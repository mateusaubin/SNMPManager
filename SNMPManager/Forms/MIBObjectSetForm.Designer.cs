namespace SNMPManager
{
    partial class MIBObjectSetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MIBObjectSetForm));
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdrTimestamp = new System.Windows.Forms.RadioButton();
            this.rdrInteger = new System.Windows.Forms.RadioButton();
            this.rdrIP = new System.Windows.Forms.RadioButton();
            this.rdrString = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancela = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(53, 13);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(208, 20);
            this.txtValue.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Valor:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdrTimestamp);
            this.groupBox1.Controls.Add(this.rdrInteger);
            this.groupBox1.Controls.Add(this.rdrIP);
            this.groupBox1.Controls.Add(this.rdrString);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 72);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Dado";
            // 
            // rdrTimestamp
            // 
            this.rdrTimestamp.AutoSize = true;
            this.rdrTimestamp.Enabled = false;
            this.rdrTimestamp.Location = new System.Drawing.Point(146, 44);
            this.rdrTimestamp.Name = "rdrTimestamp";
            this.rdrTimestamp.Size = new System.Drawing.Size(76, 17);
            this.rdrTimestamp.TabIndex = 3;
            this.rdrTimestamp.Text = "Timestamp";
            this.rdrTimestamp.UseVisualStyleBackColor = true;
            // 
            // rdrInteger
            // 
            this.rdrInteger.AutoSize = true;
            this.rdrInteger.Enabled = false;
            this.rdrInteger.Location = new System.Drawing.Point(146, 20);
            this.rdrInteger.Name = "rdrInteger";
            this.rdrInteger.Size = new System.Drawing.Size(54, 17);
            this.rdrInteger.TabIndex = 2;
            this.rdrInteger.Text = "Inteiro";
            this.rdrInteger.UseVisualStyleBackColor = true;
            // 
            // rdrIP
            // 
            this.rdrIP.AutoSize = true;
            this.rdrIP.Enabled = false;
            this.rdrIP.Location = new System.Drawing.Point(22, 44);
            this.rdrIP.Name = "rdrIP";
            this.rdrIP.Size = new System.Drawing.Size(84, 17);
            this.rdrIP.TabIndex = 1;
            this.rdrIP.Text = "Endereço IP";
            this.rdrIP.UseVisualStyleBackColor = true;
            // 
            // rdrString
            // 
            this.rdrString.AutoSize = true;
            this.rdrString.Checked = true;
            this.rdrString.Location = new System.Drawing.Point(22, 20);
            this.rdrString.Name = "rdrString";
            this.rdrString.Size = new System.Drawing.Size(52, 17);
            this.rdrString.TabIndex = 0;
            this.rdrString.TabStop = true;
            this.rdrString.Text = "String";
            this.rdrString.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.AutoSize = true;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(39, 118);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancela
            // 
            this.btnCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancela.Location = new System.Drawing.Point(145, 118);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(100, 23);
            this.btnCancela.TabIndex = 4;
            this.btnCancela.Text = "Cancelar";
            this.btnCancela.UseVisualStyleBackColor = true;
            // 
            // MIBObjectSetForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancela;
            this.ClientSize = new System.Drawing.Size(284, 148);
            this.Controls.Add(this.btnCancela);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MIBObjectSetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Definir Valor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdrString;
        private System.Windows.Forms.RadioButton rdrIP;
        private System.Windows.Forms.RadioButton rdrTimestamp;
        private System.Windows.Forms.RadioButton rdrInteger;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancela;
    }
}