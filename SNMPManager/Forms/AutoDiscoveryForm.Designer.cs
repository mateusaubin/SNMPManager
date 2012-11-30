namespace SNMPManager
{
    partial class AutoDiscoveryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoDiscoveryForm));
            this.lblCommunity = new System.Windows.Forms.Label();
            this.txtCommunity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIPIni = new System.Windows.Forms.TextBox();
            this.txtIPFin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lstIP = new System.Windows.Forms.ListBox();
            this.txtPortNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCommunity
            // 
            this.lblCommunity.AutoSize = true;
            this.lblCommunity.Location = new System.Drawing.Point(14, 16);
            this.lblCommunity.Name = "lblCommunity";
            this.lblCommunity.Size = new System.Drawing.Size(69, 13);
            this.lblCommunity.TabIndex = 0;
            this.lblCommunity.Text = "Comunidade:";
            this.lblCommunity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCommunity
            // 
            this.txtCommunity.Location = new System.Drawing.Point(89, 13);
            this.txtCommunity.Name = "txtCommunity";
            this.txtCommunity.Size = new System.Drawing.Size(75, 20);
            this.txtCommunity.TabIndex = 1;
            this.txtCommunity.Text = "public";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP Inicial:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIPIni
            // 
            this.txtIPIni.Location = new System.Drawing.Point(89, 65);
            this.txtIPIni.Name = "txtIPIni";
            this.txtIPIni.Size = new System.Drawing.Size(100, 20);
            this.txtIPIni.TabIndex = 5;
            this.txtIPIni.Text = "192.168.25.1";
            // 
            // txtIPFin
            // 
            this.txtIPFin.Location = new System.Drawing.Point(89, 91);
            this.txtIPFin.Name = "txtIPFin";
            this.txtIPFin.Size = new System.Drawing.Size(100, 20);
            this.txtIPFin.TabIndex = 7;
            this.txtIPFin.Text = "192.168.25.254";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "IP Final:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(57, 119);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lstIP
            // 
            this.lstIP.FormattingEnabled = true;
            this.lstIP.Location = new System.Drawing.Point(8, 148);
            this.lstIP.Name = "lstIP";
            this.lstIP.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstIP.Size = new System.Drawing.Size(181, 134);
            this.lstIP.TabIndex = 9;
            // 
            // txtPortNum
            // 
            this.txtPortNum.Location = new System.Drawing.Point(89, 39);
            this.txtPortNum.Name = "txtPortNum";
            this.txtPortNum.Size = new System.Drawing.Size(75, 20);
            this.txtPortNum.TabIndex = 3;
            this.txtPortNum.Text = "161";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Porta:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AutoDiscoveryForm
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 292);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPortNum);
            this.Controls.Add(this.lstIP);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtIPFin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIPIni);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCommunity);
            this.Controls.Add(this.lblCommunity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoDiscoveryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Autodescoberta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCommunity;
        private System.Windows.Forms.TextBox txtCommunity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIPIni;
        private System.Windows.Forms.TextBox txtIPFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ListBox lstIP;
        private System.Windows.Forms.TextBox txtPortNum;
        private System.Windows.Forms.Label label3;
    }
}