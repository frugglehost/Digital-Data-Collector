using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Presentation;



//SQlite tools.
using Microsoft.Data.Sqlite;
using static System.Net.Mime.MediaTypeNames;

namespace Data_Collector.DataTools {
    internal class DataMaster {

        

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


            SqliteConnection connection = new SqliteConnection("Data Source='"+ obtain_value + "DataBase\\ProductionData.db';") {
                DefaultTimeout = 5
            };
            try {
                connection.Open();
            } catch (Exception) {
            }
            return connection;
        }

        public static DataTable GetAllPN() {
            DataTable tempTable = new DataTable();
            try {

                using (SqliteConnection connection = CreateConnection()) {
                    using (SqliteCommand command = new SqliteCommand("SELECT DISTINCT [PartNumber] FROM [UniquePN] ORDER BY [PartNumber] ASC;", connection)) {
                        command.Connection = connection;
                        tempTable.Load(command.ExecuteReader());
                    }
                }
            } catch { }

            return tempTable;
        }
        public static DataTable GetShopOrder_All() {
            DataTable tempTable = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {
                using (SqliteCommand command = new SqliteCommand("SELECT * FROM [ShopOrder] ORDER BY [ShopOrder] DESC;", connection)) {
                    command.Connection = connection;
                    tempTable.Load(command.ExecuteReader());
                }
            }
            return tempTable;
        }

        public static DataTable GetShopOrder_ByOrderNum(string OrderNumber) {
            DataTable tempTable = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {
                using (SqliteCommand command = new SqliteCommand("SELECT * FROM [ShopOrder] WHERE [ShopOrder]=@p_OrderNumber ORDER BY [ShopOrder] DESC;", connection)) {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@p_OrderNumber", OrderNumber);
                    tempTable.Load(command.ExecuteReader());
                }
            }
            return tempTable;
        }

        public static DataTable GetAllUniqueDocs() {
            DataTable tempTable = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {
                using (SqliteCommand command = new SqliteCommand("SELECT DISTINCT [Name] FROM [UniqueDocs] ORDER BY [Name] ASC;", connection)) {
                    command.Connection = connection;
                    tempTable.Load(command.ExecuteReader());
                }
            }
            return tempTable;
        }

        public static DataTable GetUniquePN_PN(string PartNumber) {
            DataTable tempTable = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {

                string str = "SELECT * FROM [UniquePN] WHERE [PartNumber]=@p_PN ORDER BY [Revision] DESC;";
                SqliteCommand command = new SqliteCommand(str);

                command.Parameters.AddWithValue("@p_PN", PartNumber);

                command.Connection = connection;
                tempTable.Load(command.ExecuteReader());

            }
            return tempTable;
        }


        public static DataTable GetUserGroup_UserID(string UserNTID) {
            DataTable tempTable = new DataTable();
            try {
                using (SqliteConnection connection = CreateConnection()) {

                    string str = "SELECT * FROM [UserGroup] WHERE [UserTID]=@p_UserNTID ORDER BY [UserType] DESC;";
                    SqliteCommand command = new SqliteCommand(str);

                    command.Parameters.AddWithValue("@p_UserNTID", UserNTID);

                    command.Connection = connection;
                    tempTable.Load(command.ExecuteReader());

                }
            } catch { }
            return tempTable;
        }

        public static DataTable OrderInspPN_PartID(Int64 PartID) {
            DataTable tempTable = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {

                string str = "SELECT * FROM [OrderInspPN] WHERE [PartID]=@p_PartID ORDER BY [Order] ASC;";
                SqliteCommand command = new SqliteCommand(str);

                command.Parameters.AddWithValue("@p_PartID", PartID);

                command.Connection = connection;
                tempTable.Load(command.ExecuteReader());

            }
            return tempTable;
        }

        public static DataTable GetOrderInspPN_RowID(Int64 ROWID) {
            DataTable tempTable = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {

                string str = "SELECT * FROM [OrderInspPN] WHERE [ROWID]=@p_ROWID;";
                SqliteCommand command = new SqliteCommand(str);

                command.Parameters.AddWithValue("@p_ROWID", ROWID);

                command.Connection = connection;
                tempTable.Load(command.ExecuteReader());

            }
            return tempTable;
        }

        /*
        public static DataTable InsertOrderInspPN(Int64? PartID, Int64? DocID, Int64? DocOrder, Int64? ReqOpen = null, Int64? ReqClose = null, Int64? Order = null) {

            DataTable table = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {



                string Set = "";

                Set = (PartID != null) ? Set + "[PartID]," : Set;
                Set = (DocID != null) ? Set + "[DocID]," : Set;
                Set = (DocOrder != null) ? Set + "[DocOrder]," : Set;
                Set = (ReqOpen != null) ? Set + "[ReqOpen]," : Set;
                Set = (ReqClose != null) ? Set + "[ReqClose]," : Set;
                Set = (Order != null) ? Set + "[Order]," : Set;


                Set = Set.Substring(0, Set.Length - 1);


                string ValuesConn = "";

                ValuesConn = (PartID != null) ? ValuesConn + "@p_PartID," : ValuesConn;
                ValuesConn = (DocID != null) ? ValuesConn + "@p_DocID," : ValuesConn;
                ValuesConn = (DocOrder != null) ? ValuesConn + "@p_DocOrder," : ValuesConn;
                ValuesConn = (ReqOpen != null) ? ValuesConn + "@p_ReqOpen," : ValuesConn;
                ValuesConn = (ReqClose != null) ? ValuesConn + "@p_ReqClose," : ValuesConn;
                ValuesConn = (Order != null) ? ValuesConn + "@p_Order," : ValuesConn;


                ValuesConn = ValuesConn.Substring(0, ValuesConn.Length - 1);

                string str = string.Format("INSERT INTO [DocsPN] ({0}) VALUES ({1}); SELECT last_insert_rowid();", Set, ValuesConn);


                using (SqliteCommand command = new SqliteCommand(str, connection)) {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@p_PartID", PartID);
                    command.Parameters.AddWithValue("@p_DocID", DocID);
                    command.Parameters.AddWithValue("@p_DocOrder", DocOrder);
                    command.Parameters.AddWithValue("@p_ReqOpen", ReqOpen);
                    command.Parameters.AddWithValue("@p_ReqClose", ReqClose);
                    command.Parameters.AddWithValue("@p_Order", Order);



                    table.Load(command.ExecuteReader());

                }
            }
            return table;
        }
        */


