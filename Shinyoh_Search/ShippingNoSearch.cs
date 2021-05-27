using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BL;
using Shinyoh;
using Shinyoh_Controls;
using Shinyoh_Search;
using CKM_CommonFunction;

namespace Shinyoh_Search
{
    public partial class ShippingNoSearch : SearchBase
    {
        CommonFunction cf;
        public string ShippingNo= string.Empty;
        public string TokuisakiName = string.Empty;
        public string StaffName = string.Empty;
        ShukkaSiziNyuuryokuEntity SKSZ_Entity;
        ShukkasiziNyuuryokuBL SKSZ_BL;
        public ShippingNoSearch()
        {
            cf = new CommonFunction();           //Task no. 147 - tza
            InitializeComponent();
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Normal, F9, "検索(F9)", false);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);
            lblTokuisakiRyakuName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblStaffName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtTokuisakiCD.ChangeDate = txtCurrentDate;
            txtTokuisakiCD.lblName = lblTokuisakiRyakuName;
            txtStaffCD.ChangeDate = txtCurrentDate;
            txtStaffCD.lblName = lblStaffName;
            gvShippingNo.SetGridDesign();
            txtShippingDateFrom.Focus();
            gvShippingNo.UseRowNo(true);
            gvShippingNo.SetReadOnlyColumn("**");//readonly for search form 
            lbl_Date.Text = String.Format("{0:yyyy/MM/dd}", DateTime.Now.ToString());
            txtCurrentDate.Text = String.Format("{0:yyyy/MM/dd}", DateTime.Now.ToString());
        }
        private void ShippingNoSearch_Load(object sender, EventArgs e)
        {
            GridViewBind();
            ErrorCheck();
        }
           
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "3")
            {
                GridViewBind();
            }
            if (tagID == "4")
            {
                DataGridViewRow row = gvShippingNo.CurrentRow;
                GetGridviewData(row);
            }
            base.FunctionProcess(tagID);
        }       
        private void ErrorCheck()
        {
            //出荷予定日            
            txtShippingDateFrom.E103Check(true);
            txtShippingDateTo.E103Check(true);
            txtShippingDateTo.E106Check(true, txtShippingDateFrom, txtShippingDateTo);
            //得意先
            txtTokuisakiCD.E101Check(true, "M_Tokuisaki", txtTokuisakiCD, txtShippingDateFrom, null);
            //担当スタッフ
            txtStaffCD.E101Check(true, "M_Staff", txtStaffCD, txtShippingDateFrom, null);
            //伝票日付
            txtSlipDateFrom.E103Check(true);
            txtSlipDateTo.E103Check(true);
            txtSlipDateTo.E106Check(true, txtSlipDateFrom, txtSlipDateTo);
            //出荷指示番号
            txtShippingNoTo.E106Check(true, txtShippingNoFrom, txtShippingNoTo);
            //商品CD
            txtProductTo.E106Check(true, txtProductFrom, txtProductTo);
        }
        private void GridViewBind()
        {     
            SKSZ_Entity = GetShukkasiziEntity();
            SKSZ_BL = new ShukkasiziNyuuryokuBL();
            DataTable dt = new DataTable();
            if(ErrorCheck(panel1))           //Task no. 147 - tza
            {
                dt = SKSZ_BL.ShippingNO_Search(SKSZ_Entity);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Columns.Contains("CurrentDay"))
                    {
                        txtCurrentDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["CurrentDay"]);
                        dt.Columns.Remove("CurrentDay");
                    }
                    gvShippingNo.DataSource = dt;
                }
            }
            
        }
        private ShukkaSiziNyuuryokuEntity GetShukkasiziEntity()
        {
            SKSZ_Entity = new ShukkaSiziNyuuryokuEntity();
            if(cf.DateCheck(txtShippingDateFrom))           //Task no. 147 - tza
                SKSZ_Entity.ShukkaYoteiDate_From = txtShippingDateFrom.Text;
            if(cf.DateCheck(txtShippingDateTo))            //Task no. 147 - tza
                SKSZ_Entity.ShukkaYoteiDate_To = txtShippingDateTo.Text;

            SKSZ_Entity.TokuisakiCD = txtTokuisakiCD.Text;
            SKSZ_Entity.StaffCD = txtStaffCD.Text;
            SKSZ_Entity.ShouhinName = txtProductName.Text;

            if(cf.DateCheck(txtSlipDateFrom))           //Task no. 147 - tza
                SKSZ_Entity.DenpyouDate_From = txtSlipDateFrom.Text;
            if(cf.DateCheck(txtSlipDateTo))             //Task no. 147 - tza
                SKSZ_Entity.DenpyouDate_To = txtSlipDateTo.Text;

            SKSZ_Entity.ShukkaSiziNO_From = txtShippingNoFrom.Text;
            SKSZ_Entity.ShukkaSiziNO_To = txtShippingNoTo.Text;
            SKSZ_Entity.ShouhinCD_From = txtProductFrom.Text;
            SKSZ_Entity.ShouhinCD_To = txtProductTo.Text;

            return SKSZ_Entity;
        }
        private void GetGridviewData(DataGridViewRow gvrow)
        {
            if (gvrow.DataBoundItem != null)
            {
                DataGridViewRow row = gvrow;
                ShippingNo = row.Cells["colShippingNO"].Value.ToString();                
            }            
            this.Close();
        }
        private void gvShippingNo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetGridviewData(gvShippingNo.Rows[e.RowIndex]);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            GridViewBind();
        }       
        private void txtTokuisakiCD_KeyDown(object sender, KeyEventArgs e)
        {
            lblTokuisakiRyakuName.Text = string.Empty;
            if (!txtTokuisakiCD.IsErrorOccurs)
            {
                DataTable dt = txtTokuisakiCD.IsDatatableOccurs;
                if (dt.Rows.Count > 0)
                {
                    lblTokuisakiRyakuName.Text = dt.Rows[0]["TokuisakiRyakuName"].ToString();
                }
            }
        }

        private void txtStaffCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtStaffCD.IsErrorOccurs)
                {
                    DataTable dt = txtStaffCD.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                    {
                        StaffName = dt.Rows[0]["StaffName"].ToString();
                        lblStaffName.Text = StaffName;
                    }
                    else
                    {
                        lblStaffName.Text = string.Empty;
                    }
                }
            }
        }

        private void gvShippingNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(gvShippingNo.CurrentCell!=null)
                {
                    GetGridviewData(gvShippingNo.Rows[gvShippingNo.CurrentCell.RowIndex]);
                }                
            }
        }
    }
}
