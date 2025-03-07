using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Collector.Engineering {
    public partial class QueryDocuments : Form {
        public QueryDocuments() {
            InitializeComponent();
        }

        public string DocID_F2 { get; set; }

        private void QueryDocuments_Load(object sender, EventArgs e) {
            DataTable UniqueDocs = DataTools.DataMaster.GetAllUniqueDocs();

            foreach (DataRow row in UniqueDocs.Rows) {
                cob_UniqueDocName.Items.Add(row["Name"]);
            }
        }

        private void cob_UniqueDocName_Leave(object sender, EventArgs e) {
            cob_Rev.Items.Clear();

            foreach (string ItemData in cob_UniqueDocName.Items) {

                if (cob_UniqueDocName.Text.ToUpper().Trim() == ItemData.ToUpper().Trim()) {
                    cob_UniqueDocName.SelectedItem = ItemData;
                }

            }

            tb_DocID.Text = "";

            DataTable UniqueDocs = DataTools.DataMaster.GetRevbyUniqueDoc(cob_UniqueDocName.Text);
            cob_Rev.Items.Clear();
            foreach (DataRow row in UniqueDocs.Rows) {

                cob_Rev.Items.Add(row.Field<Int64>("Revison").ToString());
            }


            if (cob_Rev.Items.Count > 0) {
                cob_Rev.SelectedIndex = 0;
            }

            
        }

        private void cob_Rev_SelectedIndexChanged(object sender, EventArgs e) {
            DataTable UniqueDocs = DataTools.DataMaster.GetUniqueDocIDbyPNandRev(cob_UniqueDocName.Text, Convert.ToInt64(cob_Rev.Text));

            if (UniqueDocs.Rows.Count == 1) {
                tb_DocID.Text = UniqueDocs.Rows[0].Field<Int64>("DocID").ToString();
                tb_Path.Text = UniqueDocs.Rows[0].Field<string>("Path");
                tb_FileName.Text = Path.GetFileName(tb_Path.Text);
            }

            CheckSaveStatus();

        }

        private void tb_DocID_TextChanged(object sender, EventArgs e) {

        }


        private void CheckSaveStatus() {

            if (!string.IsNullOrWhiteSpace(tb_Path.Text) && !string.IsNullOrWhiteSpace(tb_DocID.Text)) {
                btn_Save.Enabled = true;
            } else {
                btn_Save.Enabled = false;
            }

        }

        private void btn_Save_Click(object sender, EventArgs e) {

            DocID_F2=tb_DocID.Text; 
            this.Close();
        }
    }
}
