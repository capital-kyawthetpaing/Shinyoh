using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;


namespace BL
{
    public  class ExportCSVExcel
    {
        
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
                        oSheet.Cells[rowCount, i] = dr[i - 1].ToString();
                    }
                    oSheet.Columns.AutoFit();
                }

                // color the columns 
                oSheet.Range[obj.Start_Interior_No, obj.End_Interior_No].Interior.Color = obj.Interior_Color;
                oSheet.Range[obj.Start_Font_No, obj.End_Font_No].Font.Color = obj.Font_Color;

                //Change date format
                rg = (Excel.Range)oSheet.Cells[obj.Start_Date_No, obj.End_Date_No];
                rg.EntireColumn.NumberFormat = obj.Date_Format;

                //change number format
                Excel.Range numberRange;
                numberRange = oSheet.get_Range("T1", "V1");
                numberRange.NumberFormat = "#,###,###";                

                //header alignment
                var range = oSheet.Range[obj.Start_Title_Center_No, obj.End_Title_Center_No];
                range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.WrapText = true;


                // left alignment
                //Excel.Range last = oSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                //Excel.Range range = oSheet.get_Range("A2", last);
               // range.EntireColumn.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                //right alignment
                //rg = (Excel.Range)oSheet.Cells[20, 22];
                //rg.EntireColumn.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                //no border 
                oXL.Windows.Application.ActiveWindow.DisplayGridlines = false;

                // Save the sheet and close 
                oSheet = null;
                oWB.SaveAs(obj.FilePath, Excel.XlFileFormat.xlWorkbookNormal,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                    Excel.XlSaveAsAccessMode.xlExclusive,
                    Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value);
                oWB.Close(Missing.Value, Missing.Value, Missing.Value);
                oWB = null;
                oXL.Quit();
            }
            catch
            {
                throw;
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

        public  string DataTableToCSV(DataTable datatable, char seperator)
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
        public  string Start_Interior_No { get; set; }
        public  string End_Interior_No { get; set; }
        public Color Interior_Color { get; set; }
        public  string Start_Font_No { get; set; }
        public  string End_Font_No { get; set; }
        public Color Font_Color { get; set; }
        public  int Start_Date_No { get; set; }
        public  int End_Date_No { get; set; }
        public  string Date_Format { get; set; }
        public  string Start_Title_Center_No { get; set; }
        public string End_Title_Center_No { get; set; }
        public string Start_Number_No { get; set; }
        public string End_Number_No { get; set; }
        public string Number_Format { get; set; }
    }   
    
}
