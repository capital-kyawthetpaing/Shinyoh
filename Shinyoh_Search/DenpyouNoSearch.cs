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
        public static string division = "";
        public static string seqno = "";
        public static string prefix = "";

        public DenpyouNoSearch()
        {
            InitializeComponent(); 
            this.gvDenpyouNo.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gvDenpyouNo_RowPostPaint);
        }

        private void DenpyouNoSearch_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);
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
            denpyou_entity.date = txtDate.Text;
            gvDenpyouNo.DataSource = denpyoubl.DenpyouNO_Search(denpyou_entity);
        }

        private void gvDenpyouNo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > 0)
            {
                GetGridviewData(gvDenpyouNo.Rows[e.RowIndex]);
            }
        }

        private void GetGridviewData(DataGridViewRow gvrow)
        {
            if (gvrow != null)
            {
                DataGridViewRow row = gvrow;
                division = row.Cells[1].Value.ToString();
                seqno = row.Cells[2].Value.ToString();
                prefix = row.Cells[3].Value.ToString();
                this.Close();
            }
        }

        private void gvDenpyouNo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(gvDenpyouNo.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
