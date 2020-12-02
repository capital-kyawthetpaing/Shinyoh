using BL;
using CKM_CommonFunction;
using Entity;
using Shinyoh;
using Shinyoh_Controls;
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

        public MasterTourokuKouriten()
        {
            InitializeComponent();
            cf = new CommonFunction();
            base_bl = new BaseBL();
            err = new ErrorCheck();
        }

        private void MasterTourokuKouriten_Load(object sender, EventArgs e)
        {
            ProgramID = "MasterTourokuKouriten";
            StartProgram();
            cboMode.Bind(false, multi_Entity);

            txtStaffCD.lblName = lblStaffCD_Name;
            txtTokuisakiCD.lblName = lblTokuisakiRyakuName;

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

            txtKouritenCD.ChangeDate = txtChangeDate;
            txtCopyCD.ChangeDate = txtCopyDate;
        }

        private void ChangeMode(Mode mode)
        {
            Mode_Setting();

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
                    txtChangeDate.E270Check(false, "M_Kouriten", txtKouritenCD, txtChangeDate);

                    Disable_UDI_Mode();

                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;
                    break;
            }
        }
        private void Mode_Setting()
        {
            cf.Clear(PanelTitle);
            cf.Clear(Panel_Detail);
            rdo_AliasKBN1.Checked = true;
            lblStaffCD_Name.Text = string.Empty;
            lblTokuisakiRyakuName.Text = string.Empty;

            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(Panel_Detail);

            txtKouritenCD.Focus();
            txtKensakuHyouziJun.Text = "0";
            lblStaffCD_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblTokuisakiRyakuName.BorderStyle = System.Windows.Forms.BorderStyle.None;
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

                BaseBL bbl = new BaseBL();
                if (bbl.ShowMessage("Q206") != DialogResult.Yes)
                {
                    PreviousCtrl.Focus();
                }
                else
                {
                    KouritenBL bl = new KouritenBL();
                    string chk_val = string.Empty;
                    if (rdo_Registragion.Checked)
                        chk_val = "create_update";
                    else chk_val = "delete";
                    bl.CSV_M_Kouriten_CUD(Xml, chk_val);
                }
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
            {
                obj.AliasKBN = "1";
            }
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
                lblTokuisakiRyakuName.Text= dt.Rows[0]["TokuisakiRyakuName"].ToString();
                if (dt.Rows[0]["AliasKBN"].ToString() == "1")
                    rdo_AliasKBN1.Checked = true;
                else rdo_AliasKBN2.Checked = true;
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
                rdo_AliasKBN2.Checked = false;
        }

        private void rdo_AliasKBN2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_AliasKBN2.Checked == true)
                rdo_AliasKBN1.Checked = false;           
        }

        private void btn_Copy_Click(object sender, EventArgs e)
        {
            TokuisakiBL bl = new TokuisakiBL();
            DataTable dt = bl.M_Tokuisaki_Select(txtTokuisakiCD.Text, txtChangeDate.Text, "E101");
            if (dt.Rows.Count > 0 && dt.Rows[0]["MessageID"].ToString() == "E132")
                Copy_Tokuisaki_Data(dt);
        }

        private void Copy_Tokuisaki_Data(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["MessageID"].ToString() == "E132")
                {
                    if (dt.Rows[0]["ShokutiFLG"].ToString().Equals("1"))
                    {
                        chk_Flag.Checked = true;
                    }
                    else
                        chk_Flag.Checked = false;
                    txtKouritenName.Text = dt.Rows[0]["TokuisakiName"].ToString();
                    txtKouritenRyakuName.Text = dt.Rows[0]["TokuisakiRyakuName"].ToString();
                    txtKanaName.Text = dt.Rows[0]["KanaName"].ToString();
                    txtKensakuHyouziJun.Text = dt.Rows[0]["KensakuHyouziJun"].ToString();

                    if (dt.Rows[0]["AliasKBN"].ToString().Equals("1"))
                    {
                        rdo_AliasKBN1.Checked = true;
                    }
                    else if (dt.Rows[0]["AliasKBN"].ToString().Equals("2"))
                        rdo_AliasKBN2.Checked = true;

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
                    lblStaffCD_Name.Text= dt.Rows[0]["StaffName"].ToString();
                    txtStartDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["TorihikiKaisiDate"]);
                    txtEndDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["TorihikiShuuryouDate"]);
                    txtRemark.Text = dt.Rows[0]["Remarks"].ToString();
                }
            }
        }

        private string ChooseFile()
        {

            var filePath = string.Empty;
            KouritenEntity obj = new KouritenEntity();
            string Xml = string.Empty;
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
                    string[] csvRows = File.ReadAllLines(filePath);
                    var bl_List = new List<bool>();
                    for (int i = 1; i < csvRows.Length; i++)
                    {
                        var splits = csvRows[i].Split(',');
                        obj.KouritenCD = splits[0];
                        bl_List.Add(Null_Check(obj.KouritenCD));
                        bl_List.Add(Byte_Check(10, obj.KouritenCD));

                        //
                        obj.ChangeDate = splits[1];
                        bl_List.Add(Null_Check(obj.ChangeDate));
                        bl_List.Add(Date_Check(obj.ChangeDate));

                        //
                        obj.ShokutiFLG = splits[2];
                        bl_List.Add(Null_Check(obj.ShokutiFLG.ToString()));
                        if (!(obj.ShokutiFLG == "0" || obj.ShokutiFLG == "1"))
                        {
                            base_bl.ShowMessage("E117", "0", "1");
                            //err.ShowErrorMessage("E117");
                            bl_List.Add(true);
                        }

                        //
                        obj.KouritenName = splits[3];
                        bl_List.Add(Null_Check(obj.KouritenName.ToString()));
                        bl_List.Add(Byte_Check(80, obj.KouritenName));

                        //
                        obj.KouritenRyakuName = splits[4];
                        bl_List.Add(Null_Check(obj.KouritenRyakuName.ToString()));
                        bl_List.Add(Byte_Check(40, obj.KouritenRyakuName));

                        //
                        obj.KanaName = splits[5];
                        bl_List.Add(Byte_Check(80, obj.KanaName));

                        //no error check
                        obj.KensakuHyouziJun = splits[6];

                        obj.TokuisakiCD = splits[7];
                        bl_List.Add(Null_Check(obj.TokuisakiCD.ToString()));
                        bl_List.Add(Byte_Check(10, obj.TokuisakiCD));

                        //
                        obj.AliasKBN = splits[8];
                        if (!(obj.AliasKBN == "1" || obj.AliasKBN == "2"))
                        {
                            base_bl.ShowMessage("E117", "1", "2");
                            bl_List.Add(true);
                        }
                        bl_List.Add(Null_Check(obj.AliasKBN.ToString()));

                        //
                        obj.YuubinNO1 = splits[9];
                        bl_List.Add(Byte_Check(3, obj.YuubinNO1));

                        //
                        obj.YuubinNO2 = splits[10];
                        bl_List.Add(Byte_Check(4, obj.YuubinNO2));

                        //
                        obj.Juusho1 = splits[11];
                        bl_List.Add(Byte_Check(80, obj.Juusho1));

                        //
                        obj.Juusho2 = splits[12];
                        bl_List.Add(Byte_Check(80, obj.Juusho2));

                        //
                        obj.Tel11 = splits[13];
                        bl_List.Add(Byte_Check(6, obj.Tel11));

                        //
                        obj.Tel12 = splits[14];
                        bl_List.Add(Byte_Check(5, obj.Tel12));

                        //
                        obj.Tel13 = splits[15];
                        bl_List.Add(Byte_Check(5, obj.Tel13));

                        //
                        obj.Tel21 = splits[16];
                        bl_List.Add(Byte_Check(6, obj.Tel21));

                        //
                        obj.Tel22 = splits[17];
                        bl_List.Add(Byte_Check(5, obj.Tel22));

                        //
                        obj.Tel23 = splits[18];
                        bl_List.Add(Byte_Check(5, obj.Tel23));

                        //
                        obj.TantouBusho = splits[19];
                        bl_List.Add(Byte_Check(40, obj.TantouBusho));

                        //
                        obj.TantouYakushoku = splits[20];
                        bl_List.Add(Byte_Check(40, obj.TantouYakushoku));

                        //
                        obj.TantoushaName = splits[21];
                        bl_List.Add(Byte_Check(40, obj.TantoushaName));

                        //
                        obj.MailAddress = splits[22];
                        bl_List.Add(Byte_Check(100, obj.MailAddress));

                        //
                        obj.StaffCD = splits[23];
                        bl_List.Add(Null_Check(obj.StaffCD.ToString()));
                        bl_List.Add(Byte_Check(10, obj.StaffCD));

                        //
                        obj.TorihikiKaisiDate = splits[24];
                        bl_List.Add(Date_Check(obj.TorihikiKaisiDate));

                        //
                        obj.TorihikiShuuryouDate = splits[25];
                        bl_List.Add(Date_Check(obj.TorihikiShuuryouDate));

                        //
                        obj.Remarks = splits[26];
                        bl_List.Add(Byte_Check(80, obj.Remarks));

                        // Error E101 for Staff
                        DataTable dt = new DataTable();
                        StaffBL sBL = new StaffBL();
                        dt = sBL.Staff_Select_Check(obj.StaffCD, obj.ChangeDate, "E101");
                        if (dt.Rows[0]["MessageID"].ToString() == "E101")
                        {
                            err.ShowErrorMessage("E101");
                             bl_List.Add(true);
                        }

                        // Error E101 for Tokuisaki
                        DataTable dt1 = new DataTable();
                        TokuisakiBL tBL = new TokuisakiBL();
                        dt = tBL.M_Tokuisaki_Select(obj.TokuisakiCD, obj.ChangeDate, "E101");
                        if (dt.Rows[0]["MessageID"].ToString() == "E101")
                        {
                            err.ShowErrorMessage("E101");
                            bl_List.Add(true);
                        }

                        string error = string.Empty;
                        if (bl_List.Contains(true))
                            error = "true";
                        else error = "false";

                        DataRow dr = create_dt.NewRow();
                        for (int j = 0; j < splits.Length; j++)
                        {
                            if (string.IsNullOrEmpty(splits[j]))
                                dr[j] = DBNull.Value;
                            else
                                dr[j] = splits[j].ToString();
                        }
                        dr[27] = "0";
                        dr[28] = base_Entity.OperatorCD;
                        dr[29] = base_Entity.OperatorCD;
                        dr[30] = error;
                        create_dt.Rows.Add(dr);
                    }

                    Xml = cf.DataTableToXml(create_dt);
                }
            }
            return Xml;
        }

        private bool Null_Check(string obj_text)
        {
            bool bl = false;
            if (string.IsNullOrWhiteSpace(obj_text))
            {
                err.ShowErrorMessage("E102");
                bl = true;
            }
            return bl;
        }
        private bool Byte_Check(int obj_len, string obj_text)
        {
            bool bl = false;
            if (cf.IsByteLengthOver(obj_len, obj_text))
            {
                err.ShowErrorMessage("E142");
                bl = true;
            }
            return bl;
        }
        public bool Date_Check(string csv_Date)
        {
            bool bl = false;
            if (!string.IsNullOrEmpty(csv_Date))
            {
                if (!cf.CheckDateValue(csv_Date))
                {
                    err.ShowErrorMessage("E103");
                    bl = true;
                }
            }
            return bl;
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
    }
}
