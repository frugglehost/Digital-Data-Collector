using Data_Collector.Production;
using Newtonsoft.Json;
using PdfiumViewer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO.Ports;
using System.Security.Cryptography;

namespace Data_Collector {
    public partial class Main : Form {

        
        /// Keep it Alive
        [FlagsAttribute]
        public enum EXECUTION_STATE : uint {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001
            // Legacy flag, should not be used.
            // ES_USER_PRESENT = 0x00000004
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);
        ///

        string LocalFolder = "";
        string GUID_Beat ="";

        public Main() {
            InitializeComponent();
            LocalFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Digital Data Collector";

            if (!Directory.Exists(LocalFolder)) {
                Directory.CreateDirectory(LocalFolder);
            }

            if (!Directory.Exists(LocalFolder + @"\OfflineDB")) {
                Directory.CreateDirectory(LocalFolder + @"\OfflineDB");
            }
            if (!Directory.Exists(LocalFolder + @"\OfflinePDF")) {
                Directory.CreateDirectory(LocalFolder + @"\OfflinePDF");
            }
        }



        private void btn_Search_Click(object sender, EventArgs e) {
            GUID_Beat = "";


            //Lets make everything clean.
            pdf_Document.Document?.Dispose();
            pdf_Document.Load(PdfDocument.Load("Resources/Blank.pdf"));


            dgv_Main.Rows.Clear();
            
            cob_PartNumber.Enabled = true;
            cob_PartNumber.SelectedIndex = -1;
            cob_PartNumber.Items.Clear();

            cob_Rev.Enabled = true;
            cob_Rev.SelectedIndex = -1;
            cob_Rev.Items.Clear();

            cob_DocList.DataSource = null;
            cob_DocList.Items.Clear();
            cob_Serials.Items.Clear();
            tb_PartID.Text = "";



            

            if (btn_Search.Text == "Search") {

                //Capture the User Input and format it to upper and trim.
                string str_ShopOrder = tb_ShopOrder.Text;
                str_ShopOrder = str_ShopOrder.ToUpper().Trim();
                tb_ShopOrder.Text = str_ShopOrder;

                cob_PartNumber_Enter(this, EventArgs.Empty);
                

                if (string.IsNullOrWhiteSpace(str_ShopOrder)) {
                    MessageBox.Show("Mising Shop Order data");
                } else {
                    //We have a potently valid shoporder. Lets go and see if it exists. 

                    DataTable ShopOrderData = DataTools.DataMaster.GetShopOrder_ShopOrder(str_ShopOrder);
                    DataTable ShopOrderSN = DataTools.DataMaster.GetUniqueSerial(str_ShopOrder, null , null);


                    foreach (DataRow RowSN in ShopOrderSN.Rows) {

                        cob_Serials.Items.Add(RowSN.Field<string>("Serial"));

                    }
                    if (cob_Serials.Items.Count > 0) {
                        cob_Serials.SelectedIndex = 0;
                    }

                    if (ShopOrderData.Rows.Count != 1) {
                        // We have a problem let tell the end user.
                        tb_ShopOrder.BackColor = Color.Red;
                        tb_ShopOrder.Focus();
                        tb_ShopOrder.SelectAll();
                    } else {

                        //Lock that shop order down.
                        tb_ShopOrder.BackColor = SystemColors.Window;
                        tb_ShopOrder.Enabled = false;

                        btn_Search.Text = "Done";


                        //We made it! We have a single row no duplices or any missing. 
                        Int64 TempPartID = ShopOrderData.Rows[0].Field<Int64>("PartID");


                        //Get details of the PartID for the display.
                        DataTable DetailsPartID = DataTools.DataMaster.GetUniquePN_PartID(TempPartID);

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
                timer_Refresh.Enabled = true;
                btn_Sync.Enabled = true;

                

            } else {
                tb_ShopOrder.BackColor = SystemColors.Window;
                tb_ShopOrder.Enabled = true;
                timer_Refresh.Enabled = false;
                btn_Sync.Enabled = false;

                btn_Search.Text = "Search";
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

            DataTable PartID = DataTools.DataMaster.GetPartIDbyPNandRev(cob_PartNumber.Text, Convert.ToInt32(cob_Rev.Text));
            Int64 int_PartID = 0;

            if (PartID.Rows.Count != 1) {
                //failed to find a valid Part ID.
            } else {
                int_PartID = PartID.Rows[0].Field<Int64>("PartID");
                tb_PartID.Text = int_PartID.ToString();

            }







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

        private void cob_DocList_SelectedIndexChanged(object sender, EventArgs e) {

            var TempDocID = cob_DocList.SelectedValue;

            if (TempDocID!=null) {

                pdf_Document.Document?.Dispose();
                pdf_Document.Load(PdfDocument.Load(LocalFolder + @"\OfflinePDF\" + TempDocID + ".pdf"));

            }




        }

        private void tb_PartID_TextChanged(object sender, EventArgs e) {

            dgv_Main.Rows.Clear();

            if (!string.IsNullOrEmpty(tb_PartID.Text)) {



                Int64 intPartID = Convert.ToInt64(tb_PartID.Text);

                //Get a unique PartID to fill in the boxes.
                DataTable DocumentsList = DataTools.DataMaster.GetDocsPN_PartID(intPartID);

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

                        try {
                            File.Copy(@TempDocuDetails.Rows[0].Field<string>("Path"), LocalFolder + @"\OfflinePDF\" + TempValue + ".pdf", true);
                        } catch { }
                    }
                }

                cob_DocList.ValueMember = "Value";
                cob_DocList.DisplayMember = "Display";
                cob_DocList.DataSource = DetailDocList;

                //We now have the documents now we need to get a list of Inspection points.
                DataTable OrderInspPN = DataTools.DataMaster.GetOrderInspPN_PartID(Convert.ToInt64(tb_PartID.Text));
                List<Int64> InspectionCriteriaID = new List<Int64>();

                foreach (DataRow Row in OrderInspPN.Rows) {
                    Int64? OrderID = Row.Field<Int64?>("ROWID");
                    Int64 InpCrID = Row.Field<Int64?>("DataPointID") ?? 0;
                    Int64? ReqOpen = Row.Field<Int64?>("ReqOpen");
                    Int64? ReqClos = Row.Field<Int64?>("ReqClose");

                    dgv_Main.Rows.Add(OrderID, InpCrID, ReqOpen, ReqClos);
                    InspectionCriteriaID.Add(InpCrID);
                }


                if (InspectionCriteriaID.Count > 0) {
                    DataTable Records = DataTools.DataMaster.GetInspCriteria_DataPointID_Bulk(InspectionCriteriaID);
                    DataTable Values = DataTools.DataMaster.GetDataRecords(null, tb_ShopOrder.Text, null);

                    //Find the spcific row in the data Table that matches
                    int int_RowIndexDGV = 0;
                    foreach (DataGridViewRow DGV_Row in dgv_Main.Rows) {

                        string str_ICID = DGV_Row.Cells["dgv_Main_ICID"].Value.ToString();

                        //Parse though the Records
                        foreach (DataRow Row in Records.Rows) {
                            if (str_ICID == Row.Field<Int64?>("DataPointID").ToString()) {
                                DGV_Row.Cells["dgv_tb_Name"].Value = Row.Field<string>("DataPointName");
                                DGV_Row.Cells["dgv_tb_Name"].ToolTipText = Row.Field<string>("Description");

                                DGV_Row.Cells["dgv_tb_User"].Value = Row.Field<string>("UserType");
                                DGV_Row.Cells["dgv_cb_Mandatory"].Value = Convert.ToBoolean(Row.Field<Int64?>("Mandatory") ?? 0);
                                DGV_Row.Cells[dgv_tb_DocID.Index].Value = Row.Field<Int64?>("DocID") ?? 0;
                                DGV_Row.Cells[dgv_tb_Position.Index].Value = Row.Field<string>("DocPosition");
                            }
                        }

                        //Parse Though the Values

                        // Use the Select method to find all rows matching the filter.
                        string expression = "DataPointID = " + str_ICID;
                        DataRow[] foundRows = Values.Select(expression, "Rec_ID DESC");
                        DataTable TempValue = Values.Clone();

                        foreach (DataRow FoundRowData in foundRows) {
                            TempValue.ImportRow(FoundRowData);
                        }
                        UpdateMainValue(int_RowIndexDGV, Convert.ToInt64(str_ICID), TempValue);
                        int_RowIndexDGV++;
                    }
                }


                if (!string.IsNullOrWhiteSpace(tb_ShopOrder.Text)) {
                    GUID_Beat = Guid.NewGuid().ToString();

                    DataTools.DataMaster.UpsertClockingLog(GUID_Beat, tb_ShopOrder.Text, ss_User.Text, DateTime.UtcNow.ToString(), DateTime.UtcNow.ToString());


                }


            }
        }

        private void pdf_Document_Click(object sender, EventArgs e) {

            MouseEventArgs args = (MouseEventArgs)e;
            PdfPoint point = this.pdf_Document.PointToPdf(args.Location);
            //DocID, Page, X, Y
            string Position = String.Format("{0},{1},{2}", point.Page.ToString(), point.Location.X, point.Location.Y);


            Rectangle displayRectangle = this.pdf_Document.DisplayRectangle;




            int LastRow = 0;
            if (this.dgv_Main.SelectedCells.Count > 0) {

                foreach (DataGridViewCell Cells in dgv_Main.SelectedCells) {
                    dgv_Main.Rows[Cells.RowIndex].Cells[dgv_tb_Position.Index].Value = Position;
                    dgv_Main.Rows[Cells.RowIndex].Cells[dgv_tb_DocID.Index].Value = cob_DocList.SelectedValue;
                    dgv_Main.Rows[Cells.RowIndex].Cells[dgv_tb_Position.Index].Style.BackColor = Color.Yellow;
                    

                    if (LastRow < Cells.RowIndex)
                        LastRow = Cells.RowIndex;
                }


                /*
                using (IEnumerator enumerator = this.dgv_Main.SelectedCells.GetEnumerator()) {
                    while (enumerator.MoveNext()) {
                        rowIndex = ((DataGridViewCell)enumerator.Current).RowIndex;
                        this.dgv_Main.Rows[rowIndex].Cells["dgv_tb_Position"].Value = Position;
                        this.dgv_Main.Rows[rowIndex].Cells["dgv_tb_Position"].Style.BackColor = Color.Yellow;
                        this.dgv_Main.Rows[rowIndex].Cells[dgv_tb_DocID.Index].Value = this.cob_DocList.SelectedValue;
                        this.dgv_Main.Rows[rowIndex].Cells[dgv_tb_DocID.Index].Style.BackColor = Color.Yellow;
                        this.dgv_Main.Rows[rowIndex].Cells["dgv_tb_Display"].Value = this.pdf_Document.Document.PageSizes[0];
                        if (rowIndex > num3) {
                            num3 = rowIndex;
                        }
                    }
                }
                */
                this.dgv_Main.ClearSelection();
                if (this.dgv_Main.Rows.Count > (LastRow + 1)) {
                    this.dgv_Main.Rows[LastRow + 1].Cells[dgv_tb_Position.Index].Selected = true;
                }
            }





        }

        private void btn_Add_Click(object sender, EventArgs e) {
            dgv_Main.Rows.Add();
        }

        private void dgv_Main_CellClick(object sender, DataGridViewCellEventArgs e) {


            int rowIndex = dgv_Main.CurrentCell.RowIndex;
            int colIndex = dgv_Main.CurrentCell.ColumnIndex;
            if (dgv_Main.Rows[rowIndex].Cells[dgv_tb_Position.Index].Value != null && colIndex==1) {

                //Read and sepperate the CSV (Page, X, Y)
                char[] separator = new char[] { ',' };
                string[] strPosition = dgv_Main.Rows[rowIndex].Cells[dgv_tb_Position.Index].Value.ToString().Split(separator);

                
                try {
                    Int64 DocumnetID = Convert.ToInt64(dgv_Main.Rows[rowIndex].Cells[dgv_tb_DocID.Index].Value.ToString() ?? "0");

                    if (Convert.ToInt64(cob_DocList.SelectedValue) != DocumnetID && DocumnetID!=0) {
                        try {
                            cob_DocList.SelectedValue = DocumnetID;
                        }catch{  }
                    }
                    

                    int intPageNum = Convert.ToInt32(Math.Floor(Convert.ToDouble(strPosition[0])));
                    int IntX = Convert.ToInt32(Math.Floor(Convert.ToDouble(strPosition[1])));
                    int IntY = Convert.ToInt32(Math.Floor(Convert.ToDouble(strPosition[2])));
                    if (this.pdf_Document.Page != intPageNum) {
                        double num6 = this.pdf_Document.DisplayRectangle.Height / this.pdf_Document.Document.PageCount;
                        double width = this.pdf_Document.DisplayRectangle.Width;
                        float height = this.pdf_Document.Document.PageSizes[intPageNum].Height;
                        double DoubleY = (num6 * intPageNum) + (((height - IntY) / height) * num6);
                        int ModedY = Convert.ToInt32(Math.Round(DoubleY, 0)) - 100;
                        int ModedX = Convert.ToInt32(Math.Round((double)((((float)IntX) / this.pdf_Document.Document.PageSizes[intPageNum].Width) * width), 0)) - 200;
                        if (ModedY < 0) {
                            ModedY = 0;
                        }
                        if (ModedX < 0) {
                            ModedX = 0;
                        }
                        this.pdf_Document.SetDisplayRectLocation(new Point(-ModedX, -ModedY));
                    }
                } catch (Exception) {
                }
            }





        }

        private void ts_EditPoints_Click(object sender, EventArgs e) {

            ts_EditPoints.Checked = !ts_EditPoints.Checked;
            dgv_Main.Columns["dgv_tb_Position"].Visible = ts_EditPoints.Checked;
            dgv_Main.Columns["dgv_tb_DocID"].Visible = ts_EditPoints.Checked;

            timer_Refresh.Enabled= !ts_EditPoints.Checked;

            if (ts_EditPoints.Checked) {
                dgv_Main.Width = dgv_Main.Width - 75;
                
            } else {
                dgv_Main.Width = dgv_Main.Width + 75;
            }


        }

        private void dgv_Main_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {

            //Check if the row is real row. (exclude headder)
            if (e.RowIndex >= 0) {

                string str_ICID = (dgv_Main.Rows[e.RowIndex].Cells[dgv_Main_ICID.Index].Value ?? "0").ToString();
                string str_OrderICID = (dgv_Main.Rows[e.RowIndex].Cells[dgv_tb_OrderID.Index].Value ?? "0").ToString();

                string strDocID = (dgv_Main.Rows[e.RowIndex].Cells[dgv_tb_DocID.Index].Value ?? "0").ToString();
                string strUserRole = (dgv_Main.Rows[e.RowIndex].Cells[dgv_tb_User.Index].Value ?? "").ToString();
                string strPosition = (dgv_Main.Rows[e.RowIndex].Cells[dgv_tb_Position.Index].Value ?? "").ToString();
                
                string strPartID=tb_PartID.Text;

                

                Int64 DataPointID = Convert.ToInt64(str_ICID);
                int RowNumber = e.RowIndex;

                //Check if we are in engineer mode or operator mode.
                if (ts_EditPoints.Checked) {
                    //We are in engineer mode. Lets save some points. 
                    if (strDocID == "0") {
                        strDocID = cob_DocList.SelectedValue.ToString();
                    }

                    //Check if any "NEW" rows has an OrderID and InspID


                    if (str_ICID == "0") {
                        DataTable InspCriteria = DataTools.DataMaster.InsertInspCriteria(Convert.ToInt64(strDocID));
                        str_ICID=InspCriteria.Rows[0].Field<Int64>("last_insert_rowid()").ToString();
                        dgv_Main.Rows[e.RowIndex].Cells[dgv_Main_ICID.Index].Value = str_ICID;
                    }

                    if (str_OrderICID == "0") {
                        DataTable InspCriteria = DataTools.DataMaster.InsertOrderInspPN(Convert.ToInt64(strPartID), Convert.ToInt64(str_ICID), e.RowIndex);
                        str_OrderICID = InspCriteria.Rows[0].Field<Int64>("last_insert_rowid()").ToString();
                        dgv_Main.Rows[e.RowIndex].Cells["dgv_tb_OrderID"].Value = str_OrderICID;
                    }

                    


                    Engineering.AssignCollection EditInspectionPoint = new Engineering.AssignCollection(strPartID, str_ICID, strDocID, strPosition, RowNumber, str_OrderICID);
                    EditInspectionPoint.ShowDialog();
                    //string results = subform.DocID_F2;

                    //The Form was closed update the Row. 

                    DataTable OrderInspPNNew = DataTools.DataMaster.GetOrderInspPN_RowID(Convert.ToInt64(str_OrderICID));
                    if (OrderInspPNNew.Rows.Count > 0) {
                        dgv_Main.Rows[e.RowIndex].Cells["dgv_tb_ReqOpen"].Value = OrderInspPNNew.Rows[0].Field<Int64>("ReqOpen");
                        dgv_Main.Rows[e.RowIndex].Cells["dgv_tb_ReqClosed"].Value = OrderInspPNNew.Rows[0].Field<Int64>("ReqClose");
                    }

                    DataTable InspCriteriaNew = DataTools.DataMaster.GetInspCriteria_DataPointID(Convert.ToInt64(str_ICID));
                    if (InspCriteriaNew.Rows.Count > 0) {

                        dgv_Main.Rows[e.RowIndex].Cells["dgv_tb_Name"].Value = InspCriteriaNew.Rows[0].Field<string>("DataPointName");
                        dgv_Main.Rows[e.RowIndex].Cells["dgv_tb_User"].Value = InspCriteriaNew.Rows[0].Field<string>("UserType");
                        dgv_Main.Rows[e.RowIndex].Cells["dgv_cb_Mandatory"].Value = Convert.ToBoolean(InspCriteriaNew.Rows[0].Field<Int64>("Mandatory"));

                        dgv_Main.Rows[e.RowIndex].Cells["dgv_tb_Position"].Value = InspCriteriaNew.Rows[0].Field<string>("DocPosition");
                        dgv_Main.Rows[e.RowIndex].Cells[dgv_tb_DocID.Index].Value = InspCriteriaNew.Rows[0].Field<Int64>("DocID");

                    }



                } else {
                    //We are in Operator Mode.

                    //Get groups that the operator is assigned too. 
                    DataTable UserRoles= DataTools.DataMaster.GetUserGroup_UserID(Environment.UserName);
                    bool Allowed = false;
                    foreach (DataRow Row in UserRoles.Rows) {
                        //Check if the user is apart of the group and "active" (1= true)
                        if(Row.Field<string>("UserType")== strUserRole && Convert.ToBoolean(Row.Field<Int64>("Active"))) {
                            Allowed = true;
                        }
                    }


                    if (!Allowed) {
                        //End user not allowed 

                        MessageBox.Show("User is not a " + strUserRole, "Group Error");


                    } else {
                        str_ICID = dgv_Main.Rows[e.RowIndex].Cells[dgv_Main_ICID.Index].Value.ToString();
                        string str_ShopOrder=tb_ShopOrder.Text;




                        //They are allowed in enable the flood gates!
                        new Production.DataCollection(str_ICID, str_ShopOrder).ShowDialog();

                        UpdateMainValue(e.RowIndex, Convert.ToInt64(str_ICID));

                    }

                }




                /*

                DataGridView view1 = (DataGridView)sender;

                if (!this.ts_EditDataPoints.Checked) {
                    string str2 = this.dgv_Main.Rows[e.RowIndex].Cells["dgv_db_UserType"].Value.ToString();
                    DataTable userbyGroup = new DataTable();
                    try {
                        userbyGroup = DataLoader.GetUserbyGroup(Environment.UserName);
                    } catch (Exception) {
                    }
                    bool flag = false;
                    if (userbyGroup.Rows.Count > 0) {
                        using (IEnumerator enumerator = userbyGroup.Rows.GetEnumerator()) {
                            while (enumerator.MoveNext()) {
                                if (((DataRow)enumerator.Current).Field<string>("UserType") != str2) {
                                    continue;
                                }
                                flag = true;
                            }
                        }
                    }
                    if (flag) {
                        new Form2(this.tb_ShopOrder.Text, DataPointID, "").ShowDialog();
                    } else {
                        MessageBox.Show("Not Authorized");
                    }
                    if ((this.t != null) && (this.t.ThreadState == ThreadState.Running)) {
                        this.t.Abort();
                    }
                    this.UpdateRowInfo(e.RowIndex);
                    this.UpdateCellToolTips(Convert.ToInt64(this.tb_PartID.Text), this.tb_ShopOrder.Text);
                } else if (DataPointID == 0) {
                    MessageBox.Show("Error: Select a document from the dropdown.");
                } else {
                    string text1;
                    string text2;
                    object obj1 = this.dgv_Main.Rows[e.RowIndex].Cells["dgv_tb_Position"].Value;
                    if (obj1 != null) {
                        text1 = obj1.ToString();
                    } else {
                        object local1 = obj1;
                        text1 = null;
                    }
                    string positionDisp = text1;
                    long result = 0L;
                    object obj2 = this.dgv_Main.Rows[e.RowIndex].Cells[dgv_tb_DocID.Index].Value;
                    if (obj2 != null) {
                        text2 = obj2.ToString();
                    } else {
                        object local2 = obj2;
                        text2 = null;
                    }
                    long.TryParse(text2, out result);
                    MannageDataPoint point1 = new MannageDataPoint(DataPointID, (long)e.RowIndex, result, Convert.ToInt64(this.tb_PartID.Text), positionDisp);
                    point1.ShowDialog();
                    long returnValue = point1.ReturnValue;
                    if (returnValue != 0) {
                        this.timer_Sync.Stop();
                        if ((this.t != null) && (this.t.ThreadState == ThreadState.Running)) {
                            this.t.Abort();
                        }
                        try {
                            DataLoader.GetIC(returnValue);
                            this.UpdateRowInfo(e.RowIndex);
                        } catch {
                            this.ss_Error.Text = "Failed to Grab data from Data Input Capture.";
                        }
                        this.timer_Sync.Start();
                    }
                }
                */
            }
        }


        //http://stackoverflow.com/questions/11137979/image-resizing-using-c-sharp
        public static Bitmap Resize(Image image, int width, int height) {

            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage)) {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes()) {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void UpdateMainValue(int RowIndex, Int64 int_ICID, DataTable Passrecord = null) {
            DataTable Records = new DataTable();
            bool ShouldWeAdd = false;
            //Lets get the data we need to make sure everything is present. 
            if (Passrecord == null) {
                 Records = DataTools.DataMaster.GetDataRecords(null, tb_ShopOrder.Text, int_ICID);
            }else {
                Records = Passrecord;
                ShouldWeAdd = true;
            }
                //Variables
                string DataRecords = "";
            bool TimerClosed = true;
            bool ItemHasData = false;



            //Loop though all results.
            int int_RowIndex = 0;
            foreach (DataRow Rows in Records.Rows) {
                DataTable Values = JsonConvert.DeserializeObject<DataTable>(Rows.Field<string>("Value"));
                string str_Values = "";
                foreach (DataRow ValueRow in Values.Rows) {
                    
                    ItemHasData = true;



                    //Check if it might need a clock icon
                    string str_Type = ValueRow.Field<string>("Type");
                    switch (str_Type.Trim().ToLower()) {

                        case "stop watch":
                        case "timer": {

                            str_Values = str_Values + ValueRow.Field<string>("Value") + ", ";

                            //We only need the top most row.
                            if (int_RowIndex == 0) {
                                //Get all Extra Data
                                DataTable ExtraValues = JsonConvert.DeserializeObject<DataTable>(ValueRow.Field<string>("Extra"));

                                foreach (DataRow ExtraRows in ExtraValues.Rows) {
                                    if (string.IsNullOrWhiteSpace(ExtraRows.Field<string>("Start")) || string.IsNullOrWhiteSpace(ExtraRows.Field<string>("End"))) {
                                        TimerClosed = false;
                                    }
                                }
                            }
                        }
                        break;
                        case "chemical": {
                            //Get all Extra Data
                            DataTable ExtraValues = JsonConvert.DeserializeObject<DataTable>(ValueRow.Field<string>("Value"));

                            foreach (DataRow ExtraRows in ExtraValues.Rows) {
                                str_Values = str_Values + string.Format("{0}, {1}, {2}", ExtraRows.Field<string>("PN"), ExtraRows.Field<string>("LOT"), ExtraRows.Field<string>("Exp"));
                            }

                        }
                        break;


                        default: {
                            //Get all Extra Data
                            
                                str_Values = str_Values + ValueRow.Field<string>("Value")+", ";
                           

                        }
                        break;
                    }

                }
                DataRecords = DataRecords + string.Format("Value: {0}", str_Values + Environment.NewLine);
                int_RowIndex++;
            }

            //Set Values box
            int BoxSize = dgv_Main.Rows[RowIndex].Height-5;
            Bitmap IconSet = new Bitmap(1,1);
            if (ItemHasData) {
                dgv_Main.Rows[RowIndex].Cells[dgv_Main_Closed.Index].Value = true;
                if (TimerClosed) {
                    IconSet = Properties.Resources.GreenCheck;

                } else {
                    IconSet = Properties.Resources.Timer;
                    //Almost gotem. If there is an open timer we need to close it out.
                    dgv_Main.Rows[RowIndex].Cells[dgv_Main_Closed.Index].Value = false;
                }


                
                dgv_Main.Rows[RowIndex].Cells[dgv_Image_Value.Index].ToolTipText = DataRecords;

            } else {
                IconSet = Properties.Resources.RedX;
            }

                dgv_Main.Rows[RowIndex].Cells[dgv_Image_Value.Index].Value = Resize(IconSet, BoxSize, BoxSize);


        }

        private void ts_editGroups_Click(object sender, EventArgs e) {
            new Support.EditGroups().ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e) {
            ss_Version.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            ss_User.Text = Environment.UserName;

            SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS);

        }

        private void tb_ShopOrder_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode.Equals(Keys.Enter)) {
                btn_Search_Click(null, EventArgs.Empty);
            }
            }

        private void btn_Sync_Click(object sender, EventArgs e) {


            Thread thread1 = new Thread(new ThreadStart(DoSync));
            thread1.Start();



        }

        private void DoSync() {
            try {

                DataTools.DataMaster.UpsertClockingLog(GUID_Beat, tb_ShopOrder.Text, ss_User.Text, DateTime.UtcNow.ToString(), DateTime.UtcNow.ToString());


                if (!string.IsNullOrWhiteSpace(tb_ShopOrder.Text)) {

                    List<Int64> InspectionCriteriaID = new List<Int64>();

                    foreach (DataGridViewRow RowsMain in dgv_Main.Rows) {
                        string str_ICID = (RowsMain.Cells[dgv_Main_ICID.Index].Value ?? "0").ToString();
                        InspectionCriteriaID.Add(Convert.ToInt64(str_ICID));
                    }


                    if (InspectionCriteriaID.Count > 0) {
                        DataTable Records = DataTools.DataMaster.GetInspCriteria_DataPointID_Bulk(InspectionCriteriaID);
                        DataTable Values = DataTools.DataMaster.GetDataRecords(null, tb_ShopOrder.Text, null);

                        //Find the spcific row in the data Table that matches
                        int int_RowIndexDGV = 0;
                        foreach (DataGridViewRow DGV_Row in dgv_Main.Rows) {

                            string str_ICID = (DGV_Row.Cells["dgv_Main_ICID"].Value ?? "0").ToString();

                            //Parse though the Records
                            foreach (DataRow Row in Records.Rows) {
                                if (str_ICID == Row.Field<Int64?>("DataPointID").ToString()) {
                                    DGV_Row.Cells["dgv_tb_Name"].Value = Row.Field<string>("DataPointName");
                                    DGV_Row.Cells["dgv_tb_Name"].ToolTipText = Row.Field<string>("Description");

                                    DGV_Row.Cells["dgv_tb_User"].Value = Row.Field<string>("UserType");
                                    DGV_Row.Cells["dgv_cb_Mandatory"].Value = Convert.ToBoolean(Row.Field<Int64?>("Mandatory") ?? 0);
                                    DGV_Row.Cells[dgv_tb_DocID.Index].Value = Row.Field<Int64?>("DocID") ?? 0;
                                    DGV_Row.Cells[dgv_tb_Position.Index].Value = Row.Field<string>("DocPosition");


                                }

                            }

                            //Parse Though the Values

                            // Use the Select method to find all rows matching the filter.
                            string expression = "DataPointID = " + str_ICID;
                            DataRow[] foundRows = Values.Select(expression, "Rec_ID DESC");
                            DataTable TempValue = Values.Clone();

                            foreach (DataRow FoundRowData in foundRows) {
                                TempValue.ImportRow(FoundRowData);
                            }

                            UpdateMainValue(int_RowIndexDGV, Convert.ToInt64(str_ICID), TempValue);

                            int_RowIndexDGV++;

                        }
                    }
                }
            } finally {

                ss_LasSync.Text = DateTime.Now.ToString("HH:mm:ss");
            
            }
        }

        private void timer_Refresh_Tick(object sender, EventArgs e) {

            if (!ts_EditPoints.Checked) {

                PowerStatus pwr = SystemInformation.PowerStatus;




                Thread thread1 = new Thread(new ThreadStart(DoSync));
                thread1.Start();

                float strBatterylife = pwr.BatteryLifePercent;
                ts_Battery.Text = (strBatterylife * 100).ToString() + "%";

                if (strBatterylife < .80) {
                    MessageBox.Show("The computer battery is critical at " + ts_Battery.Text + ".", "Charger Request", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void ts_CreateTable_Click(object sender, EventArgs e) {
            DataTools.BlankSQlite.CreateDB();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e) {
            //Night time pill!
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
        }

        private void btn_SaveAll_Click(object sender, EventArgs e) {

            //Let loop though all of the rows and save the Order and the position. 
            foreach(DataGridViewRow MainRow in dgv_Main.Rows) {

                Int64 OrderNumber = MainRow.Index;

                Int64 OrderICID = Convert.ToInt64(MainRow.Cells[dgv_tb_OrderID.Index].Value ?? 0);
                Int64 ICID = Convert.ToInt64(MainRow.Cells[dgv_Main_ICID.Index].Value ?? 0);
                if (ICID != 0 && OrderICID != 0) {
                    Int64 DocID = Convert.ToInt64(MainRow.Cells[dgv_tb_DocID.Index].Value ?? 0);
                    string Position = (MainRow.Cells[dgv_tb_Position.Index].Value ?? "").ToString();


                    DataTools.DataMaster.UpdateInspCriteria(ICID, null, null, null, null, null, DocID, Position);

                    DataTools.DataMaster.UpdateOrderInspPN(OrderICID, null, null, null, null, OrderNumber);


                    MainRow.DefaultCellStyle.BackColor = Color.LightGreen;

                }
            }






        }
    }
}
