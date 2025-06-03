//using DocumentFormat.OpenXml.Drawing.Charts;
//using DocumentFormat.OpenXml.Drawing.Spreadsheet;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Collector.DataTools {
    class QualityData {


        private static SqliteConnection CreateConnection() {

            /*
            string LocalFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Digital Data Collector";

            IniFile MyIni = new IniFile(@LocalFolder + @"\Settings.ini");
            string obtain_value = MyIni.Read("RootFoder");


            if (string.IsNullOrWhiteSpace(obtain_value)) {


                // Show the FolderBrowserDialog.
                System.Windows.Forms.FolderBrowserDialog FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();

                DialogResult result = FolderBrowser.ShowDialog();
                if (result == DialogResult.OK) {
                    obtain_value = FolderBrowser.SelectedPath;


                    MyIni.Write("RootFoder", obtain_value);

                }


            }
            */

            string obtain_value = System.Configuration.ConfigurationManager.AppSettings["DefaultRootFoder"];

            if (string.IsNullOrWhiteSpace(obtain_value)) {
                obtain_value = AppContext.BaseDirectory;
            }



            //string obtain_value = System.Configuration.ConfigurationManager.AppSettings["DataBaseRemote"];

            SqliteConnection connection = new SqliteConnection("Data Source='" + obtain_value + "Data\\Quality.db';") {
                DefaultTimeout = 5
            };
            try {
                connection.Open();
            } catch (Exception) {
            }
            return connection;
        }

        public static DataTable GetUniqueNCR_NCRStartWith(string NCR ) {


            DataTable tempTable = new DataTable();
            try {

                using (SqliteConnection connection = CreateConnection()) {


                    using (SqliteCommand command = new SqliteCommand("SELECT * FROM [UniqueNCR] WHERE [NCR] LIKE @p_NCR ORDER BY [NCR] DESC;", connection)) {
                        command.Connection = connection;

                        command.Parameters.AddWithValue("@p_NCR", NCR+ "%");

                        tempTable.Load(command.ExecuteReader());
                    }
                }
            } catch { }

            return tempTable;
        }

        public static DataTable GetUniqueNCR(DataTable InputData) {


            DataTable tempTable = new DataTable();
            try {

                using (SqliteConnection connection = CreateConnection()) {

                    string Where = "";

                    //Check if the string "fake binary" is a 1 = True. If True we are looking for a null value else dothe normal check (if null dot look for it.)
                    foreach (DataRow InputRow in InputData.Rows) {
                        string ColName = InputRow.Field<string>("Name");
                        string ValueStr = InputRow.Field<string>("ValueStr");
                        Int64? ValueInt = InputRow.Field<Int64?>("ValueInt");
                        byte[] ValueByte = InputRow.Field<byte[]>("ValueByte");
                        bool Null = InputRow.Field<bool>("Null");

                        if (Null == true) {
                            //Ignore all values and set it null
                            Where = Where + "[" + ColName + "]=NULL AND ";
                        } else {
                            if (ValueStr != null || ValueInt != null || ValueByte != null) {
                                Where = Where + "[" + ColName + "]=@p_" + ColName + " AND ";
                            }
                        }
                    }


                    if (Where.Length != 0) {
                        Where = Where.Substring(0, Where.Length - 4);

                        Where = "WHERE " + Where;

                    }


                    using (SqliteCommand command = new SqliteCommand(string.Format("SELECT * FROM [UniqueNCR] {0} ORDER BY [NCR] ASC;", Where), connection)) {
                        command.Connection = connection;

                        foreach (DataRow InputRow in InputData.Rows) {
                            string ColName = InputRow.Field<string>("Name");
                            string ValueStr = InputRow.Field<string>("ValueStr");
                            Int64? ValueInt = InputRow.Field<Int64?>("ValueInt");
                            byte[] ValueByte = InputRow.Field<byte[]>("ValueByte");
                            bool Null = InputRow.Field<bool>("Null");

                            if (ValueStr != null) {
                                command.Parameters.AddWithValue("@p_" + ColName, ValueStr);
                            } else if (ValueInt != null) {
                                command.Parameters.AddWithValue("@p_" + ColName, ValueInt);
                            } else if (ValueByte != null) {
                                command.Parameters.AddWithValue("@p_" + ColName, ValueByte);
                            }

                        }



                        tempTable.Load(command.ExecuteReader());
                    }
                }
            } catch { }

            return tempTable;
        }




        public static void UpsertUniqueNCR(DataTable InputData) {

            string InsertCols = "";
            string InsertVals = "";
            string Set = "";


            //Check if the string "fake binary" is a 1 = True. If True we are looking for a null value else dothe normal check (if null dot look for it.)
            foreach(DataRow InputRow in InputData.Rows) {
                string ColName = InputRow.Field<string>("Name");
                string ValueStr = InputRow.Field<string>("ValueStr");
                Int64? ValueInt = InputRow.Field<Int64?>("ValueInt");
                byte[] ValueByte = InputRow.Field<byte[]>("ValueByte");
                bool Null = InputRow.Field<bool>("Null");

                if (Null == true) {
                    //Ignore all values and set it null
                    InsertCols = InsertCols + "["+ ColName + "],";
                    InsertVals = InsertVals + "NULL,";
                    Set = Set + "[" + ColName + "]=NULL,";
                } else {
                    if (ValueStr!=null || ValueInt != null || ValueByte != null) {
                        InsertCols = InsertCols + "[" + ColName + "],";
                        InsertVals = InsertVals + "@p_"+ ColName + ",";
                        Set = Set + "[" + ColName + "]=@p_" + ColName + ",";
                    }
                }
            }


            //Take off the last char at the end. 
            if (InsertCols.Length != 0) {
                InsertCols = InsertCols.Substring(0, InsertCols.Length - 1);
            }
            if (InsertVals.Length != 0) {
                InsertVals = InsertVals.Substring(0, InsertVals.Length - 1);
            }
            if (Set.Length != 0) {
                Set = Set.Substring(0, Set.Length - 1);
            }



            string strConn = string.Format("INSERT INTO [UniqueNCR] ({0})" +
                        "VALUES({1})" +
                        "ON CONFLICT([NCR]) " +
                        "DO " +
                        "UPDATE SET {2} " +
                        "WHERE [NCR]=@p_NCR;", InsertCols, InsertVals, Set);




            DataTable table1 = new DataTable();
            try {
                using (SqliteConnection connection = CreateConnection()) {
                    using (SqliteCommand command = new SqliteCommand(strConn, connection)) {
                        command.Connection = connection;

                        foreach (DataRow InputRow in InputData.Rows) {
                            string ColName = InputRow.Field<string>("Name");
                            string ValueStr = InputRow.Field<string>("ValueStr");
                            Int64? ValueInt = InputRow.Field<Int64?>("ValueInt");
                            byte[] ValueByte = InputRow.Field<byte[]>("ValueByte");
                            bool Null = InputRow.Field<bool>("Null");

                            if (ValueStr != null) {
                                command.Parameters.AddWithValue("@p_" + ColName, ValueStr);
                            }else if (ValueInt != null) {
                                command.Parameters.AddWithValue("@p_" + ColName, ValueInt);
                            }else if (ValueByte != null) {
                                command.Parameters.AddWithValue("@p_" + ColName, ValueByte);
                            }

                        }

                        command.ExecuteNonQuery();
                    }
                }
            } catch { }
        }



    }
}
