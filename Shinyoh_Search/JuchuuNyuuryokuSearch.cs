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
    public partial class JuchuuNyuuryokuSearch : SearchBase
    {
        CommonFunction cf;
        public string JuchuuNo = string.Empty;
        public JuchuuNyuuryokuSearch(string JNO)
        {
            cf = new CommonFunction();           //Task no. 147 - tza
            InitializeComponent();
            txtJuchuuNoFrom.Text = txtJuchuuNoTo.Text = JNO;
        }

        private void JuchuuNyuuryokuSearch_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Normal, F9, "検索(F9)", false);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);
            lblTokuisakiRyakuName.BorderStyle= System.Windows.Forms.BorderStyle.None;
            lblStaffCD_Name.BorderStyle= System.Windows.Forms.BorderStyle.None;
            txtTokuisaki.ChangeDate = txtCurrentDate;
            txtTokuisaki.lblName = lblTokuisakiRyakuName;
            txtStaffCD.ChangeDate = txtCurrentDate;
            txtStaffCD.lblName = lblStaffCD_Name;
            ErrorCheck();
            gv_1.UseRowNo(true);
            gv_1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv_1.SetReadOnlyColumn("**");//readonly for search form 
            DataGridviewBind();
            gv_1.Select();
        }
        private void ErrorCheck()
        {
           
            txtJuchuuDateFrom.Focus();
            txtJuchuuDateFrom.E103Check(true);
            txtJuchuuDateTo.E103Check(true);
            txtJuchuuDateTo.E104Check(true, txtJuchuuDateFrom, txtJuchuuDateTo);
            txtTokuisaki.E101Check(true, "M_Tokuisaki", txtTokuisaki, txtCurrentDate, null);
            txtStaffCD.E101Check(true, "M_Staff", txtStaffCD, txtCurrentDate, null);
            txtJuchuuNoTo.E106Check(true, txtJuchuuNoFrom, txtJuchuuNoTo);
            txtHacchuNoTo.E106Check(true, txtHacchuNoFrom, txtHacchuNoTo);
            txtShouhinTo.E106Check(true, txtShouhinFrom, txtShouhinTo);
        }

        private void DataGridviewBind()
        {
            JuchuuNyuuryokuEntity obj = new JuchuuNyuuryokuEntity();
            if (cf.DateCheck(txtJuchuuDateFrom))           //Task no. 147 - tza
                obj.JuchuuDateFrom = txtJuchuuDateFrom.Text;
            if(cf.DateCheck(txtJuchuuDateTo))           //Task no. 147 - tza
                obj.JuchuuDateTo = txtJuchuuDateTo.Text;
            obj.TokuisakiCD = txtTokuisaki.Text;
            obj.StaffCD = txtStaffCD.Text;            
            obj.ShouhinName = txtShouhinName.Text;

            obj.JuchuuNoFrom = txtJuchuuNoFrom.Text;
            obj.JuchuuNoTo = txtJuchuuNoTo.Text;
            obj.HacchuNoFrom = txtHacchuNoFrom.Text;
            obj.HacchuNoTo = txtHacchuNoTo.Text;

            obj.ShouhinCDFrom = txtShouhinFrom.Text;
            obj.ShouhinCDTo = txtShouhinTo.Text;
            JuchuuNyuuryokuBL objMethod = new JuchuuNyuuryokuBL();
            if(ErrorCheck(panel1))           //Task no. 147 - tza
            {
                DataTable dt = objMethod.JuchuuNyuuryoku_Search(obj);
                if (dt.Columns.Contains("CurrentDay"))
                {
                    if (dt.Rows.Count > 0)
                    {
                        lbl_Date.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["CurrentDay"]);
                        txtCurrentDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["CurrentDay"]);
                    }
                }
                gv_1.DataSource = dt;
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
                JuchuuNo = row.Cells["colJuchuuNO"].Value.ToString();
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
