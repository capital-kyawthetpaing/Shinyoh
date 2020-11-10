using BL;
using CKM_CommonFunction;
using Entity;
using Shinyoh;
using System;
using System.Data;
using System.Windows.Forms;

namespace MasterTouroku_Siiresaki
{
    public partial class MasterTourokuSiiresaki : BaseForm
    {
        CommonFunction cf;
        StaffEntity staff_Entity;
        multipurposeEntity multi_Entity;
        public MasterTourokuSiiresaki()
        {
            InitializeComponent();
            cf = new CommonFunction();
        }

        private void MasterTourokuSiiresaki_Load(object sender, EventArgs e)
        {
            ProgramID = "MasterTourokuSiiresaki";
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
            SetButton(ButtonType.BType.Empty, F8, "", false);
            SetButton(ButtonType.BType.Empty, F10, "CSV取込(F10)", true);
            SetButton(ButtonType.BType.Empty, F11, "", false);

            ChangeMode(Mode.New);
            txtSupplierCD.Focus();

            staff_Entity = GetBaseData(); 
        }

        private void ChangeMode(Mode mode)
        {
            //Enable && Disable
            cf.Clear(PanelTitle);
            cf.Clear(Panel_Detail);
            lblStaffCD_Name.Text = string.Empty;

            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(Panel_Detail);
            txtSupplierCD.Focus();
            txtSearch.Text = "0";
            lblStaffCD_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;

            switch (mode)
            {
                case Mode.New:
                    ErrorCheck();

                    txtChangeDate.E132Check(true, "M_Siiresaki", txtSupplierCD, txtChangeDate,null);
                    txtChangeDate.E133Check(false, "M_Siiresaki", txtSupplierCD, txtChangeDate, null);
                    txtChangeDate.E270Check(false, "M_Siiresaki", txtSupplierCD, txtChangeDate);


                    txtCopyDate.E103Check(true);
                    txtCopyDate.E102MultiCheck(true, txtCopyCD, txtCopyDate);
                    txtCopyDate.E133Check(true, "M_Siiresaki", txtCopyCD, txtCopyDate, null);

                    
                    txtChangeDate.NextControlName = txtCopyCD.Name;
                    txtCopyCD.Enabled = true;
                    txtCopyDate.Enabled = true;

                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    break;

                case Mode.Update:
                    ErrorCheck();

                    txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, string.Empty, string.Empty);

                    txtChangeDate.E132Check(false, "M_Siiresaki", txtSupplierCD, txtChangeDate, null);
                    txtChangeDate.E133Check(true, "M_Siiresaki", txtSupplierCD, txtChangeDate, null);
                    txtChangeDate.E270Check(false, "M_Siiresaki", txtSupplierCD, txtChangeDate);

                    Disable_UDI_Mode();
                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    txtChangeDate.E132Check(false, "M_Siiresaki", txtSupplierCD, txtChangeDate, null);
                    txtChangeDate.E133Check(true, "M_Siiresaki", txtSupplierCD, txtChangeDate, null);

                    txtChangeDate.E270Check(true, "M_Siiresaki", txtSupplierCD, txtChangeDate);

                    Disable_UDI_Mode();
                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;

                    break;
                case Mode.Inquiry:
                    txtChangeDate.E132Check(false, "M_Siiresaki", txtSupplierCD, txtChangeDate, null);
                    txtChangeDate.E133Check(true, "M_Siiresaki", txtSupplierCD, txtChangeDate, null);

                    Disable_UDI_Mode();
                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;
                    break;
            }
        }
        public void Disable_UDI_Mode()
        {
            txtCopyCD.Enabled = false;
            txtCopyDate.Enabled = false;
            rdo_Registragion.Enabled = false;
            rdo_Delete.Enabled = false;
        }
        public void ErrorCheck()
        {
            txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, string.Empty, string.Empty);

            txtSupplierCD.E102Check(true);
            txtChangeDate.E102Check(true);
            txtChangeDate.E103Check(true);

            txtSupplierName.E102Check(true);
            txtShort_Name.E102Check(true);
            txtPayCD.E102Check(true);
            txtYubin2.E102MultiCheck(true, txtYubin1, txtYubin2);
            

