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
        public string renban = "0";
        public string seqno = string.Empty;
        public string prefix = string.Empty;

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
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);

            gvDenpyouNo.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopRight;
            gvDenpyouNo.UseRowNo(true);
            BindDataGrid();
            cbDivision2.E106Check(true, cbDivision1, cbDivision2);
           // lbl_Date.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FunctionProcess(btnSearch.Tag.ToString());
            BindDataGrid();
        }

        public override void FunctionProcess(string tagID)
        {
            if (tagID == "2")
            {
                BindDataGrid();
            }
            if (tagID == "3")
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
            //denpyou_entity.date = txtDate.Text;
            gvDenpyouNo.DataSource = denpyoubl.DenpyouNO_Search(denpyou_entity);
            DataTable dt = denpyoubl.DenpyouNO_Search(denpyou_entity);
            if (dt.Columns.Contains("CurrentDay"))
            {
                if (dt.Rows.Count > 0)
                {
                    lbl_Date.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["CurrentDay"]);
                    //dt.Columns.Remove("CurrentDay");
                }
            }
            dt.Columns.Remove("CurrentDay");
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
                this.Close();
            }
        }

        private void gvDenpyouNo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetGridviewData(gvDenpyouNo.Rows[e.RowIndex]);
        }

        private void cbDivision2_KeyDown(object sender, KeyEventArgs e)
        {
           // cbDivision2.E106Check(true, cbDivision1, cbDivision2);
        }
    }
}
