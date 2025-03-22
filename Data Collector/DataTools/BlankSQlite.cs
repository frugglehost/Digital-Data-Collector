using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Collector.DataTools {
    internal class BlankSQlite {


        private static SqliteConnection CreateConnection() {

            string LocalFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Digital Data Collector";

            IniFile MyIni = new IniFile(@LocalFolder + @"\Settings.ini");
            string obtain_value = MyIni.Read("RootFoder");


            //string obtain_value = System.Configuration.ConfigurationManager.AppSettings["DataBaseRemote"];
            SqliteConnection connection = new SqliteConnection("Data Source='" + obtain_value + "\\DataBase.db';");
            try {
                connection.Open();
            } catch (Exception) {
            }
            return connection;
        }

        public static void CreateDB() {
            using (SqliteConnection connection = CreateConnection()) {
                using (SqliteCommand command = new SqliteCommand(@"
CREATE TABLE BarDecode (
    Contains   TEXT    NOT NULL
                       UNIQUE
                       PRIMARY KEY
                       COLLATE NOCASE,
    Delimiter  TEXT    NOT NULL,
    PN         INTEGER NOT NULL,
    Lot        INTEGER NOT NULL,
    Date       INTEGER NOT NULL,
    DateFormat TEXT    NOT NULL,
    Coments    TEXT,
    PNOver     TEXT,
    AddDays    INTEGER
)
STRICT;


CREATE TABLE ClockingLog (
    GUID      TEXT PRIMARY KEY,
    ShopOrder TEXT NOT NULL,
    UserID    TEXT NOT NULL,
    Start     TEXT NOT NULL,
    Stop      TEXT NOT NULL
)
STRICT;


CREATE TABLE DataRecords (
    Rec_ID         INTEGER PRIMARY KEY,
    ShopOrderID    TEXT    NOT NULL,
    DataPointID    INTEGER NOT NULL,
    Value          TEXT    NOT NULL,
    User_ID        TEXT    NOT NULL,
    [DateTime UTC] TEXT    NOT NULL,
    Hidden         TEXT
)
STRICT;


CREATE TABLE DocsPN (
    ID       INTEGER PRIMARY KEY,
    PartID   INTEGER NOT NULL,
    DocID    INTEGER NOT NULL,
    DocOrder INTEGER NOT NULL
)
STRICT;


CREATE TABLE InspCriteria (
    DataPointID   INTEGER PRIMARY KEY,
    DataPointName TEXT    DEFAULT TBD,
    Description   TEXT    DEFAULT TBD,
    Type          TEXT,
    DocID         INTEGER,
    DocPosition   TEXT,
    UserType      TEXT,
    Mandatory     INTEGER DEFAULT (1),
    Format        TEXT,
    OldICID       INTEGER
)
STRICT;


CREATE TABLE OrderInspPN (
    RowID       INTEGER PRIMARY KEY,
    PartID      INTEGER,
    DataPointID INTEGER,
    ReqOpen     INTEGER,
    ReqClose    INTEGER,
    [Order]     INTEGER
)
STRICT;


CREATE TABLE ShopOrder (
    ShopOrder TEXT    PRIMARY KEY
                      NOT NULL
                      COLLATE NOCASE,
    PartID    INT     NOT NULL,
    Qty       INTEGER DEFAULT (1) 
)
WITHOUT ROWID,
STRICT;


CREATE TABLE UniqueDocs (
    DocID   INTEGER PRIMARY KEY,
    Name    TEXT    NOT NULL,
    Path    TEXT,
    Revison INTEGER NOT NULL
                    DEFAULT (0) 
)
STRICT;


CREATE TABLE UniquePN (
    PartID     INTEGER PRIMARY KEY,
    PartNumber TEXT    NOT NULL,
    Revision   INTEGER NOT NULL
)
STRICT;


CREATE TABLE UniqueSerial (
    RowID      INTEGER PRIMARY KEY,
    ShopOrder  TEXT    COLLATE NOCASE,
    PartNumber TEXT    COLLATE NOCASE,
    Serial     TEXT
)
STRICT;


CREATE TABLE UserGroup (
    UserTID  TEXT    NOT NULL
                     COLLATE NOCASE,
    UserType TEXT    NOT NULL,
    Active   INTEGER DEFAULT (1) 
                     NOT NULL
)
STRICT;


CREATE TABLE UserInfo (
    User_ID TEXT PRIMARY KEY
                 NOT NULL,
    First   TEXT NOT NULL,
    Last    TEXT NOT NULL
)
WITHOUT ROWID,
STRICT;

", connection)) {
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
            }
        }



    }
}
