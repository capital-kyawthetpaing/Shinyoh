using BL;
using CKM_CommonFunction;
using DocumentFormat.OpenXml.Vml;
using Entity;
using Shinyoh;
using System;
using System.CodeDom;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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
        string tmpPath = @"C:\DBConfig\Hacchuushou\imge.jpg";
        string tmpDir = @"C:\DBConfig\Hacchuushou\";
        string tmpSourceLogo = "C:\\DBConfig\\Hacchuushou\\SHINYOH_Logo.jpg";
        string tmpSave = @"C:\DBConfig\HacchuuShou\OutPut\";
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
            Rdo2.Checked = true;
            txtJuchuuNO2.E106Check(true, txtJuchuuNO1, txtJuchuuNO2);
            txtHacchuuNO1.E106Check(true, txtHacchuuNO1, txtHacchuuNO2);
            txtInputDate1.E103Check(true);
            txtInputDate2.E103Check(true);
            txtInputDate2.E106Check(true, txtInputDate1, txtInputDate2);
            txtIssueDate.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            txtIssueDate.E103Check(true);
           // txtKanriNO.E102Check(true);

            txtPayment.Text = hsbl.HCS_M_MultiPorpose_Type(1);
            txtBeneficiary1.Text= hsbl.HCS_M_MultiPorpose_Type(2);
            txtBeneficiary2.Text= hsbl.HCS_M_MultiPorpose_Type(3);
            txtOriginCountry.Text= hsbl.HCS_M_MultiPorpose_Type(4);
            txtDestination.Text= hsbl.HCS_M_MultiPorpose_Type(5);

            chkSS.Checked = true; //HET
            chkFW.Checked = true; //HET
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "6")
            {
                Rdo1.Checked = true;
                cf.Clear(PanelDetail);
                txtJuchuuNO1.Focus();
                chkSS.Checked = true; //HET
                chkFW.Checked = true; //HET
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
            #region Heading Part
            hsbl = new HacchuuShoBL();
            DataTable dt = new DataTable();
            dt = hsbl.Get_ExportData(Get_UIData());

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet = xlWorkBook.ActiveSheet;
            xlWorkSheet.Name = "発注書(PURCHASE ORDER)";

            xlApp.ActiveWindow.View = Excel.XlWindowView.xlPageBreakPreview;

            //xlWorkSheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
            try
            {
                xlWorkSheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLegal;
            }
            catch(Exception ex){
                var msg = ex.Message;
            }
            xlWorkSheet.PageSetup.PrintArea = "A1:U100";
            xlWorkSheet.PageSetup.Zoom = 40;

            xlWorkSheet.Cells[3, 6] = "RM605 6/F NANKAI SAKAIEKI BLDG.,";
            xlWorkSheet.Cells[4, 6] = "NO.3-22 EBISUJIMACHO, SAKAI-KU,";
            xlWorkSheet.Cells[5, 6] = "SAKAI-SHI, OSAKA, 590-0985, JAPAN";
            xlWorkSheet.Cells[6, 19] = "TEL :";
            xlWorkSheet.Cells[6, 20] = "81-72-229-2251";
            xlWorkSheet.Cells[7, 19] = "FAX : :";
            xlWorkSheet.Cells[7, 20] = "81-72-229-7830";
            xlWorkSheet.Cells[10, 6] = "PURCHASE ORDER ";
            //xlWorkSheet.Cells[12, 2] = "TO:   " + txtBeneficiary1.Text;
            //xlWorkSheet.Cells[12, 20] = "PO NO. FK-248:";
            //xlWorkSheet.Cells[13, 20] = "DATE. 8, April, 2020";
            //xlWorkSheet.Cells[14, 2] = "We thank for your cooperation related to our business.";
            //xlWorkSheet.Cells[15, 2] = "Here, we send our Purchase Order sheet for below items on the terms and conditions as under.";

            xlApp.get_Range("A1", "U100").Cells.Font.Name = "Times New Roman";
            xlApp.get_Range("I17", "S17").Cells.NumberFormat = "0.0";

            xlApp.get_Range("A1:U1", "A3:U3").Merge(Type.Missing);
            xlApp.get_Range("A4", "U4").Merge(Type.Missing);
            xlApp.get_Range("A5", "U5").Merge(Type.Missing);
            xlApp.get_Range("T6", "U6").Merge(Type.Missing);
            xlApp.get_Range("T7", "U7").Merge(Type.Missing);
            xlApp.get_Range("A10", "U10").Merge(Type.Missing);
            //xlApp.get_Range("B11:L11", "B13:L13").Merge(Type.Missing);
            //xlApp.get_Range("T12", "U12").Merge(Type.Missing);
            //xlApp.get_Range("T13", "U13").Merge(Type.Missing);
            //xlApp.get_Range("B14", "L14").Merge(Type.Missing);
            //xlApp.get_Range("B15", "L15").Merge(Type.Missing);
            //xlWorkSheet.get_Range("B14:L14", "B15:L15").Merge(Type.Missing);
            var Cell = (Excel.Range)xlWorkSheet.Cells[2, 1];
            Cell.RowHeight = 35;
            var Cell1 = (Excel.Range)xlWorkSheet.Cells[10, 1];
            Cell1.Font.Bold = true;
            Cell1.Font.Size = 20;
            Cell1.RowHeight = 50;
            xlWorkSheet.Columns[2].ColumnWidth = 10;
            xlWorkSheet.Columns[3].ColumnWidth = 20;
            xlWorkSheet.Columns[4].ColumnWidth = 15;
            xlWorkSheet.Columns[5].ColumnWidth = 20;
            xlWorkSheet.Columns[6].ColumnWidth = 20;
            xlWorkSheet.Columns[7].ColumnWidth = 15;
            xlWorkSheet.Columns[8].ColumnWidth = 15;
            xlWorkSheet.Columns[9].ColumnWidth = 5;
            xlWorkSheet.Columns[10].ColumnWidth = 5;
            xlWorkSheet.Columns[11].ColumnWidth = 5;
            xlWorkSheet.Columns[12].ColumnWidth = 5;
            xlWorkSheet.Columns[13].ColumnWidth = 5;
            xlWorkSheet.Columns[14].ColumnWidth = 5;
            xlWorkSheet.Columns[15].ColumnWidth = 5;
            xlWorkSheet.Columns[16].ColumnWidth = 5;
            xlWorkSheet.Columns[17].ColumnWidth = 5;
            xlWorkSheet.Columns[18].ColumnWidth = 5;
            xlWorkSheet.Columns[19].ColumnWidth = 5;
            xlWorkSheet.Columns[20].ColumnWidth = 5;
            xlWorkSheet.Columns[21].ColumnWidth = 15;

            xlWorkSheet.get_Range("A1:U1", "A5:U5").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            xlWorkSheet.get_Range("A10", "U10").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            xlWorkSheet.get_Range("A10", "U10").Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            xlWorkSheet.get_Range("A11", "H11").Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            xlWorkSheet.get_Range("A1:U1", "A3:U3").Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
            SetImage(1,6,"",xlWorkSheet,true);
            //xlWorkSheet.Shapes.AddPicture(path, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 380, 5, 250, 30);

            #endregion

            var dtsupplier = dt.Select("SiiresakiCD is not null").CopyToDataTable().AsEnumerable().Select(r => r.Field<string>("SiiresakiCD")).Distinct().ToList();
            
            int EndRow = 0; int col = 0;
            int startrow = 12;int gvrow = 17;
            if (Name != "")
            for (int j = 0; j < dtsupplier.Count(); j++)
            {
               
                string SiiresakiCD = dtsupplier[j].ToString();
                //if (SiiresakiCD == "3333")
                //{
                    var dtgv = dt.AsEnumerable().Where(s => s.Field<string>("SiiresakiCD") == SiiresakiCD).CopyToDataTable();
                    var dgv = dtgv.AsEnumerable().GroupBy(x => x.Field<string>("ColorNo") ,x=> x.Field<string>("ModelNo")).Count();  // get Model and Color
                    var dvresult= dtgv.AsEnumerable()
    .GroupBy(r => new { Col1 = r["ColorNo"], Col2 = r["ModelNo"] })
    .Select(g =>
    {
        var row = dt.NewRow();

        row["Pairs"] = g.Sum(r => r.Field<int>("Pairs"));
        row["Amount"] = g.Sum(r => r.Field<int>("Amount"));
        row["ColorNo"] = g.Key.Col1;
        row["ModelNo"] = g.Key.Col2;

        return row;

    })
    .CopyToDataTable();
                    //   var dgtv_Model_Color= dtgv.AsEnumerable().Select(c => c.Field<string>("ColorNo"))
                    #region Style top part
                    xlWorkSheet.Cells[startrow, 2] = "TO:   " + dtgv.Rows[0]["SiiresakiName"].ToString();
                    xlWorkSheet.Cells[startrow, 20] = "PO NO. FK-248:";
                    xlWorkSheet.Cells[startrow + 1, 20] = "DATE. 8, April, 2020";
                    xlWorkSheet.Cells[startrow + 2, 2] = "We thank for your cooperation related to our business.";
                    xlWorkSheet.Cells[startrow + 3, 2] = "Here, we send our Purchase Order sheet for below items on the terms and conditions as under.";
                    object st1 = "B" + (startrow) + ":L" + (startrow);
                    object st2 = "B" + (startrow + 1) + ":L" + (startrow + 1);
                    xlApp.get_Range(st1, st2).Merge(Type.Missing);
                    // xlApp.get_Range("B11:L11", "B13:L13").Merge(Type.Missing);
                    xlApp.get_Range("T" + startrow, "U" + startrow).Merge(Type.Missing);
                    xlApp.get_Range("T" + (startrow + 1), "U" + (startrow + 1)).Merge(Type.Missing);
                    xlApp.get_Range("B" + (startrow + 2), "L" + (startrow + 2)).Merge(Type.Missing);
                    xlApp.get_Range("B" + (startrow + 3), "L" + (startrow + 3)).Merge(Type.Missing);
                    xlWorkSheet.get_Range("A" + startrow, "L" + startrow).Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    #endregion
                    if (j == 0)
                    {
                        //  col = (gvrow + 1) + dtgv.Rows.Count;
                        col = (gvrow + 1) + dgv;
                        EndRow = col;
                    }
                    else
                    {
                        //  col = EndRow + dtgv.Rows.Count;
                        col = (gvrow + 1) + dgv;
                        EndRow = col;
                    }

                    #region Child Style
                    string idx = "A" + gvrow + ":U" + gvrow;
                    string idx1 = "B" + gvrow + ":U" + gvrow;
                    string s_value = "A" + col + ":U" + col;
                    string val1 = "A" + col + ":U" + col;
                    string val2 = "B" + col + ":U" + col;
                    xlWorkSheet.get_Range(idx, val1).Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    xlWorkSheet.get_Range(idx, val1).Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    xlWorkSheet.get_Range(idx1, val2).Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous;
                    xlWorkSheet.get_Range(idx, val2).Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

                    xlWorkSheet.get_Range("B" + gvrow, "U" + gvrow).Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = 3d;//row17
                    xlWorkSheet.get_Range("B" + gvrow, "U" + gvrow).Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 3d;//row17

                    xlApp.get_Range("U" + (gvrow + 1), "U" + col).Cells.NumberFormat = "$#,##0.00";
                    xlWorkSheet.get_Range("A" + (gvrow + 1) + ":U" + (gvrow + 1), val2).RowHeight = 40;
                    xlApp.get_Range("A17", "U" + col).Cells.Font.Name = "Arial";

                    xlWorkSheet.get_Range("B" + gvrow, "U" + col).Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = 3d;
                    xlWorkSheet.get_Range("B" + gvrow, "U" + col).Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = 3d;
                    xlWorkSheet.get_Range("B" + (col), "U" + (col)).Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 3d;//total

                    #endregion

                    #region Header Supplier
                    xlWorkSheet.Cells[gvrow, 2] = "Model No";
                    xlWorkSheet.Cells[gvrow, 3] = "Model Name";
                    xlWorkSheet.Cells[gvrow, 4] = "FOB PRICE";
                    xlWorkSheet.Cells[gvrow, 5] = "JAPAN Color";
                    xlWorkSheet.Cells[gvrow, 6] = "KOREA Color";
                    xlWorkSheet.Cells[gvrow, 7] = "Shipping place";
                    xlWorkSheet.Cells[gvrow, 8] = "IMAGE";
                    xlWorkSheet.Cells[gvrow, 9] = "23.0";
                    xlWorkSheet.Cells[gvrow, 10] = "23.5";
                    xlWorkSheet.Cells[gvrow, 11] = "24.0";
                    xlWorkSheet.Cells[gvrow, 12] = "24.5";
                    xlWorkSheet.Cells[gvrow, 13] = "25.0";
                    xlWorkSheet.Cells[gvrow, 14] = "25.5";
                    xlWorkSheet.Cells[gvrow, 15] = "26.0";
                    xlWorkSheet.Cells[gvrow, 16] = "26.5";
                    xlWorkSheet.Cells[gvrow, 17] = "27.0";
                    xlWorkSheet.Cells[gvrow, 18] = "27.5";
                    xlWorkSheet.Cells[gvrow, 19] = "28.0";
                    xlWorkSheet.Cells[gvrow, 20] = "Pairs";
                    xlWorkSheet.Cells[gvrow, 21] = "Amount";
                    xlWorkSheet.Cells[col, 8] = "TOTAL";
                    #endregion

                    #region Child Item
                    var modelno = ""; var otherModel = 0;var colorno = ""; var otherCkolor = "";
                    for (int h = 0; h < dtgv.Rows.Count; h++)
                    {
                        if (modelno != dtgv.Rows[h]["ModelNo"].ToString())
                        {
                            xlWorkSheet.Cells[gvrow + (otherModel + 1), 2] = dtgv.Rows[h]["ModelNo"].ToString();
                            xlWorkSheet.Cells[gvrow + (otherModel + 1), 3] = dtgv.Rows[h]["ModelName"].ToString();
                            xlWorkSheet.Cells[gvrow + (otherModel + 1), 4] = dtgv.Rows[h]["FOBPRICE"].ToString();
                            xlWorkSheet.Cells[gvrow + (otherModel + 1), 5] = dtgv.Rows[h]["JAPANColor"].ToString();
                            xlWorkSheet.Cells[gvrow + (otherModel + 1), 6] = dtgv.Rows[h]["KOREAColor"].ToString();
                            xlWorkSheet.Cells[gvrow + (otherModel + 1), 7] = dtgv.Rows[h]["Shippingplace"].ToString();
                            try
                            {
                                SettingImg(dtgv.Rows[h]["IMAGE"] as byte[]);
                                SetImage(gvrow + (otherModel + 1), 8, tmpPath, xlWorkSheet);
                            }
                            catch (Exception ex) { var msg = ex.Message; }
                            xlWorkSheet.Cells[gvrow + (otherModel + 1), 20] = dtgv.Rows[h]["Pairs"].ToString();
                            xlWorkSheet.Cells[gvrow + (otherModel + 1), 21] = dtgv.Rows[h]["Amount"].ToString();
                            modelno = dtgv.Rows[h]["ModelNo"].ToString();
                            colorno = dtgv.Rows[h]["ColorNo"].ToString();
                            otherModel++;
                        }
                        else if (modelno == dtgv.Rows[h]["ModelNo"].ToString() && colorno != dtgv.Rows[h]["ColorNo"].ToString())
                        {
                            xlWorkSheet.Cells[gvrow + (otherModel + 1), 2] = dtgv.Rows[h]["ModelNo"].ToString();
                            xlWorkSheet.Cells[gvrow + (otherModel + 1), 3] = dtgv.Rows[h]["ModelName"].ToString();
                            xlWorkSheet.Cells[gvrow + (otherModel + 1), 4] = dtgv.Rows[h]["FOBPRICE"].ToString();
                            xlWorkSheet.Cells[gvrow + (otherModel + 1), 5] = dtgv.Rows[h]["JAPANColor"].ToString();
                            xlWorkSheet.Cells[gvrow + (otherModel + 1), 6] = dtgv.Rows[h]["KOREAColor"].ToString();
                            xlWorkSheet.Cells[gvrow + (otherModel + 1), 7] = dtgv.Rows[h]["Shippingplace"].ToString();
                            try
                            {
                                SettingImg(dtgv.Rows[h]["IMAGE"] as byte[]);
                                SetImage(gvrow + (otherModel + 1), 8, @"‪C:\SMS\Hacchuushou\imge.jpg", xlWorkSheet);
                            }
                            catch (Exception ex) { var msg = ex.Message; }
                            xlWorkSheet.Cells[gvrow + (otherModel + 1), 20] = dtgv.Rows[h]["Pairs"].ToString();
                            xlWorkSheet.Cells[gvrow + (otherModel + 1), 21] = dtgv.Rows[h]["Amount"].ToString();
                            modelno = dtgv.Rows[h]["ModelNo"].ToString();
                            colorno = dtgv.Rows[h]["ColorNo"].ToString();
                            otherModel++;
                        }
                        xlWorkSheet.Cells[gvrow + (otherModel), GetSizeTitile(dtgv.Rows[h]["SizeNo"].ToString())] = dtgv.Rows[h]["HacchuuSuu"].ToString();
                    }
                    xlWorkSheet.Cells[col, 20].Formula =  "=Sum(" + xlWorkSheet.Cells[gvrow+1, 20].Address + ":" + xlWorkSheet.Cells[col-1, 20].Address + ")";
                    xlWorkSheet.Cells[col, 21].Formula = "=Sum(" + xlWorkSheet.Cells[gvrow + 1, 21].Address + ":" + xlWorkSheet.Cells[col - 1, 21].Address + ")";
                    #endregion
                    //xlWorkSheet.Rows[col+2].PageBreak = Excel.XlPageBreak.xlPageBreakManual;

                    startrow = col + 2;
                    EndRow = col + 6;
                    gvrow = col + 6;
                //}
            }

            xlWorkSheet.Cells[col+4,2]= "1.Terms of Payment :";
            xlWorkSheet.Cells[col + 4, 3] = "1.Terms of Payment :";
            xlApp.get_Range("C" + col + 4, "L" + col + 4).Merge(Type.Missing);
            var dtnow = DateTime.Now.ToString("yyyyMMdd HHmmss");
            var fname = dtnow.Replace(" ", "_") + "_" +  OperatorCD + "_" + "PurchaseOrder.xlsx";
            if (!Directory.Exists(tmpSave))
            {
                Directory.CreateDirectory(tmpSave); ;
            }
            xlWorkBook.SaveAs(tmpSave + fname, misValue, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            //MessageBox.Show("File created !");
            bbl.ShowMessage("I201", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            Process.Start(System.IO.Path.GetDirectoryName(tmpSave + fname));
        }
        private void SettingImg(byte[] bt)
        {
            if (!Directory.Exists(tmpDir))
            {
                Directory.CreateDirectory(tmpDir);
            }
            if (File.Exists(tmpPath))
            {
                File.Delete(tmpPath);
            }
            File.WriteAllBytes(tmpPath, bt);
        }
        private void SetImage(int r, int c, string path, Excel.Worksheet ws, bool IsLogo = false)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)ws.Cells[r, c];
                float Left = (float)((double)oRange.Left);
                float Top = (float)((double)oRange.Top);
                float ImageHeight = 32;
                float ImageWidth = 64;
                string filePath = string.Empty;
                if (Debugger.IsAttached)
                {
                    System.Uri u = new System.Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
                    filePath = System.IO.Path.GetDirectoryName(u.LocalPath).Replace("bin", "#").Split('#').First() + @"\HacchuuSho\Image\SHINYOH_Logo.jpg";
                }
                else
                    filePath = tmpSourceLogo;
                if (IsLogo)
                {
                    ImageHeight = 32;
                    ImageWidth = 250;
                    ws.Shapes.AddPicture(filePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left + (float)25, Top + (float)(2.5), ImageWidth, ImageHeight);
                }
                else
                    ws.Shapes.AddPicture(path, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left + (float)15, Top + (float)(2.5), ImageWidth, ImageHeight);
            }
            catch
            { 
            }
        }
        private int GetSizeTitile(String title )
        {
            var sizetitle = 0;
            if (title == "23.0")
            {
                sizetitle = 9;
            }
            else if (title == "23.5")
            {
                sizetitle = 10;
            }
            else if (title == "24.0")
            {
                sizetitle = 11;
            }
            else if (title == "24.5")
            {
                sizetitle = 12;
            }
            else if (title == "25.0")
            {
                sizetitle = 13;
            }
            else if (title == "25.5")
            {
                sizetitle = 14;
            }
            else if (title == "26.0")
            {
                sizetitle = 15;
            }
            else if (title == "26.5")
            {
                sizetitle = 16;
            }
            else if (title == "27.0")
            {
                sizetitle = 17;
            }
            else if (title == "27.5")
            {
                sizetitle = 18;
            }
            else if (title == "28.0")
            {
                sizetitle = 19;
            }
            
            return sizetitle; 
        }
        private string GetSize(DataTable dt, int r=0, string SizeNo="")
        {
            var val = "";
            try
            {
                val = dt.Rows[r][SizeNo].ToString();
            }
            catch { }
            return val;
        }
        private DataTable CreateTempdt()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ModelNo");
            dt.Columns.Add("ModelName");
            dt.Columns.Add("FOBPRICE");
            dt.Columns.Add("JAPANColor");
            dt.Columns.Add("KOREAColor");
            dt.Columns.Add("Shippingplace");
            dt.Columns.Add("IMAGE",typeof(byte));
            dt.Columns.Add("Pairs");
            dt.Columns.Add("Amount");
            dt.AcceptChanges();
            return dt;
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
                SS=chkSS.Checked?"1":"",
                FW=chkFW.Checked?"1":"",
                Rdo_Type=Rdo1.Checked?1:0
            };
            hse.OperatorCD = OperatorCD;
            hse.PC = PCID;
                return hse;
        }
    }
}
