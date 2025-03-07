namespace Data_Collector.Engineering {
    partial class QueryDocuments {
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
            this.label5 = new System.Windows.Forms.Label();
            this.tb_FileName = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_Path = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_DocID = new System.Windows.Forms.TextBox();
            this.cob_Rev = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cob_UniqueDocName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pdfRenderer1 = new PdfiumViewer.PdfRenderer();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 122;
            this.label5.Text = "Name:";
            // 
            // tb_FileName
            // 
            this.tb_FileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_FileName.Location = new System.Drawing.Point(108, 118);
            this.tb_FileName.Name = "tb_FileName";
            this.tb_FileName.ReadOnly = true;
            this.tb_FileName.Size = new System.Drawing.Size(233, 20);
            this.tb_FileName.TabIndex = 123;
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.Enabled = false;
            this.btn_Save.Location = new System.Drawing.Point(12, 320);
            this.btn_Save.MaximumSize = new System.Drawing.Size(329, 53);
            this.btn_Save.MinimumSize = new System.Drawing.Size(329, 53);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(329, 53);
            this.btn_Save.TabIndex = 117;
            this.btn_Save.Text = "Set Document";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 119;
            this.label4.Text = "Path:";
            // 
            // tb_Path
            // 
            this.tb_Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Path.Location = new System.Drawing.Point(108, 92);
            this.tb_Path.Name = "tb_Path";
            this.tb_Path.ReadOnly = true;
            this.tb_Path.Size = new System.Drawing.Size(233, 20);
            this.tb_Path.TabIndex = 120;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 118;
            this.label3.Text = "DocID:";
            // 
            // tb_DocID
            // 
            this.tb_DocID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_DocID.Location = new System.Drawing.Point(108, 66);
            this.tb_DocID.Name = "tb_DocID";
            this.tb_DocID.ReadOnly = true;
            this.tb_DocID.Size = new System.Drawing.Size(233, 20);
            this.tb_DocID.TabIndex = 121;
            // 
            // cob_Rev
            // 
            this.cob_Rev.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cob_Rev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_Rev.FormattingEnabled = true;
            this.cob_Rev.Location = new System.Drawing.Point(108, 39);
            this.cob_Rev.Name = "cob_Rev";
            this.cob_Rev.Size = new System.Drawing.Size(233, 21);
            this.cob_Rev.TabIndex = 115;
            this.cob_Rev.SelectedIndexChanged += new System.EventHandler(this.cob_Rev_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 116;
            this.label2.Text = "Document Rev:";
            // 
            // cob_UniqueDocName
            // 
            this.cob_UniqueDocName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cob_UniqueDocName.FormattingEnabled = true;
            this.cob_UniqueDocName.Location = new System.Drawing.Point(108, 12);
            this.cob_UniqueDocName.Name = "cob_UniqueDocName";
            this.cob_UniqueDocName.Size = new System.Drawing.Size(233, 21);
            this.cob_UniqueDocName.TabIndex = 114;
            this.cob_UniqueDocName.Leave += new System.EventHandler(this.cob_UniqueDocName_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 113;
            this.label1.Text = "Document Name:";
            // 
            // pdfRenderer1
            // 
            this.pdfRenderer1.Location = new System.Drawing.Point(12, 144);
            this.pdfRenderer1.MaximumSize = new System.Drawing.Size(329, 170);
            this.pdfRenderer1.MinimumSize = new System.Drawing.Size(329, 170);
            this.pdfRenderer1.Name = "pdfRenderer1";
            this.pdfRenderer1.Page = 0;
            this.pdfRenderer1.Rotation = PdfiumViewer.PdfRotation.Rotate0;
            this.pdfRenderer1.Size = new System.Drawing.Size(329, 170);
            this.pdfRenderer1.TabIndex = 124;
            this.pdfRenderer1.Text = "pdfRenderer1";
            this.pdfRenderer1.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitHeight;
            // 
            // QueryDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 385);
            this.Controls.Add(this.pdfRenderer1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_FileName);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_Path);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_DocID);
            this.Controls.Add(this.cob_Rev);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cob_UniqueDocName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QueryDocuments";
            this.ShowIcon = false;
            this.Text = "Query Documents";
            this.Load += new System.EventHandler(this.QueryDocuments_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_FileName;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_Path;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_DocID;
        private System.Windows.Forms.ComboBox cob_Rev;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cob_UniqueDocName;
        private System.Windows.Forms.Label label1;
        private PdfiumViewer.PdfRenderer pdfRenderer1;
    }
}