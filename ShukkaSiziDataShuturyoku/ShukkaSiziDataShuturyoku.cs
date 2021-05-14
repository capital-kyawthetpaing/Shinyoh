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
        ExportCSVExcel obj_Export;
        ShukkaSiziDataShuturyokuBL shukkaBL;
        public ShukkaSiziDataShuturyoku()
        {
            InitializeComponent();
            baseEntity = _GetBaseData();
            cf = new CommonFunction();
            bbl = new BaseBL();
            shukkaBL = new ShukkaSiziDataShuturyokuBL();
            obj_Export = new ExportCSVExcel();
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
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", true);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", false);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            SetButton(ButtonType.BType.Empty, F8, "", false);
            SetButton(ButtonType.BType.ExcelExport, F10, "出力(F10)", true);
            SetButton(ButtonType.BType.Empty, F11, "", false);

            txtToukuisaki.lblName = lblTokuisakiName;
            txtKouriten.lblName = lblKouritenName;
            txtBrand.lblName = lblBrand_Name;

            txtTempDate.Text = baseEntity.LoginDate;
            txtToukuisaki.ChangeDate = txtTempDate;
            txtKouriten.ChangeDate = txtTempDate;

            txtKouriten.TxtBox = txtToukuisaki;

            ErrorCheck();
        }
        private void ErrorCheck()
        {
            txtToukuisaki.E101Check(true, "M_Tokuisaki", txtToukuisaki, txtTempDate, null);
            txtKouriten.E101Check(true, "M_Kouriten", txtKouriten, txtTempDate, null);
            txtBrand.E101Check(true, "M_Shouhin", txtBrand, null, null);
            txtShukkaDate1.E103Check(true);
            txtShukkaDate2.E103Check(true);
            txtInputDate1.E103Check(true);
            txtInputDate2.E103Check(true);
            txtShukkaDate2.E104Check(true, txtShukkaDate1, txtShukkaDate2);
            txtInputDate2.E104Check(true, txtInputDate1, txtInputDate2);
            txtShukkaNo2.E106Check(true, txtShukkaNo1, txtShukkaNo2);

            chk_SS.Checked = true; 
            chk_FW.Checked = true; 
        }

        private void txtBrand_KeyDown(object sender, KeyEventArgs e)
        {
            //multipurposeBL bl = new multipurposeBL();
            //string brandName = txtBrand.Text.ToString();
            //DataTable dt = bl.M_Multiporpose_SelectData(brandName, 1, string.Empty, string.Empty);

            //if (dt.Rows.Count > 0)
            //    lblBrand_Name.Text = dt.Rows[0]["Char1"].ToString();
            //else lblBrand_Name.Text = string.Empty;
        }
        private void Clear()
        {
            cf.Clear(PanelDetail);
            rdo_MiHakkou.Checked = true;
            txtShukkaNo1.Focus();
            lblBrand_Name.Text = "";
            lblTokuisakiName.Text = "";
            lblKouritenName.Text = "";

            chk_SS.Checked = true; 
            chk_FW.Checked = true; 
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "6")
            {
                Clear();
            }
            if (tagID == "10")
            {             
                DataTable dt = new DataTable { TableName = "MyTableName" };
                dt = Get_Form_Object();
                if (dt.Rows.Count > 0)
                {
                    dt.Columns["TokuisakiCD"].ColumnName = "得意先CD";
                    dt.Columns["KouritenCD"].ColumnName = "店舗CD";
                    dt.Columns["TokuisakiName"].ColumnName = "得意先名";
                    dt.Columns["KouritenName"].ColumnName = "店舗名";
                    dt.Columns["DenpyouDate"].ColumnName = "伝票日付";
                    dt.Columns["ShukkaYoteiDate"].ColumnName = "出荷日";
                    dt.Columns["HinbanCD"].ColumnName = "品番";
                    dt.Columns["ColorRyakuName"].ColumnName = "ｶﾗｰ";
                    dt.Columns["SizeNO"].ColumnName = "ｻｲｽﾞ";
                    dt.Columns["JANCD"].ColumnName = "JANｺｰﾄﾞ";
                    dt.Columns["ShukkaSiziSuu"].ColumnName = "数量";
                    dt.Columns["UriageTanka"].ColumnName = "単価";
                    dt.Columns["UriageKingaku"].ColumnName = "金額";
                    //dt.Columns["KouritenJuusho2"].ColumnName = "先方発注№";
                    //dt.Columns["SenpouHacchuuNO"].ColumnName = "出荷指示番号";
                    dt.Columns["SenpouHacchuuNO"].ColumnName = "先方発注№";
                    dt.Columns["ShukkaSiziNO"].ColumnName = "出荷指示番号";
                    dt.Columns["ShukkaSiziMeisaiTekiyou"].ColumnName = "備考";

                    if (!System.IO.Directory.Exists("C:\\Excel"))
                        System.IO.Directory.CreateDirectory("C:\\Excel");

                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.InitialDirectory = @"C:\Excel\";

                    //for excel
                    saveFileDialog1.Filter = "ExcelFile|*.xls";
                   // saveFileDialog1.FileName = ".xls";
                    saveFileDialog1.RestoreDirectory = true;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        ExcelDesignSetting obj = new ExcelDesignSetting();
                        obj.FilePath = saveFileDialog1.FileName;
                        obj.SheetName = "Sheet1";
                        obj.Start_Interior_Column = "A1";
                        obj.End_Interior_Column = "P1";
                        obj.Interior_Color = Color.FromArgb(255, 192, 0);
                        obj.Start_Font_Column = "A1";
                        obj.End_Font_Column = "P1";
                        obj.Font_Color = Color.Black;
                        //For column E,F
                        obj.Date_Column = new List<int>();
                        obj.Date_Column.Add(5);
                        obj.Date_Column.Add(6);
                        obj.Date_Format = "YYYY/MM/DD";
                        //for column 9(I)
                        obj.OnePlaceDecimal_Column = new List<int>();
                        obj.OnePlaceDecimal_Column.Add(9);
                        obj.Decimal_Format = "#.0";
                        obj.Start_Title_Center_Column = "A1";
                        obj.End_Title_Center_Column = "P1";
                        bool bl = obj_Export.ExportDataTableToExcel(dt, obj);
                        if (bl)
                        {
                            bbl.ShowMessage("I203");
                            Clear();
                        }
                    }
                }
                else if (dt.Rows.Count == 0)
                {
                    bbl.ShowMessage("S013");
                    if (PreviousCtrl != null)
                        PreviousCtrl.Focus();
                }                           
            base.FunctionProcess(tagID);
            }
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
