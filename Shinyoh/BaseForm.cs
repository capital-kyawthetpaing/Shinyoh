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
using System.Linq;
using System.Runtime.InteropServices;

namespace Shinyoh
{
    public partial class BaseForm : Form
    {
        #region Login Information
        protected string CompanyCD { get; set; }
        protected string OperatorCD { get; set; }
        protected string PCID { get; set; }
        protected string LoginDate { get;set;}
        #endregion

        BaseBL bbl;
        FileFunction ff;
        StaffBL staffBL;
        ProgramEntity programEntity;
        protected string ProgramID { get; set; }
        protected Control PreviousCtrl { get; set; }

        protected string LastSelectedMode { get; set; }

        #region ProcessMode
        public enum Mode
        {
            New,
            Update,
            Delete,
            Inquiry,
            Null
            //Idle // Ptk (idle , base int) added for hacchuushou
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
            LoginDate = staffEntity.LoginDate;

            staffEntity.ProgramID = ProgramID;
            staffEntity.PC = PCID;
            programEntity = staffBL.Staff_AccessCheck(staffEntity);
            if (programEntity == null)
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

        private void btnFunctionClick(object sender, EventArgs e)
        {
            SButton btn = (SButton)sender;
            if(btn.ButtonType == ButtonType.BType.Search)
            {
                if (PreviousCtrl != null)
                    PreviousCtrl.Focus();
                SendKeys.Send("{F9}");
            }
            else
                FireClickEvent(btn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="type">1--> button click, 2 --> combo Mode change</param>
        protected void FireClickEvent(SButton btn)
        {
            if (btn.Visible)
            {
                switch (btn.ButtonType)
                {
                    case ButtonType.BType.Close:                     
                        if (bbl.ShowMessage("Q003") == DialogResult.Yes)
                        {
                            BaseEntity be = new BaseEntity();
                            be.OperatorCD = OperatorCD;
                            be.ProgramID = ProgramID;
                            be.PC = PCID;
                            bbl.D_Exclusive_Number_Remove(be);
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
                        if (programEntity.Insertable.Equals("1"))
                            SetMode(btn,"1");
                        break;
                    case ButtonType.BType.Update:
                        if (programEntity.Updatable.Equals("1"))
                            SetMode(btn,"2");
                        break;
                    case ButtonType.BType.Delete:
                        if (programEntity.Deletable.Equals("1"))
                            SetMode(btn,"3");
                        break;
                    case ButtonType.BType.Inquiry:
                        if (programEntity.Inquirable.Equals("1"))
                            SetMode(btn,"4");
                        break;
                    case ButtonType.BType.Cancel:
                        if (bbl.ShowMessage("Q004") != DialogResult.Yes)
                        {
                            //cboMode.Enabled = false;
                            if (PreviousCtrl != null)
                                PreviousCtrl.Focus();
                        }
                        else
                        {
                            //cboMode.Enabled = true;
                            FunctionProcess(btn.Tag.ToString());
                        }
                        break;
                    case ButtonType.BType.Import:
                        FunctionProcess(btn.Tag.ToString());
                        break;
                    case ButtonType.BType.Confirm:
                        FunctionProcess(btn.Tag.ToString());
                        break;
                    case ButtonType.BType.Display:
                        FunctionProcess(btn.Tag.ToString());
                        break;
                    case ButtonType.BType.Memory:
                        FunctionProcess(btn.Tag.ToString());
                        break;
                    case ButtonType.BType.Save:
                        if (cboMode.SelectedValue == null)
                        {
                            if (bbl.ShowMessage("Q101") != DialogResult.Yes)
                            {
                                //cboMode.Enabled = false;
                                if (PreviousCtrl != null)
                                    PreviousCtrl.Focus();
                            }
                            else
                            {
                                //cboMode.Enabled = true;
                                FunctionProcess(btn.Tag.ToString());
                            }
                        }
                        else if (cboMode.SelectedValue.ToString() == "1" || cboMode.SelectedValue.ToString() == "2")
                        {
                            if (ErrorCheck(PanelTitle) && ErrorCheck(this.Controls.Find("PanelDetail", true)[0] as Panel))
                            {
                                if (bbl.ShowMessage("Q101") != DialogResult.Yes)
                                {
                                    //cboMode.Enabled = false;
                                    if (PreviousCtrl != null)
                                        PreviousCtrl.Focus();
                                }
                                else
                                {
                                    //cboMode.Enabled = true;
                                    FunctionProcess(btn.Tag.ToString());
                                }
                            }                           
                        }
                        else if (cboMode.SelectedValue.ToString() == "3")
                        {
                            if (bbl.ShowMessage("Q102") != DialogResult.Yes)
                            {
                                //cboMode.Enabled = false;
                                if (PreviousCtrl != null)
                                    PreviousCtrl.Focus();
                            }
                            else
                            {
                                //cboMode.Enabled = true;
                                FunctionProcess(btn.Tag.ToString());
                            }
                        }
                        break;
                    case ButtonType.BType.Process: 
                        if (bbl.ShowMessage("Q002") != DialogResult.Yes)
                        {
                            if (PreviousCtrl != null)
                                PreviousCtrl.Focus();
                        }
                        else
                            FunctionProcess(btn.Tag.ToString());
                        break;
                    case ButtonType.BType.ExcelExport:
                        if (ErrorCheck(this.Controls.Find("PanelDetail", true)[0] as Panel))
                        {
                            if (bbl.ShowMessage("Q205") != DialogResult.Yes)
                            {
                                if (PreviousCtrl != null)
                                    PreviousCtrl.Focus();
                            }
                            else
                                FunctionProcess(btn.Tag.ToString());
                        }
                        break;
                    case ButtonType.BType.CSVExport:
                        if (ErrorCheck(this.Controls.Find("PanelDetail", true)[0] as Panel))
                        {
                            if (bbl.ShowMessage("Q203") != DialogResult.Yes)
                            {
                                if (PreviousCtrl != null)
                                    PreviousCtrl.Focus();
                            }
                            else
                                FunctionProcess(btn.Tag.ToString());
                        }
                        break;
                }
            }
        }

        public static int index = 0;
        private void SetMode(SButton btn,string selectedvalue)
        {
            if(selectedvalue != cboMode.SelectedValue.ToString())
            {
                if (bbl.ShowMessage("Q005") == DialogResult.Yes)
                {
                    cboMode.SelectedValue = selectedvalue;
                }
                else
                {
                    if (PreviousCtrl != null)
                        PreviousCtrl.Focus();

                    return;
                }
            }
            else
            {
                if (PreviousCtrl != null)
                    PreviousCtrl.Focus();

                return;
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
                case ButtonType.BType.Display:
                    button.Text = buttonText;
                    break;
                case ButtonType.BType.New:
                    CheckButton(programEntity.Insertable, buttonText, button);

                    if (programEntity.Insertable.Equals("0"))
                    {
                        DataTable dt = (DataTable)cboMode.DataSource;
                        DataRow[] row = dt.Select("ID='1'");
                        if(row.Length>0)
                            dt.Rows.Remove(row[0]);
                    }
                    break;
                case ButtonType.BType.Update:
                    CheckButton(programEntity.Updatable, buttonText, button);

                    if (programEntity.Updatable.Equals("0"))
                    {
                        DataTable dt = (DataTable)cboMode.DataSource;
                        DataRow[] row = dt.Select("ID='2'");
                        if (row.Length > 0)
                            dt.Rows.Remove(row[0]);
                    }
                    break;
                case ButtonType.BType.Delete:
                    CheckButton(programEntity.Deletable, buttonText, button);

                    if (programEntity.Deletable.Equals("0"))
                    {
                        DataTable dt = (DataTable)cboMode.DataSource;
                        DataRow[] row = dt.Select("ID='3'");
                        if (row.Length > 0)
                            dt.Rows.Remove(row[0]);
                    }
                    break;
                case ButtonType.BType.Inquiry:
                    CheckButton(programEntity.Inquirable, buttonText, button);

                    if (programEntity.Inquirable.Equals("0"))
                    {
                        DataTable dt = (DataTable)cboMode.DataSource;
                        DataRow[] row = dt.Select("ID='4'");
                        if (row.Length > 0)
                            dt.Rows.Remove(row[0]);
                    }
                    break;
                case ButtonType.BType.Print:
                    CheckButton(programEntity.Printable, buttonText, button);
                    break;
                case ButtonType.BType.Import:
                    CheckButton(programEntity.Importable = "", buttonText, button);
                    break;
                case ButtonType.BType.Confirm:
                    button.Text = buttonText;
                    break;
                case ButtonType.BType.Export:
                    button.Text = buttonText;
                    break;
                case ButtonType.BType.Memory:
                    button.Text = buttonText;
                    break;
                case ButtonType.BType.Process:
                    button.Text = buttonText;
                    break;
                case ButtonType.BType.ExcelExport:
                    button.Text = buttonText;
                    break;
                case ButtonType.BType.CSVExport:
                    button.Text = buttonText;
                    break;
            }

            button.Visible = visible;
        }
        protected Mode GetMode(Mode initMode)
        {
            Mode mode = Mode.Null;

            if (!string.IsNullOrWhiteSpace(BtnF5.Text) && programEntity.Inquirable.Equals("1"))
            {
                mode = Mode.Inquiry;
                if (initMode == mode)
                    return mode;
            }
                if (!string.IsNullOrWhiteSpace(BtnF4.Text) && programEntity.Deletable.Equals("1"))
            {
                mode = Mode.Delete;
                if (initMode == mode)
                    return mode;
            }
                if (!string.IsNullOrWhiteSpace(BtnF3.Text) && programEntity.Updatable.Equals("1"))
            {
                mode = Mode.Update;
                if (initMode == mode)
                    return mode;
            }

            if (!string.IsNullOrWhiteSpace(BtnF2.Text) && programEntity.Insertable.Equals("1"))
            {
                mode = Mode.New;
                if (initMode == mode)
                    return mode;
            }
                        
            return mode;
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
                    PreviousCtrl = this.ActiveControl;
                    SButton btn = this.Controls.Find("Btn" + e.KeyCode.ToString(), true)[0] as SButton;
                    if (e.KeyCode == Keys.F10)
                    {
                        // 何かの処理

                        //F10 はメニューバーをアクティブにする、Windows 標準のショートカットキーです。
                        //このショートカットの動作をさせないように
                        // 既定の処理は実行しない
                        e.Handled = true;
                    }
                    if (e.KeyCode != Keys.F9)
                    {
                        PreviousCtrl = this.ActiveControl;
                        btn.Focus();
                    }
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
                    else if (ActiveControl is SRadio)
                    {
                        SRadio radio = ActiveControl as SRadio;
                        if (!string.IsNullOrWhiteSpace(radio.NextControlName))
                        {
                            Control[] ctlArr = this.Controls.Find(radio.NextControlName, true);
                            if (ctlArr.Length > 0)
                            {
                                radio.NextControl = ctlArr[0];
                            }
                        }
                    }
                    else if (ActiveControl is SCheckBox)
                    {
                        SCheckBox checkbox = ActiveControl as SCheckBox;
                        if (!string.IsNullOrWhiteSpace(checkbox.NextControlName))
                        {
                            Control[] ctlArr = this.Controls.Find(checkbox.NextControlName, true);
                            if (ctlArr.Length > 0)
                            {
                                checkbox.NextControl = ctlArr[0];
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

        protected void RadioPanel_GotFocus(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is RadioButton)
                {
                    RadioButton rdoBtn = ctrl as RadioButton;
                    if (rdoBtn.Checked)
                        rdoBtn.Focus();
                }
            }
        } 

        public StaffEntity GetBaseData()
        {
            StaffEntity obj = new StaffEntity();
            obj.StaffCD = OperatorCD;
            obj.ProgramID = ProgramID;
            obj.PC = PCID;
            return obj;
        }

        public BaseEntity _GetBaseData()
        {
            BaseEntity obj = new BaseEntity();
            obj.OperatorCD = OperatorCD;
            obj.ProgramID = ProgramID;
            obj.PC = PCID;
            obj.LoginDate = LoginDate;
            obj.SPName = sLabel1.Text;
            return obj;
        }

        private void cboMode_SelectedValueChanged(object sender, EventArgs e)
        {
            bool ismode = false;
            if (this.ActiveControl != null && this.ActiveControl.Name.Equals("cboMode"))
                ismode = true;

            if (cboMode.SelectedValue.ToString().Equals("1"))
            {
                if(programEntity.Insertable.Equals("0"))
                {
                    //権限なし
                    return;
                }
                FunctionProcess("2");
            }
            else if (cboMode.SelectedValue.ToString().Equals("2"))
            {
                if (programEntity.Updatable.Equals("0"))
                {
                    //権限なし
                    return;
                }
                FunctionProcess("3");
            }
            else if (cboMode.SelectedValue.ToString().Equals("3"))
            {
                if (programEntity.Deletable.Equals("0"))
                {
                    //権限なし
                    return;
                }
                FunctionProcess("4");
            }
            else if (cboMode.SelectedValue.ToString().Equals("4"))
            {
                if (programEntity.Inquirable.Equals("0"))
                {
                    //権限なし
                    return;
                }
                FunctionProcess("5");
            }
            if (ismode)
                cboMode.Focus();
        }

        protected bool ErrorCheck(Panel panel)
        {
            Dictionary<int, Control> dic = new Dictionary<int, Control>();

            foreach (Control ctrl in panel.Controls)
            {
                if(!(ctrl is Label))
                    dic.Add(ctrl.TabIndex, ctrl);
            }


            foreach (KeyValuePair<int,Control> ctrldic in dic.OrderBy(key => key.Key))
            {
                Control ctrl = ctrldic.Value as Control;

                if ((ctrl is STextBox))
                {
                    STextBox st = ctrl as STextBox;
                    if (st.ErrorCheck())
                        return false;
                }
                if(ctrl is SCombo)
                {
                    SCombo sc = ctrl as SCombo;
                    if (sc.ErrorCheck())
                        return false;
                }
                if (ctrl is SCheckBox)
                {
                    SCheckBox sch = ctrl as SCheckBox;
                    if (sch.ErrorCheck())
                        return false;
                }
                if(ctrl is SGridView)
                {
                    SGridView sgv = ctrl as SGridView;
                    if(sgv.Memory_Row_Count==0 && sgv.ActionType != "F10")
                    {
                        bbl.ShowMessage("E274");
                        return false;
                    }
                }
            }
            return true;
        }

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                const int CS_NOCLOSE = 0x200;

                System.Windows.Forms.CreateParams createParam = base.CreateParams;
                createParam.ClassStyle = createParam.ClassStyle | CS_NOCLOSE;

                return createParam;
            }
        }

        private void BaseForm_MouseLeave(object sender, EventArgs e)
        {

        }
    }
}
