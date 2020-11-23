﻿using BL;
using CKM_CommonFunction;
using Entity;
using Shinyoh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace HacchuuList
{
    public partial class HacchuuList : BaseForm
    {
        CommonFunction cf;
        BaseEntity baseEntity;
        HacchuuListBL obj_Bl;

        public HacchuuList()
        {
            cf = new CommonFunction();
            baseEntity = new BaseEntity();
            obj_Bl = new HacchuuListBL();
            InitializeComponent();
        }

        private void HacchuuList_Load(object sender, EventArgs e)
        {
            ProgramID = "HacchuuList";
            StartProgram();

            rdo_Hac.Focus();

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
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", true);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", false);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            SetButton(ButtonType.BType.Empty, F8, "", false);
            SetButton(ButtonType.BType.Import, F10, "出力(F10)", true);
            SetButton(ButtonType.BType.Empty, F11, "", false);

            ErrorCheck();

            baseEntity = _GetBaseData();
            txtHacchuuDate1.Text = baseEntity.LoginDate;
            txtHacchuuDate2.Text = baseEntity.LoginDate;
            txtUpdate_HacchuuDate1.Text = baseEntity.LoginDate;
            txtUpdate_HacchuuDate2.Text = baseEntity.LoginDate;
            txtTempDate.Text = baseEntity.LoginDate;

            txtStaffCD.lblName = lblStaff_Name;
            Disable_Method();
        }
        private void ErrorCheck()
        {
            txtHacchuuDate1.E102Check(true);
            txtHacchuuDate2.E102Check(true);
            txtHacchuuDate1.E103Check(true);
            txtHacchuuDate2.E103Check(true);
            txtHacchuuDate2.E104Check(true, txtHacchuuDate1, txtHacchuuDate2);
            txtHacchuuNO2.E106Check(true, txtHacchuuNO1, txtHacchuuNO2);
            txtUpdate_HacchuuDate1.E103Check(true);
            txtUpdate_HacchuuDate2.E103Check(true);
            txtUpdate_HacchuuDate2.E104Check(true, txtUpdate_HacchuuDate1, txtUpdate_HacchuuDate2);

            txtJuchuuDate1.E103Check(true);
            txtJuchuuDate2.E103Check(true);
            txtUpdate_JuchuuDate1.E103Check(true);
            txtUpdate_JuchuuDate2.E103Check(true);
            txtJuchuuDate2.E104Check(true, txtJuchuuDate1, txtJuchuuDate2);
            txtUpdate_JuchuuDate2.E106Check(true, txtUpdate_JuchuuDate1, txtUpdate_JuchuuDate2);

            txtJuchuuNO2.E106Check(true, txtJuchuuNO1, txtJuchuuNO2);

            txtStaffCD.E101Check(true, "M_Staff", txtStaffCD, txtTempDate, null);           
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "6")
            {
                cf.Clear(Panel_Detail);
                rdo_Hac.Focus();
            }
            if (tagID == "10")
            {
                DataTable dt = Get_Form_Object();
                //if(dt.Rows.Count>0)
                //{
               
                  dt.Columns["HacchuuNO"].ColumnName = "発注番号";
                    dt.Columns["JuchuuNO"].ColumnName = "受注番号";
                    dt.Columns["HacchuuDate"].ColumnName = "受発注日";
                    dt.Columns["StaffName"].ColumnName = "担当者	";
                    dt.Columns["TokuisakiCD"].ColumnName = "得意先";
                    dt.Columns["TokuisakiRyakuName"].ColumnName = "得意先名";
                    dt.Columns["KouritenCD"].ColumnName = "小売店";
                    dt.Columns["KouritenRyakuName"].ColumnName = "小売店名";
                    dt.Columns["SenpouHacchuuNO"].ColumnName = "先方発注番号";
                    dt.Columns["SenpouBusho"].ColumnName = "先方部署	";
                    dt.Columns["KibouNouki"].ColumnName = "希望納期";
                    dt.Columns["HacchuuDenpyouTekiyou"].ColumnName = "伝票摘要";
                    dt.Columns["Char1"].ColumnName = "ブランド名";
                    dt.Columns["Exhibition"].ColumnName = "展示会";
                    dt.Columns["JANCD"].ColumnName = "JANCD";
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
                    dt.Columns["SoukoName"].ColumnName = "倉庫";
                // ExportDataSetToExcel(dt);
                //dt.WriteXml("C:\\Shinyoh\\Project_Excel\\発注リスト.xlsx");
                // Datatable_To_Excel(dt);
                // }

                
            }
            base.FunctionProcess(tagID);
        }
        private void Datatable_To_Excel(DataTable dt)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            // Start Excel and get Application object.  
            excel = new Microsoft.Office.Interop.Excel.Application();
            // for making Excel visible  
            excel.Visible = false;
            excel.DisplayAlerts = false;
            // Creation a new Workbook  
            excelworkBook = excel.Workbooks.Add(Type.Missing);
            // Workk sheet  
            excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
            excelSheet.Name = "発注リスト";
            excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[dt.Columns.Count, dt.Columns.Count]];
            excelCellrange.EntireColumn.AutoFit();
            Microsoft.Office.Interop.Excel.Borders border = excelCellrange.Borders;
            border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            border.Weight = 2d;
        }

        private void ExportDataSetToExcel(DataTable dt)
        {
            //Creae an Excel application instance
            Excel.Application excelApp = new Excel.Application();

            //Create an Excel workbook instance and open it from the predefined location
             Excel.Workbook excelWorkBook = excelApp.Workbooks.Open(@"C:\\Org.xlsx");

           
                //Add a new worksheet to workbook with the Datatable name
                Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();
                excelWorkSheet.Name = "発注リスト";

                for (int i = 1; i < dt.Columns.Count + 1; i++)
                {
                    excelWorkSheet.Cells[1, i] = dt.Columns[i - 1].ColumnName;
                }

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    for (int k = 0; k < dt.Columns.Count; k++)
                    {
                        excelWorkSheet.Cells[j + 2, k + 1] = dt.Rows[j].ItemArray[k].ToString();
                    }
                }
           

            excelWorkBook.Save();
            excelWorkBook.Close();
            excelApp.Quit();
        }
        private void txtBrandCD_KeyDown(object sender, KeyEventArgs e)
        {
            multipurposeBL bl = new multipurposeBL();
            DataTable dt = bl.M_Multiporpose_SelectData(txtBrandCD.Text, 1, string.Empty, string.Empty);
            if (dt.Rows.Count > 0)
                lblBrand_Name.Text = dt.Rows[0]["Char1"].ToString();
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
        }
        private void Disable_Method()
        {
            txtJuchuuDate1.Enabled = false;
            txtJuchuuDate2.Enabled = false;
            txtJuchuuNO1.Enabled = false;
            txtJuchuuNO2.Enabled = false;
            txtUpdate_JuchuuDate1.Enabled = false;
            txtUpdate_JuchuuDate2.Enabled = false;
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
            obj.BrandCD = txtBrandCD.Text;
            obj.Year = txtYear.Text;
            obj.SS = chk_SS.Checked == true ? "1" : "0";
            obj.FW = chk_FW.Checked == true ? "1" : "0";
            obj.JuchuuDate1 = txtJuchuuDate1.Text;
            obj.JuchuuDate2 = txtJuchuuDate2.Text;
            obj.JuchuuNO1 = txtJuchuuNO1.Text;
            obj.Juchuu_UpdateDate1 = txtUpdate_JuchuuDate1.Text;
            obj.Juchuu_UpdateDate2 = txtUpdate_JuchuuDate2.Text;
            if (rdo_Hac.Checked)
                obj.Condition = "Hacchuu";
            else obj.Condition = "Juchuu";
            obj.LoginDate = baseEntity.LoginDate;
            DataTable dt = obj_Bl.GetHacchuuList(obj);
            return dt;
        }
    }
}