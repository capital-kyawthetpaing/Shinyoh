using BL;
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

namespace ShukkaSiziDataShuturyoku {
    public partial class ShukkaSiziDataShuturyoku : BaseForm {
        BaseEntity baseEntity;
        CommonFunction cf;
        public ShukkaSiziDataShuturyoku()
        {
            InitializeComponent();
            baseEntity = _GetBaseData();
            cf = new CommonFunction();
        }

        private void ShukkaSiziDataShuturyoku_Load(object sender, EventArgs e)
        {
            ProgramID = "ShukkaSiziDataShuturyoku";
            StartProgram();
            cboMode.Visible = false;
            txtShukkaNo1.Focus();

            lblBrand_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblTokuisakiName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblKouritenName.BorderStyle = System.Windows.Forms.BorderStyle.None;

            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "新規(F2)", false);
            SetButton(ButtonType.BType.Update, F3, "修正(F3)", false);
            SetButton(ButtonType.BType.Delete, F4, "削除(F4)", false);
            SetButton(ButtonType.BType.Inquiry, F5, "照会(F5)", false);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", false);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", false);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            SetButton(ButtonType.BType.Empty, F8, "", false);
            SetButton(ButtonType.BType.Import, F10, "出力(F10)", true);
            SetButton(ButtonType.BType.Empty, F11, "", false);

            txtToukuisaki.lblName = lblTokuisakiName;
            txtKouriten.lblName = lblKouritenName;

            txtTempDate.Text = baseEntity.LoginDate;
            txtToukuisaki.ChangeDate = txtTempDate;
            txtKouriten.ChangeDate = txtTempDate;

            ErrorCheck();
        }
        private void ErrorCheck()
        {
            txtToukuisaki.E101Check(true, "M_Tokuisaki", txtToukuisaki, txtTempDate, null);
            txtKouriten.E101Check(true, "M_Kouriten", txtKouriten, txtTempDate, null);
            txtShukkaDate1.E103Check(true);
            txtShukkaDate2.E103Check(true);
            txtInputDate1.E103Check(true);
            txtInputDate2.E103Check(true);
            txtShukkaDate2.E104Check(true, txtShukkaDate1, txtShukkaDate2);
            txtInputDate2.E104Check(true, txtInputDate1, txtInputDate2);
            txtShukkaNo2.E106Check(true, txtShukkaNo1, txtShukkaNo2);
            
        }

        private void txtBrand_KeyDown(object sender, KeyEventArgs e)
        {
            multipurposeBL bl = new multipurposeBL();
            string brandName = txtBrand.Text.ToString();
            DataTable dt = bl.M_Multiporpose_SelectData(brandName, 1, string.Empty, string.Empty);

            if (dt.Rows.Count > 0)
                lblBrand_Name.Text = dt.Rows[0]["Char1"].ToString();
            else lblBrand_Name.Text = string.Empty;
        }
        private void Clear()
        {
            cf.Clear(Panel_Detail);
            txtShukkaNo1.Focus();
            lblBrand_Name.Text = "";
            lblTokuisakiName.Text = "";
            lblKouritenName.Text = "";
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "6")
            {
                Clear();
            }
            if (tagID == "10")
            {
            }
        }
    }
}
