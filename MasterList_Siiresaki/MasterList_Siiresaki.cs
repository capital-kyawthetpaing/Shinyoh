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
using Excel = Microsoft.Office.Interop.Excel;

namespace MasterList_Siiresaki
{
    public partial class MasterList_Siiresaki : BaseForm
    {
        BaseEntity base_entity;
        CommonFunction cf;
        multipurposeEntity multi_Entity;
        BaseBL bbl = new BaseBL();
        DataTable dt = new DataTable();
        public MasterList_Siiresaki()
        {
            InitializeComponent();
            cf = new CommonFunction();
        }
        private void MasterList_Siiresaki_Load(object sender, EventArgs e)
        {
            ProgramID = "MasterList_Siiresaki";
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
            txtSiiresakiCD_From.Focus();
            txtSiiresakiCD_From.ChangeDate = txtChangeDate;
            txtSiiresakiCD_To.ChangeDate = txtChangeDate;
            UI_ErrorCheck();
        }
        private void UI_ErrorCheck()
        {
            txtSiiresakiCD_To.E106Check(true, txtSiiresakiCD_From, txtSiiresakiCD_To);
            txtYuubinNO2.E102MultiCheck(true, txtYuubinNO1, txtYuubinNO2);
            txtYuubinNO2.Yuubin_Juusho(true, txtYuubinNO1, txtYuubinNO2, string.Empty, string.Empty);
        }

        public override void FunctionProcess(string tagID)
        {
            if (tagID == "6")
            {
                cf.Clear(PanelDetail);
                txtSiiresakiCD_From.Focus();
            }
            if (tagID == "10")
            {
                if (ErrorCheck(PanelDetail))
                {
                    Excel_Export();
                    cf.Clear(PanelDetail);
                    txtSiiresakiCD_From.Focus();
                }
                    
            }
        }
        private void Excel_Export()
        {
            SiiresakiBL sbl = new SiiresakiBL();
            dt = sbl.Get_ExportData(Get_UIData());

            if (dt.Rows.Count > 0)
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Name = "得意先マスタリスト";

                for (int i = 1; i < dt.Columns.Count + 1; i++)
                {
                    xlWorkSheet.Cells[1, i] = dt.Columns[i - 1].ColumnName;
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        xlWorkSheet.Cells[i + 2, j + 1] = dt.Rows[i][j].ToString();
                    }
                }
                if (!System.IO.Directory.Exists("C:\\Output Excel Files"))
                    System.IO.Directory.CreateDirectory("C:\\Output Excel Files");
                xlWorkBook.SaveAs("C:\\Output Excel Files\\得意先マスタリスト.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);                xlApp.Quit();
            }
        }

        private SiiresakiEntity Get_UIData()
        {
            SiiresakiEntity ske = new SiiresakiEntity();
            if (rdo_RRevisionDate.Checked)
                ske.Output_Type = 0;
            else
                ske.Output_Type = 1;
            ske.SiiresakiCD_From = txtSiiresakiCD_From.Text;
            ske.SiiresakiCD_To = txtSiiresakiCD_To.Text;
            ske.SiiresakiRyakuName = txtSiiresakiName.Text;
            ske.YuubinNO1 = txtYuubinNO1.Text;
            ske.YuubinNO2 = txtYuubinNO2.Text;
            ske.Juusho1 = txtJuusho.Text;
            ske.Tel11 = txtPhNO1.Text;
            ske.Tel12 = txtPhNO2.Text;
            ske.Tel13 = txtPhNO3.Text;
            ske.Remarks = txtRemarks.Text;
            ske.ProgramID = ProgramID;
            return ske;
        }
    }
}
