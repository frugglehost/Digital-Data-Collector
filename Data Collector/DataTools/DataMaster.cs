using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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



        public static DataTable GetShopOrder(string ShopOrder = null) {

            DataTable tempTable= new DataTable();

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





    }


}
