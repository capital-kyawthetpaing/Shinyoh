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
using CKM_CommonFunction;

namespace Shinyoh_Search
{
    public partial class HacchuuNyuuryokuSearch : SearchBase
    {
        CommonFunction cf;
        public string HacchuuNo = string.Empty;
        public HacchuuNyuuryokuSearch()
        {
            cf = new CommonFunction();           //Task no. 147 - tza
            InitializeComponent();
        }

        private void HacchuuNyuuryokuSearch_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Normal, F9, "検索(F9)", false);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);
            lblSiiresakiRyakuName.BorderStyle= System.Windows.Forms.BorderStyle.None;
            lblStaffCD_Name.BorderStyle= System.Windows.Forms.BorderStyle.None;
            txtSiiresaki.ChangeDate = txtCurrentDate;
            txtSiiresaki.lblName = lblSiiresakiRyakuName;
            txtStaffCD.ChangeDate = txtCurrentDate;
            txtStaffCD.lblName = lblStaffCD_Name;
            txtShouhin1.ChangeDate = txtCurrentDate;        //TaskNo530 for shouhin HET
            txtShouhin2.ChangeDate = txtCurrentDate;        //TaskNo530 for shouhin HET
            ErrorCheck();
            gv_1.UseRowNo(true);
            gv_1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv_1.SetReadOnlyColumn("**");//readonly for search form 
            DataGridviewBind();
            gv_1.Select();
        }
        private void ErrorCheck()
        {           
            txtDate1.Focus();
            txtDate1.E103Check(true);
            txtDate2.E103Check(true);
            txtDate2.E104Check(true, txtDate1, txtDate2);
            txtSiiresaki.E101Check(true, "M_Siiresaki", txtSiiresaki, txtCurrentDate, null);
            txtStaffCD.E101Check(true, "M_Staff", txtStaffCD, txtCurrentDate, null);
            txtNo12.E106Check(true, txtNo11, txtNo12);
            txtNo22.E106Check(true, txtNo21, txtNo22);
            txtShouhin2.E106Check(true, txtShouhin1, txtShouhin2);
        }

        private void DataGridviewBind()
        {
            HacchuuNyuuryokuEntity obj = new HacchuuNyuuryokuEntity();

            if(cf.DateCheck(txtDate1))           //Task no. 147 - tza
                obj.Date1 = txtDate1.Text;
            if(cf.DateCheck(txtDate2))           //Task no. 147 - tza
                obj.Date2 = txtDate2.Text;

            obj.SiiresakiCD = txtSiiresaki.Text;
            obj.StaffCD = txtStaffCD.Text;            
            obj.ShouhinName = txtShouhinName.Text;

            obj.NO11 = txtNo11.Text;
            obj.NO12 = txtNo12.Text;
            obj.NO21 = txtNo21.Text;
            obj.NO22 = txtNo22.Text;

            obj.ShouhinCD1 = txtShouhin1.Text;
            obj.ShouhinCD2 = txtShouhin2.Text;
            HacchuuNyuuryokuBL objMethod = new HacchuuNyuuryokuBL();
            if(ErrorCheck(panel1))           //Task no. 147 - tza
            {
                DataTable dt = objMethod.HacchuuNyuuryoku_Search(obj);
                if (dt.Columns.Contains("CurrentDay"))
                {
                    if (dt.Rows.Count > 0)
                    {
                        lbl_Date.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["CurrentDay"]);
                        txtCurrentDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["CurrentDay"]);
                    }
                }
                gv_1.DataSource = dt;
                gv_1.Select();
            }
        }

        public override void FunctionProcess(string tagID)
        {
            if (tagID == "3")
            {
                DataGridviewBind();
            }
            if (tagID == "4")
            {
                DataGridViewRow row = gv_1.CurrentRow;
                GetGridviewData(row);
            }
            base.FunctionProcess(tagID);
        }
        private void GetGridviewData(DataGridViewRow gvrow)
        {
            if (gvrow.DataBoundItem != null)
            {
                DataGridViewRow row = gvrow;
                HacchuuNo = row.Cells["colHacchuuNO"].Value.ToString();
            }
            this.Close();
        }

        private void gv_1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                GetGridviewData(gv_1.Rows[e.RowIndex]);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DataGridviewBind();
        }

        private void gv_1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (gv_1.CurrentCell != null)
                    GetGridviewData(gv_1.Rows[gv_1.CurrentCell.RowIndex]);
            }
        }
    }
}
