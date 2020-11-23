using BL;
using Entity;
using Shinyoh;
using System;
using System.Data;
using System.Windows.Forms;

namespace JuchuuList {
    public partial class JuchuuList : BaseForm {
        BaseEntity baseEntity;
        JuchuuListBL juchuuListBL;
        public JuchuuList()
        {
            InitializeComponent();
            baseEntity = new BaseEntity();
            juchuuListBL = new JuchuuListBL();
        }

        private void JuchuuList_Load(object sender, EventArgs e)
        {
           
            ProgramID = "JuchuuList";
            StartProgram();
            cboMode.Visible = false;
            txtOrderDate1.Focus();
            lblStaffCD_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblBrandName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtStaffCD.lblName = lblStaffCD_Name;

            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "新規(F2)", false);
            SetButton(ButtonType.BType.Update, F3, "修正(F3)", false);
            SetButton(ButtonType.BType.Delete, F4, "削除(F4)", false);
            SetButton(ButtonType.BType.Inquiry, F5, "照会(F5)", false);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", true);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", false);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            SetButton(ButtonType.BType.Empty, F8, "", false);
            SetButton(ButtonType.BType.Import, F10, "出力(F10)", true);
            SetButton(ButtonType.BType.Empty, F11, "", false);

            ErrorCheck();

            BaseEntity baseEntity = _GetBaseData();
            txtOrderDate1.Text = baseEntity.LoginDate;
            txtOrderDate2.Text = baseEntity.LoginDate;
            txtInputDate1.Text = baseEntity.LoginDate;
            txtInputDate2.Text = baseEntity.LoginDate;
            txtDate.Text = baseEntity.LoginDate;
        }
        private void ErrorCheck()
        {
           
            txtStaffCD.E101Check(true, "M_Staff", txtStaffCD,txtDate , null);
            txtTokuisaki.E101Check(true, "M_Tokuisaki", txtTokuisaki, txtDate, null);
            // txtStore.E101Check(true, "M_Kouriten", txtStore, txtDate, null);
           // txtBrand.E101Check(true, "JuchuuList", txtBrand, null, null);

            txtYubin2.E102MultiCheck(true, txtYubin1, txtYubin2);
            txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, string.Empty, string.Empty);

            txtOrderDate1.E102Check(true);
            txtOrderDate2.E102Check(true);
            txtOrderDate1.E103Check(true);
            txtOrderDate2.E103Check(true);
            txtOrderDate2.E104Check(true,txtOrderDate1, txtOrderDate2);

            txtInputDate1.E103Check(true);
            txtInputDate2.E103Check(true);
            txtInputDate2.E104Check(true, txtInputDate1, txtInputDate2);

            txtOrderNo2.E106Check(true, txtOrderNo1, txtOrderNo2);

        }
        private void txtBrand_KeyDown(object sender, KeyEventArgs e)
        {
            multipurposeBL bl = new multipurposeBL();
            string brandName = txtBrand.Text.ToString();
            DataTable dt = bl.M_Multiporpose_SelectData(brandName, 1,string.Empty,string.Empty);

            if (dt.Rows.Count > 0)
                lblBrandName.Text = dt.Rows[0]["Char1"].ToString();
        }

        private void txtYubin2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtYubin2.IsErrorOccurs && txtYubin2.IsDatatableOccurs.Rows.Count > 0)
                {
                    DataTable dt = txtYubin2.IsDatatableOccurs;
                    txtAddress.Text = dt.Rows[0]["Juusho1"].ToString();
                }
            }
        }
        private void txtTokuisaki_Leave(object sender, EventArgs e)
        {
            if (!txtTokuisaki.IsErrorOccurs)
            {
                TokuisakiBL bl = new TokuisakiBL();
                DataTable dt = bl.M_Tokuisaki_Select(txtTokuisaki.Text, string.Empty, string.Empty);

                if (dt.Rows[0]["ShokutiFLG"].ToString().Equals("1"))
                {
                    txtName.Enabled = true;
                    txtYubin1.Enabled = true;
                    txtYubin2.Enabled = true;
                    txtAddress.Enabled = true;
                    txtPhNo1.Enabled = true;
                    txtPhNo2.Enabled = true;
                    txtPhNo3.Enabled = true;
                }
                else
                {
                    txtName.Enabled = false;
                    txtYubin1.Enabled = false;
                    txtYubin2.Enabled = false;
                    txtAddress.Enabled = false;
                    txtPhNo1.Enabled = false;
                    txtPhNo2.Enabled = false;
                    txtPhNo3.Enabled = false;
                }
            }
        }
        private DataTable Get_Form_Object()
        {
            JuchuuEntity obj = new JuchuuEntity();
            obj.JuhuuDate1 = txtOrderDate1.Text;
            obj.JuhuuDate2 = txtOrderDate2.Text;
            obj.JuhuuNO1 = txtInputDate1.Text;
            obj.JuhuuNO2 = txtInputDate2.Text;
            obj.InputDate1 = txtInputDate1.Text;
            obj.InputDate2 = txtInputDate2.Text;
            obj.StaffCD = txtStaffCD.Text;
            obj.BrandCD = txtBrand.Text;
            obj.Year = txtYear.Text;
            obj.SS = chk_SS.Checked == true ? "1" : "0";
            obj.FW = chk_FW.Checked == true ? "1" : "0";
            obj.Store = txtStore.Text;
            obj.DestOrderNo = txtDestOrderNo.Text;
            obj.Name = txtName.Text;
            obj.YuubinNo1 = txtYubin1.Text;
            obj.YuubinNo2 = txtYubin2.Text;
            obj.Juusho = txtAddress.Text;
            obj.Tel1 = txtPhNo1.Text;
            obj.Tel2 = txtPhNo2.Text;
            obj.Tel3 = txtPhNo3.Text;

            TokuisakiBL bl = new TokuisakiBL();
            DataTable dt = bl.M_Tokuisaki_Select(txtTokuisaki.Text, string.Empty, string.Empty);

            if (dt.Rows[0]["ShokutiFLG"].ToString().Equals("1"))
            {
                obj.Condition = "Tokuisaki";
            }
            else obj.Condition = "Juchuu";
            obj.LoginDate = baseEntity.LoginDate;
            DataTable dataTable = juchuuListBL.JuchuuList_Excel(obj);
            return dataTable;
        }
    }
}
