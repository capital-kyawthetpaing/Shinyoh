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
            gvArrivalNo.SetGridDesign();
            gvArrivalNo.SetReadOnlyColumn("*");
        }

        private void ArrivalNOSearch_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);
            lblSiiresaki.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblStaff.BorderStyle = System.Windows.Forms.BorderStyle.None;
            gvArrivalNo.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvArrivalNo.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvArrivalNo.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvArrivalNo.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvArrivalNo.UseRowNo(true);
            GridViewBind();
            txtDateFrom.Focus();
            ErrorCheck();
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
                GetGridviewData(row);
            }
            base.FunctionProcess(tagID);
        }
        public void ErrorCheck()
        {
            txtDateFrom.E103Check(true);
            txtDateTo.E103Check(true);
            txtDateTo.E106Check(true, txtDateFrom, txtDateTo);

            txtExpectedDateFrom.E103Check(true);
            txtExpectedDateTo.E103Check(true);
            txtExpectedDateTo.E106Check(true, txtExpectedDateFrom, txtExpectedDateTo);

            txtControlNoTo.E106Check(true, txtControlNoFrom, txtControlNoTo);
            txtProductTo.E106Check(true, txtProductFrom, txtProductTo);

            sbStaff.E101Check(true, "staff", null, null, null);
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
            if (dt.Columns.Contains("CurrentDay"))
            {
                if (dt.Rows.Count > 0)
                {
                    lbl_Date.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["CurrentDay"]);
                    dt.Columns.Remove("CurrentDay");
                }
            }
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
            //FunctionProcess(btnSearch.Tag.ToString());
            GridViewBind();
        }
        private void gvArrivalNo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetGridviewData(gvArrivalNo.Rows[e.RowIndex]);
        }
    }
}
