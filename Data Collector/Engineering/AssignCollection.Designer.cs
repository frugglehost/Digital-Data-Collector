namespace Data_Collector.Engineering {
    partial class AssignCollection {
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_InspID = new System.Windows.Forms.TextBox();
            this.cob_Type = new System.Windows.Forms.ComboBox();
            this.tb_DocID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_Position = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_Desc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cob_UserRole = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cob_Mandatory = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_Order = new System.Windows.Forms.TextBox();
            this.tb_Close = new System.Windows.Forms.TextBox();
            this.tb_Open = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.tb_PartID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cob_Filters = new System.Windows.Forms.ComboBox();
            this.tb_OrderID = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btn_Quick_Filter = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Collection Input Form:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Inspection ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 371);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Open Requirement:";
            // 
            // tb_InspID
            // 
            this.tb_InspID.Location = new System.Drawing.Point(117, 67);
            this.tb_InspID.Name = "tb_InspID";
            this.tb_InspID.ReadOnly = true;
            this.tb_InspID.Size = new System.Drawing.Size(95, 20);
            this.tb_InspID.TabIndex = 3;
            this.tb_InspID.TabStop = false;
            // 
            // cob_Type
            // 
            this.cob_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_Type.FormattingEnabled = true;
            this.cob_Type.Items.AddRange(new object[] {
            "Acknowledge",
            "Badge",
            "Chemical",
            "Date",
            "Date/Time",
            "Number",
            "Serial Number",
            "Tool ID",
            "Text",
            "Timer",
            "Stop Watch",
            "File"});
            this.cob_Type.Location = new System.Drawing.Point(117, 119);
            this.cob_Type.Name = "cob_Type";
            this.cob_Type.Size = new System.Drawing.Size(255, 21);
            this.cob_Type.TabIndex = 1;
            this.cob_Type.SelectedIndexChanged += new System.EventHandler(this.CheckStatus);
            // 
            // tb_DocID
            // 
            this.tb_DocID.Location = new System.Drawing.Point(117, 93);
            this.tb_DocID.Name = "tb_DocID";
            this.tb_DocID.ReadOnly = true;
            this.tb_DocID.Size = new System.Drawing.Size(59, 20);
            this.tb_DocID.TabIndex = 5;
            this.tb_DocID.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Doc ID:";
            // 
            // tb_Position
            // 
            this.tb_Position.Location = new System.Drawing.Point(235, 93);
            this.tb_Position.Name = "tb_Position";
            this.tb_Position.ReadOnly = true;
            this.tb_Position.Size = new System.Drawing.Size(137, 20);
            this.tb_Position.TabIndex = 7;
            this.tb_Position.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(182, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Position:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(77, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Type:";
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(117, 173);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(255, 20);
            this.tb_Name.TabIndex = 3;
            this.tb_Name.TextChanged += new System.EventHandler(this.CheckStatus);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(73, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Name:";
            // 
            // tb_Desc
            // 
            this.tb_Desc.Location = new System.Drawing.Point(117, 199);
            this.tb_Desc.Multiline = true;
            this.tb_Desc.Name = "tb_Desc";
            this.tb_Desc.Size = new System.Drawing.Size(255, 90);
            this.tb_Desc.TabIndex = 4;
            this.tb_Desc.TextChanged += new System.EventHandler(this.CheckStatus);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 202);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Description:";
            // 
            // cob_UserRole
            // 
            this.cob_UserRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_UserRole.FormattingEnabled = true;
            this.cob_UserRole.Items.AddRange(new object[] {
            "MFG",
            "QC",
            "Supervisor",
            "ME",
            "QE",
            "Support"});
            this.cob_UserRole.Location = new System.Drawing.Point(117, 295);
            this.cob_UserRole.Name = "cob_UserRole";
            this.cob_UserRole.Size = new System.Drawing.Size(255, 21);
            this.cob_UserRole.TabIndex = 5;
            this.cob_UserRole.SelectedIndexChanged += new System.EventHandler(this.CheckStatus);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(54, 298);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "User Role:";
            // 
            // cob_Mandatory
            // 
            this.cob_Mandatory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_Mandatory.FormattingEnabled = true;
            this.cob_Mandatory.Items.AddRange(new object[] {
            "TRUE",
            "FALSE"});
            this.cob_Mandatory.Location = new System.Drawing.Point(117, 322);
            this.cob_Mandatory.Name = "cob_Mandatory";
            this.cob_Mandatory.Size = new System.Drawing.Size(255, 21);
            this.cob_Mandatory.TabIndex = 6;
            this.cob_Mandatory.SelectedIndexChanged += new System.EventHandler(this.CheckStatus);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(51, 325);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Mandatory:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_Order);
            this.groupBox1.Controls.Add(this.tb_Close);
            this.groupBox1.Controls.Add(this.tb_Open);
            this.groupBox1.Location = new System.Drawing.Point(117, 349);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 101);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PN Specifc Data (Optional)";
            // 
            // tb_Order
            // 
            this.tb_Order.Location = new System.Drawing.Point(6, 71);
            this.tb_Order.Name = "tb_Order";
            this.tb_Order.ReadOnly = true;
            this.tb_Order.Size = new System.Drawing.Size(243, 20);
            this.tb_Order.TabIndex = 9;
            this.tb_Order.TabStop = false;
            // 
            // tb_Close
            // 
            this.tb_Close.Location = new System.Drawing.Point(6, 45);
            this.tb_Close.Name = "tb_Close";
            this.tb_Close.Size = new System.Drawing.Size(243, 20);
            this.tb_Close.TabIndex = 9;
            // 
            // tb_Open
            // 
            this.tb_Open.Location = new System.Drawing.Point(6, 19);
            this.tb_Open.Name = "tb_Open";
            this.tb_Open.Size = new System.Drawing.Size(243, 20);
            this.tb_Open.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 397);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Close Requirement:";
            // 
            // btn_Save
            // 
            this.btn_Save.Enabled = false;
            this.btn_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Location = new System.Drawing.Point(12, 456);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(360, 63);
            this.btn_Save.TabIndex = 9;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // tb_PartID
            // 
            this.tb_PartID.Location = new System.Drawing.Point(117, 41);
            this.tb_PartID.Name = "tb_PartID";
            this.tb_PartID.ReadOnly = true;
            this.tb_PartID.Size = new System.Drawing.Size(255, 20);
            this.tb_PartID.TabIndex = 23;
            this.tb_PartID.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(67, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Part ID:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(35, 423);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "Order Position:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(74, 149);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 13);
            this.label14.TabIndex = 25;
            this.label14.Text = "Filters:";
            // 
            // cob_Filters
            // 
            this.cob_Filters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cob_Filters.FormattingEnabled = true;
            this.cob_Filters.Location = new System.Drawing.Point(117, 146);
            this.cob_Filters.Name = "cob_Filters";
            this.cob_Filters.Size = new System.Drawing.Size(174, 21);
            this.cob_Filters.TabIndex = 2;
            // 
            // tb_OrderID
            // 
            this.tb_OrderID.Location = new System.Drawing.Point(274, 67);
            this.tb_OrderID.Name = "tb_OrderID";
            this.tb_OrderID.ReadOnly = true;
            this.tb_OrderID.Size = new System.Drawing.Size(98, 20);
            this.tb_OrderID.TabIndex = 27;
            this.tb_OrderID.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(218, 70);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Order ID:";
            // 
            // btn_Quick_Filter
            // 
            this.btn_Quick_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Quick_Filter.Location = new System.Drawing.Point(297, 144);
            this.btn_Quick_Filter.Name = "btn_Quick_Filter";
            this.btn_Quick_Filter.Size = new System.Drawing.Size(75, 23);
            this.btn_Quick_Filter.TabIndex = 28;
            this.btn_Quick_Filter.Text = "Quick";
            this.btn_Quick_Filter.UseVisualStyleBackColor = true;
            this.btn_Quick_Filter.Click += new System.EventHandler(this.btn_Quick_Filter_Click);
            // 
            // AssignCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 531);
            this.Controls.Add(this.btn_Quick_Filter);
            this.Controls.Add(this.tb_OrderID);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cob_Filters);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tb_PartID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cob_Mandatory);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cob_UserRole);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tb_Desc);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_Name);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_Position);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_DocID);
            this.Controls.Add(this.cob_Type);
            this.Controls.Add(this.tb_InspID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 570);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 570);
            this.Name = "AssignCollection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Assign Collection";
            this.Load += new System.EventHandler(this.AssignCollection_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_InspID;
        private System.Windows.Forms.ComboBox cob_Type;
        private System.Windows.Forms.TextBox tb_DocID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_Position;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_Desc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cob_UserRole;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cob_Mandatory;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_Close;
        private System.Windows.Forms.TextBox tb_Open;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox tb_PartID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_Order;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cob_Filters;
        private System.Windows.Forms.TextBox tb_OrderID;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btn_Quick_Filter;
    }
}