using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Collector.Engineering
{
    public partial class QuickFilter: Form
    {
        public QuickFilter(string Type)
        {
            InitializeComponent();
            tb_Filter.Text = Type;
        }

        private void QuickFilter_Load(object sender, EventArgs e) {

            //Create Columns
            switch (tb_Filter.Text) {

                case "Number": {

                    DataGridViewTextBoxColumn NewText = new DataGridViewTextBoxColumn();
                    NewText.AutoSizeMode=System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                    NewText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

                    dgv_Format.Columns.Add(NewText);
                    dgv_Format.Columns[1].Name = "Test";

                }
                break;
            
            
            
            }

            /*
                Acknowledge
                Badge
                Chemical
                Date
                Date/Time
                Number
                Serial Number
                Tool ID
                Text
                Timer
                Stop Watch
                File
            */
        }
    }
}
