using System.Windows.Forms;
using System.Net;

namespace SNMPManager
{
    public partial class HostAddForm : Form
    {
        internal string HostName
        {
            get
            {
                return string.IsNullOrEmpty(txtNome.Text) ? null : txtNome.Text.Trim();
            }
        }

        internal IPAddress IPAddr
        {
            get
            {
                IPAddress ip;
                if (IPAddress.TryParse(txtIPAddr.Text, out ip))
                    return ip;
                else
                    return null;
            }
        }

        internal ushort PortNum
        {
            get
            {
                ushort port;
                if (ushort.TryParse(txtPortNum.Text, out port))
                    return port;
                else
                    return 0;
            }
        }

        internal string Community
        {
            get
            {
                return string.IsNullOrEmpty(txtCommunity.Text) ? null : txtCommunity.Text.Trim();
            }
        }

        internal bool IsValid
        {
            get
            {
                return IPAddr != null && PortNum > 0 && !string.IsNullOrEmpty(Community);
            }
        }

        public HostAddForm()
        {
            InitializeComponent();
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

        private void HostAddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.IsValid)
            {
                if (DialogResult.Yes == MessageBox.Show("Dados inválidos, deseja descartá-los?", "Confirma", MessageBoxButtons.YesNo))
                    this.DialogResult = DialogResult.Cancel;
                else
                    e.Cancel = true;
            }
        }
    }
}
