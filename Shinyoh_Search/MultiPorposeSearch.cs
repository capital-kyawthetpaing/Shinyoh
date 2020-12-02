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
    public partial class MultiPorposeSearch : SearchBase
    {
        public string Id = string.Empty;
        public string Key = string.Empty; 
        public MultiPorposeSearch()
        {
            InitializeComponent();
        }

        private void MultiPorposeSearch_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);

            gvMultiporpose.UseRowNo(true);
            GridViewBind();
            txtID1.Focus();
            txtID2.E106Check(true, txtID1, txtID2);
            txtKey2.E106Check(true, txtKey1, txtKey2);
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "2")
            {
                GridViewBind();
            }
            if (tagID == "3")
            {
                DataGridViewRow row = gvMultiporpose.CurrentRow;
                GetGridviewData(row);
                //GetGridviewData();
            }
            base.FunctionProcess(tagID);
        }
        private void GridViewBind()
        {
            multipurposeBL bl = new multipurposeBL();
            multipurposeEntity mentity = new multipurposeEntity();
            mentity.ID1 = txtID1.Text;
            mentity.ID2 = txtID2.Text;
            mentity.Key1 = txtKey1.Text;
            mentity.Key2 = txtKey2.Text;
            mentity.IdName = txtIDName.Text;
            DataTable dt = bl.M_Multiporpose_Search(mentity);
            gvMultiporpose.DataSource = dt;
        }
        private void GetGridviewData(DataGridViewRow gvrow)
        {
            if (gvrow.DataBoundItem != null)
            {
                DataGridViewRow row = gvrow;
                Id = gvMultiporpose.CurrentRow.Cells["colID"].Value.ToString();
                Key = gvMultiporpose.CurrentRow.Cells["colKey"].Value.ToString();
                this.Close();
            }
            //if (gvMultiporpose.CurrentRow != null && gvMultiporpose.CurrentRow.Index >= 0)
            //{
            //    Id = gvMultiporpose.CurrentRow.Cells["colID"].Value.ToString();
            //    Key = gvMultiporpose.CurrentRow.Cells["colKey"].Value.ToString();
            //    this.Close();
            //}
        }
        private void gvMultiporpose_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetGridviewData(gvMultiporpose.Rows[e.RowIndex]);
        }
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            //FunctionProcess(btnDisplay.Tag.ToString());
            GridViewBind();
        }
    }
}
