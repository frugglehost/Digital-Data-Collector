using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Collector.Production {
    public partial class CreateOrders : Form {
        public CreateOrders() {
            InitializeComponent();
        }

        private void CreateOrders_Load(object sender, EventArgs e) {

            DataTable PartList = DataTools.DataMaster.GetAllPN();
            DataTable ShopOrders = DataTools.DataMaster.GetShopOrder_All();

            foreach (DataRow row in PartList.Rows) {
                cob_PartNumber.Items.Add(row.Field<string>("PartNumber"));
            }

            foreach (DataRow row in ShopOrders.Rows) {
                cob_ShopOrders.Items.Add(row.Field<string>("ShopOrder"));
            }


        }

        private void cob_PartNumber_SelectedIndexChanged(object sender, EventArgs e) {

            //Great Time to go and change the Rev.
            cob_Rev.Items.Clear();

            DataTable PartRevs = DataTools.DataMaster.GetRevbyPN(cob_PartNumber.Text);

            foreach (DataRow Row in PartRevs.Rows) {

                cob_Rev.Items.Add(Row[2]);

            }

            if (cob_Rev.Items.Count > 0) {
                cob_Rev.SelectedIndex = 0;
            }


        }

        private void cob_Rev_SelectedIndexChanged(object sender, EventArgs e) {


            //Great Time to go and change the Rev.

            DataTable PartID = DataTools.DataMaster.GetPartIDbyPNandRev(cob_PartNumber.Text, Convert.ToInt32(cob_Rev.Text));

            if (PartID.Rows.Count != 1) {
                //failed to find a valid Part ID.
            } else {
                Int64 int_PartID = PartID.Rows[0].Field<Int64>("PartID");
                tb_PartID.Text = int_PartID.ToString();

                //cob_PartNumber.Enabled=false;
            }


        }

        private void cob_PartNumber_Leave(object sender, EventArgs e) {

            //See if there was alrady a number.
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

        private void btn_AddSN_Click(object sender, EventArgs e) {

            lb_Serials.Items.Add(tb_Serial.Text.ToUpper().Trim());
            tb_Serial.Text = "";
            tb_Serial.Focus();

        }

        private void lb_Serials_MouseClick(object sender, MouseEventArgs e) {

        }

        private void lb_Serials_MouseDown(object sender, MouseEventArgs e) {
            switch (e.Button) {
                case MouseButtons.Right: {
                    cxb_Serials.Show(this, new Point(e.X+ lb_Serials.Location.X, e.Y+ lb_Serials.Location.Y));//places the menu at the pointer position
                }
                break;
            }
        }

        private void ts_RemoveSelected_Click(object sender, EventArgs e) {

            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(lb_Serials);
            selectedItems = lb_Serials.SelectedItems;

            foreach (var Items in lb_Serials.SelectedItems) {

                DataTools.DataMaster.RemoveUniqueSerial(cob_ShopOrders.Text, cob_PartNumber.Text, Items.ToString());

                //lb_Serials.Items.Remove(Items);
            }

            
            if (lb_Serials.SelectedIndex != -1) {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    lb_Serials.Items.Remove(selectedItems[i]);
            }
            

        }

        private void cob_ShopOrders_SelectedIndexChanged(object sender, EventArgs e) {

            //We have a Shop Order lets go and see if someone already created it.

            lb_Serials.Items.Clear();

            //Get DocID
            //Get Qty
            //Get Serials

            string str_OrderNumber = cob_ShopOrders.Text;
            Int64 int_DocumnetID = 0;

            DataTable ShopOrderInfo = DataTools.DataMaster.GetShopOrder_ByOrderNum(str_OrderNumber);

            if (ShopOrderInfo.Rows.Count > 0) {
                int_DocumnetID= ShopOrderInfo.Rows[0].Field<Int64>("PartID");
                tb_Qty.Text = ShopOrderInfo.Rows[0].Field<Int64>("Qty").ToString();

                DataTable DocumnetID = DataTools.DataMaster.GetUniquePN_PartID(int_DocumnetID);

                DataTable SerilNumbers = DataTools.DataMaster.GetUniqueSerial_Order(str_OrderNumber);

                if (DocumnetID.Rows.Count > 0) {
                    cob_PartNumber.Text = DocumnetID.Rows[0].Field<string>("PartNumber");
                    cob_Rev.Text = DocumnetID.Rows[0].Field<Int64>("Revision").ToString();
                    tb_PartID.Text= int_DocumnetID.ToString();
                }

                foreach (DataRow dr in SerilNumbers.Rows) {
                    lb_Serials.Items.Add(dr.Field<string>("Serial"));
                }



            }

            

        }

        private void btn_Save_Click(object sender, EventArgs e) {

            string TempShopOrder = cob_ShopOrders.Text;
            Int64 tempPartID=Convert.ToInt64(tb_PartID.Text);
            Int64 tempQty = Convert.ToInt64(tb_Qty.Text);

            //Check if the Order exists. 
            if (DataTools.DataMaster.GetShopOrder_ShopOrder(cob_ShopOrders.Text).Rows.Count > 0) {

                //We have a hit lets Update
                DataTools.DataMaster.UpdateShopOrder_ShopOrder(TempShopOrder, tempPartID, tempQty);

            } else {
                //No Hit do a insert.

                DataTools.DataMaster.InsertShopOrder(TempShopOrder, tempPartID, tempQty);

            }

            DataTable GetAllOldSN = DataTools.DataMaster.GetUniqueSerial(TempShopOrder);
            foreach (string TempSN in lb_Serials.Items) {

                bool Found = false;

                foreach(DataRow OldSNrows in GetAllOldSN.Rows) {
                    string Serial = OldSNrows.Field<string>("Serial");
                    if (Serial== TempSN) {
                        Found = true;
                    }
                }

                if (!Found) DataTools.DataMaster.InsertUniqueSerial(TempShopOrder, cob_PartNumber.Text, TempSN);
            }

            this.Close();


        }
    }
}
