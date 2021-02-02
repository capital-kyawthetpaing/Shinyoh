using BL;
using CKM_CommonFunction;
using ClosedXML.Excel;
using Entity;
using Shinyoh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace HacchuuSho
{
    public partial class HacchuuSho : BaseForm
    {
        BaseEntity be;
        CommonFunction cf;
        multipurposeEntity multi_Entity;
        BaseBL bbl = new BaseBL();
        HacchuuShoBL hsbl;
        public HacchuuSho()
        {
            InitializeComponent();
            cf = new CommonFunction();
            be = new BaseEntity();
            hsbl = new HacchuuShoBL();
        }

        private void HacchuuSho_Load(object sender, EventArgs e)
        {
            ProgramID = "HacchuuSho";
            StartProgram();
            cboMode.Bind(false, multi_Entity);
            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "", false);
            SetButton(ButtonType.BType.Update, F3, "", false);
            SetButton(ButtonType.BType.Delete, F4, "", false);
            SetButton(ButtonType.BType.Inquiry, F5, "", false);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", false);
            SetButton(ButtonType.BType.Save, F12, "", false);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            SetButton(ButtonType.BType.Empty, F8, "", false);
            SetButton(ButtonType.BType.ExcelExport, F10, "出力(F10)", true);
            SetButton(ButtonType.BType.Empty, F11, "", false);
            lblBrandName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            UI_ErrorCheck();
        }

        private void UI_ErrorCheck()
        {
            be = _GetBaseData();
            txtChangeDate.Text = be.LoginDate;
            txtJuchuuNO1.ChangeDate = txtChangeDate;
            txtJuchuuNO2.ChangeDate = txtChangeDate;
            txtHacchuuNO1.ChangeDate = txtChangeDate;
            txtHacchuuNO2.ChangeDate = txtChangeDate;
            txtBrandCD.lblName = lblBrandName;
            txtJuchuuNO1.Focus();
            Rdo1.Checked = true;
            txtJuchuuNO2.E106Check(true, txtJuchuuNO1, txtJuchuuNO2);
            txtHacchuuNO1.E106Check(true, txtHacchuuNO1, txtHacchuuNO2);
            txtInputDate1.E103Check(true);
            txtInputDate2.E103Check(true);
            txtInputDate2.E106Check(true, txtInputDate1, txtInputDate2);
            txtIssueDate.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            txtIssueDate.E103Check(true);
            txtKanriNO.E102Check(true);

            txtPayment.Text = hsbl.HCS_M_MultiPorpose_Type(1);
            txtBeneficiary1.Text= hsbl.HCS_M_MultiPorpose_Type(2);
            txtBeneficiary2.Text= hsbl.HCS_M_MultiPorpose_Type(3);
            txtOriginCountry.Text= hsbl.HCS_M_MultiPorpose_Type(4);
            txtDestination.Text= hsbl.HCS_M_MultiPorpose_Type(5);
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "6")
            {
                Rdo1.Checked = true;
                cf.Clear(PanelDetail);
                txtJuchuuNO1.Focus();
            }
            if (tagID == "10")
            {
                Excel_Export();
                //if (ErrorCheck(PanelDetail))
                //{
                //}

            }
        }

        private void txtBrandCD_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                multipurposeBL bl = new multipurposeBL();
                DataTable dt = bl.M_Multiporpose_SelectData(txtBrandCD.Text, 1, "103", string.Empty);
                if (dt.Rows.Count > 0)
                    lblBrandName.Text = dt.Rows[0]["Char1"].ToString();
            }
        }

        private void Excel_Export()
        {
        }

        private HacchuuShoEntity Get_UIData()
        {
            HacchuuShoEntity hse = new HacchuuShoEntity()
            {
                JuchuuNO1=txtJuchuuNO1.Text,
                JuchuuNO2=txtJuchuuNO2.Text,
                HacchuuNO1=txtHacchuuNO1.Text,
                HacchuuNO2=txtHacchuuNO2.Text,
                InputDate1=txtInputDate1.Text,
                InputDate2=txtInputDate2.Text,
                BrandCD=txtBrandCD.Text,
                YearTerm=txtYearTerm.Text,
                SS=chkSS.Checked?"1":"0",
                FW=chkFW.Checked?"1":"0",
                Rdo_Type=Rdo1.Checked?1:0
            };
                return hse;
        }
    }
}
