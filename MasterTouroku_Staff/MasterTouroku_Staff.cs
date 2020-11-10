using BL;
using Entity;
using Shinyoh;
using System;
using CKM_CommonFunction;
using System.Windows.Forms;
using System.Data;
using Shinyoh_Controls;
using Shinyoh_Search;

namespace MasterTouroku_Staff
{
    public partial class MasterTouroku_Staff : BaseForm
    {
        ButtonType type = new ButtonType();
        BaseEntity base_Entity;
        CommonFunction cf;
        StaffBL bl = new StaffBL();

        public MasterTouroku_Staff()
        {
            InitializeComponent();
            cf = new CommonFunction();
        }

        private void MasterTouroku_Staff_Load(object sender, EventArgs e)
        {
            multipurposeEntity multipurpose_entity = new multipurposeEntity();
            multipurpose_entity.id = 214;
            ProgramID = "MasterTourokuStaff";
            StartProgram();
            cboMode.Bind(false, multipurpose_entity);
            cboStaff_Menu.Bind(true, multipurpose_entity);
            cboStaff_authority.Bind(true, multipurpose_entity);
            cboStaff_Position.Bind(true, multipurpose_entity);
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
            SetButton(ButtonType.BType.Empty, F10, "", false);
            SetButton(ButtonType.BType.Empty, F11, "", false);
            
            ChangeMode(Mode.New);

            txt_Staff.Focus();
            base_Entity = _GetBaseData();

            SearchBox.ChangeDate = txtStaff_CDate;
            
        }

        private void ChangeMode(Mode mode)
        {
            //Enable && Disable
            cf.Clear(PanelTitle);
            cf.Clear(Panel_Staff);
            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(Panel_Staff);
            txt_Staff.Focus();
            txtStaff_Search.Text = "0";

            switch (mode)
            {
                case Mode.New:
                    
                    ErrorChek();
                    //E102
                    txtStaff_CDate.E102Check(true);
                    txtStaff_CopyDate.E102MultiCheck(true, txtStaff_Copy, txtStaff_CopyDate);
                    //E132
                    txtStaff_CDate.E132Check(true, "M_Staff", txt_Staff, txtStaff_CDate, null);
                    //E133
                    txtStaff_CDate.E133Check(false, "M_Staff", txt_Staff, txtStaff_CDate, null);
                    txtStaff_CopyDate.E133Check(true, "M_Staff", txtStaff_Copy, txtStaff_CopyDate, null);

                    txtStaff_CDate.NextControlName = txtStaff_Copy.Name;
                    txtStaff_Copy.Enabled = true;
                    txtStaff_CopyDate.Enabled = true;                   

                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    break;

                case Mode.Update:                    
                    ErrorChek();
                    //E132
                    txtStaff_CDate.E132Check(false, "M_Staff", txt_Staff, txtStaff_CDate, null);
                    //E133
                    txtStaff_CDate.E133Check(true, "M_Staff", txt_Staff, txtStaff_CDate, null);

                    //Enable && Disable
                    txtStaff_Copy.Enabled = false;
                    txtStaff_CopyDate.Enabled = false;
                   

                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    //E132
                    txtStaff_CDate.E132Check(false, "M_Staff", txt_Staff, txtStaff_CDate, null);
                    //E133
                    txtStaff_CDate.E133Check(true, "M_Staff", txt_Staff, txtStaff_CDate, null);
                    
                    //Enable && Disable
                    txtStaff_Copy.Enabled = false;
                    txtStaff_CopyDate.Enabled = false;

                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;

                    break;
                case Mode.Inquiry:
                    //E132
                    txtStaff_CDate.E132Check(false, "M_Staff", txt_Staff, txtStaff_CDate, null);
                    //E133
                    txtStaff_CDate.E133Check(true, "M_Staff", txt_Staff, txtStaff_CDate, null);

                    //Enable && Disable
                    txtStaff_Copy.Enabled = false;
                    txtStaff_CopyDate.Enabled = false;

                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;
                    break;
            }
        }

