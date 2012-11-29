using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
                return txtCommunity.Text.Trim();
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
