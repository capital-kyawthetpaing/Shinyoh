using BL;
using CKM_CommonFunction;
using Entity;
using Shinyoh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace HacchuuList
{
    public partial class HacchuuList : BaseForm
    {
        CommonFunction cf;
        BaseEntity baseEntity;
        HacchuuListBL obj_Bl;
        ExportCSVExcel obj_Export;
        BaseBL bbl = new BaseBL();
        public HacchuuList()
        {
            cf = new CommonFunction();
            baseEntity = new BaseEntity();
            obj_Bl = new HacchuuListBL();
            obj_Export = new ExportCSVExcel();
            InitializeComponent();
        }

        private void HacchuuList_Load(object sender, EventArgs e)
        {
            ProgramID = "HacchuuList";
            StartProgram();

            txtHacchuuDate1.Focus();

            cboMode.Visible = false;

            lblStaff_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblBrand_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lbl_Title.BorderStyle = System.Windows.Forms.BorderStyle.None;


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
            SetButton(ButtonType.BType.ExcelExport, F10, "出力(F10)", true); 
            SetButton(ButtonType.BType.Empty, F11, "", false);

            ErrorCheck();

            baseEntity = _GetBaseData();
            Date_Setting();

            txtStaffCD.lblName = lblStaff_Name;
            txtBrand.lblName = lblBrand_Name;
            Disable_Method();

            txtStaffCD.ChangeDate = txtTempDate;
        }

        private void Date_Setting()
        {
            txtHacchuuDate1.Text = baseEntity.LoginDate;
            txtHacchuuDate2.Text = baseEntity.LoginDate;
            txtUpdate_HacchuuDate1.Text = baseEntity.LoginDate;
            txtUpdate_HacchuuDate2.Text = baseEntity.LoginDate;
            txtTempDate.Text = baseEntity.LoginDate;

            chk_SS.Checked = true; //HET
            chk_FW.Checked = true; //HET
        }
        private void ErrorCheck()
        {
            txtHacchuuDate1.E102Check(true);
            txtHacchuuDate2.E102Check(true);
            txtHacchuuDate1.E103Check(true);
            txtHacchuuDate2.E103Check(true);
            txtHacchuuDate2.E106Check(true, txtHacchuuDate1, txtHacchuuDate2);
            txtHacchuuNO2.E106Check(true, txtHacchuuNO1, txtHacchuuNO2);
            txtUpdate_HacchuuDate1.E103Check(true);
            txtUpdate_HacchuuDate2.E103Check(true);
            txtUpdate_HacchuuDate2.E106Check(true, txtUpdate_HacchuuDate1, txtUpdate_HacchuuDate2);

            txtJuchuuDate1.E103Check(true);
            txtJuchuuDate2.E103Check(true);
            txtUpdate_JuchuuDate1.E103Check(true);
            txtUpdate_JuchuuDate2.E103Check(true);
            txtJuchuuDate2.E106Check(true, txtJuchuuDate1, txtJuchuuDate2);
            txtUpdate_JuchuuDate2.E106Check(true, txtUpdate_JuchuuDate1, txtUpdate_JuchuuDate2);

            txtJuchuuNO2.E106Check(true, txtJuchuuNO1, txtJuchuuNO2);

            txtStaffCD.E101Check(true, "M_Staff", txtStaffCD, txtTempDate, null);

            //txtBrandCD.E101Check(true, "M_MultiPorpose", txtBrandCD, txtTempDate, null);

            txtBrand.E101Check(true, "M_Shouhin", txtBrand, null, null);
        }
        private void Clear()
        {
            cf.Clear(PanelDetail);
            rdo_Hac.Checked = true;
            txtHacchuuDate1.Focus();
            Date_Setting();
            lblStaff_Name.Text = "";
            lblBrand_Name.Text = "";
            chk_SS.Checked = true; //HET
            chk_FW.Checked = true; //HET
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "6")
            {
                Clear();
            }
            if (tagID == "10")
            {
                //if (ErrorCheck(PanelDetail))
                //{
                DataTable dt = new DataTable { TableName = "MyTableName" };
                dt = Get_Form_Object();
                if (dt.Rows.Count > 0)
                {
                    dt.Columns["HacchuuNO"].ColumnName = "発注番号";
                    dt.Columns["JuchuuNO"].ColumnName = "受注番号";
                    dt.Columns["HacchuuDate"].ColumnName = "受発注日";
                    dt.Columns["StaffName"].ColumnName = "担当者	";
                    dt.Columns["TokuisakiCD"].ColumnName = "得意先コード";
                    dt.Columns["TokuisakiRyakuName"].ColumnName = "得意先名";
                    dt.Columns["KouritenCD"].ColumnName = "小売店コード";
                    dt.Columns["KouritenRyakuName"].ColumnName = "小売店";
                    dt.Columns["SenpouHacchuuNO"].ColumnName = "先方発注番号";
                    dt.Columns["SenpouBusho"].ColumnName = "先方部署	";
                    dt.Columns["KibouNouki"].ColumnName = "希望納期";
                    dt.Columns["HacchuuDenpyouTekiyou"].ColumnName = "伝票摘要";
                    dt.Columns["Char1"].ColumnName = "ブランド名";
                    dt.Columns["Exhibition"].ColumnName = "展示会";
                    dt.Columns["JANCD"].ColumnName = "JANコード";
                    dt.Columns["ShouhinCD"].ColumnName = "商品";
                    dt.Columns["ShouhinName"].ColumnName = "商品名";
                    dt.Columns["ColorRyakuName"].ColumnName = "カラー";
                    dt.Columns["SizeNO"].ColumnName = "サイズ";
                    dt.Columns["HacchuuSuu"].ColumnName = "数量";
                    dt.Columns["UriageTanka"].ColumnName = "上代	";
                    dt.Columns["HacchuuTanka"].ColumnName = "下代";
                    dt.Columns["HacchuuMeisaiTekiyou"].ColumnName = "明細摘要";
                    dt.Columns["SiiresakiCD"].ColumnName = "発注先";
                    dt.Columns["SiiresakiRyakuName"].ColumnName = "発注先名";
                   // dt.Columns.Remove("発注先名");                              //not include in Excel
                    dt.Columns["SoukoName"].ColumnName = "倉庫";
                    
                        //2021 / 05 / 21 ssa CHG XMLExcel
                    string ProgramID = "HacchuuList";
                    string fname = "発注リスト";
                    string[] datacol = { "2", "10" };
                    string[] numcol = { "20", "21", "22" };

                    ExportCSVExcel list = new ExportCSVExcel();
                    list.ExcelOutputFile(dt, ProgramID, fname, fname, 26, datacol, numcol);

                    //if (!System.IO.Directory.Exists("C:\\Excel"))
                    //    System.IO.Directory.CreateDirectory("C:\\Excel");

                    //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    //saveFileDialog1.InitialDirectory = @"C:\Excel\";
                    ////for csv
                    //saveFileDialog1.Filter = "csv files (*.csv)|*.csv";
                    //saveFileDialog1.FileName = ProgramID + " (" + DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.Hour + DateTime.Now.Day + DateTime.Now.Month + ") " + OperatorCD;
                    //saveFileDialog1.RestoreDirectory = true;
                    //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    //{
                    //    string sb = obj_Export.DataTableToCSV(dt, ',');
                    //    if (!string.IsNullOrEmpty(sb))
                    //    {
                    //        File.WriteAllText(saveFileDialog1.FileName, sb.ToString(), Encoding.UTF8);
                    //        Clear();
                    //    }
                    //}


                    //for excel
                    //    saveFileDialog1.Filter = "ExcelFile|*.xlsx";
                    //    saveFileDialog1.FileName = "発注リスト.xlsx";
                    //    saveFileDialog1.RestoreDirectory = true;
                    //    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    //    {
                    //        ExcelDesignSetting obj = new ExcelDesignSetting();
                    //        obj.FilePath = saveFileDialog1.FileName;
                    //        obj.SheetName = "発注リスト";
                    //        obj.Start_Interior_Column = "A1";
                    //        obj.End_Interior_Column = "Z1";
                    //        obj.Interior_Color = Color.FromArgb(255, 192, 0);
                    //        obj.Start_Font_Column = "A1";
                    //        obj.End_Font_Column = "Z1";
                    //        obj.Font_Color = Color.Black;
                    //        //For column C
                    //        obj.Date_Column = new List<int>();
                    //        obj.Date_Column.Add(3);
                    //        obj.Date_Format = "YYYY/MM/DD";
                    //        obj.Start_Title_Center_Column = "A1";
                    //        obj.End_Title_Center_Column = "Z1";
                    //        //for column T,U,V
                    //        obj.Number_Column = new List<int>();
                    //        //obj.Number_Column.Add(20);
                    //        obj.Number_Column.Add(21);
                    //        obj.Number_Column.Add(22);
                    //        obj.Number_Format = "#,###,###";
                    //        bool bl = obj_Export.ExportDataTableToExcel(dt, obj);
                    //        if (bl)
                    //        {
                    //            bbl.ShowMessage("I203");
                    //            Clear();
                    //        }
                    //    }
                }
                else if (dt.Rows.Count == 0)
                {
                    bbl.ShowMessage("S013");
                    if (PreviousCtrl != null)
                        PreviousCtrl.Focus();
                }
                //}
            }
            base.FunctionProcess(tagID);
        }

        private void rdo_Hac_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_Hac.Checked == true)
            {
                rdo_Juc.Checked = false;
                Disable_Method();
            } 
        }
        private void Enable_Method()
        {
            txtJuchuuDate1.Enabled = true;
            txtJuchuuDate2.Enabled = true;
            txtJuchuuNO1.Enabled = true;
            txtJuchuuNO2.Enabled = true;
            txtUpdate_JuchuuDate1.Enabled = true;
            txtUpdate_JuchuuDate2.Enabled = true;
            chk_FW.NextControlName = txtJuchuuDate1.Name;
        }
        private void Disable_Method()
        {
            txtJuchuuDate1.Text = string.Empty;
            txtJuchuuDate2.Text = string.Empty;
            txtJuchuuNO1.Text = string.Empty;
            txtJuchuuNO2.Text = string.Empty;
            txtUpdate_JuchuuDate1.Text = string.Empty;
            txtUpdate_JuchuuDate2.Text = string.Empty;

            txtJuchuuDate1.Enabled = false;
            txtJuchuuDate2.Enabled = false;
            txtJuchuuNO1.Enabled = false;
            txtJuchuuNO2.Enabled = false;
            txtUpdate_JuchuuDate1.Enabled = false;
            txtUpdate_JuchuuDate2.Enabled = false;

            chk_FW.NextControlName = "BtnF10";
        }
        private void rdo_Juc_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_Juc.Checked == true)
            {
                rdo_Hac.Checked = false;
                Enable_Method();
            }
        }
        private DataTable Get_Form_Object()
        {
            HacchuuEntity obj = new HacchuuEntity();
            obj.HacchuuNO1 = txtHacchuuNO1.Text;
            obj.HacchuuNO2 = txtHacchuuNO2.Text;
            obj.HacchuuDate1 = txtHacchuuDate1.Text;
            obj.HacchuuDate2 = txtHacchuuDate2.Text;
            obj.Hacchuu_UpdateDate1 = string.IsNullOrEmpty(txtUpdate_HacchuuDate1.Text) ? baseEntity.LoginDate : txtUpdate_HacchuuDate1.Text;
            obj.Hacchuu_UpdateDate2 = string.IsNullOrEmpty(txtUpdate_HacchuuDate2.Text) ? baseEntity.LoginDate : txtUpdate_HacchuuDate2.Text;
            obj.StaffCD = txtStaffCD.Text;
            obj.BrandCD = txtBrand.Text;
            obj.Year = txtYear.Text;
            obj.SS = chk_SS.Checked == true ? "1" : "0";
            obj.FW = chk_FW.Checked == true ? "1" : "0";
            obj.JuchuuDate1 = txtJuchuuDate1.Text;
            obj.JuchuuDate2 = txtJuchuuDate2.Text;
            obj.JuchuuNO1 = txtJuchuuNO1.Text;
            obj.JuchuuNO2 = txtJuchuuNO2.Text;
            obj.Juchuu_UpdateDate1 = txtUpdate_JuchuuDate1.Text;
            obj.Juchuu_UpdateDate2 = txtUpdate_JuchuuDate2.Text;
            if (rdo_Hac.Checked)
                obj.Condition = "Hacchuu";
            else obj.Condition = "Juchuu";
            obj.LoginDate = baseEntity.LoginDate;
            DataTable dt = obj_Bl.GetHacchuuList(obj);
            return dt;
        }

        private void txtBrandCD_KeyDown(object sender, KeyEventArgs e)
        {
            multipurposeBL bl = new multipurposeBL();
            DataTable dt = bl.M_Multiporpose_SelectData(txtBrand.Text, 1, string.Empty, string.Empty);
            lblBrand_Name.Text = string.Empty;
            if (dt.Rows.Count > 0)
                lblBrand_Name.Text = dt.Rows[0]["Char1"].ToString();
        }
    }
}
