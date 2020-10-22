﻿using System;
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

        BaseBL bbl;
        FileFunction ff;
        StaffBL staffBL;
        ProgramEntity programEntity;
        protected string ProgramID { get; set; }
        protected Control PreviousCtrl { get; set; }

        #region ProcessMode
        public enum Mode
        {
            New,
            Update,
            Delete,
            Inquiry
        }
        #endregion

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

        public BaseForm()
        {
            InitializeComponent();
            programEntity = new ProgramEntity();
            bbl = new BaseBL();
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
            SButton btn = (SButton)sender;
            FireClickEvent(btn);
        }

        private void FireClickEvent(SButton btn)
        {
            switch(btn.ButtonType)
            {
                case ButtonType.BType.Close:
                    if (bbl.ShowMessage("Q003") == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    else
                    {
                        if (PreviousCtrl != null)
                            PreviousCtrl.Focus();
                        return;
                    }
                    break;
                case ButtonType.BType.New:
                case ButtonType.BType.Update:
                case ButtonType.BType.Delete:
                case ButtonType.BType.Inquiry:
                    if (bbl.ShowMessage("Q005") != DialogResult.Yes)
                    {
                        if(PreviousCtrl != null)
                            PreviousCtrl.Focus();
                        return;
                    }
                    else
                        FunctionProcess(btn.Tag.ToString());
                    break;
                case ButtonType.BType.Save:
                    FunctionProcess(btn.Tag.ToString());
                    break;

            }
        }

        public virtual void FunctionProcess(string tagID)
        {
        }

        protected void SetButton(ButtonType.BType buttonType,SButton button,string buttonText,bool visible)
        {
            button.ButtonType = buttonType;
            switch(buttonType)
            {
                case ButtonType.BType.Close:
                    button.Text = buttonText;
                    break;
                case ButtonType.BType.Save:
                    button.Text = buttonText;
                    break;
                case ButtonType.BType.Cancel:
                    button.Text = buttonText;
                    break;
                case ButtonType.BType.Search:
                    button.Text = buttonText;
                    break;
                case ButtonType.BType.Empty:
                    button.Text = buttonText;
                    break;
                case ButtonType.BType.New:
                    CheckButton(programEntity.Insertable, buttonText, button);
                    break;
                case ButtonType.BType.Update:
                    CheckButton(programEntity.Updatable, buttonText, button);
                    break;
                case ButtonType.BType.Delete:
                    CheckButton(programEntity.Deletable, buttonText, button);
                    break;
                case ButtonType.BType.Inquiry:
                    CheckButton(programEntity.Inquirable, buttonText, button);
                    break;
                case ButtonType.BType.Print:
                    CheckButton(programEntity.Printable, buttonText, button);
                    break;
            }

            button.Visible = visible;
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
            switch(e.KeyCode)
            {
                case Keys.F1:
                case Keys.F2:
                case Keys.F3:
                case Keys.F4:
                case Keys.F5:
                case Keys.F6:
                case Keys.F7:
                case Keys.F8:
                case Keys.F9:
                case Keys.F10:
                case Keys.F11:
                case Keys.F12:
                    SButton btn = this.Controls.Find("Btn" + e.KeyCode.ToString(),true)[0] as SButton;
                    FireClickEvent(btn);
                    break;
                case Keys.Enter:
                    if (ActiveControl is STextBox)
                    {
                        STextBox stxt = ActiveControl as STextBox;
                        if (!string.IsNullOrWhiteSpace(stxt.NextControlName))
                        {
                            Control[] ctlArr = this.Controls.Find(stxt.NextControlName, true);
                            if (ctlArr.Length > 0)
                            {
                                stxt.NextControl = ctlArr[0];
                            }
                        }
                    }
                    break;

            }    
        }

        private void FuctionButton_MouseEnter(object sender, EventArgs e)
        {
            PreviousCtrl = this.ActiveControl;
        }
        public LogEntity GetLogData()
        {
            LogEntity obj = new LogEntity();
            obj.InsertOperator = OperatorCD;
            obj.Program = ProgramID;
            obj.PC = PCID;
            return obj;
        }
    }
}