        private void ErrorChek()
        {
            //E102
            txt_Staff.E102Check(true);            
            txtStaff_Name.E102Check(true);
            cboStaff_Menu.E102Check(true);
            cboStaff_authority.E102Check(true);
            txtStaff_Passward.E102Check(true);
            txtStaff_JDate.E102Check(true);
            //E103
            txtStaff_CDate.E103Check(true);
            txtStaff_CopyDate.E103Check(true);
            txtStaff_JDate.E103Check(true);
            txtStaff_LDate.E103Check(true);
            //E04
            txtStaff_LDate.E104Check(true, txtStaff_JDate, txtStaff_LDate);

            //E166
            txtStaff_Confirm.E166Check(true, txtStaff_Passward, txtStaff_Confirm);
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
                if (ErrorCheck(PanelTitle) && ErrorCheck(Panel_Staff))
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
            MasterTourokuStaff entity = GetInsertStaff();            
            
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
        
        private MasterTourokuStaff GetInsertStaff()
        {
            MasterTourokuStaff obj = new MasterTourokuStaff();
            obj.StaffCD = txt_Staff.Text.ToString();
            obj.ChangeDate = txtStaff_CDate.Text.ToString();
            obj.StaffName = txtStaff_Name.Text.ToString();
            obj.KanaName = txtStaff_KanaName.Text.ToString();
            obj.KensakuHyouziJun =txtStaff_Search.Text;            
            obj.MenuCD = cboStaff_Menu.SelectedValue.ToString();
            obj.AuthorizationsCD = cboStaff_authority.SelectedValue.ToString();
            obj.PositionCD = cboStaff_Position.SelectedValue.ToString();
            obj.JoinDate = txtStaff_JDate.Text.ToString();
            obj.LeaveDate = txtStaff_LDate.Text.ToString();
            obj.Passward = txtStaff_Passward.Text;
            obj.Remarks = txtStaff_Remark.Text;
            obj.UsedFlg = 0;
            obj.InsertOperator = base_Entity.OperatorCD;
            obj.UpdateOperator = base_Entity.OperatorCD;
            

            //for log table
            obj.KeyItem = txt_Staff.Text.ToString() + " " + txtStaff_CDate.Text;
            obj.PC = base_Entity.PC;            
            return obj;
        }        

        private void DoInsert(MasterTourokuStaff obj)
        {
            StaffBL objMethod = new StaffBL();
            objMethod.M_Staff_CUD(obj);
        }
        
        private void DoUpdate(MasterTourokuStaff obj)
        {
            StaffBL objMethod = new StaffBL();
            objMethod.M_Staff_CUD(obj);
        }

        private void DoDelete(MasterTourokuStaff obj)
        {
            StaffBL objMethod = new StaffBL();
            objMethod.M_Staff_CUD(obj);
        }
        private void txtStaff_CopyDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cboMode.SelectedValue.ToString() == "1")
            {
                if (!txtStaff_CopyDate.IsErrorOccurs)
                {
                    EnablePanel();
                    DataTable dt = txtStaff_CopyDate.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                        From_DB_To_Form(dt);
                }
            }
        }
        
        private void EnablePanel()
        {
            cf.EnablePanel(Panel_Staff);
            txtStaff_Name.Focus();
            cf.DisablePanel(PanelTitle);
        }

        private void txtStaff_CDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtStaff_CDate.IsErrorOccurs)
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
                DataTable dt = txtStaff_CDate.IsDatatableOccurs;
                if(dt.Rows.Count>0 && cboMode.SelectedValue.ToString() != "1")
                {
                    From_DB_To_Form(dt);
                }
            }
        }

        private void From_DB_To_Form(DataTable dt)
        {
            if (dt.Rows[0]["MessageID"].ToString() == "E132")
            {
                txtStaff_Name.Text = dt.Rows[0]["StaffName"].ToString();
                txtStaff_KanaName.Text = dt.Rows[0]["KanaName"].ToString();
                txtStaff_Search.Text = dt.Rows[0]["KensakuHyouziJun"].ToString();
                cboStaff_Menu.SelectedValue = dt.Rows[0]["MenuCD"].ToString();
                cboStaff_authority.SelectedValue = dt.Rows[0]["AuthorizationsCD"].ToString();
                cboStaff_Position.SelectedValue = dt.Rows[0]["PositionCD"].ToString();
                txtStaff_Passward.Text = dt.Rows[0]["Passward"].ToString();
                txtStaff_Confirm.Text = dt.Rows[0]["Passward"].ToString();
                txtStaff_JDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["JoinDate"]);
                txtStaff_LDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["LeaveDate"]);
                txtStaff_Remark.Text = dt.Rows[0]["Remarks"].ToString();
            }
        }

        private void txtStaff_Search_TextChanged(object sender, EventArgs e)
        {
            string value = txtStaff_Search.Text.Replace(",", "");
            ulong ul;
            if (ulong.TryParse(value, out ul))
            {
                txtStaff_Search.TextChanged -= txtStaff_Search_TextChanged;
                txtStaff_Search.Text = string.Format("{0:#,#0}", ul);
                txtStaff_Search.SelectionStart = txtStaff_Search.Text.Length;
                txtStaff_Search.TextChanged += txtStaff_Search_TextChanged;
            }
            else
            {
                txtStaff_Search.Text = "0";
            }
        }
    }
}
