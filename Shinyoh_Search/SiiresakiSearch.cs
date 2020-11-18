using BL;
using Entity;
using Shinyoh;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Shinyoh_Search
{
    public partial class SiiresakiSearch : SearchBase
    {
        public string SiiresakiCD = string.Empty;
        public string changeDate = string.Empty;
        public SiiresakiSearch()
        {
            InitializeComponent();
        }

        private void SiiresakiSearch_Load(object sender, System.EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);

            rdo_Date.Focus();

            gvSupplier.UseRowNo(true);
            gvSupplier.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;            
            DataGridviewBind();
        }

        private void txtSupplier2_KeyDown(object sender, KeyEventArgs e)
        {
            txtSupplier2.E106Check(true, txtSupplier1, txtSupplier2);
        }

        private void btnSupplier_F11_Click(object sender, System.EventArgs e)
        {
            DataGridviewBind();
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "2")
            {
                DataGridviewBind();
            }
            if (tagID == "3")
            {
                DataGridViewRow row = gvSupplier.CurrentRow;
                GetGridviewData(row);
            }
            base.FunctionProcess(tagID);
        }
        private void DataGridviewBind()
        {
            SiiresakiEntity obj = new SiiresakiEntity();
            obj.SiiresakiCD = txtSupplier1.Text;
            obj.SiiresakiRyakuName = txtSupplier2.Text;//using tempory for assign data
            obj.SiiresakiName = txtSupplierName.Text;
            obj.KanaName = txtKanaName.Text;
            obj.Remarks = string.Empty;
            if (rdo_Date.Checked)
                obj.Remarks = "RevisionDate";
            if (rdo_All.Checked)
                obj.Remarks = "All";
            SiiresakiBL objMethod = new SiiresakiBL();
            DataTable dt = objMethod.Siiresaki_Search(obj);
            if (dt.Columns.Contains("CurrentDay"))
            {
                lbl_Date.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["CurrentDay"]);
                dt.Columns.Remove("CurrentDay");
            }
            gvSupplier.DataSource = dt;
        }

        private void gvSupplier_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetGridviewData(gvSupplier.Rows[e.RowIndex]);
        }
        private void GetGridviewData(DataGridViewRow gvrow)
        {
            if (gvrow.DataBoundItem != null)
            {
                DataGridViewRow row = gvrow;
                SiiresakiCD = row.Cells["colSiiresakiCD"].Value.ToString();
                changeDate = Convert.ToDateTime(row.Cells["colChangeDate"].Value.ToString()).ToString("yyyy/MM/dd");
                this.Close();
            }
        }
    }
}
