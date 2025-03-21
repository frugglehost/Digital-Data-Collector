namespace Data_Collector.Support {
    partial class KillData {
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
            this.dgv_Kill = new System.Windows.Forms.DataGridView();
            this.dgv_Kill_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Kill_DataPointID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Kill_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Kill_Hidden = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_ShopOrder = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_Disable = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ss_User = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Kill)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Kill
            // 
            this.dgv_Kill.AllowUserToAddRows = false;
            this.dgv_Kill.AllowUserToDeleteRows = false;
            this.dgv_Kill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Kill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Kill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_Kill_ID,
            this.dgv_Kill_DataPointID,
            this.dgv_Kill_Value,
            this.dgv_Kill_Hidden});
            this.dgv_Kill.Location = new System.Drawing.Point(12, 39);
            this.dgv_Kill.Name = "dgv_Kill";
            this.dgv_Kill.Size = new System.Drawing.Size(695, 386);
            this.dgv_Kill.TabIndex = 0;
            // 
            // dgv_Kill_ID
            // 
            this.dgv_Kill_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgv_Kill_ID.HeaderText = "ID";
            this.dgv_Kill_ID.Name = "dgv_Kill_ID";
            this.dgv_Kill_ID.ReadOnly = true;
            this.dgv_Kill_ID.Width = 43;
            // 
            // dgv_Kill_DataPointID
            // 
            this.dgv_Kill_DataPointID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgv_Kill_DataPointID.HeaderText = "DataPointID";
            this.dgv_Kill_DataPointID.Name = "dgv_Kill_DataPointID";
            this.dgv_Kill_DataPointID.ReadOnly = true;
            this.dgv_Kill_DataPointID.Width = 90;
            // 
            // dgv_Kill_Value
            // 
            this.dgv_Kill_Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_Kill_Value.HeaderText = "Value";
            this.dgv_Kill_Value.Name = "dgv_Kill_Value";
            this.dgv_Kill_Value.ReadOnly = true;
            // 
            // dgv_Kill_Hidden
            // 
            this.dgv_Kill_Hidden.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgv_Kill_Hidden.HeaderText = "Disable";
            this.dgv_Kill_Hidden.Name = "dgv_Kill_Hidden";
            this.dgv_Kill_Hidden.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Shop Order:";
            // 
            // tb_ShopOrder
            // 
            this.tb_ShopOrder.Location = new System.Drawing.Point(82, 12);
            this.tb_ShopOrder.Name = "tb_ShopOrder";
            this.tb_ShopOrder.Size = new System.Drawing.Size(163, 20);
            this.tb_ShopOrder.TabIndex = 2;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(251, 10);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 3;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // btn_Disable
            // 
            this.btn_Disable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Disable.Location = new System.Drawing.Point(713, 39);
            this.btn_Disable.Name = "btn_Disable";
            this.btn_Disable.Size = new System.Drawing.Size(75, 66);
            this.btn_Disable.TabIndex = 4;
            this.btn_Disable.Text = "Disable Rows";
            this.btn_Disable.UseVisualStyleBackColor = true;
            this.btn_Disable.Click += new System.EventHandler(this.btn_Disable_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.ss_User,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(36, 17);
            this.toolStripStatusLabel1.Text = "User: ";
            // 
            // ss_User
            // 
            this.ss_User.Name = "ss_User";
            this.ss_User.Size = new System.Drawing.Size(35, 17);
            this.ss_User.Text = "XXXX";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(41, 17);
            this.toolStripStatusLabel3.Text = "Mode:";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel4.Text = "XXXX";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "DataPointID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Value";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // KillData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_Disable);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.tb_ShopOrder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_Kill);
            this.Name = "KillData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KillData";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Kill)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Kill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_ShopOrder;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_Disable;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel ss_User;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_Kill_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_Kill_DataPointID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_Kill_Value;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv_Kill_Hidden;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}