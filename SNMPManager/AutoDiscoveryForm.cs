using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Diagnostics;
using SnmpSharpNet;

namespace SNMPManager
{
    public partial class AutoDiscoveryForm : Form
    {
        public IPAddress IPInicial
        {
            get
            {
                IPAddress ip;
                return IPAddress.TryParse(txtIPIni.Text, out ip) ? ip : null;
            }
        }

        public IPAddress IPFinal
        {
            get
            {
                IPAddress ip;
                return IPAddress.TryParse(txtIPFin.Text, out ip) ? ip : null;
            }
        }

        public ushort Porta
        {
            get
            {
                ushort p = 0;
                return ushort.TryParse(txtPortNum.Text, out p) ? p : (ushort)0;
            }
        }

        public string Comunidade
        {
            get
            {
                return string.IsNullOrEmpty(txtCommunity.Text) ? null : txtCommunity.Text.Trim();
            }
        }

        public BindingList<SNMPHost> Hosts { get; protected set; }

        public AutoDiscoveryForm()
        {
            InitializeComponent();
            Hosts = new BindingList<SNMPHost>();
            lstIP.DataSource = Hosts;
            lstIP.DisplayMember = "DisplayName";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            btn.Enabled = false;
            Hosts.Clear();

            var ini = (long)(uint)IPAddress.NetworkToHostOrder((int)IPInicial.Address);
            var fin = (long)(uint)IPAddress.NetworkToHostOrder((int)IPFinal.Address);
            var cur = ini;

            var ipList = new List<IPAddress>();
            var foundList = new List<SNMPHost>();

            using (var q = new SuperQueue<IPAddress>(10,
                delegate(IPAddress ip)
                {
                    var pingExec = new Ping();
                    PingReply pingReply;
                    try
                    {
                        pingReply = pingExec.Send(ip, 250);
                        if (pingReply != null && pingReply.Status == IPStatus.Success)
                        {
                            Debug.WriteLine(ip);
                            lock (ipList)
                                ipList.Add(ip);
                        }
                    }
                    catch { }
                }))
            {
                Debug.WriteLine("Pingando hosts");
                while (cur <= fin)
                {
                    q.EnqueueTask(IPAddress.Parse(cur.ToString()));
                    cur++;
                }
            }
            using (var q = new SuperQueue<IPAddress>(1,
                delegate(IPAddress ip)
                {
                    var defHost = new SNMPHost() { Community = txtCommunity.Text, Port = (Porta > 0 ? Porta : (ushort)161) };
                    var defMibObj = new MibObject() { OID = "1.3.6.1.2.1.1.5" };
                    var defRequest = new SNMPRequest(defHost, defMibObj);

                    try
                    {
                        defRequest.Host.IP = ip;
                        defRequest.Send();
                        if (defRequest.ResponseValue != null)
                        {
                            Debug.WriteLine(ip);
                            lock (foundList)
                                foundList.Add(
                                    new SNMPHost()
                                    {
                                        Port = defHost.Port,
                                        Community = defHost.Community,
                                        IP = defHost.IP
                                    }
                                );
                        }
                    }
                    catch { }
                }))
            {
                Debug.WriteLine("Verificando protocolo SNMP");
                foreach (var ip in ipList)
                    q.EnqueueTask(ip);
            }

            foreach (var item in foundList)
                Hosts.Add(item);
            btn.Enabled = true;
        }
    }
}
