namespace Data_Collector.Engineering {
    partial class ManageDocument {
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
            this.cob_UniqueDocName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cob_Rev = new System.Windows.Forms.ComboBox();
            this.btn_NewRev = new System.Windows.Forms.Button();
            this.tb_DocID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Path = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Change = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_FileName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Document Name:";
            // 
            // cob_UniqueDocName
            // 
            this.cob_UniqueDocName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cob_UniqueDocName.FormattingEnabled = true;
            this.cob_UniqueDocName.Location = new System.Drawing.Point(108, 6);
            this.cob_UniqueDocName.Name = "cob_UniqueDocName";
            this.cob_UniqueDocName.Size = new System.Drawing.Size(233, 21);
            this.cob_UniqueDocName.TabIndex = 1;
            this.cob_UniqueDocName.SelectedIndexChanged += new System.EventHandler(this.cob_UniqueID_SelectedIndexChanged);
            this.cob_UniqueDocName.Leave += new System.EventHandler(this.cob_UniqueID_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Document Rev:";
            // 
            // cob_Rev
            // 
            this.cob_Rev.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cob_Rev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_Rev.FormattingEnabled = true;
            this.cob_Rev.Location = new System.Drawing.Point(108, 33);
            this.cob_Rev.Name = "cob_Rev";
            this.cob_Rev.Size = new System.Drawing.Size(127, 21);
            this.cob_Rev.TabIndex = 2;
            this.cob_Rev.SelectedIndexChanged += new System.EventHandler(this.cob_Rev_SelectedIndexChanged);
            // 
            // btn_NewRev
            // 
            this.btn_NewRev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_NewRev.Location = new System.Drawing.Point(241, 33);
            this.btn_NewRev.Name = "btn_NewRev";
            this.btn_NewRev.Size = new System.Drawing.Size(100, 23);
            this.btn_NewRev.TabIndex = 99;
            this.btn_NewRev.Text = "Make New Rev";
            this.btn_NewRev.UseVisualStyleBackColor = true;
            this.btn_NewRev.Click += new System.EventHandler(this.btn_NewRev_Click);
            // 
            // tb_DocID
            // 
            this.tb_DocID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_DocID.Location = new System.Drawing.Point(108, 60);
            this.tb_DocID.Name = "tb_DocID";
            this.tb_DocID.ReadOnly = true;
            this.tb_DocID.Size = new System.Drawing.Size(127, 20);
            this.tb_DocID.TabIndex = 99;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "DocID:";
            // 
            // tb_Path
            // 
            this.tb_Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Path.Location = new System.Drawing.Point(108, 86);
            this.tb_Path.Name = "tb_Path";
            this.tb_Path.ReadOnly = true;
            this.tb_Path.Size = new System.Drawing.Size(127, 20);
            this.tb_Path.TabIndex = 99;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Path:";
            // 
            // btn_Change
            // 
            this.btn_Change.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Change.Location = new System.Drawing.Point(241, 86);
            this.btn_Change.Name = "btn_Change";
            this.btn_Change.Size = new System.Drawing.Size(100, 23);
            this.btn_Change.TabIndex = 3;
            this.btn_Change.Text = "Change";
            this.btn_Change.UseVisualStyleBackColor = true;
            this.btn_Change.Click += new System.EventHandler(this.btn_Change_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.Enabled = false;
            this.btn_Save.Location = new System.Drawing.Point(12, 149);
            this.btn_Save.MaximumSize = new System.Drawing.Size(329, 53);
            this.btn_Save.MinimumSize = new System.Drawing.Size(329, 53);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(329, 53);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 100;
            this.label5.Text = "Name:";
            // 
            // tb_FileName
            // 
            this.tb_FileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_FileName.Location = new System.Drawing.Point(108, 112);
            this.tb_FileName.Name = "tb_FileName";
            this.tb_FileName.ReadOnly = true;
            this.tb_FileName.Size = new System.Drawing.Size(127, 20);
            this.tb_FileName.TabIndex = 101;
            // 
            // ManageDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 214);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_FileName);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Change);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_Path);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_DocID);
            this.Controls.Add(this.btn_NewRev);
            this.Controls.Add(this.cob_Rev);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cob_UniqueDocName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(369, 253);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(369, 253);
            this.Name = "ManageDocument";
            this.Text = "Manage Documents";
            this.Load += new System.EventHandler(this.ManageDocument_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cob_UniqueDocName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cob_Rev;
        private System.Windows.Forms.Button btn_NewRev;
        private System.Windows.Forms.TextBox tb_DocID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Path;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Change;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_FileName;
    }
}