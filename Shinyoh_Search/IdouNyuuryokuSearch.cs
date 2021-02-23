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
    public partial class IdouNyuuryokuSearch : SearchBase
    {
        CommonFunction cf;
        public string IdouNo = string.Empty;
        public IdouNyuuryokuSearch()
        {
            cf = new CommonFunction();           //Task no. 147 - tza
            InitializeComponent();
        }

        private void IdouNyuuryokuSearch_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);

            lblNyukoSouko.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblShukkosouko.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblStaff.BorderStyle = System.Windows.Forms.BorderStyle.None;

            ErrorCheck();

            gv_Idou.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv_Idou.UseRowNo(true);
            gv_Idou.SetGridDesign();
            gv_Idou.SetReadOnlyColumn("**");//readonly for search form 
            DataGridviewBind();
            gv_Idou.Select();
        }
        private void ErrorCheck()
        {
            txtDate1.Focus();
            txtDate1.E103Check(true);
            txtDate2.E103Check(true);
            txtDate2.E104Check(true, txtDate1, txtDate2);
            txtShukkosouko.E101Check(false, "souko", txtShukkosouko, null, null);
            txtNyukosouko.E101Check(false, "souko", txtNyukosouko, null, null);
            
            txtNo12.E106Check(true, txtNo11, txtNo12);
            txtStaffCD.E101Check(true, "M_Staff", txtStaffCD, txtCurrentDate, null);
            txtShouhin2.E106Check(true, txtShouhin1, txtShouhin2);
        }
        private void DataGridviewBind()
        {
            IdouNyuuryokuEntity obj = new IdouNyuuryokuEntity();

            if(cf.DateCheck(txtDate1))           //Task no. 147 - tza
                obj.Date1 = txtDate1.Text;
            if(cf.DateCheck(txtDate2))           //Task no. 147 - tza
                obj.Date2 = txtDate2.Text;

            obj.ShukkoSoukoCD = txtShukkosouko.Text;
            obj.NyuukoSoukoCD = txtNyukosouko.Text;
            obj.ShouhinName = txtShouhinName.Text;

            obj.IdouNO1 = txtNo11.Text;
            obj.IdouNO2 = txtNo12.Text;
            obj.StaffCD = txtStaffCD.Text;
            obj.ShouhinCD1 = txtShouhin1.Text;
            obj.ShouhinCD2 = txtShouhin2.Text;

            if(ErrorCheck(panel1))           //Task no. 147 - tza
            {
                IdouNyuuryokuBL objMethod = new IdouNyuuryokuBL();
                DataTable dt = objMethod.IdouNyuuryo_Search(obj);
                if (dt.Columns.Contains("CurrentDate"))
                {
                    if (dt.Rows.Count > 0)
                    {
                        lbl_Date.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["CurrentDate"]);
                        txtCurrentDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["CurrentDate"]);
                    }
                }
                gv_Idou.DataSource = dt;
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
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
                DataGridViewRow row = gv_Idou.CurrentRow;
                GetGridviewData(row);
            }
            base.FunctionProcess(tagID);
        }
        private void GetGridviewData(DataGridViewRow gvrow)
        {
            if (gvrow.DataBoundItem != null)
            {
                DataGridViewRow row = gvrow;
                IdouNo = row.Cells["colIdouNO"].Value.ToString();
            }
            this.Close();
        }

        private void txtStaffCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (!txtStaffCD.IsErrorOccurs)
            {
                DataTable dt = txtStaffCD.IsDatatableOccurs;
                if (dt.Rows.Count > 0)
                    lblStaff.Text = dt.Rows[0]["StaffName"].ToString();
            }
        }

        private void txtShukkosouko_KeyDown(object sender, KeyEventArgs e)
        {
            if (!txtShukkosouko.IsErrorOccurs)
            {
                DataTable dt = txtShukkosouko.IsDatatableOccurs;
                if (dt.Rows.Count > 0)
                    lblStaff.Text = dt.Rows[0]["SoukoName"].ToString();
            }
        }

        private void txtNyukosouko_KeyDown(object sender, KeyEventArgs e)
        {
            if (!txtShukkosouko.IsErrorOccurs)
            {
                DataTable dt = txtShukkosouko.IsDatatableOccurs;
                if (dt.Rows.Count > 0)
                    lblStaff.Text = dt.Rows[0]["SoukoName"].ToString();
            }
        }

        private void gv_Idou_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                GetGridviewData(gv_Idou.Rows[e.RowIndex]);
            }
        }

        private void gv_Idou_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (gv_Idou.CurrentCell != null)
                    GetGridviewData(gv_Idou.Rows[gv_Idou.CurrentCell.RowIndex]);
            }
        }
    }
}