        public static DataTable GetOrderInspPN_PartID(Int64 PartID) {
            DataTable tempTable = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {

                string str = "SELECT * FROM [OrderInspPN] WHERE [PartID]=@p_PartID ORDER BY [Order] ASC;";
                SqliteCommand command = new SqliteCommand(str);

                command.Parameters.AddWithValue("@p_PartID", PartID);

                command.Connection = connection;
                tempTable.Load(command.ExecuteReader());

            }
            return tempTable;
        }

        public static DataTable GetOrderInspPN(Int64? RowID = null, Int64? PartID = null, Int64? DataPointID = null, Int64? ReqOpen = null, Int64? ReqClose = null, Int64? Order=null) {
            DataTable tempTable = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {



                string Where = "";

                Where = (RowID != null) ? Where + "[RowID]=@p_RowID AND " : Where;
                Where = (PartID != null) ? Where + "[PartID]=@p_PartID AND " : Where;
                Where = (DataPointID != null) ? Where + "[DataPointID]=@p_DataPointID AND " : Where;
                Where = (ReqOpen != null) ? Where + "[ReqOpen]=@p_ReqOpen AND " : Where;
                Where = (ReqClose != null) ? Where + "[ReqClose]=@p_ReqClose AND " : Where;
                Where = (Order != null) ? Where + "[Order]=@p_Order AND " : Where;

                if (Where.Length != 0) {
                    Where = Where.Substring(0, Where.Length - 4);

                    Where = "WHERE " + Where;

                }

                

                string str = string.Format("SELECT * FROM [OrderInspPN] {0} ORDER BY [Order] ASC;", Where);


                SqliteCommand command = new SqliteCommand(str);

                command.Parameters.AddWithValue("@p_RowID", RowID);
                command.Parameters.AddWithValue("@p_PartID", PartID);
                command.Parameters.AddWithValue("@p_DataPointID", DataPointID);
                command.Parameters.AddWithValue("@p_ReqOpen", ReqOpen);
                command.Parameters.AddWithValue("@p_ReqClose", ReqClose);
                command.Parameters.AddWithValue("@p_Order", Order);


                command.Connection = connection;
                tempTable.Load(command.ExecuteReader());

            }
            return tempTable;
        }


        public static DataTable GetUniqueGroups(string GroupID = null, string Desription = null, string Active = null) {
            DataTable tempTable = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {



                string Where = "";

                Where = (GroupID != null) ? Where + "[GroupID]=@p_GroupID AND " : Where;
                Where = (Desription != null) ? Where + "[Desription]=@p_Desription AND " : Where;
                Where = (Active != null) ? Where + "[Active]=@p_Active AND " : Where;


                if (Where.Length != 0) {
                    Where = Where.Substring(0, Where.Length - 4);

                    Where = "WHERE " + Where;

                }



                string str = string.Format("SELECT * FROM [UniqueGroups] {0} ORDER BY [GroupID] ASC;", Where);


                SqliteCommand command = new SqliteCommand(str);

                command.Parameters.AddWithValue("@p_GroupID", GroupID);
                command.Parameters.AddWithValue("@p_Desription", Desription);
                command.Parameters.AddWithValue("@p_Active", Active);



                command.Connection = connection;
                tempTable.Load(command.ExecuteReader());

            }
            return tempTable;
        }


        public static DataTable GetClockingLog(string GUID = null, string ShopOrder = null, string UserID = null, string Start = null, string Stop = null) {
            DataTable tempTable = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {



                string Where = "";

                Where = (GUID != null) ? Where + "[GUID]=@p_GUID AND " : Where;
                Where = (ShopOrder != null) ? Where + "[ShopOrder]=@p_ShopOrder AND " : Where;
                Where = (UserID != null) ? Where + "[UserID]=@p_UserID AND " : Where;
                Where = (Start != null) ? Where + "[Start]=@p_Start AND " : Where;
                Where = (Stop != null) ? Where + "[Stop]=@p_Stop AND " : Where;

                if (Where.Length != 0) {
                    Where = Where.Substring(0, Where.Length - 4);

                    Where = "WHERE " + Where;

                }



                string str = string.Format("SELECT * FROM [ClockingLog] {0};", Where);


                SqliteCommand command = new SqliteCommand(str);

                command.Parameters.AddWithValue("@p_GUID", GUID);
                command.Parameters.AddWithValue("@p_ShopOrder", ShopOrder);
                command.Parameters.AddWithValue("@p_UserID", UserID);
                command.Parameters.AddWithValue("@p_Start", Start);
                command.Parameters.AddWithValue("@p_Stop", Stop);


                command.Connection = connection;
                tempTable.Load(command.ExecuteReader());

            }
            return tempTable;
        }