            txtCurrency.E102Check(true);
            txtStaffCD.E102Check(true);
            txtStaffCD.E101Check(true, "M_Staff", txtStaffCD, txtChangeDate, null);

            txtStartDate.E103Check(true);
            txtEndDate.E103Check(true);
            txtEndDate.E104Check(true, txtStartDate, txtEndDate);

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
            SiiresakiEntity entity = GetInsert();

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

        private SiiresakiEntity GetInsert()
        {
            SiiresakiEntity obj = new SiiresakiEntity();
            obj.SiiresakiCD = txtSupplierCD.Text;
            obj.ChangeDate = txtChangeDate.Text;
            obj.ShokutiFLG = chk_Flag.Checked ? 1 : 0;
            obj.SiiresakiName = txtSupplierName.Text;
            obj.SiiresakiRyakuName = txtShort_Name.Text;
            obj.KanaName = txtLong_Name.Text;
            obj.SiharaisakiCD = txtPayCD.Text;
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
            obj.TuukaCD = txtCurrency.Text;
            obj.StaffCD = txtStaffCD.Text;
            obj.TorihikiKaisiDate = txtStartDate.Text;
            obj.TorihikiShuuryouDate = txtEndDate.Text;
            obj.Remarks = txtRemark.Text;
            obj.KensakuHyouziJun = txtSearch.Text;
            obj.UsedFlg = 0;
            obj.InsertOperator = staff_Entity.StaffCD;
            obj.UpdateOperator = staff_Entity.StaffCD;

            //for log table
            obj.PC = staff_Entity.PC;
            obj.KeyItem = txtSupplierCD.Text + " " + txtChangeDate.Text;
            return obj;
        }

        private void DoInsert(SiiresakiEntity obj)
        {
            SiiresakiBL objMethod = new SiiresakiBL();
            objMethod.M_Siiresaki_CUD(obj);
        }
        private void DoUpdate(SiiresakiEntity obj)
        {
            SiiresakiBL objMethod = new SiiresakiBL();
            objMethod.M_Siiresaki_CUD(obj);
        }
        private void DoDelete(SiiresakiEntity obj)
        {
            SiiresakiBL objMethod = new SiiresakiBL();
            objMethod.M_Siiresaki_CUD(obj);
        }

        private void txtYubin2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (!txtYubin2.IsErrorOccurs && txtYubin2.IsDatatableOccurs.Rows.Count>0)
                {
                    DataTable dt = txtYubin2.IsDatatableOccurs;
                    txtAddress1.Text = dt.Rows[0]["Juusho1"].ToString();
                    txtAddress2.Text = dt.Rows[0]["Juusho2"].ToString();
                }
            }
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
                txtSupplierName.Text = dt.Rows[0]["SiiresakiName"].ToString();
                txtShort_Name.Text = dt.Rows[0]["SiiresakiRyakuName"].ToString();
                txtLong_Name.Text = dt.Rows[0]["KanaName"].ToString();
                txtSearch.Text = dt.Rows[0]["KensakuHyouziJun"].ToString();
                txtPayCD.Text = dt.Rows[0]["SiharaisakiCD"].ToString();
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
                txtCurrency.Text = dt.Rows[0]["TuukaCD"].ToString();
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

        private void txtStaffCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (!txtStaffCD.IsErrorOccurs)
            {
                DataTable dt = txtStaffCD.IsDatatableOccurs;
                if (dt.Rows.Count > 0)
                    lblStaffCD_Name.Text = dt.Rows[0]["StaffName"].ToString();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string value = txtSearch.Text.Replace(",", "");
            ulong ul;
            if (ulong.TryParse(value, out ul))
            {
                txtSearch.TextChanged -= txtSearch_TextChanged;
                txtSearch.Text = string.Format("{0:#,#0}", ul);
                txtSearch.SelectionStart = txtSearch.Text.Length;
                txtSearch.TextChanged += txtSearch_TextChanged;
            }
            else
            {
                txtSearch.Text = "0";
            }
        }
    }
}
