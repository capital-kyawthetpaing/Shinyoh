using BL;
using CKM_CommonFunction;
using Entity;
using Shinyoh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterTouroku_Kouriten
{
    public partial class MasterTourokuKouriten :BaseForm
    {
        CommonFunction cf;
        multipurposeEntity multi_Entity ;
        BaseEntity base_Entity;
        public MasterTourokuKouriten()
        {
            InitializeComponent();
            cf = new CommonFunction();
        }

        private void MasterTourokuKouriten_Load(object sender, EventArgs e)
        {
            ProgramID = "MasterTourokuKouriten";
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
            txtKouritenCD.Focus();

            base_Entity = _GetBaseData();
        }

        private void ChangeMode(Mode mode)
        {
            //Enable && Disable
            cf.Clear(PanelTitle);
            cf.Clear(Panel_Detail);
            lblStaffCD_Name.Text = string.Empty;

            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(Panel_Detail);

            txtKouritenCD.Focus();
            txtKensakuHyouziJun.Text = "0";
            lblStaffCD_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;

            switch (mode)
            {
                case Mode.New:
                    ErrorCheck();

                    txtChangeDate.E132Check(true, "M_Kouriten", txtKouritenCD, txtChangeDate, null);
                    txtChangeDate.E133Check(false, "M_Kouriten", txtKouritenCD, txtChangeDate, null);
                    txtChangeDate.E270Check(false, "M_Kouriten", txtKouritenCD, txtChangeDate);


                    txtCopyDate.E103Check(true);
                    txtCopyDate.E102MultiCheck(true, txtCopyCD, txtCopyDate);
                    txtCopyDate.E133Check(true, "M_Kouriten", txtCopyCD, txtCopyDate, null);


                    txtChangeDate.NextControlName = txtCopyCD.Name;
                    txtCopyCD.Enabled = true;
                    txtCopyDate.Enabled = true;

                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    break;

                case Mode.Update:
                    ErrorCheck();

                    txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, txtYubin1.Text, txtYubin2.Text);

                    txtChangeDate.E132Check(false, "M_Kouriten", txtKouritenCD, txtChangeDate, null);
                    txtChangeDate.E133Check(true, "M_Kouriten", txtKouritenCD, txtChangeDate, null);
                    txtChangeDate.E270Check(false, "M_Kouriten", txtKouritenCD, txtChangeDate);

                    Disable_UDI_Mode();
                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    txtChangeDate.E132Check(false, "M_Kouriten", txtKouritenCD, txtChangeDate, null);
                    txtChangeDate.E133Check(true, "M_Kouriten", txtKouritenCD, txtChangeDate, null);

                    txtChangeDate.E270Check(true, "M_Kouriten", txtKouritenCD, txtChangeDate);

                    Disable_UDI_Mode();
                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;

                    break;
                case Mode.Inquiry:
                    txtChangeDate.E132Check(false, "M_Kouriten", txtKouritenCD, txtChangeDate, null);
                    txtChangeDate.E133Check(true, "M_Kouriten", txtKouritenCD, txtChangeDate, null);

                    Disable_UDI_Mode();

                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;
                    break;
            }
        }
        public void ErrorCheck()
        {
            txtYubin2.E102MultiCheck(true, txtYubin1, txtYubin2);
            txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, string.Empty, string.Empty);

            txtKouritenCD.E102Check(true);
            txtChangeDate.E102Check(true);
            txtChangeDate.E103Check(true);

            txtKouritenName.E102Check(true);
            txtKouritenRyakuName.E102Check(true);
            txtKanaName.E102Check(true);
            txtYubin2.E102MultiCheck(true, txtYubin1, txtYubin2);

            txtTokuisakiCD.E102Check(true);
            txtTokuisakiCD.E101Check(true, "M_Tokuisaki", txtTokuisakiCD, txtChangeDate, null);

            txtStaffCD.E102Check(true);
            txtStaffCD.E101Check(true, "M_Staff", txtStaffCD, txtChangeDate, null);

            txtStartDate.E103Check(true);
            txtEndDate.E103Check(true);
            txtEndDate.E104Check(true, txtStartDate, txtEndDate);
        }
        public void Disable_UDI_Mode()
        {
            txtCopyCD.Enabled = false;
            txtCopyDate.Enabled = false;
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
            if (tagID == "10")
            {
                //if(ErrorCheck(PanelTitle) && ErrorCheck(Panel_Detail))
                //{
                //string Xml = ChooseFile();

                //BaseBL bbl = new BaseBL();
                //if (bbl.ShowMessage("Q206") != DialogResult.Yes)
                //{
                //    PreviousCtrl.Focus();
                //}
                //else
                //{
                //    SiiresakiBL bl = new SiiresakiBL();
                //    string chk_val = string.Empty;
                //    if (rdo_Registragion.Checked)
                //        chk_val = "create_update";
                //    else chk_val = "delete";
                //    bl.CSV_M_Siiresaki_CUD(Xml, chk_val);
                //}
                //  }

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
            KouritenEntity entity = GetInsert();

            if (cboMode.SelectedValue.Equals("1"))
            {
                entity.Mode = "New";
                DoInsert(entity);
            }
            else if (cboMode.SelectedValue.Equals("2"))
            {
                entity.Mode = "Update";
                DoUpdate(entity);
            }
            else if (cboMode.SelectedValue.Equals("3"))
            {
                entity.Mode = "Delete";
                DoDelete(entity);
            }
        }
        private KouritenEntity GetInsert()
        {
            KouritenEntity obj = new KouritenEntity();
            obj.KouritenCD = txtKouritenCD.Text;
            obj.ChangeDate = txtChangeDate.Text;
            obj.ShokutiFLG = chk_Flag.Checked ? "1" : "0";
            obj.TokuisakiCD = txtTokuisakiCD.Text;
            obj.KouritenName = txtKouritenName.Text;
            obj.KouritenRyakuName = txtKouritenRyakuName.Text;
            obj.KanaName = txtKanaName.Text;
            if (rdo_AliasKBN1.Checked)
                obj.AliasKBN = "1";
            else obj.AliasKBN = "2";
            obj.YuubinNO1 = txtYubin1.Text;
            obj.YuubinNO2 = txtYubin2.Text;
            obj.Juusho1 = txtAddress1.Text;
            obj.Juusho2 = txtAddress2.Text;
            obj.Tel11 = txtPhone1_1.Text;
            obj.Tel12 = txtPhone1_2.Text;
            obj.Tel13 = txtPhone1_3.Text;
            obj.Tel21 = txtPhone2_1.Text;
            obj.Tel22 = txtPhone2_2.Text;
            obj.Tel23 = txtPhone2_3.Text;
            obj.TantouBusho = txtTantouBusho.Text;
            obj.TantoushaName = txtTantoushaName.Text;
            obj.TantouYakushoku = txtTantouYakushoku.Text;
            obj.MailAddress = txtMail.Text;
            obj.StaffCD = txtStaffCD.Text;
            obj.TorihikiKaisiDate = txtStartDate.Text;
            obj.TorihikiShuuryouDate = txtEndDate.Text;
            obj.Remarks = txtRemark.Text;
            int int_val = 0;
            int.TryParse(txtKensakuHyouziJun.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out int_val);
            obj.KensakuHyouziJun = int_val.ToString();
            obj.UsedFlg = 0;
            obj.InsertOperator = base_Entity.OperatorCD;
            obj.UpdateOperator = base_Entity.OperatorCD;

            //for log table
            obj.PC = base_Entity.PC;
            obj.ProgramID = base_Entity.ProgramID;
            obj.KeyItem = txtKouritenCD.Text + " " + txtChangeDate.Text;
            return obj;
        }

        private void DoInsert(KouritenEntity obj)
        {
            KouritenBL objMethod = new KouritenBL();
            objMethod.M_Kouriten_CUD(obj);
        }
        private void DoUpdate(KouritenEntity obj)
        {
            KouritenBL objMethod = new KouritenBL();
            objMethod.M_Kouriten_CUD(obj);
        }
        private void DoDelete(KouritenEntity obj)
        {
            KouritenBL objMethod = new KouritenBL();
            objMethod.M_Kouriten_CUD(obj);
        }

        private void txtChangeDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtChangeDate.IsErrorOccurs)
                {
                    if (cboMode.SelectedValue.ToString() == "2")
                    {
                        EnablePanel();
                    }
                    else if (cboMode.SelectedValue.ToString() == "3" || cboMode.SelectedValue.ToString() == "4")
                    {
                        cf.DisablePanel(PanelTitle);
                    }
                }
                DataTable dt = txtChangeDate.IsDatatableOccurs;
                if (dt.Rows.Count > 0 && cboMode.SelectedValue.ToString() != "1")
                {
                    From_DB_To_Form(dt);
                }
            }
        }
        private void EnablePanel()
        {
            cf.EnablePanel(Panel_Detail);
            txtTokuisakiCD.Focus();
            cf.DisablePanel(PanelTitle);
        }
        private void From_DB_To_Form(DataTable dt)
        {
            if (dt.Rows[0]["MessageID"].ToString() == "E132")
            {
                if (Convert.ToInt32(dt.Rows[0]["ShokutiFLG"]) == 1)
                    chk_Flag.Checked = true;
                else chk_Flag.Checked = false;
                txtKouritenName.Text = dt.Rows[0]["KouritenName"].ToString();
                txtKouritenRyakuName.Text = dt.Rows[0]["KouritenRyakuName"].ToString();
                txtKanaName.Text = dt.Rows[0]["KanaName"].ToString();
                txtKensakuHyouziJun.Text = dt.Rows[0]["KensakuHyouziJun"].ToString();
                txtTokuisakiCD.Text = dt.Rows[0]["TokuisakiCD"].ToString();
                txtYubin1.Text = dt.Rows[0]["YuubinNO1"].ToString();
                txtYubin2.Text = dt.Rows[0]["YuubinNO2"].ToString();
                txtAddress1.Text = dt.Rows[0]["Juusho1"].ToString();
                txtAddress2.Text = dt.Rows[0]["Juusho2"].ToString();
                txtPhone1_1.Text = dt.Rows[0]["Tel11"].ToString();
                txtPhone1_2.Text = dt.Rows[0]["Tel12"].ToString();
                txtPhone1_3.Text = dt.Rows[0]["Tel13"].ToString();
                txtPhone2_1.Text = dt.Rows[0]["Tel21"].ToString();
                txtPhone2_2.Text = dt.Rows[0]["Tel22"].ToString();
                txtPhone2_3.Text = dt.Rows[0]["Tel23"].ToString();
                txtTantouBusho.Text = dt.Rows[0]["TantouBusho"].ToString();
                txtTantouYakushoku.Text = dt.Rows[0]["TantouYakushoku"].ToString();
                txtTantoushaName.Text = dt.Rows[0]["TantoushaName"].ToString();
                txtMail.Text = dt.Rows[0]["MailAddress"].ToString();
                txtStaffCD.Text = dt.Rows[0]["StaffCD"].ToString();
                lblStaffCD_Name.Text = dt.Rows[0]["StaffName"].ToString();
                txtStartDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["TorihikiKaisiDate"]);
                txtEndDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["TorihikiShuuryouDate"]);
                txtRemark.Text = dt.Rows[0]["Remarks"].ToString();

                txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, dt.Rows[0]["YuubinNO1"].ToString(), dt.Rows[0]["YuubinNO2"].ToString());
            }
        }

        private void txtCopyDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cboMode.SelectedValue.ToString() == "1")
            {
                if (!txtCopyDate.IsErrorOccurs)
                {
                    EnablePanel();
                    DataTable dt = txtCopyDate.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                        From_DB_To_Form(dt);
                }
            }
        }

        private void txtKensakuHyouziJun_TextChanged(object sender, EventArgs e)
        {
            string value = txtKensakuHyouziJun.Text.Replace(",", "");
            ulong ul;
            if (ulong.TryParse(value, out ul))
            {
                txtKensakuHyouziJun.TextChanged -= txtKensakuHyouziJun_TextChanged;
                txtKensakuHyouziJun.Text = string.Format("{0:#,#0}", ul);
                txtKensakuHyouziJun.SelectionStart = txtKensakuHyouziJun.Text.Length;
                txtKensakuHyouziJun.TextChanged += txtKensakuHyouziJun_TextChanged;
            }
            else
            {
                txtKensakuHyouziJun.Text = "0";
            }
        }

        private void txtYubin2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtYubin2.IsErrorOccurs && txtYubin2.IsDatatableOccurs.Rows.Count > 0)
                {
                    DataTable dt = txtYubin2.IsDatatableOccurs;
                    txtAddress1.Text = dt.Rows[0]["Juusho1"].ToString();
                    txtAddress2.Text = dt.Rows[0]["Juusho2"].ToString();
                }
            }
        }

        private void txtTokuisakiCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (!txtTokuisakiCD.IsErrorOccurs)
            {
                DataTable dt = txtTokuisakiCD.IsDatatableOccurs;
                if (dt.Rows.Count > 0)
                    sLabel6.Text = dt.Rows[0]["TokuisakiRyakuName"].ToString();
            }
        }
    }
}