        public static DataTable GetInspCriteria_DataPointID(Int64 DataPointID) {
            DataTable tempTable = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {

                string str = "SELECT * FROM [InspCriteria] WHERE [DataPointID]=@p_DataPointID;";
                SqliteCommand command = new SqliteCommand(str);

                command.Parameters.AddWithValue("@p_DataPointID", DataPointID);

                command.Connection = connection;
                tempTable.Load(command.ExecuteReader());

            }
            return tempTable;
        }


        public static DataTable GetInspCriteria_DataPointID_Bulk(List<Int64?> DataPointID) {
            DataTable tempTable = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {

                string str = "SELECT * FROM [InspCriteria] WHERE [DataPointID]=@p_DataPointID0";
                
                for(int i=1; i < DataPointID.Count; i++) {
                    if (DataPointID[i] != null) {
                        str = str + " OR [DataPointID]=@p_DataPointID" + i;
                    }
                }


                SqliteCommand command = new SqliteCommand(str);

                command.Parameters.AddWithValue("@p_DataPointID0", DataPointID[0]);

                for (int i = 1; i < DataPointID.Count; i++) {
                    if (DataPointID[i] != null) {
                        command.Parameters.AddWithValue("@p_DataPointID" + i, DataPointID[i]);
                    }
                }

                command.Parameters.AddWithValue("@p_DataPointID", DataPointID);

                command.Connection = connection;
                tempTable.Load(command.ExecuteReader());

            }
            return tempTable;
        }

        public static DataTable GetPartIDbyPNandRev(string PartNumber, int Rev) {
            DataTable tempTable = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {

                string str = "SELECT * FROM [UniquePN] WHERE [PartNumber]=@p_PN AND [Revision]=@p_Rev;";
                SqliteCommand command = new SqliteCommand(str);

                command.Parameters.AddWithValue("@p_PN", PartNumber);
                command.Parameters.AddWithValue("@p_Rev", Rev);

                command.Connection = connection;
                tempTable.Load(command.ExecuteReader());

            }
            return tempTable;
        }

        public static DataTable GetUniquePN_PartID( Int64 PartID) {
            DataTable tempTable = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {

                string str = "SELECT * FROM [UniquePN] WHERE [PartID]=@p_PartID;";
                SqliteCommand command = new SqliteCommand(str);

                command.Parameters.AddWithValue("@p_PartID", PartID);

                command.Connection = connection;
                tempTable.Load(command.ExecuteReader());

            }
            return tempTable;
        }

        public static DataTable GetUniqueSerial_Order(string ShopOrder) {
            DataTable tempTable = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {

                string str = "SELECT * FROM [UniqueSerial] WHERE [ShopOrder]=@p_ShopOrder ORDER By [Serial] ASC;";
                SqliteCommand command = new SqliteCommand(str);

                command.Parameters.AddWithValue("@p_ShopOrder", ShopOrder);

                command.Connection = connection;
                tempTable.Load(command.ExecuteReader());

            }
            return tempTable;
        }



        public static DataTable GetShopOrder_ShopOrder(string ShopOrder = null) {

            DataTable tempTable = new DataTable();

            using (SqliteConnection connection = CreateConnection()) {

                string str = "SELECT * FROM [ShopOrder]";
                if (ShopOrder != null) {
                    str = str + " WHERE [ShopOrder]=@p_ID";
                }
                SqliteCommand command = new SqliteCommand(str + ";", connection);
                if (ShopOrder != null) {
                    command.Parameters.AddWithValue("@p_ID", ShopOrder);
                }
                tempTable.Load(command.ExecuteReader());
                return tempTable;

            }

            return new DataTable(); //We got to this point so there is a probelm.
        }

        public static DataTable GetBarDecode(string ShopOrder = null) {

            DataTable tempTable = new DataTable();

            using (SqliteConnection connection = CreateConnection()) {

                string str = "SELECT * FROM [ShopOrder]";
                if (ShopOrder != null) {
                    str = str + " WHERE [ShopOrder]=@p_ID";
                }
                SqliteCommand command = new SqliteCommand(str + ";", connection);
                if (ShopOrder != null) {
                    command.Parameters.AddWithValue("@p_ID", ShopOrder);
                }
                tempTable.Load(command.ExecuteReader());
                return tempTable;

            }

            return new DataTable(); //We got to this point so there is a probelm.
        }

        public static DataTable GetRevbyUniqueDoc(string PartNumber) {
            DataTable tempTable = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {

                string str = "SELECT * FROM [UniqueDocs] WHERE [Name]=@p_PN ORDER BY [Revison] DESC;";
                SqliteCommand command = new SqliteCommand(str);

                command.Parameters.AddWithValue("@p_PN", PartNumber);

                command.Connection = connection;
                tempTable.Load(command.ExecuteReader());

            }
            return tempTable;
        }



        public static DataTable GetUniqueDocIDbyPNandRev(string PartNumber, Int64 Rev) {
            DataTable tempTable = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {

                string str = "SELECT * FROM [UniqueDocs] WHERE [Name]=@p_PN and [Revison]=@p_Rev;";
                SqliteCommand command = new SqliteCommand(str);

                command.Parameters.AddWithValue("@p_PN", PartNumber);
                command.Parameters.AddWithValue("@p_Rev", Rev);

                command.Connection = connection;
                tempTable.Load(command.ExecuteReader());

            }
            return tempTable;
        }


