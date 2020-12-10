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
    public partial class Shouhin_Search : SearchBase
    {
        public string shouhinCD = string.Empty;
        public string changeDate = string.Empty;
        public string parent_changeDate;
        ShouhinBL shouhinbl = new ShouhinBL();
        public Shouhin_Search()
        {
            InitializeComponent();
        }

        private void Shouhin_Search_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);
            dgDetail.UseRowNo(true);
            dgDetail.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgDetail.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            BindDataGrid();
            if (string.IsNullOrWhiteSpace(parent_changeDate))
                txtChangeDate.Text = string.Format("{0:yyyy/MM/dd}", DateTime.Now);
            else
                txtChangeDate.Text = string.Format("{0:yyyy/MM/dd}", parent_changeDate);

            txtProduct1.E106Check(true, txtProduct, txtProduct1);
            txtJANCD1.E106Check(true, txtJANCD, txtJANCD1);
            txtExhibition1.E106Check(true, txtExhibition, txtExhibition1);
            txtBrand1.E106Check(true, txtBrand, txtBrand1);
        }

        private void dgDetail_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetGridviewData(dgDetail.Rows[e.RowIndex]);
        }

        public override void FunctionProcess(string tagID)
        {
            if (tagID == "2")
            {
                BindDataGrid();
            }
            if (tagID == "3")
            {
                DataGridViewRow row = dgDetail.CurrentRow;
                GetGridviewData(row);
            }
            base.FunctionProcess(tagID);
        }

        private void btn_F11_Click(object sender, EventArgs e)
        {
            FunctionProcess(btn_F11.Tag.ToString());
            BindDataGrid();
        }

        private void BindDataGrid()
        {
            ShouhinEntity shouhin = new ShouhinEntity();
            if (rdoRecentRevisionDate.Checked)
                shouhin.DisplayTarget = 0;
            else
                shouhin.DisplayTarget = 1;
            shouhin.RevisionDate = txtChangeDate.Text;
            shouhin.Product = txtProduct.Text;
            shouhin.Product1 = txtProduct1.Text;
            shouhin.JANCD = txtJANCD.Text;
            shouhin.JANCD1 = txtJANCD1.Text;
            shouhin.Remarks = txtRemarks.Text;
            shouhin.ProductName = txtProductName.Text;
            shouhin.Exhibition = txtExhibition.Text;
            shouhin.Exhibition1 = txtExhibition1.Text;
            shouhin.SS = chkSS.Checked ? "1" : "0";
            shouhin.FW = chkFW.Checked ? "1" : "0";
            shouhin.Color = txtColor.Text;
            shouhin.KatakanaName = txtKanaName.Text;
            shouhin.BrandCD = txtBrand.Text;
            shouhin.BrandCD1 = txtBrand1.Text;
            shouhin.Size = txtSize.Text;
            DataTable dt = shouhinbl.Shouhin_SearchData(shouhin);
            dgDetail.DataSource = dt;
        }

        private void GetGridviewData(DataGridViewRow gvrow)
        {
            if (gvrow != null)
            {
                DataGridViewRow row = gvrow;
                shouhinCD = row.Cells["ShouhinCD"].Value.ToString();
                changeDate = Convert.ToDateTime(row.Cells["ChangeDate"].Value.ToString()).ToString("yyyy/MM/dd");
                this.Close();
            }
        }
    }
}
