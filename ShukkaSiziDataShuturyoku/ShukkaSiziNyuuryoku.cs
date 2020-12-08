using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System;
using Shinyoh;
using Entity;
using BL;
using CKM_CommonFunction;
using System.Windows.Forms;
using Shinyoh_Controls;
using Shinyoh_Search;
using System.Data;
using BL;

namespace ShukkaSiziNyuuryoku
{
    public partial class ShukkaSiziNyuuryoku : BaseForm
    {
        CommonFunction cf;
        multipurposeEntity multi_Entity;
        chakuniNyuuryoku_BL cbl;
        BaseBL bbl;
        public ShukkaSiziNyuuryoku()
        {
            InitializeComponent();
            cf = new CommonFunction();
            bbl = new BaseBL();
        }

        private void ShukkaSiziNyuuryoku_Load(object sender, EventArgs e)
        {
            ProgramID = "ShukkaSiziNyuuryoku";
            StartProgram();
            cboMode.Bind(false, multi_Entity);

            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "新規(F2)", true);
            SetButton(ButtonType.BType.Update, F3, "変更(F3)", true);
            SetButton(ButtonType.BType.Delete, F4, "削除(F4)", true);
            SetButton(ButtonType.BType.Inquiry, F5, "照会(F5)", true);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", true);
            SetButton(ButtonType.BType.Display, F10, "表示(F10)", true);
            SetButton(ButtonType.BType.Search, F11, "保存(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            ChangeMode(Mode.New);
            txtShippingNO.Focus();
            multipurposeEntity multipurpose_entity = new multipurposeEntity();
        }

        private void ChangeMode(Mode mode)
        {
            switch (mode)
            {
                case Mode.New:
                    ErrorCheck();
                    cf.Clear(PanelTitle);
                    cf.Clear(panelDetails);
                    cf.EnablePanel(PanelTitle);
                    cf.EnablePanel(panelDetails);
                    txtShippingNO.Focus();
                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    break;
                case Mode.Update:
                    txtShippingNO.E102Check(true);
                    txtShippingNO.E133Check(true, "ChakuniNyuuryoku", txtShippingNO, null, null);
                    txtShippingNO.E268Check(true, "ChakuniNyuuryoku", txtShippingNO, null);
                    cf.Clear(PanelTitle);
                    cf.Clear(panelDetails);
                    cf.EnablePanel(PanelTitle);
                    cf.EnablePanel(panelDetails);
                    txtShippingNO.Enabled = true;
                    txtShippingNO.Focus();
                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    txtShippingNO.E133Check(true, "ChakuniNyuuryoku", txtShippingNO, null, null);
                    txtShippingNO.E268Check(true, "ChakuniNyuuryoku", txtShippingNO, null);
                    cf.Clear(PanelTitle);
                    cf.Clear(panelDetails);
                    cf.EnablePanel(PanelTitle);
                    cf.DisablePanel(panelDetails);
                    txtShippingNO.Enabled = true;
                    txtShippingNO.Focus();
                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;
                    break;
                case Mode.Inquiry:
                    txtShippingNO.E133Check(true, "ChakuniNyuuryoku", txtShippingNO, null, null);
                    txtShippingNO.E268Check(true, "ChakuniNyuuryoku", txtShippingNO, null);
                    cf.Clear(PanelTitle);
                    cf.Clear(panelDetails);
                    cf.EnablePanel(PanelTitle);
                    cf.DisablePanel(panelDetails);
                    txtShippingNO.Enabled = true;
                    txtShippingNO.Focus();
                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;
                    break;
            }
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
                Clear();
            }
            if (tagID == "12")
            {
                if (ErrorCheck(PanelTitle) && ErrorCheck(panelDetails))
                {
                    //DBProcess();
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
            Clear();
            base.FunctionProcess(tagID);
        }

        private void ErrorCheck()
        {
            
        }
        public void Clear()
        {
            cf.Clear(PanelTitle);
            cf.Clear(panelDetails);
            cf.EnablePanel(PanelTitle);
            lblSiiresaki.Text = string.Empty;
            lblStaff.Text = string.Empty;
            lblBrandName.Text = string.Empty;
            lblWareHouse.Text = string.Empty;
            txtShippingNO.Focus();
        }
    }
}