        public static DataTable GetUniqueDoc_DocID( Int64 DocID) {
            DataTable tempTable = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {

                string str = "SELECT * FROM [UniqueDocs] WHERE [DocID]=@p_DocID;";
                SqliteCommand command = new SqliteCommand(str);

                command.Parameters.AddWithValue("@p_DocID", DocID);

                command.Connection = connection;
                tempTable.Load(command.ExecuteReader());

            }
            return tempTable;
        }


        public static DataTable GetDocsPN_PartID(Int64 PartID) {
            DataTable tempTable = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {

                string str = "SELECT * FROM [DocsPN] WHERE [PartID]=@p_PartID ORDER BY [DocOrder] ASC;";
                SqliteCommand command = new SqliteCommand(str);

                command.Parameters.AddWithValue("@p_PartID", PartID);

                command.Connection = connection;
                tempTable.Load(command.ExecuteReader());

            }
            return tempTable;
        }

        public static DataTable GetDataRecords(Int64? Rec_ID=null, string ShopOrderID=null, Int64? DataPointID=null, bool Hidden=true) {
            DataTable tempTable = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {

                string Where = "";

                Where = (Rec_ID != null) ? Where + "[Rec_ID]=@p_Rec_ID AND " : Where;
                Where = (ShopOrderID != null) ? Where + "[ShopOrderID]=@p_ShopOrderID AND " : Where;
                Where = (DataPointID != null) ? Where + "[DataPointID]=@p_DataPointID AND " : Where;
                Where = (Hidden == true) ? Where + "[Hidden] IS NULL AND " : Where;

                Where = Where.Substring(0, Where.Length - 4);

                string str = string.Format("SELECT * FROM [DataRecords] WHERE {0} ORDER BY [Rec_ID] DESC;", Where);
                

                
                SqliteCommand command = new SqliteCommand(str);

                command.Parameters.AddWithValue("@p_Rec_ID", Rec_ID);
                command.Parameters.AddWithValue("@p_ShopOrderID", ShopOrderID);
                command.Parameters.AddWithValue("@p_DataPointID", DataPointID);

                command.Connection = connection;
                tempTable.Load(command.ExecuteReader());

            }
            return tempTable;
        }


        public static DataTable GetInspCriteria(Int64? DataPointID = null, string DataPointName = null, string Description = null, string Type = null, Int64? DocID = null, string DocPosition = null, string UserType = null, Int64? Mandatory = null, string Format = null) {
            DataTable tempTable = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {

                string Where = "";

                Where = (DataPointID != null) ? Where + "[DataPointID]=@p_DataPointID AND " : Where;
                Where = (DataPointName != null) ? Where + "[DataPointName]=@p_DataPointName AND " : Where;
                Where = (Description != null) ? Where + "[Description]=@p_Description AND " : Where;
                Where = (Type != null) ? Where + "[Type]=@p_Type AND " : Where;
                Where = (DocID != null) ? Where + "[DocID]=@p_DocID AND " : Where;
                Where = (DocPosition != null) ? Where + "[DocPosition]=@p_DocPosition AND " : Where;
                Where = (UserType != null) ? Where + "[UserType]=@p_UserType AND " : Where;
                Where = (Mandatory != null) ? Where + "[Mandatory]=@p_Mandatory AND " : Where;
                Where = (Format != null) ? Where + "[Format]=@p_Format AND " : Where;


                Where = Where.Substring(0, Where.Length - 4);

                string str = string.Format("SELECT * FROM [InspCriteria] WHERE {0} ORDER BY [DataPointID] ASC;", Where);



                SqliteCommand command = new SqliteCommand(str);

                command.Parameters.AddWithValue("@p_DataPointID", DataPointID);
                command.Parameters.AddWithValue("@p_DataPointName", DataPointName);
                command.Parameters.AddWithValue("@p_Description", Description);
                command.Parameters.AddWithValue("@p_Type", Type);
                command.Parameters.AddWithValue("@p_DocID", DocID);
                command.Parameters.AddWithValue("@p_DocPosition", DocPosition);
                command.Parameters.AddWithValue("@p_UserType", UserType);
                command.Parameters.AddWithValue("@p_Mandatory", Mandatory);
                command.Parameters.AddWithValue("@p_Format", Format);


                command.Connection = connection;
                tempTable.Load(command.ExecuteReader());

            }
            return tempTable;
        }


        /*
        public static DataTable GetUniqueSerial(Int64? RowID = null, string Order = null, Int64? Serial = null) {
            DataTable tempTable = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {

                string Where = "";

                Where = (RowID != null) ? Where + "[RowID]=@p_RowID AND " : Where;
                Where = (Order != null) ? Where + "[Order]=@p_Order AND " : Where;
                Where = (Serial != null) ? Where + "[Serial]=@p_Serial AND " : Where;

                Where = Where.Substring(0, Where.Length - 4);

                string str = string.Format("SELECT * FROM [UniqueSerial] WHERE {0} ORDER BY [Serial] DESC;", Where);



                SqliteCommand command = new SqliteCommand(str);

                command.Parameters.AddWithValue("@p_RowID", RowID);
                command.Parameters.AddWithValue("@p_Order", Order);
                command.Parameters.AddWithValue("@p_Serial", Serial);

                command.Connection = connection;
                tempTable.Load(command.ExecuteReader());

            }
            return tempTable;
        }
        */



