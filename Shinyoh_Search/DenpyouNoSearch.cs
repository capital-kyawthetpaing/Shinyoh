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
    public partial class DenpyouNoSearch : SearchBase
    {
        DenpyouNOBL denpyoubl;
        DenpyouNOEntity denpyou_entity;
        public string renban = string.Empty;
        public string seqno = string.Empty;
        public string prefix = string.Empty;
        public string renbanValue = string.Empty;

        public DenpyouNoSearch()
        {
            InitializeComponent();
        }

        private void DenpyouNoSearch_Load(object sender, EventArgs e)
        {
            multipurposeEntity multi_entity = new multipurposeEntity();
            multi_entity.id = 101;
            cbDivision1.Bind(true, multi_entity);
            cbDivision2.Bind(true, multi_entity);
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Normal, F9, "", false);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);

            gvDenpyouNo.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopRight;
            gvDenpyouNo.UseRowNo(true);
            gvDenpyouNo.SetGridDesign();
            gvDenpyouNo.SetReadOnlyColumn("**");//readonly for search form 
            BindDataGrid();
            cbDivision2.E106Check(true, cbDivision1, cbDivision2);
            gvDenpyouNo.Select();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FunctionProcess(btnSearch.Tag.ToString());
        }

        public override void FunctionProcess(string tagID)
        {
            if (tagID == "3")
            {
                BindDataGrid();
                gvDenpyouNo.Select();
            }
            if (tagID == "4")
            {
                DataGridViewRow row = gvDenpyouNo.CurrentRow;
                GetGridviewData(row);
            }
            base.FunctionProcess(tagID);
        }

        public void BindDataGrid()
        {
            denpyoubl = new DenpyouNOBL();
            denpyou_entity = new DenpyouNOEntity();
            denpyou_entity.division1 = cbDivision1.SelectedValue.ToString();
            denpyou_entity.division2 = cbDivision2.SelectedValue.ToString();
            gvDenpyouNo.DataSource = denpyoubl.DenpyouNO_Search(denpyou_entity);
            DataTable dt = denpyoubl.DenpyouNO_Search(denpyou_entity);
            if (dt.Columns.Contains("CurrentDay"))
            {
                if (dt.Rows.Count > 0)
                {
                    lbl_Date.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["CurrentDay"]);
                }
            }
            dt.Columns.Remove("CurrentDay");
            gvDenpyouNo.Columns[0].Visible = false;
            gvDenpyouNo.DataSource = dt;
        }

        private void GetGridviewData(DataGridViewRow gvrow)
        {
            if (gvrow != null)
            {
                DataGridViewRow row = gvrow;
                renban = row.Cells[0].Value.ToString();
                seqno = row.Cells[1].Value.ToString();
                prefix = row.Cells[2].Value.ToString();
            }
            this.Close();
        }

        private void gvDenpyouNo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetGridviewData(gvDenpyouNo.Rows[e.RowIndex]);
        }

        private void gvDenpyouNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (gvDenpyouNo.CurrentCell != null)
                    GetGridviewData(gvDenpyouNo.Rows[gvDenpyouNo.CurrentCell.RowIndex]);
            }
        }
    }
}
