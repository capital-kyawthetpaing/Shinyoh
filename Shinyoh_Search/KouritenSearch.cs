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
    public partial class KouritenSearch : SearchBase
    {
        public KouritenEntity Access_Kouriten_obj = new KouritenEntity();
        public string KouritenCD = string.Empty;
        public string changeDate = string.Empty;
        public string KouritenRyakuName = string.Empty;
        public string Date_Access_Kouriten = string.Empty;
        public string tokuisakiCD = string.Empty;
        public KouritenSearch()
        {
            InitializeComponent();
        }

        private void KouritenSearch_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Normal, F9, "", false);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);

            rdo_Date.Focus();
            gv_Kouriten.UseRowNo(true);
            gv_Kouriten.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //DataGridviewBind();
            txtCD2.E106Check(true, txtCD1, txtCD2);
            txtTokuisakiCD2.E106Check(true, txtTokuisakiCD1, txtTokuisakiCD2);

            gv_Kouriten.SetGridDesign();
            gv_Kouriten.SetReadOnlyColumn("**");//readonly for search form 
            gv_Kouriten.Select();
            Access_DB_Object(Access_Kouriten_obj);
            txtTokuisakiCD1.Text = tokuisakiCD;
            txtTokuisakiCD2.Text = tokuisakiCD;
            DataGridviewBind();
        }
        private void btnKouriten_F11_Click(object sender, EventArgs e)
        {
            DataGridviewBind();
            gv_Kouriten.Select();
        }
        private void DataGridviewBind()
        {
            KouritenEntity obj = new KouritenEntity();
            obj.KouritenCD = txtCD1.Text;
            obj.ChangeDate = Date_Access_Kouriten;
            obj.KouritenRyakuName = txtCD2.Text;//using tempory for assign data
            obj.KouritenName = txtName.Text;
            obj.KanaName = txtKanaName.Text;

            obj.TokuisakiCD = txtTokuisakiCD1.Text;
            obj.MailAddress = txtTokuisakiCD2.Text;
            obj.Juusho1 = txtTokuisakiName.Text;
            obj.Juusho2 = txtTokuisaki_Kana.Text;

            obj.Remarks = string.Empty;
            if (rdo_Date.Checked)
                obj.Remarks = "RevisionDate";
            if (rdo_All.Checked)
                obj.Remarks = "All";
            KouritenBL objMethod = new KouritenBL();
            DataTable dt = objMethod.Kouriten_Search(obj);
            if (dt.Columns.Contains("CurrentDay"))
            {
                if (dt.Rows.Count > 0)
                {
                    lbl_Date.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["CurrentDay"]);
                    //dt.Columns.Remove("CurrentDay");
                }
            }
            dt.Columns.Remove("CurrentDay");
            gv_Kouriten.DataSource = dt;
        }
        private void Access_DB_Object(KouritenEntity Access_Kouriten_obj)
        {
            txtTokuisakiCD1.Text = Access_Kouriten_obj.TokuisakiCD;
            txtTokuisakiCD2.Text = Access_Kouriten_obj.TokuisakiCD;
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "3")
            {
                DataGridviewBind();
                gv_Kouriten.Select();
            }
            if (tagID == "4")
            {
                DataGridViewRow row = gv_Kouriten.CurrentRow;
                GetGridviewData(row);
            }
            base.FunctionProcess(tagID);
        }

        private void GetGridviewData(DataGridViewRow gvrow)
        {
            if (gvrow != null)
            {
                DataGridViewRow row = gvrow;
                KouritenCD = row.Cells["colKouritenCD"].Value.ToString();
                changeDate = Convert.ToDateTime(row.Cells["colChangeDate"].Value.ToString()).ToString("yyyy/MM/dd");
                KouritenRyakuName = row.Cells["colKouritenRyakuName"].Value.ToString();
            }
            this.Close();
        }

        private void gv_Kouriten_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetGridviewData(gv_Kouriten.Rows[e.RowIndex]);
        }

        private void gv_Kouriten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (gv_Kouriten.CurrentCell != null)
                    GetGridviewData(gv_Kouriten.Rows[gv_Kouriten.CurrentCell.RowIndex]);
            }
        }
    }
}
