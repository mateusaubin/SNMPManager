using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SnmpSharpNet;

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
            mibList.DisplayMember = "DisplayName";

            hostList.DataSource = Hosts;
            hostList.DisplayMember = "DisplayName";
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
                statusbar.Text = string.Format("{0} ({1})", SelectedMibObject.DisplayName, SelectedMibObject.OID);
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
                    mibList.SelectedIndex = index;
            }

        }

        /// <summary>
        /// Mostra detalhes de um Host na StatusBar
        /// </summary>
        private void hostList_UpdateStatusBar(object sender, EventArgs e)
        {
            if (SelectedHost != null)
                statusbar.Text = string.Format("{0} ({1}:{2})", SelectedHost.DisplayName, SelectedHost.IP, SelectedHost.Port);
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
                if (SelectedHost != null)
                    Hosts.Remove(SelectedHost);
                else
                    MessageBox.Show("Por favor, selecione um host para remover", "Erro", MessageBoxButtons.OK);
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
            if (SelectedHost == null || SelectedMibObject == null)
            {
                MessageBox.Show("Por favor, selecione um Host e um Objeto da MIB", "Erro", MessageBoxButtons.OK);
            }
            else
            {
                var req = new SNMPCommunications(SelectedHost, PduType.Get, SelectedMibObject);
                req.Send();
                SNMPCommunications.Add(req);
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
            throw new NotImplementedException();
        }
    }
}