        public static DataTable InsertNewUniqueDoc(string Name, long Rev) {

            DataTable table = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {
                using (SqliteCommand command = new SqliteCommand("INSERT INTO [UniqueDocs] ([Name],[Revison]) VALUES (@p_PartNumber,@p_Rev); SELECT last_insert_rowid();", connection)) {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@p_PartNumber", Name);
                    command.Parameters.AddWithValue("@p_Rev", Rev);
                    table.Load(command.ExecuteReader());

                }
            }
            return table;
        }

        public static DataTable InsertShopOrder(string ShopOrder, Int64 PartID,  Int64 Qty, string Status) {

            DataTable table = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {
                using (SqliteCommand command = new SqliteCommand("INSERT INTO [ShopOrder] ([ShopOrder],[PartID],[Qty],[Status]) VALUES (@p_ShopOrder,@p_PartID,@p_Qty,@p_Status); SELECT last_insert_rowid();", connection)) {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@p_ShopOrder", ShopOrder);
                    command.Parameters.AddWithValue("@p_PartID", PartID);
                    command.Parameters.AddWithValue("@p_Qty", Qty);
                    command.Parameters.AddWithValue("@p_Status", Status);
                    table.Load(command.ExecuteReader());

                }
            }
            return table;
        }

        public static DataTable InsertUserGroup(string NTID, string UserType, Int64 Active) {

            DataTable table = new DataTable();
            try {
                using (SqliteConnection connection = CreateConnection()) {
                    using (SqliteCommand command = new SqliteCommand("INSERT INTO [UserGroup] ([UserTID],[UserType],[Active]) VALUES (@p_NTID,@p_UserType,@p_Active); SELECT last_insert_rowid();", connection)) {
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@p_NTID", NTID);
                        command.Parameters.AddWithValue("@p_UserType", UserType);
                        command.Parameters.AddWithValue("@p_Active", Active);
                        table.Load(command.ExecuteReader());

                    }
                }
            } catch { }
            return table;
        }

        public static DataTable UpdateUserGroup_UserTID_UserType(string NTID, string UserType, Int64 Active) {

            DataTable table = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {
                using (SqliteCommand command = new SqliteCommand("UPDATE [UserGroup] SET [Active]=@p_Active WHERE [UserTID]=@p_NTID AND [UserType]=@p_UserType; SELECT last_insert_rowid();", connection)) {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@p_NTID", NTID);
                    command.Parameters.AddWithValue("@p_UserType", UserType);
                    command.Parameters.AddWithValue("@p_Active", Active);
                    table.Load(command.ExecuteReader());

                }
            }
            return table;
        }

        public static DataTable UpdateShopOrder_ShopOrder(string ShopOrder, Int64? PartID=null, Int64? Qty=null,string Status=null) {

            DataTable table = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {

                string Set = "";

                Set = (ShopOrder != null) ? Set + "[ShopOrder]=@p_ShopOrder," : Set;
                Set = (PartID != null) ? Set + "[PartID]=@p_PartID," : Set;
                Set = (Qty != null) ? Set + "[Qty]=@p_Qty," : Set;
                Set = (Status != null) ? Set + "[Status]=@p_Status," : Set;


                Set = Set.Substring(0, Set.Length - 1);

                string str = string.Format("UPDATE [ShopOrder] SET {0} WHERE [ShopOrder]=@p_ShopOrder; SELECT last_insert_rowid();", Set);





                using (SqliteCommand command = new SqliteCommand(str, connection)) {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@p_ShopOrder", ShopOrder);
                    command.Parameters.AddWithValue("@p_PartID", PartID);
                    command.Parameters.AddWithValue("@p_Qty", Qty);
                    command.Parameters.AddWithValue("@p_Status", Status);
                    table.Load(command.ExecuteReader());

                }
            }
            return table;
        }

        public static DataTable InsertNewUniquePN(string Name, long Rev) {

            DataTable table = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {
                using (SqliteCommand command = new SqliteCommand("INSERT INTO [UniquePN] ([PartNumber],[Revision]) VALUES (@p_PartNumber,@p_Rev); SELECT last_insert_rowid();", connection)) {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@p_PartNumber", Name);
                    command.Parameters.AddWithValue("@p_Rev", Rev);
                    table.Load(command.ExecuteReader());

                }
            }
            return table;
        }

        public static DataTable InsertDocsPN_NewRow(Int64 PartID, Int64 DocID, Int64 DocOrder) {

            DataTable table = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {
                using (SqliteCommand command = new SqliteCommand("INSERT INTO [DocsPN] ([PartID],[DocID],[DocOrder]) VALUES (@p_PartID,@p_DocID,@p_DocOrder); SELECT last_insert_rowid();", connection)) {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@p_PartID", PartID);
                    command.Parameters.AddWithValue("@p_DocID", DocID);
                    command.Parameters.AddWithValue("@p_DocOrder", DocOrder);
                    table.Load(command.ExecuteReader());

                }
            }
            return table;
        }

        public static DataTable InsertInspCriteria(Int64 DocID) {

            DataTable table = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {
                using (SqliteCommand command = new SqliteCommand("INSERT INTO [InspCriteria] ([DocID]) VALUES (@p_DocID); SELECT last_insert_rowid();", connection)) {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@p_DocID", DocID);
                    table.Load(command.ExecuteReader());

                }
            }
            return table;
        }


