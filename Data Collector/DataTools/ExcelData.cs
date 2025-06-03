using ClosedXML.Excel;
using Data_Collector.Engineering;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Collector.DataTools
{
    class ExcelData
    {

        public static bool CreateFinialOutput(DataGridView RawData,string ShopOrder,string PartNumber, string Rev) {





            //Create Blank Table for Data Input
            DataTable table = new DataTable();
            table.Columns.Add("ICID");
            table.Columns.Add("Name");
            table.Columns.Add("User Type");
            table.Columns.Add("Type");
            table.Columns.Add("Record ID");
            table.Columns.Add("Date Collected (UTC)");
            table.Columns.Add("User Name");
            table.Columns.Add("Value");



            foreach (DataGridViewRow MainRows in RawData.Rows) {

                string ICID = MainRows.Cells["dgv_Main_ICID"].Value.ToString();
                string Name = MainRows.Cells["dgv_Main_Name"].Value.ToString();
                string UserType = MainRows.Cells["dgv_Main_UserType"].Value.ToString();
                string Type = "Missing";
                Int64 RecordID = -1;
                string RecDateTime = "Missing";
                string User_ID = "Missing";
                string Value = "Missing";
                string ExtraInfo = "";



                //Get For info from the ICID number
                DataTable GotDetailsIC = DataTools.DataMaster.GetInspCriteria(Convert.ToInt64(ICID));

                if (GotDetailsIC.Rows.Count > 0) {
                    Type = GotDetailsIC.Rows[0].Field<string>("Type");
                }

                DataTable GotRecords = DataTools.DataMaster.GetDataRecords(null, ShopOrder, Convert.ToInt64(ICID));

                //Populate a missing data row.
                if (GotRecords.Rows.Count == 0) {
                    table.Rows.Add(ICID, Name, UserType, Type, RecordID, RecDateTime, User_ID, Value);
                }

                int RowsCounter = 0;
                foreach (DataRow ValueRow in GotRecords.Rows) {

                    string Hidden= ValueRow.Field<string>("Hidden");

                    if (string.IsNullOrWhiteSpace(Hidden)) {



                        RecordID = ValueRow.Field<Int64>("Rec_ID");
                        RecDateTime = ValueRow.Field<string>("DateTime UTC");
                        User_ID = ValueRow.Field<string>("User_ID");
                        Value = "";


                        //Lets look at the data a bit and if it is one of the specail formats below lets format it better
                        DataTable Values = JsonConvert.DeserializeObject<DataTable>(ValueRow.Field<string>("Value"));

                        if (Values.Rows.Count > 0) {

                            //Depending on the type lets format the value so it is human readable. 
                            switch (Values.Rows[0].Field<string>("Type").ToLower()) {

                                case "acknowledge":
                                case "chemical": {

                                    Value = Values.Rows[0].Field<string>("Value");


                                    table.Rows.Add(ICID, Name, UserType, Type, RecordID, RecDateTime, User_ID, Value);
                                }
                                break;

                                case "stop watch":
                                case "timer": {

                                    foreach (DataRow ValueRows in Values.Rows) {
                                        DataTable ExtraData = JsonConvert.DeserializeObject<DataTable>(ValueRows.Field<string>("Extra"));


                                        Value = Value + ExtraData.Rows[0].Field<string>("Name") + " " + ValueRows.Field<string>("Value") + System.Environment.NewLine;
                                    }


                                    Value = Value.TrimEnd('\n').TrimEnd('\r').TrimEnd('\n');

                                    if (RowsCounter == 0) {

                                        table.Rows.Add(ICID, Name, UserType, Type, RecordID, RecDateTime, User_ID, Value);
                                    }
                                }
                                break;


                                default: {


                                    foreach (DataRow ValueRows in Values.Rows) {
                                        Value = Value + ValueRows.Field<string>("Value") + System.Environment.NewLine;
                                    }


                                    Value = Value.TrimEnd('\n').TrimEnd('\r').TrimEnd('\n');
                                    table.Rows.Add(ICID, Name, UserType, Type, RecordID, RecDateTime, User_ID, Value);
                                }
                                break;
                            }


                            RowsCounter++;

                        }


                    }

                }
            }
            

            string FileName = string.Format("{0}_{1}_{2}_{3}.xlsx", ShopOrder, PartNumber, Rev, DateTime.UtcNow.ToString("yyyy-MM-dd HHmm"));

            string obtain_value = System.Configuration.ConfigurationManager.AppSettings["DefaultRootFoder"];

            if (string.IsNullOrWhiteSpace(obtain_value)) {
                obtain_value = AppContext.BaseDirectory;


            }

            if (!Directory.Exists(obtain_value + "Data\\")) {
                Directory.CreateDirectory(obtain_value + "Data\\");
            }

            string FullPath = obtain_value + @"Data\Report\" + FileName;

            if (!Directory.Exists(obtain_value + @"Data\Report")) {
                Directory.CreateDirectory(obtain_value + @"Data\Report");
            }

            


            XLWorkbook workbook = new XLWorkbook();
            workbook.Worksheets.Add(table, ShopOrder).Columns("A", "H").AdjustToContents();
            workbook.Worksheets.Add(DataTools.DataMaster.GetClockingLog(null,ShopOrder), "Clocking Log").Columns("A", "F").AdjustToContents();
            try {
                workbook.SaveAs(FullPath);
                if (File.Exists(FullPath)) {
                    using (Process process = new Process()) {
                        process.StartInfo.FileName = FullPath;
                        process.StartInfo.UseShellExecute = true;
                        process.Start();
                    }
                }
            } catch (Exception exception1) {
                MessageBox.Show(exception1.Message);
            }




            return true;

        }




    }
}
