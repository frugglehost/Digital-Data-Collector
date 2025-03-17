namespace Data_Collector.Engineering {
    partial class QuickFilter {
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
            this.dgv_Format = new System.Windows.Forms.DataGridView();
            this.btn_Save = new System.Windows.Forms.Button();
            this.Preview = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Filter = new System.Windows.Forms.TextBox();
            this.Default = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Format)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Format
            // 
            this.dgv_Format.AllowUserToAddRows = false;
            this.dgv_Format.AllowUserToDeleteRows = false;
            this.dgv_Format.AllowUserToResizeRows = false;
            this.dgv_Format.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Format.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Format.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Default});
            this.dgv_Format.Location = new System.Drawing.Point(12, 38);
            this.dgv_Format.Name = "dgv_Format";
            this.dgv_Format.RowHeadersVisible = false;
            this.dgv_Format.Size = new System.Drawing.Size(740, 340);
            this.dgv_Format.TabIndex = 0;
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.Location = new System.Drawing.Point(12, 384);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(367, 54);
            this.btn_Save.TabIndex = 1;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            // 
            // Preview
            // 
            this.Preview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Preview.Location = new System.Drawing.Point(385, 384);
            this.Preview.Name = "Preview";
            this.Preview.Size = new System.Drawing.Size(367, 54);
            this.Preview.TabIndex = 2;
            this.Preview.Text = "Preview";
            this.Preview.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Type:";
            // 
            // tb_Filter
            // 
            this.tb_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Filter.Location = new System.Drawing.Point(52, 12);
            this.tb_Filter.Name = "tb_Filter";
            this.tb_Filter.ReadOnly = true;
            this.tb_Filter.Size = new System.Drawing.Size(700, 20);
            this.tb_Filter.TabIndex = 4;
            // 
            // Default
            // 
            this.Default.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Default.HeaderText = "Default";
            this.Default.Name = "Default";
            this.Default.Width = 47;
            // 
            // QuickFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 450);
            this.Controls.Add(this.tb_Filter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Preview);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.dgv_Format);
            this.Name = "QuickFilter";
            this.Text = "QuickFilter";
            this.Load += new System.EventHandler(this.QuickFilter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Format)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Format;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button Preview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Filter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Default;
    }
}