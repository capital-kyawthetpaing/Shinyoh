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
            SetButton(ButtonType.BType.Empty, F10, "", false);
            SetButton(ButtonType.BType.Empty, F11, "", false);

            ChangeMode(Mode.New);
            base_entity = _GetBaseData();
            txtProduct.ChangeDate = txtRevisionDate;
            txtCopyProduct.ChangeDate = txtCopyRevisionDate;
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
                    txtCopyRevisionDate.Enabled = true;
                    UI_ErrorCheck();

                    txtRevisionDate.E132Check(true, "M_Shouhin", txtProduct, txtRevisionDate, null);
                    txtRevisionDate.E133Check(false, "M_Shouhin", txtProduct, txtRevisionDate, null);
                    txtRevisionDate.E270Check(false, "M_Shouhin", txtProduct, txtRevisionDate);

                    txtCopyRevisionDate.E102MultiCheck(true, txtCopyProduct, txtCopyRevisionDate);
                    txtCopyRevisionDate.E103Check(true);
                    txtCopyRevisionDate.E133Check(true, "M_Siiresaki", txtCopyProduct, txtCopyRevisionDate, null);

                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    break;
                case Mode.Update:
                    txtCopyProduct.Enabled = false;
                    txtCopyRevisionDate.Enabled = false;
                    UI_ErrorCheck();

                    txtRevisionDate.E132Check(false, "M_Shouhin", txtProduct, txtRevisionDate, null);
                    txtRevisionDate.E133Check(true, "M_Shouhin", txtProduct, txtRevisionDate, null);
                    txtRevisionDate.E270Check(false, "M_Shouhin", txtProduct, txtRevisionDate);

                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    txtCopyProduct.Enabled = false;
                    txtCopyRevisionDate.Enabled = false;
                    UI_ErrorCheck();

                    txtRevisionDate.E132Check(false, "M_Shouhin", txtProduct, txtRevisionDate, null);
                    txtRevisionDate.E133Check(true, "M_Shouhin", txtProduct, txtRevisionDate, null);
                    txtRevisionDate.E270Check(true, "M_Shouhin", txtProduct, txtRevisionDate);

                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;
                    break;
                case Mode.Inquiry:
                    txtCopyProduct.Enabled = false;
                    txtCopyRevisionDate.Enabled = false;
                    UI_ErrorCheck();

                    txtRevisionDate.E132Check(false, "M_Shouhin", txtProduct, txtRevisionDate, null);
                    txtRevisionDate.E133Check(true, "M_Shouhin", txtProduct, txtRevisionDate, null);
                    txtRevisionDate.E270Check(false, "M_Shouhin", txtProduct, txtRevisionDate);

                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;
                    break;
            }
        }

        private void UI_ErrorCheck()
        {
            txtProduct.E102Check(true);
            txtRevisionDate.E102Check(true);
            txtRevisionDate.E103Check(true);
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
            txtMajorSuppliers.E101Check(true, "M_Siiresaki", txtMajorSuppliers, txtRevisionDate, null);

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
            shouhin_entity.RevisionDate = txtRevisionDate.Text;
            shouhin_entity.CopyProduct = txtCopyProduct.Text;
            shouhin_entity.CopyRevisionDate = txtCopyRevisionDate.Text;
            shouhin_entity.ShoukouFLG = chkShukou.Checked ? 1 : 0;
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
            shouhin_entity.FOB = Convert.ToInt32(txtFOB.Text);
            shouhin_entity.Shipping_Place = txtShippingPlace.Text;
            shouhin_entity.HacchuuLot = Convert.ToDecimal(txtHacchuuLot.Text);
            shouhin_entity.ImageFilePathName = txtImage.Text;
            shouhin_entity.Remarks = txtRemarks.Text;
            shouhin_entity.KensakuHyouziJun = Convert.ToInt32(txtKensakuHyouziJun.Text);
            shouhin_entity.UsedFlag = 0;
            shouhin_entity.InsertOperator = base_entity.OperatorCD;
            shouhin_entity.UpdateOperator = base_entity.OperatorCD;

            //for log table
            shouhin_entity.PC = base_entity.PC;
            shouhin_entity.ProgramID = base_entity.ProgramID;
            shouhin_entity.KeyItem = txtProduct.Text + " " + txtRevisionDate.Text;
            return shouhin_entity;
        }

        private void Shouhin_IUD(ShouhinEntity shouhin_entity)
        {
            ShouhinBL shouhinbl = new ShouhinBL();
            shouhinbl.Shouhin_IUD(shouhin_entity);
        }

    }
}
