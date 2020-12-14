using Entity;
using Shinyoh;
using Shinyoh_Search;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShukkaNyuuryoku {
    public partial class ShukkaNyuuryoku : BaseForm {
        multipurposeEntity multi_Entity;
        public ShukkaNyuuryoku()
        {
            InitializeComponent();
            multi_Entity = new multipurposeEntity();
        }

        private void ShukkaNyuuryoku_Load(object sender, EventArgs e)
        {
            ProgramID = "ShukkaNyuuryoku";
            StartProgram();
            cboMode.Bind(false, multi_Entity);

            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "新規(F2)", true);
            SetButton(ButtonType.BType.Update, F3, "修正(F3)", true);
            SetButton(ButtonType.BType.Delete, F4, "削除(F4)", true);
            SetButton(ButtonType.BType.Inquiry, F5, "照会(F5)", true);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", true);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            SetButton(ButtonType.BType.Empty, F8, "確認(F8)", true);
            SetButton(ButtonType.BType.Empty, F10, "表示(F10)", true);
            SetButton(ButtonType.BType.Empty, F11, "保存(F11)", true);

            Date_Setting();
            ChangeMode(Mode.New);

        }
        private void Date_Setting()
        {
            BaseEntity baseEntity = _GetBaseData();
            txtShukkaDate.Text = baseEntity.LoginDate;
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
                //Mode_Setting();
                //if (cboMode.SelectedValue.Equals("2") || cboMode.SelectedValue.Equals("3") || cboMode.SelectedValue.Equals("4"))
                //{
                //    Disable_UDI_Mode();
                //}
            }
            if (tagID == "9")
            {
                //SiiresakiSearch detail = new SiiresakiSearch();
                //detail.ShowDialog();
            }
            if (tagID == "10")
            {

            }
            if (tagID == "12")
            {
                //if (ErrorCheck(PanelTitle) && ErrorCheck(Panel_Detail))
                //{
                //    DBProcess();
                //    switch (cboMode.SelectedValue)
                //    {
                //        case "1":
                //            ChangeMode(Mode.New);
                //            break;
                //        case "2":
                //            ChangeMode(Mode.Update);
                //            break;
                //        case "3":
                //            ChangeMode(Mode.Delete);
                //            break;
                //        case "4":
                //            ChangeMode(Mode.Inquiry);
                //            break;
                //    }
                //}
            }

            base.FunctionProcess(tagID);
        }

        private void ChangeMode(Mode mode)
        {
            //Mode_Setting();
            switch (mode)
            {
                case Mode.New:
                    ErrorCheck();
                    txtShukkaNo.E102Check(false);
                    txtShukkaNo.E133Check(false, "ShukkaNyuuryoku", txtShukkaNo, null, null);
                    txtShukkaNo.E160Check(false, "ShukkaNyuuryoku", txtShukkaNo, null);

                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    break;

                case Mode.Update:
                    ErrorCheck();
                    txtShukkaNo.E102Check(true);
                    txtShukkaNo.E133Check(true, "ShukkaNyuuryoku", txtShukkaNo, null, null);
                    txtShukkaNo.E160Check(true, "ShukkaNyuuryoku", txtShukkaNo, null);

                    //Disable_UDI_Mode();
                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    ErrorCheck();
                    txtShukkaNo.E102Check(true);
                    txtShukkaNo.E133Check(true, "ShukkaNyuuryoku", txtShukkaNo, null, null);
                    txtShukkaNo.E160Check(true, "ShukkaNyuuryoku", txtShukkaNo, null);

                    //Disable_UDI_Mode();
                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;

                    break;
                case Mode.Inquiry:
                    txtShukkaNo.E102Check(true);
                    txtShukkaNo.E133Check(true, "ShukkaNyuuryoku", txtShukkaNo, null, null);
                    txtShukkaNo.E160Check(true, "ShukkaNyuuryoku", txtShukkaNo, null);

                    //Disable_UDI_Mode();
                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;
                    break;
            }
        }
        private void ErrorCheck()
        {
            txtShukkaDate.E102Check(true);
            txtShukkaDate.E103Check(true);
            txtShukkaDate.E115Check(true, "ShukkaNyuuryoku", txtShukkaDate);
        }
        private void sButton1_Click(object sender, EventArgs e)
        {
            ShukkaNoSearch a = new ShukkaNoSearch();
            a.Show();
            
        }
    }
}
