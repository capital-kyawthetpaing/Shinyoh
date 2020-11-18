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
            txtStaffCD.lblName = lblStaffCD_Name;
            string today = DateTime.Today.ToString("yyyy/MM/dd");
            txtOrderDate1.Text = today;
            txtOrderDate2.Text = today;
            txtInputDate1.Text = today;
            txtInputDate2.Text = today;

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
            //txtStaffCD.E101Check(true, "M_Staff", txtStaffCD, , null);

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
    }
}
