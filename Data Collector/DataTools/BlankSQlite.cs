using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Collector.DataTools {
    internal class BlankSQlite {


        private static SqliteConnection CreateConnection() {
            SqliteConnection connection = new SqliteConnection("Data Source=database.db;");
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
    ClockID        INTEGER PRIMARY KEY,
    UserID         TEXT,
    SessionID      TEXT,
    Type           INTEGER DEFAULT (0),
    [DateTime UTC] TEXT    NOT NULL,
    ShopOrder      TEXT
)
STRICT;

CREATE TABLE DataRecords (
    Rec_ID         INTEGER PRIMARY KEY,
    ShopOrderID    TEXT    NOT NULL,
    DataPointID    INTEGER NOT NULL,
    Value          TEXT    NOT NULL,
    User_ID        TEXT    NOT NULL,
    [DateTime UTC] TEXT    NOT NULL
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
    DataPointID    INTEGER PRIMARY KEY,
    DataPointName  TEXT    DEFAULT TBD,
    Description    TEXT    DEFAULT TBD,
    DataPointOrder INTEGER,
    Type           TEXT,
    PartID         INTEGER,
    DocID          INTEGER,
    DocPosition    TEXT,
    UserType       TEXT,
    ReqOpen        INTEGER,
    ReqClose       INTEGER,
    Mandatory      INTEGER DEFAULT (1) 
)
STRICT;

CREATE TABLE ShopOrder (
    ShopOrder TEXT PRIMARY KEY
                   NOT NULL
                   COLLATE NOCASE,
    PartID    INT  NOT NULL,
    Serial    TEXT
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
