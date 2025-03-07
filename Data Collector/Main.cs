using PdfiumViewer;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Data_Collector {
    public partial class Main : Form {

        string LocalFolder = "";

        public Main() {
            InitializeComponent();
            LocalFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Digital Data Collector";

            if (!Directory.Exists(LocalFolder)) {
                Directory.CreateDirectory(LocalFolder);
            }

            if (!Directory.Exists(LocalFolder+@"\OfflineDB")) {
                Directory.CreateDirectory(LocalFolder + @"\OfflineDB");
            }
            if (!Directory.Exists(LocalFolder + @"\OfflinePDF")) {
                Directory.CreateDirectory(LocalFolder + @"\OfflinePDF");
            }
        }

        private void btn_Test_Click(object sender, EventArgs e) {

            pdf_Document.Document?.Dispose();
            pdf_Document.Load(PdfDocument.Load(@"C:\Users\jedwo\Downloads\732181_3672185_Dworak.pdf"));
        }

        private void btn_Search_Click(object sender, EventArgs e) {

            //Capture the User Input and format it to upper and trim.
            string str_ShopOrder = tb_ShopOrder.Text;
            str_ShopOrder = str_ShopOrder.ToUpper().Trim();
            tb_ShopOrder.Text = str_ShopOrder;

            cob_PartNumber_Enter(this, EventArgs.Empty);
            cob_Rev.Items.Clear();

            if (string.IsNullOrWhiteSpace(str_ShopOrder)) {
                MessageBox.Show("Mising Shop Order data");
            } else {
                //We have a potently valid shoporder. Lets go and see if it exists. 

                DataTable ShopOrderData = DataTools.DataMaster.GetShopOrder_ShopOrder(str_ShopOrder);

                if (ShopOrderData.Rows.Count != 1) {
                    // We have a problem let tell the end user.
                } else {
                    //We made it! We have a single row no duplices or any missing. 
                    Int64 TempPartID = ShopOrderData.Rows[0].Field<Int64>("PartID");


                    //Get details of the PartID for the display.
                    DataTable DetailsPartID=DataTools.DataMaster.GetUniquePN_PartID(TempPartID);

                    if (DetailsPartID.Rows.Count > 0) {
                        cob_PartNumber.Text = DetailsPartID.Rows[0].Field<string>("PartNumber");
                        cob_PartNumber_Leave(this, EventArgs.Empty);


                        cob_Rev.Text = DetailsPartID.Rows[0].Field<Int64>("Revision").ToString();

                        cob_Rev_Leave(this, EventArgs.Empty);

                        cob_PartNumber.Enabled = false;
                        cob_Rev.Enabled = false;
                    }



                    



                }





            }
        }



        private void cob_PartNumber_Enter(object sender, EventArgs e) {
            if (cob_PartNumber.Items.Count == 0) {
                //We have an empty box lets get some data.

                cob_Rev.Items.Clear();

                DataTable PartNumbers = DataTools.DataMaster.GetAllPN();

                foreach (DataRow Row in PartNumbers.Rows) {

                    cob_PartNumber.Items.Add(Row[0]);

                }



            }
        }

        private void ts_CreateTables_Click(object sender, EventArgs e) {
            DataTools.BlankSQlite.CreateDB();
        }

        private void cob_PartNumber_SelectedIndexChanged(object sender, EventArgs e) {

            //Great Time to go and change the Rev.
            cob_Rev.Items.Clear();

            DataTable PartRevs = DataTools.DataMaster.GetRevbyPN(cob_PartNumber.Text);

            foreach (DataRow Row in PartRevs.Rows) {

                cob_Rev.Items.Add(Row[2]);

            }


        }

        private void cob_Rev_SelectedIndexChanged(object sender, EventArgs e) {


            //Great Time to go and change the Rev.

            DataTable PartID = DataTools.DataMaster.GetPartIDbyPNandRev(cob_PartNumber.Text,Convert.ToInt32(cob_Rev.Text));
            Int64 int_PartID = 0;

            if (PartID.Rows.Count != 1) {
                //failed to find a valid Part ID.
            } else {
                int_PartID = PartID.Rows[0].Field<Int64>("PartID");
                tb_PartID.Text= int_PartID.ToString();

            }



            //Get a unique PartID to fill in the boxes.
            DataTable DocumentsList = DataTools.DataMaster.GetDocsPN_PartID(int_PartID);

            DataTable DetailDocList = new DataTable();
            DetailDocList.Columns.Add("Display");
            DetailDocList.Columns.Add("Value");

            foreach (DataRow Row in DocumentsList.Rows) {
                string TempDisplay = "";
                Int64 TempValue = 0;

                TempValue = Row.Field<Int64>("DocID");

                DataTable TempDocuDetails = DataTools.DataMaster.GetUniqueDoc_DocID(TempValue);

                if (TempDocuDetails.Rows.Count > 0) {
                    TempDisplay = TempDocuDetails.Rows[0].Field<string>("Name") + " Rev " + TempDocuDetails.Rows[0].Field<Int64>("Revison").ToString();

                    DetailDocList.Rows.Add(TempDisplay, TempValue);
                }
            }

            cob_DocList.ValueMember = "Value";
            cob_DocList.DisplayMember = "Display";
            cob_DocList.DataSource = DetailDocList;



        }

        private void ts_ManageDocument_Click(object sender, EventArgs e) {
            new Engineering.ManageDocument().ShowDialog();
        }

        private void mannagePartNumberToolStripMenuItem_Click(object sender, EventArgs e) {
            new Engineering.ManagePartNumber().ShowDialog();
        }

        private void ts_ShoOrder_Click(object sender, EventArgs e) {
            new Production.CreateOrders().ShowDialog();
        }

        private void cob_PartNumber_Leave(object sender, EventArgs e) {


            if (cob_PartNumber.SelectedIndex == -1) {

                cob_Rev.Items.Clear();
                tb_PartID.Text = "";

                //if there is a similar/aleady existing PN lets reuse it.
                foreach (string ItemData in cob_PartNumber.Items) {
                    if (cob_PartNumber.Text.ToUpper().Trim() == ItemData.ToUpper().Trim()) {
                        cob_PartNumber.SelectedItem = ItemData;

                    }
                }


            }

        }

        private void cob_Rev_Leave(object sender, EventArgs e) {

            if (cob_Rev.SelectedIndex == -1) {
                tb_PartID.Text = "";

                //if there is a similar/aleady existing PN lets reuse it.
                foreach (Int64 ItemData in cob_Rev.Items) {
                    if (Convert.ToInt64(cob_Rev.Text) == ItemData) {
                        cob_Rev.SelectedItem = ItemData;

                    }
                }


            }


        }
    }
}
