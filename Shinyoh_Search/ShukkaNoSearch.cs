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

namespace Shinyoh_Search {
    public partial class ShukkaNoSearch : SearchBase {
        CommonFunction cf;
        public string TokuisakiName = string.Empty;
        public string StaffName = string.Empty;
        public string ShukkaNo = string.Empty;
        public ShukkaNoSearch()
        {
            cf = new CommonFunction();           //Task no. 147 - tza
            InitializeComponent();
        }
        private void ShukkaNoSearch_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Normal, F9, "検索(F9)", false);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);

            lblTokuisaki_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblStaffName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txt_Tokuisaki.ChangeDate = txtCurrentDate;
            txt_Tokuisaki.lblName = lblTokuisaki_Name;
            txt_StaffCD.ChangeDate = txtCurrentDate;
            txt_StaffCD.lblName = lblStaffName;
            txtShukkaDate1.Focus();
            gvShukkaNo.UseRowNo(true);
            DataGridviewBind();
            gvShukkaNo.SetReadOnlyColumn("**");//readonly for search form 
            ErrorCheck();
            gvShukkaNo.Select();
            txtShouhin1.ChangeDate = txtCurrentDate; //2021 / 05 / 27 ssa CHG TaskNO 544
            txtShouhin2.ChangeDate = txtCurrentDate;//2021 / 05 / 27 ssa CHG TaskNO 544
        }
        private void ErrorCheck()
        {
            //出荷日
            txtShukkaDate1.E103Check(true);
            txtShukkaDate2.E103Check(true);
            txtShukkaDate2.E104Check(true, txtShukkaDate1, txtShukkaDate2);
            //得意先
            txt_Tokuisaki.E101Check(true, "M_Tokuisaki", txt_Tokuisaki, txtCurrentDate, null);
            //担当スタッフCD
            txt_StaffCD.E101Check(true, "M_Staff",txt_StaffCD, txtCurrentDate, null);
            //出荷番号			
            txtShukkaNo2.E106Check(true, txtShukkaNo1, txtShukkaNo2);
            //	出荷指示番号				
            txtShukkaSijiNo2.E106Check(true, txtShukkaSijiNo1, txtShukkaSijiNo2);
            //	商品CD		
            txtShouhin2.E106Check(true, txtShouhin1, txtShouhin2);
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "3")
            {
                DataGridviewBind();
            }
            if (tagID == "4")
            {
                DataGridViewRow row = gvShukkaNo.CurrentRow;
                GetGridviewData(row);
            }
            base.FunctionProcess(tagID);
        }
        private void DataGridviewBind()
        {
            ShukkaNyuuryokuEntity obj = new ShukkaNyuuryokuEntity();
            if(cf.DateCheck(txtShukkaDate1))           //Task no. 147 - tza
                obj.ShukkaDate1 = txtShukkaDate1.Text;
            if(cf.DateCheck(txtShukkaDate2))           //Task no. 147 - tza
                obj.ShukkaDate2 = txtShukkaDate2.Text;
            obj.TokuisakiCD = txt_Tokuisaki.Text;
            obj.StaffCD = txt_StaffCD.Text;
            obj.ShouhinName = txtShouhinName.Text;
            obj.ShukkaNO1 = txtShukkaNo1.Text;
            obj.ShukkaNO2 = txtShukkaNo2.Text;
            obj.ShukkaSiziNO1 = txtShukkaSijiNo1.Text;
            obj.ShukkaSiziNO2 = txtShukkaSijiNo2.Text;
            obj.ShouhinCD1 = txtShouhin1.Text;
            obj.ShouhinCD2 = txtShouhin2.Text;

            if(ErrorCheck(panel1))           //Task no. 147 - tza
            {
                ShukkaNyuuryokuBL sBL = new ShukkaNyuuryokuBL();
                DataTable dt = sBL.ShukkaNo_Search(obj);
                if (dt.Columns.Contains("CurrentDay"))
                {
                    if (dt.Rows.Count > 0)
                    {
                        lbl_Date.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["CurrentDay"]);
                        txtCurrentDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["CurrentDay"]);
                    }
                }
                else
                {
                    ClearSession();
                }
                dt.Columns.Remove("CurrentDay");
                gvShukkaNo.DataSource = dt;
            }
        }

        private void ClearSession()
        {
            txtShukkaDate1.Clear();
            txtShukkaDate2.Clear();
            txt_Tokuisaki.Clear();
            lblTokuisaki_Name.Text = string.Empty;
            txt_StaffCD.Clear();
            lblStaffName.Text = string.Empty;
            txtShouhinName.Clear();
            txtShukkaNo1.Clear();
            txtShukkaNo2.Clear();
            txtShukkaSijiNo1.Clear();
            txtShukkaSijiNo2.Clear();
            txtShouhin1.Clear();
            txtShouhin2.Clear();

        }
        private void GetGridviewData(DataGridViewRow gvrow)
        {
            if (gvrow != null)
            {
                DataGridViewRow row = gvrow;
                ShukkaNo = row.Cells["colShukkaNo"].Value.ToString();
            }
            this.Close();
        }

        private void gvShukkaNo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetGridviewData(gvShukkaNo.Rows[e.RowIndex]);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DataGridviewBind();
        }

        private void gvShukkaNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (gvShukkaNo.CurrentCell != null)
                {
                    GetGridviewData(gvShukkaNo.Rows[gvShukkaNo.CurrentCell.RowIndex]);
                }
            }
        }

        private void txt_Tokuisaki_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txt_Tokuisaki.IsErrorOccurs)
                {
                    DataTable dt = txt_Tokuisaki.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                    {
                        TokuisakiName = dt.Rows[0]["TokuisakiRyakuName"].ToString();
                        lblTokuisaki_Name.Text = TokuisakiName;
                    }
                    else
                    {
                        lblTokuisaki_Name.Text = string.Empty;
                    }
                }
            }
        }

        private void txt_StaffCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txt_StaffCD.IsErrorOccurs)
                {
                    DataTable dt = txt_StaffCD.IsDatatableOccurs;
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
    }
}
