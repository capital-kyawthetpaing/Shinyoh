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
            hsbl = new HacchuuShoBL();
            //DataTable dt = new DataTable();
            //dt = hsbl.Get_ExportData(Get_UIData());
            string FileName = "PURCHASEORDER" + txtKanriNO.Text;

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            xlWorkSheet.Cells[3, 6] = "RM605 6/F NANKAI SAKAIEKI BLDG.,";            
            xlWorkSheet.Cells[4, 6] = "NO.3-22 EBISUJIMACHO, SAKAI-KU,";
            xlWorkSheet.Cells[5, 6] = "SAKAI-SHI, OSAKA, 590-0985, JAPAN";
            xlWorkSheet.Cells[6, 19] = "TEL :";
            xlWorkSheet.Cells[6, 20] = "81-72-229-2251";
            xlWorkSheet.Cells[7, 19] = "FAX : :";
            xlWorkSheet.Cells[7, 20] = "81-72-229-7830";
            xlWorkSheet.Cells[10, 6] = "PURCHASE ORDER ";
            xlWorkSheet.Cells[12, 2] = "TO:   "+txtBeneficiary1.Text;
            xlWorkSheet.Cells[12, 20] = "PO NO. FK-248:";
            xlWorkSheet.Cells[13, 20] = "DATE. 8, April, 2020";
            xlWorkSheet.Cells[14, 2] = "We thank for your cooperation related to our business.";
            xlWorkSheet.Cells[15, 2] = "Here, we send our Purchase Order sheet for below items on the terms and conditions as under.";

            //Excel.Style style = xlWorkBook.Styles.Add("NewStyle");
            //style.Font.Name = "Arial";
            xlApp.get_Range("A1", "U15").Cells.Font.Name = "Times New Roman";
            xlApp.get_Range("A1:U1", "A3:U3").Merge(Type.Missing);
            xlApp.get_Range("A4", "U4").Merge(Type.Missing);
            xlApp.get_Range("A5", "U5").Merge(Type.Missing);
            xlApp.get_Range("T6", "U6").Merge(Type.Missing);
            xlApp.get_Range("T7", "U7").Merge(Type.Missing);
            xlApp.get_Range("A10", "U10").Merge(Type.Missing);
            xlApp.get_Range("B11:L11", "B13:L13").Merge(Type.Missing);
            xlApp.get_Range("T12", "U12").Merge(Type.Missing);
            xlApp.get_Range("T13", "U13").Merge(Type.Missing);
            xlApp.get_Range("B14", "L14").Merge(Type.Missing);
            xlApp.get_Range("B15", "L15").Merge(Type.Missing);
            var Cell = (Excel.Range)xlWorkSheet.Cells[2, 1];
            Cell.RowHeight = 35;
            var Cell1 = (Excel.Range)xlWorkSheet.Cells[10, 1];
            Cell1.Font.Bold = true;
            Cell1.Font.Size = 20;
            Cell1.RowHeight = 50;
            xlWorkSheet.get_Range("A1:U1", "A5:U5").Cells.HorizontalAlignment =Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            xlWorkSheet.get_Range("A10", "U10").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            xlWorkSheet.get_Range("A10", "U10").Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            xlWorkSheet.get_Range("A11", "H11").Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            //xlWorkSheet.get_Range("A11", "H11").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //xlWorkSheet.get_Range("A5", "U5").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //xlApp.get_Range("A1:U3").HorizontalAlignment = XLAlignmentHorizontalValues.Center;
            string path = @"D:\PROJ\ShinyohProject\Shinyoh\HacchuuSho\Image\SHINYOH_Logo.jpg";
            xlWorkSheet.Shapes.AddPicture(path, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue,380, 5, 250, 30);
            //xlApp.get_Range("B4:U4", Type.Missing).Merge(Type.Missing);
            //xlApp.get_Range("B5:U5", Type.Missing).Merge(Type.Missing);

            //xlApp.get_Range("A3:U3").HorizontalAlignment= XLAlignmentHorizontalValues.Center;

            //Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[8, 8];
            //float Left = (float)((double)oRange.Left);
            //float Top = (float)((double)oRange.Top);
            //const float ImageSize = 350;
            //xlWorkSheet.Shapes.AddPicture(path, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 100, 70, 500,40);

            xlWorkBook.SaveAs("MyExcelFile.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            MessageBox.Show("File created !");


            //if (dt.Rows.Count > 0)
            //{
            //    string folderPath = "C:\\ShinYoh\\" + ProgramID + "\\";
            //    if (!Directory.Exists(folderPath))
            //    {
            //        Directory.CreateDirectory(folderPath);
            //    }
            //    SaveFileDialog savedialog = new SaveFileDialog();
            //    savedialog.Filter = "Excel Files|*.xlsx;";
            //    savedialog.Title = "Save";
            //    savedialog.FileName = fname + ".xlsx";
            //    savedialog.InitialDirectory = folderPath;

            //    savedialog.RestoreDirectory = true;

            //    if (savedialog.ShowDialog() == DialogResult.OK)
            //    {
            //        if (Path.GetExtension(savedialog.FileName).Contains(".xlsx"))
            //        {
            //            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            //            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            //            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            //            worksheet = workbook.ActiveSheet;
            //            worksheet.Name = "Sheet1";

            //            using (var wb = new XLWorkbook())
            //            {
            //                var ws = wb.AddWorksheet("Sheet1");

            //                var imagePath = @"c:\path\to\your\image.jpg";
            //                var image = ws.AddPicture(imagePath)
            //                    .MoveTo(ws.Cell("B3").Address)
            //                    .Scale(.5); // optional: resize picture

            //                wb.SaveAs("file.xlsx");
            //            }
            //        }
            //    }

            //}
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
