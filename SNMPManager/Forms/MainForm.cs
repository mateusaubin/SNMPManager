using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SNMPManager
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Objetos da MIB disponíveis para consulta
        /// </summary>
        public BindingList<MibObject> MIBObjects { get; protected set; }

        /// <summary>
        /// Hosts disponíveis para consulta
        /// </summary>
        public BindingList<SNMPHost> Hosts { get; protected set; }

        /// <summary>
        /// Histórico de comunicação
        /// </summary>
        public BindingList<SNMPCommunications> SNMPCommunications { get; protected set; }

        /// <summary>
        /// Objeto da MIB selecionado atualmente
        /// </summary>
        public MibObject SelectedMibObject
        {
            get
            {
                return mibList.SelectedItem as MibObject;
            }
        }

        /// <summary>
        /// Host selecionado atualmente
        /// </summary>
        public SNMPHost SelectedHost
        {
            get
            {
                return hostList.SelectedItem as SNMPHost;
            }
        }

        /// <summary>
        /// Construtor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            InitializeDataStructures();
            DataBind();
            Clear();
        }

        /// <summary>
        /// Limpa os defaults
        /// </summary>
        private void Clear()
        {
            statusbar.Text = string.Empty;
            mibList.ClearSelected();
            hostList.ClearSelected();
        }

        /// <summary>
        /// Associa as coleções aos controles de tela
        /// </summary>
        private void DataBind()
        {
            communicationGrid.DataSource = SNMPCommunications;

            mibList.DataSource = MIBObjects;

            hostList.DataSource = Hosts;
        }

        /// <summary>
        /// Inicializa as coleções
        /// </summary>
        private void InitializeDataStructures()
        {
            SNMPCommunications = new BindingList<SNMPCommunications>();
            MIBObjects = new BindingList<MibObject>();
            Hosts = new BindingList<SNMPHost>();

            // MIB-II
            MIBObjects.Add(new MibObject() { OID = "1.3.6.1.2.1.1.5", Name = "sysName" });
            MIBObjects.Add(new MibObject() { OID = "1.3.6.1.2.1.1.6", Name = "sysLocation", CanSet = true });
            MIBObjects.Add(new MibObject() { OID = "1.3.6.1.2.1.1.3", Name = "sysUpTime" });
            MIBObjects.Add(new MibObject() { OID = "1.3.6.1.2.1.25.1.6", Name = "hrSystemProcesses" });
            // MIB-Custom
            MIBObjects.Add(new MibObject() { OID = "1.3.6.1.4.1.1.2", Name = "screenResolutionWidth" });
            MIBObjects.Add(new MibObject() { OID = "1.3.6.1.4.1.1.3", Name = "screenResolutionHeight" });
            MIBObjects.Add(new MibObject() { OID = "1.3.6.1.4.1.1.6", Name = "filesystemCount" });
        }

        /// <summary>
        /// Mostra detalhes de um Objeto da MIB na StatusBar
        /// </summary>
        private void mibList_UpdateStatusBar(object sender, EventArgs e)
        {
            if (SelectedMibObject != null)
                statusbar.Text = string.Format("{0} ({1})", SelectedMibObject, SelectedMibObject.OID);
            else
                statusbar.Text = string.Empty;
        }

        /// <summary>
        /// Habilita a seleção de um objeto da MIB com o botão direito
        /// </summary>
        private void mibList_RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = mibList.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    mibList.SelectedIndex = index;
                    mibList_UpdateStatusBar(null, null);
                }
            }

        }

        /// <summary>
        /// Mostra detalhes de um Host na StatusBar
        /// </summary>
        private void hostList_UpdateStatusBar(object sender, EventArgs e)
        {
            if (SelectedHost != null)
                statusbar.Text = string.Format("{0} ({1}:{2})", SelectedHost, SelectedHost.IP, SelectedHost.Port);
            else
                statusbar.Text = string.Empty;
        }

        /// <summary>
        /// Trata a operação de Adicionar Host
        /// </summary>
        private void adicionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var hostAdd = new HostAddForm())
            {
                var result = hostAdd.ShowDialog(this);
                switch (result)
                {
                    case DialogResult.OK:
                        // TODO: Validar se já existe
                        Hosts.Add(
                            new SNMPHost()
                            {
                                IP = hostAdd.IPAddr,
                                Port = hostAdd.PortNum,
                                Community = hostAdd.Community,
                                Name = hostAdd.HostName
                            }
                        );
                        hostList_UpdateStatusBar(null, null);
                        hostList.Focus();
                        break;
                    case DialogResult.Cancel:
                        // Faz nada não
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Trata a operação de Remover Host
        /// </summary>
        private void removerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Hosts.Count > 0)
            {
                if (!ValidaHostSelecionado())
                    return;

                Hosts.Remove(SelectedHost);
            }
            hostList_UpdateStatusBar(null, null);
            hostList.Focus();
        }

        /// <summary>
        /// Controla se a operação Set está disponível para um objeto da MIB
        /// </summary>
        private void mibListMenu_Opening(object sender, CancelEventArgs e)
        {
            mibListMenu.Items[1].Enabled = SelectedMibObject.CanSet;
        }

        /// <summary>
        /// Trata a operação de Get de um objeto da MIB sobre um Host
        /// </summary>
        private void getToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ValidaHostSelecionado())
                return;

            var req = new SNMPCommunications(SelectedHost, SelectedMibObject);
            try
            {
                req.Send();
                SNMPCommunications.Add(req);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Trata a operação de Set de um objeto da MIB sobre um Host
        /// </summary>
        private void setToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ValidaHostSelecionado())
                return;

            using (var setValue = new MIBObjectSetForm())
            {
                var result = setValue.ShowDialog(this);
                switch (result)
                {
                    case DialogResult.OK:
                        try
                        {
                            var req = new SNMPCommunications(SelectedHost, SelectedMibObject);
                            req.Send(setValue.ConvertedValue());
                            SNMPCommunications.Add(req);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case DialogResult.Cancel:
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Limpa os registros da tabela
        /// </summary>
        private void limparToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SNMPCommunications.Clear();
        }

        private void autodescobertaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var autoDisc = new AutoDiscoveryForm())
            {
                var result = autoDisc.ShowDialog(this);

                if (autoDisc.Hosts != null && autoDisc.Hosts.Count > 0)
                {
                    foreach (var item in autoDisc.Hosts)
                        this.Hosts.Add(item);

                    hostList_UpdateStatusBar(null, null);
                    hostList.Focus();
                }
            }
        }

        private void isAliveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AddMonitoringEvent(MonitorKind.IsAlive);
        }

        private void AddMonitoringEvent(MonitorKind monitorKind)
        {
            if (!ValidaHostSelecionado())
                return;

            if (SelectedHost.AddMonitoringEvent(monitorKind))
            {
                // Insere na lista de hosts monitorados
                lstMonitorados.Items.Add(string.Format("{0}: {1}", monitorKind, SelectedHost));
            }

            // Habilita timer
            if (!tmrMonitor.Enabled)
            {
                tmrMonitor.Enabled = true;

                // Força a primeira execução
                //tmrMonitor_Tick(null, null);
            }
        }

        private bool ValidaHostSelecionado()
        {
            bool isSelected = SelectedHost != null;

            if (!isSelected)
                MessageBox.Show("Por favor, selecione um Host.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return isSelected;
        }

        private void tmrMonitor_Tick(object sender, EventArgs e)
        {
            var list = lstMonitoringLog;
            var code = new Action<string>((v) => { list.Items.Add(string.Format("{0} - {1}", DateTime.Now, v)); list.TopIndex = list.Items.Count - 1; });
            string msg = "Monitorando...";

            if (list.InvokeRequired)
                list.Invoke(code, msg);
            else
                code.Invoke(msg);


            if (!bwMonitor.IsBusy)
                bwMonitor.RunWorkerAsync();
        }

        private void bwMonitor_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            if (worker == null)
                throw new Exception("Aconteceu algo com o BackgroundWorker");

            var list = lstMonitoringLog;
            var code = new Action<MonitorEvent>((v) => { list.Items.Add(v); list.TopIndex = list.Items.Count - 1; });

            // TODO: Corrigir o problema do Enumerator quando remove um host da collection original
            var hostsCopy = new SNMPHost[Hosts.Count];
            Hosts.CopyTo(hostsCopy, 0);

            // Executa o Monitor passando todos os Hosts
            foreach (var evt in SNMPMonitor.Instance.Exec(hostsCopy))
            {
                if (list.InvokeRequired)
                    list.Invoke(code, evt);
                else
                    code.Invoke(evt);
            }
        }

        private void pararToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tmrMonitor.Enabled = false;
            foreach (var host in Hosts)
                host.MonitoredEvents.Clear();
            lstMonitorados.Items.Clear();
        }
    }
}
