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
            cboStaff_Mode.Bind(false);
            cboStaff_Menu.Bind(false);
            cboStaff_authority.Bind(false);
            cboStaff_Position.Bind(false);
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
            // ChangeMode(Mode.New);

            objLog_Entity = GetLogData();
            
        }
        private void ChangeMode(Mode mode)
        {
            switch (mode)
            {
                case Mode.New:
                    txt_Staff.E102Check(true);                    
                    txtStaff_Name.E102Check(true);
                    cboStaff_Menu.E102Check(true);
                    cboStaff_authority.E102Check(true);
                    txtStaff_Passward.E102Check(true);
                    txtStaff_Confirm.E166Check(true,txtStaff_Passward,txtStaff_Confirm);
                    txtStaff_JDate.E102Check(true); 
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

    }
}
