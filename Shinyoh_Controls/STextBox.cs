using System;
using System.ComponentModel;
using System.Windows.Forms;
using CKM_CommonFunction;
using BL;
using System.Drawing;
using Entity;
using static Entity.SearchType;
using System.Data;

namespace Shinyoh_Controls
{
    public class STextBox : TextBox
    {
        CommonFunction cf;
        BaseBL bbl;
        ErrorCheck errchk;
        public enum STextBoxType
        {
            Normal = 0,
            Date = 1,//check dateformat
            Price = 2,//check price format
            Number = 3,//check integer only
            Time = 4,//Time format
            YearMonth = 5 //2019/01 format
        }

        private STextBoxType SType { get; set; }
        [Browsable(true)]
        [Category("Shinyoh Properties")]
        [Description("Select Control Type")]
        [DisplayName("Control Type")]
        public STextBoxType TextBoxType
        {
            get { return SType; }
            set
            {
                SType = value;
            }
        }

        [Browsable(true)]
        [Category("Shinyoh Properties")]
        [Description("Select Default Keyboard")]
        [DisplayName("Default Language")]
        public DefKey DefaultKeyboard { get; set; } = 0;
        public enum DefKey
        {
            English = 0,
            Japanese = 1
        }

        [Browsable(true)]
        [Category("Shinyoh Properties")]
        [Description("Max Length After Decimal Point")]
        [DisplayName("Decimal Place")]
        public int DecimalPlace { get; set; } = 0;

        [Browsable(true)]
        [Category("Shinyoh Properties")]
        [Description("Max Length Before Decimal Point")]
        [DisplayName("Integer Part")]
        public int IntegerPart { get; set; } = 0;

        [Browsable(true)]
        [Category("Shinyoh Properties")]
        [Description("Allow Minus")]
        [DisplayName("AllowMinus")]
        public bool AllowMinus { get; set; } = false;

        [Browsable(true)]
        [Category("Shinyoh Properties")]
        [Description("IsRequire")]
        [DisplayName("IsRequire")]
        public bool IsRequire { get; set; } = false;

        [Browsable(true)]
        [Category("Shinyoh Properties")]
        [Description("SearchType")]
        [DisplayName("SearchType")]
        public ScType SearchType { get; set; }

        [Browsable(true)]
        [Category("Shinyoh Properties")]
        [Description("DepandOnMode")]
        [DisplayName("DepandOnMode")]
        public bool DepandOnMode { get; set; } = true;

        [Browsable(true)]
        [Category("Shinyoh Properties")]
        [Description("NextControlName")]
        [DisplayName("NextControlName")]
        public string NextControlName { get; set; }
        public bool MoveNext { get; set; } = true;
        public Control NextControl { get; set; } 

        public bool IsErrorOccurs { get; set; }
        public DataTable IsDatatableOccurs { get; set; }

        public bool E101;
        public string E101Type;
        public bool E102;
        public string E102Type;
        public bool E102Multi;
        public bool E103;
        public bool E104;
        public bool E106;
        public bool E115;
        public string E115Type;
        public bool E132;
        public string E132Type;  
        public bool E133;
        public string E133Type;
        public bool E135;
        public string E135Type;
        public bool E227;
        public string E227Type;
        public bool E267;
        public string E267Type;
        public bool E268;
        public string E268Type;
        public bool E160;
        public bool E166;
        public string E160Type;
        public bool E270;
        public string E270Type;
        public bool CYuubin_Juusho;

        public Control ctrlE101_1;
        public Control ctrlE101_2;
        public Control ctrlE101_3;
        public Control ctrlE102_1;
        public Control ctrlE102_2;
        public Control ctrlE104_1;
        public Control ctrlE104_2;
        public Control ctrlE268_1;
        public Control ctrlE268_2;
        public Control ctrlE106_1;
        public Control ctrlE106_2;
        public Control ctrlE115_1;
        public Control ctrlE132_1;
        public Control ctrlE132_2;
        public Control ctrlE132_3;
        public Control ctrlE133_1;
        public Control ctrlE133_2;
        public Control ctrlE133_3;
        public Control ctrlE135_1;
        public Control ctrlE135_2;
        public Control ctrlE160_1;
        public Control ctrlE160_2;
        public Control ctrlE166_1;
        public Control ctrlE166_2;
        public Control ctrlE227_1;
        public Control ctrlE227_2;
        public Control ctrlE267_1;
        public Control ctrlE267_2;
        public Control ctrlE270_1;
        public Control ctrlE270_2;

