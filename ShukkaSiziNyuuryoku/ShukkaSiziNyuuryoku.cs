using System;
using Shinyoh;
using Entity;
using BL;
using CKM_CommonFunction;
using System.Windows.Forms;
using Shinyoh_Controls;
using Shinyoh_Search;
using System.Data;

namespace ShukkaSiziNyuuryoku
{
    public partial class ShukkaSiziNyuuryoku : BaseForm
    {
        CommonFunction cf;
        multipurposeEntity multi_Entity;
        StaffBL staffBL;
        ShukkasiziNyuuryokuBL sksz_bl;
        BaseBL bbl;
        TokuisakiDetails td = new TokuisakiDetails();
        KouritenDetails kd = new KouritenDetails();
        public string tdDate;
        public ShukkaSiziNyuuryoku()
        {
            InitializeComponent();
            cf = new CommonFunction();
            multi_Entity = new multipurposeEntity();
            staffBL = new StaffBL();
            sksz_bl = new ShukkasiziNyuuryokuBL();
            bbl = new BaseBL();
            tdDate = string.Empty;
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
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", false);
            SetButton(ButtonType.BType.Display, F10, "表示(F10)", true);
            SetButton(ButtonType.BType.Search, F11, "保存(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            lblSiiresakiName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblKouritenName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblStaffName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            ChangeMode(Mode.New);
            sbShippingNO.Focus();
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
                    sbShippingNO.Focus();                    
                    New_Mode();
                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    break;
                case Mode.Update:
                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;
                    break;
                case Mode.Inquiry:
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
                //if (ErrorCheck(PanelTitle) && ErrorCheck(panelDetails))
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
        private void ErrorCheck()
        {
            sbShippingNO.E102Check(true);
            sbShippingNO.E133Check(true, "ShukkaSiziNyuuryoku", sbShippingNO, null, null);
            sbShippingNO.E115Check(true, "ShukkaSiziNyuuryoku", sbShippingNO);
            sbShippingNO.E160Check(true, "ShukkaSiziNyuuryoku", sbShippingNO,null);
            //出荷予定日
            txtShippingDate.E102Check(true);
            txtShippingDate.E103Check(true);
            //得意先
            sbTokuisaki.E102Check(true);
            sbTokuisaki.E101Check(true, "M_Tokuisaki", txtShippingDate, null, null);
            sbTokuisaki.E267Check(true, "M_Tokuisaki", sbTokuisaki, txtShippingDate);
            sbTokuisaki.E227Check(true, "M_Tokuisaki", sbTokuisaki, txtShippingDate);
            //E269
            //小売店
            sbKouriten.E101Check(true, "M_Kouriten", sbKouriten, txtShippingDate, null);
            sbKouriten.E267Check(true, "M_Kouriten", sbKouriten, txtShippingDate);
            sbKouriten.E227Check(true, "M_Kouriten", sbKouriten, txtShippingDate);
            //担当スタッフCD
            sbStaffCD.E102Check(true);
            sbStaffCD.E101Check(true, "M_Staff", sbStaffCD, txtShippingDate, null);
            sbStaffCD.E135Check(true, "M_Staff", sbStaffCD, txtShippingDate);
            //伝票日付
            txtSlipDate.E102Check(true);
            txtSlipDate.E103Check(true);
            //受注番号(searchshi)
            txtJuchuuNo.E133Check(true, "JuchuuNyuuryoku", txtJuchuuNo, null, null);
        }
        private void New_Mode()
        {
            tdDate = DateTime.Now.ToString("yyyy/MM/dd");
            txtShippingDate.Text = tdDate;
            txtSlipDate.Text = tdDate;

            StaffEntity staffEntity = new StaffEntity
            {
                StaffCD = OperatorCD
            };
            staffEntity = staffBL.GetStaffEntity(staffEntity);
            sbStaffCD.Text = OperatorCD;
            lblStaffName.Text = staffEntity.StaffName;
        }
        private void Clear()
        {
            
        }

        private void btn_Tokuisaki_Click(object sender, EventArgs e)
        {
            td.ShowDialog();           
        }

        private void btnKouriren_Detail_Click(object sender, EventArgs e)
        {
            kd.ShowDialog();
        }
    }
}
