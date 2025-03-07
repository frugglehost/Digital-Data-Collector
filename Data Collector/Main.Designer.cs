namespace Data_Collector {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supervisorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageShopOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.engineeringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualPartNumberModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editDataPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mannagePartNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDocumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_CreateTables = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_ShopOrder = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cob_Serials = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cob_PartNumber = new System.Windows.Forms.ComboBox();
            this.cob_Rev = new System.Windows.Forms.ComboBox();
            this.tb_PartID = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pdf_Document = new PdfiumViewer.PdfRenderer();
            this.btn_Test = new System.Windows.Forms.Button();
            this.btn_Sync = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.cob_DocList = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgv_tb_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_tb_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_tb_User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Image_Value = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgv_tb_Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.supportToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1056, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // supportToolStripMenuItem
            // 
            this.supportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supervisorToolStripMenuItem,
            this.engineeringToolStripMenuItem,
            this.databaseToolsToolStripMenuItem});
            this.supportToolStripMenuItem.Name = "supportToolStripMenuItem";
            this.supportToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.supportToolStripMenuItem.Text = "Support";
            // 
            // supervisorToolStripMenuItem
            // 
            this.supervisorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageShopOrderToolStripMenuItem});
            this.supervisorToolStripMenuItem.Name = "supervisorToolStripMenuItem";
            this.supervisorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.supervisorToolStripMenuItem.Text = "Supervisor";
            // 
            // manageShopOrderToolStripMenuItem
            // 
            this.manageShopOrderToolStripMenuItem.Name = "manageShopOrderToolStripMenuItem";
            this.manageShopOrderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.manageShopOrderToolStripMenuItem.Text = "Manage Shop Order";
            // 
            // engineeringToolStripMenuItem
            // 
            this.engineeringToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualPartNumberModeToolStripMenuItem,
            this.editDataPointsToolStripMenuItem,
            this.mannagePartNumberToolStripMenuItem,
            this.manageDocumentsToolStripMenuItem});
            this.engineeringToolStripMenuItem.Name = "engineeringToolStripMenuItem";
            this.engineeringToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.engineeringToolStripMenuItem.Text = "Engineering";
            // 
            // manualPartNumberModeToolStripMenuItem
            // 
            this.manualPartNumberModeToolStripMenuItem.Name = "manualPartNumberModeToolStripMenuItem";
            this.manualPartNumberModeToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.manualPartNumberModeToolStripMenuItem.Text = "Manual Part Number Mode";
            // 
            // editDataPointsToolStripMenuItem
            // 
            this.editDataPointsToolStripMenuItem.Name = "editDataPointsToolStripMenuItem";
            this.editDataPointsToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.editDataPointsToolStripMenuItem.Text = "Edit Data Points";
            // 
            // mannagePartNumberToolStripMenuItem
            // 
            this.mannagePartNumberToolStripMenuItem.Name = "mannagePartNumberToolStripMenuItem";
            this.mannagePartNumberToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.mannagePartNumberToolStripMenuItem.Text = "Mannage Part Number";
            // 
            // manageDocumentsToolStripMenuItem
            // 
            this.manageDocumentsToolStripMenuItem.Name = "manageDocumentsToolStripMenuItem";
            this.manageDocumentsToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.manageDocumentsToolStripMenuItem.Text = "Manage Documents";
            // 
            // databaseToolsToolStripMenuItem
            // 
            this.databaseToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_CreateTables});
            this.databaseToolsToolStripMenuItem.Name = "databaseToolsToolStripMenuItem";
            this.databaseToolsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.databaseToolsToolStripMenuItem.Text = "Database Tools";
            // 
            // ts_CreateTables
            // 
            this.ts_CreateTables.Name = "ts_CreateTables";
            this.ts_CreateTables.Size = new System.Drawing.Size(180, 22);
            this.ts_CreateTables.Text = "Create All Table";
            this.ts_CreateTables.Click += new System.EventHandler(this.ts_CreateTables_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Shop Order:";
            // 
            // tb_ShopOrder
            // 
            this.tb_ShopOrder.Location = new System.Drawing.Point(82, 27);
            this.tb_ShopOrder.Name = "tb_ShopOrder";
            this.tb_ShopOrder.Size = new System.Drawing.Size(107, 20);
            this.tb_ShopOrder.TabIndex = 2;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(195, 25);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 3;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Serials:";
            // 
            // cob_Serials
            // 
            this.cob_Serials.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_Serials.FormattingEnabled = true;
            this.cob_Serials.Location = new System.Drawing.Point(323, 26);
            this.cob_Serials.Name = "cob_Serials";
            this.cob_Serials.Size = new System.Drawing.Size(144, 21);
            this.cob_Serials.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(473, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Part Number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(689, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Rev:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(806, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "PartID:";
            // 
            // cob_PartNumber
            // 
            this.cob_PartNumber.FormattingEnabled = true;
            this.cob_PartNumber.Location = new System.Drawing.Point(548, 27);
            this.cob_PartNumber.Name = "cob_PartNumber";
            this.cob_PartNumber.Size = new System.Drawing.Size(135, 21);
            this.cob_PartNumber.TabIndex = 9;
            this.cob_PartNumber.SelectedIndexChanged += new System.EventHandler(this.cob_PartNumber_SelectedIndexChanged);
            this.cob_PartNumber.Enter += new System.EventHandler(this.cob_PartNumber_Enter);
            // 
            // cob_Rev
            // 
            this.cob_Rev.FormattingEnabled = true;
            this.cob_Rev.Location = new System.Drawing.Point(725, 27);
            this.cob_Rev.Name = "cob_Rev";
            this.cob_Rev.Size = new System.Drawing.Size(75, 21);
            this.cob_Rev.TabIndex = 10;
            this.cob_Rev.SelectedIndexChanged += new System.EventHandler(this.cob_Rev_SelectedIndexChanged);
            // 
            // tb_PartID
            // 
            this.tb_PartID.Location = new System.Drawing.Point(852, 27);
            this.tb_PartID.Name = "tb_PartID";
            this.tb_PartID.ReadOnly = true;
            this.tb_PartID.Size = new System.Drawing.Size(69, 20);
            this.tb_PartID.TabIndex = 11;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 53);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1032, 501);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1024, 475);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Work Instructions";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pdf_Document);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_Test);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Sync);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Export);
            this.splitContainer1.Panel2.Controls.Add(this.cob_DocList);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1018, 469);
            this.splitContainer1.SplitterDistance = 660;
            this.splitContainer1.TabIndex = 0;
            // 
            // pdf_Document
            // 
            this.pdf_Document.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdf_Document.Location = new System.Drawing.Point(3, 3);
            this.pdf_Document.Name = "pdf_Document";
            this.pdf_Document.Page = 0;
            this.pdf_Document.Rotation = PdfiumViewer.PdfRotation.Rotate0;
            this.pdf_Document.Size = new System.Drawing.Size(654, 463);
            this.pdf_Document.TabIndex = 0;
            this.pdf_Document.Text = "pdfRenderer1";
            this.pdf_Document.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitHeight;
            // 
            // btn_Test
            // 
            this.btn_Test.Location = new System.Drawing.Point(62, 146);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(252, 148);
            this.btn_Test.TabIndex = 1;
            this.btn_Test.Text = "Test";
            this.btn_Test.UseVisualStyleBackColor = true;
            this.btn_Test.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // btn_Sync
            // 
            this.btn_Sync.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Sync.Location = new System.Drawing.Point(3, 414);
            this.btn_Sync.Name = "btn_Sync";
            this.btn_Sync.Size = new System.Drawing.Size(348, 23);
            this.btn_Sync.TabIndex = 3;
            this.btn_Sync.Text = "Refresh Sync";
            this.btn_Sync.UseVisualStyleBackColor = true;
            // 
            // btn_Export
            // 
            this.btn_Export.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Export.Location = new System.Drawing.Point(3, 443);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(348, 23);
            this.btn_Export.TabIndex = 2;
            this.btn_Export.Text = "Export Data";
            this.btn_Export.UseVisualStyleBackColor = true;
            // 
            // cob_DocList
            // 
            this.cob_DocList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cob_DocList.FormattingEnabled = true;
            this.cob_DocList.Location = new System.Drawing.Point(3, 3);
            this.cob_DocList.Name = "cob_DocList";
            this.cob_DocList.Size = new System.Drawing.Size(348, 21);
            this.cob_DocList.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_tb_ID,
            this.dgv_tb_Name,
            this.dgv_tb_User,
            this.dgv_Image_Value,
            this.dgv_tb_Position});
            this.dataGridView1.Location = new System.Drawing.Point(3, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(348, 378);
            this.dataGridView1.TabIndex = 0;
            // 
            // dgv_tb_ID
            // 
            this.dgv_tb_ID.FillWeight = 50F;
            this.dgv_tb_ID.HeaderText = "ID";
            this.dgv_tb_ID.MinimumWidth = 50;
            this.dgv_tb_ID.Name = "dgv_tb_ID";
            this.dgv_tb_ID.ReadOnly = true;
            this.dgv_tb_ID.Width = 50;
            // 
            // dgv_tb_Name
            // 
            this.dgv_tb_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_tb_Name.HeaderText = "Name";
            this.dgv_tb_Name.Name = "dgv_tb_Name";
            this.dgv_tb_Name.ReadOnly = true;
            // 
            // dgv_tb_User
            // 
            this.dgv_tb_User.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgv_tb_User.FillWeight = 75F;
            this.dgv_tb_User.HeaderText = "User";
            this.dgv_tb_User.MinimumWidth = 75;
            this.dgv_tb_User.Name = "dgv_tb_User";
            this.dgv_tb_User.ReadOnly = true;
            this.dgv_tb_User.Width = 75;
            // 
            // dgv_Image_Value
            // 
            this.dgv_Image_Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgv_Image_Value.FillWeight = 75F;
            this.dgv_Image_Value.HeaderText = "Value";
            this.dgv_Image_Value.MinimumWidth = 75;
            this.dgv_Image_Value.Name = "dgv_Image_Value";
            this.dgv_Image_Value.ReadOnly = true;
            this.dgv_Image_Value.Width = 75;
            // 
            // dgv_tb_Position
            // 
            this.dgv_tb_Position.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgv_tb_Position.HeaderText = "Position";
            this.dgv_tb_Position.MinimumWidth = 100;
            this.dgv_tb_Position.Name = "dgv_tb_Position";
            this.dgv_tb_Position.ReadOnly = true;
            this.dgv_tb_Position.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1024, 475);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Part List";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1024, 475);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Shop Items";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1024, 475);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Tools";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 557);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1056, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 579);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tb_PartID);
            this.Controls.Add(this.cob_Rev);
            this.Controls.Add(this.cob_PartNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cob_Serials);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.tb_ShopOrder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(965, 39);
            this.Name = "Main";
            this.Text = "Digital Data Collector";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supervisorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageShopOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem engineeringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualPartNumberModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editDataPointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mannagePartNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDocumentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ts_CreateTables;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_ShopOrder;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cob_Serials;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cob_PartNumber;
        private System.Windows.Forms.ComboBox cob_Rev;
        private System.Windows.Forms.TextBox tb_PartID;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_tb_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_tb_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_tb_User;
        private System.Windows.Forms.DataGridViewImageColumn dgv_Image_Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_tb_Position;
        private System.Windows.Forms.Button btn_Sync;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.ComboBox cob_DocList;
        private System.Windows.Forms.Button btn_Test;
        private PdfiumViewer.PdfRenderer pdf_Document;
    }
}

