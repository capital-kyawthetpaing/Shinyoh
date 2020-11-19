using CKM_CommonFunction;
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

namespace HacchuuList
{
    public partial class HacchuuList : BaseForm
    {
        CommonFunction cf;
        public HacchuuList()
        {
            cf = new CommonFunction();
            InitializeComponent();
        }

        private void HacchuuList_Load(object sender, EventArgs e)
        {
            ProgramID = "HacchuuList";
            StartProgram();

            rdo_Hac.Focus();

            cboMode.Visible = false;

            lblStaff_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblBrand_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lbl_Title.BorderStyle = System.Windows.Forms.BorderStyle.None;


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
            txtHacchuuDate1.E102Check(true);
            txtHacchuuDate2.E102Check(true);
            txtHacchuuDate1.E103Check(true);
            txtHacchuuDate2.E103Check(true);
            txtHacchuuDate2.E104Check(true, txtHacchuuDate1, txtHacchuuDate2);
            txtHacchuuNO2.E106Check(true, txtHacchuuNO1, txtHacchuuNO2);
            txtUpdate_HacchuuDate1.E103Check(true);
            txtUpdate_HacchuuDate2.E103Check(true);
            txtUpdate_HacchuuDate2.E104Check(true, txtUpdate_HacchuuDate1, txtUpdate_HacchuuDate2);

            txtJuchuuDate1.E103Check(true);
            txtJuchuuDate2.E103Check(true);
            txtUpdate_JuchuuDate1.E103Check(true);
            txtUpdate_JuchuuDate2.E103Check(true);
            txtJuchuuDate2.E104Check(true, txtJuchuuDate1, txtJuchuuDate2);
            txtUpdate_JuchuuDate2.E106Check(true, txtUpdate_JuchuuDate1, txtUpdate_JuchuuDate2);

            txtJuchuuNO2.E106Check(true, txtJuchuuNO1, txtJuchuuNO2);

            //txtStaffCD.E101Check(true, "M_Staff", txtStaffCD, txtDate, null);
            //txtBrandCD.E101Check(true, "M_Tokuisaki", txtTokuisaki, txtDate, null);
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "6")
            {
                cf.Clear(Panel_Detail);
                rdo_Hac.Focus();
            }
            base.FunctionProcess(tagID);
        }
    }
}
