﻿using BL;
using CKM_CommonFunction;
using Entity;
using Shinyoh;
using Shinyoh_Search;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace MasterList_Tokuisaki
{
    public partial class MasterList_Tokuisaki : BaseForm
    {
        BaseEntity base_entity;
        CommonFunction cf;
        multipurposeEntity multi_Entity;
        BaseBL bbl = new BaseBL();
        DataTable dt = new DataTable();
        public MasterList_Tokuisaki()
        {
            InitializeComponent();
            cf = new CommonFunction();
        }

        private void MasterList_Tokuisaki_Load(object sender, EventArgs e)
        {
            ProgramID = "MasterList_Tokuisaki";
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
            SetButton(ButtonType.BType.Import, F10, "出力(F10)", true);
            SetButton(ButtonType.BType.Empty, F11, "", false);

            base_entity = _GetBaseData();
            txtChangeDate.Text = base_entity.LoginDate;
            txtTokuisakiCD.Focus();
            txtTokuisakiCD.ChangeDate = txtChangeDate;
            txtTokuisakiCD1.ChangeDate = txtChangeDate;
            UI_ErrorCheck();
        }

        private void UI_ErrorCheck()
        {
            txtTokuisakiCD1.E106Check(true, txtTokuisakiCD, txtTokuisakiCD1);
            txtYuubinNO2.E102MultiCheck(true, txtYuubinNO1, txtYuubinNO2);
            txtYuubinNO2.Yuubin_Juusho(true, txtYuubinNO1, txtYuubinNO2, string.Empty, string.Empty);
        }

        private void txtYuubinNO2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtJuusho.Text = string.Empty;
                if (!txtYuubinNO2.IsErrorOccurs)
                {
                    dt = txtYuubinNO2.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                        txtJuusho.Text = dt.Rows[0]["Juusho1"].ToString();
                }
            }
        }

        public override void FunctionProcess(string tagID)
        {
            if(tagID == "6")
            {
                cf.Clear(PanelDetail);
                txtTokuisakiCD.Focus();
            }
            if(tagID == "10")
            {
                if (ErrorCheck(PanelDetail))
                    Excel_Export();
            }
        }

        private void Excel_Export()
        {
            TokuisakiBL bl = new TokuisakiBL();
            dt = bl.Get_ExportData(Get_UIData());
            if (dt.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = false;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "得意先マスタリスト";
                for (int i = 1; i < dt.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dt.Columns[i - 1].ColumnName;
                }
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dt.Rows[i][j].ToString();
                    }
                }
                if (!System.IO.Directory.Exists("C:\\Output Excel Files"))
                    System.IO.Directory.CreateDirectory("C:\\Output Excel Files");
                workbook.SaveAs("C:\\Output Excel Files\\得意先マスタリスト.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                app.Quit();
            }
        }

        private TokuisakiEntity Get_UIData()
        {
            TokuisakiEntity entity = new TokuisakiEntity();
            if (rdo_RRevisionDate.Checked)
                entity.Output_Type = 0;
            else
                entity.Output_Type = 1;
            entity.TokuisakiCD = txtTokuisakiCD.Text;
            entity.TokuisakiCD1 = txtTokuisakiCD1.Text;
            entity.TokuisakiName = txtTokuisakiName.Text;
            entity.YuubinNO1 = txtYuubinNO1.Text;
            entity.YuubinNO2 = txtYuubinNO2.Text;
            entity.Juusho1 = txtJuusho.Text;
            entity.Tel11 = txtPhNO1.Text;
            entity.Tel12 = txtPhNO2.Text;
            entity.Tel13 = txtPhNO3.Text;
            entity.Remarks = txtRemarks.Text;
            return entity;
        }
    }
}