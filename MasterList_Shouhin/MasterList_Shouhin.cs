using BL;
using CKM_CommonFunction;
using Entity;
using Shinyoh;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace MasterList_Shouhin
{
    public partial class MasterList_Shouhin : BaseForm
    {
        BaseEntity base_entity;
        CommonFunction cf;
        multipurposeEntity multi_Entity;
        BaseBL bbl = new BaseBL();
        DataTable dtShouhin = new DataTable();
        ExportCSVExcel obj_Export;
        public MasterList_Shouhin()
        {
            InitializeComponent();
            cf = new CommonFunction();
            obj_Export = new ExportCSVExcel();
        }
        private void MasterList_Shouhin_Load(object sender, EventArgs e)
        {
            ProgramID = "MasterList_Shouhin";
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

            base_entity = _GetBaseData();
            txtChangeDate.Text = base_entity.LoginDate;
            txtShouhinCD_From.Focus();
            txtShouhinCD_From.ChangeDate = txtChangeDate;
            txtShouhinCD_To.ChangeDate = txtChangeDate;
            UI_ErrorCheck();
        }
        private void UI_ErrorCheck()
        {
            txtShouhinCD_To.E106Check(true, txtShouhinCD_From, txtShouhinCD_To);
            txtJANCD_To.E106Check(true, txtJANCD_From, txtJANCD_To);
            txtBrand_To.E106Check(true, txtBrand_From, txtBrand_To);
            txtColorNO2.E106Check(true, txtColorNO1, txtColorNO2);
            txtSizeNO2.E106Check(true, txtSizeNO1, txtSizeNO2);
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "6")
            {
                rdo_ChokkinDate.Checked = true;
                cf.Clear(PanelDetail);
                txtShouhinCD_From.Focus();
            }
            if (tagID == "10")
            {
                if (ErrorCheck(PanelDetail))
                {
                    Excel_Export();
                }

            }
        }
        private void Excel_Export()
        {
            ShouhinBL sh_bl = new ShouhinBL();
            dtShouhin = sh_bl.Get_ExportData(Get_UIData());
            if(dtShouhin.Rows.Count>0)
            {
                string ProgramID = "MasterList_Shouhin";
                string fname= "商品マスタリスト";
                string[] datacol = { "2", "33", "34" };
                string[] numcol = { "22", "23", "24", "37" };

                ExportCSVExcel list = new ExportCSVExcel();
                //list.stringCol = new string[1] { "10" };
                bool bl= list.ExcelOutputFile(dtShouhin, ProgramID, fname, fname, 45, datacol, numcol);
                if(bl)
                {
                    Clear();
                }

                //if (!System.IO.Directory.Exists("C:\\ShinYoh\\" + ProgramID + "\\"))
                //    System.IO.Directory.CreateDirectory("C:\\ShinYoh\\" + ProgramID + "\\");

                //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                //saveFileDialog1.InitialDirectory = @"C:\ShinYoh\" + ProgramID + "\"";

                ////for excel
                //saveFileDialog1.Filter = "ExcelFile|*.xlsx";
                //saveFileDialog1.FileName = fname;
                //saveFileDialog1.RestoreDirectory = true;
                //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                //{
                //    ExcelDesignSetting obj = new ExcelDesignSetting();
                //    obj.FilePath = saveFileDialog1.FileName;
                //    obj.SheetName = "Sheet1";
                //    obj.Start_Interior_Column = "A1";
                //    obj.End_Interior_Column = "AS1";
                //    obj.Interior_Color = Color.FromArgb(255, 192, 0);
                //    obj.Start_Font_Column = "A1";
                //    obj.End_Font_Column = "AS1";
                //    obj.Font_Color = Color.Black;
                //    obj.Start_Title_Center_Column = "A1";
                //    obj.End_Title_Center_Column = "AS1";
                //    obj.Number_Column = new List<int>();
                //    obj.Number_Column.Add(22);
                //    obj.Number_Column.Add(23);
                //    obj.Number_Column.Add(24);
                //    obj.Number_Column.Add(37);
                //    obj.Number_Format = "#,###,###";
                //    bool bl = obj_Export.ExportDataTableToExcel(dtShouhin, obj);
                //    if (bl)
                //    {
                //        bbl.ShowMessage("I203");
                //        Clear();
                //    }
                //}
            }
            else
            {
                bbl.ShowMessage("S013");
            }
        }
        private ShouhinEntity Get_UIData()
        {
            ShouhinEntity sh_e = new ShouhinEntity();
            if (rdo_ChokkinDate.Checked)
                sh_e.Output_Type = 0;
            else
                sh_e.Output_Type = 1;
            sh_e.ShouhinCD1 = txtShouhinCD_From.Text;
            sh_e.ShouhinCD2 = txtShouhinCD_To.Text;
            sh_e.JANCD = txtJANCD_From.Text;
            sh_e.JANCD1 = txtJANCD_To.Text;
            sh_e.ShouhinRyakuName = txtShouhinName.Text;
            sh_e.BrandCD = txtBrand_From.Text;
            sh_e.BrandCD1 = txtBrand_To.Text;
            sh_e.ColorNo1 = txtColorNO1.Text;
            sh_e.ColorNo2 = txtColorNO2.Text;
            sh_e.SizeNo1 = txtSizeNO1.Text;
            sh_e.SizeNo2 = txtSizeNO2.Text;
            sh_e.Remarks = txtRemarks.Text;
            sh_e.PC = PCID;
            sh_e.ProgramID = ProgramID;
            sh_e.InsertOperator = OperatorCD;
            return sh_e;
        }
        private void Clear()
        {
            cf.Clear(PanelDetail);
            rdo_ChokkinDate.Checked = true;
            txtShouhinCD_From.Focus();
            //txtShouhinCD_From.Text = string.Empty;
            //txtShouhinCD_To.Text = string.Empty;
            //txtJANCD_From.Text = string.Empty;
            //txtJANCD_To.Text = string.Empty;
            //txtShouhinName.Text = string.Empty;
            //txtBrand_From.Text = string.Empty;
            //txtBrand_To.Text = string.Empty;
            //txtColorNO1.Text = string.Empty;
            //txtColorNO2.Text = string.Empty;
            //txtSizeNO1.Text = string.Empty;
            //txtSizeNO2.Text = string.Empty;
            //txtRemarks.Text = string.Empty;
        }
    }
}
