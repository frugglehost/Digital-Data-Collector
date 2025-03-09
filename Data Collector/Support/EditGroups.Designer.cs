namespace Data_Collector.Support {
    partial class EditGroups {
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
            this.list_Groups = new System.Windows.Forms.CheckedListBox();
            this.tb_NTID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // list_Groups
            // 
            this.list_Groups.Enabled = false;
            this.list_Groups.FormattingEnabled = true;
            this.list_Groups.Items.AddRange(new object[] {
            "MFG",
            "QC",
            "Supervisor",
            "ME",
            "QE",
            "Support"});
            this.list_Groups.Location = new System.Drawing.Point(12, 38);
            this.list_Groups.Name = "list_Groups";
            this.list_Groups.Size = new System.Drawing.Size(215, 154);
            this.list_Groups.TabIndex = 0;
            // 
            // tb_NTID
            // 
            this.tb_NTID.Location = new System.Drawing.Point(54, 12);
            this.tb_NTID.Name = "tb_NTID";
            this.tb_NTID.Size = new System.Drawing.Size(100, 20);
            this.tb_NTID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "NTID:";
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(160, 10);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(67, 23);
            this.btn_Search.TabIndex = 3;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Enabled = false;
            this.btn_Save.Location = new System.Drawing.Point(12, 198);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(215, 31);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // EditGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 241);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_NTID);
            this.Controls.Add(this.list_Groups);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(255, 280);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(255, 280);
            this.Name = "EditGroups";
            this.Text = "Edit Groups";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox list_Groups;
        private System.Windows.Forms.TextBox tb_NTID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_Save;
    }
}