using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Linq;
using System.IO;
using System.Security.Cryptography;

namespace Data_Collector.Engineering {
    public partial class ManageDocument : Form {
        public ManageDocument() {
            InitializeComponent();
        }

        private void ManageDocument_Load(object sender, EventArgs e) {

            DataTable UniqueDocs = DataTools.DataMaster.GetAllUniqueDocs();

            foreach (DataRow row in UniqueDocs.Rows) {
                cob_UniqueDocName.Items.Add(row["Name"]);
            }

        }

        private void btn_NewRev_Click(object sender, EventArgs e) {

            DataTable UniqueDocs = DataTools.DataMaster.GetRevbyUniqueDoc(cob_UniqueDocName.Text);
            Int64 int_Rev = 1;


            if (UniqueDocs.Rows.Count > 0) {
                //Lets go! We will add a new incremental Rev.

                int_Rev = UniqueDocs.Rows[0].Field<Int64>("Revison") + 1;


                



            } else {

                cob_UniqueDocName.Items.Add(cob_UniqueDocName.Text.Trim());
            }

            DataTable UniqueDocID = DataTools.DataMaster.InsertNewUniqueDoc(cob_UniqueDocName.Text.Trim(), int_Rev);

            cob_UniqueID_Leave(this, EventArgs.Empty);


            //We have a new rev. Lets make the engineer's life a bit easier and create new positions.

            if (int_Rev > 1) {

                Int64 DocID = UniqueDocID.Rows[0].Field<Int64>("last_insert_rowid()");

                Int64 OldDocID = UniqueDocs.Rows[0].Field<Int64>("DocID");

                DataTable AllInpsections = DataTools.DataMaster.GetInspCriteria(null, null, null, null, OldDocID);

                foreach(DataRow InspRows in AllInpsections.Rows) {
                    Int64 OldDataPointID = InspRows.Field<Int64>("DataPointID");
                    string DataPointName = InspRows.Field<string>("DataPointName");
                    string Description = InspRows.Field<string>("Description");
                    string Type = InspRows.Field<string>("Type");
                    
                    string DocPosition = InspRows.Field<string>("DocPosition");
                    string UserType = InspRows.Field<string>("UserType");
                    Int64 Mandatory = InspRows.Field<Int64>("Mandatory");
                    string Format = InspRows.Field<string>("Format");



                    DataTools.DataMaster.InsertInspCriteriaFull(DataPointName, Description, Type, DocID, DocPosition, UserType, Mandatory, Format, OldDataPointID);

                }



            }






            //tb_DocID.Text = UniqueDocID.Rows[0].Field<Int64>("last_insert_rowid()").ToString();
        }


        private void cob_Rev_SelectedIndexChanged(object sender, EventArgs e) {


            DataTable UniqueDocs = DataTools.DataMaster.GetUniqueDocIDbyPNandRev(cob_UniqueDocName.Text, Convert.ToInt64(cob_Rev.Text));

            if (UniqueDocs.Rows.Count ==1) {
                tb_DocID.Text = UniqueDocs.Rows[0].Field<Int64>("DocID").ToString();
                tb_Path.Text = UniqueDocs.Rows[0].Field<string>("Path");
                tb_FileName.Text = Path.GetFileName(tb_Path.Text);
            }

            CheckSaveStatus();
        }

        private void btn_Save_Click(object sender, EventArgs e) {



            DataTools.DataMaster.UpdateDocInfo(Convert.ToInt64(tb_DocID.Text),tb_Path.Text);

            cob_UniqueDocName.Text = "";
            tb_Path.Text = "";
            tb_FileName.Text = "";
            cob_UniqueDocName.SelectedIndex = -1;
            cob_UniqueDocName.Focus();
            cob_Rev.Items.Clear();

        }

        private void cob_UniqueID_SelectedIndexChanged(object sender, EventArgs e) {
            cob_UniqueID_Leave(this, EventArgs.Empty);
        }

        private void cob_UniqueID_Leave(object sender, EventArgs e) {
            cob_Rev.Items.Clear();

            foreach (string ItemData in cob_UniqueDocName.Items) {

                if (cob_UniqueDocName.Text.ToUpper().Trim() == ItemData.ToUpper().Trim()) {
                    cob_UniqueDocName.SelectedItem = ItemData;
                }

            }

            tb_DocID.Text = "";

            DataTable UniqueDocs = DataTools.DataMaster.GetRevbyUniqueDoc(cob_UniqueDocName.Text);
            cob_Rev.Items.Clear();
            foreach (DataRow row in UniqueDocs.Rows) {

                cob_Rev.Items.Add(row.Field<Int64>("Revison").ToString());
            }


            if (cob_Rev.Items.Count > 0) {
                cob_Rev.SelectedIndex = 0;
            }

            CheckSaveStatus();
        }
        private void CheckSaveStatus() {

            if (!string.IsNullOrWhiteSpace(tb_Path.Text) && !string.IsNullOrWhiteSpace(tb_DocID.Text)) {
                btn_Save.Enabled = true;
            } else {
                btn_Save.Enabled = false;
            }

        }

        private void btn_Change_Click(object sender, EventArgs e) {



            var fileContent = string.Empty;
            var filePath = string.Empty;

            

            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                if (!string.IsNullOrWhiteSpace(tb_Path.Text)) {
                    openFileDialog.InitialDirectory = Path.GetDirectoryName(tb_Path.Text);
                } else {
                    openFileDialog.InitialDirectory = "c:\\";
                }
                
                openFileDialog.Filter = "PDF (*.pdf)|*.pdf|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream)) {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            tb_Path.Text = filePath;
            tb_FileName.Text = Path.GetFileName(filePath);

            CheckSaveStatus();
        }
    }

}
