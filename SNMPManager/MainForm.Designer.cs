namespace SNMPManager
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.adicionarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mibList = new System.Windows.Forms.ListBox();
            this.mibListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.getToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusbar = new System.Windows.Forms.ToolStripStatusLabel();
            this.hostList = new System.Windows.Forms.ListBox();
            this.communicationGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.limparToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autodescobertaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timestampDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hostnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objetoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responseValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNMPCommunicationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuBar.SuspendLayout();
            this.mibListMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.communicationGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sNMPCommunicationsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.resultadosToolStripMenuItem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(484, 24);
            this.menuBar.TabIndex = 3;
            this.menuBar.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autodescobertaToolStripMenuItem,
            this.adicionarToolStripMenuItem,
            this.removerToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeyDisplayString = "";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(49, 20);
            this.toolStripMenuItem1.Text = "Hosts";
            // 
            // adicionarToolStripMenuItem
            // 
            this.adicionarToolStripMenuItem.Name = "adicionarToolStripMenuItem";
            this.adicionarToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.adicionarToolStripMenuItem.Text = "Adicionar";
            this.adicionarToolStripMenuItem.Click += new System.EventHandler(this.adicionarToolStripMenuItem_Click);
            // 
            // removerToolStripMenuItem
            // 
            this.removerToolStripMenuItem.Name = "removerToolStripMenuItem";
            this.removerToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.removerToolStripMenuItem.Text = "Remover";
            this.removerToolStripMenuItem.Click += new System.EventHandler(this.removerToolStripMenuItem_Click);
            // 
            // mibList
            // 
            this.mibList.ContextMenuStrip = this.mibListMenu;
            this.mibList.FormattingEnabled = true;
            this.mibList.Location = new System.Drawing.Point(245, 27);
            this.mibList.Name = "mibList";
            this.mibList.Size = new System.Drawing.Size(235, 134);
            this.mibList.TabIndex = 1;
            this.mibList.Click += new System.EventHandler(this.mibList_UpdateStatusBar);
            this.mibList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mibList_RightClick);
            // 
            // mibListMenu
            // 
            this.mibListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getToolStripMenuItem,
            this.setToolStripMenuItem});
            this.mibListMenu.Name = "contextMenuStrip1";
            this.mibListMenu.Size = new System.Drawing.Size(93, 48);
            this.mibListMenu.Text = "Get";
            this.mibListMenu.Opening += new System.ComponentModel.CancelEventHandler(this.mibListMenu_Opening);
            // 
            // getToolStripMenuItem
            // 
            this.getToolStripMenuItem.Name = "getToolStripMenuItem";
            this.getToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.getToolStripMenuItem.Text = "Get";
            this.getToolStripMenuItem.Click += new System.EventHandler(this.getToolStripMenuItem_Click);
            // 
            // setToolStripMenuItem
            // 
            this.setToolStripMenuItem.Name = "setToolStripMenuItem";
            this.setToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.setToolStripMenuItem.Text = "Set";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusbar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 340);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(484, 22);
            this.statusStrip1.TabIndex = 4;
            // 
            // statusbar
            // 
            this.statusbar.Name = "statusbar";
            this.statusbar.Size = new System.Drawing.Size(77, 17);
            this.statusbar.Text = "statusbarText";
            // 
            // hostList
            // 
            this.hostList.FormattingEnabled = true;
            this.hostList.Location = new System.Drawing.Point(4, 27);
            this.hostList.Name = "hostList";
            this.hostList.Size = new System.Drawing.Size(235, 134);
            this.hostList.TabIndex = 0;
            this.hostList.Click += new System.EventHandler(this.hostList_UpdateStatusBar);
            // 
            // communicationGrid
            // 
            this.communicationGrid.AllowUserToAddRows = false;
            this.communicationGrid.AllowUserToDeleteRows = false;
            this.communicationGrid.AutoGenerateColumns = false;
            this.communicationGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.communicationGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.communicationGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.communicationGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.timestampDataGridViewTextBoxColumn,
            this.hostnameDataGridViewTextBoxColumn,
            this.tipoDataGridViewTextBoxColumn,
            this.objetoDataGridViewTextBoxColumn,
            this.responseValueDataGridViewTextBoxColumn});
            this.communicationGrid.DataSource = this.sNMPCommunicationsBindingSource;
            this.communicationGrid.Location = new System.Drawing.Point(4, 166);
            this.communicationGrid.Name = "communicationGrid";
            this.communicationGrid.ReadOnly = true;
            this.communicationGrid.RowHeadersVisible = false;
            this.communicationGrid.Size = new System.Drawing.Size(476, 170);
            this.communicationGrid.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ResponseValue";
            this.dataGridViewTextBoxColumn2.HeaderText = "ResponseValue";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // resultadosToolStripMenuItem
            // 
            this.resultadosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.limparToolStripMenuItem});
            this.resultadosToolStripMenuItem.Name = "resultadosToolStripMenuItem";
            this.resultadosToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.resultadosToolStripMenuItem.Text = "Resultados";
            // 
            // limparToolStripMenuItem
            // 
            this.limparToolStripMenuItem.Name = "limparToolStripMenuItem";
            this.limparToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.limparToolStripMenuItem.Text = "Limpar";
            this.limparToolStripMenuItem.Click += new System.EventHandler(this.limparToolStripMenuItem_Click);
            // 
            // autodescobertaToolStripMenuItem
            // 
            this.autodescobertaToolStripMenuItem.Name = "autodescobertaToolStripMenuItem";
            this.autodescobertaToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.autodescobertaToolStripMenuItem.Text = "Autodescoberta";
            this.autodescobertaToolStripMenuItem.Click += new System.EventHandler(this.autodescobertaToolStripMenuItem_Click);
            // 
            // timestampDataGridViewTextBoxColumn
            // 
            this.timestampDataGridViewTextBoxColumn.DataPropertyName = "Timestamp";
            this.timestampDataGridViewTextBoxColumn.HeaderText = "Timestamp";
            this.timestampDataGridViewTextBoxColumn.Name = "timestampDataGridViewTextBoxColumn";
            this.timestampDataGridViewTextBoxColumn.ReadOnly = true;
            this.timestampDataGridViewTextBoxColumn.Width = 83;
            // 
            // hostnameDataGridViewTextBoxColumn
            // 
            this.hostnameDataGridViewTextBoxColumn.DataPropertyName = "Hostname";
            this.hostnameDataGridViewTextBoxColumn.HeaderText = "Hostname";
            this.hostnameDataGridViewTextBoxColumn.Name = "hostnameDataGridViewTextBoxColumn";
            this.hostnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.hostnameDataGridViewTextBoxColumn.Width = 80;
            // 
            // tipoDataGridViewTextBoxColumn
            // 
            this.tipoDataGridViewTextBoxColumn.DataPropertyName = "Tipo";
            this.tipoDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipoDataGridViewTextBoxColumn.Name = "tipoDataGridViewTextBoxColumn";
            this.tipoDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoDataGridViewTextBoxColumn.Width = 53;
            // 
            // objetoDataGridViewTextBoxColumn
            // 
            this.objetoDataGridViewTextBoxColumn.DataPropertyName = "Objeto";
            this.objetoDataGridViewTextBoxColumn.HeaderText = "Objeto";
            this.objetoDataGridViewTextBoxColumn.Name = "objetoDataGridViewTextBoxColumn";
            this.objetoDataGridViewTextBoxColumn.ReadOnly = true;
            this.objetoDataGridViewTextBoxColumn.Width = 63;
            // 
            // responseValueDataGridViewTextBoxColumn
            // 
            this.responseValueDataGridViewTextBoxColumn.DataPropertyName = "ResponseValue";
            this.responseValueDataGridViewTextBoxColumn.HeaderText = "ResponseValue";
            this.responseValueDataGridViewTextBoxColumn.Name = "responseValueDataGridViewTextBoxColumn";
            this.responseValueDataGridViewTextBoxColumn.ReadOnly = true;
            this.responseValueDataGridViewTextBoxColumn.Width = 107;
            // 
            // sNMPCommunicationsBindingSource
            // 
            this.sNMPCommunicationsBindingSource.DataSource = typeof(SNMPManager.SNMPCommunications);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 362);
            this.Controls.Add(this.hostList);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.communicationGrid);
            this.Controls.Add(this.mibList);
            this.Controls.Add(this.menuBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SNMPManager - 2012";
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.mibListMenu.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.communicationGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sNMPCommunicationsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem adicionarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removerToolStripMenuItem;
        private System.Windows.Forms.ListBox mibList;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusbar;
        private System.Windows.Forms.ListBox hostList;
        private System.Windows.Forms.ContextMenuStrip mibListMenu;
        private System.Windows.Forms.ToolStripMenuItem getToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setToolStripMenuItem;
        private System.Windows.Forms.DataGridView communicationGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn hostDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource sNMPCommunicationsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestampDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hostnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn objetoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn responseValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ToolStripMenuItem resultadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem limparToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autodescobertaToolStripMenuItem;
    }
}