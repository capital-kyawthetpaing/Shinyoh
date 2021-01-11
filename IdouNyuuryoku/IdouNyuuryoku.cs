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
        DataTable gv1_to_dt1;
        public IdouNyuuryoku()
        {
            InitializeComponent();
            cf = new CommonFunction();
            multi_Entity = new multipurposeEntity();
            base_Entity = new BaseEntity();
            Idou_BL = new IdouNyuuryokuBL();
            gv1_to_dt1 = new DataTable();
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
            cf.Clear(PanelDetail);

            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(PanelDetail);

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
            }
            DataTable dt_Souko = Idou_BL.IdouNyuuryoku_Select_Check(string.Empty, string.Empty, "Load_Souko");
            if(dt_Souko.Rows.Count>0)
            {
                txtNyukosouko.Text = dt_Souko.Rows[0]["SoukoCD"].ToString();
                lbl_Nyuko.Text = dt_Souko.Rows[0]["SoukoName"].ToString();
            }
        }
        private void Disable_UDI_Mode()
        {
            txtCopy.Enabled = false;
        }
        private void ErrorCheck()
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
                Mode_Setting();
                if (cboMode.SelectedValue.Equals("2") || cboMode.SelectedValue.Equals("3") || cboMode.SelectedValue.Equals("4"))
                {
                    Disable_UDI_Mode();
                }
            }
            if (tagID == "8")
            {
              //  F8_Gridview_Bind();
            }
            if (tagID == "9")
            {
                //SiiresakiSearch detail = new SiiresakiSearch();
                //detail.ShowDialog();
            }
            if (tagID == "10")
            {
               // F10_Gridview_Bind();
            }
            if (tagID == "11")
            {
              //  F11_Gridview_Bind();
            }
            if (tagID == "12")
            {
                //if (ErrorCheck(PanelTitle) && ErrorCheck(PanelDetail))
                //{

              //  DBProcess();
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
                // }
            }

            base.FunctionProcess(tagID);
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

        private void txtBrandCD_KeyDown(object sender, KeyEventArgs e)
        {
            multipurposeBL bl = new multipurposeBL();
            DataTable dt = bl.M_Multiporpose_SelectData(txtBrandCD.Text, 1, string.Empty, string.Empty);
            if (dt.Rows.Count > 0)
                lblBrand_Name.Text = dt.Rows[0]["Char1"].ToString();
        }

        private void txtIdouNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtIdouNO.IsErrorOccurs)
                {
                    
                    if (cboMode.SelectedValue.ToString() == "2")//update
                    {
                        EnablePanel();
                    }
                    else if (cboMode.SelectedValue.ToString() == "3" || cboMode.SelectedValue.ToString() == "4")
                    {
                        cf.DisablePanel(PanelTitle);
                    }
                }
                DataTable dt = txtIdouNO.IsDatatableOccurs;
                if (dt.Rows.Count > 0 && cboMode.SelectedValue.ToString() != "1")
                {
                    From_DB_To_Form(dt);
                }
            }
        }

        private void EnablePanel()
        {
            cf.EnablePanel(PanelDetail);
            txtIdouDate.Focus();
            cf.DisablePanel(PanelTitle);
        }
        private void From_DB_To_Form(DataTable dt)
        {
            if (dt.Rows[0]["MessageID"].ToString() == "E132")
            {
                txtIdouDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["IdouDate"]);
                txtIdoukubun.Text = dt.Rows[0]["IdouKBN"].ToString();
                lbl_IdouKubun.Text = dt.Rows[0]["Char1"].ToString();
                txtStaffCD.Text = dt.Rows[0]["StaffCD"].ToString();
                lblStaff_Name.Text = dt.Rows[0]["StaffName"].ToString();
                txtShukkosouko.Text = dt.Rows[0]["ShukkoSoukoCD"].ToString();
                lbl_Shukko.Text = dt.Rows[0]["ShukkoSoukoName"].ToString();
                txtNyukosouko.Text = dt.Rows[0]["NyuukoSoukoCD"].ToString();
                lbl_Nyuko.Text = dt.Rows[0]["NyuukoSoukoName"].ToString();
                txtDenpyouTekiyou.Text = dt.Rows[0]["IdouDenpyouTekiyou"].ToString();

                dt.Columns.Remove("IdouDate");
                dt.Columns.Remove("IdouKBN");
                dt.Columns.Remove("Char1");
                dt.Columns.Remove("StaffCD");
                dt.Columns.Remove("StaffName");
                dt.Columns.Remove("ShukkoSoukoCD");
                dt.Columns.Remove("ShukkoSoukoName");
                dt.Columns.Remove("NyuukoSoukoCD");
                dt.Columns.Remove("NyuukoSoukoName");
                dt.Columns.Remove("IdouDenpyouTekiyou");
                dt.Columns.Remove("MessageID");

                gv_1.DataSource = dt;
                gv_1.ClearSelection();

                //DataTable dt_temp = dt.Copy();
                //gv1_to_dt1 = dt_temp;

                //if (cboMode.SelectedValue.ToString() == "1")
                //    F8_dt1 = gv1_to_dt1.Clone();
                //else
                //    F8_dt1 = gv1_to_dt1.Copy();
            }
        }
    }
}
