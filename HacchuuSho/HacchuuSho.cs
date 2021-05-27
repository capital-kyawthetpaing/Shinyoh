using BL;
using CKM_CommonFunction;
//using DocumentFormat.OpenXml.Drawing;
//using DocumentFormat.OpenXml.Vml;
using Entity;
using Microsoft.Office.Interop.Excel;
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
using DataTable = System.Data.DataTable;
using System.Text.RegularExpressions;
//using DocumentFormat.OpenXml.Office2010.Excel;
//using DocumentFormat.OpenXml.Spreadsheet;
//using System.Windows.Media;
//using DocumentFormat.OpenXml.Packaging;

namespace HacchuuSho
{
    public partial class HacchuuSho : BaseForm
    {
        BaseEntity be;
        CommonFunction cf;
        multipurposeEntity multi_Entity;
        BaseBL bbl = new BaseBL();
        HacchuuShoBL hsbl;
        string tmpPath = @"C:\ShinYoh\HacchuuSho\imge.jpg";
        string tmpDir = @"C:\ShinYoh\HacchuuSho\";
        string tmpSourceLogo = @"C:\ShinYoh\HacchuuSho\SHINYOH_Logo.jpg";
        string tmpSave = @"C:\ShinYoh\HacchuuSho\";
        byte[] headerLogo = null;
        static readonly Regex SheetNameForbiddenRegex = new Regex("[:\\\\?\\[\\]\\/*：￥＼？［］／＊]");
        const int MaxRow = 8;

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
            headerLogo  = bbl.GetLogo("101","1");
            SettingImg(headerLogo);
        }

