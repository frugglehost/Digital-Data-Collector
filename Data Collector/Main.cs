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

            if (!string.IsNullOrWhiteSpace(str_ShopOrder)) {
                MessageBox.Show("Mising Shop Order data");
            } else {
                //We have a potently valid shoporder. Lets go and see if it exists. 

                DataTable ShopOrderData = DataTools.DataMaster.GetShopOrder(str_ShopOrder);

                if (ShopOrderData.Rows.Count != 1) {
                    // We have a problem let tell the end user.
                } else {
                    //We made it! We have a single row no duplices or any missing. 

                    //Get a unique PartID to fill in the boxes.

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

            DataTable PartRevs = DataTools.DataMaster.GetRevbyPN(cob_PartNumber.Text);

            foreach (DataRow Row in PartRevs.Rows) {

                cob_Rev.Items.Add(Row[2]);

            }


        }

        private void cob_Rev_SelectedIndexChanged(object sender, EventArgs e) {


            //Great Time to go and change the Rev.

            DataTable PartID = DataTools.DataMaster.GetPartIDbyPNandRev(cob_PartNumber.Text,Convert.ToInt32(cob_Rev.Text));

            if (PartID.Rows.Count != 1) {
                //failed to find a valid Part ID.
            } else {
                Int64 int_PartID = PartID.Rows[0].Field<Int64>("PartID");
                tb_PartID.Text= int_PartID.ToString();

            }

        }

        private void ts_ManageDocument_Click(object sender, EventArgs e) {
            new Engineering.ManageDocument().ShowDialog();
        }

        private void mannagePartNumberToolStripMenuItem_Click(object sender, EventArgs e) {
            new Engineering.ManagePartNumber().ShowDialog();
        }
    }
}
