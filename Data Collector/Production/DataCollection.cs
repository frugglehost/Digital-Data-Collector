using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    if (Row.Cells[0].Value.ToString() == "Stop") {
                        DateTime StartTime = Convert.ToDateTime(Row.Cells[dgv_timer_Start.Index].Value.ToString());
                        Row.Cells[dgv_Timer_Left.Index].Value = Math.Round(Convert.ToDouble(Row.Cells[dgv_Timer_Durration.Index].Value.ToString()) - (CurrentTime - StartTime).TotalMinutes, 2);
                    }
                }

                //Count up Timers

                foreach (DataGridViewRow Row in dgv_Stopwatch.Rows) {

                    if (Row.Cells[0].Value.ToString() == "Stop") {
                        DateTime StartTime = Convert.ToDateTime(Row.Cells[dgv_Stopwatch_Start.Index].Value);
                        TimeSpan TimeBetween = CurrentTime - StartTime;
                        Row.Cells[dgv_Stopwatch_Duration.Index].Value = TimeBetween.ToString("mm':'ss");
                    }

                    
                }


            } catch {
                //safety net if something fails. (Potental collision between timer and start stop)
                //No need to warn the end user. All times are deltas bettween a start stop. Puch button will do the finial calculation. 
            }



        }

        private void btn_Save_Click(object sender, EventArgs e) {

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

            tab_Control_SelectedIndexChanged(this, EventArgs.Empty);


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
                    UserInput.Columns.Add("PN");
                    UserInput.Columns.Add("LOT");
                    UserInput.Columns.Add("Exp");

                    Chemicals.Rows.Add(tb_PN.Text, tb_Lot.Text, dtp_Exp.Value.ToString("yyyy-mm-dd"));

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
                    UserInput.Rows.Add(str_Type, cob_ToolNumber.Text + " - "+cob_SerialNum.Text, tb_MagicInput.Text);
                }
                break;
                case "text": {
                    UserInput.Rows.Add(str_Type, tbr_FreeText.Text, tb_MagicInput.Text);
                }
                break;
                case "timer": {
                    foreach (DataGridViewRow row in dgv_Timer.Rows) {
                        UserInput.Rows.Add(str_Type, row.Cells[dgv_Timer_Left.Index].Value, tb_MagicInput.Text, string.Format("ID: {0}, Start: {1}, End: {2}", row.Index, row.Cells[dgv_timer_Start.Index].Value, row.Cells[dgv_timer_End.Index].Value));
                    }
                }
                break;
                case "stop watch": {
                    foreach (DataGridViewRow row in dgv_Stopwatch.Rows) {
                        UserInput.Rows.Add(str_Type, row.Cells[dgv_Stopwatch_Duration.Index].Value, tb_MagicInput.Text, string.Format("ID: {0}, Start: {1}, End: {2}", row.Index, row.Cells[dgv_Stopwatch_Start.Index].Value, row.Cells[dgv_Stopwatch_Stop.Index].Value));
                    }
                }
                break;
                case "file": {
                    foreach (DataGridViewRow row in dgv_File.Rows) {
                        UserInput.Rows.Add(str_Type, row.Cells[dgv_File_Name.Index].Value, tb_MagicInput.Text, row.Cells[dgv_File_Path.Index].Value);
                    }
                }
                break;




            }

            //Loop through the collections and format it for DB upload.

            str_Value = JsonConvert.SerializeObject(UserInput, Formatting.None);







        }

        private void btn_BadgeAdd_Click(object sender, EventArgs e) {
            dgv_Badge.Rows.Add();
        }

        private void btn_Timer_Click(object sender, EventArgs e) {
            dgv_Timer.Rows.Add("Start", "", 90, "", "Reset");
        }

        private void dgv_Timer_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == 0) {
                //We pressed the button.
                int int_Row = e.RowIndex;
                if (dgv_Timer.Rows[int_Row].Cells[dgv_Timer_StartStop.Index].Value == "Start") {
                    dgv_Timer.Rows[int_Row].Cells[dgv_timer_Start.Index].Value = DateTime.UtcNow.ToString();
                    dgv_Timer.Rows[int_Row].Cells[dgv_Timer_StartStop.Index].Value = "Stop";
                } else {
                    DateTime CurrentTime = DateTime.UtcNow;
                    


                    dgv_Timer.Rows[int_Row].Cells[dgv_timer_End.Index].Value = CurrentTime.ToString();
                    DateTime StartTime = Convert.ToDateTime(dgv_Timer.Rows[int_Row].Cells[dgv_timer_Start.Index].Value);

                    double TimeBetween = Math.Round(Convert.ToDouble(dgv_Timer.Rows[int_Row].Cells[dgv_Timer_Durration.Index].Value.ToString()) - (CurrentTime - StartTime).TotalMinutes, 2);
                    dgv_Timer.Rows[int_Row].Cells[dgv_Timer_Left.Index].Value = TimeBetween;
                    if (TimeBetween < 0) {
                        dgv_Timer.Rows[int_Row].Cells[dgv_Timer_Left.Index].Style.BackColor = Color.Red;
                    } else {
                        dgv_Timer.Rows[int_Row].Cells[dgv_Timer_Left.Index].Style.BackColor = Color.LightGreen;
                    }

                    dgv_Timer.Rows[int_Row].Cells[dgv_Timer_StartStop.Index].Value = "Start";
                }
            }
        }

        private void btn_StopwatchAdd_Click(object sender, EventArgs e) {
            dgv_Stopwatch.Rows.Add("Start", "", "00:00", "Reset");
        }

        private void dgv_Stopwatch_CellContentClick(object sender, DataGridViewCellEventArgs e) {

            if (e.ColumnIndex == 0) {
                int int_Row = e.RowIndex;

                if (dgv_Stopwatch.Rows[int_Row].Cells[dgv_Stopwatch_Action.Index].Value == "Start") {
                    dgv_Stopwatch.Rows[int_Row].Cells[dgv_Stopwatch_Start.Index].Value = DateTime.UtcNow.ToString();
                    dgv_Stopwatch.Rows[int_Row].Cells[dgv_Stopwatch_Action.Index].Value = "Stop";

                } else {
                    DateTime CurrentTime = DateTime.UtcNow;



                    dgv_Stopwatch.Rows[int_Row].Cells[dgv_Stopwatch_Stop.Index].Value = CurrentTime.ToString();

                    DateTime StartTime = Convert.ToDateTime(dgv_Stopwatch.Rows[int_Row].Cells[dgv_Stopwatch_Start.Index].Value);

                    TimeSpan TimeBetween = CurrentTime - StartTime;

                    dgv_Stopwatch.Rows[int_Row].Cells[dgv_Stopwatch_Duration.Index].Value = TimeBetween.ToString("mm':'ss");
                    dgv_Stopwatch.Rows[int_Row].Cells[dgv_Stopwatch_Duration.Index].Style.BackColor = Color.LightGreen;


                    dgv_Stopwatch.Rows[int_Row].Cells[dgv_Stopwatch_Action.Index].Value = "Start";
                }

            }

        }
    }

}