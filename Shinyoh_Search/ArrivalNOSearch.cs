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
    public partial class ArrivalNOSearch : SearchBase
    {
        public string ChakuniNO = string.Empty;
        public ArrivalNOSearch()
        {
            InitializeComponent();
        }

        private void ArrivalNOSearch_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);

            gvArrivalNo.UseRowNo(true);
            GridViewBind();
            txtDateFrom.Focus();
            txtDateFrom.E103Check(true);
            txtDateTo.E103Check(true);
            txtExpectedDateFrom.E103Check(true);
            txtExpectedDateTo.E103Check(true);
            txtExpectedDateTo.E106Check(true, txtExpectedDateFrom, txtExpectedDateTo);
            sbStaff.E101Check(true, "staff", null, null, null);
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "2")
            {
                GridViewBind();
            }
            if (tagID == "3")
            {
                DataGridViewRow row = gvArrivalNo.CurrentRow;
            }
            base.FunctionProcess(tagID);
        }
        private void GridViewBind()
        {
            chakuniNyuuryoku_BL ab = new chakuniNyuuryoku_BL();
            ChakuniNyuuryoku_Entity ane = new ChakuniNyuuryoku_Entity();
            ane.ChakuniDateFrom = txtDateFrom.Text;
            ane.ChakuniDateTo = txtDateTo.Text;
            ane.SiiresakiCD = sbSiiresaki.Text;
            ane.StaffCD = sbStaff.Text;
            ane.ShouhinName = txtProductName.Text;
            ane.ChakuniYoteiDateFrom = txtExpectedDateFrom.Text;
            ane.ChakuniYoteiDateTo = txtExpectedDateTo.Text;
            ane.KanriNOFrom = txtControlNoFrom.Text;
            ane.KanriNOTo = txtControlNoTo.Text;
            ane.ShouhinCDFrom = txtProductFrom.Text;
            ane.ShouhinCDTo = txtProductTo.Text;
            DataTable dt = ab.ArrivalNO_Search(ane);
            gvArrivalNo.DataSource = dt;
        }
        private void GetGridviewData(DataGridViewRow gvrow)
        {
            if (gvrow.DataBoundItem != null)
            {
                DataGridViewRow row = gvrow;
                ChakuniNO = row.Cells["colChakuniNO"].Value.ToString();
                this.Close();
            }
        }
        private void sButton2_Click(object sender, EventArgs e)
        {
            FunctionProcess(btnSearch.Tag.ToString());
            GridViewBind();
        }
        private void txtDateTo_KeyDown(object sender, KeyEventArgs e)
        {
            txtDateTo.E106Check(true, txtDateFrom, txtDateTo);
        }

        private void txtExpectedDateTo_KeyDown(object sender, KeyEventArgs e)
        {
            txtExpectedDateTo.E106Check(true, txtExpectedDateFrom, txtExpectedDateTo);
        }

        private void txtControlNoTo_KeyDown(object sender, KeyEventArgs e)
        {
            txtControlNoTo.E106Check(true, txtControlNoFrom, txtControlNoTo);
        }

        private void txtProductTo_KeyDown(object sender, KeyEventArgs e)
        {
            txtProductTo.E106Check(true, txtProductFrom, txtProductTo);
        }

        private void gvArrivalNo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetGridviewData(gvArrivalNo.Rows[e.RowIndex]);
        }
    }
}
