﻿using BL;
using Entity;
using Shinyoh;
using System;
using CKM_CommonFunction;
using System.Windows.Forms;
using System.Data;
using Shinyoh_Controls;
using Shinyoh_Search;
using System.Text;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace MasterTouroku_Shouhin
{
    public partial class MasterTouroku_Shouhin : BaseForm
    {
        BaseEntity base_entity;
        CommonFunction cf;
        multipurposeEntity multi_Entity;
        BaseBL bbl = new BaseBL();
        bool bl = false;
        ShouhinBL shouhinbl = new ShouhinBL();
        public MasterTouroku_Shouhin()
        {
            InitializeComponent();
            cf = new CommonFunction();
        }

        private void MasterTouroku_Shouhin_Load(object sender, EventArgs e)
        {
            ProgramID = "MasterTourokuShouhin";
            StartProgram();
            cboMode.Bind(false, multi_Entity);
            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "新規(F2)", true);
            SetButton(ButtonType.BType.Update, F3, "修正(F3)", true);
            SetButton(ButtonType.BType.Delete, F4, "削除(F4)", true);
            SetButton(ButtonType.BType.Inquiry, F5, "照会(F5)", true);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", false);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            SetButton(ButtonType.BType.Empty, F8, "", false);
            SetButton(ButtonType.BType.Import, F10, "CSV取込(F10)", true);
            SetButton(ButtonType.BType.Empty, F11, "", false);

            ChangeMode(Mode.New);
            base_entity = _GetBaseData();
            txtProduct.ChangeDate = txtChangeDate;
            txtCopyProduct.ChangeDate = txtCopyChangeDate;

            txtTani.lblName = lbl_TaniCD;
            txtBrand.lblName = lbl_BrandCD;
            txtColor.lblName = lbl_ColorNO;
            txtSize.lblName = lbl_SizeNO;
            txtTaxRate.lblName = lbl_TaxtRate;
            txtIEvaluation.lblName = lbl_IEvaluation;
            txtIManagement.lblName = lbl_IManagement;
        }

        private void ChangeMode(Mode mode)
        {
            txtProduct.Focus();
            switch (mode)
            {
                case Mode.New:
                    txtChangeDate.NextControlName = txtCopyProduct.Name;
                    UI_ErrorCheck();
                    txtCopyProduct.Enabled = true;
                    txtCopyChangeDate.Enabled = true;

                    txtChangeDate.E132Check(true, "M_Shouhin", txtProduct, txtChangeDate, null);
                    txtChangeDate.E133Check(false, "M_Shouhin", txtProduct, txtChangeDate, null);
                    txtChangeDate.E270Check(false, "M_Shouhin", txtProduct, txtChangeDate);

                    txtCopyChangeDate.E102MultiCheck(true, txtCopyProduct, txtCopyChangeDate);
                    txtCopyChangeDate.E103Check(true);
                    txtCopyChangeDate.E133Check(true, "M_Shouhin", txtCopyProduct, txtCopyChangeDate, null);

                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    break;
                case Mode.Update:
                    UI_ErrorCheck();
                    txtCopyProduct.Enabled = false;
                    txtCopyChangeDate.Enabled = false;

                    txtChangeDate.E132Check(false, "M_Shouhin", txtProduct, txtChangeDate, null);
                    txtChangeDate.E133Check(true, "M_Shouhin", txtProduct, txtChangeDate, null);
                    txtChangeDate.E270Check(false, "M_Shouhin", txtProduct, txtChangeDate);

                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    UI_ErrorCheck();
                    txtCopyProduct.Enabled = false;
                    txtCopyChangeDate.Enabled = false;

                    txtChangeDate.E132Check(false, "M_Shouhin", txtProduct, txtChangeDate, null);
                    txtChangeDate.E133Check(true, "M_Shouhin", txtProduct, txtChangeDate, null);
                    txtChangeDate.E270Check(true, "M_Shouhin", txtProduct, txtChangeDate);

                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;
                    break;
                case Mode.Inquiry:
                    UI_ErrorCheck();
                    txtCopyProduct.Enabled = false;
                    txtCopyChangeDate.Enabled = false;

                    txtChangeDate.E132Check(false, "M_Shouhin", txtProduct, txtChangeDate, null);
                    txtChangeDate.E133Check(true, "M_Shouhin", txtProduct, txtChangeDate, null);
                    txtChangeDate.E270Check(false, "M_Shouhin", txtProduct, txtChangeDate);

                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;
                    break;
            }
        }

        private void UI_ErrorCheck()
        {
            cf.Clear(PanelTitle);
            cf.Clear(Panel_Detail);
            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(Panel_Detail);

            txtProduct.E102Check(true);
            txtChangeDate.E102Check(true);
            txtChangeDate.E103Check(true);
            txtHinbanCD.E102Check(true);
            txtProductName.E102Check(true);
            txtShouhinRyakuName.E102Check(true);

            txtTani.E102Check(true);
            txtTani.E101Check(true, "M_Shouhin", txtTani, null, null);

            txtBrand.E102Check(true);
            txtBrand.E101Check(true, "M_Shouhin", txtBrand, null, null);

            txtColor.E102Check(true);
            txtColor.E101Check(true, "M_Shouhin", txtColor, null, null);

            txtSize.E102Check(true);
            txtSize.E101Check(true, "M_Shouhin", txtSize, null, null);

            txtRetailPrice.E102Check(true);
            txtLowerPrice.E102Check(true);
            txtStandardPrice.E102Check(true);

            txtTaxRate.E102Check(true);
            txtTaxRate.E101Check(true, "M_Shouhin", txtTaxRate, null, null);

            txtIEvaluation.E102Check(true);
            txtIEvaluation.E101Check(true, "M_Shouhin", txtIEvaluation, null, null);

            txtIManagement.E102Check(true);
            txtIManagement.E101Check(true, "M_Shouhin", txtIManagement, null, null);

            txtMajorSuppliers.E102Check(true);
            txtMajorSuppliers.E101Check(true, "M_Siiresaki", txtMajorSuppliers, txtChangeDate, null);

            txtHandlingEndDate.E103Check(true);
            txtSalesStopDate.E103Check(true);
            txtHacchuuLot.E102Check(true);

            lbl_TaniCD.Text = string.Empty;
            lbl_TaniCD.BorderStyle = BorderStyle.None;
            lbl_BrandCD.Text = string.Empty;
            lbl_BrandCD.BorderStyle = BorderStyle.None;
            lbl_ColorNO.Text = string.Empty;
            lbl_ColorNO.BorderStyle = BorderStyle.None;
            lbl_SizeNO.Text = string.Empty;
            lbl_SizeNO.BorderStyle = BorderStyle.None;
            lbl_TaxtRate.Text = string.Empty;
            lbl_TaxtRate.BorderStyle = BorderStyle.None;
            lbl_IEvaluation.Text = string.Empty;
            lbl_IEvaluation.BorderStyle = BorderStyle.None;
            lbl_IManagement.Text = string.Empty;
            lbl_IManagement.BorderStyle = BorderStyle.None;
            lbl_MajorSuppliers.Text = string.Empty;
            lbl_MajorSuppliers.BorderStyle = BorderStyle.None;
            pImage.ImageLocation = "";
        }

        public override void FunctionProcess(string tagID)
        {
            if (tagID == "2")
            {
                ChangeMode(Mode.New);
            }
            if (tagID == "3")
            {
                ChangeMode(Mode.Update);
            }
            if (tagID == "4")
            {
                ChangeMode(Mode.Delete);
            }
            if (tagID == "5")
            {
                ChangeMode(Mode.Inquiry);
            }
            if (tagID == "6")
            {
                txtProduct.Focus();

                UI_ErrorCheck();
                if (cboMode.SelectedValue.Equals("2") || cboMode.SelectedValue.Equals("3") || cboMode.SelectedValue.Equals("4"))
                {
                    txtCopyProduct.Enabled = false;
                    txtCopyChangeDate.Enabled = false;
                }
            }
            if (tagID == "10")
            {
                string Xml = GetFileData();
                if (!string.IsNullOrEmpty(Xml))
                {
                    if (bbl.ShowMessage("Q206") != DialogResult.Yes)
                    {
                        PreviousCtrl.Focus();
                    }
                    else
                    {
                        ShouhinBL bl = new ShouhinBL();
                        string chk_val = string.Empty;
                        if (rdo_Registragion.Checked)
                            chk_val = "create_update";
                        else chk_val = "delete";
                        bl.CSV_M_Shouhin_CUD(Xml, chk_val);
                    }
                }
            }
            if (tagID == "12")
            {
                if (ErrorCheck(PanelTitle) && ErrorCheck(Panel_Detail))
                {
                    DBProcess();
                    switch (cboMode.SelectedValue)
                    {
                        case "1":
                            ChangeMode(Mode.New);
                            break;
                        case "2":
                            ChangeMode(Mode.Update);
                            break;
                        case "3":
                            ChangeMode(Mode.Delete);
                            break;
                        case "4":
                            ChangeMode(Mode.Inquiry);
                            break;
                    }
                }
            }
            base.FunctionProcess(tagID);
        }

        private void DBProcess()
        {
            ShouhinEntity shouhin_entity = getShouhin();
            switch (cboMode.SelectedValue)
            {
                case "1":
                    shouhin_entity.Mode = "New";
                    break;
                case "2":
                    shouhin_entity.Mode = "Update";
                    break;
                case "3":
                    shouhin_entity.Mode = "Delete";
                    break;
            }
            Shouhin_IUD(shouhin_entity);
        }

        private ShouhinEntity getShouhin()
        {
            ShouhinEntity shouhin_entity = new ShouhinEntity();
            shouhin_entity.Product = txtProduct.Text.Trim();
            shouhin_entity.RevisionDate = txtChangeDate.Text.Trim();
            shouhin_entity.CopyProduct = txtCopyProduct.Text.Trim();
            shouhin_entity.CopyRevisionDate = txtCopyChangeDate.Text.Trim();
            shouhin_entity.ShokutiFLG = chkShukou.Checked ? 1 : 0;
            shouhin_entity.HinbanCD = txtHinbanCD.Text.Trim();
            shouhin_entity.ProductName = txtProductName.Text.Trim();
            shouhin_entity.ShouhinRyakuName = txtShouhinRyakuName.Text.Trim();
            shouhin_entity.KatakanaName = txtKatakanaName.Text.Trim();
            shouhin_entity.JANCD = txtJANCD.Text.Trim();
            shouhin_entity.Exhibition = txtExhibition.Text.Trim();
            shouhin_entity.SS = chkSS.Checked ? "1" : "0";
            shouhin_entity.FW = chkFW.Checked ? "1" : "0";
            shouhin_entity.TaniCD = txtTani.Text.Trim();
            shouhin_entity.BrandCD = txtBrand.Text.Trim();
            shouhin_entity.Color = txtColor.Text.Trim();
            shouhin_entity.Size = txtSize.Text.Trim();
            shouhin_entity.JoudaiTanka = txtRetailPrice.Text.Trim();
            shouhin_entity.GedaiTanka = txtLowerPrice.Text.Trim();
            shouhin_entity.HyoujunGenkaTanka = txtStandardPrice.Text.Trim();
            shouhin_entity.ZeirituKBN = Convert.ToInt32(txtTaxRate.Text.Trim());
            shouhin_entity.ZaikoHyoukaKBN = Convert.ToInt32(txtIEvaluation.Text.Trim());
            shouhin_entity.ZaikoKanriKBN = Convert.ToInt32(txtIManagement.Text.Trim());
            shouhin_entity.MainSiiresakiCD = txtMajorSuppliers.Text.Trim();
            shouhin_entity.ToriatukaiShuuryouDate = txtHandlingEndDate.Text.Trim();
            shouhin_entity.HanbaiTeisiDate = txtSalesStopDate.Text.Trim();
            shouhin_entity.Model_No = txtModelNo.Text.Trim();
            shouhin_entity.Model_Name = txtModelName.Text.Trim();
            shouhin_entity.FOB = txtFOB.Text.Trim();
            shouhin_entity.Shipping_Place = txtShippingPlace.Text.Trim();
            shouhin_entity.HacchuuLot = Convert.ToDecimal(txtHacchuuLot.Text.Trim());
            shouhin_entity.ImageFilePathName = txtImage.Text.Trim();
            shouhin_entity.Image = !string.IsNullOrEmpty(txtImage.Text.Trim()) ? System.IO.File.ReadAllBytes(txtImage.Text) : new byte[] { };
            shouhin_entity.Remarks = txtRemarks.Text;
            shouhin_entity.KensakuHyouziJun = !string.IsNullOrWhiteSpace(txtKensakuHyouziJun.Text.Trim()) ? Convert.ToInt32(txtKensakuHyouziJun.Text.Trim()) : 0;
            shouhin_entity.InsertOperator = base_entity.OperatorCD;
            shouhin_entity.UpdateOperator = base_entity.OperatorCD;

            //for log table
            shouhin_entity.PC = base_entity.PC;
            shouhin_entity.ProgramID = base_entity.ProgramID;
            shouhin_entity.KeyItem = txtProduct.Text + " " + txtChangeDate.Text;
            return shouhin_entity;
        }

        private void Shouhin_IUD(ShouhinEntity shouhin_entity)
        {
            shouhinbl.Shouhin_IUD(shouhin_entity);
        }

        private void txtChangeDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtChangeDate.IsErrorOccurs)
                {
                    if (cboMode.SelectedValue.ToString() == "2")
                    {
                        EnableAndDisablePanel();
                    }
                    else if (cboMode.SelectedValue.ToString() == "3" || cboMode.SelectedValue.ToString() == "4")
                    {
                        cf.DisablePanel(PanelTitle);
                    }
                }
                DataTable dt = txtChangeDate.IsDatatableOccurs;
                if (dt.Rows.Count > 0 && cboMode.SelectedValue.ToString() != "1")
                {
                    DB_To_UI(dt);
                }
            }
        }

        private void txtCopyChangeDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cboMode.SelectedValue.ToString() == "1")
            {
                if (!txtCopyChangeDate.IsErrorOccurs)
                {
                    EnableAndDisablePanel();
                    DataTable dt = txtCopyChangeDate.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                        DB_To_UI(dt);
                }
            }
        }

        private void EnableAndDisablePanel()
        {
            cf.DisablePanel(PanelTitle);
            cf.EnablePanel(Panel_Detail);
            chkShukou.Focus();
        }

        private void DB_To_UI(DataTable dt)
        {
            if(dt.Rows[0]["MessageID"].ToString() == "E132")
            {
                if (dt.Rows[0]["ShokutiFLG"].ToString() == "1")
                    chkShukou.Checked = true;
                else
                    chkShukou.Checked = false;
                txtHinbanCD.Text = dt.Rows[0]["HinbanCD"].ToString();
                txtProductName.Text = dt.Rows[0]["ShouhinName"].ToString();
                txtShouhinRyakuName.Text = dt.Rows[0]["ShouhinRyakuName"].ToString();
                txtKatakanaName.Text = dt.Rows[0]["KanaName"].ToString();
                txtJANCD.Text = dt.Rows[0]["JANCD"].ToString();
                txtExhibition.Text = dt.Rows[0]["YearTerm"].ToString();
                if (dt.Rows[0]["SeasonSS"].ToString() == "1")
                    chkSS.Checked = true;
                else
                    chkFW.Checked = false;
                if (dt.Rows[0]["SeasonFW"].ToString() == "1")
                    chkFW.Checked = true;
                else
                    chkFW.Checked = false;
                txtTani.Text = dt.Rows[0]["TaniCD"].ToString();
                lbl_TaniCD.Text = dt.Rows[0]["TaniName"].ToString();
                txtBrand.Text = dt.Rows[0]["BrandCD"].ToString();
                lbl_BrandCD.Text = dt.Rows[0]["BrandName"].ToString();
                txtColor.Text = dt.Rows[0]["ColorNO"].ToString();
                lbl_ColorNO.Text = dt.Rows[0]["ColorName"].ToString();
                txtSize.Text = dt.Rows[0]["SizeNO"].ToString();
                lbl_SizeNO.Text = dt.Rows[0]["SizeName"].ToString();
                txtRetailPrice.Text = dt.Rows[0]["JoudaiTanka"].ToString();
                txtLowerPrice.Text = dt.Rows[0]["GedaiTanka"].ToString();
                txtStandardPrice.Text = dt.Rows[0]["HyoujunGenkaTanka"].ToString();
                txtTaxRate.Text = dt.Rows[0]["ZeirituKBN"].ToString();
                lbl_TaxtRate.Text = dt.Rows[0]["ZeirituKBN_Name"].ToString();
                txtIEvaluation.Text = dt.Rows[0]["ZaikoHyoukaKBN"].ToString();
                lbl_IEvaluation.Text = dt.Rows[0]["ZaikoHyoukaKBN_Name"].ToString();
                txtIManagement.Text = dt.Rows[0]["ZaikoKanriKBN"].ToString();
                lbl_IManagement.Text = dt.Rows[0]["ZaikoKanriKBN_Name"].ToString();
                txtMajorSuppliers.Text = dt.Rows[0]["MainSiiresakiCD"].ToString();
                lbl_MajorSuppliers.Text = dt.Rows[0]["SiiresakiRyakuName"].ToString();
                txtHandlingEndDate.Text = dt.Rows[0]["ToriatukaiShuuryouDate"].ToString();
                txtSalesStopDate.Text = dt.Rows[0]["HanbaiTeisiDate"].ToString();
                txtModelNo.Text = dt.Rows[0]["Model_No"].ToString();
                txtModelName.Text = dt.Rows[0]["Model_Name"].ToString();
                txtFOB.Text = dt.Rows[0]["FOB"].ToString();
                txtShippingPlace.Text = dt.Rows[0]["Shipping_Place"].ToString();
                txtHacchuuLot.Text = dt.Rows[0]["HacchuuLot"].ToString();
                txtImage.Text = dt.Rows[0]["ShouhinImageFilePathName"].ToString();

                if(!string.IsNullOrEmpty(dt.Rows[0]["ShouhinImage"].ToString()))
                {
                    byte[] imgBytes = (byte[])dt.Rows[0]["ShouhinImage"];
                    pImage.Image = Image.FromStream(new MemoryStream(imgBytes));
                }

                txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();
                txtKensakuHyouziJun.Text = dt.Rows[0]["KensakuHyouziJun"].ToString();
            }
        }

        private void txtImage_KeyDown(object sender, KeyEventArgs e)
        {
            if (!System.IO.File.Exists(txtImage.Text))
            {
                txtImage.Focus();
                pImage.ImageLocation = "";
                bbl.ShowMessage("E128");
            }
            else
            {
                pImage.ImageLocation = txtImage.Text;
            }
        }

        private string GetFileData()
        {
            var filePath = string.Empty;
            ShouhinEntity obj = new ShouhinEntity();
            string Xml = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\CSV Folder\\";
                openFileDialog.Title = "Browse CSV Files";
                openFileDialog.Filter = "csv files (*.csv)|*.csv";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                DataTable create_dt = new DataTable();
                Add_Datatable_Column(create_dt);
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    string[] csvRows = File.ReadAllLines(filePath);
                    var bl_list = new List<bool>();
                    for (int i = 1; i < csvRows.Length; i++)
                    {
                        string error = "false";
                        var data = csvRows[i].Split(',');
                        DataRow dr = create_dt.NewRow();
                        for (int j = 0; j < data.Length; j++)
                        {
                            if (string.IsNullOrWhiteSpace(data[j]))
                                dr[j] = DBNull.Value;
                            else
                                dr[j] = data[j].ToString();
                        }
                        dr["UsedFlg"] = "0";
                        dr["InsertOperator"] = base_entity.OperatorCD;
                        dr["UpdateOperator"] = base_entity.OperatorCD;

                        string[] NullCheck_List = { "0", "1", "2", "3", "4", "5", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22"};
                        string[] NullCheck_Msg = { "商品CD未入力エラー", "改定日未入力エラー", "諸口未入力エラー", "品番CD未入力エラー", "商品名未入力エラー", "略名未入力エラー", "単位CD未入力エラー", "ブランドCD未入力エラー", "カラーNO未入力エラー", "サイズNO未入力エラー", "上代単価未入力エラー", "下代単価未入力エラー", "標準原価単価未入力エラー", "税率区分未入力エラー", "在庫評価区分未入力エラー", "在庫管理区分未入力エラー", "主要仕入先未入力エラー" };
                        string[] ByteCheck_List = { "0_50", "3_20", "4_100", "5_80", "6_80", "8_13", "9_6", "10_6", "11_6", "12_2", "13_10", "14_13", "15_13", "22_10", "32_80"};
                        string[] ByteCheck_Msg = { "商品CD桁数エラー", "品番CD桁数エラー", "商品名桁数エラー", "略名桁数エラー", "カナ名桁数エラー", "JANCD桁数エラー", "年度桁数エラー", "シーズンSS桁数エラー", "シーズンFW桁数エラー", "単位CD桁数エラー", "ブランドCD桁数エラー", "カラーNO桁数エラー", "サイズNO桁数エラー", "主要仕入先CD桁数エラー", "備考桁数エラー" };
                        string[] ValueCheck_List = { "2", "18", "19", "20" };
                        string[] ValueCheck_Amt = { "1", "2", "2", "1" };
                        string[] DateCheck_List = { "1", "22", "23" };
                        string[] NonNumeric_List = { "15", "16", "17", "26" };
                        string InputValue_Msg = "入力可能値外エラー";
                        string[] MasterCheck_List = { "11", "12", "13", "14", "21" };
                        string[] MasterCheck_ID = { "102", "103", "104", "105" };
                        string[] MasterCheck_Msg = { "単位CD未登録エラー", "ブランドCD未登録エラー", "カラーNO未登録エラー", "サイズNO未登録エラー", "主要仕入先CD未登録エラー" };

                        for(int nc = 0; nc < NullCheck_List.Length; nc++)
                        {
                            int ncl_index = Convert.ToInt32(NullCheck_List[nc].ToString());
                            if (Null_Check(data[ncl_index].ToString(), i, NullCheck_Msg[nc].ToString()))
                                error = "true";
                        }

                        for (int bc = 0; bc < ByteCheck_List.Length; bc++)
                        {
                            var bcl = ByteCheck_List[bc].ToString().Split('_');
                            int bcl_index = Convert.ToInt32(bcl[0]);
                            int bcl_len = Convert.ToInt32(bcl[1]);
                            if (Byte_Check(bcl_len, data[bcl_index].ToString(), i, ByteCheck_Msg[bc].ToString()))
                                error = "true";
                        }

                        for (int vc = 0; vc < ValueCheck_List.Length; vc++)
                        {
                            int vcl_index = Convert.ToInt32(ValueCheck_List[vc].ToString());
                            int vc_Amount = Convert.ToInt32(ValueCheck_Amt[vc].ToString());
                            if (Value_Check(data[vcl_index].ToString(), i, vc_Amount, InputValue_Msg))
                                error = "true";
                        }

                        for(int dc = 0; dc < DateCheck_List.Length; dc++)
                        {
                            int dcl_index = Convert.ToInt32(DateCheck_List[dc].ToString());
                            if (Date_Check(data[dcl_index].ToString(), i, InputValue_Msg))
                                error = "true";
                        }

                        for(int nn = 0; nn < NonNumeric_List.Length; nn++)
                        {
                            int nnl_index = Convert.ToInt32(NonNumeric_List[nn].ToString());
                            if (NonNumeric_Check(data[nnl_index].ToString(), i, InputValue_Msg))
                                error = "true";
                        }

                        for(int mc = 0; mc < MasterCheck_List.Length; mc++)
                        {
                            string CD_ID = string.Empty, Key_Date = string.Empty;
                            int type;
                            int mcl_index = Convert.ToInt32(MasterCheck_List[mc].ToString());
                            if(mc != MasterCheck_List.Length - 1)
                            {
                                CD_ID = MasterCheck_ID[mc].ToString();
                                Key_Date = data[mcl_index].ToString();
                                type = 0;
                            }
                            else
                            {
                                CD_ID = data[0].ToString();
                                Key_Date = data[1].ToString();
                                type = 1;
                            }

                            if (Master_Check(CD_ID, Key_Date, type, i, MasterCheck_Msg[mc].ToString()))
                                error = "true";
                        }

                        if (ImageFile_Check(data[30].ToString(), i, "指定したパスにファイルが存在しないエラー"))
                            error = "true";
                        else
                            dr[30] = System.IO.File.ReadAllBytes(data[30].ToString());

                        dr["Error"] = error;
                        create_dt.Rows.Add(dr);
                    }
                    Xml = cf.DataTableToXml(create_dt);
                }
                else
                {
                    Xml = string.Empty;
                }
            }
            return Xml;
        }

        private bool Null_Check(string obj_text, int line_no, string error_msg)
        {
            bl = false;
            if (string.IsNullOrWhiteSpace(obj_text))
            {
                bbl.ShowMessage("E276", line_no.ToString(), error_msg);
                bl = true;
            }
            return bl;
        }
        private bool Byte_Check(int obj_len, string obj_text, int line_no, string error_msg)
        {
            bl = false;
            if (cf.IsByteLengthOver(obj_len, obj_text))
            {
                bbl.ShowMessage("E276", line_no.ToString(), error_msg);
                bl = true;
            }
            return bl;
        }
        public bool Date_Check(string csv_Date, int line_no, string error_msg)
        {
            bl = false;
            if (!string.IsNullOrWhiteSpace(csv_Date) || csv_Date != "NULL")
            {
                if (!cf.CheckDateValue(csv_Date))
                {
                    bbl.ShowMessage("E276", line_no.ToString(), error_msg);
                    bl = true;
                }
            }
            return bl;
        }
        public bool Value_Check(string obj_text, int line_no, int Amount, string error_msg)
        {
            bl = false;
            int n;
            if(!int.TryParse(obj_text, out n))
            {
                bbl.ShowMessage("E276", line_no.ToString(), error_msg);
                bl = true;
            }
            else if ((Convert.ToInt32(obj_text) < 0) || (Convert.ToInt32(obj_text) > Amount))
            {
                bbl.ShowMessage("E276", line_no.ToString(), error_msg);
                bl = true;
            }
            return bl;
        }
        public bool NonNumeric_Check(string obj_text, int line_no, string error_msg)
        {
            bl = false;
            int n;
            if(!int.TryParse(obj_text, out n))
            {
                bbl.ShowMessage("E276", line_no.ToString(), error_msg);
                bl = true;
            }
            return bl;
        }
        public bool Master_Check(string CD_ID, string Key_Date, int type, int line_no, string error_msg)
        {
            SiiresakiBL siiresakibl = new SiiresakiBL();
            bl = false;
            DataTable dt;
            if (type == 0)
                dt = shouhinbl.Shouhin_Check(CD_ID, Key_Date, "E101");
            else
                dt = siiresakibl.Siiresaki_Select_Check(CD_ID, Key_Date, "E101");
            if(dt.Rows.Count<1)
            {
                bbl.ShowMessage("E276", line_no.ToString(), error_msg);
                bl = true;
            }
            return bl;
        }
        public bool ImageFile_Check(string obj_text, int line_no, string error_msg)
        {
            bl = false;
            if(!System.IO.File.Exists(obj_text))
            {
                bbl.ShowMessage("E276", line_no.ToString(), error_msg);
                bl = true;
            }
            return bl;
        }

        public void Add_Datatable_Column(DataTable create_dt)
        {
            create_dt.Columns.Add("ShouhinCD");
            create_dt.Columns.Add("ChangeDate");
            create_dt.Columns.Add("ShokutiFLG");
            create_dt.Columns.Add("ShouhinName");
            create_dt.Columns.Add("ShouhinRyakuName");
            create_dt.Columns.Add("KanaName");
            create_dt.Columns.Add("KensakuHyouziJun");
            create_dt.Columns.Add("JANCD");
            create_dt.Columns.Add("YearTerm");
            create_dt.Columns.Add("SeasonSS");
            create_dt.Columns.Add("SeasonFW");
            create_dt.Columns.Add("TaniCD");
            create_dt.Columns.Add("BrandCD");
            create_dt.Columns.Add("ColorNO");
            create_dt.Columns.Add("SizeNO");
            create_dt.Columns.Add("JoudaiTanka");
            create_dt.Columns.Add("GedaiTanka");
            create_dt.Columns.Add("HyoujunGenkaTanka");
            create_dt.Columns.Add("ZeirituKBN");
            create_dt.Columns.Add("ZaikoHyoukaKBN");
            create_dt.Columns.Add("ZaikoKanriKBN");
            create_dt.Columns.Add("MainSiiresakiCD");
            create_dt.Columns.Add("ToriatukaiShuuryouDate");
            create_dt.Columns.Add("HanbaiTeisiDate");
            create_dt.Columns.Add("Model_No");
            create_dt.Columns.Add("Model_Name");
            create_dt.Columns.Add("FOB");
            create_dt.Columns.Add("Shipping_Place");
            create_dt.Columns.Add("HacchuuLot");
            create_dt.Columns.Add("ShouhinImageFilePathName");
            create_dt.Columns.Add("ShouhinImage");
            create_dt.Columns.Add("Remarks");
            create_dt.Columns.Add("UsedFlg");
            create_dt.Columns.Add("InsertOperator");
            create_dt.Columns.Add("UpdateOperator");
            create_dt.Columns.Add("Error");
        }

        private void txtTani_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                lbl_TaniCD.Text = string.Empty;
                if(!txtTani.IsErrorOccurs)
                {
                    DataTable dt = txtTani.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                        lbl_TaniCD.Text = dt.Rows[0]["char1"].ToString();
                }
            }
        }

        private void txtBrand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lbl_BrandCD.Text = string.Empty;
                if (!txtBrand.IsErrorOccurs)
                {
                    DataTable dt = txtBrand.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                        lbl_BrandCD.Text = dt.Rows[0]["char1"].ToString();
                }
            }
        }

        private void txtColor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lbl_ColorNO.Text = string.Empty;
                if (!txtColor.IsErrorOccurs)
                {
                    DataTable dt = txtColor.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                        lbl_ColorNO.Text = dt.Rows[0]["char1"].ToString();
                }
            }
        }

        private void txtSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lbl_SizeNO.Text = string.Empty;
                if (!txtSize.IsErrorOccurs)
                {
                    DataTable dt = txtSize.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                        lbl_SizeNO.Text = dt.Rows[0]["char1"].ToString();
                }
            }
        }

        private void txtTaxRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lbl_TaxtRate.Text = string.Empty;
                if (!txtTaxRate.IsErrorOccurs)
                {
                    DataTable dt = txtTaxRate.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                        lbl_TaxtRate.Text = dt.Rows[0]["char1"].ToString();
                }
            }
        }

        private void txtIEvaluation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lbl_IEvaluation.Text = string.Empty;
                if (!txtIEvaluation.IsErrorOccurs)
                {
                    DataTable dt = txtIEvaluation.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                        lbl_IEvaluation.Text = dt.Rows[0]["char1"].ToString();
                }
            }
        }

        private void txtIManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lbl_IManagement.Text = string.Empty;
                if (!txtIManagement.IsErrorOccurs)
                {
                    DataTable dt = txtIManagement.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                        lbl_IManagement.Text = dt.Rows[0]["char1"].ToString();
                }
            }
        }

        private void txtMajorSuppliers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lbl_MajorSuppliers.Text = string.Empty;
                if (!txtMajorSuppliers.IsErrorOccurs)
                {
                    DataTable dt = txtMajorSuppliers.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                        lbl_MajorSuppliers.Text = dt.Rows[0]["SiiresakiRyakuName"].ToString();
                }
            }
        }
    }
}
