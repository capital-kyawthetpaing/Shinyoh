using BL;
using CKM_CommonFunction;
using Entity;
using Shinyoh;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace JuchuuList {
    public partial class JuchuuList : BaseForm {
        BaseEntity baseEntity;
        JuchuuListBL juchuuListBL;
        CommonFunction cf;
        String chk=string.Empty;
        string YuuBinNO1 = string.Empty;
        string YuuBinNO2 = string.Empty;
        string Address = string.Empty;   
        ExportCSVExcel obj_Export;
        BaseBL bbl = new BaseBL();

        public JuchuuList()
        {
            InitializeComponent();
            baseEntity = new BaseEntity();
            juchuuListBL = new JuchuuListBL();
            cf=new CommonFunction();
            obj_Export = new ExportCSVExcel();
        }

        private void JuchuuList_Load(object sender, EventArgs e)
        {
           
            ProgramID = "JuchuuList";
            StartProgram();
            cboMode.Visible = false;
            txtOrderDate1.Focus();
            lblStaffCD_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblBrandName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblTokuisakiName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblKouritenName.BorderStyle = System.Windows.Forms.BorderStyle.None;

            txtStaffCD.lblName = lblStaffCD_Name;
            txtBrand.lblName = lblBrandName;
            txtTokuisaki.lblName = lblTokuisakiName;
            txtStore.lblName = lblKouritenName;

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
            Date_Setting();
            ErrorCheck();

            txtStaffCD.ChangeDate = txtTempDate;
            txtTokuisaki.ChangeDate = txtTempDate;
            txtStore.ChangeDate = txtTempDate;

            //if (txtName.Enabled == false)
            //{
            //    Control btn = this.TopLevelControl.Controls.Find("BtnF10", true)[0];
            //    txtDestOrderNo.NextControlName = btn.Name;
            //}else
            //    txtDestOrderNo.NextControlName = txtName.Name;
        }
        private void Date_Setting()
        {

            BaseEntity baseEntity = _GetBaseData();
            txtOrderDate1.Text = baseEntity.LoginDate;
            txtOrderDate2.Text = baseEntity.LoginDate;
            txtInputDate1.Text = baseEntity.LoginDate;
            txtInputDate2.Text = baseEntity.LoginDate;
            txtTempDate.Text = baseEntity.LoginDate;
        }
        private void ErrorCheck()
        {
           
            txtStaffCD.E101Check(true, "M_Staff", txtStaffCD,txtTempDate , null);
            txtTokuisaki.E101Check(true, "M_Tokuisaki", txtTokuisaki, txtTempDate, null);
            txtStore.E101Check(true, "M_Kouriten", txtStore, txtTempDate, null);
           // txtBrand.E101Check(true, "JuchuuList", txtBrand, null, null);

            txtYubin2.E102MultiCheck(true, txtYubin1, txtYubin2);
            txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, string.Empty, string.Empty);

            txtOrderDate1.E102Check(true);
            txtOrderDate2.E102Check(true);
            txtOrderDate1.E103Check(true);
            txtOrderDate2.E103Check(true);
            txtOrderDate2.E104Check(true,txtOrderDate1, txtOrderDate2);

            txtInputDate1.E103Check(true);
            txtInputDate2.E103Check(true);
            txtInputDate2.E104Check(true, txtInputDate1, txtInputDate2);

            txtOrderNo2.E106Check(true, txtOrderNo1, txtOrderNo2);

        }
        private void txtBrand_KeyDown(object sender, KeyEventArgs e)
        {
            //multipurposeBL bl = new multipurposeBL();
            //string brandName = txtBrand.Text.ToString();
            //DataTable dt = bl.M_Multiporpose_SelectData(brandName, 1,string.Empty,string.Empty);

            //if (dt.Rows.Count > 0)
            //    lblBrandName.Text = dt.Rows[0]["Char1"].ToString();
            //else lblBrandName.Text = string.Empty;
        }

        private void txtYubin2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtYubin2.IsErrorOccurs)
                {
                    if (txtYubin2.IsDatatableOccurs.Rows.Count > 0)
                    {
                        DataTable dt = txtYubin2.IsDatatableOccurs;
                        txtAddress.Text = dt.Rows[0]["Juusho1"].ToString();
                    }
                    else
                    {
                        if (txtYubin1.Text != YuuBinNO1 || txtYubin2.Text != YuuBinNO2)
                        {
                            txtAddress.Text = string.Empty;
                        }
                        else
                        {
                            txtAddress.Text = Address;
                        }
                    }
                }

            }
        }
        private void txtTokuisaki_Leave(object sender, EventArgs e)
        {
            if (!txtTokuisaki.IsErrorOccurs)
            {
                TokuisakiBL bl = new TokuisakiBL();
                DataTable dt = bl.M_Tokuisaki_Select(txtTokuisaki.Text, txtTempDate.Text, "E101");
                if (string.IsNullOrEmpty(txtTokuisaki.Text))
                {
                    Control control = this.TopLevelControl.Controls.Find("txtStore", true)[0];
                    control.Focus();
                }
                else
                {
                    if (dt.Rows[0]["ShokutiFLG"].ToString().Equals("1"))
                    {
                        txtName.Enabled = true;
                        txtYubin1.Enabled = true;
                        txtYubin2.Enabled = true;
                        txtAddress.Enabled = true;
                        txtPhNo1.Enabled = true;
                        txtPhNo2.Enabled = true;
                        txtPhNo3.Enabled = true;
                        chk = "1";
                    }
                    else
                    {
                        txtName.Enabled = false;
                        txtYubin1.Enabled = false;
                        txtYubin2.Enabled = false;
                        txtAddress.Enabled = false;
                        txtPhNo1.Enabled = false;
                        txtPhNo2.Enabled = false;
                        txtPhNo3.Enabled = false;
                        chk = "0";
                    }
                }
            }
        }
        private void Clear()
        {
            cf.Clear(PanelDetail);
            txtOrderDate1.Focus();
            Date_Setting();
            lblStaffCD_Name.Text = "";
            lblBrandName.Text = "";
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
                    if (PreviousCtrl != null)
                        PreviousCtrl.Focus();
                }
                else {
                    DataTable dt = new DataTable { TableName = "JuchuuListTable" };
                    dt = Get_Form_Object();
                    if (dt.Rows.Count > 0)
                    {

                        dt.Columns["JuchuuNO"].ColumnName = "受注番号";
                        dt.Columns["JuchuuDate"].ColumnName = "受発注日";
                        dt.Columns["StaffName"].ColumnName = "担当者	";
                        dt.Columns["TokuisakiCD"].ColumnName = "得意先コード";
                        dt.Columns["TokuisakiRyakuName"].ColumnName = "得意先名";
                        dt.Columns["KouritenCD"].ColumnName = "小売店コード";
                        dt.Columns["KouritenRyakuName"].ColumnName = "小売店";
                        dt.Columns["SenpouHacchuuNO"].ColumnName = "先方発注番号";
                        dt.Columns["SenpouBusho"].ColumnName = "先方部署	";
                        dt.Columns["KibouNouki"].ColumnName = "希望納期";
                        dt.Columns["JuchuuDenpyouTekiyou"].ColumnName = "伝票摘要";
                        dt.Columns["Char1"].ColumnName = "ブランド";
                        dt.Columns["Exhibition"].ColumnName = "展示会";
                        dt.Columns["JANCD"].ColumnName = "JANコード";
                        dt.Columns["ShouhinCD"].ColumnName = "商品";
                        dt.Columns["ShouhinName"].ColumnName = "品名";
                        dt.Columns["ColorRyakuName"].ColumnName = "カラー";
                        dt.Columns["SizeNO"].ColumnName = "サイズ";
                        dt.Columns["JuchuuSuu"].ColumnName = "数量";
                        dt.Columns["UriageTanka"].ColumnName = "上代	";
                        dt.Columns["HacchuuTanka"].ColumnName = "下代";
                        dt.Columns["Free"].ColumnName = "Free";
                        dt.Columns["JuchuuMeisaiTekiyou"].ColumnName = "明細摘要";
                        dt.Columns["SiiresakiCD"].ColumnName = "発注先";
                        dt.Columns["SiiresakiRyakuName"].ColumnName = "発注先名";
                        dt.Columns.Remove("発注先名");
                        dt.Columns["SoukoName"].ColumnName = "倉庫";

                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                        saveFileDialog1.InitialDirectory = @"C:\CSV\";


                        //for excel
                        saveFileDialog1.Filter = "ExcelFile|*.xls";
                        saveFileDialog1.FileName = "受注リスト.xls";
                        saveFileDialog1.RestoreDirectory = true;
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            ExcelDesignSetting obj = new ExcelDesignSetting();
                            obj.FilePath = saveFileDialog1.FileName;
                            obj.SheetName = "受注リスト";
                            obj.Start_Interior_Column = "A1";
                            obj.End_Interior_Column = "Y1";
                            obj.Interior_Color = Color.Orange;
                            obj.Start_Font_Column = "A1";
                            obj.End_Font_Column = "Y1";
                            obj.Font_Color = Color.Black;
                            //For column B
                            obj.Date_Column = new List<int>();
                            obj.Date_Column.Add(2);
                            obj.Date_Format = "YYYY/MM/DD";
                            obj.Start_Title_Center_Column = "A1";
                            obj.End_Title_Center_Column = "Y1";
                            //for column T,U
                            obj.Number_Column = new List<int>();
                            obj.Number_Column.Add(20);
                            obj.Number_Column.Add(21);
                            obj.Number_Format = "#,###,###";
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
                }
                
            }
            base.FunctionProcess(tagID);
        }
      
        private DataTable Get_Form_Object()
        {
            JuchuuEntity obj = new JuchuuEntity();
            obj.JuhuuDate1 = txtOrderDate1.Text;
            obj.JuhuuDate2 = txtOrderDate2.Text;
            obj.JuhuuNO1 = txtOrderNo1.Text;
            obj.JuhuuNO2 = txtOrderNo2.Text;
            obj.InputDate1 = txtInputDate1.Text;
            obj.InputDate2 = txtInputDate2.Text;
            obj.StaffCD = txtStaffCD.Text;
            obj.BrandCD = txtBrand.Text;
            obj.Year = txtYear.Text;
            obj.SS = chk_SS.Checked == true ? "1" : "0";
            obj.FW = chk_FW.Checked == true ? "1" : "0";
            obj.Store = txtStore.Text;
            obj.DestOrderNo = txtDestOrderNo.Text;
            obj.Name = txtName.Text;
            obj.YuubinNo1 = txtYubin1.Text;
            obj.YuubinNo2 = txtYubin2.Text;
            obj.Juusho = txtAddress.Text;
            obj.Tel1 = txtPhNo1.Text;
            obj.Tel2 = txtPhNo2.Text;
            obj.Tel3 = txtPhNo3.Text;

            if (chk.Equals("1")&& (!string.IsNullOrEmpty(txtTokuisaki.Text)))
            {
                obj.Condition = "Tokuisaki";
            }
            else obj.Condition = "Juchuu";
            obj.LoginDate = baseEntity.LoginDate;
            DataTable dataTable = juchuuListBL.JuchuuList_Excel(obj);
            return dataTable;
        }
    }
}
