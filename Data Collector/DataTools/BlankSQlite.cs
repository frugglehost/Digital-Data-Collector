using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Collector.DataTools {
    internal class BlankSQlite {


        private static SqliteConnection CreateConnection(string NameDB) {

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

            if (!Directory.Exists(obtain_value + "DataBase\\")) {
                Directory.CreateDirectory(obtain_value + "DataBase\\");
            }

            //string obtain_value = System.Configuration.ConfigurationManager.AppSettings["DataBaseRemote"];
            SqliteConnection connection = new SqliteConnection("Data Source='" + obtain_value + "DataBase\\"+ NameDB+".db';");
            try {
                connection.Open();
            } catch (Exception) {
            }
            return connection;

        }


        public static void CreateDB_QC() {
            using (SqliteConnection connection = CreateConnection("QualityData")) {
                using (SqliteCommand command = new SqliteCommand(@"
CREATE TABLE Dispo_Task (
    RowID       INTEGER PRIMARY KEY,
    DispoID     INTEGER REFERENCES NCR_Dispo (RowID) ON DELETE SET NULL
                                                     ON UPDATE CASCADE,
    UserGroup   TEXT,
    TaskType    ANY,
    CreatedBy   TEXT,
    TimeCreated TEXT,
    NameDesc    TEXT,
    [Full Text] BLOB,
    AssignedTo  TEXT,
    Status      TEXT,
    ClosedBy    TEXT,
    TimeClosed  TEXT,
    Notes       TEXT
)
STRICT;

CREATE TABLE NCR_CA (
    RowID        INTEGER PRIMARY KEY
                         NOT NULL,
    Owner        TEXT    COLLATE NOCASE,
    TaskName     TEXT,
    Status       TEXT,
    PlannedClose TEXT,
    ActualClosed TEXT
)
STRICT;

CREATE TABLE NCR_Contain (
    RowID        INTEGER PRIMARY KEY
                         NOT NULL,
    Owner        TEXT    COLLATE NOCASE,
    TaskName     TEXT,
    Status       TEXT,
    PlannedClose TEXT,
    ActualClosed TEXT
)
STRICT;

CREATE TABLE NCR_Dispo (
    RowID      INTEGER PRIMARY KEY
                       NOT NULL,
    NCR        TEXT    REFERENCES UniqueNCR (NCR) ON DELETE SET NULL
                                                  ON UPDATE CASCADE,
    TimeOpen   TEXT,
    TimeClosed TEXT,
    Status     TEXT
);


CREATE TABLE NCR_Files (
    RowID  INTEGER PRIMARY KEY
                   NOT NULL,
    NCR    TEXT    REFERENCES UniqueNCR (NCR) ON DELETE SET NULL
                                              ON UPDATE CASCADE,
    Name   TEXT    COLLATE NOCASE,
    Path   TEXT,
    Status TEXT
)
STRICT;

CREATE TABLE NCR_RCA_Files (
    RowID  INTEGER PRIMARY KEY
                   NOT NULL,
    NCR    TEXT    REFERENCES UniqueNCR (NCR) ON DELETE SET NULL
                                              ON UPDATE CASCADE,
    Name   TEXT    COLLATE NOCASE,
    Path   TEXT,
    Status TEXT
)
STRICT;

CREATE TABLE NCR_WorkOrder (
    RowID     INTEGER PRIMARY KEY
                      NOT NULL,
    NCR       TEXT    REFERENCES UniqueNCR (NCR) ON DELETE SET NULL
                                                 ON UPDATE CASCADE,
    WorkOrder TEXT    COLLATE NOCASE,
    Serial    TEXT    COLLATE NOCASE
)
STRICT;

CREATE TABLE Signature (
    RowID    INTEGER PRIMARY KEY
                     NOT NULL,
    NTID     TEXT    COLLATE NOCASE
                     NOT NULL,
    SignDate TEXT    NOT NULL,
    Source   TEXT    NOT NULL,
    SelfHash TEXT,
    Hint     TEXT,
    UsedOn   TEXT
)
STRICT;

CREATE TABLE UniqueNCR (
    NCR              TEXT    PRIMARY KEY
                             UNIQUE
                             NOT NULL
                             COLLATE NOCASE,
    Orginator        TEXT,
    Area             TEXT,
    PN_SN            TEXT,
    PO               TEXT,
    CoC              TEXT,
    ItemNo           ANY,
    Supplier         TEXT,
    StatmentNCR      BLOB,
    IssuedBy         TEXT,
    IssuedBySign     INTEGER,
    ProcessOwner     TEXT,
    ProcessOwnerSign INTEGER,
    RootCauseTxt     BLOB,
    ProcessComp      TEXT,
    ProcessCompSign  INTEGER,
    VerifedBy        TEXT,
    VerifiedBySign   INTEGER,
    DepartHead       TEXT,
    DepartHeadSign   INTEGER
)
WITHOUT ROWID,
STRICT;


", connection)) {
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
            }
        }


        public static void CreateDB() {
            using (SqliteConnection connection = CreateConnection("ProductionData")) {
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
    [Order]     INTEGER,
    Visible     INTEGER DEFAULT (1) 
)
STRICT;


CREATE TABLE ShopOrder (
    ShopOrder TEXT    PRIMARY KEY
                      NOT NULL
                      COLLATE NOCASE,
    PartID    INT     NOT NULL,
    Qty       INTEGER DEFAULT (1),
    Status    TEXT    DEFAULT Open
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

CREATE TABLE UniqueGroups (
    GroupID    TEXT    PRIMARY KEY
                       UNIQUE
                       NOT NULL
                       COLLATE NOCASE,
    Desription TEXT,
    Active     INTEGER DEFAULT (1) 
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
