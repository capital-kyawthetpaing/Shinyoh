using BL;
using CKM_CommonFunction;
using Entity;
using Shinyoh;
using Shinyoh_Search;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterList_Shouhin
{
    public partial class MasterList_Shouhin : BaseForm
    {
        BaseEntity base_entity;
        CommonFunction cf;
        multipurposeEntity multi_Entity;
        BaseBL bbl = new BaseBL();
        DataTable dtShouhin = new DataTable();
        public MasterList_Shouhin()
        {
            InitializeComponent();
            cf = new CommonFunction();
        }

        private void MasterList_Shouhin_Load(object sender, EventArgs e)
        {
            ProgramID = "MasterList_Shouhin";
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
            SetButton(ButtonType.BType.Import, F10, "出力(F10)", true);
            SetButton(ButtonType.BType.Empty, F11, "", false);

            base_entity = _GetBaseData();
            txtChangeDate.Text = base_entity.LoginDate;
            txtShouhinCD_From.Focus();
            txtShouhinCD_From.ChangeDate = txtChangeDate;
            txtShouhinCD_To.ChangeDate = txtChangeDate;
            UI_ErrorCheck();
        }

        private void UI_ErrorCheck()
        {
            txtShouhinCD_To.E106Check(true, txtShouhinCD_From, txtShouhinCD_To);
            txtJANCD_To.E106Check(true, txtJANCD_From, txtJANCD_To);
            txtBrand_To.E106Check(true, txtBrand_From, txtBrand_To);
            txtColor2.E106Check(true, txtColor1, txtColor2);
            txtSize2.E106Check(true, txtSize1, txtSize2);
        }

        public override void FunctionProcess(string tagID)
        {
            if (tagID == "6")
            {
                rdo_ChokkinDate.Checked = true;
                cf.Clear(PanelDetail);
                txtShouhinCD_From.Focus();
            }
            if (tagID == "10")
            {
                if (ErrorCheck(PanelDetail))
                {
                    Excel_Export();
                }

            }
        }

        private void Excel_Export()
        {
            ShouhinBL sh_bl = new ShouhinBL();
            dtShouhin = sh_bl.Get_ExportData(Get_UIData());
            if(dtShouhin.Rows.Count>0)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = @"C:\";
                saveFileDialog1.DefaultExt = "xls";
                saveFileDialog1.Filter = "ExcelFile|*.xls";
                saveFileDialog1.FileName = "受注リスト.xls";
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ExportCSVExcel excel = new ExportCSVExcel();
                    //excel.ExportDataTableToExcel(dtShouhin, saveFileDialog1);
                    //ExportDataTableToExcel(dt, saveFileDialog1.FileName);
                }
            }
        }
        private ShouhinEntity Get_UIData()
        {
            ShouhinEntity sh_e = new ShouhinEntity();
            if (rdo_ChokkinDate.Checked)
                sh_e.Output_Type = 0;
            else
                sh_e.Output_Type = 1;
            sh_e.ShouhinCD1 = txtShouhinCD_From.Text;
            sh_e.ShouhinCD2 = txtShouhinCD_To.Text;
            sh_e.JANCD = txtJANCD_From.Text;
            sh_e.JANCD1 = txtJANCD_To.Text;
            sh_e.ShouhinRyakuName = txtShouhinName.Text;
            sh_e.BrandCD = txtBrand_From.Text;
            sh_e.BrandCD1 = txtBrand_To.Text;
            sh_e.ColorNo1 = txtColor1.Text;
            sh_e.ColorNo2 = txtColor2.Text;
            sh_e.SizeNo1 = txtSize1.Text;
            sh_e.SizeNo2 = txtSize2.Text;
            sh_e.Remarks = txtRemarks.Text;
            sh_e.PC = PCID;
            sh_e.ProgramID = ProgramID;
            sh_e.InsertOperator = OperatorCD;
            return sh_e;
        }
    }
}