        private void UI_ErrorCheck()
        {
            be = _GetBaseData();
            txtChangeDate.Text = be.LoginDate;
            txtInputDate1.Text = be.LoginDate;
            txtInputDate2.Text = be.LoginDate;
            chkFW.Checked = true;
            chkSS.Checked = true;

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
            
            txtIssueDate.E103Check(true);
            txtKanriNO.E102Check(true);

            txtPayment.Text = hsbl.HCS_M_MultiPorpose_Type(1);
            txtBeneficiary1.Text = hsbl.HCS_M_MultiPorpose_Type(2);
            txtBeneficiary2.Text = hsbl.HCS_M_MultiPorpose_Type(3);
            txtOriginCountry.Text = hsbl.HCS_M_MultiPorpose_Type(4);
            txtShipping.Text = hsbl.HCS_M_MultiPorpose_Type(5);
            txtDestination.Text = hsbl.HCS_M_MultiPorpose_Type(6);


            txtIssueDate.Text =DateTime.Now.ToString("yyyy/MM/dd");
            cboMode.SelectedIndex = 2;
            Rdo1.Focus();
            Rdo1.Select();
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "6")
            {
                //Rdo1.Checked = true;
                //cf.Clear(PanelDetail);
                //txtJuchuuNO1.Focus();
                Clear(); //HET
            }
            if (tagID == "10")
            {
                if (!ErrorCheckMain())
                {
                    txtKanriNO.Focus();
                    return;
                }
                Excel_Export();
                //if (ErrorCheck(PanelDetail))
                //{
                //}

            }
        }
        //HET
        private void Clear()
        {
            txtJuchuuNO1.Focus();
            Rdo1.Checked = true;
            
            cf.Clear(PanelDetail);
            txtIssueDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            txtPayment.Text = hsbl.HCS_M_MultiPorpose_Type(1);
            txtBeneficiary1.Text = hsbl.HCS_M_MultiPorpose_Type(2);
            txtBeneficiary2.Text = hsbl.HCS_M_MultiPorpose_Type(3);
            txtOriginCountry.Text = hsbl.HCS_M_MultiPorpose_Type(4);
            txtShipping.Text= hsbl.HCS_M_MultiPorpose_Type(5);
            txtDestination.Text = hsbl.HCS_M_MultiPorpose_Type(6);

            chkSS.Checked = true;
            chkFW.Checked = true;
            txtInputDate1.Text = be.LoginDate;
            txtInputDate2.Text = be.LoginDate;
            lblBrandName.Text = "";
        }
        private bool  ErrorCheckMain()
        {
            if (string.IsNullOrEmpty(txtKanriNO.Text))
            {
                bbl.ShowMessage("E102");
                return false;
            }
            
        string knrno=    SheetNameForbiddenRegex.Replace(txtKanriNO.Text, "");
            if(!txtKanriNO.Text.Equals(knrno))
            {
                bbl.ShowMessage("E118");
                return false;
            }
            return true;
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
        private string GetDate(string dt)
        {
            var res = "";
            try
            {
                var date = Convert.ToDateTime(dt);
                //res = date.Day.ToString() + "," + date.ToString("MMMM") + "," + date.Year.ToString();
                res = date.Day.ToString() + ", " + date.ToString("MMM", System.Globalization.CultureInfo.InvariantCulture) + ", " + date.Year.ToString();
            }
            catch
            {

            }
            return res;
        }
        private void Excel_Export()
        {
            #region Coolumn Style
            hsbl = new HacchuuShoBL();
            DataTable dt = new DataTable();
            dt = hsbl.Get_ExportData(Get_UIData());
            if (dt.Rows.Count == 0)
            {
                bbl.ShowMessage("S013"); //HET
                return;
            }
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet = xlWorkBook.ActiveSheet;
            //xlWorkSheet.Name = "発注書(PURCHASE ORDER)";
            xlWorkSheet.Name = txtKanriNO.Text;//ssa
            xlApp.DisplayAlerts = false;
            if (!Directory.Exists(tmpSave))
            {
                Directory.CreateDirectory(tmpSave); ;
            }
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Filter = "Excel Files|*.xlsx;";
            savedialog.Title = "Save";
            savedialog.FileName = "PURCHASE_ORDER" + "_" + txtKanriNO.Text + ".xlsx"; 
            savedialog.InitialDirectory = tmpSave;
            savedialog.RestoreDirectory = true;
            try
            {
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    if (Path.GetExtension(savedialog.FileName).Contains(".xlsx"))
                    {
                        //            try
                        //{
                        //xlWorkSheet.PageSetup.PrintArea = "A1:V1000";
                        xlWorkSheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;//Page horizontal
                        xlWorkSheet.PageSetup.Zoom = 75; //page setting when printing, a few percent of the scale
                        xlWorkSheet.PageSetup.Zoom = false; //Page setting when printing, must be set to false, page height, page width is valid
                                                            //try
                                                            //{
                        xlWorkSheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;//paper size
                                                                                                               //}
                                                                                                               //catch { }
                        xlWorkSheet.PageSetup.FitToPagesWide = 1; //Set the page width of the page to be 1 page wide
                        xlWorkSheet.PageSetup.FitToPagesTall = false; //Set the page height of the page zoom automatically
                                                                      //}
                                                                      //catch (Exception ex)
                                                                      //{
                                                                      //    var msg = ex.Message;
                                                                      //}

                        xlApp.ActiveWindow.View = Excel.XlWindowView.xlNormalView;
                        xlApp.ActiveWindow.DisplayGridlines = false;

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
                        xlWorkSheet.Columns[20].ColumnWidth = 10;
                        xlWorkSheet.Columns[21].ColumnWidth = 15;

                        #endregion

                        var dtsupplier = dt.Select("SiiresakiCD is not null").CopyToDataTable().AsEnumerable().Select(r => r.Field<string>("SiiresakiCD")).Distinct().ToList();

                        int col = 0; int startrow = 12; int gvrow = 17;
                        for (int j = 0; j < dtsupplier.Count(); j++)
                        {
                            int pageCount = 1;

                            //if (j > 0) break;
                            SetHeader(xlWorkSheet, dt, xlApp, col);

                            string SiiresakiCD = dtsupplier[j].ToString();

                            var dtgv = dt.AsEnumerable().Where(s => s.Field<string>("SiiresakiCD") == SiiresakiCD).CopyToDataTable();
                            var dgv = dtgv.AsEnumerable().GroupBy(x => x.Field<string>("ColorNo"), x => x.Field<string>("ModelNo")).Count();  // get Model and Color
                            //「FLOOR、MEMO」で Distinct したレコードを取得
                            var dtDis = dtgv.DefaultView.ToTable(true, "ColorNo", "ModelNo");
                            dgv = dtDis.Rows.Count;

                            var dvresult = dtgv.AsEnumerable().GroupBy(r => new { Col1 = r["ColorNo"], Col2 = r["ModelNo"] }).Select(g => {
                                var row = dt.NewRow();
                                row["Pairs"] = g.Sum(r => r.Field<int>("Pairs"));
                                row["Amount"] = g.Sum(r => r.Field<decimal>("Amount"));
                                row["ColorNo"] = g.Key.Col1;
                                row["ModelNo"] = g.Key.Col2;
                                return row;
                            }).CopyToDataTable();

                            #region Style top part
                            SetStyleTopPart(xlWorkSheet, startrow, dtgv, xlApp);
                            #endregion

                            //col = (gvrow + 1) + dgv;
                            col = gvrow + 1 + MaxRow;
                            #region Child Style
                            SetChildStyle(xlWorkSheet, gvrow, col, xlApp);
                            #endregion

                            #region Header Supplier
                            SetHeaderSupplier(xlWorkSheet, gvrow);                            
                            #endregion

                            #region Child Item
                            var modelno = ""; var otherModel = 0; var colorno = ""; var otherCkolor = "";
                            double sum1 = 0; double sum2 = 0;
                            //ShiiresakiCD毎の件数
                            for (int h = 0; h < dtgv.Rows.Count; h++)
                            {
                                //改ページ条件
                                if ((modelno != dtgv.Rows[h]["ModelNo"].ToString() || colorno != dtgv.Rows[h]["ColorNo"].ToString())　&& otherModel >0 && otherModel % MaxRow == 0)
                                {
                                    pageCount++;

                                    //最終ページでない場合
                                    if (h != dtgv.Rows.Count - 1)
                                    {
                                        xlWorkSheet.get_Range("B" + (gvrow), "U" + (gvrow)).Interior.Color = System.Drawing.ColorTranslator.FromHtml("#FFF2CC");
                                        xlWorkSheet.Cells[col, 20].Formula = "=Sum(" + xlWorkSheet.Cells[gvrow + 1, 20].Address + ":" + xlWorkSheet.Cells[col - 1, 20].Address + ")";
                                        xlWorkSheet.Cells[col, 21].Formula = "=Sum(" + xlWorkSheet.Cells[gvrow + 1, 21].Address + ":" + xlWorkSheet.Cells[col - 1, 21].Address + ")";

                                        sum1 += xlWorkSheet.Cells[col, 20].value;
                                        sum2 += xlWorkSheet.Cells[col, 21].value;

                                        xlWorkSheet.Cells[col, 20] = "****";
                                        xlWorkSheet.Cells[col, 21] = "**********";

                                        SetFooter(xlWorkBook, xlWorkSheet, col);
                                        col += 17 - 2;
                                        startrow = col + 12;
                                        gvrow = startrow + 5;

                                        //次のページの設定
                                        SetHeader(xlWorkSheet, dt, xlApp, col);

                                        #region Style top part
                                        SetStyleTopPart(xlWorkSheet, startrow, dtgv, xlApp);
                                        #endregion

                                        //col = (gvrow + 1) + dgv;
                                        col = gvrow + 1 + MaxRow;
                                        #region Child Style
                                        SetChildStyle(xlWorkSheet, gvrow, col, xlApp);
                                        #endregion

                                        #region Header Supplier
                                        SetHeaderSupplier(xlWorkSheet, gvrow);
                                        #endregion

                                        otherModel = 0;
                                    }
                                }
                                //改行条件
                                if (modelno != dtgv.Rows[h]["ModelNo"].ToString())
                                {
                                    xlWorkSheet.Cells[gvrow + (otherModel + 1), 2] = dtgv.Rows[h]["ModelNo"].ToString();
                                    xlWorkSheet.Cells[gvrow + (otherModel + 1), 3] = dtgv.Rows[h]["ModelName"].ToString();
                                    xlWorkSheet.Cells[gvrow + (otherModel + 1), 4] = dtgv.Rows[h]["FOBPRICE"].ToString();
                                    xlWorkSheet.Cells[gvrow + (otherModel + 1), 5] = dtgv.Rows[h]["JAPANColor"].ToString();
                                    xlWorkSheet.Cells[gvrow + (otherModel + 1), 6] = dtgv.Rows[h]["KOREAColor"].ToString();
                                    xlWorkSheet.Cells[gvrow + (otherModel + 1), 7] = dtgv.Rows[h]["Shippingplace"].ToString();
                                    //Yellow_Color_Change_Item ==> [ModelNO]
                                    var Cell_Color = (Excel.Range)xlWorkSheet.Cells[gvrow + (otherModel + 1), 2];
                                    var Cell_Color1 = (Excel.Range)xlWorkSheet.Cells[gvrow + (otherModel + 1), 5];
                                    //if (dtgv.Rows[h]["HacchuuLotFLG"].ToString().Equals("1"))
                                    //{
                                    //    Cell_Color.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#F0F179");
                                    //    Cell_Color1.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#F0F179");
                                    //}
                                    //try
                                    //{
                                    SettingImg(dtgv.Rows[h]["IMAGE"] as byte[]);
                                    SetImage(gvrow + (otherModel + 1), 8, tmpPath, xlWorkSheet);
                                    //}
                                    //catch (Exception ex) { var msg = ex.Message; }

                                    xlWorkSheet.Cells[gvrow + (otherModel + 1), 20] = dtgv.Rows[h]["Pairs"].ToString();
                                    xlWorkSheet.Cells[gvrow + (otherModel + 1), 21] = dtgv.Rows[h]["Amount"].ToString();
                                    modelno = dtgv.Rows[h]["ModelNo"].ToString();
                                    colorno = dtgv.Rows[h]["ColorNo"].ToString();

                                    int rowIndex = gvrow + otherModel;
                                    xlWorkSheet.get_Range("B" + rowIndex, "U" + rowIndex).Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 3d;

                                    otherModel++;
                                    //xlWorkSheet.get_Range("B" + (otherModel + 1), "U" + gvrow + (otherModel + 1)).Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 3d;
                                    
                                }
                                else if (modelno == dtgv.Rows[h]["ModelNo"].ToString() && colorno != dtgv.Rows[h]["ColorNo"].ToString())
                                {
                                    xlWorkSheet.Cells[gvrow + (otherModel + 1), 2] = dtgv.Rows[h]["ModelNo"].ToString();
                                    xlWorkSheet.Cells[gvrow + (otherModel + 1), 3] = dtgv.Rows[h]["ModelName"].ToString();
                                    xlWorkSheet.Cells[gvrow + (otherModel + 1), 4] = dtgv.Rows[h]["FOBPRICE"].ToString();
                                    xlWorkSheet.Cells[gvrow + (otherModel + 1), 5] = dtgv.Rows[h]["JAPANColor"].ToString();
                                    xlWorkSheet.Cells[gvrow + (otherModel + 1), 6] = dtgv.Rows[h]["KOREAColor"].ToString();
                                    xlWorkSheet.Cells[gvrow + (otherModel + 1), 7] = dtgv.Rows[h]["Shippingplace"].ToString();

                                    //Yellow_Color_Change_Item ==> [ModelNO]
                                    var Cell_Color = (Excel.Range)xlWorkSheet.Cells[gvrow + (otherModel + 1), 2];
                                    var Cell_Color1 = (Excel.Range)xlWorkSheet.Cells[gvrow + (otherModel + 1), 5];

                                    //if (dtgv.Rows[h]["HacchuuLotFLG"].ToString().Equals("1"))
                                    //{
                                    //    Cell_Color.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#F0F179");
                                    //    Cell_Color1.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#F0F179");
                                    //}

                                    //try
                                    //    {
                                    SettingImg(dtgv.Rows[h]["IMAGE"] as byte[]);
                                    SetImage(gvrow + (otherModel + 1), 8, tmpPath, xlWorkSheet);
                                    //}
                                    //catch (Exception ex) { var msg = ex.Message; }
                                    xlWorkSheet.Cells[gvrow + (otherModel + 1), 20] = dtgv.Rows[h]["Pairs"].ToString();
                                    xlWorkSheet.Cells[gvrow + (otherModel + 1), 21] = dtgv.Rows[h]["Amount"].ToString();
                                    modelno = dtgv.Rows[h]["ModelNo"].ToString();
                                    colorno = dtgv.Rows[h]["ColorNo"].ToString();
                                    otherModel++;
                                }

                                xlWorkSheet.Cells[gvrow + (otherModel), GetSizeTitile(dtgv.Rows[h]["SizeNo"].ToString())] = dtgv.Rows[h]["HacchuuSuu"].ToString();
                                //Yellow_Color_Change_Item ==> [ModelNO]
                                if (dtgv.Rows[h]["HacchuuLotFLG"].ToString().Equals("1"))
                                {
                                    var Cell_Color2 = xlWorkSheet.Cells[gvrow + (otherModel), GetSizeTitile(dtgv.Rows[h]["SizeNo"].ToString())];
                                    Cell_Color2.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#F0F179");
                                }

                            }

                            int rowNo = gvrow + otherModel;
                            xlWorkSheet.get_Range("B" + rowNo, "U" + rowNo).Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 3d;

                            xlWorkSheet.get_Range("B" + (gvrow), "U" + (gvrow)).Interior.Color = System.Drawing.ColorTranslator.FromHtml("#FFF2CC");
                            xlWorkSheet.Cells[col, 20].Formula = "=Sum(" + xlWorkSheet.Cells[gvrow + 1, 20].Address + ":" + xlWorkSheet.Cells[col - 1, 20].Address + ")";
                            xlWorkSheet.Cells[col, 21].Formula = "=Sum(" + xlWorkSheet.Cells[gvrow + 1, 21].Address + ":" + xlWorkSheet.Cells[col - 1, 21].Address + ")";

                            //xlWorkSheet.Cells[col, 8] = "TOTAL";
                            if (sum1 != 0 || sum2 != 0)
                            {
                                sum1 += xlWorkSheet.Cells[col, 20].value;
                                sum2 += xlWorkSheet.Cells[col, 21].value;

                                xlWorkSheet.Cells[col, 20] = sum1;
                                xlWorkSheet.Cells[col, 21] = sum2;
                            }
                            #endregion

                            SetFooter(xlWorkBook, xlWorkSheet, col);
                            col += 17-2;
                            startrow = col + 12;
                            gvrow = startrow + 5;
                        }

                        xlWorkSheet.PageSetup.PrintArea = "A1:V"+ col;

                        // Footers

                        xlApp.get_Range("C" + col + 4, "L" + col + 4).Merge(Type.Missing);
                        var dtnow = DateTime.Now.ToString("yyyyMMdd HHmmss");
                        xlWorkBook.SaveAs(savedialog.FileName, misValue, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                        xlWorkBook.Close(true, misValue, misValue);
                        xlApp.Quit();
                        bbl.ShowMessage("I201", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                        Process.Start(System.IO.Path.GetDirectoryName(savedialog.FileName));
                        Clear(); //HET
                    }
                }
            }
            catch (Exception ex1)
            {
                bbl.ShowMessage("E122");
            }
        }
        private void SetFooter(Excel.Workbook wb,Excel.Worksheet xlWorkSheet, int col)
        {
            xlWorkSheet.Cells[col + 4, 3] = "1.Terms of Payment :"; xlWorkSheet.Cells[col + 4, 4] = txtPayment.Text;

            xlWorkSheet.Cells[col + 6, 3] = "2. BENEFICIARY :"; xlWorkSheet.Cells[col + 6, 4] = txtBeneficiary1.Text; xlWorkSheet.Cells[col + 7, 4] = txtBeneficiary2.Text;

            xlWorkSheet.Cells[col + 9, 3] = "3. Country of Origin : "; xlWorkSheet.Cells[col + 9, 4] = txtOriginCountry.Text;

            xlWorkSheet.Cells[col + 11, 3] = "4. Shipping from : "; xlWorkSheet.Cells[col + 11, 4] = txtShipping.Text;

            xlWorkSheet.Cells[col + 13, 3] = "5. Destination :"; xlWorkSheet.Cells[col + 13, 4] = txtDestination.Text;

            xlWorkSheet.Cells[col + 15, 3] = "Looking forward to receiving your order confirmation.";

            xlWorkSheet.Cells[col + 15, 19] = "Sincerely yours,"; 
            wb.Worksheets[1].HPageBreaks.Add(xlWorkSheet.Range["W"+ (col + 16).ToString()]);
        }
        private void SetHeader(Excel.Worksheet xlWorkSheet,DataTable dt, Excel.Application xlApp ,int added)
        {
            xlWorkSheet.Cells[added+3, 6] = dt.Rows[0]["EiziAddress1"].ToString();
            xlWorkSheet.Cells[added+4, 6] = dt.Rows[0]["EiziAddress2"].ToString();
            xlWorkSheet.Cells[added+5, 6] = dt.Rows[0]["EiziAddress3"].ToString();

            xlWorkSheet.Cells[added + 6, 19] = "TEL : ";
            xlWorkSheet.Cells[added + 6, 20] = dt.Rows[0]["EiziTelephoneNO"].ToString();

            xlWorkSheet.Cells[added + 7, 19] = "FAX : ";
            xlWorkSheet.Cells[added + 7, 20] = dt.Rows[0]["EiziFaxNO"].ToString();

            xlWorkSheet.Cells[added + 10, 6] = "PURCHASE ORDER "; 
            xlApp.Cells.Font.Name = "Times New Roman";

            xlApp.get_Range("I" +(added + 17).ToString(), "S"  +(added + 17).ToString()).Cells.NumberFormat = "0.0"; 
            xlApp.get_Range("A"+(added+1).ToString()+":U"+(added + 1).ToString() , "A" + (added + 3).ToString() + ":U" + (added + 3).ToString() ).Merge(Type.Missing);
            xlApp.get_Range("A" + (added + 4).ToString() , "U" + (added + 4).ToString() ).Merge(Type.Missing);
            xlApp.get_Range("A"+ (added + 5).ToString(), "U"+ (added + 5).ToString()).Merge(Type.Missing);
            xlApp.get_Range("T"+ (added + 6).ToString(), "U"+ (added + 6).ToString()).Merge(Type.Missing);
            xlApp.get_Range("T"+(added + 7).ToString(), "U"+ (added + 7).ToString()).Merge(Type.Missing);
            xlApp.get_Range("A"+ (added + 10).ToString(), "U"+ (added + 10).ToString()).Merge(Type.Missing); 
            var Cell = (Excel.Range)xlWorkSheet.Cells[added+2, 1];
            Cell.RowHeight = 35;
            var Cell1 = (Excel.Range)xlWorkSheet.Cells[added+10, 1];
            Cell1.Font.Bold = true;
            Cell1.Font.Size = 20;
            Cell1.RowHeight = 50;
            xlWorkSheet.get_Range("A"+ (added + 1).ToString() + ":U"+ (added + 1).ToString(), "A"+ (added + 5).ToString() + ":U"+ (added + 5).ToString()).Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            xlWorkSheet.get_Range("A"+ (added + 10).ToString(), "U"+ (added + 10).ToString()).Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            xlWorkSheet.get_Range("A"+ (added + 10).ToString(), "U"+ (added + 10).ToString()).Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            xlWorkSheet.get_Range("A"+ (added + 11).ToString(), "H"+ (added + 11).ToString()).Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            xlWorkSheet.get_Range("A"+ (added + 1).ToString() + ":U"+ (added + 1).ToString(), "A"+ (added + 3).ToString() + ":U"+ (added + 3).ToString()).Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;

            SettingImg(headerLogo);
            SetImage(added+1, 6, tmpPath, xlWorkSheet, true);
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
            try
            {
                File.WriteAllBytes(tmpPath, bt);
            }
            catch{ 
            
            }
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
               // string filePath = string.Empty;
                //if (Debugger.IsAttached)
                //{
                //    System.Uri u = new System.Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
                //    filePath = System.IO.Path.GetDirectoryName(u.LocalPath).Replace("bin", "#").Split('#').First() + @"\HacchuuSho\Image\SHINYOH_Logo.jpg";
                //}
                //else
                //    filePath = tmpSourceLogo;
                if (IsLogo)
                {
                    ImageHeight = 32;
                    ImageWidth = 250;
                    ws.Shapes.AddPicture(path, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left + (float)30, Top + (float)(2.5), ImageWidth, ImageHeight);
                }
                else
                    ws.Shapes.AddPicture(path, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left + (float)15, Top + (float)(2.5), ImageWidth, ImageHeight);
            }
            catch
            {
            }
        }
        private void SetStyleTopPart(Excel.Worksheet xlWorkSheet, int startrow,DataTable dtgv, Excel.Application xlApp)
        {
            xlWorkSheet.Cells[startrow, 2] = "TO : " + dtgv.Rows[0]["SiiresakiName"].ToString();
            xlWorkSheet.Cells[startrow, 20] = "PO NO : " + txtKanriNO.Text;
            xlWorkSheet.Cells[startrow + 1, 20] = "DATE : " + GetDate(txtIssueDate.Text);
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

        }
        private void SetChildStyle(Excel.Worksheet xlWorkSheet, int gvrow, int col, Excel.Application xlApp)
        {
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

            xlApp.get_Range("T" + (gvrow + 1), "T" + col).Cells.NumberFormat = "#,##0";//ssa
            xlApp.get_Range("D" + (gvrow + 1), "D" + col).Cells.NumberFormatLocal = "$#,##0.00";
            xlApp.get_Range("U" + (gvrow + 1), "U" + col).Cells.NumberFormatLocal = "$#,##0.00";
            xlWorkSheet.get_Range("A" + (gvrow + 1) + ":U" + (gvrow + 1), val2).RowHeight = 40;
            xlApp.get_Range("A17", "U" + col).Cells.Font.Name = "Arial";

            xlWorkSheet.get_Range("B" + gvrow, "U" + col).Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = 3d;
            xlWorkSheet.get_Range("B" + gvrow, "U" + col).Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = 3d;
            xlWorkSheet.get_Range("B" + (col - 1), "U" + (col - 1)).Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 3d;//ssa
            xlWorkSheet.get_Range("B" + (col), "U" + (col)).Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 3d;//total

        }
        private void SetHeaderSupplier(Excel.Worksheet xlWorkSheet, int gvrow)
        {
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
            xlWorkSheet.Cells[gvrow + 9, 8] = "TOTAL";
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
                Rdo_Type=Rdo1.Checked?0:1
            };
            hse.OperatorCD = OperatorCD;
            hse.PC = PCID;
                return hse;
        }
    }
}