        public static DataTable InsertInspCriteriaFull(string DataPointName,  string Description, string Type, Int64? DocID, string DocPosition, string UserType, Int64? Mandatory, string Format, Int64? OldICID=null) {

            DataTable table = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {


                string Set = "";

                Set = (DataPointName != null) ? Set + "[DataPointName]," : Set;
                Set = (Description != null) ? Set + "[Description]," : Set;
                Set = (Type != null) ? Set + "[Type]," : Set;
                Set = (DocID != null) ? Set + "[DocID]," : Set;
                Set = (DocPosition != null) ? Set + "[DocPosition]," : Set;
                Set = (UserType != null) ? Set + "[UserType]," : Set;
                Set = (Mandatory != null) ? Set + "[Mandatory]," : Set;
                Set = (Format != null) ? Set + "[Format]," : Set;
                Set = (OldICID != null) ? Set + "[OldICID]," : Set;

                Set = Set.Substring(0, Set.Length - 1);


                string ValuesConn = "";

                ValuesConn = (DataPointName != null) ? ValuesConn + "@p_DataPointName," : ValuesConn;
                ValuesConn = (Description != null) ? ValuesConn + "@p_Description," : ValuesConn;
                ValuesConn = (Type != null) ? ValuesConn + "@p_Type," : ValuesConn;
                ValuesConn = (DocID != null) ? ValuesConn + "@p_DocID," : ValuesConn;
                ValuesConn = (DocPosition != null) ? ValuesConn + "@p_DocPosition," : ValuesConn;
                ValuesConn = (UserType != null) ? ValuesConn + "@p_UserType," : ValuesConn;
                ValuesConn = (Mandatory != null) ? ValuesConn + "@p_Mandatory," : ValuesConn;
                ValuesConn = (Format != null) ? ValuesConn + "@p_Format," : ValuesConn;
                ValuesConn = (OldICID != null) ? ValuesConn + "@p_OldICID," : ValuesConn;

                ValuesConn = ValuesConn.Substring(0, ValuesConn.Length - 1);

                string str = string.Format("INSERT INTO [InspCriteria] ({0}) VALUES ({1}); SELECT last_insert_rowid();", Set, ValuesConn);


                using (SqliteCommand command = new SqliteCommand(str, connection)) {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@p_DataPointName", DataPointName);
                    command.Parameters.AddWithValue("@p_Description", Description);
                    command.Parameters.AddWithValue("@p_Type", Type);
                    command.Parameters.AddWithValue("@p_DocID", DocID);
                    command.Parameters.AddWithValue("@p_DocPosition", DocPosition);
                    command.Parameters.AddWithValue("@p_UserType", UserType);
                    command.Parameters.AddWithValue("@p_Mandatory", Mandatory);
                    command.Parameters.AddWithValue("@p_Format", Format);
                    command.Parameters.AddWithValue("@p_OldICID", OldICID);
                    

                    table.Load(command.ExecuteReader());

                }
            }
            return table;
        }


        public static void UpdateInspCriteria(Int64 RowID, string Type=null, string DataPointName = null,string Description = null, string UserType = null, Int64? Mandatory = null, Int64? DocID = null, string DocPosition = null) {

            DataTable table = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {


                string Set = "";

                Set = (Type != null) ? Set + "[Type]=@p_Type, " : Set;
                Set = (DataPointName != null) ? Set + "[DataPointName]=@p_DataPointName, " : Set;
                Set = (Description != null) ? Set + "[Description]=@p_Description, " : Set;
                Set = (UserType != null) ? Set + "[UserType]=@p_UserType, " : Set;
                Set = (Mandatory != null) ? Set + "[Mandatory]=@p_Mandatory, " : Set;
                Set = (DocID != null) ? Set + "[DocID]=@p_DocID, " : Set;
                Set = (DocPosition != null) ? Set + "[DocPosition]=@p_DocPosition, " : Set;


                Set = Set.Substring(0, Set.Length - 2);

                string str = string.Format("UPDATE [InspCriteria] SET {0} WHERE [DataPointID]=@p_RowID;", Set);



                using (SqliteCommand command = new SqliteCommand(str, connection)) {

                    command.Connection = connection;
                    command.Parameters.AddWithValue("@p_RowID", RowID);
                    command.Parameters.AddWithValue("@p_Type", Type);
                    command.Parameters.AddWithValue("@p_DataPointName", DataPointName);
                    command.Parameters.AddWithValue("@p_Description", Description);
                    command.Parameters.AddWithValue("@p_UserType", UserType);
                    command.Parameters.AddWithValue("@p_Mandatory", Mandatory);
                    command.Parameters.AddWithValue("@p_DocID", DocID);
                    command.Parameters.AddWithValue("@p_DocPosition", DocPosition);
                    table.Load(command.ExecuteReader());

                }
            }
        }

