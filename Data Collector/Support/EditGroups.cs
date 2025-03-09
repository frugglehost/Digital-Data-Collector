using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Collector.Support {
    public partial class EditGroups : Form {
        public EditGroups() {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e) {

            string CurrentNTID = tb_NTID.Text.Trim().ToUpper();

            DataTable CurrentUserData = DataTools.DataMaster.GetUserGroup_UserID(CurrentNTID);

            for (int i = 0; i < list_Groups.Items.Count; i++) {
                string Name=list_Groups.Items[i].ToString();
                bool CheckTrue = list_Groups.GetItemChecked(i);

                bool foundold = false;
                foreach (DataRow CurrentDataRow in CurrentUserData.Rows) {
                    if (Name == CurrentDataRow.Field<string>("UserType")) {
                        foundold = true;
                    }
                }

                if (!foundold) {
                    //Do an Insert
                    DataTools.DataMaster.InsertUserGroup(CurrentNTID, Name, Convert.ToInt64(CheckTrue));
                } else {
                    //Do an Update
                    DataTools.DataMaster.UpdateUserGroup_UserTID_UserType(CurrentNTID, Name, Convert.ToInt64(CheckTrue));
                }



            }


            list_Groups.Enabled = !list_Groups.Enabled;
            tb_NTID.Enabled = !tb_NTID.Enabled;
            btn_Save.Enabled = !btn_Save.Enabled;
            tb_NTID.Text = "";



        }

        private void btn_Search_Click(object sender, EventArgs e) {

            for (int i = 0; i < list_Groups.Items.Count; i++) {
                list_Groups.SetItemChecked(i, false);
            }


            string CurrentNTID = tb_NTID.Text.Trim().ToUpper();
            DataTable CurrentUserData = DataTools.DataMaster.GetUserGroup_UserID(CurrentNTID);

            foreach (DataRow CurrentDataRow in CurrentUserData.Rows) {
                string Type = CurrentDataRow.Field<string>("UserType");
                if ( list_Groups.Items.Contains(Type)) {
                    
                    list_Groups.SetItemChecked(list_Groups.Items.IndexOf(Type), Convert.ToBoolean(CurrentDataRow.Field<Int64>("Active")));
                }

            }
            list_Groups.Enabled = !list_Groups.Enabled;
            tb_NTID.Enabled = !tb_NTID.Enabled;
            btn_Save.Enabled = !btn_Save.Enabled;



        }
    }
}
