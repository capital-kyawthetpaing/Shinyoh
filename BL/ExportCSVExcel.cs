using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using ClosedXML.Excel;
using System.IO;
using System.Windows.Forms;

namespace BL
{
    public  class ExportCSVExcel
    {
        BaseBL bbl = new BaseBL();
        public string[] stringCol = null;
        public  bool ExportDataTableToExcel(DataTable dt,ExcelDesignSetting  obj)
        {
            Excel.Application oXL;
            Excel.Workbook oWB;
            Excel.Worksheet oSheet;
            Excel.Range rg;

            try
            {
                // Start Excel and get Application object. 
                oXL = new Excel.Application();

                // Set some properties 
                oXL.Visible = false;
                oXL.DisplayAlerts = false;

                // Get a new workbook. 
                oWB = oXL.Workbooks.Add(Missing.Value);

                // Get the Active sheet 
                oSheet = (Excel.Worksheet)oWB.ActiveSheet;
                oSheet.Name = obj.SheetName;

                foreach (DataColumn dc in dt.Columns)
                {
                    if (dc.DataType == typeof(string))
                    {
                        oSheet.Cells[1, dt.Columns.IndexOf(dc) + 1].EntireColumn.NumberFormat = "@";
                    }
                }

                int rowCount = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    rowCount += 1;
                    for (int i = 1; i < dt.Columns.Count + 1; i++)
                    {
                        // Add the header the first time through 
                        if (rowCount == 2)
                        {
                            oSheet.Cells[1, i] = dt.Columns[i - 1].ColumnName;
                        }
                       // oSheet.Cells[rowCount, i].EntireColumn.NumberFormat = "@";
                        oSheet.Cells[rowCount, i] = dr[i - 1].ToString();
                    }
                     //oSheet.Columns.AutoFit();
                   oSheet.Columns.ColumnWidth = 15;
                }

                //header alignment
                if(!string.IsNullOrEmpty(obj.Start_Title_Center_Column) && !string.IsNullOrEmpty(obj.End_Title_Center_Column))
                {
                    var range = oSheet.Range[obj.Start_Title_Center_Column, obj.End_Title_Center_Column];
                    range.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;//ssa
                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//ssa
                    range.WrapText = true;
                }
                // color the columns 
                if (!string.IsNullOrEmpty(obj.Start_Interior_Column) && !string.IsNullOrEmpty(obj.End_Interior_Column))
                {
                    oSheet.Range[obj.Start_Interior_Column, obj.End_Interior_Column].Interior.Color = Color.FromArgb(255, 192, 0);
                }
                //font color 
                if (!string.IsNullOrEmpty(obj.Start_Font_Column) && !string.IsNullOrEmpty(obj.End_Font_Column))
                {
                    oSheet.Range[obj.Start_Font_Column, obj.End_Font_Column].Font.Color = Color.Black;
                }
                //Change date format               
                if (obj.Date_Column != null && obj.Date_Column.Count > 0)//change
                {
                    for (int k = 0; k < obj.Date_Column.Count; k++)
                    {
                        rg = (Excel.Range)oSheet.Cells[obj.Date_Column[k], obj.Date_Column[k]];
                        rg.EntireColumn.NumberFormat = obj.Date_Format;
                        rg.EntireColumn.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        rg.EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    }
                }
                //change number format
                if (obj.Number_Column != null && obj.Number_Column.Count > 0)//change
                {
                    for (int k = 0; k < obj.Number_Column.Count; k++)
                    {
                        rg = (Excel.Range)oSheet.Cells[obj.Number_Column[k], obj.Number_Column[k]];
                        rg.EntireColumn.NumberFormat = obj.Number_Format;
                    }
                }
                //no border 
                oXL.Windows.Application.ActiveWindow.DisplayGridlines = false;

                // Save the sheet and close 
                oSheet = null;
                oWB.SaveAs(obj.FilePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                    Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,//ssa
                    Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value);
                //Doesn't appear in any other open windows.
            //True: Close workbook and save changes.
            //False: Close workbook without saving changes.
                oWB.Close(false, Missing.Value, Missing.Value);//change
                oWB = null;
                oXL.Quit();
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
                throw ex;
            }
            finally
            {
                // Clean up 
                // NOTE: When in release mode, this does the trick 
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
            return true;
        }
        protected DataTable GetJanCD(DataTable dt,string[] eColName=null)
        {
            foreach (DataRow dr in dt.Rows)
            {
                var d="";
                /////if (eColName.)
                try
                {
                  d  = PureJan(dr["JanCD"].ToString());
                    dr["JanCD"] = PureJan(dr["JanCD"].ToString());
                }
                catch (Exception ex) { 
                
                }
            }
            return dt;
        }
        protected string PureJan(string va)
        {
            string vl = "";
            if (va != "")
            {
                try
                {
                    vl = string.Format("{0:f}", Convert.ToDouble(va));

                }
                catch
                {

                    vl = Double.Parse(va, System.Globalization.NumberStyles.Any).ToString();
                }

                if (vl.Contains("."))
                    vl = vl.Split('.').First();
            }
            return vl;
        }
             