        public static void UpdateOrderInspPN(Int64 RowID, Int64? PartID = null, Int64? DataPointID = null, Int64? ReqOpen = null, Int64 ?ReqClose = null, Int64? Order=null, Int64? Visible = null) {

            DataTable table = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {


                string Set = "";

                Set = (PartID != null) ? Set + "[PartID]=@p_PartID, " : Set;
                Set = (DataPointID != null) ? Set + "[DataPointID]=@p_DataPointID, " : Set;
                Set = (ReqOpen != null) ? Set + "[ReqOpen]=@p_ReqOpen, " : Set;
                Set = (ReqClose != null) ? Set + "[ReqClose]=@p_ReqClose, " : Set;
                Set = (Order != null) ? Set + "[Order]=@p_Order, " : Set;
                Set = (Visible != null) ? Set + "[Visible]=@p_Visible, " : Set;

                Set = Set.Substring(0, Set.Length - 2);

                string str = string.Format("UPDATE [OrderInspPN] SET {0} WHERE [ROWID]=@p_RowID;", Set);


                using (SqliteCommand command = new SqliteCommand(str, connection)) {

                    command.Connection = connection;
                    command.Parameters.AddWithValue("@p_RowID", RowID);
                    command.Parameters.AddWithValue("@p_PartID", PartID);
                    command.Parameters.AddWithValue("@p_DataPointID", DataPointID);
                    command.Parameters.AddWithValue("@p_ReqOpen", ReqOpen);
                    command.Parameters.AddWithValue("@p_ReqClose", ReqClose);
                    command.Parameters.AddWithValue("@p_Order", Order);
                    command.Parameters.AddWithValue("@p_Visible", Visible);

                    table.Load(command.ExecuteReader());

                }
            }
        }


        public static DataTable InsertOrderInspPN(Int64? PartID = null, Int64? DataPointID = null, Int64? Order = null, Int64? ReqOpen = null, Int64? ReqClose=null, Int64? Visible=null) {

            DataTable table = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {

                string Set = "";

                Set = (PartID != null) ? Set + "[PartID]," : Set;
                Set = (DataPointID != null) ? Set + "[DataPointID]," : Set;
                Set = (Order != null) ? Set + "[Order]," : Set;
                Set = (ReqOpen != null) ? Set + "[ReqOpen]," : Set;
                Set = (ReqClose != null) ? Set + "[ReqClose]," : Set;
                Set = (Visible != null) ? Set + "[Visible]," : Set;

                Set = Set.Substring(0, Set.Length - 1);


                string ValuesConn = "";

                ValuesConn = (PartID != null) ? ValuesConn + "@p_PartID," : ValuesConn;
                ValuesConn = (DataPointID != null) ? ValuesConn + "@p_DataPointID," : ValuesConn;
                ValuesConn = (Order != null) ? ValuesConn + "@p_Order," : ValuesConn;
                ValuesConn = (ReqOpen != null) ? ValuesConn + "@p_ReqOpen," : ValuesConn;
                ValuesConn = (ReqClose != null) ? ValuesConn + "@p_ReqClose," : ValuesConn;
                ValuesConn = (Visible != null) ? ValuesConn + "@p_Visible," : ValuesConn;


                ValuesConn = ValuesConn.Substring(0, ValuesConn.Length - 1);

                string str = string.Format("INSERT INTO [OrderInspPN] ({0}) VALUES ({1}); SELECT last_insert_rowid();", Set, ValuesConn);


                using (SqliteCommand command = new SqliteCommand(str, connection)) {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@p_PartID", PartID);
                    command.Parameters.AddWithValue("@p_DataPointID", DataPointID);
                    command.Parameters.AddWithValue("@p_Order", Order);
                    command.Parameters.AddWithValue("@p_ReqOpen", ReqOpen);
                    command.Parameters.AddWithValue("@p_ReqClose", ReqClose);
                    command.Parameters.AddWithValue("@p_Visible", Visible);

                    table.Load(command.ExecuteReader());

                }
            }
            return table;
        }


