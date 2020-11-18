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

namespace JuchuuList {
    public partial class JuchuuList : BaseForm {
        BaseEntity baseEntity=new BaseEntity();
        public JuchuuList()
        {
            InitializeComponent();
        }

        private void JuchuuList_Load(object sender, EventArgs e)
        {
            ProgramID = "JuchuuList";
            StartProgram();
            cboMode.Visible = false;
            txtOrderDate1.Focus();
            lblStaffCD_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblBrandName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblTokuisakiName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtStaffCD.lblName = lblStaffCD_Name;
           // string today = DateTime.Today.ToString("yyyy/MM/dd");
             txtOrderDate1.Text = baseEntity.LoginDate;
            //txtOrderDate2.Text = today;
            //txtInputDate1.Text = today;
            //txtInputDate2.Text = today;

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
        }
        private void ErrorCheck()
        {
            txtDate.Text = baseEntity.LoginDate;
            //txtStaffCD.E101Check(true, "M_Staff", txtStaffCD,null , null);
            txtTokuisaki.E101Check(true, "M_Tokuisaki", txtTokuisaki, txtDate, null);

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

        private void txtTokuisaki_KeyDown(object sender, KeyEventArgs e)
        
        {
            if (!txtTokuisaki.IsErrorOccurs)
            {
                TokuisakiBL bl = new TokuisakiBL();
                DataTable dt = bl.M_Tokuisaki_Select(txtTokuisaki.Text,txtDate.Text, "E101");
                if (dt.Rows[0]["ShokutiFLG"].ToString().Equals("0"))
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
    }
}
