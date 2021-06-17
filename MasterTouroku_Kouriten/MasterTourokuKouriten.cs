using BL;
using CKM_CommonFunction;
using Entity;
using Shinyoh;
using Shinyoh_Controls;
using Shinyoh_Search;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
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
        ErrorCheck err;
        BaseBL base_bl;
        string YuuBinNO1 = string.Empty;
        string YuuBinNO2 = string.Empty;
        string Address1 = string.Empty;
        string Address2 = string.Empty;
        BaseBL bbl = new BaseBL();
        public MasterTourokuKouriten()
        {
            InitializeComponent();
            cf = new CommonFunction();
            base_bl = new BaseBL();
            err = new ErrorCheck();
        }
        private void MasterTourokuKouriten_Load(object sender, EventArgs e)
        {
            ProgramID = "MasterTouroku_Kouriten";

            StartProgram();
            cboMode.Bind(false, multi_Entity);

            txtStaffCD.lblName = lblStaffCD_Name;

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

            ChangeMode(GetMode(Mode.New));
            txtTokuisakiCD.Focus();

            base_Entity = _GetBaseData();
            txtSystemDate.Text = base_Entity.LoginDate;

            txtStaffCD.ChangeDate = txtChangeDate;
            txtKouritenCD.ChangeDate = txtChangeDate;
            txtCopyCD.TxtBox = txtTokuisakiCD_Copy;//ses
            txtKouritenCD.TxtBox = txtTokuisakiCD;//ses
            txtCopyCD.ChangeDate = txtCopyDate;
            txtTokuisakiCD.ChangeDate = txtSystemDate;
            txtTokuisakiCD_Copy.ChangeDate = txtSystemDate;
            panel2.GotFocus += RadioPanel_GotFocus;
        }

        private void ChangeMode(Mode mode)
        {
            Mode_Setting();
            ErrorCheck();

            switch (mode)
            {
                case Mode.New:

                    txtChangeDate.E132Check(true, "M_Kouriten", txtKouritenCD, txtChangeDate, txtTokuisakiCD);
                    txtChangeDate.E133Check(false, "M_Kouriten", txtKouritenCD, txtChangeDate,null);

                    txtChangeDate.E270Check(false, "M_Kouriten", txtKouritenCD, txtChangeDate);
                    txtTokuisakiCD_Copy.Enabled = true;
                    txtChangeDate.NextControlName = txtTokuisakiCD_Copy.Name;
                    txtTokuisakiCD_Copy.TabIndex = 4;
                    txtCopyCD.Enabled = true;
                    txtTokuisakiCD_Copy.NextControlName = txtCopyCD.Name;
                    txtCopyCD.TabIndex = 5;
                    txtCopyDate.Enabled = true;
                    txtCopyCD.NextControlName = txtCopyDate.Name;
                    txtCopyDate.TabIndex = 6;
                    txtCopyDate.E103Check(true);
                    txtCopyCD.E102MultiCheck(true, txtTokuisakiCD_Copy, txtCopyCD);
                    txtCopyDate.E102MultiCheck(true, txtCopyCD, txtCopyDate);
                    txtCopyDate.E133Check(true, "M_Kouriten", txtCopyCD, txtCopyDate, txtTokuisakiCD_Copy);

                    txtTokuisakiCD.E101Check(true, "M_Tokuisaki", txtTokuisakiCD, txtSystemDate, null);

                    //txtChangeDate.NextControlName = txtTokuisakiCD_Copy.Name;
                    //txtTokuisakiCD_Copy.Enabled = true;
                    //txtCopyCD.Enabled = true;
                    //txtCopyDate.Enabled = true;
                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    break;

                case Mode.Update:

                    txtChangeDate.E132Check(false, "M_Kouriten", txtKouritenCD, txtChangeDate, null);
                    txtChangeDate.E133Check(true, "M_Kouriten", txtKouritenCD, txtChangeDate, txtTokuisakiCD);
                    txtChangeDate.E270Check(false, "M_Kouriten", txtKouritenCD, txtChangeDate);

                    txtTokuisakiCD.E101Check(true, "M_Tokuisaki", txtTokuisakiCD, txtSystemDate, null);

                    Disable_UDI_Mode();
                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    txtChangeDate.E132Check(false, "M_Kouriten", txtKouritenCD, txtChangeDate, null);
                    txtChangeDate.E133Check(true, "M_Kouriten", txtKouritenCD, txtChangeDate, txtTokuisakiCD);

                    txtChangeDate.E270Check(true, "M_Kouriten", txtKouritenCD, txtChangeDate,txtTokuisakiCD);

                    txtTokuisakiCD.E101Check(true, "M_Tokuisaki", txtTokuisakiCD, txtSystemDate, null);
                    Disable_UDI_Mode();
                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;

                    break;
                case Mode.Inquiry:
                    txtChangeDate.E132Check(false, "M_Kouriten", txtKouritenCD, txtChangeDate, null);
                    txtChangeDate.E133Check(true, "M_Kouriten", txtKouritenCD, txtChangeDate, txtTokuisakiCD);
                    txtChangeDate.E270Check(false, "M_Kouriten", txtKouritenCD, txtChangeDate);

                    txtTokuisakiCD.E101Check(true, "M_Tokuisaki", txtTokuisakiCD, txtSystemDate, null);
                    Disable_UDI_Mode();

                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;
                    break;
            }
        }
        private void Mode_Setting()
        {
            cf.Clear(PanelTitle);
            cf.Clear(PanelDetail);
            rdo_AliasKBN1.Checked = true;
           
            lblStaffCD_Name.Text = string.Empty;
           

            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(PanelDetail);

            txtTokuisakiCD.Focus();
           // txtKensakuHyouziJun.Text = "0";
            lblStaffCD_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
           

            rdo_Registragion.Checked = true;

            YuuBinNO1 = string.Empty;
            YuuBinNO2 = string.Empty;
            Address1 = string.Empty;
            Address2 = string.Empty;
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
            txtYubin2.E102MultiCheck(true, txtYubin1, txtYubin2);

            txtTokuisakiCD.E102Check(true);
            //txtTokuisakiCD.E101Check(true, "M_Tokuisaki", txtTokuisakiCD, txtSystemDate, null);

            txtStaffCD.E102Check(true);
            txtStaffCD.E101Check(true, "M_Staff", txtStaffCD, txtChangeDate, null);

            txtStartDate.E103Check(true);
            txtEndDate.E103Check(true);
            txtEndDate.E104Check(true, txtStartDate, txtEndDate);
        }
        public void Disable_UDI_Mode()
        {
            txtTokuisakiCD_Copy.Enabled = false;
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
            if (tagID == "6")
            {
                Mode_Setting();
                if (cboMode.SelectedValue.Equals("2") || cboMode.SelectedValue.Equals("3") || cboMode.SelectedValue.Equals("4"))
                {
                    Disable_UDI_Mode();
                }
            }
            if (tagID == "10")
            {
                string Xml = ChooseFile();
                if (!string.IsNullOrEmpty(Xml))
                {
                    KouritenBL bl = new KouritenBL();
                    string chk_val = string.Empty;
                    if (rdo_Registragion.Checked)
                        chk_val = "create_Err_Check";
                    else chk_val = "delete_Err_Check";
                    DataTable dt = bl.CSV_M_Kouriten_CUD(Xml, chk_val);
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
                                dt = bl.CSV_M_Kouriten_CUD(Xml, chk_val);
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
                //if (ErrorCheck(PanelTitle) && ErrorCheck(PanelDetail))
                //{
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
                //}
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
            if (rdo_AliasKBN1.Checked==true)
            {
                obj.AliasKBN = "1";
            }
            else if(rdo_AliasKBN2.Checked==true)
            {
                obj.AliasKBN = "2";
            }
            //else obj.AliasKBN = "2";
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
            string return_BL = objMethod.M_Kouriten_CUD(obj);
            if (return_BL == "true")
                bbl.ShowMessage("I101");
        }
        private void DoUpdate(KouritenEntity obj)
        {
            KouritenBL objMethod = new KouritenBL();
            string return_BL = objMethod.M_Kouriten_CUD(obj);
            if (return_BL == "true")
                bbl.ShowMessage("I101");
        }
        private void DoDelete(KouritenEntity obj)
        {
            KouritenBL objMethod = new KouritenBL();
            string return_BL = objMethod.M_Kouriten_CUD(obj);
            if (return_BL == "true")
                bbl.ShowMessage("I102");
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
                        if (cboMode.SelectedValue.ToString() == "3")
                        {
                            Control btnF12 = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                            btnF12.Focus();
                        }
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
            cf.EnablePanel(PanelDetail);
            chk_Flag.Focus();
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
                // txtTokuisakiCD.Text = dt.Rows[0]["TokuisakiCD"].ToString();

                if (dt.Rows[0]["AliasKBN"].ToString() == "1")
                {
                    rdo_AliasKBN1.Checked = true;
                    //txtKanaName.NextControlName = rdo_AliasKBN1.Name;
                }
                else
                {
                    rdo_AliasKBN2.Checked = true;
                    //txtKanaName.NextControlName = rdo_AliasKBN2.Name;
                }
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
                Address1 = dt.Rows[0]["Juusho1"].ToString();
                Address2 = dt.Rows[0]["Juusho2"].ToString();
                YuuBinNO1 = dt.Rows[0]["YuubinNO1"].ToString();
                YuuBinNO2 = dt.Rows[0]["YuubinNO2"].ToString();
               // txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, dt.Rows[0]["YuubinNO1"].ToString(), dt.Rows[0]["YuubinNO2"].ToString());
            }
        }

        private void txtCopyDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cboMode.SelectedValue.ToString() == "1")
            {
                if (ErrorCheck(PanelTitle))
                {
                    if (!txtCopyDate.IsErrorOccurs)
                    {
                        EnablePanel();
                        DataTable dt = txtCopyDate.IsDatatableOccurs;
                        if (dt.Rows.Count > 0)
                            From_DB_To_Form(dt);
                    }
                }
                else
                {
                    cf.Clear(PanelDetail);
                }
            }
        }

        private void txtKensakuHyouziJun_TextChanged(object sender, EventArgs e)
        {
            //string value = txtKensakuHyouziJun.Text.Replace(",", "");
            //ulong ul;
            //if (ulong.TryParse(value, out ul))
            //{
            //    txtKensakuHyouziJun.TextChanged -= txtKensakuHyouziJun_TextChanged;
            //    txtKensakuHyouziJun.Text = string.Format("{0:#,#0}", ul);
            //    txtKensakuHyouziJun.SelectionStart = txtKensakuHyouziJun.Text.Length;
            //    txtKensakuHyouziJun.TextChanged += txtKensakuHyouziJun_TextChanged;
            //}
            //else
            //{
            //    txtKensakuHyouziJun.Text = "0";
            //}
        }

        private void txtYubin2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtYubin2.IsErrorOccurs)
                {
                    if (txtYubin2.IsDatatableOccurs.Rows.Count > 0)
                    {
                        DataTable dt = txtYubin2.IsDatatableOccurs;
                        txtAddress1.Text = dt.Rows[0]["Juusho1"].ToString();
                        txtAddress2.Text = dt.Rows[0]["Juusho2"].ToString();
                    }
                    else
                    {
                        if (txtYubin1.Text != YuuBinNO1 || txtYubin2.Text != YuuBinNO2)
                        {
                            txtAddress1.Text = string.Empty;
                            txtAddress2.Text = string.Empty;
                        }
                        else
                        {
                            txtAddress1.Text = Address1;
                            txtAddress2.Text = Address2;
                        }
                    }
                }
            }
        }

        //private void txtTokuisakiCD_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (!txtTokuisakiCD.IsErrorOccurs)
        //    {
        //        DataTable dt = txtTokuisakiCD.IsDatatableOccurs;
        //        if (dt.Rows.Count > 0)
        //            lblTokuisakiRyakuName.Text = dt.Rows[0]["TokuisakiRyakuName"].ToString();
        //    }
        //}

        //private void txtStaffCD_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (!txtStaffCD.IsErrorOccurs)
        //    {
        //        DataTable dt = txtStaffCD.IsDatatableOccurs;
        //        if (dt.Rows.Count > 0)
        //            lblStaffCD_Name.Text = dt.Rows[0]["StaffName"].ToString();
        //    }
        //}

        private void rdo_AliasKBN1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_AliasKBN1.Checked == true)
            {
                rdo_AliasKBN2.Checked = false;
                //txtKanaName.NextControlName = rdo_AliasKBN1.Name;
            }
               
        }

        private void rdo_AliasKBN2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_AliasKBN2.Checked == true)
            {
                rdo_AliasKBN1.Checked = false;
                //txtKanaName.NextControlName = rdo_AliasKBN2.Name;
            }
        }

        //private void btn_Copy_Click(object sender, EventArgs e)
        //{
        //    TokuisakiBL bl = new TokuisakiBL();
        //    DataTable dt = bl.M_Tokuisaki_Select(txtTokuisakiCD.Text, txtChangeDate.Text, "E101");
        //    if (dt.Rows.Count > 0 && dt.Rows[0]["MessageID"].ToString() == "E132")
        //        Copy_Tokuisaki_Data(dt);
        //}

        //private void Copy_Tokuisaki_Data(DataTable dt)
        //{
        //    if (dt.Rows.Count > 0)
        //    {
        //        if (dt.Rows[0]["MessageID"].ToString() == "E132")
        //        {
        //            if (dt.Rows[0]["ShokutiFLG"].ToString().Equals("1"))
        //            {
        //                chk_Flag.Checked = true;
        //            }
        //            else
        //                chk_Flag.Checked = false;
        //            txtKouritenName.Text = dt.Rows[0]["TokuisakiName"].ToString();
        //            txtKouritenRyakuName.Text = dt.Rows[0]["TokuisakiRyakuName"].ToString();
        //            txtKanaName.Text = dt.Rows[0]["KanaName"].ToString();
        //            txtKensakuHyouziJun.Text = dt.Rows[0]["KensakuHyouziJun"].ToString();

        //            if (dt.Rows[0]["AliasKBN"].ToString().Equals("1"))
        //            {
        //                rdo_AliasKBN1.Checked = true;
        //            }
        //            else if (dt.Rows[0]["AliasKBN"].ToString().Equals("2"))
        //                rdo_AliasKBN2.Checked = true;

        //            txtYubin1.Text = dt.Rows[0]["YuubinNO1"].ToString();
        //            txtYubin2.Text = dt.Rows[0]["YuubinNO2"].ToString();
        //            txtAddress1.Text = dt.Rows[0]["Juusho1"].ToString();
        //            txtAddress2.Text = dt.Rows[0]["Juusho2"].ToString();
        //            txtPhone1_1.Text = dt.Rows[0]["Tel11"].ToString();
        //            txtPhone1_2.Text = dt.Rows[0]["Tel12"].ToString();
        //            txtPhone1_3.Text = dt.Rows[0]["Tel13"].ToString();
        //            txtPhone2_1.Text = dt.Rows[0]["Tel21"].ToString();
        //            txtPhone2_2.Text = dt.Rows[0]["Tel22"].ToString();
        //            txtPhone2_3.Text = dt.Rows[0]["Tel23"].ToString();
        //            txtTantouBusho.Text = dt.Rows[0]["TantouBusho"].ToString();
        //            txtTantouYakushoku.Text = dt.Rows[0]["TantouYakushoku"].ToString();
        //            txtTantoushaName.Text = dt.Rows[0]["TantoushaName"].ToString();
        //            txtMail.Text = dt.Rows[0]["MailAddress"].ToString();
        //            txtStaffCD.Text = dt.Rows[0]["StaffCD"].ToString();
        //            //lblStaffCD_Name.Text= dt.Rows[0]["StaffName"].ToString();
        //            txtStartDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["TorihikiKaisiDate"]);
        //            txtEndDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["TorihikiShuuryouDate"]);
        //            txtRemark.Text = dt.Rows[0]["Remarks"].ToString();
        //        }
        //    }
        //}

        private string ChooseFile()
        {
            var filePath = string.Empty;
            KouritenEntity obj = new KouritenEntity();
            string Xml = string.Empty;
            string error = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\CSV Folder\\";
                openFileDialog.Title = "Browse CSV Files";
                openFileDialog.Filter = "csv files (*.csv)|*.csv";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                DataTable create_dt = new DataTable();
                Create_Datatable_Column(create_dt);
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    string[] csvRows = File.ReadAllLines(filePath,Encoding.GetEncoding(932));
                    //string[] csvRows = File.ReadAllLines(OpenFileDialog, Encoding.GetEncoding(932));
                    var bl_List = new List<bool>();
                    for (int i = 1; i < csvRows.Length; i++)
                    {
                        error = "false";
                        var splits = csvRows[i].Split(',');
                        DataRow dr = create_dt.NewRow();
                        for (int j = 0; j < splits.Length; j++)
                        {
                            if (string.IsNullOrEmpty(splits[j]))
                                dr[j] = DBNull.Value;
                            else
                                dr[j] = splits[j].ToString();
                        }
                        dr["UsedFlg"] = "0";
                        dr["InsertOperator"] = base_Entity.OperatorCD;
                        dr["UpdateOperator"] = base_Entity.OperatorCD;
                        dr["Error"] = error;
                        create_dt.Rows.Add(dr);

                        //var splits = csvRows[i].Split(',');
                        //obj.KouritenCD = splits[0];
                        //if(Null_Check(obj.KouritenCD, i, "小売店CD未入力エラー"))break;
                        //if(Byte_Check(10, obj.KouritenCD, i, "小売店CD桁数エラー"))break;
                        ////
                        //obj.ChangeDate = splits[1];
                        //if(Null_Check(obj.ChangeDate, i, "改定日未入力エラー"))break;
                        //if (Date_Check(obj.ChangeDate, i, "入力可能値外エラー", "改定日") == "true") break;
                        //else splits[1] = Date_Check(obj.ChangeDate, i, "入力可能値外エラー", "改定日");

                        ////
                        //obj.ShokutiFLG = splits[2];
                        //if(Null_Check(obj.ShokutiFLG, i, "諸口未入力エラー"))break;
                        //if (!(obj.ShokutiFLG == "0" || obj.ShokutiFLG == "1"))
                        //{
                        //    bbl.ShowMessage("E276", i.ToString(), "入力可能値外エラー", "項目:諸口区分(0～1)");
                        //    //bl_List.Add(true);
                        //    break;
                        //}

                        ////
                        //obj.KouritenName = splits[3];
                        //if(Null_Check(obj.KouritenName, i, "小売店名未入力エラー"))break;
                        //if(Byte_Check(80, obj.KouritenName, i, "小売店名桁数エラー"))break;

                        ////
                        //obj.KouritenRyakuName = splits[4];
                        //if(Null_Check(obj.KouritenRyakuName, i, "略名未入力エラー"))break;
                        //if(Byte_Check(40, obj.KouritenRyakuName, i, "略名桁数エラー"))break;

                        ////
                        //obj.KanaName = splits[5];
                        //if(Byte_Check(80, obj.KanaName, i, "カナ名桁数エラー"))break;

                        ////no error check
                        //obj.KensakuHyouziJun = splits[6];

                        //obj.TokuisakiCD = splits[7];
                        //if(Null_Check(obj.TokuisakiCD, i, "得意先CD未入力エラー"))break;
                        //if(Byte_Check(10, obj.TokuisakiCD, i, "得意先CD桁数エラー"))break;

                        ////
                        //obj.AliasKBN = splits[8];
                        //if (Null_Check(obj.AliasKBN, i, "敬称未入力エラー")) break;
                        //if (!(obj.AliasKBN == "1" || obj.AliasKBN == "2"))
                        //{
                        //    bbl.ShowMessage("E276", i.ToString(), "入力可能値外エラー", "項目:敬称(1～2)");
                        //    //base_bl.ShowMessage("E117", "1", "2");
                        //    // bl_List.Add(true);
                        //    break;
                        //}

                        ////
                        //obj.YuubinNO1 = splits[9];
                        //if(Byte_Check(3, obj.YuubinNO1, i, "郵便番号１桁数エラー"))break;

                        ////
                        //obj.YuubinNO2 = splits[10];
                        //if(Byte_Check(4, obj.YuubinNO2, i, "郵便番号２桁数エラー"))break;

                        ////
                        //obj.Juusho1 = splits[11];
                        //if(Byte_Check(80, obj.Juusho1, i, "住所１桁数エラー"))break;

                        ////
                        //obj.Juusho2 = splits[12];
                        //if(Byte_Check(80, obj.Juusho2, i, "住所２桁数エラー"))break;

                        ////
                        //obj.Tel11 = splits[13];
                        //if(Byte_Check(6, obj.Tel11, i, "電話番号①-1桁数エラー")) break;

                        ////
                        //obj.Tel12 = splits[14];
                        //if(Byte_Check(5, obj.Tel12, i, "電話番号①-2桁数エラー"))break;

                        ////
                        //obj.Tel13 = splits[15];
                        //if(Byte_Check(5, obj.Tel13, i, "電話番号①-3桁数エラー"))break;

                        ////
                        //obj.Tel21 = splits[16];
                        //if(Byte_Check(6, obj.Tel21, i, "電話番号②-1桁数エラー"))break;

                        ////
                        //obj.Tel22 = splits[17];
                        //if(Byte_Check(5, obj.Tel22, i, "電話番号②-2桁数エラー"))break;

                        ////
                        //obj.Tel23 = splits[18];
                        //if(Byte_Check(5, obj.Tel23, i, "電話番号②-3桁数エラー"))break;

                        ////
                        //obj.TantouBusho = splits[19];
                        //if(Byte_Check(40, obj.TantouBusho, i, "担当部署桁数エラー"))break;

                        ////
                        //obj.TantouYakushoku = splits[20];
                        //if(Byte_Check(40, obj.TantouYakushoku, i, "担当役職桁数エラー"))break;

                        ////
                        //obj.TantoushaName = splits[21];
                        //if(Byte_Check(40, obj.TantoushaName, i, "担当者名桁数エラー"))break;

                        ////
                        //obj.MailAddress = splits[22];
                        //if(Byte_Check(100, obj.MailAddress, i, "メールアドレス桁数エラー"))break;

                        ////
                        //obj.StaffCD = splits[23];
                        //if(Null_Check(obj.StaffCD, i, "担当スタッフCD未入力エラー"))break;
                        //if(Byte_Check(10, obj.StaffCD, i, "担当スタッフCD桁数エラー"))break;

                        ////
                        //obj.TorihikiKaisiDate = splits[24];
                        //if (!string.IsNullOrEmpty(obj.TorihikiKaisiDate))
                        //{
                        //    if (Date_Check(obj.TorihikiKaisiDate, i, "入力可能値外エラー", "取引開始日") == "true") break;
                        //    else splits[24] = Date_Check(obj.TorihikiKaisiDate, i, "入力可能値外エラー", "取引開始日");
                        //}

                        ////
                        //obj.TorihikiShuuryouDate = splits[25];
                        //if(!string.IsNullOrEmpty(obj.TorihikiShuuryouDate))
                        //{
                        //    if (Date_Check(obj.TorihikiShuuryouDate, i, "入力可能値外エラー", "取引終了日") == "true") break;
                        //    else splits[25] = Date_Check(obj.TorihikiShuuryouDate, i, "入力可能値外エラー", "取引終了日");
                        //}

                        ////
                        //obj.Remarks = splits[26];
                        //if(Byte_Check(80, obj.Remarks, i, "備考桁数エラー"))break;

                        //// Error E101 for Staff
                        //DataTable dt = new DataTable();
                        //StaffBL sBL = new StaffBL();
                        //dt = sBL.Staff_Select_Check(obj.StaffCD, obj.ChangeDate, "E101");
                        //if (dt.Rows[0]["MessageID"].ToString() == "E101")
                        //{
                        //    bbl.ShowMessage("E276", i.ToString(), "担当スタッフCD未登録エラー");
                        //    // bl_List.Add(true);
                        //    break;
                        //}
                        //// Error E101 for Tokuisaki
                        //DataTable dt1 = new DataTable();
                        //TokuisakiBL tBL = new TokuisakiBL();
                        //dt1 = tBL.M_Tokuisaki_Select(obj.TokuisakiCD, obj.ChangeDate, "E101");
                        //if (dt1.Rows[0]["MessageID"].ToString() == "E101")
                        //{
                        //    bbl.ShowMessage("E276", i.ToString(), "得意先CD未登録エラー");
                        //    // bl_List.Add(true);
                        //    break;
                        //}

                        //if (rdo_Registragion.Checked == true) //2020/12/14 Y.HET ADD
                        //{
                        //    //2020/12/14 Y.Nishikawa ADD
                        //    DataTable dt2 = new DataTable();
                        //    KouritenBL kBL = new KouritenBL();
                        //    dt2 = kBL.Kouriten_Select_Check(obj.KouritenCD, obj.ChangeDate, "E132", obj.TokuisakiCD);
                        //    if (dt2.Rows[0]["MessageID"].ToString() == "E132")
                        //    {
                        //        bbl.ShowMessage("E276", i.ToString(), "小売店CD登録済エラー");
                        //        // bl_List.Add(true);
                        //        break;
                        //    }
                        //}

                        //string error = string.Empty;
                        //if (bl_List.Contains(true))
                        //    error = "true";
                        //else error = "false";

                        //DataRow dr = create_dt.NewRow();
                        //for (int j = 0; j < splits.Length; j++)
                        //{
                        //    if (string.IsNullOrEmpty(splits[j]))
                        //        dr[j] = DBNull.Value;
                        //    else
                        //        dr[j] = splits[j].ToString();
                        //}
                        //dr[27] = "0";
                        //dr[28] = base_Entity.OperatorCD;
                        //dr[29] = base_Entity.OperatorCD;
                        //dr[30] = error;
                        //create_dt.Rows.Add(dr);
                    }
                    //if(create_dt.Rows.Count == csvRows.Length-1)
                    if(create_dt.Rows.Count>0)
                    {
                        for(int r=0;r<create_dt.Rows.Count;r++)
                        {
                            //NMW task NO 592 begin
                            TextBox txt1 = new TextBox();
                            txt1.Text = create_dt.Rows[r]["ChangeDate"].ToString();//column_1
                            if (cf.DateCheck(txt1))
                                create_dt.Rows[r]["ChangeDate"] = string.IsNullOrEmpty(txt1.Text)?null:txt1.Text;
                            string date1 = create_dt.Rows[r]["ChangeDate"].ToString();//column_1

                            TextBox txt2 = new TextBox();
                            txt2.Text = create_dt.Rows[r]["TorihikiKaisiDate"].ToString();//column_2
                            if (cf.DateCheck(txt2))
                                create_dt.Rows[r]["TorihikiKaisiDate"] = string.IsNullOrEmpty(txt2.Text)?null:txt2.Text;
                            string date2 = create_dt.Rows[r]["TorihikiKaisiDate"].ToString();//column_2

                            TextBox txt3 = new TextBox();
                            txt3.Text = create_dt.Rows[r]["TorihikiShuuryouDate"].ToString();
                            if (cf.DateCheck(txt3))
                                create_dt.Rows[r]["TorihikiShuuryouDate"] = string.IsNullOrEmpty(txt3.Text)?null:txt3.Text;
                            string date3 = create_dt.Rows[r]["TorihikiShuuryouDate"].ToString();//column_3
                            //NMW task NO 592 end

                            int line_No = r + 1;

                            if (Date_Check(date1, line_No, "入力可能値外エラー", "項目:改定日") == "true")
                            {
                                return null;
                            }
                            else if (Date_Check(date2, line_No, "入力可能値外エラー", "取引開始日") == "true")
                            {
                                return null;
                            }
                            else if (Date_Check(date3, line_No, "入力可能値外エラー", "取引終了日") == "true")
                            {
                                return null;
                            }
                            else if (r == create_dt.Rows.Count - 1)
                            {
                                Xml = cf.DataTableToXml(create_dt);
                            }

                            //if (!string.IsNullOrEmpty(date1) && !DateCheck(date1))
                            //{
                            //    bbl.ShowMessage("E276", line_No.ToString(), "入力可能値外エラー", "項目:改定日");
                            //    return null;
                            //}
                            //else if (!string.IsNullOrEmpty(date2) && !DateCheck(date2))
                            //{
                            //    bbl.ShowMessage("E276", line_No.ToString(), "入力可能値外エラー", "取引開始日");
                            //    return null;
                            //}
                            //else if (!string.IsNullOrEmpty(date3) && !DateCheck(date3))
                            //{
                            //    bbl.ShowMessage("E276", line_No.ToString(), "入力可能値外エラー", "取引終了日");
                            //    return null;
                            //}
                            //else if(r==create_dt.Rows.Count-1)
                            //{
                            //    Xml = cf.DataTableToXml(create_dt);
                            //}
                        }
                    }
                }
                else
                {
                    Xml = string.Empty;
                }
            }
            return Xml;
        }

        //private bool Null_Check(string obj_text, int line_no, string error_msg)
        //{
        //    bool bl = false;
        //    if (string.IsNullOrWhiteSpace(obj_text))
        //    {
        //        bbl.ShowMessage("E276", line_no.ToString(), error_msg);
        //        bl = true;
        //    }
        //    return bl;
        //}
        //private bool Byte_Check(int obj_len, string obj_text, int line_no, string error_msg)
        //{
        //    bool bl = false;
        //    if (cf.IsByteLengthOver(obj_len, obj_text))
        //    {
        //        bbl.ShowMessage("E276", line_no.ToString(), error_msg);
        //        bl = true;
        //    }
        //    return bl;
        //}
        public string Date_Check(string csv_Date, int line_no, string error_msg1, string error_msg2)
        {
            //bool bl = false;
            TextBox txt = new TextBox();
            txt.Text = csv_Date;
            if (!string.IsNullOrEmpty(csv_Date))
            {
                if (!cf.DateCheck(txt))
                {
                    bbl.ShowMessage("E276", line_no.ToString(), error_msg1, error_msg2);
                    txt.Text = "true";
                }
            }
            return txt.Text;
        }
        public void Create_Datatable_Column(DataTable create_dt)
        {
            create_dt.Columns.Add("KouritenCD");
            create_dt.Columns.Add("ChangeDate");
            create_dt.Columns.Add("ShokutiFLG");
            create_dt.Columns.Add("KouritenName");
            create_dt.Columns.Add("KouritenRyakuName");
            create_dt.Columns.Add("KanaName");
            create_dt.Columns.Add("KensakuHyouziJun");
            create_dt.Columns.Add("TokuisakiCD");
            create_dt.Columns.Add("AliasKBN");
            create_dt.Columns.Add("YuubinNO1");
            create_dt.Columns.Add("YuubinNO2");
            create_dt.Columns.Add("Juusho1");
            create_dt.Columns.Add("Juusho2");
            create_dt.Columns.Add("Tel11");
            create_dt.Columns.Add("Tel12");
            create_dt.Columns.Add("Tel13");
            create_dt.Columns.Add("Tel21");
            create_dt.Columns.Add("Tel22");
            create_dt.Columns.Add("Tel23");
            create_dt.Columns.Add("TantouBusho");
            create_dt.Columns.Add("TantouYakushoku");
            create_dt.Columns.Add("TantoushaName");
            create_dt.Columns.Add("MailAddress");
            create_dt.Columns.Add("StaffCD");
            create_dt.Columns.Add("TorihikiKaisiDate");
            create_dt.Columns.Add("TorihikiShuuryouDate");
            create_dt.Columns.Add("Remarks");
            create_dt.Columns.Add("UsedFlg");
            create_dt.Columns.Add("InsertOperator");
            create_dt.Columns.Add("UpdateOperator");
            create_dt.Columns.Add("Error");
        }

        private bool DateCheck(string date)//ssa
        {
            if (DateTime.TryParseExact(date, "yyyy/mm/dd", CultureInfo.InvariantCulture,DateTimeStyles.None, out DateTime Temp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
