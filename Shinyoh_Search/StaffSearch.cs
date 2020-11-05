using BL;
using Entity;
using Shinyoh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shinyoh_Search
{
    public partial class StaffSearch : SearchBase
    {
        public string staffCD = string.Empty;
        public string changeDate = string.Empty;
        public StaffSearch()
        {
            InitializeComponent();
        }

        private void StaffSearch_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);

            DataGridviewBind();
            txtStaff1.Focus();
        }

        private void txtStaff2_KeyDown(object sender, KeyEventArgs e)
        {
            txtStaff2.E106Check(true, txtStaff1, txtStaff2);
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "2")
            {
                DataGridviewBind();
            }
            if (tagID == "3")
            {
                DataGridViewRow row = gvStaff.CurrentRow;
                GetGridviewData(row);
            }
            base.FunctionProcess(tagID);
        }
        private void btnStaff_F11_Click(object sender, EventArgs e)
        {
            DataGridviewBind();
        }
        private void DataGridviewBind()
        {
            MasterTourokuStaff obj = new MasterTourokuStaff();
            obj.StaffCD = txtStaff1.Text;
            obj.Passward = txtStaff2.Text;//using tempory for assign data
            obj.StaffName = txtStaffName.Text;
            obj.KanaName = txtKanaName.Text;

            StaffBL objMethod = new StaffBL();
            DataTable dt = objMethod.Staff_Search(obj);
            gvStaff.DataSource = dt;
        }

        private void gvStaff_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
             GetGridviewData(gvStaff.Rows[e.RowIndex]);
        }
        private void GetGridviewData(DataGridViewRow gvrow)
        {
            if (gvrow != null)
            {
                DataGridViewRow row = gvrow;
                staffCD = row.Cells["colStaffCD"].Value.ToString();
                changeDate = Convert.ToDateTime(row.Cells["colChangeDate"].Value.ToString()).ToString("yyyy/MM/dd");// String.Format("{0:yyyy/MM/dd}", row.Cells["colChangeDate"].Value.ToString()); 
                this.Close();
            }
        }
    }
}