        public static void UpdateDocInfo(Int64 DocID, string Path) {
            DataTable table1 = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {
                using (SqliteCommand command = new SqliteCommand("UPDATE [UniqueDocs] SET [Path]=@p_Path WHERE [DocID]=@p_DocID;", connection)) {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@p_DocID", DocID);
                    command.Parameters.AddWithValue("@p_Path", Path);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static DataTable InsertDataRecords(string ShopOrderID, Int64 DataPointID, string Value, string User_ID, string DateTimes) {
            DataTable table1 = new DataTable();
            try {
                using (SqliteConnection connection = CreateConnection()) {
                    using (SqliteCommand command = new SqliteCommand("INSERT INTO [DataRecords] ([ShopOrderID], [DataPointID], [Value], [User_ID], [DateTime UTC]) VALUES " +
                        "(@p_ShopOrderID,@p_DataPointID,@p_Value,@p_User_ID,@p_DateTimes); SELECT last_insert_rowid();", connection)) {
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@p_ShopOrderID", ShopOrderID);
                        command.Parameters.AddWithValue("@p_DataPointID", DataPointID);
                        command.Parameters.AddWithValue("@p_Value", Value);
                        command.Parameters.AddWithValue("@p_User_ID", User_ID);
                        command.Parameters.AddWithValue("@p_DateTimes", DateTimes);

                        table1.Load(command.ExecuteReader());
                    }
                }
            } catch { }
            return table1;

        }

        public static void UpsertClockingLog(string GUID, string ShopOrder, string UserID, string Start, string Stop) {
            DataTable table1 = new DataTable();
            try {
                using (SqliteConnection connection = CreateConnection()) {
                    using (SqliteCommand command = new SqliteCommand("INSERT INTO ClockingLog ([GUID],[ShopOrder],[UserID],[Start],[Stop])" +
                        "VALUES(@p_GUID,@p_ShopOrder,@p_UserID,@p_Start,@p_Stop)" +
                        "ON CONFLICT([GUID]) " +
                        "DO " +
                        "UPDATE SET [Stop] = @p_Stop " +
                        "WHERE [GUID]=@p_GUID;", connection)) {
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@p_GUID", GUID);
                        command.Parameters.AddWithValue("@p_ShopOrder", ShopOrder);
                        command.Parameters.AddWithValue("@p_UserID", UserID);
                        command.Parameters.AddWithValue("@p_Start", Start);
                        command.Parameters.AddWithValue("@p_Stop", Stop);
                        command.ExecuteNonQuery();
                    }
                }
            } catch { }
        }



        public static void InsertUniqueSerial(string ShopOrder, string PartNumber, string Serial) {
            DataTable table1 = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {
                using (SqliteCommand command = new SqliteCommand("" +
                    "INSERT INTO [UniqueSerial] ([PartNumber], [ShopOrder],[Serial]) VALUES (@p_PartNumber,@p_ShopOrder,@p_Serial);", connection)) {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@p_ShopOrder", ShopOrder);
                    command.Parameters.AddWithValue("@p_PartNumber", PartNumber);
                    command.Parameters.AddWithValue("@p_Serial", Serial);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void RemoveUniqueSerial(string ShopOrder = null, string PartNumber=null, string Serial = null) {
            DataTable table1 = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {

                string Where = "";

                Where = (PartNumber != null) ? Where + "[PartNumber]=@p_PartNumber AND " : Where;
                Where = (ShopOrder != null) ? Where + "[ShopOrder]=@p_ShopOrder AND " : Where;
                Where = (Serial != null) ? Where + "[Serial]=@p_Serial AND " : Where;

                Where = Where.Substring(0, Where.Length - 4);

                string str = string.Format(" DELETE  FROM [UniqueSerial] WHERE {0};", Where);

                using (SqliteCommand command = new SqliteCommand(str, connection)) {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@p_ShopOrder", ShopOrder);
                    command.Parameters.AddWithValue("@p_PartNumber", PartNumber);
                    command.Parameters.AddWithValue("@p_Serial", Serial);
                    command.ExecuteNonQuery();
                }
            }
        }


        public static DataTable GetUniqueSerial(string ShopOrder = null, string PartNumber = null, string Serial = null) {
            DataTable tempTable = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {

                string Where = "";

                Where = (PartNumber != null) ? Where + "[PartNumber]=@p_PartNumber AND " : Where;
                Where = (ShopOrder != null) ? Where + "[ShopOrder]=@p_ShopOrder AND " : Where;
                Where = (Serial != null) ? Where + "[Serial]=@p_Serial AND " : Where;

                Where = Where.Substring(0, Where.Length - 4);

                string str = string.Format("SELECT * FROM [UniqueSerial] WHERE {0} ORDER BY [Serial] ASC;", Where);



                SqliteCommand command = new SqliteCommand(str);

                command.Parameters.AddWithValue("@p_ShopOrder", ShopOrder);
                command.Parameters.AddWithValue("@p_PartNumber", PartNumber);
                command.Parameters.AddWithValue("@p_Serial", Serial);

                command.Connection = connection;
                tempTable.Load(command.ExecuteReader());

            }
            return tempTable;
        }

        public static void UpdateDocsPN_RowID(Int64 RowID, Int64 DocID, Int64 DocOrder) {

            DataTable table = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {
                using (SqliteCommand command = new SqliteCommand("UPDATE [DocsPN] SET [DocID]=@p_DocID, [DocOrder]=@p_DocOrder WHERE [ID]=@p_RowID;", connection)) {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@p_RowID", RowID);
                    command.Parameters.AddWithValue("@p_DocID", DocID);
                    command.Parameters.AddWithValue("@p_DocOrder", DocOrder);
                    table.Load(command.ExecuteReader());

                }
            }
        }

        public static void UpdateRecID(Int64 Rec_ID, string ShopOrderID, Int64? DataPointID,string Value, string Hidden,string Admin) {

            DataTable table = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {


                string Set = "";

                Set = (ShopOrderID != null) ? Set + "[ShopOrderID]=@p_ShopOrderID, " : Set;
                Set = (DataPointID != null) ? Set + "[DataPointID]=@p_DataPointID, " : Set;
                Set = (Value != null) ? Set + "[Value]=@p_Value, " : Set;
                Set = (Hidden != null) ? Set + "[Hidden]=@p_Hidden, " : Set;
                Set = (Admin != null) ? Set + "[Admin]=@p_Admin, " : Set;


                Set = Set.Substring(0, Set.Length - 2);

                string str = string.Format("UPDATE [DataRecords] SET {0} WHERE [Rec_ID]=@p_Rec_ID;", Set);



                using (SqliteCommand command = new SqliteCommand(str, connection)) {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@p_Rec_ID", Rec_ID);
                    command.Parameters.AddWithValue("@p_ShopOrderID", ShopOrderID);
                    command.Parameters.AddWithValue("@p_DataPointID", DataPointID);
                    command.Parameters.AddWithValue("@p_Value", Value);
                    command.Parameters.AddWithValue("@p_Hidden", Hidden);
                    command.Parameters.AddWithValue("@p_Admin", Admin);

                    table.Load(command.ExecuteReader());

                }
            }
        }

        public static void DeleteDocsPN_RowID(Int64 RowID) {

            DataTable table = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {
                using (SqliteCommand command = new SqliteCommand(" DELETE FROM [DocsPN] WHERE [ID]=@p_RowID;", connection)) {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@p_RowID", RowID);
                    table.Load(command.ExecuteReader());

                }
            }
        }






    }



}
