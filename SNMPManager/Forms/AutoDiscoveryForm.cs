using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace SNMPManager
{
    /// <summary>
    /// Autodescoberta de hosts SNMP na Rede
    /// </summary>
    public partial class AutoDiscoveryForm : Form
    {
        private int _threads;
        private ushort _pingTimeout;

        /// <summary>
        /// Número padrão de Threads
        /// </summary>
        public static readonly byte MAX_THREADS = 25;

        /// <summary>
        /// Timout padrão do Ping
        /// </summary>
        public static readonly ushort PING_TIMEOUT = 500;

        /// <summary>
        /// OID do objeto SysName da MIB-II
        /// </summary>
        public static readonly MibObject SNMP_SYSNAME = new MibObject() { OID = "1.3.6.1.2.1.1.5" };

        /// <summary>
        /// Quantidade de Threads para varrer a Rede
        /// </summary>
        public int ThreadCount
        {
            get
            {
                return _threads == 0 ? MAX_THREADS : _threads;
            }
            set
            {
                _threads = value;
            }
        }

        /// <summary>
        /// Timeout em milliseconds do Ping
        /// </summary>
        public ushort PingTimeout
        {
            get
            {
                return _pingTimeout == 0 ? PING_TIMEOUT : _pingTimeout;
            }
            set
            {
                _pingTimeout = value;
            }
        }

        /// <summary>
        /// IP Inicial da faixa a ser buscada
        /// </summary>
        public IPAddress IPInicial
        {
            get
            {
                IPAddress ip;
                return IPAddress.TryParse(txtIPIni.Text, out ip) ? ip : null;
            }
        }

        /// <summary>
        /// IP Final da faixa a ser buscada
        /// </summary>
        public IPAddress IPFinal
        {
            get
            {
                IPAddress ip;
                return IPAddress.TryParse(txtIPFin.Text, out ip) ? ip : null;
            }
        }

        /// <summary>
        /// Porta de destino da busca
        /// </summary>
        public ushort Porta
        {
            get
            {
                ushort p = 0;
                return ushort.TryParse(txtPortNum.Text, out p) ? p : (ushort)161;
            }
        }

        /// <summary>
        /// Nome da comunidade SNMP
        /// </summary>
        public string Comunidade
        {
            get
            {
                return string.IsNullOrEmpty(txtCommunity.Text) ? null : txtCommunity.Text.Trim();
            }
        }

        /// <summary>
        /// Formulário está preenchido com dados válidos?
        /// </summary>
        public bool IsValid
        {
            get
            {
                return IPInicial != null && IPFinal != null && Porta > 0 && !string.IsNullOrEmpty(Comunidade);
            }
        }

        /// <summary>
        /// Hosts encontrados
        /// </summary>
        public BindingList<SNMPHost> Hosts { get; protected set; }

        public AutoDiscoveryForm()
        {
            InitializeComponent();
            Hosts = new BindingList<SNMPHost>();
            lstIP.DataSource = Hosts;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!IsValid)
            {
                MessageBox.Show("Por favor, preencha o formulário.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var btn = sender as Button;
            btn.Enabled = false;
            Hosts.Clear();

            // Converte os IP's para númerico pra facilitar o trabalho
            var ini = (long)(uint)IPAddress.NetworkToHostOrder((int)IPInicial.Address);
            var fin = (long)(uint)IPAddress.NetworkToHostOrder((int)IPFinal.Address);
            var cur = ini;

            Logger.Self.Log("IP", LogType.DISCOVERY);
            // Tenta pingar os hosts no range
            var ipList = PingRange(cur, fin);

            Logger.Self.Log("SNMP", LogType.DISCOVERY);
            // Tenta buscar o SysName via SNMP
            var foundList = SNMPGetSysName(ipList);

            // Apresenta os hosts encontrados
            foreach (var item in foundList)
                Hosts.Add(item);

            Logger.Self.Log(string.Format("Concluída com {0} Hosts", Hosts.Count), LogType.DISCOVERY);
            btn.Enabled = true;
            MessageBox.Show("Autodescoberta concluída.", "SNMPManager", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Escaneia o Range de IP's informado enviando Pings.
        /// Caso obtenha resposta adiciona à lista de possíveis Hosts com SNMP.
        /// </summary>
        /// <returns>IP's que responderam ao Ping</returns>
        private IList<IPAddress> PingRange(long cur, long fin)
        {
            List<IPAddress> ipList = new List<IPAddress>();

            using (var q = new SuperQueue<IPAddress>(
                ThreadCount,
                delegate(IPAddress ip)
                {
                    var pingExec = new Ping();
                    PingReply pingReply;
                    try
                    {
                        pingReply = pingExec.Send(ip, PingTimeout);
                        if (pingReply != null && pingReply.Status == IPStatus.Success)
                        {
                            Debug.WriteLine(ip);

                            // Adiciona na lista
                            lock (ipList)
                                ipList.Add(ip);
                        }
                    }
                    catch { } // Ignora erros
                }))
            {
                Debug.WriteLine("Pingando hosts");
                while (cur <= fin)
                {
                    q.EnqueueTask(IPAddress.Parse(cur.ToString()));
                    cur++;
                }
            }
            return ipList;
        }

        /// <summary>
        /// Escaneia uma lista de IP's em busca de respostas SNMP.
        /// Caso obtenha resposta cria um SNMPHost representando este Host.
        /// </summary>
        /// <returns>Hosts com SNMP</returns>
        private IList<SNMPHost> SNMPGetSysName(IList<IPAddress> ipList)
        {
            List<SNMPHost> foundList = new List<SNMPHost>();

            using (var q = new SuperQueue<IPAddress>(
                ThreadCount / 2, // Reduz as threads para não sobrecarregar a rede
                delegate(IPAddress ip)
                {
                    var host = new SNMPHost() { Community = Comunidade, IP = ip, Port = Porta };
                    var request = new SNMPRequest(host, SNMP_SYSNAME) 
                                    { 
                                        TimeOut = PingTimeout, 
                                        Retries = 4, 
                                        LogRequests = false // Não loga para economizar recursos
                                    };

                    try
                    {
                        request.Send();
                        if (request.ResponseValue != null)
                        {
                            Debug.WriteLine(ip);

                            // Define o nome retornado pelo SNMP
                            host.Name = request.ResponseValue.ToString();

                            // Adiciona na lista
                            lock (foundList)
                                foundList.Add(host);
                        }
                    }
                    catch { } // Ignora erros
                }))
            {
                Debug.WriteLine("Verificando protocolo SNMP");
                foreach (var ip in ipList)
                    q.EnqueueTask(ip);
            }
            return foundList;
        }
    }
}
