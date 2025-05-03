using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Collector.Quality
{
    public partial class NewNCR: Form
    {
        public NewNCR(string NCR=null)
        {
            InitializeComponent();

            tb_NCRID.Text = NCR;

        }

        private void NewNCR_Load(object sender, EventArgs e) {

            if (!string.IsNullOrWhiteSpace(tb_NCRID.Text)) {
                // Looks like we are going to do an update. 

                //Lets grab the NCR that matches what we are looking for.
                DataTable InputData = new DataTable();
                InputData.Columns.Add("Name", typeof(String));
                InputData.Columns.Add("ValueStr", typeof(string));
                InputData.Columns.Add("ValueInt", typeof(Int64));
                InputData.Columns.Add("ValueByte", typeof(byte[]));
                InputData.Columns.Add("Null", typeof(bool));

                InputData.Rows.Add("NCR", tb_NCRID.Text, null, null, false);
                DataTable GotNCRInfo=DataTools.QualityData.GetUniqueNCR(InputData);


                if (GotNCRInfo.Rows.Count > 0) {
                    //Fill in the Text Fields

                    
                    try {
                        char[] SplitString = tb_NCRID.Text.ToCharArray();
                        tb_dd.Text = SplitString[0].ToString() + SplitString[1].ToString();
                        tb_mm.Text = SplitString[2].ToString() + SplitString[3].ToString();
                        tb_yy.Text = SplitString[4].ToString() + SplitString[5].ToString();
                        tb_Seq1.Text = SplitString[6].ToString();
                        tb_Seq2.Text = SplitString[7].ToString();
                    } catch { };
                    //We got it on the hook lets populate the fields. 

                    string Orginator = GotNCRInfo.Rows[0].Field<string>("Orginator");
                    string Area = GotNCRInfo.Rows[0].Field<string>("Orginator");
                    string PN_SN = ""; //We need to loop though and create a JSON.
                    string PO = ""; //We need to loop though the PO list and provide a JSON.
                    string CoC = ""; // We need to look though the CoC list and jovide a JSON.
                    string ItemNo = GotNCRInfo.Rows[0].Field<string>("ItemNo");
                    string Supplier = GotNCRInfo.Rows[0].Field<string>("Supplier");
                    byte[] StatmentNCR = GotNCRInfo.Rows[0].Field<byte[]>("StatmentNCR");
                    string IssuedBy = GotNCRInfo.Rows[0].Field<string>("IssuedBy");
                    Int64? IssuedBySign = GotNCRInfo.Rows[0].Field<Int64?>("IssuedBySign");
                    string ProcessOwner = GotNCRInfo.Rows[0].Field<string>("ProcessOwner");
                    Int64? ProcessOwnerSign = GotNCRInfo.Rows[0].Field<Int64?>("ProcessOwnerSign");
                    byte[] RootCauseTxt = GotNCRInfo.Rows[0].Field<byte[]>("RootCauseTxt");
                    string ProcessComp = GotNCRInfo.Rows[0].Field<string>("ProcessComp");
                    Int64? ProcessCompSign = GotNCRInfo.Rows[0].Field<Int64?>("ProcessCompSign");
                    string VerifedBy = GotNCRInfo.Rows[0].Field<string>("VerifedBy");
                    Int64? VerifiedBySign = GotNCRInfo.Rows[0].Field<Int64?>("VerifiedBySign");
                    string DepartHead =     GotNCRInfo.Rows[0].Field<string>("DepartHead");
                    Int64? DepartHeadSign = GotNCRInfo.Rows[0].Field<Int64?>("DepartHeadSign");




                    cob_Orginator.Text= Orginator;
                    cob_Area.Text= Area;

                    tb_ItemNo.Text = ItemNo;
                    cob_Supplier.Text = Supplier;

                    rtb_Statement.Rtf= (StatmentNCR==null)?"":Encoding.Unicode.GetString(StatmentNCR);
                    tb_IssuedBy.Text = IssuedBy;
                    tb_IssuedBySig.Text = IssuedBySign.ToString();
                    tb_ProcessAckName.Text = ProcessOwner;
                    tb_ProcessAckSig.Text = ProcessOwnerSign.ToString();
                    
                    rtb_RootCause.Rtf= (RootCauseTxt == null) ? "" : Encoding.Unicode.GetString(RootCauseTxt);

                    tb_ProcessComName.Text = ProcessComp;
                    tb_ProcessComSig.Text = ProcessCompSign.ToString();
                    tb_VerfiedName.Text = VerifedBy;
                    tb_VerfiedSig.Text = VerifiedBySign.ToString();
                    tb_DeptHeadName.Text = DepartHead;
                    tb_DeptHeadSig.Text = DepartHeadSign.ToString();





                }



            }







        }

        private void gb_Section1_Enter(object sender, EventArgs e) {

        }

        private void brn_Save_Click(object sender, EventArgs e) {

            //Check that the following items are good to go.
            bool SaveNCR = true;



            //The required fields are 
            //tb_NCRID
            //

            string NCRID = tb_NCRID.Text.Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(NCRID)) {
                MessageBox.Show("Please provide a vaid NCRID");

            } else {
                //Okay we have a NCRID Lets now gather all relevant info we need to insert the NCR.
                string Orginator= cob_Orginator.Text;
                string Area = cob_Area.Text;
                string PN_SN = ""; //We need to loop though and create a JSON.
                string PO = ""; //We need to loop though the PO list and provide a JSON.
                string CoC = ""; // We need to look though the CoC list and jovide a JSON.
                string ItemNo = tb_ItemNo.Text;
                string Supplier = cob_Supplier.Text;
                byte[] StatmentNCR = Encoding.Unicode.GetBytes(rtb_Statement.Rtf);
                string IssuedBy = tb_IssuedBy.Text;
                string IssuedBySign = tb_IssuedBySig.Text;
                string ProcessOwner = tb_ProcessAckName.Text;
                string ProcessOwnerSign = tb_ProcessAckSig.Text;
                byte[] RootCauseTxt = Encoding.Unicode.GetBytes(rtb_RootCause.Rtf);
                string ProcessComp = tb_ProcessComName.Text;
                string ProcessCompSign = tb_ProcessComSig.Text;
                string VerifedBy = tb_VerfiedName.Text;
                string VerifiedBySign = tb_VerfiedSig.Text;
                string DepartHead = tb_DeptHeadName.Text;
                string DepartHeadSign = tb_DeptHeadSig.Text;

                //We have the Raw data now we need to save the NCR.

                //We are going to do an upsert so we can save save some headaches on my side...

                DataTable InputData = new DataTable();
                InputData.Columns.Add("Name", typeof(String));
                InputData.Columns.Add("ValueStr", typeof(string));
                InputData.Columns.Add("ValueInt", typeof(Int64));
                InputData.Columns.Add("ValueByte", typeof(byte[]));
                InputData.Columns.Add("Null", typeof(bool));

                InputData.Rows.Add("NCR", NCRID, null, null, false);
                InputData.Rows.Add("Orginator", Orginator, null, null, false);
                InputData.Rows.Add("Area", Area, null, null, false);
                InputData.Rows.Add("PN_SN", "SNTest", null, null, false);
                InputData.Rows.Add("PO", PO, null, null, false);
                InputData.Rows.Add("CoC", CoC, null, null, false);
                InputData.Rows.Add("ItemNo", ItemNo, null, null, false);
                InputData.Rows.Add("Supplier", Supplier, null, null, false);
                InputData.Rows.Add("StatmentNCR", null, null, StatmentNCR, false);
                InputData.Rows.Add("IssuedBy", IssuedBy, null, null, false);
                InputData.Rows.Add("IssuedBySign", null, Convert.ToInt64(IssuedBySign), null, false);
                InputData.Rows.Add("ProcessOwner", ProcessOwner, null, null, false);
                InputData.Rows.Add("ProcessOwnerSign", null, Convert.ToInt64(ProcessOwnerSign), null, false);
                InputData.Rows.Add("RootCauseTxt", null, null, RootCauseTxt, false);
                InputData.Rows.Add("ProcessComp", ProcessComp, null, null, false);
                InputData.Rows.Add("ProcessCompSign", null, Convert.ToInt64(ProcessCompSign), null, false);
                InputData.Rows.Add("VerifedBy", VerifedBy, null, null, false);
                InputData.Rows.Add("VerifiedBySign", null, Convert.ToInt64(VerifiedBySign), null, false);
                InputData.Rows.Add("DepartHead", DepartHead, null, null, false);
                InputData.Rows.Add("DepartHeadSign", null, Convert.ToInt64(DepartHeadSign), null, false);

                DataTools.QualityData.UpsertUniqueNCR(InputData);

                



                //We need to record all WOs or JCNs into an applicalbe table. 



                //We updated or instered the NCR lets get all the datagridview info into a home. 



            }






        }

        private void btn_Generate_Click(object sender, EventArgs e) {

            tb_dd.Text = DateTime.Now.ToString("dd");
            tb_mm.Text = DateTime.Now.ToString("MM");
            tb_yy.Text = DateTime.Now.ToString("yy");

            string StartSeq = tb_dd.Text + tb_mm.Text + tb_yy.Text;

            DataTable GotSimilarNCR = DataTools.QualityData.GetUniqueNCR_NCRStartWith(StartSeq);
            if (GotSimilarNCR.Rows.Count > 0) {
                string Seq = GotSimilarNCR.Rows[0].Field<string>("NCR").Substring(StartSeq.Length, 2);
                int int_Seq = Convert.ToInt32(Seq)+1;

                if (int_Seq < 100) {

                    char[] SplitSeq = int_Seq.ToString("00").ToCharArray();

                    tb_Seq1.Text = SplitSeq[0].ToString();
                    tb_Seq2.Text = SplitSeq[1].ToString();


                    tb_NCRID.Text = StartSeq + tb_Seq1.Text + tb_Seq2.Text;

                    //Lets bring a chain saw too a gun fight! I know it is over kill but sue me.........
                    DataTable InputData = new DataTable();
                    InputData.Columns.Add("Name", typeof(String));
                    InputData.Columns.Add("ValueStr", typeof(string));
                    InputData.Columns.Add("ValueInt", typeof(Int64));
                    InputData.Columns.Add("ValueByte", typeof(byte[]));
                    InputData.Columns.Add("Null", typeof(bool));

                    InputData.Rows.Add("NCR", tb_NCRID.Text, null, null, false);
                    DataTools.QualityData.UpsertUniqueNCR(InputData);


                } else {
                    //Wow it was a one bad day....

                    MessageBox.Show("There are " + (int_Seq - 1) + " NCRs that have been recorded.\n\nPlease confirm that this information is correct.");

                }

            }


        }
    }
}