        public Control ctrl1Yuubin_Juusho;
        public Control ctrl2Yuubin_Juusho;
        public string check1Yuubin_Juusho;
        public string check2Yuubin_Juusho;

        public SCombo ctrl_combo;

        //Constructor
        public STextBox()
        {
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular);
            cf = new CommonFunction();
            bbl = new BaseBL();
            errchk = new ErrorCheck();

            base.MinimumSize = new Size(100, 19);
        }

        public override bool AutoSize 
        { 
            get => base.AutoSize; set => base.AutoSize = value; 
        }

        //restrict key
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (SType == STextBoxType.Price)
            {
                e.Handled = !cf.IsPriceKey(e.KeyChar, AllowMinus);
            }
            else if (SType == STextBoxType.Number)
            {
                e.Handled = !cf.IsNumberKey(e.KeyChar, AllowMinus);
            }
            else if (SType == STextBoxType.YearMonth)
            {
                e.Handled = !cf.IsYYYYMMKey(e.KeyChar);
            }
            else if (SType == STextBoxType.Date)
            {
                e.Handled = !cf.IsYYYYMMKey(e.KeyChar);
            }
            else
            {
                e.Handled = false;
            }
            base.OnKeyPress(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               ErrorCheck();
               base.OnKeyDown(e);
            }
        }

        public bool ErrorCheck()
        {
            (bool, DataTable) r_value = errchk.Check(this);
            IsErrorOccurs = r_value.Item1;
            IsDatatableOccurs = r_value.Item2;
            if (!IsErrorOccurs)
            {
                if (NextControl != null)
                    NextControl.Focus();
            }
            if (cf.IsByteLengthOver(MaxLength, Text))
            {
                IsErrorOccurs = true;
                MessageBox.Show("入力された文字が長すぎます", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Focus();
            }
            return IsErrorOccurs;
        }


        protected override void OnGotFocus(EventArgs e)
        {
            if (SearchType == ScType.None)
            {
                if (this.TopLevelControl != null)
                {
                    Control[] ctrlArr = this.TopLevelControl.Controls.Find("BtnF9", true);
                    if (ctrlArr.Length > 0)
                    {
                        Control btnF9 = ctrlArr[0];
                        if (btnF9 != null)
                            btnF9.Visible = false;
                    }
                }
            }
            else
            {
                if (this.TopLevelControl != null)
                {
                    Control cbo = this.TopLevelControl.Controls.Find("cboMode", true)[0];
                    Control[] ctrlArr = this.TopLevelControl.Controls.Find("BtnF9", true);
                    if (DepandOnMode == false || (DepandOnMode == true && cbo.Text != "新規"))
                    {
                        
                        if (ctrlArr.Length > 0)
                        {
                            Control btnF9 = ctrlArr[0];
                            if (btnF9 != null)
                                btnF9.Visible = true;
                        }
                    }
                    else
                    {
                        if (ctrlArr.Length > 0)
                        {
                            Control btnF9 = ctrlArr[0];
                            if (btnF9 != null)
                                btnF9.Visible = false;
                        }
                    }
                }
            }
            base.OnGotFocus(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            this.BackColor = Color.Cyan;
            if(DefaultKeyboard == DefKey.Japanese)
            {
                foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
                {
                    if (lang.LayoutName.Equals("Japanese"))
                    {
                        InputLanguage.CurrentInputLanguage = lang;
                        this.ImeMode = ImeMode.Hiragana;
                        break;
                    }
                }
            }
            base.OnEnter(e);
        }
        protected override void OnLeave(EventArgs e)
        {
            this.BackColor = Color.White;
            base.OnLeave(e);
        }
        protected override void OnEnabledChanged(EventArgs e)
        {
            if (!Enabled)
                this.BackColor = Color.FromArgb(255, 230, 153);
            else
                this.BackColor = SystemColors.Window;

            base.OnEnabledChanged(e);
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            base.AutoSize = false;
            base.Height = 19;
        }
        public void E101Check(bool value, string type, Control ctrl1, Control ctrl2, Control ctrl3)
        {
            E101 = value;
            E101Type = type;
            ctrlE101_1 = ctrl1;
            ctrlE101_2 = ctrl2;
            ctrlE101_3 = ctrl3;
        }
        public void E102Check(bool value)
        {
            E102  = value;
        }
        public void E102MultiCheck(bool value,Control ctrl1,Control ctrl2)
        {
            E102Multi = value;
            ctrlE102_1 = ctrl1;
            ctrlE102_2 = ctrl2;
        }
        public void E103Check(bool value)
        {
            E103 = value;
        }
        public void E104Check(bool value, Control ctrl1, Control ctrl2)
        {
            E104 = value;
            ctrlE104_1 = ctrl1;
            ctrlE104_2 = ctrl2;
        }
       
        public void E106Check(bool value, Control ctrl1, Control ctrl2)
        {
            E106 = value;
            ctrlE106_1 = ctrl1;
            ctrlE106_2 = ctrl2;
        }
        public void E115Check(bool value, string type, Control ctrl1)
        {
            E115 = value;
            E115Type = type;
            ctrlE115_1 = ctrl1;
        }
        public void E132Check(bool value,string type,Control ctrl1,Control ctrl2,Control ctrl3)
        {
            E132 = value;
            E132Type = type;
            ctrlE132_1 = ctrl1;
            ctrlE132_2 = ctrl2;
            ctrlE132_3 = ctrl3;
        }
        public void E133Check(bool value, string type, Control ctrl1, Control ctrl2, Control ctrl3)
        {
            E133 = value;
            E133Type = type;
            ctrlE133_1 = ctrl1;
            ctrlE133_2 = ctrl2;
            ctrlE133_3 = ctrl3;
        }
        public void E135Check(bool value, string type, Control ctrl1, Control ctrl2)
        {
            E135 = value;
            E135Type = type;
            ctrlE135_1 = ctrl1;
            ctrlE135_2 = ctrl2;
        }
        public void E160Check(bool value,string type, Control ctrl1, Control ctrl2)
        {
            E160 = value;
            E160Type = type;
            ctrlE160_1 = ctrl1;
            ctrlE160_2 = ctrl2;
        }
        public void E166Check(bool value,Control ctrl1,Control ctrl2)
        {
            E166 = value;
            ctrlE166_1 = ctrl1;
            ctrlE166_2 = ctrl2;
        }
        public void E227Check(bool value, string type, Control ctrl1,Control ctrl2)
        {
            E227 = value;
            E227Type = type;
            ctrlE227_1 = ctrl1;
            ctrlE227_2 = ctrl2;
        }
        public void E267Check(bool value, string type, Control ctrl1,Control ctrl2)
        {
            E267 = value;
            E267Type = type;
            ctrlE267_1 = ctrl1;
            ctrlE267_2 = ctrl2;
        }
        public void E268Check(bool value, string type, Control ctrl1, Control ctrl2)
        {
            E268 = value;
            E268Type = type;
            ctrlE268_1 = ctrl1;
            ctrlE268_2 = ctrl2;
        }
        public void E270Check(bool value, string type, Control ctrl1, Control ctrl2)
        {
            E270 = value;
            E270Type = type;
            ctrlE270_1 = ctrl1;
            ctrlE270_2 = ctrl2;
        }
        
        public void Yuubin_Juusho(bool value,Control ctrl1, Control ctrl2,string check_Yuu1,string check_Yuu2)
        {
            CYuubin_Juusho = value;
            ctrl1Yuubin_Juusho = ctrl1;
            ctrl2Yuubin_Juusho = ctrl2;
            check1Yuubin_Juusho = check_Yuu1;
            check2Yuubin_Juusho = check_Yuu2;
        }
    }
}
