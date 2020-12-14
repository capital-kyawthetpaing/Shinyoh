using System;
using Shinyoh;
using Entity;
using BL;
using CKM_CommonFunction;
using System.Windows.Forms;
using Shinyoh_Controls;
using Shinyoh_Search;
using System.Data;

namespace ShukkaTorikomi
{
    public partial class ShukkaTorikomi : BaseForm
    {
        CommonFunction cf;
        multipurposeEntity multi_Entity;
        ShukkaTorikomi_BL ShukkaTorikomi_BL;
        BaseBL bbl;

        public ShukkaTorikomi()
        {
            InitializeComponent();
            cf = new CommonFunction();
            multi_Entity = new multipurposeEntity();
            ShukkaTorikomi_BL = new ShukkaTorikomi_BL();
            bbl = new BaseBL();
        }

        private void ShukkaTorikomi_Load(object sender, EventArgs e)
        {
            ProgramID = "ShukkaTorikomi";
            StartProgram();
            cboMode.Visible = false;

            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "新規(F2)", false);
            SetButton(ButtonType.BType.Update, F3, "変更(F3)", false);
            SetButton(ButtonType.BType.Delete, F4, "削除(F4)", false);
            SetButton(ButtonType.BType.Inquiry, F5, "照会(F5)", false);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", false);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", true);
            SetButton(ButtonType.BType.Display, F10, "表示(F10)", true);
            SetButton(ButtonType.BType.Search, F11, "保存(F11)", false);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);
            multipurposeEntity multipurpose_entity = new multipurposeEntity();

            txtShukkaToNo1.Enabled = true;
            txtShukkaToNo2.Enabled = true;

            txtDate1.Enabled = false;
            txtDate2.Enabled = false;
            dataBind();
           
        }

        //private void ShukkaTorikomi_Load(object sender, KeyEventArgs e)
        //{
        //    multipurposeBL bl = new multipurposeBL();

        //    DataTable dt = bl.M_Multiporpose_SelectData(string.Empty, 3, string.Empty, string.Empty);

        //    if (dt.Rows.Count > 0)
        //    {
        //        txtShukkaToNo1.Text = dt.Rows[0]["Char1"].ToString();
        //        txtShukkaToNo2.Text = dt.Rows[0]["Char2"].ToString();
        //    }
        //    else
        //    {
        //        txtShukkaToNo1.Text = string.Empty;
        //        txtShukkaToNo2.Text = string.Empty;
        //    }

        //}

        private void dataBind()
        {
            multipurposeBL bl = new multipurposeBL();

            DataTable dt = bl.M_Multiporpose_SelectData(string.Empty, 3, string.Empty, string.Empty);

            if (dt.Rows.Count > 0)
            {
                txtShukkaToNo1.Text = dt.Rows[0]["Char1"].ToString();
                txtShukkaToNo2.Text = dt.Rows[0]["Char2"].ToString();
            }
            else
            {
                txtShukkaToNo1.Text = string.Empty;
                txtShukkaToNo2.Text = string.Empty;
            }
        }
    




        //private void ChangeMode(Mode mode)
        //{
        //    switch (mode)
        //    {
        //        case Mode.New:
        //            ErrorCheck();

        //            cf.Clear(PanelTitle);
        //            cf.Clear(panelDetails);
        //            cf.EnablePanel(PanelTitle);
        //            cf.EnablePanel(panelDetails);
        //            sbShippingNO.Focus();
        //            New_Mode();
        //            Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
        //            btnNew.Visible = true;
        //            break;
        //        case Mode.Update:
        //            Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
        //            btnUpdate.Visible = true;
        //            break;
        //        case Mode.Delete:
        //            Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
        //            btnDelete.Visible = true;
        //            break;
        //        case Mode.Inquiry:
        //            Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
        //            btnInquiry.Visible = false;
        //            break;
        //    }

        //}
    }
}
