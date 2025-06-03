namespace Data_Collector.Production {
    partial class CreateOrders {
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_Serials = new System.Windows.Forms.ListBox();
            this.cob_PartNumber = new System.Windows.Forms.ComboBox();
            this.cob_Rev = new System.Windows.Forms.ComboBox();
            this.tb_PartID = new System.Windows.Forms.TextBox();
            this.tb_Serial = new System.Windows.Forms.TextBox();
            this.btn_AddSN = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.cob_ShopOrders = new System.Windows.Forms.ComboBox();
            this.tb_Qty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cxb_Serials = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ts_RemoveSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.cob_Status = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cxb_Serials.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shop Order:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Part Number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Serial Number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Revision:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(419, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Part ID:";
            // 
            // lb_Serials
            // 
            this.lb_Serials.FormattingEnabled = true;
            this.lb_Serials.Location = new System.Drawing.Point(95, 91);
            this.lb_Serials.Name = "lb_Serials";
            this.lb_Serials.ScrollAlwaysVisible = true;
            this.lb_Serials.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lb_Serials.Size = new System.Drawing.Size(169, 108);
            this.lb_Serials.TabIndex = 5;
            this.lb_Serials.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lb_Serials_MouseClick);
            this.lb_Serials.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lb_Serials_MouseDown);
            // 
            // cob_PartNumber
            // 
            this.cob_PartNumber.FormattingEnabled = true;
            this.cob_PartNumber.Location = new System.Drawing.Point(95, 39);
            this.cob_PartNumber.Name = "cob_PartNumber";
            this.cob_PartNumber.Size = new System.Drawing.Size(169, 21);
            this.cob_PartNumber.TabIndex = 8;
            this.cob_PartNumber.SelectedIndexChanged += new System.EventHandler(this.cob_PartNumber_SelectedIndexChanged);
            this.cob_PartNumber.Leave += new System.EventHandler(this.cob_PartNumber_Leave);
            // 
            // cob_Rev
            // 
            this.cob_Rev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_Rev.FormattingEnabled = true;
            this.cob_Rev.Location = new System.Drawing.Point(332, 39);
            this.cob_Rev.Name = "cob_Rev";
            this.cob_Rev.Size = new System.Drawing.Size(81, 21);
            this.cob_Rev.TabIndex = 9;
            this.cob_Rev.SelectedIndexChanged += new System.EventHandler(this.cob_Rev_SelectedIndexChanged);
            // 
            // tb_PartID
            // 
            this.tb_PartID.Location = new System.Drawing.Point(468, 39);
            this.tb_PartID.Name = "tb_PartID";
            this.tb_PartID.ReadOnly = true;
            this.tb_PartID.Size = new System.Drawing.Size(76, 20);
            this.tb_PartID.TabIndex = 10;
            // 
            // tb_Serial
            // 
            this.tb_Serial.Location = new System.Drawing.Point(95, 66);
            this.tb_Serial.Name = "tb_Serial";
            this.tb_Serial.Size = new System.Drawing.Size(100, 20);
            this.tb_Serial.TabIndex = 11;
            // 
            // btn_AddSN
            // 
            this.btn_AddSN.Location = new System.Drawing.Point(201, 64);
            this.btn_AddSN.Name = "btn_AddSN";
            this.btn_AddSN.Size = new System.Drawing.Size(63, 23);
            this.btn_AddSN.TabIndex = 12;
            this.btn_AddSN.Text = "Add";
            this.btn_AddSN.UseVisualStyleBackColor = true;
            this.btn_AddSN.Click += new System.EventHandler(this.btn_AddSN_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(12, 205);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(532, 60);
            this.btn_Save.TabIndex = 14;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // cob_ShopOrders
            // 
            this.cob_ShopOrders.FormattingEnabled = true;
            this.cob_ShopOrders.Location = new System.Drawing.Point(95, 12);
            this.cob_ShopOrders.Name = "cob_ShopOrders";
            this.cob_ShopOrders.Size = new System.Drawing.Size(169, 21);
            this.cob_ShopOrders.TabIndex = 15;
            this.cob_ShopOrders.TextChanged += new System.EventHandler(this.cob_ShopOrders_SelectedIndexChanged);
            // 
            // tb_Qty
            // 
            this.tb_Qty.Location = new System.Drawing.Point(332, 12);
            this.tb_Qty.Name = "tb_Qty";
            this.tb_Qty.Size = new System.Drawing.Size(81, 20);
            this.tb_Qty.TabIndex = 16;
            this.tb_Qty.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(300, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Qty:";
            // 
            // cxb_Serials
            // 
            this.cxb_Serials.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_RemoveSelected});
            this.cxb_Serials.Name = "cxb_Serials";
            this.cxb_Serials.Size = new System.Drawing.Size(165, 26);
            // 
            // ts_RemoveSelected
            // 
            this.ts_RemoveSelected.Name = "ts_RemoveSelected";
            this.ts_RemoveSelected.Size = new System.Drawing.Size(164, 22);
            this.ts_RemoveSelected.Text = "Remove Selected";
            this.ts_RemoveSelected.Click += new System.EventHandler(this.ts_RemoveSelected_Click);
            // 
            // cob_Status
            // 
            this.cob_Status.FormattingEnabled = true;
            this.cob_Status.Items.AddRange(new object[] {
            "Open",
            "Closed",
            "Cancled"});
            this.cob_Status.Location = new System.Drawing.Point(468, 12);
            this.cob_Status.Name = "cob_Status";
            this.cob_Status.Size = new System.Drawing.Size(76, 21);
            this.cob_Status.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(422, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Status:";
            // 
            // CreateOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 277);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cob_Status);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_Qty);
            this.Controls.Add(this.cob_ShopOrders);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_AddSN);
            this.Controls.Add(this.tb_Serial);
            this.Controls.Add(this.tb_PartID);
            this.Controls.Add(this.cob_Rev);
            this.Controls.Add(this.cob_PartNumber);
            this.Controls.Add(this.lb_Serials);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(572, 316);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(572, 316);
            this.Name = "CreateOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create / Modify Orders";
            this.Load += new System.EventHandler(this.CreateOrders_Load);
            this.cxb_Serials.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lb_Serials;
        private System.Windows.Forms.ComboBox cob_PartNumber;
        private System.Windows.Forms.ComboBox cob_Rev;
        private System.Windows.Forms.TextBox tb_PartID;
        private System.Windows.Forms.TextBox tb_Serial;
        private System.Windows.Forms.Button btn_AddSN;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.ComboBox cob_ShopOrders;
        private System.Windows.Forms.TextBox tb_Qty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip cxb_Serials;
        private System.Windows.Forms.ToolStripMenuItem ts_RemoveSelected;
        private System.Windows.Forms.ComboBox cob_Status;
        private System.Windows.Forms.Label label7;
    }
}