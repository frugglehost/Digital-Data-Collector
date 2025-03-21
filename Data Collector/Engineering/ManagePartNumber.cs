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

            if (!string.IsNullOrWhiteSpace(cob_PartNumber.Text)) {

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
            dataGridView1.Rows.Add("Edit", -1);
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
                    DataTable DocumentList = DataTools.DataMaster.GetDocsPN_PartID(Convert.ToInt64(tb_PartID.Text));

                    foreach (DataRow row in DocumentList.Rows) {
                        Int64 TempRowID = row.Field<Int64>("ID");
                        Int64 TempDocID = row.Field<Int64>("DocID");
                        string TempName = "Error";
                        Int64 Temprev = 0;
                        DataTable dt_TempDocID = DataTools.DataMaster.GetUniqueDoc_DocID(TempDocID);


                        if (dt_TempDocID.Rows.Count > 0) {
                            TempName = dt_TempDocID.Rows[0].Field<string>("Name");
                            Temprev = dt_TempDocID.Rows[0].Field<Int64>("Revison");
                        }

                        dataGridView1.Rows.Add("Edit", TempRowID, TempDocID, TempName, Temprev, TempDocID);

                    }
                } else {


                    for (int i = 0; i < dataGridView1.Rows.Count; i++) {

                        dataGridView1.Rows[i].Cells[dgv_tb_RowID.Index].Value = -1;


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

            if (!string.IsNullOrWhiteSpace(cob_PartNumber.Text)) {

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
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0) {
                //TODO - Button Clicked - Execute Code Here


                Engineering.QueryDocuments subform = new Engineering.QueryDocuments();

                subform.ShowDialog();
                string results = subform.DocID_F2;

                if (results != null) {
                    DataTable UniqueDocument = DataTools.DataMaster.GetUniqueDoc_DocID(Convert.ToInt64(results));



                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = results;
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = UniqueDocument.Rows[0].Field<string>("Name");
                    dataGridView1.Rows[e.RowIndex].Cells[4].Value = UniqueDocument.Rows[0].Field<Int64>("Revison");
                    //dataGridView1.Rows[e.RowIndex].Cells[5].Value = results;
                }
            }



        }

        private void btn_Save_Click(object sender, EventArgs e) {

            bool DocChanges = false;

            int RowNumber = 1;

            Int64 FinialPartID = Convert.ToInt64(tb_PartID.Text);

            foreach (DataGridViewRow drv in dataGridView1.Rows) {
                Int64 TempRowID = Convert.ToInt64(drv.Cells[dgv_tb_RowID.Index].Value);
                Int64 TempDocID = Convert.ToInt64(drv.Cells[dgv_Main_DocID.Index].Value);
                Int64 TempOldDocID = Convert.ToInt64(drv.Cells[dgv_tb_OldDocID.Index].Value);


                if (TempRowID == -1) {
                    //Insert Code
                    DataTools.DataMaster.InsertDocsPN_NewRow(FinialPartID, TempDocID, RowNumber);
                } else {
                    //Update Code
                    DataTools.DataMaster.UpdateDocsPN_RowID(TempRowID, TempDocID, RowNumber);

                }




                RowNumber++;
            }



            //The End user wants me make my life hard...........

            foreach (DataGridViewRow drv in dataGridView1.Rows) {
                Int64 NewDocID = Convert.ToInt64(drv.Cells[dgv_Main_DocID.Index].Value);
                Int64 OldDocID = Convert.ToInt64(drv.Cells[dgv_tb_OldDocID.Index].Value);

                //Get the inspection Points
                DataTable NewICID_Data = DataTools.DataMaster.GetInspCriteria(null, null, null, null, NewDocID);

                foreach (DataRow ICIDRow in NewICID_Data.Rows) {
                    Int64 PastICID = ICIDRow.Field<Int64>("OldICID");
                    Int64 NewICID = ICIDRow.Field<Int64>("DataPointID");

                    DataTable GotOldOderPOS = DataTools.DataMaster.GetOrderInspPN(null, null, PastICID);

                    if (GotOldOderPOS.Rows.Count > 0) {
                        Int64 ReqOpenOld = GotOldOderPOS.Rows[0].Field<Int64?>("ReqOpen")??0;
                        Int64 ReqCloseOld = GotOldOderPOS.Rows[0].Field<Int64?>("ReqClose") ?? 0;
                        Int64 OrderOld = GotOldOderPOS.Rows[0].Field<Int64?>("Order") ?? 0;

                        DataTools.DataMaster.InsertOrderInspPN(FinialPartID, NewICID, OrderOld, ReqOpenOld, ReqCloseOld);

                    }

                }

            }




            this.Close();

        }
        

        private void btn_delete_Click(object sender, EventArgs e) {

            if (this.dataGridView1.CurrentCell.RowIndex >= 0) {

                DataGridView view = this.dataGridView1;
                try {
                    int index = view.SelectedCells[0].OwningRow.Index;

                    DataGridViewRow dataGridViewRow = view.Rows[index];



                    Int64 TempRowID = Convert.ToInt64(dataGridView1.Rows[index].Cells[1].Value);
                    Int64 TempDocID = Convert.ToInt64(dataGridView1.Rows[index].Cells[2].Value);



                    if (TempRowID > 0) {
                        // Kill data base record.
                        DataTools.DataMaster.DeleteDocsPN_RowID(TempRowID);
                    }



                    view.Rows.Remove(dataGridViewRow);

                } catch {
                }



            }



                


            

        }

        private void btn_Up_Click(object sender, EventArgs e) {

            if (dataGridView1.CurrentCell.RowIndex > 0) {
                try {
                    int count = dataGridView1.Rows.Count;
                    int index = dataGridView1.SelectedCells[0].OwningRow.Index;
                    if (index != 0) {
                        int num2 = this.dataGridView1.SelectedCells[0].OwningColumn.Index;
                        DataGridViewRow dataGridViewRow = this.dataGridView1.Rows[index];
                        dataGridView1.Rows.Remove(dataGridViewRow);
                        dataGridView1.Rows.Insert(index - 1, dataGridViewRow);
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[index - 1].Cells[num2].Selected = true;
                    }
                } catch {
                }
            }



        }

        private void btn_Down_Click(object sender, EventArgs e) {

            if (dataGridView1.CurrentCell.RowIndex > 0) {
                DataGridView view = dataGridView1;
                try {
                    int index = view.SelectedCells[0].OwningRow.Index;
                    if (index != (view.Rows.Count - 1)) {
                        int num3 = view.SelectedCells[0].OwningColumn.Index;
                        DataGridViewRow dataGridViewRow = view.Rows[index];
                        view.Rows.Remove(dataGridViewRow);
                        view.Rows.Insert(index + 1, dataGridViewRow);
                        view.ClearSelection();
                        view.Rows[index + 1].Cells[num3].Selected = true;
                    }
                } catch {
                }
            }



        }

        private void cb_AllColumns_CheckedChanged(object sender, EventArgs e) {

            dgv_tb_RowID.Visible = cb_AllColumns.Checked;
            dgv_tb_OldDocID.Visible = cb_AllColumns.Checked;


        }
    }
    
}
