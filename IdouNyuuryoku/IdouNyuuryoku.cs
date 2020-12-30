using BL;
using CKM_CommonFunction;
using Entity;
using Shinyoh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdouNyuuryoku
{
    public partial class IdouNyuuryoku : BaseForm
    {
        CommonFunction cf;
        multipurposeEntity multi_Entity;
        BaseEntity base_Entity;
        IdouNyuuryokuBL Idou_BL;

        public IdouNyuuryoku()
        {
            InitializeComponent();
            cf = new CommonFunction();
            multi_Entity = new multipurposeEntity();
            base_Entity = new BaseEntity();
            Idou_BL = new IdouNyuuryokuBL();
        }

        private void IdouNyuuryoku_Load(object sender, EventArgs e)
        {
            ProgramID = "IdouNyuuryoku";
            StartProgram();
            cboMode.Bind(false, multi_Entity);

            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "新規(F2)", true);
            SetButton(ButtonType.BType.Update, F3, "変更(F3)", true);
            SetButton(ButtonType.BType.Delete, F4, "削除(F4)", true);
            SetButton(ButtonType.BType.Inquiry, F5, "照会(F5)", true);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", true);
            SetButton(ButtonType.BType.Display, F10, "表示(F10)", true);
            SetButton(ButtonType.BType.Memory, F11, "保存(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);

            base_Entity = _GetBaseData();
            ChangeMode(Mode.New);

            txtIdoukubun.lblName = lbl_IdouKubun;
            txtStaffCD.lblName = lblStaff_Name;
            txtShukkosouko.lblName = lbl_Shukko;
            txtNyukosouko.lblName = lbl_Nyuko;

            txtStaffCD.ChangeDate = txtIdouDate;
        }
        private void ChangeMode(Mode mode)
        {
            Mode_Setting();
            switch (mode)
            {
                case Mode.New:
                    ErrorCheck();
                    txtIdouNO.E102Check(false);
                    txtIdouNO.E133Check(false, "IdouNyuuryoku", txtIdouNO, null, null);
                    

                    txtCopy.E102Check(true);
                    txtCopy.E133Check(true, "IdouNyuuryoku", txtCopy, null, null);

                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    break;

                case Mode.Update:
                    ErrorCheck();
                    txtIdouNO.E102Check(true);
                    txtCopy.E102Check(false);

                    txtIdouNO.E133Check(true, "IdouNyuuryoku", txtIdouNO, null, null);
                    

                    Disable_UDI_Mode();
                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    ErrorCheck();
                    txtIdouNO.E102Check(true);
                    txtCopy.E102Check(false);

                    txtIdouNO.E133Check(true, "IdouNyuuryoku", txtIdouNO, null, null);


                    Disable_UDI_Mode();
                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;

                    break;
                case Mode.Inquiry:
                    txtIdouNO.E102Check(false);
                    txtCopy.E102Check(false);

                    txtIdouNO.E133Check(true, "IdouNyuuryoku", txtIdouNO, null, null);
                    Disable_UDI_Mode();
                    Control btn12 = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btn12.Visible = false;
                    Control btn10 = this.TopLevelControl.Controls.Find("BtnF10", true)[0];
                    btn10.Visible = false;
                    Control btn11 = this.TopLevelControl.Controls.Find("BtnF11", true)[0];
                    btn11.Visible = false;
                    break;
            }
        }
        private void Mode_Setting()
        {
            cf.Clear(PanelTitle);
            cf.Clear(Panel_Detail);

            cf.EnablePanel(PanelTitle);
           // cf.DisablePanel(Panel_Detail);

            lbl_IdouKubun.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblStaff_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lbl_Nyuko.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lbl_Shukko.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblBrand_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;


            lbl_IdouKubun.Text = string.Empty;
            lblStaff_Name.Text = string.Empty;
            lbl_Nyuko.Text = string.Empty;
            lbl_Shukko.Text = string.Empty;
            lblBrand_Name.Text = string.Empty;

            //gv1_to_dt1 = new DataTable();
            //F8_dt1 = new DataTable();

            txtIdouNO.Focus();
            txtIdouDate.Text = base_Entity.LoginDate;
            txtStaffCD.Text = base_Entity.OperatorCD;
            lblStaff_Name.Text = base_Entity.SPName;
            DataTable dt_Multi = Idou_BL.IdouNyuuryoku_Select_Check(string.Empty, string.Empty, "Load_Multi");
            if (dt_Multi.Rows.Count > 0)
            {
                txtIdoukubun.Text = dt_Multi.Rows[0]["Key"].ToString();
                lbl_IdouKubun.Text = dt_Multi.Rows[0]["Char1"].ToString();
                Souko_Disable_Enable(txtIdoukubun.Text);
            }
            DataTable dt_Souko = Idou_BL.IdouNyuuryoku_Select_Check(string.Empty, string.Empty, "Load_Souko");
            if(dt_Souko.Rows.Count>0)
            {
                txtNyukosouko.Text = dt_Souko.Rows[0]["SoukoCD"].ToString();
                lbl_Nyuko.Text = dt_Souko.Rows[0]["SoukoName"].ToString();
                txtShukkosouko.Text = dt_Souko.Rows[0]["SoukoCD"].ToString();
                lbl_Shukko.Text = dt_Souko.Rows[0]["SoukoName"].ToString();
            }
        }
        public void Disable_UDI_Mode()
        {
            txtCopy.Enabled = false;
        }
        public void ErrorCheck()
        {

            txtIdouDate.E102Check(true);
            txtIdouDate.E103Check(true);

            txtIdouDate.E115Check(true, "IdouNyuuryoku", txtIdouDate);
            txtIdoukubun.E102Check(true);
            txtIdoukubun.E101Check(true, "M_MultiPorpose", txtIdoukubun, null, null);

            txtStaffCD.E102Check(true);
            txtStaffCD.E101Check(true, "M_Staff", txtStaffCD, txtIdouDate, null);
            txtStaffCD.E135Check(true, "M_Staff", txtStaffCD, txtIdouDate);

            if(txtShukkosouko.Enabled)
            {
                txtShukkosouko.E102Check(true);
                txtShukkosouko.E101Check(true, "souko", txtShukkosouko,null,null);
            }
            if (txtNyukosouko.Enabled)
            {
                txtNyukosouko.E102Check(true);
                txtNyukosouko.E101Check(true, "souko", txtNyukosouko, null, null);
            }
        }

        private void txtIdoukubun_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtIdoukubun.IsErrorOccurs)
                {
                    DataTable dt = txtIdoukubun.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                    {
                        lbl_IdouKubun.Text = dt.Rows[0]["Char1"].ToString();
                        Souko_Disable_Enable(txtIdoukubun.Text);
                    }
                }
                else
                {
                    lbl_IdouKubun.Text = string.Empty;
                }
            }
        }
        private void Souko_Disable_Enable(string txt_val)
        {
            if (txt_val == "1")
            {
                txtShukkosouko.Enabled = false;
                txtNyukosouko.Enabled = true;
                txtStaffCD.NextControlName = txtNyukosouko.Name;
            }
            else if (txt_val == "2")
            {
                txtShukkosouko.Enabled = true;
                txtNyukosouko.Enabled = false;
                txtStaffCD.NextControlName = txtShukkosouko.Name;
            }
            else if (txt_val == "3")
            {
                txtShukkosouko.Enabled = true;
                txtNyukosouko.Enabled = true;
                txtStaffCD.NextControlName = txtShukkosouko.Name;
            }
        }
    }
}
