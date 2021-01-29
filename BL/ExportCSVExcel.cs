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

                //header alignment
                if(!string.IsNullOrEmpty(obj.Start_Title_Center_Column) && !string.IsNullOrEmpty(obj.End_Title_Center_Column))
                {
                    var range = oSheet.Range[obj.Start_Title_Center_Column, obj.End_Title_Center_Column];
                    range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    range.WrapText = true;
                }
                // color the columns 
                if (!string.IsNullOrEmpty(obj.Start_Interior_Column) && !string.IsNullOrEmpty(obj.End_Interior_Column))
                {
                    oSheet.Range[obj.Start_Interior_Column, obj.End_Interior_Column].Interior.Color = obj.Interior_Color;
                }
                //font color 
                if (!string.IsNullOrEmpty(obj.Start_Font_Column) && !string.IsNullOrEmpty(obj.End_Font_Column))
                {
                    oSheet.Range[obj.Start_Font_Column, obj.End_Font_Column].Font.Color = obj.Font_Color;
                }
                //Change date format               
                if (obj.Date_Column != null && obj.Date_Column.Count > 0)//change
                {
                    for (int k = 0; k < obj.Date_Column.Count; k++)
                    {
                        rg = (Excel.Range)oSheet.Cells[obj.Date_Column[k], obj.Date_Column[k]];
                        rg.EntireColumn.NumberFormat = obj.Date_Format;
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
                oWB.SaveAs(obj.FilePath, Excel.XlFileFormat.xlWorkbookNormal,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                    Excel.XlSaveAsAccessMode.xlExclusive,
                    Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value);
                //Doesn't appear in any other open windows.
            //True: Close workbook and save changes.
            //False: Close workbook without saving changes.
                oWB.Close(false, Missing.Value, Missing.Value);//change
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
