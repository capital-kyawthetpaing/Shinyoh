using BL;
using Entity;
using Shinyoh;
using System;

namespace MasterTouroku_Staff
{
    public partial class MasterTouroku_Staff : BaseForm
    {
        ButtonType type = new ButtonType();
        LogEntity objLog_Entity;
        public MasterTouroku_Staff()
        {
            InitializeComponent();
        }

        private void MasterTouroku_Staff_Load(object sender, EventArgs e)
        {
            ProgramID = "MasterTourokuStaff";
            StartProgram();
            cboStaff_Mode.Bind(true);
            cboStaff_Menu.Bind(true);
            cboStaff_authority.Bind(true);
            cboStaff_Position.Bind(true);
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
            SetButton(ButtonType.BType.Empty, F10, "", false);
            SetButton(ButtonType.BType.Empty, F11, "", false);
             ChangeMode(Mode.New);

            objLog_Entity = GetLogData();    
        }
        private void ChangeMode(Mode mode)
        {
            switch (mode)
            {
                case Mode.New:
                    //E102
                    txt_Staff.E102Check(true);
                    txtStaff_CDate.E102Check(true);
                    txtStaff_CopyDate.E102MultiCheck(true, txtStaff_Copy, txtStaff_CopyDate);
                    txtStaff_Name.E102Check(true);
                    cboStaff_Menu.E102Check(true);
                    cboStaff_authority.E102Check(true);
                    txtStaff_JDate.E102Check(true);
                    //E103
                    txtStaff_CDate.E103Check(true);
                    txtStaff_CopyDate.E103Check(true);
                    txtStaff_JDate.E103Check(true);
                    txtStaff_LDate.E103Check(true);
                    //E04
                    txtStaff_LDate.E104Check(true, txtStaff_JDate, txtStaff_LDate);
                    //E132
                    txtStaff_CDate.E132Check(true,"M_Staff", txt_Staff, txtStaff_CDate, null);
                    //E133
                    txtStaff_CopyDate.E133Check(true, "M_Staff", txtStaff_Copy, txtStaff_CopyDate, null);
                    //E166
                    txtStaff_Confirm.E166Check(true,txtStaff_Passward,txtStaff_Confirm);                   
                    break;
                case Mode.Update:
                case Mode.Delete:
                case Mode.Inquiry:
                    //E132
                    txtStaff_CDate.E132Check(false, "M_Staff", txt_Staff, txtStaff_CDate, null);
                    //E133
                    txtStaff_CDate.E133Check(true, "M_Staff", txt_Staff, txtStaff_CDate, null);                    
                    break;
            }
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "2")
                cboStaff_Mode.SelectedValue = "1";              
            if (tagID == "3")
                cboStaff_Mode.SelectedValue = "2";           
            if (tagID == "4")
                cboStaff_Mode.SelectedValue = "3";            
            if (tagID == "5")
                cboStaff_Mode.SelectedValue = "4";
            if (tagID == "12")
                DBProcess();
            base.FunctionProcess(tagID);
        }
        private void DBProcess()
        {
            MasterTourokuStaff entity = GetInsertStaff();
            
            if (cboStaff_Mode.SelectedValue.Equals("1"))
            {
                entity.Mode = "New";
                objLog_Entity.Mode = "New";
                objLog_Entity.KeyItem= txt_Staff.Text.ToString() + " " + Convert.ToDateTime(txtStaff_CDate.Text).ToString("dd-MM-yyyy");

                DoInsert(entity);
                DoInsert_Log(objLog_Entity);
            }
            else if (cboStaff_Mode.SelectedValue.Equals("2"))
            {
                entity.Mode = "Update";
                objLog_Entity.Mode = "Update";
                objLog_Entity.KeyItem = txt_Staff.Text.ToString() + " " + Convert.ToDateTime(txtStaff_CDate.Text).ToString("dd-MM-yyyy");

                DoUpdate(entity);
                DoInsert_Log(objLog_Entity);
            }
            else if (cboStaff_Mode.SelectedValue.Equals("3"))
            {
                entity.Mode = "Delete";
                objLog_Entity.Mode = "Delete";
                objLog_Entity.KeyItem = txt_Staff.Text.ToString() + " " + Convert.ToDateTime(txtStaff_CDate.Text).ToString("dd-MM-yyyy");

                DoDelete(entity);
                DoInsert_Log(objLog_Entity);
            }
        }
        
        private MasterTourokuStaff GetInsertStaff()
        {
            MasterTourokuStaff obj = new MasterTourokuStaff();
            obj.StaffCD = txt_Staff.Text.ToString();
            obj.ChangeDate = Convert.ToDateTime(txtStaff_CDate.Text.ToString());
            obj.StaffName = txtStaff_Name.Text.ToString();
            obj.KanaName = txtStaff_KanaName.Text.ToString();
            obj.KensakuHyouziJun = Convert.ToInt32(txtStaff_Search.Text);
            obj.MenuCD = cboStaff_Menu.SelectedValue.ToString();
            obj.AuthorizationsCD = cboStaff_authority.SelectedValue.ToString();
            obj.PositionCD = cboStaff_Position.SelectedValue.ToString();
            obj.JoinDate = Convert.ToDateTime(txtStaff_JDate.Text.ToString());
            obj.LeaveDate = Convert.ToDateTime(txtStaff_LDate.Text.ToString());
            obj.Passward = txtStaff_Passward.Text;
            obj.Remarks = txtStaff_Remark.Text;
            obj.UsedFlg = 0;
            obj.InsertOperator = objLog_Entity.InsertOperator;
            obj.InsertDateTime = DateTime.Now;
            obj.UpdateOperator = objLog_Entity.InsertOperator;
            obj.UpdateDateTime = DateTime.Now;           
            return obj;
        }        
        private void DoInsert(MasterTourokuStaff obj)
        {
            StaffBL objMethod = new StaffBL();
            objMethod.M_Staff_CUD(obj);
        }
        public void DoInsert_Log(LogEntity obj)
        {
            StaffBL objMethod = new StaffBL();
            objMethod.L_Log_CUD(obj);
        }
        //NMW(2020-10-23)
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

        private void cboStaff_Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear();
            string item = cboStaff_Mode.SelectedValue.ToString();           
            if (item == "1")
            {
                txtStaff_Copy.Enabled = true;
                txtStaff_CopyDate.Enabled = true;
                ChangeMode(Mode.New);
            }
            else
            {
                txtStaff_Copy.Enabled = false;
                txtStaff_CopyDate.Enabled = false;
                if (item == "2")
                    ChangeMode(Mode.Update);
                else if (item == "3")
                    ChangeMode(Mode.Delete);
                else if (item == "4")
                    ChangeMode(Mode.Inquiry);
            }
        }
        private void Clear()
        {
            txt_Staff.Text = string.Empty;
            txtStaff_CDate.Text= string.Empty;
            txtStaff_Name.Text= string.Empty;
            txtStaff_KanaName.Text= string.Empty;
            txtStaff_Search.Text= string.Empty;
            cboStaff_Menu.SelectedIndex = -1;
            cboStaff_authority.SelectedIndex=-1;
            cboStaff_Position.SelectedIndex = -1;
            txtStaff_JDate.Text=string.Empty;
            txtStaff_LDate.Text=string.Empty;
            txtStaff_Passward.Text=string.Empty;
            txtStaff_Confirm.Text = string.Empty;
            txtStaff_Remark.Text = string.Empty;            
        }
    }
}
