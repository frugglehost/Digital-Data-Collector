using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Collector.Support
{
    public partial class KillData: Form
    {
        public KillData()
        {
            InitializeComponent();
        }

        private void btn_Search_Click(object sender, EventArgs e) {

            string ShopOrder = tb_ShopOrder.Text.ToUpper().Trim();
            
            tb_ShopOrder.Text = ShopOrder;


            SearchBaby();


        }

        private void SearchBaby() {

            dgv_Kill.Rows.Clear();

            DataTable AllRecords = DataTools.DataMaster.GetDataRecords(null, tb_ShopOrder.Text,null,false);

            foreach (DataRow RecordRows in AllRecords.Rows) {

                Int64 RecordID = RecordRows.Field<Int64>("Rec_ID");
                Int64 DataPointID = RecordRows.Field<Int64>("DataPointID");
                string Value = RecordRows.Field<string>("Value");
                bool Hidden = !string.IsNullOrWhiteSpace(RecordRows.Field<string>("Hidden"));



                dgv_Kill.Rows.Add(RecordID, DataPointID, Value, Hidden);

            }
        }

        private void btn_Disable_Click(object sender, EventArgs e) {

            string ShopOrder = tb_ShopOrder.Text;
            string Changer = Environment.UserName;

            foreach(DataGridViewRow dgvRow in dgv_Kill.SelectedRows) {

                Int64 Rec_ID = Convert.ToInt64(dgvRow.Cells[dgv_Kill_ID.Index].Value ?? 0);
                Int64 DataPointID = Convert.ToInt64(dgvRow.Cells[dgv_Kill_DataPointID.Index].Value ?? 0);
                string Value = dgvRow.Cells[dgv_Kill_Value.Index].Value.ToString() ?? "";



                DataTools.DataMaster.UpdateRecID(Rec_ID, null, DataPointID, Value, Changer, null);

            }

            SearchBaby();


        }
    }
}
