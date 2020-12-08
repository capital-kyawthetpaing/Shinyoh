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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ShukkaSiziDataShuturyoku {
    public partial class ShukkaSiziDataShuturyoku : BaseForm {
        BaseEntity baseEntity;
        CommonFunction cf;
        BaseBL bbl;
        ShukkaSiziDataShuturyokuBL shukkaBL;
        public ShukkaSiziDataShuturyoku()
        {
            InitializeComponent();
            baseEntity = _GetBaseData();
            cf = new CommonFunction();
            bbl = new BaseBL();
            shukkaBL = new ShukkaSiziDataShuturyokuBL();
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
                if (bbl.ShowMessage("Q205") != DialogResult.Yes)
                {
                    PreviousCtrl.Focus();
                }
                else 
                {
                    DataTable dt = new DataTable { TableName = "MyTableName" };
                    dt = Get_Form_Object();
                    if (dt.Rows.Count > 0)
                    {
                        dt.Columns["TokuisakiCD"].ColumnName = "得意先CD";
                        dt.Columns["TokuisakiName"].ColumnName = "店舗CD";
                        dt.Columns["KouritenCD"].ColumnName = "得意先名";
                        dt.Columns["KouritenName"].ColumnName = "店舗名";
                        dt.Columns["DenpyouDate"].ColumnName = "伝票日付";
                        dt.Columns["ShukkaYoteiDate"].ColumnName = "出荷日";
                        dt.Columns["ShouhinCD"].ColumnName = "品番";
                        dt.Columns["ColorRyakuName"].ColumnName = "ｶﾗｰ";
                        dt.Columns["SizeNO"].ColumnName = "ｻｲｽﾞ";
                        dt.Columns["JANCD"].ColumnName = "JANｺｰﾄﾞ";
                        dt.Columns["ShukkaSiziSuu"].ColumnName = "数量";
                        dt.Columns["UriageTanka"].ColumnName = "単価";
                        dt.Columns["UriageKingaku"].ColumnName = "金額";
                        dt.Columns["KouritenJuusho2"].ColumnName = "先方発注№";
                        dt.Columns["SenpouHacchuuNO"].ColumnName = "出荷指示番号";
                        dt.Columns["ShukkaSiziMeisaiTekiyou"].ColumnName = "備考";

                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.InitialDirectory = @"C:\";
                        saveFileDialog1.DefaultExt = "xls";
                        saveFileDialog1.Filter = "ExcelFile|*.xls";
                        saveFileDialog1.FileName = "Shukka.xls";
                        saveFileDialog1.RestoreDirectory = true;
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            ExportDataTableToExcel(dt, saveFileDialog1.FileName);
                        }
                        if (true)
                        {
                            Clear();
                        }
                    }
                }
            }
            base.FunctionProcess(tagID);
        }
        public static bool ExportDataTableToExcel(DataTable dt, string filepath)
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
                oSheet.Name = "Shukka";

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
                oSheet.Range["A1", "Y1"].Interior.Color = Excel.XlRgbColor.rgbOrange;
                oSheet.Range["A1", "Y1"].Font.Color = Excel.XlRgbColor.rgbBlack;
                //Change date format
                //rg = (Excel.Range)oSheet.Cells[3, 3];
                //rg.EntireColumn.NumberFormat = "YYYY/MM/DD";

                //left alignment
                Excel.Range last = oSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                Excel.Range range = oSheet.get_Range("A2", last);
                range.EntireColumn.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                //no border 
                oXL.Windows.Application.ActiveWindow.DisplayGridlines = false;

                // Save the sheet and close 
                oSheet = null;
                oWB.SaveAs(filepath, Excel.XlFileFormat.xlWorkbookNormal,
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

        private DataTable Get_Form_Object()
        {
            ShukkaSiziDataShuturyokuEntity obj = new ShukkaSiziDataShuturyokuEntity();
            obj.ShukkaNo1 = txtShukkaNo1.Text;
            obj.ShukkaNo2 = txtShukkaNo2.Text;
            obj.ShukkaDate1 = txtShukkaDate1.Text;
            obj.ShukkaDate2 = txtShukkaDate2.Text;
            obj.InputDate1 = string.IsNullOrEmpty(txtInputDate1.Text) ? baseEntity.LoginDate : txtInputDate1.Text;
            obj.InputDate2 = string.IsNullOrEmpty(txtInputDate2.Text) ? baseEntity.LoginDate : txtInputDate2.Text;
            obj.BrandCD = txtBrand.Text;
            obj.Year = txtYear.Text;
            obj.SS = chk_SS.Checked == true ? "1" : "0";
            obj.FW = chk_FW.Checked == true ? "1" : "0";
            obj.TokuisakiCD = txtToukuisaki.Text;
            obj.KouritenCD = txtKouriten.Text;
            if (rdo_MiHakkou.Checked)
                obj.Condition = "Mihakkoubunnomi";
            else obj.Condition = "Hakkou";
            obj.LoginDate = baseEntity.LoginDate;
            DataTable dt = shukkaBL.ShukkaSiziDataShuturyoku_Excel(obj);
            return dt;
        }
    }
}
