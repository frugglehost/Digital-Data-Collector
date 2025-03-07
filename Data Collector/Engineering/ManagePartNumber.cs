using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Collector.Engineering {
    public partial class ManagePartNumber : Form {
        public ManagePartNumber() {
            InitializeComponent();

            DataTable PNlist = DataTools.DataMaster.GetAllPN();
            foreach (DataRow row in PNlist.Rows) {
                cob_PartNumber.Items.Add(row.Field<string>("PartNumber"));
            }
        }

        private void cob_Rev_SelectedIndexChanged(object sender, EventArgs e) {

            if (cob_Rev.Items.Count > 0) {

                //Lock it down. We dont need any one messing around with the PN once it is set
                cob_PartNumber.Enabled = false;
                tb_PartID.Text = "";



                //OKay we have attempted to select a rev. Lets aget a unique Part ID. 
                if (!string.IsNullOrWhiteSpace(cob_Rev.Text)) {

                    DataTable PartID = DataTools.DataMaster.GetPartIDbyPNandRev(cob_PartNumber.Text, Convert.ToInt32(cob_Rev.Text));

                    if (PartID.Rows.Count != 1) {
                        //failed to find a valid Part ID.
                    } else {
                        Int64 int_PartID = PartID.Rows[0].Field<Int64>("PartID");
                        tb_PartID.Text = int_PartID.ToString();

                    }
                }


                


            }

            
            
            

        }

        private void cob_PartNumber_Leave(object sender, EventArgs e) {
            


            if (cob_PartNumber.SelectedIndex == -1) {

                cob_Rev.Items.Clear();
                dataGridView1.Rows.Clear();
                tb_PartID.Text = "";

                //if there is a similar/aleady existing PN lets reuse it.
                foreach (string ItemData in cob_PartNumber.Items) {
                    if (cob_PartNumber.Text.ToUpper().Trim() == ItemData.ToUpper().Trim()) {
                        cob_PartNumber.SelectedItem = ItemData;
                        
                    }
                }

                
            }
            

        }


        private void btn_Add_Click(object sender, EventArgs e) {
            dataGridView1.Rows.Add("Edit");
        }

        private void tb_PartID_TextChanged(object sender, EventArgs e) {

            if (!string.IsNullOrWhiteSpace(tb_PartID.Text)) {
                // We have a part number lets get all old documents.

                DialogResult WarnningResults = DialogResult.Yes;

                if (dataGridView1.Rows.Count > 0) {

                    WarnningResults = MessageBox.Show("You have data that is in the table. \nWould you like to clear it?", "Old Data", MessageBoxButtons.YesNo);

                }


                if (WarnningResults != DialogResult.No) {
                    dataGridView1.Rows.Clear();
                    DataTable DocumentList = DataTools.DataMaster.GetDocListIDbyPartID(Convert.ToInt64(tb_PartID.Text));

                    foreach (DataRow row in DocumentList.Rows) {

                        Int64 TempDocID = row.Field<Int64>("DocID");
                        DataTable dt_TempDocID = DataTools.DataMaster.GetUniqueDocbyDocID(TempDocID);



                        dataGridView1.Rows.Add("Edit", TempDocID, dt_TempDocID.Rows[0].Field<string>("Name"), dt_TempDocID.Rows[0].Field<Int64>("Revison"), TempDocID);
                    }
                }

                





            }

        }

        private void cob_PartNumber_SelectedIndexChanged(object sender, EventArgs e) {

            
            dataGridView1.Rows.Clear();
            

            GetAllRevs();

        }

        private void GetAllRevs() {

            cob_Rev.Items.Clear();
            tb_PartID.Text = "";

            //Update the rev drop down list.
            DataTable UniquePNs = DataTools.DataMaster.GetRevbyPN(cob_PartNumber.Text);

            foreach (DataRow row in UniquePNs.Rows) {

                cob_Rev.Items.Add(row.Field<Int64>("Revision").ToString());
            }

            if (cob_Rev.Items.Count > 0) {
                cob_Rev.SelectedIndex = 0;
            }
        }

        private void btn_Rev_Click(object sender, EventArgs e) {


            DataTable UniquePN = DataTools.DataMaster.GetRevbyPN(cob_PartNumber.Text);
            Int64 int_Rev = 1;

            if (UniquePN.Rows.Count > 0) {
                //Lets go! We will add a new incremental Rev.

                int_Rev = UniquePN.Rows[0].Field<Int64>("Revision") + 1;

            } else {

                cob_PartNumber.Items.Add(cob_PartNumber.Text.Trim());
            }

            DataTable UniqueDocID = DataTools.DataMaster.InsertNewUniquePN(cob_PartNumber.Text.Trim(), int_Rev);


            GetAllRevs();




        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0) {
                //TODO - Button Clicked - Execute Code Here


                Engineering.QueryDocuments subform = new Engineering.QueryDocuments();

                subform.ShowDialog();
                string results = subform.DocID_F2;


                DataTable UniqueDocument = DataTools.DataMaster.GetUniqueDocbyDocID(Convert.ToInt64(results));



                dataGridView1.Rows[e.RowIndex].Cells[1].Value = results;
                dataGridView1.Rows[e.RowIndex].Cells[2].Value = UniqueDocument.Rows[0].Field<string>("Name");
                dataGridView1.Rows[e.RowIndex].Cells[3].Value = UniqueDocument.Rows[0].Field<Int64>("Revison");
                dataGridView1.Rows[e.RowIndex].Cells[4].Value = results;
            }



        }

        private void btn_Save_Click(object sender, EventArgs e) {


            foreach (DataRowView drv in dataGridView1.Rows) {



            }


        }
    }
    
}
