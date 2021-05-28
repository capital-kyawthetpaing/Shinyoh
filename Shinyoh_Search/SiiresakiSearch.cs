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
        public string SiiresakiName = string.Empty;

        public string Date_Access_Siiresaki;
        public SiiresakiSearch()
        {
            InitializeComponent();
        }

        private void SiiresakiSearch_Load(object sender, System.EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Normal, F9, "", false);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);

            rdo_Date.Focus();

            gvSupplier.UseRowNo(true);
            gvSupplier.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridviewBind();

            txtSupplier2.E106Check(true, txtSupplier1, txtSupplier2);
            gvSupplier.SetGridDesign();
            gvSupplier.SetReadOnlyColumn("**");//readonly for search form 
            gvSupplier.Select();
        }    

        private void btnSupplier_F11_Click(object sender, System.EventArgs e)
        {
            DataGridviewBind();
            gvSupplier.Select();
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "3")
            {
                DataGridviewBind();
                gvSupplier.Select();
            }
            if (tagID == "4")
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
            obj.ChangeDate = Date_Access_Siiresaki;
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
                if (dt.Rows.Count > 0)
                {
                    lbl_Date.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["CurrentDay"]);
                    //dt.Columns.Remove("CurrentDay");
                }
                else
                {
                    ClearSession();
                }
                dt.Columns.Remove("CurrentDay");
            }
            //dt.Columns.Remove("CurrentDay");
            gvSupplier.DataSource = dt;
        }

        private void ClearSession()
        {
            txtSupplier1.Clear();
            txtSupplier2.Clear();
            txtSupplierName.Clear();
            txtKanaName.Clear();
        }
        private void gvSupplier_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetGridviewData(gvSupplier.Rows[e.RowIndex]);
        }
        private void GetGridviewData(DataGridViewRow gvrow)
        {
            if (gvrow != null)
            {
                DataGridViewRow row = gvrow;
                SiiresakiCD = row.Cells["colSiiresakiCD"].Value.ToString();
                SiiresakiName = row.Cells["colSiiresakiName"].Value.ToString();
                changeDate = Convert.ToDateTime(row.Cells["colChangeDate"].Value.ToString()).ToString("yyyy/MM/dd");
            }
            this.Close();
        }

        private void gvSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (gvSupplier.CurrentCell != null)
                    GetGridviewData(gvSupplier.Rows[gvSupplier.CurrentCell.RowIndex]);
            }
        }
    }
}
