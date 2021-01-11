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
    public partial class ChakuniYoteiNyuuryokuSearch : SearchBase
    {
        public string ChakuniYoteiNO = string.Empty;
        public ChakuniYoteiNyuuryokuSearch()
        {
            InitializeComponent();
        }
        private void ChakuniYoteiNyuuryokuSearch_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);
            lblSiiresaki.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblStaff.BorderStyle = System.Windows.Forms.BorderStyle.None;
            gvChakuniYoteiNyuuryoku.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvChakuniYoteiNyuuryoku.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvChakuniYoteiNyuuryoku.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvChakuniYoteiNyuuryoku.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvChakuniYoteiNyuuryoku.UseRowNo(true);
            GridViewBind();
            gvChakuniYoteiNyuuryoku.SetGridDesign();
            gvChakuniYoteiNyuuryoku.SetReadOnlyColumn("**");
            gvChakuniYoteiNyuuryoku.Select();
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
                DataGridViewRow row = gvChakuniYoteiNyuuryoku.CurrentRow;
                GetGridviewData(row);
            }
            base.FunctionProcess(tagID);
        }
        private void GridViewBind()
        {
            ChakuniYoteiNyuuryoku_BL cb = new ChakuniYoteiNyuuryoku_BL();
            ChakuniYoteiNyuuryokuEntity cyn = new ChakuniYoteiNyuuryokuEntity();
            cyn.ChakuniYoteiDateFrom = txtDateFrom.Text;
            cyn.ChakuniYoteiDateTo = txtDateTo.Text;
            cyn.SiiresakiCD = sbSiiresaki.Text;
            cyn.StaffCD = sbStaff.Text;
            cyn.ShouhinName = txtShouhinName.Text;
            cyn.HacchuuDateFrom = txtOrderDateFrom.Text;
            cyn.HacchuuDateTo = txtOrderDateTo.Text;
            cyn.KanriNOFrom = txtControlNoFrom.Text;
            cyn.KanriNOTo = txtControlNoTo.Text;
            cyn.ShouhinCDFrom = txtShouhinCDFrom.Text;
            cyn.ShouhinCDTo = txtShouhinCDTo.Text;
            DataTable dt = cb.ChakuniYoteiNyuuryoku_Search(cyn);
            if (dt.Columns.Contains("CurrentDay"))
            {
                if (dt.Rows.Count > 0)
                {
                    lbl_Date.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["CurrentDay"]);
                    dt.Columns.Remove("CurrentDay");
                }
            }
            gvChakuniYoteiNyuuryoku.DataSource = dt;
        }
        public void ErrorCheck()
        {
            txtDateFrom.E103Check(true);
            txtDateTo.E103Check(true);
            txtDateTo.E104Check(true, txtDateFrom, txtDateTo);

            txtOrderDateFrom.E103Check(true);
            txtOrderDateTo.E103Check(true);
            txtOrderDateTo.E104Check(true, txtOrderDateFrom, txtOrderDateTo);

            txtControlNoTo.E106Check(true, txtControlNoFrom, txtControlNoTo);
            txtShouhinCDTo.E106Check(true, txtShouhinCDFrom, txtShouhinCDTo);

            sbSiiresaki.E101Check(true, "M_Siiresaki", null, null, null);
            sbStaff.E101Check(true, "staff", null, null, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GridViewBind();
        }
        private void GetGridviewData(DataGridViewRow gvrow)
        {
            if (gvrow.DataBoundItem != null)
            {
                DataGridViewRow row = gvrow;
                ChakuniYoteiNO = row.Cells["colChakuniYoteiNO"].Value.ToString();
            }
            this.Close();
        }
        private void gvChakuniYoteiNyuuryoku_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                GetGridviewData(gvChakuniYoteiNyuuryoku.Rows[e.RowIndex]);
            }
        }
        private void gvChakuniYoteiNyuuryoku_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (gvChakuniYoteiNyuuryoku.CurrentCell != null)
                    GetGridviewData(gvChakuniYoteiNyuuryoku.Rows[gvChakuniYoteiNyuuryoku.CurrentCell.RowIndex]);
            }
        }
    }
}
