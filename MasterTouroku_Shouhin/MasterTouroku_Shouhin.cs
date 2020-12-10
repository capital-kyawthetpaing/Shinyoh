using BL;
using Entity;
using Shinyoh;
using System;
using CKM_CommonFunction;
using System.Windows.Forms;
using System.Data;
using Shinyoh_Controls;
using Shinyoh_Search;

namespace MasterTouroku_Shouhin
{
    public partial class MasterTouroku_Shouhin : BaseForm
    {
        BaseEntity base_entity;
        CommonFunction cf;
        multipurposeEntity multi_Entity;
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
        }

        private void ChangeMode(Mode mode)
        {
            cf.Clear(PanelTitle);
            cf.Clear(Panel_Detail);
            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(Panel_Detail);
            txtProduct.Focus();
            switch (mode)
            {
                case Mode.New:
                    txtCopyProduct.Enabled = true;
                    txtCopyChangeDate.Enabled = true;
                    UI_ErrorCheck();

                    txtChangeDate.E132Check(true, "M_Shouhin", txtProduct, txtChangeDate, null);
                    txtChangeDate.E133Check(false, "M_Shouhin", txtProduct, txtChangeDate, null);
                    txtChangeDate.E270Check(false, "M_Shouhin", txtProduct, txtChangeDate);

                    txtCopyChangeDate.E102MultiCheck(true, txtCopyProduct, txtCopyChangeDate);
                    txtCopyChangeDate.E103Check(true);
                    txtCopyChangeDate.E133Check(true, "M_Siiresaki", txtCopyProduct, txtCopyChangeDate, null);

                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    break;
                case Mode.Update:
                    txtCopyProduct.Enabled = false;
                    txtCopyChangeDate.Enabled = false;
                    UI_ErrorCheck();

                    txtChangeDate.E132Check(false, "M_Shouhin", txtProduct, txtChangeDate, null);
                    txtChangeDate.E133Check(true, "M_Shouhin", txtProduct, txtChangeDate, null);
                    txtChangeDate.E270Check(false, "M_Shouhin", txtProduct, txtChangeDate);

                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    txtCopyProduct.Enabled = false;
                    txtCopyChangeDate.Enabled = false;
                    UI_ErrorCheck();

                    txtChangeDate.E132Check(false, "M_Shouhin", txtProduct, txtChangeDate, null);
                    txtChangeDate.E133Check(true, "M_Shouhin", txtProduct, txtChangeDate, null);
                    txtChangeDate.E270Check(true, "M_Shouhin", txtProduct, txtChangeDate);

                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;
                    break;
                case Mode.Inquiry:
                    txtCopyProduct.Enabled = false;
                    txtCopyChangeDate.Enabled = false;
                    UI_ErrorCheck();

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
            txtProduct.E102Check(true);
            txtChangeDate.E102Check(true);
            txtChangeDate.E103Check(true);
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
            shouhin_entity.Product = txtProduct.Text;
            shouhin_entity.RevisionDate = txtChangeDate.Text;
            shouhin_entity.CopyProduct = txtCopyProduct.Text;
            shouhin_entity.CopyRevisionDate = txtCopyChangeDate.Text;
            shouhin_entity.ShokutiFLG = chkShukou.Checked ? 1 : 0;
            shouhin_entity.ProductName = txtProductName.Text;
            shouhin_entity.ShouhinRyakuName = txtShouhinRyakuName.Text;
            shouhin_entity.KatakanaName = txtKatakanaName.Text;
            shouhin_entity.JANCD = txtJANCD.Text;
            shouhin_entity.Exhibition = txtExhibition.Text;
            shouhin_entity.SS = chkSS.Checked ? "1" : "0";
            shouhin_entity.FW = chkFW.Checked ? "1" : "0";
            shouhin_entity.TaniCD = txtTani.Text;
            shouhin_entity.BrandCD = txtBrand.Text;
            shouhin_entity.Color = txtColor.Text;
            shouhin_entity.Size = txtSize.Text;
            shouhin_entity.JoudaiTanka = txtRetailPrice.Text;
            shouhin_entity.GedaiTanka = txtLowerPrice.Text;
            shouhin_entity.HyoujunGenkaTanka = txtStandardPrice.Text;
            shouhin_entity.ZeirituKBN = Convert.ToInt32(txtTaxRate.Text);
            shouhin_entity.ZaikoHyoukaKBN = Convert.ToInt32(txtIEvaluation.Text);
            shouhin_entity.ZaikoKanriKBN = Convert.ToInt32(txtIManagement.Text);
            shouhin_entity.MainSiiresakiCD = txtMajorSuppliers.Text;
            shouhin_entity.ToriatukaiShuuryouDate = txtHandlingEndDate.Text;
            shouhin_entity.HanbaiTeisiDate = txtSalesStopDate.Text;
            shouhin_entity.Model_No = txtModelNo.Text;
            shouhin_entity.Model_Name = txtModelName.Text;
            shouhin_entity.FOB = txtFOB.Text;
            shouhin_entity.Shipping_Place = txtShippingPlace.Text;
            shouhin_entity.HacchuuLot = Convert.ToDecimal(txtHacchuuLot.Text);
            shouhin_entity.ImageFilePathName = txtImage.Text;
            shouhin_entity.Remarks = txtRemarks.Text;
            shouhin_entity.KensakuHyouziJun = Convert.ToInt32(txtKensakuHyouziJun.Text);
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
            ShouhinBL shouhinbl = new ShouhinBL();
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
            if(dt.Rows[0]["MessageID"].ToString() == "132")
            {
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
                    chkFW.Checked = false;
                if (dt.Rows[0]["SeasonFW"].ToString() == "1")
                    chkFW.Checked = true;
                else
                    chkFW.Checked = false;
                txtTani.Text = dt.Rows[0]["TaniCD"].ToString();
                txtBrand.Text = dt.Rows[0]["BrandCD"].ToString();
                txtColor.Text = dt.Rows[0]["ColorNO"].ToString();
                txtSize.Text = dt.Rows[0]["SizeNO"].ToString();
                txtRetailPrice.Text = dt.Rows[0]["JoudaiTanka"].ToString();
                txtLowerPrice.Text = dt.Rows[0]["GedaiTanka"].ToString();
                txtStandardPrice.Text = dt.Rows[0]["HyoujunGenkaTanka"].ToString();
                txtTaxRate.Text = dt.Rows[0]["ZeirituKBN"].ToString();
                txtIEvaluation.Text = dt.Rows[0]["ZaikoHyoukaKBN"].ToString();
                txtIManagement.Text = dt.Rows[0]["ZaikoKanriKBN"].ToString();
                txtMajorSuppliers.Text = dt.Rows[0]["MainSiiresakiCD"].ToString();
                txtHandlingEndDate.Text = dt.Rows[0]["ToriatukaiShuuryouDate"].ToString();
                txtSalesStopDate.Text = dt.Rows[0]["HanbaiTeisiDate"].ToString();
                txtModelNo.Text = dt.Rows[0]["Model_No"].ToString();
                txtModelName.Text = dt.Rows[0]["ModelName"].ToString();
                txtFOB.Text = dt.Rows[0]["FOB"].ToString();
                txtShippingPlace.Text = dt.Rows[0]["Shipping_Place"].ToString();
                txtHacchuuLot.Text = dt.Rows[0]["HacchuuLot"].ToString();
                txtImage.Text = dt.Rows[0]["ShouhinImageFilePathName"].ToString();
                txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();
                txtKensakuHyouziJun.Text = dt.Rows[0]["KensakuHyouziJun"].ToString();
            }
        }
    }
}
