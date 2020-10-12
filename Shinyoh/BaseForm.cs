using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using CKM_CommonFunction;
using BL;
using Entity;
using System.Data;
using Shinyoh_Controls;

namespace Shinyoh
{
    public partial class BaseForm : Form
    {
        #region Login Information
        protected string CompanyCD { get; set; }
        protected string OperatorCD { get; set; }
        protected string PCID { get; set; }
        #endregion

        FileFunction ff;
        StaffBL staffBL;
        ProgramEntity programEntity;
        protected string ProgramID { get; set; }

        #region Function Button
        protected SButton F1 { get => BtnF1; set => BtnF1 = value; }
        protected SButton F2 { get => BtnF2; set => BtnF2 = value; }
        protected SButton F3 { get => BtnF3; set => BtnF3 = value; }
        protected SButton F4 { get => BtnF4; set => BtnF4 = value; }
        protected SButton F5 { get => BtnF5; set => BtnF5 = value; }
        protected SButton F6 { get => BtnF6; set => BtnF6 = value; }
        protected SButton F7 { get => BtnF7; set => BtnF7 = value; }
        protected SButton F8 { get => BtnF8; set => BtnF8 = value; }
        protected SButton F9 { get => BtnF9; set => BtnF9 = value; }
        protected SButton F10 { get => BtnF10; set => BtnF10 = value; }
        protected SButton F11 { get => BtnF11; set => BtnF11 = value; }
        protected SButton F12 { get => BtnF12; set => BtnF12 = value; }
        #endregion

        protected enum ButtonType
        {
            Insert,
            Update,
            Delete,
            Inquiry,
            Print,
            Run
        }

        public BaseForm()
        {
            InitializeComponent();
            programEntity = new ProgramEntity();
            ff = new FileFunction();
            staffBL = new StaffBL();
        }

        protected void StartProgram()
        {
            string filePath = string.Empty;
            if (Debugger.IsAttached)
            {
                System.Uri u = new System.Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
                filePath = System.IO.Path.GetDirectoryName(u.LocalPath) + @"\" + "DBConfig.ini";
            }
            else
            {
                filePath = @"C:\\DBConfig\\DBConfig.ini";
            }
            Dictionary<string, string> dicConfig = ff.ReadConfig(filePath, "DataBase", "Shinyoh");
            if (this.GetCmdLine() == false || dicConfig.Count == 0)
            {
                //起動時エラー    DB接続不可能
                this.Close();
                System.Environment.Exit(0);
            }

            BaseBL.IEntity.DatabaseServer = dicConfig["DatabaseServer"];
            BaseBL.IEntity.DatabaseName = dicConfig["DatabaseName"];
            BaseBL.IEntity.DatabaseLoginID = dicConfig["DatabaseLoginID"];
            BaseBL.IEntity.DatabasePassword = dicConfig["DatabasePassword"];


            StaffEntity staffEntity = new StaffEntity
            {
                StaffCD = OperatorCD
            };

            //set LoginName & LoginDate
            staffEntity = staffBL.GetStaffEntity(staffEntity);
            sLabel1.Text = staffEntity.StaffName;
            sLabel2.Text = staffEntity.LoginDate;

            staffEntity.ProgramID = ProgramID;
            programEntity = staffBL.Staff_AccessCheck(staffEntity);
            if(programEntity == null)
            {
                this.Close();
                System.Environment.Exit(0);
            }
        }

        private bool GetCmdLine()
        {
            string[] cmds = System.Environment.GetCommandLineArgs();

            if (cmds.Length < 4)
                return false;

            CompanyCD = cmds[1];
            OperatorCD = cmds[2];
            PCID = cmds[3];

            if (string.IsNullOrWhiteSpace(CompanyCD)
                || string.IsNullOrWhiteSpace(OperatorCD)
                || string.IsNullOrWhiteSpace(PCID))
                return false;

            return true;
        }

        private void btnFunctionClick(object sender,EventArgs e)
        {
            Button btn = (Button)sender;
            FunctionProcess((int)btn.Tag);
        }

        public virtual void FunctionProcess(int Index)
        {
        }

        protected void SetButton(ButtonType buttonType,Button button,string buttonText)
        {
            switch(buttonType)
            {
                case ButtonType.Insert:
                    CheckButton(programEntity.Insertable, buttonText, button);
                    break;
                case ButtonType.Update:
                    CheckButton(programEntity.Updatable, buttonText, button);
                    break;
                case ButtonType.Delete:
                    CheckButton(programEntity.Deletable, buttonText, button);
                    break;
                case ButtonType.Inquiry:
                    CheckButton(programEntity.Inquirable, buttonText, button);
                    break;
                case ButtonType.Print:
                    CheckButton(programEntity.Printable, buttonText, button);
                    break;
            }
        }

        private void CheckButton(string Value,string Text,Button button)
        {
            if(Value.Equals("0"))
            {
                button.Text = string.Empty;
                button.Enabled = false;
            }
            else
            {
                button.Text = Text;
                button.Enabled = true;
            }
        }

        private void BaseForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(ActiveControl is STextBox)
                {
                    STextBox stxt = ActiveControl as STextBox;
                    if(!string.IsNullOrWhiteSpace(stxt.NextControlName))
                    {
                        Control[] ctlArr = this.Controls.Find(stxt.NextControlName, true);
                        if (ctlArr.Length > 0)
                        {
                            stxt.NextControl = ctlArr[0];
                        }
                    }                   
                }
            }
        }
    }
}
