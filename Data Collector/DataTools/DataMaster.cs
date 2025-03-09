using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

//SQlite tools.
using Microsoft.Data.Sqlite;

namespace Data_Collector.DataTools {
    internal class DataMaster {

        private static SqliteConnection CreateConnection() {
            SqliteConnection connection = new SqliteConnection("Data Source=database.db;") {
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
            using (SqliteConnection connection = CreateConnection()) {
                using (SqliteCommand command = new SqliteCommand("SELECT DISTINCT [PartNumber] FROM [UniquePN] ORDER BY [PartNumber] ASC;", connection)) {
                    command.Connection = connection;
                    tempTable.Load(command.ExecuteReader());
                }
            }
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

        public static DataTable GetRevbyPN(string PartNumber) {
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
            using (SqliteConnection connection = CreateConnection()) {

                string str = "SELECT * FROM [UserGroup] WHERE [UserTID]=@p_UserNTID ORDER BY [UserType] DESC;";
                SqliteCommand command = new SqliteCommand(str);

                command.Parameters.AddWithValue("@p_UserNTID", UserNTID);

                command.Connection = connection;
                tempTable.Load(command.ExecuteReader());

            }
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


        public static DataTable GetInspCriteria_DataPointID_Bulk(List<Int64> DataPointID) {
            DataTable tempTable = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {

                string str = "SELECT * FROM [InspCriteria] WHERE [DataPointID]=@p_DataPointID0";
                
                for(int i=1; i < DataPointID.Count; i++) {

                    str = str + " OR [DataPointID]=@p_DataPointID" + i;
                }


                SqliteCommand command = new SqliteCommand(str);

                command.Parameters.AddWithValue("@p_DataPointID0", DataPointID[0]);

                for (int i = 1; i < DataPointID.Count; i++) {
                    command.Parameters.AddWithValue("@p_DataPointID" + i, DataPointID[i]);
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

        public static DataTable GetUniqueSerial_Order(string Order) {
            DataTable tempTable = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {

                string str = "SELECT * FROM [UniqueSerial] WHERE [Order]=@p_Order ORDER By [Serial] ASC;";
                SqliteCommand command = new SqliteCommand(str);

                command.Parameters.AddWithValue("@p_Order", Order);

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

        public static DataTable InsertShopOrder(string ShopOrder, Int64 PartID,  Int64 Qty) {

            DataTable table = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {
                using (SqliteCommand command = new SqliteCommand("INSERT INTO [ShopOrder] ([ShopOrder],[PartID],[Qty]) VALUES (@p_ShopOrder,@p_PartID,@p_Qty); SELECT last_insert_rowid();", connection)) {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@p_ShopOrder", ShopOrder);
                    command.Parameters.AddWithValue("@p_PartID", PartID);
                    command.Parameters.AddWithValue("@p_Qty", Qty);
                    table.Load(command.ExecuteReader());

                }
            }
            return table;
        }

        public static DataTable InsertUserGroup(string NTID, string UserType, Int64 Active) {

            DataTable table = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {
                using (SqliteCommand command = new SqliteCommand("INSERT INTO [UserGroup] ([UserTID],[UserType],[Active]) VALUES (@p_NTID,@p_UserType,@p_Active); SELECT last_insert_rowid();", connection)) {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@p_NTID", NTID);
                    command.Parameters.AddWithValue("@p_UserType", UserType);
                    command.Parameters.AddWithValue("@p_Active", Active);
                    table.Load(command.ExecuteReader());

                }
            }
            return table;
        }

        public static DataTable UpdateUserGroup_UserTID_UserType(string NTID, string UserType, Int64 Active) {

            DataTable table = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {
                using (SqliteCommand command = new SqliteCommand("UPDATE [UserGroup] SET [Active]=@p_Active WHERE [UserTID]=@p_NTID AND [UserType]=@p_UserType;", connection)) {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@p_NTID", NTID);
                    command.Parameters.AddWithValue("@p_UserType", UserType);
                    command.Parameters.AddWithValue("@p_Active", Active);
                    table.Load(command.ExecuteReader());

                }
            }
            return table;
        }

        public static DataTable UpdateShopOrder_ShopOrder(string ShopOrder, Int64 PartID, Int64 Qty) {

            DataTable table = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {
                using (SqliteCommand command = new SqliteCommand("UPDATE [ShopOrder] SET [PartID]=@p_PartID, [Qty]=@p_Qty WHERE [ShopOrder]=@p_ShopOrder;", connection)) {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@p_ShopOrder", ShopOrder);
                    command.Parameters.AddWithValue("@p_PartID", PartID);
                    command.Parameters.AddWithValue("@p_Qty", Qty);
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

        public static void UpdateInspCriteria(Int64 RowID, string Type, string DataPointName,string Description, string UserType, Int64 Mandatory, Int64 DocID, string DocPosition) {

            DataTable table = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {
                using (SqliteCommand command = new SqliteCommand("UPDATE [InspCriteria] SET [Type]=@p_Type, " +
                    "[DataPointName]=@p_DataPointName, " +
                    "[Description]=@p_Description, " +
                    "[UserType]=@p_UserType, " +
                    "[Mandatory]=@p_Mandatory, " +
                    "[DocID]=@p_DocID," +
                    "[DocPosition]=@p_DocPosition WHERE [DataPointID]=@p_RowID;", connection)) {

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

        public static void UpdateOrderInspPN(Int64 RowID, Int64 PartID, Int64 DataPointID, Int64 ReqOpen, Int64 ReqClose, Int64 Order) {

            DataTable table = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {
                using (SqliteCommand command = new SqliteCommand("UPDATE [OrderInspPN] SET [PartID]=@p_PartID, " +
                    "[DataPointID]=@p_DataPointID, " +
                    "[ReqOpen]=@p_ReqOpen, " +
                    "[ReqClose]=@p_ReqClose, " +
                    "[Order]=@p_Order WHERE [ROWID]=@p_RowID;", connection)) {

                    command.Connection = connection;
                    command.Parameters.AddWithValue("@p_RowID", RowID);
                    command.Parameters.AddWithValue("@p_PartID", PartID);
                    command.Parameters.AddWithValue("@p_DataPointID", DataPointID);
                    command.Parameters.AddWithValue("@p_ReqOpen", ReqOpen);
                    command.Parameters.AddWithValue("@p_ReqClose", ReqClose);
                    command.Parameters.AddWithValue("@p_Order", Order);
                    table.Load(command.ExecuteReader());

                }
            }
        }


        public static DataTable InsertOrderInspPN(Int64 PartID, Int64 DataPointID, int Order) {

            DataTable table = new DataTable();
            using (SqliteConnection connection = CreateConnection()) {
                using (SqliteCommand command = new SqliteCommand("INSERT INTO [OrderInspPN] ([PartID], [DataPointID], [Order]) VALUES (@p_PartID,@p_DataPointID,@p_Order); SELECT last_insert_rowid();", connection)) {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@p_PartID", PartID);
                    command.Parameters.AddWithValue("@p_DataPointID", DataPointID);
                    command.Parameters.AddWithValue("@p_Order", Order);
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
