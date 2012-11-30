namespace SNMPManager
{
    partial class HostAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HostAddForm));
            this.txtIPAddr = new System.Windows.Forms.TextBox();
            this.txtPortNum = new System.Windows.Forms.TextBox();
            this.txtCommunity = new System.Windows.Forms.TextBox();
            this.lblIPAddr = new System.Windows.Forms.Label();
            this.lblPortNum = new System.Windows.Forms.Label();
            this.lblCommunity = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtIPAddr
            // 
            this.txtIPAddr.Location = new System.Drawing.Point(92, 38);
            this.txtIPAddr.Name = "txtIPAddr";
            this.txtIPAddr.Size = new System.Drawing.Size(100, 20);
            this.txtIPAddr.TabIndex = 3;
            this.txtIPAddr.Text = "127.0.0.1";
            // 
            // txtPortNum
            // 
            this.txtPortNum.Location = new System.Drawing.Point(92, 65);
            this.txtPortNum.Name = "txtPortNum";
            this.txtPortNum.Size = new System.Drawing.Size(50, 20);
            this.txtPortNum.TabIndex = 5;
            this.txtPortNum.Text = "161";
            // 
            // txtCommunity
            // 
            this.txtCommunity.Location = new System.Drawing.Point(92, 92);
            this.txtCommunity.Name = "txtCommunity";
            this.txtCommunity.Size = new System.Drawing.Size(100, 20);
            this.txtCommunity.TabIndex = 7;
            this.txtCommunity.Text = "public";
            // 
            // lblIPAddr
            // 
            this.lblIPAddr.AutoSize = true;
            this.lblIPAddr.Location = new System.Drawing.Point(7, 41);
            this.lblIPAddr.Name = "lblIPAddr";
            this.lblIPAddr.Size = new System.Drawing.Size(79, 13);
            this.lblIPAddr.TabIndex = 2;
            this.lblIPAddr.Text = "IP / Hostname:";
            this.lblIPAddr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPortNum
            // 
            this.lblPortNum.AutoSize = true;
            this.lblPortNum.Location = new System.Drawing.Point(51, 68);
            this.lblPortNum.Name = "lblPortNum";
            this.lblPortNum.Size = new System.Drawing.Size(35, 13);
            this.lblPortNum.TabIndex = 4;
            this.lblPortNum.Text = "Porta:";
            this.lblPortNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCommunity
            // 
            this.lblCommunity.AutoSize = true;
            this.lblCommunity.Location = new System.Drawing.Point(17, 95);
            this.lblCommunity.Name = "lblCommunity";
            this.lblCommunity.Size = new System.Drawing.Size(69, 13);
            this.lblCommunity.TabIndex = 6;
            this.lblCommunity.Text = "Comunidade:";
            this.lblCommunity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(67, 118);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "Adicionar";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(51, 15);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Nome:";
            this.lblNome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(92, 12);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(100, 20);
            this.txtNome.TabIndex = 1;
            // 
            // HostAddForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 147);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblCommunity);
            this.Controls.Add(this.lblPortNum);
            this.Controls.Add(this.lblIPAddr);
            this.Controls.Add(this.txtCommunity);
            this.Controls.Add(this.txtPortNum);
            this.Controls.Add(this.txtIPAddr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HostAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adicionar Host";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HostAddForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIPAddr;
        private System.Windows.Forms.TextBox txtPortNum;
        private System.Windows.Forms.TextBox txtCommunity;
        private System.Windows.Forms.Label lblIPAddr;
        private System.Windows.Forms.Label lblPortNum;
        private System.Windows.Forms.Label lblCommunity;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;

    }
}