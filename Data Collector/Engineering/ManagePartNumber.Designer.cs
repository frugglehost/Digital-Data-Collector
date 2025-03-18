namespace Data_Collector.Engineering {
    partial class ManagePartNumber {
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
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cob_PartNumber = new System.Windows.Forms.ComboBox();
            this.cob_Rev = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Rev = new System.Windows.Forms.Button();
            this.tb_PartID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgv_btn_Change = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgv_tb_RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_tb_DocID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_tb_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_tb_Rev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_tb_OldDocID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_Up = new System.Windows.Forms.Button();
            this.btn_Down = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Part Number:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(816, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // cob_PartNumber
            // 
            this.cob_PartNumber.FormattingEnabled = true;
            this.cob_PartNumber.Location = new System.Drawing.Point(87, 27);
            this.cob_PartNumber.Name = "cob_PartNumber";
            this.cob_PartNumber.Size = new System.Drawing.Size(209, 21);
            this.cob_PartNumber.TabIndex = 2;
            this.cob_PartNumber.SelectedIndexChanged += new System.EventHandler(this.cob_PartNumber_SelectedIndexChanged);
            this.cob_PartNumber.Leave += new System.EventHandler(this.cob_PartNumber_Leave);
            // 
            // cob_Rev
            // 
            this.cob_Rev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_Rev.FormattingEnabled = true;
            this.cob_Rev.Location = new System.Drawing.Point(87, 54);
            this.cob_Rev.Name = "cob_Rev";
            this.cob_Rev.Size = new System.Drawing.Size(110, 21);
            this.cob_Rev.TabIndex = 3;
            this.cob_Rev.SelectedIndexChanged += new System.EventHandler(this.cob_Rev_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Rev:";
            // 
            // btn_Rev
            // 
            this.btn_Rev.Location = new System.Drawing.Point(203, 52);
            this.btn_Rev.Name = "btn_Rev";
            this.btn_Rev.Size = new System.Drawing.Size(93, 23);
            this.btn_Rev.TabIndex = 5;
            this.btn_Rev.Text = "New Rev";
            this.btn_Rev.UseVisualStyleBackColor = true;
            this.btn_Rev.Click += new System.EventHandler(this.btn_Rev_Click);
            // 
            // tb_PartID
            // 
            this.tb_PartID.Location = new System.Drawing.Point(351, 28);
            this.tb_PartID.Name = "tb_PartID";
            this.tb_PartID.ReadOnly = true;
            this.tb_PartID.Size = new System.Drawing.Size(76, 20);
            this.tb_PartID.TabIndex = 6;
            this.tb_PartID.TextChanged += new System.EventHandler(this.tb_PartID_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Part ID:";
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
            this.dgv_btn_Change,
            this.dgv_tb_RowID,
            this.dgv_tb_DocID,
            this.dgv_tb_Name,
            this.dgv_tb_Rev,
            this.dgv_tb_OldDocID});
            this.dataGridView1.Location = new System.Drawing.Point(12, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(675, 408);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dgv_btn_Change
            // 
            this.dgv_btn_Change.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgv_btn_Change.FillWeight = 75F;
            this.dgv_btn_Change.HeaderText = "";
            this.dgv_btn_Change.Name = "dgv_btn_Change";
            this.dgv_btn_Change.ReadOnly = true;
            this.dgv_btn_Change.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_btn_Change.Text = "Edit";
            this.dgv_btn_Change.Width = 75;
            // 
            // dgv_tb_RowID
            // 
            this.dgv_tb_RowID.HeaderText = "RowID";
            this.dgv_tb_RowID.Name = "dgv_tb_RowID";
            this.dgv_tb_RowID.ReadOnly = true;
            this.dgv_tb_RowID.Visible = false;
            // 
            // dgv_tb_DocID
            // 
            this.dgv_tb_DocID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgv_tb_DocID.FillWeight = 75F;
            this.dgv_tb_DocID.HeaderText = "Doc ID";
            this.dgv_tb_DocID.Name = "dgv_tb_DocID";
            this.dgv_tb_DocID.ReadOnly = true;
            this.dgv_tb_DocID.Width = 75;
            // 
            // dgv_tb_Name
            // 
            this.dgv_tb_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_tb_Name.HeaderText = "Document Name";
            this.dgv_tb_Name.Name = "dgv_tb_Name";
            this.dgv_tb_Name.ReadOnly = true;
            // 
            // dgv_tb_Rev
            // 
            this.dgv_tb_Rev.HeaderText = "Rev";
            this.dgv_tb_Rev.Name = "dgv_tb_Rev";
            this.dgv_tb_Rev.ReadOnly = true;
            // 
            // dgv_tb_OldDocID
            // 
            this.dgv_tb_OldDocID.HeaderText = "OldDoc";
            this.dgv_tb_OldDocID.Name = "dgv_tb_OldDocID";
            this.dgv_tb_OldDocID.ReadOnly = true;
            this.dgv_tb_OldDocID.Visible = false;
            // 
            // btn_Add
            // 
            this.btn_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Add.Location = new System.Drawing.Point(693, 81);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(111, 23);
            this.btn_Add.TabIndex = 9;
            this.btn_Add.Text = "Add Row";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_delete.Location = new System.Drawing.Point(693, 110);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(111, 23);
            this.btn_delete.TabIndex = 10;
            this.btn_delete.Text = "Remove Row";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_Up
            // 
            this.btn_Up.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Up.Location = new System.Drawing.Point(693, 164);
            this.btn_Up.Name = "btn_Up";
            this.btn_Up.Size = new System.Drawing.Size(111, 23);
            this.btn_Up.TabIndex = 11;
            this.btn_Up.Text = "Up";
            this.btn_Up.UseVisualStyleBackColor = true;
            this.btn_Up.Click += new System.EventHandler(this.btn_Up_Click);
            // 
            // btn_Down
            // 
            this.btn_Down.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Down.Location = new System.Drawing.Point(693, 193);
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Size = new System.Drawing.Size(111, 23);
            this.btn_Down.TabIndex = 12;
            this.btn_Down.Text = "Down";
            this.btn_Down.UseVisualStyleBackColor = true;
            this.btn_Down.Click += new System.EventHandler(this.btn_Down_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.Location = new System.Drawing.Point(12, 495);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(792, 46);
            this.btn_Save.TabIndex = 13;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // ManagePartNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 553);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Down);
            this.Controls.Add(this.btn_Up);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_PartID);
            this.Controls.Add(this.btn_Rev);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cob_Rev);
            this.Controls.Add(this.cob_PartNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ManagePartNumber";
            this.Text = "ManagePartNumber";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ComboBox cob_PartNumber;
        private System.Windows.Forms.ComboBox cob_Rev;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Rev;
        private System.Windows.Forms.TextBox tb_PartID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_Up;
        private System.Windows.Forms.Button btn_Down;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.DataGridViewButtonColumn dgv_btn_Change;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_tb_RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_tb_DocID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_tb_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_tb_Rev;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_tb_OldDocID;
    }
}