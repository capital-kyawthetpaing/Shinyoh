using BL;
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
using System.Net;

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
            ProgramID = "MasterTouroku_Shouhin";
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
            txtProduct.TxtBox = txtColor;
            txtProduct.TxtBox1 = txtSize;
            txtProduct.lblName = lblColorNO;
            txtProduct.lblName1 = lblSizeNO;
            txtProduct.ChangeDate = txtChangeDate;

            txtCopyProduct.TxtBox = txtCopyColor;       //HET
            txtCopyProduct.TxtBox1 = txtCopySize;       //HET
            txtCopyProduct.lblName = lblCopyColorNO;    //HET
            txtCopyProduct.lblName1 = lblCopySizeNO;    //HET
            txtCopyProduct.ChangeDate = txtCopyChangeDate; //HET

            ////txtCopyProduct.TxtBox = txtCopyProduct;//ses
            //txtCopyProduct.TxtBox =txtCopyColor;
            //txtCopyProduct.TxtBox1 = txtCopySize;
            //txtCopyProduct.lblName = lblCopyColorNO;
            //txtCopyProduct.lblName1 = lblCopySizeNO;
            ////txtCopyProduct.ChangeDate = txtCopyColor;//ses

            txtMajorSuppliers.ChangeDate = txtChangeDate;
            txtColor.lblName = lblColorNO;
            txtSize.lblName = lblSizeNO;
            txtCopyColor.lblName = lblCopyColorNO;
            txtCopySize.lblName = lblCopySizeNO;
            txtTani.lblName = lbl_TaniCD;
            txtBrand.lblName = lbl_BrandCD;
            txtTaxRate.lblName = lbl_TaxtRate;
            txtIEvaluation.lblName = lbl_IEvaluation;
            txtIManagement.lblName = lbl_IManagement;
            txtMajorSuppliers.lblName = lbl_MajorSuppliers;
            txtProduct.Focus();
        }
        private void ChangeMode(Mode mode)
        {
            switch (mode)
            {
                case Mode.New:
                    txtChangeDate.NextControlName = txtCopyProduct.Name;
                    UI_ErrorCheck();
                    txtCopyProduct.Enabled = true;
                    txtCopyChangeDate.Enabled = true;
                    txtColor.E101Check(true, "M_Shouhin", txtColor, null, null);
                    txtSize.E101Check(true, "M_Shouhin", txtSize, null, null);
                    txtChangeDate.E132MultiCheck(true, "M_Shouhin", txtProduct, txtColor, txtSize, txtChangeDate);
                    txtChangeDate.E133MultiCheck(false, "M_Shouhin", txtProduct, txtColor, txtSize, txtChangeDate);
                    txtChangeDate.E270MultiCheck(false, "M_Shouhin", txtProduct, txtColor, txtSize, txtChangeDate);
                    
                    txtCopyColor.E102MultiCheck(true, txtCopyProduct, txtCopyColor);
                    txtCopySize.E102MultiCheck(true, txtCopyColor, txtCopySize);
                    txtCopyChangeDate.E102MultiCheck(true, txtCopyProduct, txtCopyChangeDate);
                    txtCopyColor.E101Check(true, "M_Shouhin", txtCopyColor, null, null);
                    txtCopySize.E101Check(true, "M_Shouhin", txtCopySize, null, null);
                    txtCopyChangeDate.E103Check(true);
                    txtCopyChangeDate.E133MultiCheck(true, "M_Shouhin", txtCopyProduct, txtCopyColor, txtCopySize, txtCopyChangeDate);

                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    break;
                case Mode.Update:
                    UI_ErrorCheck();
                    txtCopyProduct.Enabled = false;
                    txtCopyColor.Enabled = false;
                    txtCopySize.Enabled = false;
                    txtCopyChangeDate.Enabled = false;

                    txtColor.E101Check(true, "M_Shouhin", txtColor, null, null);
                    txtSize.E101Check(true, "M_Shouhin", txtSize, null, null);

                    txtChangeDate.E132MultiCheck(false, "M_Shouhin", txtProduct, txtColor, txtSize, txtChangeDate);
                    txtChangeDate.E133MultiCheck(true, "M_Shouhin", txtProduct, txtColor, txtSize, txtChangeDate);
                    txtChangeDate.E270MultiCheck(false, "M_Shouhin", txtProduct, txtColor, txtSize, txtChangeDate);

                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    UI_ErrorCheck();
                    txtCopyProduct.Enabled = false;
                    txtCopyColor.Enabled = false;
                    txtCopySize.Enabled = false;
                    txtCopyChangeDate.Enabled = false;

                    txtColor.E101Check(true, "M_Shouhin", txtColor, null, null);
                    txtSize.E101Check(true, "M_Shouhin", txtSize, null, null);

                    txtChangeDate.E132MultiCheck(false, "M_Shouhin", txtProduct, txtColor, txtSize, txtChangeDate);
                    txtChangeDate.E133MultiCheck(true, "M_Shouhin", txtProduct, txtColor, txtSize, txtChangeDate);
                    txtChangeDate.E270MultiCheck(true, "M_Shouhin", txtProduct, txtColor, txtSize, txtChangeDate);

                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;
                    break;
                case Mode.Inquiry:
                    UI_ErrorCheck();
                    txtCopyProduct.Enabled = false;
                    txtCopyColor.Enabled = false;
                    txtCopySize.Enabled = false;
                    txtCopyChangeDate.Enabled = false;

                    txtColor.E101Check(true, "M_Shouhin", txtColor, null, null);
                    txtSize.E101Check(true, "M_Shouhin", txtSize, null, null);
                    txtChangeDate.E132MultiCheck(false, "M_Shouhin", txtProduct, txtColor, txtSize, txtChangeDate);
                    txtChangeDate.E133MultiCheck(true, "M_Shouhin", txtProduct, txtColor, txtSize, txtChangeDate);
                    txtChangeDate.E270MultiCheck(false, "M_Shouhin", txtProduct, txtColor, txtSize, txtChangeDate);

                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;
                    break;
            }
        }

        private void UI_ErrorCheck()
        {
            cf.Clear(PanelTitle);
            cf.Clear(PanelDetail);
            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(PanelDetail);
            txtProduct.Focus();

            txtProduct.E102Check(true);
            txtColor.E102Check(true);
            lblColorNO.Text = string.Empty;
            lblColorNO.BorderStyle = BorderStyle.None;
            txtSize.E102Check(true);
            lblSizeNO.Text = string.Empty;
            lblSizeNO.BorderStyle = BorderStyle.None;

            lblCopyColorNO.Text = string.Empty;
            lblCopyColorNO.BorderStyle = BorderStyle.None;

            lblCopySizeNO.Text = string.Empty;
            lblCopySizeNO.BorderStyle = BorderStyle.None;

            txtChangeDate.E102Check(true);
            txtChangeDate.E103Check(true);
            txtProductName.E102Check(true);
            txtShouhinRyakuName.E102Check(true);
            txtTani.E102Check(true);
            txtTani.E101Check(true, "M_Shouhin", txtTani, null, null);
            txtBrand.E102Check(true);
            txtBrand.E101Check(true, "M_Shouhin", txtBrand, null, null);
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
            txtImage.E128Check(true, txtImage, pImage);
            lbl_TaniCD.Text = string.Empty;
            lbl_TaniCD.BorderStyle = BorderStyle.None;
            lbl_BrandCD.Text = string.Empty;
            lbl_BrandCD.BorderStyle = BorderStyle.None;
            lbl_TaxtRate.Text = string.Empty;
            lbl_TaxtRate.BorderStyle = BorderStyle.None;
            lbl_IEvaluation.Text = string.Empty;
            lbl_IEvaluation.BorderStyle = BorderStyle.None;
            lbl_IManagement.Text = string.Empty;
            lbl_IManagement.BorderStyle = BorderStyle.None;
            lbl_MajorSuppliers.Text = string.Empty;
            lbl_MajorSuppliers.BorderStyle = BorderStyle.None;
            pImage.ImageLocation = null;
            pImage.Image = null;
            txtRetailPrice.Text = string.Empty;

            chkSS.Checked = true; //HET
            chkFW.Checked = true; //HET
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
                UI_ErrorCheck();
                if (cboMode.SelectedValue.Equals("2") || cboMode.SelectedValue.Equals("3") || cboMode.SelectedValue.Equals("4"))
                {
                    txtCopyProduct.Enabled = false;
                    txtCopyChangeDate.Enabled = false;
                    txtCopyColor.Enabled = false;       //HET
                    txtCopySize.Enabled = false;        //HET
                }
            }
            if (tagID == "10")
            {
                string Xml = GetFileData();
                if (!string.IsNullOrEmpty(Xml))
                {
                    ShouhinBL bl = new ShouhinBL();
                    string chk_val = string.Empty;
                    if (rdo_Registragion.Checked)
                        chk_val = "create_Err_Check";
                    else chk_val = "delete_Err_Check";
                    DataTable dt = bl.CSV_M_Shouhin_CUD(Xml, chk_val);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Result"].ToString().Equals("1"))
                        {
                            if (bbl.ShowMessage("Q206") != DialogResult.Yes)
                            {
                                PreviousCtrl.Focus();
                            }
                            else
                            {
                                if (rdo_Registragion.Checked)
                                    chk_val = "create_update";
                                else chk_val = "delete";
                                dt = bl.CSV_M_Shouhin_CUD(Xml, chk_val);
                                if (dt.Rows.Count > 0)
                                {
                                    if (dt.Rows[0]["Result"].ToString().Equals("1"))
                                    {
                                        bbl.ShowMessage("I002");
                                        rdo_Registragion.Checked = true;
                                        rdo_Delete.Checked = false;
                                    }
                                }

                            }
                        }
                        else
                        {
                            bbl.ShowMessage("E276", dt.Rows[0]["SEQ"].ToString(), dt.Rows[0]["Error1"].ToString(), dt.Rows[0]["Error2"].ToString());
                        }
                    }

                }
            }
            if (tagID == "12")
            {
                if (ErrorCheck(PanelTitle) && ErrorCheck(PanelDetail))
                {
                    DBProcess();
                    switch (cboMode.SelectedValue)
                    {
                        case "1":
                            ChangeMode(Mode.New);
                            bbl.ShowMessage("I101");
                            break;
                        case "2":
                            ChangeMode(Mode.Update);
                            bbl.ShowMessage("I101");
                            break;
                        case "3":
                            ChangeMode(Mode.Delete);
                            bbl.ShowMessage("I102");
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
            shouhin_entity.Product = txtProduct.Text.Trim()+ txtColor.Text.Trim()+ txtSize.Text.Trim();
            shouhin_entity.Color = txtColor.Text.Trim();
            shouhin_entity.Size = txtSize.Text.Trim();
            shouhin_entity.RevisionDate = txtChangeDate.Text.Trim();
            shouhin_entity.CopyProduct = txtCopyProduct.Text.Trim();
            shouhin_entity.CopyColorNO = txtCopyColor.Text.Trim();
            shouhin_entity.CopySizeNO = txtCopySize.Text.Trim();
            shouhin_entity.CopyRevisionDate = txtCopyChangeDate.Text.Trim();
            shouhin_entity.ShokutiFLG = chkShukou.Checked ? 1 : 0;
            shouhin_entity.HinbanCD = txtProduct.Text.Trim();
            shouhin_entity.ProductName = txtProductName.Text.Trim();
            shouhin_entity.ShouhinRyakuName = txtShouhinRyakuName.Text.Trim();
            shouhin_entity.KatakanaName = txtKatakanaName.Text.Trim();
            shouhin_entity.JANCD = txtJANCD.Text.Trim();
            shouhin_entity.Exhibition =txtExhibition.Text.Trim();
            shouhin_entity.SS = chkSS.Checked ? "1" : "0";
            shouhin_entity.FW = chkFW.Checked ? "1" : "0";
            shouhin_entity.TaniCD = txtTani.Text.Trim();
            shouhin_entity.BrandCD = txtBrand.Text.Trim();
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

        private bool Shouhin_IUD(ShouhinEntity shouhin_entity)
        {
            return shouhinbl.Shouhin_IUD(shouhin_entity);
        }

        private void txtChangeDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtChangeDate.IsErrorOccurs)
                {
                    if (cboMode.SelectedValue.ToString() == "2")
                    {
                        //string ShouhinCD = string.Empty;
                        //ShouhinCD = txtProduct.Text;
                        //shouhinbl = new ShouhinBL();
                        //DataTable dt = shouhinbl.Shouhin_Check(ShouhinCD, txtCopyChangeDate.Text, "E133");

                        //if (dt.Rows[0]["MessageID"].ToString().Equals("E133"))
                        //{
                        //    bbl.ShowMessage("E133");
                        //    txtChangeDate.Focus(); 
                        //}
                        EnableAndDisablePanel();
                    }
                    else if (cboMode.SelectedValue.ToString() == "3" || cboMode.SelectedValue.ToString() == "4")
                    {
                        cf.DisablePanel(PanelTitle);
                        if (cboMode.SelectedValue.ToString() == "3")
                        {
                            //string ShouhinCD = string.Empty;
                            //ShouhinCD = txtProduct.Text + txtColor.Text + txtSize.Text;
                            //shouhinbl = new ShouhinBL();
                            //DataTable dt = shouhinbl.Shouhin_Check(ShouhinCD, txtCopyChangeDate.Text, "E133");

                            //if (dt.Rows[0]["MessageID"].ToString().Equals("E133"))
                            //{
                            //    bbl.ShowMessage("E133");
                            //    txtChangeDate.Focus();
                            //}
                            //DataTable dt270 = shouhinbl.Shouhin_Check(ShouhinCD, txtCopyChangeDate.Text, "E270");
                            //if (dt270.Rows[0]["MessageID"].ToString().Equals("E270"))
                            //{
                            //    bbl.ShowMessage("E270");
                            //    txtChangeDate.Focus();
                            //}
                            Control btnF12 = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                            btnF12.Focus();
                        }
                    }
                }
                DataTable dt1 = txtChangeDate.IsDatatableOccurs;
                if (dt1.Rows.Count > 0 && cboMode.SelectedValue.ToString() != "1")
                {
                    DB_To_UI(dt1, "copy");
                }
            }
        }

        private void txtCopyChangeDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cboMode.SelectedValue.ToString() == "1")
            {
                //if(!string.IsNullOrEmpty(txtCopyProduct.Text) && !string.IsNullOrEmpty(txtCopyColor.Text) && !string.IsNullOrEmpty(txtCopySize.Text))
                //{
                //    string ShouhinCD = string.Empty;
                //    ShouhinCD = txtCopyProduct.Text + txtCopyColor.Text + txtCopySize.Text;
                //    shouhinbl = new ShouhinBL();
                //    DataTable dt = shouhinbl.Shouhin_Check(ShouhinCD, txtCopyChangeDate.Text, "E133");

                //    if (dt.Rows[0]["MessageID"].ToString().Equals("E133"))
                //    {
                //        bbl.ShowMessage("E133");
                //        txtCopyChangeDate.Focus();
                //    }
                if (ErrorCheck(PanelTitle))
                {
                    if (!txtCopyChangeDate.IsErrorOccurs)
                    {
                        EnableAndDisablePanel();
                        DataTable dt1 = txtCopyChangeDate.IsDatatableOccurs;
                        if (dt1.Rows.Count > 0)
                            DB_To_UI(dt1, "copy");
                    }
                }
            }
        }

        private void EnableAndDisablePanel()
        {
            cf.DisablePanel(PanelTitle);
            cf.EnablePanel(PanelDetail);
            chkShukou.Focus();
        }

        private void DB_To_UI(DataTable dt, string type)
        {
            if(dt.Rows[0]["MessageID"].ToString() == "E132")
            {
                if(type != "copy")          // HET
                {
                    txtProduct.Text = dt.Rows[0]["HinbanCD"].ToString();
                    txtColor.Text = dt.Rows[0]["ColorNO"].ToString();
                    txtSize.Text = dt.Rows[0]["SizeNO"].ToString();
                }
                if (dt.Rows[0]["ShokutiFLG"].ToString() == "1")
                    chkShukou.Checked = true;
                else
                    chkShukou.Checked = false;
                txtProductName.Text = dt.Rows[0]["ShouhinName"].ToString();
                txtShouhinRyakuName.Text = dt.Rows[0]["ShouhinRyakuName"].ToString();
                txtKatakanaName.Text = dt.Rows[0]["KanaName"].ToString();
                txtJANCD.Text = dt.Rows[0]["JANCD"].ToString();
                txtExhibition.Text = dt.Rows[0]["YearTerm"].ToString();
                if (dt.Rows[0]["SeasonSS"].ToString() == "1")
                    chkSS.Checked = true;
                else
                    chkSS.Checked = false;
                if (dt.Rows[0]["SeasonFW"].ToString() == "1")
                    chkFW.Checked = true;
                else
                    chkFW.Checked = false;
                txtTani.Text = dt.Rows[0]["TaniCD"].ToString();
                lbl_TaniCD.Text = dt.Rows[0]["TaniName"].ToString();
                txtBrand.Text = dt.Rows[0]["BrandCD"].ToString();
                lbl_BrandCD.Text = dt.Rows[0]["BrandName"].ToString();
                //txtColor.Text = dt.Rows[0]["ColorNO"].ToString();
                //lbl_ColorNO.Text = dt.Rows[0]["ColorName"].ToString();
                //txtSize.Text = dt.Rows[0]["SizeNO"].ToString();
                //lbl_SizeNO.Text = dt.Rows[0]["SizeName"].ToString();
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
                txtHandlingEndDate.Text = !string.IsNullOrEmpty(dt.Rows[0]["ToriatukaiShuuryouDate"].ToString()) ? Convert.ToDateTime(dt.Rows[0]["ToriatukaiShuuryouDate"].ToString()).ToString("yyyy/MM/dd") : string.Empty;
                txtSalesStopDate.Text = !string.IsNullOrEmpty(dt.Rows[0]["HanbaiTeisiDate"].ToString()) ? Convert.ToDateTime(dt.Rows[0]["HanbaiTeisiDate"].ToString()).ToString("yyyy/MM/dd") : string.Empty;
                txtModelNo.Text = dt.Rows[0]["Model_No"].ToString();
                txtModelName.Text = dt.Rows[0]["Model_Name"].ToString();
                txtFOB.Text = dt.Rows[0]["FOB"].ToString();
                txtShippingPlace.Text = dt.Rows[0]["Shipping_Place"].ToString();
                txtHacchuuLot.Text = dt.Rows[0]["HacchuuLot"].ToString();
                txtImage.Text = dt.Rows[0]["ShouhinImageFilePathName"].ToString();

                pImage.Image = null;
                if(!string.IsNullOrEmpty(dt.Rows[0]["ShouhinImage"].ToString()))
                {
                    byte[] imgBytes = (byte[])dt.Rows[0]["ShouhinImage"];
                    if (imgBytes.Length > 0)
                    {
                        pImage.Image = Image.FromStream(new MemoryStream(imgBytes));
                        pImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }

                txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();
                txtKensakuHyouziJun.Text = dt.Rows[0]["KensakuHyouziJun"].ToString();
            }
        }

        private void txtImage_KeyDown(object sender, KeyEventArgs e)
        {
            pImage.Image = null;
            pImage.ImageLocation = txtImage.Text;
            pImage.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private string GetFileData()
        {
            string error = "false";
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
                    string[] csvRows = File.ReadAllLines(filePath,Encoding.GetEncoding(932));
                    var bl_list = new List<bool>();
                    for (int i = 1; i < csvRows.Length; i++)
                    {
                        error = "false";
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

                        //string[] NullCheck_List = { "0", "1", "2", "3", "4", "5", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22"};
                        //string[] NullCheck_Msg = { "商品CD未入力エラー", "改定日未入力エラー", "諸口未入力エラー", "品番CD未入力エラー", "商品名未入力エラー", "略名未入力エラー", "単位CD未入力エラー", "ブランドCD未入力エラー", "カラーNO未入力エラー", "サイズNO未入力エラー", "上代単価未入力エラー", "下代単価未入力エラー", "標準原価単価未入力エラー", "税率区分未入力エラー", "在庫評価区分未入力エラー", "在庫管理区分未入力エラー", "主要仕入先未入力エラー" };
                        //string[] ByteCheck_List = { "0_50", "3_20", "4_100", "5_80", "6_80", "8_13", "9_6", "10_6", "11_6", "12_2", "13_10", "14_13", "15_13", "22_10", "31_80"};
                        //string[] ByteCheck_Msg = { "商品CD桁数エラー", "品番CD桁数エラー", "商品名桁数エラー", "略名桁数エラー", "カナ名桁数エラー", "JANCD桁数エラー", "年度桁数エラー", "シーズンSS桁数エラー", "シーズンFW桁数エラー", "単位CD桁数エラー", "ブランドCD桁数エラー", "カラーNO桁数エラー", "サイズNO桁数エラー", "主要仕入先CD桁数エラー", "備考桁数エラー" };
                        //string[] ValueCheck_List = { "2", "19", "20", "21" };
                        //string[] ValueCheck_Amt = { "1", "2", "3", "1" };
                        //string[] ValueCheck_Msg = { "項目:諸口区分(0～1)", "項目:税率区分(0～2)", "項目:在庫評価区分(0～3)", "項目:在庫管理区分(0～1)" };
                        //string[] DateCheck_List = { "1", "23", "24" };
                        //string[] DateCheck_Msg = { "項目:改定日", "項目:取扱終了日", "項目:販売停止日" };
                        //string[] NonNumeric_List = { "16", "17", "18", "27" };
                        //string[] NonNumeric_Msg = { "項目:上代単価", "項目:下代単価", "項目:標準原価単価", "項目:FOB" };
                        //string InputValue_Msg = "入力可能値外エラー";
                        //string[] MasterCheck_List = { "12", "13", "14", "15", "22" };
                        //string[] MasterCheck_ID = { "102", "103", "104", "105" };
                        //string[] MasterCheck_Msg = { "単位CD未登録エラー", "ブランドCD未登録エラー", "カラーNO未登録エラー", "サイズNO未登録エラー", "主要仕入先CD未登録エラー" };

                        //for (int nc = 0; nc < NullCheck_List.Length; nc++)
                        //{
                        //    int ncl_index = Convert.ToInt32(NullCheck_List[nc].ToString());
                        //    if (Null_Check(data[ncl_index].ToString(), i, NullCheck_Msg[nc].ToString()))
                        //    {
                        //        error = "true";
                        //        goto StopProcess;
                        //    }
                        //}

                        //for (int bc = 0; bc < ByteCheck_List.Length; bc++)
                        //{
                        //    var bcl = ByteCheck_List[bc].ToString().Split('_');
                        //    int bcl_index = Convert.ToInt32(bcl[0]);
                        //    int bcl_len = Convert.ToInt32(bcl[1]);
                        //    if (Byte_Check(bcl_len, data[bcl_index].ToString(), i, ByteCheck_Msg[bc].ToString()))
                        //    {
                        //        error = "true";
                        //        goto StopProcess;
                        //    }
                        //}

                        //for (int vc = 0; vc < ValueCheck_List.Length; vc++)
                        //{
                        //    int vcl_index = Convert.ToInt32(ValueCheck_List[vc].ToString());
                        //    int vc_Amount = Convert.ToInt32(ValueCheck_Amt[vc].ToString());
                        //    string vc_msg = ValueCheck_Msg[vc].ToString();
                        //    if (Value_Check(data[vcl_index].ToString(), i, vc_Amount, InputValue_Msg, vc_msg))
                        //    {
                        //        error = "true";
                        //        goto StopProcess;
                        //    }
                        //}

                        //for(int dc = 0; dc < DateCheck_List.Length; dc++)
                        //{
                        //    int dcl_index = Convert.ToInt32(DateCheck_List[dc].ToString());
                        //    string dc_msg = DateCheck_Msg[dc].ToString();
                        //    if (Date_Check(data[dcl_index].ToString(), i, InputValue_Msg, dc_msg) == "true")
                        //    {
                        //        error = "true";
                        //        goto StopProcess;
                        //    }
                        //    else
                        //    {
                        //        dr[dcl_index] = Date_Check(data[dcl_index].ToString(), i, InputValue_Msg, dc_msg);
                        //    }
                        //}

                        //for(int nn = 0; nn < NonNumeric_List.Length; nn++)
                        //{
                        //    int nnl_index = Convert.ToInt32(NonNumeric_List[nn].ToString());
                        //    string nn_msg = NonNumeric_Msg[nn].ToString();
                        //    if (NonNumeric_Check(data[nnl_index].ToString(), i, InputValue_Msg, nn_msg))
                        //    {
                        //        error = "true";
                        //        goto StopProcess;
                        //    }
                        //}

                        //for(int mc = 0; mc < MasterCheck_List.Length; mc++)
                        //{
                        //    string CD_ID = string.Empty, Key_Date = string.Empty;
                        //    int type;
                        //    int mcl_index = Convert.ToInt32(MasterCheck_List[mc].ToString());
                        //    if(mc != MasterCheck_List.Length - 1)
                        //    {
                        //        CD_ID = MasterCheck_ID[mc].ToString();
                        //        Key_Date = data[mcl_index].ToString();
                        //        type = 0;
                        //    }
                        //    else
                        //    {
                        //        CD_ID = data[0].ToString();
                        //        Key_Date = data[1].ToString();
                        //        type = 1;
                        //    }

                        //    if (Master_Check(CD_ID, Key_Date, type, i, MasterCheck_Msg[mc].ToString()))
                        //    {
                        //        error = "true";
                        //        goto StopProcess;
                        //    }
                        //}

                        byte[] img;
                        if (ImageFile_Check(data[30].ToString(), i, "指定したパスに画像ファイルが存在しないエラー"))
                        {
                            //bbl.ShowMessage("E276", i.ToString(), "指定したパスに画像ファイルが存在しないエラー");
                            return string.Empty;
                        }                           
                        else
                        {
                            img = !string.IsNullOrEmpty(data[30].ToString().Trim()) ? System.IO.File.ReadAllBytes(data[30].ToString()) : new byte[] { };
                            dr[31] = Convert.ToBase64String(img);
                        }

                        dr["Error"] = error;
                        create_dt.Rows.Add(dr);
                    }
                    if (create_dt.Rows.Count > 0)
                    {
                        for (int r = 0; r < create_dt.Rows.Count; r++)
                        {
                            string date1 = create_dt.Rows[r]["ChangeDate"].ToString();//column_1
                            string date2 = create_dt.Rows[r]["ToriatukaiShuuryouDate"].ToString();//column_2
                            string date3 = create_dt.Rows[r]["HanbaiTeisiDate"].ToString();//column_3
                            int line_No = r + 1;

                            if (Date_Check(date1, line_No, "入力可能値外エラー", "項目:改定日") == "true")
                            {
                                return null;
                            }
                            else if (Date_Check(date2, line_No, "入力可能値外エラー", "項目:取扱終了日") == "true")
                            {
                                return null;
                            }
                            else if (Date_Check(date3, line_No, "入力可能値外エラー", "項目:販売停止日") == "true")
                            {
                                return null;
                            }
                            else if (r == create_dt.Rows.Count - 1)
                            {
                                Xml = cf.DataTableToXml(create_dt);
                            }                         
                        }
                    }
                    ////if (error == "false")
                    //Xml = cf.DataTableToXml(create_dt);
                    ////else
                    ////    Xml = string.Empty;
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
        public string Date_Check(string csv_Date, int line_no, string error_msg, string dc_msg)
        {
            TextBox txt = new TextBox();
            txt.Text = csv_Date;
            if (!string.IsNullOrEmpty(csv_Date))
            {
                if (!cf.DateCheck(txt))
                {
                    bbl.ShowMessage("E276", line_no.ToString(), error_msg, dc_msg);
                    txt.Text = "true";
                }
            }
            return txt.Text;
        }
        public bool Value_Check(string obj_text, int line_no, int Amount, string error_msg, string vc_msg)
        {
            bl = false;
            int n;
            if(!int.TryParse(obj_text, out n))
            {
                bbl.ShowMessage("E276", line_no.ToString(), error_msg, vc_msg);
                bl = true;
            }
            else if ((Convert.ToInt32(obj_text) < 0) || (Convert.ToInt32(obj_text) > Amount))
            {
                bbl.ShowMessage("E276", line_no.ToString(), error_msg, vc_msg);
                bl = true;
            }
            return bl;
        }
        public bool NonNumeric_Check(string obj_text, int line_no, string error_msg, string nn_msg)
        {
            bl = false;
            int n;
            decimal d;
            if(!int.TryParse(obj_text, out n))
            {
                if(!decimal.TryParse(obj_text, out d))
                {
                    bbl.ShowMessage("E276", line_no.ToString(), error_msg, nn_msg);
                    bl = true;
                }
            }
            return bl;
        }
        public bool Master_Check(string CD_ID, string Key_Date, int type, int line_no, string error_msg)
        {
            SiiresakiBL siiresakibl = new SiiresakiBL();
            bl = false;
            DataTable dt;
            if (type == 0)
                dt = shouhinbl.Shouhin_Check(CD_ID, string.Empty, string.Empty, Key_Date, "E101");
            else
                dt = siiresakibl.Siiresaki_Select_Check(CD_ID, Key_Date, "E101");
            if (dt.Rows.Count < 1)
            {
                bbl.ShowMessage("E276", line_no.ToString(), error_msg);
                bl = true;
            }
            return bl;
        }
        public bool ImageFile_Check(string obj_text, int line_no, string error_msg)
        {
            bl = false;
            if(!System.IO.File.Exists(obj_text) && !string.IsNullOrEmpty(obj_text.Trim()))
            {
                bbl.ShowMessage("E276", line_no.ToString(), error_msg);
                bl = true;
            }
            return bl;
        }
        public bool Shouhin_Check(string shouhinCD,string colorNo,string SizeNo, string Key_Date, int line_no)
        {
            bl = false;
            DataTable dt = new DataTable();
            dt = shouhinbl.Shouhin_Check(shouhinCD, colorNo, SizeNo, Key_Date, "E132");
            if (dt.Rows[0]["MessageID"].ToString() == "E132")
            {
                bbl.ShowMessage("E276", line_no.ToString(), "商品CD登録済エラー");
                bl = true;
            }
            return bl;
        }

        public void Add_Datatable_Column(DataTable create_dt)
        {
            create_dt.Columns.Add("ShouhinCD");
            create_dt.Columns.Add("ChangeDate");
            create_dt.Columns.Add("ShokutiFLG");
            create_dt.Columns.Add("HinbanCD");
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
    }
}
