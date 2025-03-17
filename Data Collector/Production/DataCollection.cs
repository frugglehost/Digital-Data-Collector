using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Data_Collector.Production {




    public partial class DataCollection : Form {


        public DataCollection(string ICID, string ShopOrder) {
            InitializeComponent();

            dtp_FullTime.Value = DateTime.Now;

            tb_ICID.Text = ICID;
            tb_ShopOrder.Text = ShopOrder;


        }

        private void timer1_Tick(object sender, EventArgs e) {

            try {
                DateTime CurrentTime = DateTime.UtcNow;
                textBox1.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                //Count down timers
                foreach (DataGridViewRow Row in dgv_Timer.Rows) {
                    if (Row.Cells[dgv_Timer_Action.Index].Value.ToString() == "Stop" && Row.Cells[dgv_Timer_Pause.Index].Value.ToString() == "Pause") {
                        DateTime StartTime = Convert.ToDateTime(Row.Cells[dgv_timer_Start.Index].Value.ToString());
                        double Offset = Convert.ToDouble(Row.Cells[dgv_Timer_Offset.Index].Value ?? 0);

                        Row.Cells[dgv_Timer_Left.Index].Value = Math.Round(Convert.ToDouble(Row.Cells[dgv_Timer_Durration.Index].Value.ToString()) - (CurrentTime - StartTime).TotalMinutes + Offset, 2);
                    }
                }

                //Count up Timers

                foreach (DataGridViewRow Row in dgv_Stopwatch.Rows) {

                    if (Row.Cells[dgv_Stopwatch_Action.Index].Value.ToString() == "Stop" && Row.Cells[dgv_Stopwatch_Pause.Index].Value.ToString() == "Pause") {
                        double Offset = Convert.ToDouble(Row.Cells[dgv_StopWatch_Offset.Index].Value ?? 0);
                        DateTime StartTime = Convert.ToDateTime(Row.Cells[dgv_Stopwatch_Start.Index].Value);
                        TimeSpan TimeBetween = CurrentTime - StartTime.AddSeconds(Offset);

                        string sign = TimeBetween.Ticks < 0 ? "-" : "+";
                        

                        Row.Cells[dgv_Stopwatch_Duration.Index].Value = sign+TimeBetween.ToString("mm':'ss");
                    }


                }


            } catch {
                //safety net if something fails. (Potental collision between timer and start stop)
                //No need to warn the end user. All times are deltas bettween a start stop. Puch button will do the finial calculation. 
            }



        }

        private void btn_Save_Click(object sender, EventArgs e) {
            //Would be neat to see if the data is save able and then save it for the end user....


            this.Close();
        }

        private DataTable LoadHistory(Int64 int_ICID) {

            DataTable Records = DataTools.DataMaster.GetDataRecords(null, tb_ShopOrder.Text, int_ICID);

            string DataRecords = "";

            foreach (DataRow Rows in Records.Rows) {
                DataRecords = DataRecords + string.Format("ID: {0}, {1}, Value: {2}", Rows.Field<Int64>("Rec_ID"), Rows.Field<string>("User_ID"), Rows.Field<string>("Value") + Environment.NewLine);
            }
            tb_History.Text = DataRecords;

            return Records;
        }

        private void DataCollection_Load(object sender, EventArgs e) {
            //We have a loaded Form so lets go and fill it all in.

            Int64 int_ICID = Convert.ToInt64(tb_ICID.Text);

            DataTable DetailsICID = DataTools.DataMaster.GetInspCriteria_DataPointID(int_ICID);

            if (DetailsICID.Rows.Count > 0) {

                tb_Type.Text = DetailsICID.Rows[0].Field<string>("Type");
                tb_Name.Text = DetailsICID.Rows[0].Field<string>("DataPointName");
                tb_Description.Text = DetailsICID.Rows[0].Field<string>("Description");
                tb_UserType.Text = DetailsICID.Rows[0].Field<string>("UserType");
                tb_Format.Text = DetailsICID.Rows[0].Field<string>("Format");

            }


            DataTable Records = LoadHistory(int_ICID);



            DataTable Formats = JsonConvert.DeserializeObject<DataTable>(tb_Format.Text);

            if (Formats == null)
                Formats = new DataTable();

            //Auto fill any tables with special formats. 

            switch (tb_Type.Text.Trim().ToLower()) {

                case "acknowledge": {
                    //Do nothing
                }
                break;
                case "badge": {
                    //Do Noting
                }
                break;
                case "date/time": {
                    //Do Noting
                }
                break;
                case "date": {
                    //Do Noting
                }
                break;
                case "chemical": {
                    //Do Noting
                }
                break;
                case "number": {
                    foreach (DataRow NumberRows in Formats.Rows) {
                        dgv_Number.Rows.Add("", NumberRows.Field<string>("Mask"));
                    }
                }
                break;
                case "serial number": {
                    foreach (DataRow SerialRows in Formats.Rows) {
                        dgv_Serial.Rows.Add("", SerialRows.Field<string>("Mask"));
                    }
                }
                break;
                case "tool id": {

                }
                break;
                case "text": {

                }
                break;
                case "timer": {
                    //Fill in Eng added lines 
                    int rowNumber = 0;
                    foreach (DataRow TimerRows in Formats.Rows) {
                        dgv_Timer.Rows.Add("Start", TimerRows.Field<string>("Name"), TimerRows.Field<string>("Duration"));
                        dgv_Timer.Rows[rowNumber].Cells[dgv_Timer_Name.Index].ReadOnly = true;
                        dgv_Timer.Rows[rowNumber].Cells[dgv_Timer_Durration.Index].ReadOnly = true;
                        rowNumber++;
                    }

                    //Lets get old Data 
                    if (Records.Rows.Count > 0) {

                        DataTable Values = JsonConvert.DeserializeObject<DataTable>(Records.Rows[0].Field<string>("Value"));

                        int RowsIndex = 0;
                        int InitalRows = dgv_Timer.Rows.Count;
                        foreach (DataRow row in Values.Rows) {
                            string Name = "";
                            string Start = "";
                            string End = "";
                            double Duration = 0;
                            double Offset = 0;
                            double TimeBetween = 0;

                            DataTable TempData = JsonConvert.DeserializeObject<DataTable>(row.Field<string>("Extra"));

                            Name = TempData.Rows[0].Field<string>("Name");
                            Duration = Convert.ToDouble(TempData.Rows[0].Field<string>("Duration"));
                            Start = TempData.Rows[0].Field<string>("Start");
                            End = TempData.Rows[0].Field<string>("End");

                            string Status = (!string.IsNullOrWhiteSpace(Start) && string.IsNullOrWhiteSpace(End)) ? "Stop" : "Start";

                            //Edit Exisiting rows
                            if (InitalRows > RowsIndex + 1) {
                                Duration = Convert.ToDouble(dgv_Timer.Rows[RowsIndex].Cells[dgv_Timer_Durration.Index].Value);

                                //Lock existing cells.
                                dgv_Timer.Rows[RowsIndex].Cells[dgv_Timer_Name.Index].ReadOnly = true;
                                dgv_Timer.Rows[RowsIndex].Cells[dgv_Timer_Durration.Index].ReadOnly = true;
                            } else {

                                DateTime dat_Start = DateTime.UtcNow;
                                DateTime dat_End = DateTime.UtcNow;


                                DateTime.TryParse(Start, out dat_Start);
                                DateTime.TryParse(End, out dat_End);

                                if (dat_End==DateTime.MinValue)
                                    dat_End= DateTime.UtcNow;

                                //Add blank Row
                                dgv_Timer.Rows.Add();

                                TimeBetween = Math.Round(Duration - (dat_End - dat_Start).TotalMinutes, 2);

                                //Color code for a quick look.
                                if (!string.IsNullOrWhiteSpace(Start) && !string.IsNullOrWhiteSpace(End)) {

                                    
                                        dgv_Timer.Rows[RowsIndex].Cells[dgv_Timer_Left.Index].Style.BackColor = Color.LightGreen;
                                    
                                }

                            }

                            //Insert data into the row. 
                            dgv_Timer.Rows[RowsIndex].Cells[dgv_Timer_Action.Index].Value = Status;
                            dgv_Timer.Rows[RowsIndex].Cells[dgv_Timer_Name.Index].Value = Name;
                            dgv_Timer.Rows[RowsIndex].Cells[dgv_Timer_Durration.Index].Value = Duration;
                            dgv_Timer.Rows[RowsIndex].Cells[dgv_Timer_Left.Index].Value = TimeBetween;
                            dgv_Timer.Rows[RowsIndex].Cells[dgv_Timer_Pause.Index].Value = "Pause";
                            dgv_Timer.Rows[RowsIndex].Cells[dgv_timer_Start.Index].Value = Start;
                            dgv_Timer.Rows[RowsIndex].Cells[dgv_timer_End.Index].Value = End;
                            dgv_Timer.Rows[RowsIndex].Cells[dgv_Timer_Offset.Index].Value = Offset;

                            foreach (DataGridViewColumn Col in dgv_Timer.Columns) {

                                if (dgv_Timer.Rows[RowsIndex].Cells[Col.Name].Value == "") {
                                    dgv_Timer.Rows[RowsIndex].Cells[Col.Index].Value = null;
                                }

                            }





                            RowsIndex++;

                        }


                    }


                }
                break;
                case "stop watch": {

                    //Fill in Eng added lines 
                    int rowNumber = 0;
                    foreach (DataRow WatchRows in Formats.Rows) {
                        dgv_Stopwatch.Rows.Add("Start", WatchRows.Field<string>("Name"), WatchRows.Field<string>("Duration"));
                        dgv_Stopwatch.Rows[rowNumber].Cells[dgv_Timer_Name.Index].ReadOnly = true;
                        rowNumber++;
                    }

                    //Lets check old Data 
                    if (Records.Rows.Count > 0) {
                        //We have old data lets go and get to work. 
                        DataTable Values = JsonConvert.DeserializeObject<DataTable>(Records.Rows[0].Field<string>("Value"));

                        int RowsIndex = 0;
                        int InitalRows = dgv_Stopwatch.Rows.Count;
                        foreach (DataRow row in Values.Rows) {
                            string Name = "";
                            string Start = "";
                            string End = "";
                            string Duration = "";
                            string str_Offset = "";
                            double Offset = 0;
                            

                            DataTable TempData = JsonConvert.DeserializeObject<DataTable>(row.Field<string>("Extra"));

                            Name = TempData.Rows[0].Field<string>("Name");
                            Start = TempData.Rows[0].Field<string>("Start");
                            End = TempData.Rows[0].Field<string>("End");
                            str_Offset = TempData.Rows[0].Field<string>("Offset");

                            if (!string.IsNullOrWhiteSpace(str_Offset)) {
                                Offset = Convert.ToDouble(str_Offset);
                            }

                            string Status = (!string.IsNullOrWhiteSpace(Start) && string.IsNullOrWhiteSpace(End)) ? "Stop" : "Start";


                            DateTime dat_Start = DateTime.UtcNow;
                            DateTime dat_End = DateTime.UtcNow;
                            DateTime.TryParse(Start, out dat_Start);
                            DateTime.TryParse(End, out dat_End);
                            TimeSpan span_TimeBetween = dat_End - dat_Start.AddSeconds(Offset);
                            string sign = span_TimeBetween.Ticks < 0 ? "-" : "+";
                            Duration = sign+span_TimeBetween.ToString("mm':'ss");

                            //Edit Exisiting rows
                            if (InitalRows > RowsIndex + 1) {
                                //Do Something?

                            } else {
                                dgv_Stopwatch.Rows.Add();
                            }





                            //Insert data into the row. 
                            dgv_Stopwatch.Rows[RowsIndex].Cells[dgv_Stopwatch_Action.Index].Value = Status;
                            dgv_Stopwatch.Rows[RowsIndex].Cells[dgv_Stopwatch_Name.Index].Value = Name;
                            dgv_Stopwatch.Rows[RowsIndex].Cells[dgv_Stopwatch_Duration.Index].Value = Duration;
                            dgv_Stopwatch.Rows[RowsIndex].Cells[dgv_Stopwatch_Pause.Index].Value = "Pause";
                            dgv_Stopwatch.Rows[RowsIndex].Cells[dgv_Stopwatch_Start.Index].Value = Start;
                            dgv_Stopwatch.Rows[RowsIndex].Cells[dgv_Stopwatch_Stop.Index].Value = End;
                            dgv_Stopwatch.Rows[RowsIndex].Cells[dgv_StopWatch_Offset.Index].Value = Offset;

                            foreach (DataGridViewColumn Col in dgv_Stopwatch.Columns) {

                                if (dgv_Stopwatch.Rows[RowsIndex].Cells[Col.Name].Value=="") {
                                    dgv_Stopwatch.Rows[RowsIndex].Cells[Col.Index].Value = null;
                                }

                            }



                            RowsIndex++;
                        }


                        


                    }







                    }
                break;
                case "file": {
                    foreach (DataRow Rows in Formats.Rows) {
                        dgv_File.Rows.Add("Edit", Rows.Field<string>("Name"),null,null, Rows.Field<string>("SavePath"));
                    }




                    //Lets check old Data 
                    if (Records.Rows.Count > 0) {
                        //We have old data lets go and get to work. 
                        DataTable Values = JsonConvert.DeserializeObject<DataTable>(Records.Rows[0].Field<string>("Value"));

                        int RowsIndex = 0;
                        int InitalRows = dgv_Stopwatch.Rows.Count;
                        foreach (DataRow row in Values.Rows) {
                            string Name = "";
                            string FileName = "";
                            string Path = "";
                            string SaveTo = "";
                            string Local = "";

                            DataTable TempData = JsonConvert.DeserializeObject<DataTable>(row.Field<string>("Extra"));

                            foreach(DataRow ExtraRows in TempData.Rows) {

                                Name = ExtraRows.Field<string>("Name");
                                FileName = ExtraRows.Field<string>("FileName");
                                Path = ExtraRows.Field<string>("Path");
                                Local = ExtraRows.Field<string>("Local");



                            }

                            





                            //Edit Exisiting rows
                            if (InitalRows > RowsIndex + 1) {
                                //Do Something?

                                

                            } else {
                                dgv_File.Rows.Add();
                            }

                            //Insert data into the row. 
                            dgv_File.Rows[RowsIndex].Cells[dgv_File_Action.Index].Value = "Edit";
                            dgv_File.Rows[RowsIndex].Cells[dgv_File_Name.Index].Value = Name;
                            dgv_File.Rows[RowsIndex].Cells[dgv_File_FileName.Index].Value = FileName;
                            dgv_File.Rows[RowsIndex].Cells[dgv_File_Path.Index].Value = Path;
                            //dgv_File.Rows[RowsIndex].Cells[dgv_File_SaveTo.Index].Value = SaveTo;
                            dgv_File.Rows[RowsIndex].Cells[dgv_File_Local.Index].Value = Local;




                        }


                    }






                        }
                        break;
                default: {
                    //Do Noting
                }
                break;




            }








            tab_Control_SelectedIndexChanged(this, EventArgs.Empty);

            //Make it live baby 
            tb_MagicInput.Focus();
        }

        private void tab_Control_SelectedIndexChanged(object sender, EventArgs e) {

            string TabNames = tab_Control.SelectedTab.Name;

            /*
             * 
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


            switch (tb_Type.Text.Trim().ToLower()) {

                case "acknowledge":
                tab_Control.SelectTab(0);

                break;
                case "badge":
                tab_Control.SelectTab(6);

                break;
                case "date/time":
                tab_Control.SelectTab(1);

                break;
                case "date":
                tab_Control.SelectTab(1);

                break;
                case "chemical":
                tab_Control.SelectTab(2);

                break;
                case "number":
                tab_Control.SelectTab(3);

                break;
                case "serial number":
                tab_Control.SelectTab(4);

                break;
                case "tool id":
                tab_Control.SelectTab(5);

                break;
                case "text":
                tab_Control.SelectTab(10);

                break;
                case "timer":
                tab_Control.SelectTab(7);

                break;
                case "stop watch":
                tab_Control.SelectTab(8);

                break;
                case "file":
                tab_Control.SelectTab(9);

                break;
                default:
                // code block

                //Well someone messed up...


                break;




            }

            tb_MagicInput.Focus();
        }

        private void btn_Acknowledge_Click(object sender, EventArgs e) {
            tb_iAcknowledge.Text = Environment.UserName + " - " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm z");
        }

        private void btn_RecordTab_Click(object sender, EventArgs e) {

            //Get current tab Name
            string str_TabName = tab_Control.SelectedTab.Text.ToLower();

            //Gather Data that is static on the form.
            string str_ICID = tb_ICID.Text;
            string str_ShopOrder = tb_ShopOrder.Text;
            string str_Type = tb_Type.Text;
            string str_NTID = Environment.UserName;


            //Generate string for dynamic inputs.
            string str_Value = "";
            string str_GeneralUserInput = "";
            DataTable UserInput = new DataTable();
            UserInput.Columns.Add("Type");
            UserInput.Columns.Add("Value");
            UserInput.Columns.Add("UserInput");
            UserInput.Columns.Add("Extra");

            switch (tb_Type.Text.Trim().ToLower()) {

                case "acknowledge": {
                    UserInput.Rows.Add(str_Type, tb_iAcknowledge.Text, tb_MagicInput.Text);
                }
                break;
                case "badge": {
                    foreach (DataGridViewRow row in dgv_Badge.Rows) {
                        UserInput.Rows.Add(str_Type, row.Cells[dgv_Badge_NTID.Index].Value, tb_MagicInput.Text);
                    }
                }
                break;
                case "date/time": {
                    UserInput.Rows.Add(str_Type, dtp_FullTime.Value.ToString("yyyy-MM-dd HH:mm"), tb_MagicInput.Text);
                }
                break;
                case "date": {
                    UserInput.Rows.Add(str_Type, dtp_FullTime.Value.ToString("yyyy-MM-dd"), tb_MagicInput.Text);
                }
                break;
                case "chemical": {
                    DataTable Chemicals = new DataTable();
                    Chemicals.Columns.Add("PN");
                    Chemicals.Columns.Add("LOT");
                    Chemicals.Columns.Add("Exp");

                    Chemicals.Rows.Add(tb_chemPN.Text, tb_ChemLot.Text, dtp_ChemExp.Value.ToString("yyyy-MM-dd"));

                    UserInput.Rows.Add(str_Type, JsonConvert.SerializeObject(Chemicals, Formatting.None), tb_MagicInput.Text);

                }
                break;
                case "number": {
                    foreach (DataGridViewRow row in dgv_Number.Rows) {
                        UserInput.Rows.Add(str_Type, row.Cells[dgv_Number_Input.Index].Value, tb_MagicInput.Text);
                    }
                }
                break;
                case "serial number": {
                    foreach (DataGridViewRow row in dgv_Serial.Rows) {
                        UserInput.Rows.Add(str_Type, row.Cells[dgv_Number_Input.Index].Value, tb_MagicInput.Text);
                    }
                }
                break;
                case "tool id": {
                    UserInput.Rows.Add(str_Type, cob_ToolNumber.Text + " - " + cob_SerialNum.Text, tb_MagicInput.Text);
                }
                break;
                case "text": {
                    UserInput.Rows.Add(str_Type, tbr_FreeText.Text, tb_MagicInput.Text);
                }
                break;
                case "timer": {
                    foreach (DataGridViewRow row in dgv_Timer.Rows) {
                        DataTable TempData = new DataTable();
                        TempData.Columns.Add("Name");
                        TempData.Columns.Add("Duration");
                        TempData.Columns.Add("Start");
                        TempData.Columns.Add("End");
                        TempData.Columns.Add("Offset");

                        TempData.Rows.Add(row.Cells[dgv_Timer_Name.Index].Value, row.Cells[dgv_Timer_Durration.Index].Value, row.Cells[dgv_timer_Start.Index].Value ?? "", row.Cells[dgv_timer_End.Index].Value ?? "", row.Cells[dgv_Timer_Offset.Index].Value ?? "");

                        UserInput.Rows.Add(str_Type, row.Cells[dgv_Timer_Left.Index].Value, tb_MagicInput.Text, JsonConvert.SerializeObject(TempData, Formatting.None));
                    }
                }
                break;
                case "stop watch": {
                    foreach (DataGridViewRow row in dgv_Stopwatch.Rows) {

                        DataTable TempData = new DataTable();
                        TempData.Columns.Add("Name");
                        TempData.Columns.Add("Start");
                        TempData.Columns.Add("End");
                        TempData.Columns.Add("Offset");

                        TempData.Rows.Add(row.Cells[dgv_Stopwatch_Name.Index].Value, row.Cells[dgv_Stopwatch_Start.Index].Value ?? "", row.Cells[dgv_Stopwatch_Stop.Index].Value ?? "", row.Cells[dgv_StopWatch_Offset.Index].Value ?? "");


                        UserInput.Rows.Add(str_Type, row.Cells[dgv_Stopwatch_Duration.Index].Value, tb_MagicInput.Text, JsonConvert.SerializeObject(TempData, Formatting.None));
                    }
                }
                break;
                case "file": {
                    foreach (DataGridViewRow row in dgv_File.Rows) {
                        DataTable TempData = new DataTable();
                        TempData.Columns.Add("Name");
                        TempData.Columns.Add("FileName");
                        TempData.Columns.Add("Path");
                        TempData.Columns.Add("Local");

                        TempData.Rows.Add(row.Cells[dgv_File_Name.Index].Value, row.Cells[dgv_File_FileName.Index].Value ?? "", row.Cells[dgv_File_Path.Index].Value ?? "", row.Cells[dgv_File_Local.Index].Value ?? "");


                        UserInput.Rows.Add(str_Type, row.Cells[dgv_File_FileName.Index].Value, tb_MagicInput.Text, JsonConvert.SerializeObject(TempData, Formatting.None));
                    }
                }
                break;




            }

            //Loop through the collections and format it for DB upload.

            str_Value = JsonConvert.SerializeObject(UserInput, Formatting.None);

            DataTools.DataMaster.InsertDataRecords(str_ShopOrder, Convert.ToInt64(str_ICID), str_Value, str_NTID, DateTime.UtcNow.ToString());

            LoadHistory(Convert.ToInt64(str_ICID));



        }

        private void btn_BadgeAdd_Click(object sender, EventArgs e) {
            dgv_Badge.Rows.Add();
        }

        private void btn_Timer_Click(object sender, EventArgs e) {
            dgv_Timer.Rows.Add("Start", "", 90, null, "Pause");



        }

        private void dgv_Timer_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            //Grab the row refernece
            int int_Row = e.RowIndex;

            //Grab info that can be used multiple times. 
            DateTime CurrentTime = DateTime.UtcNow;
            string str_StartStop = dgv_Timer.Rows[int_Row].Cells[dgv_Timer_Action.Index].Value.ToString();
            string str_Pause = dgv_Timer.Rows[int_Row].Cells[dgv_Timer_Pause.Index].Value.ToString();

            if (e.ColumnIndex == dgv_Timer_Action.Index) {
                //We pressed the Start Stop button.

                if (str_StartStop == "Start") {
                    dgv_Timer.Rows[int_Row].Cells[dgv_timer_Start.Index].Value = CurrentTime.ToString();
                    dgv_Timer.Rows[int_Row].Cells[dgv_Timer_Action.Index].Value = "Stop";
                    dgv_Timer.Rows[int_Row].Cells[dgv_timer_End.Index].Value = null;
                    dgv_Timer.Rows[int_Row].Cells[dgv_Timer_Pause.Index].ReadOnly = false;
                } else {

                    //Run a Stop. Lock in the delta time and etc.
                    dgv_Timer.Rows[int_Row].Cells[dgv_timer_End.Index].Value = CurrentTime.ToString();
                    DateTime StartTime = Convert.ToDateTime(dgv_Timer.Rows[int_Row].Cells[dgv_timer_Start.Index].Value);

                    double Offset = Convert.ToDouble(dgv_Timer.Rows[int_Row].Cells[dgv_Timer_Offset.Index].Value ?? 0);

                    double TimeBetween = Math.Round(Convert.ToDouble(dgv_Timer.Rows[int_Row].Cells[dgv_Timer_Durration.Index].Value.ToString()) - (Convert.ToDateTime(dgv_Timer.Rows[int_Row].Cells[dgv_timer_End.Index].Value) - StartTime).TotalMinutes+Offset, 2);
                    dgv_Timer.Rows[int_Row].Cells[dgv_Timer_Left.Index].Value = TimeBetween;

                    dgv_Timer.Rows[int_Row].Cells[dgv_Timer_Left.Index].Style.BackColor = Color.LightGreen;


                    dgv_Timer.Rows[int_Row].Cells[dgv_Timer_Action.Index].Value = "Start";
                    dgv_Timer.Rows[int_Row].Cells[dgv_Timer_Pause.Index].ReadOnly = true;
                }

            }

            if (e.ColumnIndex == dgv_Timer_Pause.Index) {
                //We pressed the pause button button.




                if (str_Pause == "Pause") {
                    // We need to hold the count down.

                    //Save the difference from start to Now.
                    DateTime StartTime = Convert.ToDateTime(dgv_Timer.Rows[int_Row].Cells[dgv_timer_Start.Index].Value);
                    double Duration = Convert.ToDouble(dgv_Timer.Rows[int_Row].Cells[dgv_Timer_Durration.Index].Value.ToString());
                    double Remainning = Convert.ToDouble((dgv_Timer.Rows[int_Row].Cells[dgv_Timer_Left.Index].Value ?? 0).ToString());
                    double TimeBetween = Math.Round(Duration - (CurrentTime - StartTime).TotalMinutes, 2);

                    //why just why would you press pause if it is not running... I'm sure there is a better way but I gave up.
                    if (str_StartStop != "Start") {

                        dgv_Timer.Rows[int_Row].Cells[dgv_Timer_Offset.Index].Value = Remainning - Duration;


                        dgv_Timer.Rows[int_Row].Cells[dgv_Timer_Pause.Index].Value = "Continue";
                        btn_RecordTab.Enabled = false;
                        btn_Save.Enabled = false;
                    } else {
                        MessageBox.Show("Countdown has not started.");
                    }

                } else {
                    dgv_Timer.Rows[int_Row].Cells[dgv_timer_Start.Index].Value = CurrentTime;
                    dgv_Timer.Rows[int_Row].Cells[dgv_Timer_Pause.Index].Value = "Pause";

                    //Check if we have any Pauses. This is tough one. Maybe in the future we can keep all stop/stops add them up and we can use a pause Flag or similar in the stop field.
                    //This would allow for a save but for now we will take the easy route and block it off.
                    bool EnableButtons = true;
                    foreach (DataGridViewRow TempRows in dgv_Timer.Rows) {
                        if (TempRows.Cells[dgv_Timer_Pause.Index].Value == "Continue")
                            EnableButtons = false;
                    }
                    btn_RecordTab.Enabled = EnableButtons;
                    btn_Save.Enabled = EnableButtons;
                }



            }
        }

        private void btn_StopwatchAdd_Click(object sender, EventArgs e) {
            dgv_Stopwatch.Rows.Add("Start", "", "00:00", "Pause");
        }

        private void dgv_Stopwatch_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            //Row number Selected
            int int_Row = e.RowIndex;
            DateTime CurrentTime = DateTime.UtcNow;

            Double Offset = Convert.ToDouble(dgv_Stopwatch.Rows[int_Row].Cells[dgv_StopWatch_Offset.Index].Value ?? 0);

            string str_inialAction = dgv_Stopwatch.Rows[int_Row].Cells[dgv_Stopwatch_Action.Index].Value.ToString();
            string str_initalPause = dgv_Stopwatch.Rows[int_Row].Cells[dgv_Stopwatch_Pause.Index].Value.ToString();


            if (e.ColumnIndex == dgv_Stopwatch_Action.Index) {

                if (str_initalPause != "Continue") {
                    if (str_inialAction == "Start") {
                        dgv_Stopwatch.Rows[int_Row].Cells[dgv_Stopwatch_Start.Index].Value = DateTime.UtcNow.ToString();
                        dgv_Stopwatch.Rows[int_Row].Cells[dgv_Stopwatch_Action.Index].Value = "Stop";
                        dgv_Stopwatch.Rows[int_Row].Cells[dgv_Stopwatch_Stop.Index].Value = null;
                        dgv_Stopwatch.Rows[int_Row].Cells[dgv_StopWatch_Offset.Index].Value = null;
                        dgv_Stopwatch.Rows[int_Row].Cells[dgv_Stopwatch_Pause.Index].Value = "Pause";
                    } else {

                        dgv_Stopwatch.Rows[int_Row].Cells[dgv_Stopwatch_Stop.Index].Value = CurrentTime.ToString();

                        DateTime StartTime = Convert.ToDateTime(dgv_Stopwatch.Rows[int_Row].Cells[dgv_Stopwatch_Start.Index].Value);


                        TimeSpan CurrentDuration = Convert.ToDateTime(dgv_Stopwatch.Rows[int_Row].Cells[dgv_Stopwatch_Stop.Index].Value) - StartTime.AddSeconds(Offset);
                        string sign = CurrentDuration.Ticks < 0 ? "-" : "+";


                        dgv_Stopwatch.Rows[int_Row].Cells[dgv_Stopwatch_Duration.Index].Value = sign + CurrentDuration.ToString("mm':'ss");
                        dgv_Stopwatch.Rows[int_Row].Cells[dgv_Stopwatch_Duration.Index].Style.BackColor = Color.LightGreen;


                        dgv_Stopwatch.Rows[int_Row].Cells[dgv_Stopwatch_Action.Index].Value = "Start";
                    }
                } else {
                    MessageBox.Show("Timer is paused");
                }
            }

            if (e.ColumnIndex == dgv_Stopwatch_Pause.Index) {
                //They Pressed the pause Buton colum.

               

                //Record current values of row

                


                DateTime StartTime = Convert.ToDateTime(dgv_Stopwatch.Rows[int_Row].Cells[dgv_Stopwatch_Start.Index].Value);

                if (str_inialAction != "Start") {
                    if (str_initalPause == "Pause") {

                        TimeSpan CurrentDuration = CurrentTime - StartTime.AddSeconds(Offset);


                        dgv_Stopwatch.Rows[int_Row].Cells[dgv_StopWatch_Offset.Index].Value = (-Math.Round(CurrentDuration.TotalSeconds,0)).ToString();
                        dgv_Stopwatch.Rows[int_Row].Cells[dgv_Stopwatch_Pause.Index].Value = "Continue";
                    } else {


                        dgv_Stopwatch.Rows[int_Row].Cells[dgv_Stopwatch_Start.Index].Value = CurrentTime;
                        dgv_Stopwatch.Rows[int_Row].Cells[dgv_Stopwatch_Stop.Index].Value = null;


                        dgv_Stopwatch.Rows[int_Row].Cells[dgv_Stopwatch_Pause.Index].Value = "Pause";
                    }
                } else {
                    MessageBox.Show("Timer is not running");
                }

                


            }

        }

        private void tb_MagicInput_KeyDown(object sender, KeyEventArgs e) {

            if (e.KeyCode.Equals(Keys.Enter)) {
                e.SuppressKeyPress = true;
                if (tb_Type.Text == "Chemical") {
                    //Semi Static Variables
                    string str_MagicInput = this.tb_MagicInput.Text.Trim().ToUpper();
                    tb_MagicInput.Text = str_MagicInput;

                    //Define reused items to parse MagicInput
                    string SplitChar = ","; //Lets default to ","
                    long pos_PartNumber = 1L;
                    long pod_LotNumber = 2L;
                    long pos_DateExp = 3L;
                    string str_RawDateFormat = "yyyy-MM-dd"; //Default to KSA standards.
                    long int_AppendDaysCount = 0L;


                    //Defined values that are filled in the boxes.
                    string str_FinialPN;
                    string str_FinialLOT;
                    string str_FinialDate;
                    



                    string str_ChangePN = "";

                    bool bol_FoundBarcode = false;
                    foreach (DataRow row in DataTools.DataMaster.GetBarDecode().Rows) {
                        if (str_MagicInput.StartsWith(row.Field<string>("Contains"))) {
                            SplitChar = row.Field<string>("Delimiter");
                            pos_PartNumber = row.Field<long>("PN");
                            pod_LotNumber = row.Field<long>("Lot");
                            pos_DateExp = row.Field<long>("Date");
                            str_RawDateFormat = row.Field<string>("DateFormat");
                            str_ChangePN = row.Field<string>("PNOver");
                            int_AppendDaysCount = row.Field<long>("AddDays");

                            bol_FoundBarcode = true;
                        }
                    }
                    DialogResult WantToContinue = DialogResult.Yes;

                    if (!bol_FoundBarcode) {
                        //Dang it who made a new barcode.
                        WantToContinue = MessageBox.Show("Failed to mind a matching barcode format decorder.\n\nDo you want to use the default checker?", "Lookup Match Fail", MessageBoxButtons.YesNo);
                    }

                    if (WantToContinue != DialogResult.Yes) {
                        //Play it safe lets pull back focus on the magic input. 
                        tb_MagicInput.Focus();
                        tb_MagicInput.SelectAll();

                    } else {
                        //We are going to either use the default or the values found in the barcode DB.

                        char[] separator = new char[] { char.Parse(SplitChar) };
                        string[] arry_MagicInput = str_MagicInput.Split(separator);


                        //Lets get the PN
                        str_FinialPN = arry_MagicInput[(int)pos_PartNumber];

                        if (!string.IsNullOrWhiteSpace(str_ChangePN))
                            str_FinialPN = str_ChangePN;

                        

                        //Lets get the Lot/Batch Number
                        str_FinialLOT=arry_MagicInput[(int)pod_LotNumber];


                        //Lets get an exp date
                        string str_TempDate = arry_MagicInput[(int)pos_DateExp];
                        DateTime time_TempExpires;

                        if (DateTime.TryParseExact(str_TempDate, str_RawDateFormat, null, DateTimeStyles.None, out time_TempExpires)) {
                            time_TempExpires = time_TempExpires.AddDays((double)int_AppendDaysCount);
                        } else {
                            MessageBox.Show("Error: The date format does not look like " + str_RawDateFormat);
                            time_TempExpires = dtp_ChemExp.MinDate;
                        }
                        dtp_ChemExp.Value = time_TempExpires;
                        
                        



                        //Set the values for the end user. 
                        tb_chemPN.Text = str_FinialPN;
                        tb_ChemLot.Text = arry_MagicInput[(int)pod_LotNumber];

                        






                    }



                }




            }
        }

        private void dtp_ChemExp_ValueChanged(object sender, EventArgs e) {


            //Check if the date has expired or not. 
            if (dtp_ChemExp.Value.Date < DateTime.Now.Date) {
                btn_Save.Enabled = false;
                btn_RecordTab.Enabled = false;

                pic_ChemExp.Image = Properties.Resources.RedX;


            } else {
                btn_RecordTab.Enabled = true;
                btn_Save.Enabled = true;
                btn_Save.Focus();

                pic_ChemExp.Image = Properties.Resources.GreenCheck;
            }

        }

        private void btn_Reset_Click(object sender, EventArgs e) {
            tb_MagicInput.Text = "";
            tb_MagicInput.Focus();
        }

        private void brn_NumberAdd_Click(object sender, EventArgs e) {

            string str_Mask = "";
            if (!string.IsNullOrWhiteSpace(tb_Format.Text)){
                DataTable TempData = JsonConvert.DeserializeObject<DataTable>(tb_Format.Text);

                foreach(DataRow FormatRow in TempData.Rows) {
                    if (FormatRow.Field<bool>("Default")){
                        str_Mask = FormatRow.Field<string>("Mask");
                    }
                }
            }

            dgv_Number.Rows.Add("", str_Mask);
        }

        private void dgv_Number_CellLeave(object sender, DataGridViewCellEventArgs e) {

            if (e.ColumnIndex == dgv_Number_Input.Index) {
                // Instantiate the regular expression object.
                string pat = dgv_Number.Rows[e.RowIndex].Cells[dgv_Number_Mask.Index].Value.ToString();
                Regex r = new Regex(pat, RegexOptions.IgnoreCase);

                Match m = r.Match(dgv_Number.Rows[e.RowIndex].Cells[dgv_Number_Input.Index].Value.ToString());

                if (m.Success == true) {
                    //Great Job
                    string Input = dgv_Number.Rows[e.RowIndex].Cells[dgv_Number_Input.Index].Value.ToString();
                    if (Input == m.Value) {
                        //Perfect Match
                    } else {

                        DialogResult Messages = MessageBox.Show("The input does not exactly match the input.\n\n" + Input + " != " + m.Value + "\n\n Do you want to replace the text?", "Partial Missmatch", MessageBoxButtons.YesNo);

                        if (DialogResult.Yes== Messages) {

                            dgv_Number.Rows[e.RowIndex].Cells[dgv_Number_Input.Index].Value = m.Value;

                        }

                    }
                } else {
                    MessageBox.Show("Files Dont Match Pattern: " + pat);
                }

            }
        }

        private void btn_FileAdd_Click(object sender, EventArgs e) {
            dgv_File.Rows.Add("Edit");


        }

        private void dgv_File_CellContentClick(object sender, DataGridViewCellEventArgs e) {

            //Row number Selected
            int int_Row = e.RowIndex;
            int int_Col = e.ColumnIndex;


            if (int_Col == dgv_File_Action.Index) {
                //We clicked the button.



                if (ofd_File_Collection.ShowDialog() == DialogResult.OK) {

                    string PathLocalPC = ofd_File_Collection.FileName;
                    string PathToSave = (dgv_File.Rows[int_Row].Cells[dgv_File_SaveTo.Index].Value ?? "").ToString() ;

                    if (string.IsNullOrWhiteSpace(PathToSave)) {
                        if(fbd_SavePath.ShowDialog() == DialogResult.OK) {

                            PathToSave = fbd_SavePath.SelectedPath;

                        } else {
                            MessageBox.Show("Unable to select a folder.");
                            return;
                        }
                    }

                    string FiletoSave = PathToSave + "\\" + Path.GetFileName(PathLocalPC);
                    File.Copy(PathLocalPC, FiletoSave,true);



                    dgv_File.Rows[int_Row].Cells[dgv_File_Path.Index].Value = FiletoSave;
                    dgv_File.Rows[int_Row].Cells[dgv_File_FileName.Index].Value = Path.GetFileName(FiletoSave);
                    dgv_File.Rows[int_Row].Cells[dgv_File_SaveTo.Index].Value = PathToSave;
                    dgv_File.Rows[int_Row].Cells[dgv_File_Local.Index].Value = Environment.MachineName +"; "+ofd_File_Collection.FileName;


                }


            }









        }
    }
}