        public bool ExcelOutputFile(DataTable dtvalue, string ProgramID, string fname, string SheetName, int bgcol, string[] datecol, string[] numcol)
        {
            try
            {
                GetJanCD(dtvalue);
                string folderPath = "C:\\ShinYoh\\" + ProgramID + "\\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Filter = "Excel Files|*.xlsx;";
                savedialog.Title = "Save";
                savedialog.FileName = fname + ".xlsx";
                savedialog.InitialDirectory = folderPath;

                savedialog.RestoreDirectory = true;

                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    if (Path.GetExtension(savedialog.FileName).Contains(".xlsx"))
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add(dtvalue, SheetName);
                            ws.Range(ws.Cell(1, 1), ws.Cell(1, bgcol)).Style.Fill.BackgroundColor = XLColor.FromArgb(255, 192, 0);
                            ws.FirstRow().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            //ws.ColumnWidth = 15;
                            // worksheet.Columns.AutoFit();
                            ws.Columns().AdjustToContents();

                            if (stringCol != null)
                            {
                                for (int i = 0; i < stringCol.Count(); i++)
                                {
                                    string val = stringCol[i].ToString();
                                    ws.Column(val).DataType = XLDataType.Text;
                                    ws.Column(val).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                                }
                            }

                            if (datecol != null)
                            {
                                for (int i = 0; i < datecol.Count(); i++)
                                {
                                    string val = datecol[i].ToString();
                                    ws.Column(val).Style.NumberFormat.Format = "YYYY/MM/DD";
                                    ws.Column(val).Style.Alignment.Horizontal= XLAlignmentHorizontalValues.Center;
                                }
                            }

                            //// PTK removed 2021/05/20
                            //int j = 0;
                            //foreach (DataColumn dc in dtvalue.Columns)   /// Make Every JanCD to be not allow Exponential when Edit cell
                            //{
                            //    j++;
                            //    if (dc.ColumnName.ToUpper() == "JANCD")
                            //    ws.Columns(j.ToString()).Style.NumberFormat.SetNumberFormatId(49);
                            //}
                            if (numcol != null)
                            {
                                // PTK removed 2021/05/20
                                for (int k = 0; k < numcol.Count(); k++)
                                {
                                    string val1 = numcol[k].ToString();
                                    ws.Column(val1).Style.NumberFormat.Format = "#,##0";//ID 3 is the same
                                }
                            }
                            ws.ShowGridLines = false;
                            ws.Tables.FirstOrDefault().ShowAutoFilter = false;
                            ws.Tables.FirstOrDefault().Theme = XLTableTheme.None;

                            wb.SaveAs(savedialog.FileName);
                            bbl.ShowMessage("I203");
                        }
                        Process.Start(Path.GetDirectoryName(savedialog.FileName));
                        //workbook.Close(false, Missing.Value, Missing.Value);
                        //excel.Quit();
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                bbl.ShowMessage("E122");
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                // Clean up 
                // NOTE: When in release mode, this does the trick 
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
            return true;
        }

        public string DataTableToCSV(DataTable datatable, char seperator)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < datatable.Columns.Count; i++)
            {
                sb.Append(datatable.Columns[i]);
                if (i < datatable.Columns.Count - 1)
                    sb.Append(seperator);
            }
            sb.AppendLine();
            foreach (DataRow dr in datatable.Rows)
            {
                for (int i = 0; i < datatable.Columns.Count; i++)
                {
                    sb.Append(dr[i].ToString());

                    if (i < datatable.Columns.Count - 1)
                        sb.Append(seperator);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
    public class ExcelDesignSetting
    {
        public  string FilePath { get; set; }
        public  string SheetName { get; set; }
        public  string Start_Interior_Column { get; set; }
        public  string End_Interior_Column { get; set; }
        public Color Interior_Color { get; set; }
        public  string Start_Font_Column { get; set; }
        public  string End_Font_Column { get; set; }
        public Color Font_Color { get; set; }
        public  List<int> Date_Column { get; set; }
        public string Date_Format { get; set; }
        public  string Start_Title_Center_Column { get; set; }
        public string End_Title_Center_Column { get; set; }
        public List<int> Number_Column { get; set; }
        public string Number_Format { get; set; }
    }   
    
}
