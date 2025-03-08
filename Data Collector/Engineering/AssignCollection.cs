using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Data_Collector.Engineering {
    public partial class AssignCollection : Form {
        public AssignCollection(string PartID, string InspID, string DocID,string Position,int RowNumber, string OrderID) {
            InitializeComponent();

            tb_PartID.Text = PartID;
            tb_InspID.Text= InspID.ToString();

            
            string[] strPosition = Position.Split(',');

            tb_DocID.Text = DocID;
            try {
                tb_Position.Text = string.Format("{0},{1},{2}", strPosition[0], strPosition[1], strPosition[2]);
            }catch { }

            cob_Mandatory.SelectedIndex = 0;
            tb_Order.Text = RowNumber.ToString();
            tb_OrderID.Text = OrderID;
        }

        private void btn_Save_Click(object sender, EventArgs e) {

            Int64 InspID = Convert.ToInt64(tb_InspID.Text);
            string Type = cob_Type.Text;
            string Name= tb_Name.Text;
            string Desc= tb_Desc.Text;
            string UserRole = cob_UserRole.Text;
            string Mandatory = cob_Mandatory.Text;
            string DocID = tb_DocID.Text;
            string Position = tb_Position.Text;

            //Update the OrderInspPN Talbe
            DataTools.DataMaster.UpdateInspCriteria(InspID, Type, Name, Desc, UserRole, Convert.ToInt64(Convert.ToBoolean(Mandatory)), Convert.ToInt64(DocID), Position);


            //Update the InspCriteria

            Int64 OrderID = Convert.ToInt64(tb_OrderID.Text);
            Int64 PartID=Convert.ToInt64(tb_PartID.Text);
            Int64 OpenReq=-1 ;
            Int64 CloseReq=-1;
            Int64 OrderNum = Convert.ToInt64(tb_Order.Text);


            Int64.TryParse(tb_Open.Text, out OpenReq);
            Int64.TryParse(tb_Close.Text, out CloseReq);

            DataTools.DataMaster.UpdateOrderInspPN(OrderID, PartID, InspID, OpenReq, CloseReq, OrderNum);


            this.Close();

        }

        private void AssignCollection_Load(object sender, EventArgs e) {

            //We are all loaded. Lets fill out the form for the end user if there is old Data.

            DataTable OrderInspPN = DataTools.DataMaster.GetOrderInspPN_RowID(Convert.ToInt64(tb_OrderID.Text));
            DataTable InspCriteria = DataTools.DataMaster.GetInspCriteria_DataPointID(Convert.ToInt64(tb_InspID.Text));

            if (OrderInspPN.Rows.Count > 0) {
                tb_Open.Text=OrderInspPN.Rows[0].Field<Int64?>("ReqOpen").ToString() ?? "";
                tb_Close.Text = OrderInspPN.Rows[0].Field<Int64?>("ReqClose").ToString() ?? "";
            }

            if (InspCriteria.Rows.Count > 0) {
                cob_Type.Text=InspCriteria.Rows[0].Field<string>("Type") ?? "";
                tb_Name.Text = InspCriteria.Rows[0].Field<string>("DataPointName") ?? "";
                tb_Desc.Text = InspCriteria.Rows[0].Field<string>("Description") ?? "";
                cob_UserRole.Text = InspCriteria.Rows[0].Field<string>("UserType") ?? "";


                if ((InspCriteria.Rows[0].Field<Int64?>("Mandatory") ?? 1) != 1) {
                    cob_Mandatory.Text = "FALSE";
                } else { 
                    cob_Mandatory.Text = "TRUE"; 
                }

                



            }


            CheckStatus(this, EventArgs.Empty);
        }

        private void cob_Type_Leave(object sender, EventArgs e) {

        }

        private void CheckStatus(object sender, EventArgs e) {
            bool AllGood = false;

            if (cob_Type.SelectedIndex != -1 && 
                !String.IsNullOrWhiteSpace(tb_Name.Text) &&
                !String.IsNullOrWhiteSpace(tb_Desc.Text) &&
                cob_UserRole.SelectedIndex != -1 &&
                cob_Mandatory.SelectedIndex != -1) {
                AllGood = true;
            }






            btn_Save.Enabled = AllGood;

        }

    }
}
