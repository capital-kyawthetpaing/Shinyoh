using System;
using System.ComponentModel;
using System.Windows.Forms;
using CKM_CommonFunction;
using BL;
using System.Drawing;
using Entity;
using static Entity.SearchType;

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
        [Description("NextControlName")]
        [DisplayName("NextControlName")]
        public string NextControlName { get; set; }
        public bool MoveNext { get; set; } = true;
        public Control NextControl { get; set; }

        public bool IsErrorOccurs { get; set; }

        public bool E102;
        public bool E102Multi;
        public bool E166;
        public bool E132;
        public string E132Type;
        public bool E101;
        public string E101Type;
        //Nwe Mar Win
        public bool E103;//(2020-10-22)
        public bool E133;//(2020-10-23)
        public string E133Type;
        public bool E104;

        public Control ctrlE102_1;
        public Control ctrlE102_2;
        public Control ctrlE166_1;
        public Control ctrlE166_2;
        public Control ctrlE132_1;
        public Control ctrlE132_2;
        public Control ctrlE132_3;
        public Control ctrlE101_1;
        public Control ctrlE101_2;
        public Control ctrlE101_3;
        //NMW (2020-10-23)
        public Control ctrlE133_1;
        public Control ctrlE133_2;
        public Control ctrlE133_3;
        public Control ctrlE104_1;
        public Control ctrlE104_2;

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
                IsErrorOccurs = errchk.Check(this);

                if(!IsErrorOccurs)
                {
                    if (NextControl != null)
                        NextControl.Focus();
                }
                if(cf.IsByteLengthOver(MaxLength,Text))
                {
                    MessageBox.Show("入力された文字が長すぎます", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                base.OnKeyDown(e);
            }
        }
        
        protected override void OnGotFocus(EventArgs e)
        {
            if (SearchType == ScType.None)
            {
                Control btnF9 = this.TopLevelControl.Controls.Find("BtnF9", true)[0];
                btnF9.Visible = false;
            }
            else
            {
                Control btnF9 = this.TopLevelControl.Controls.Find("BtnF9", true)[0];
                btnF9.Visible = true;
            }

            base.OnGotFocus(e);
        }
        protected override void OnEnter(EventArgs e)
        {
            this.BackColor = Color.Cyan;
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
        public void E132Check(bool value,string type,Control ctrl1,Control ctrl2,Control ctrl3)
        {
            E132 = value;
            E132Type = type;
            ctrlE132_1 = ctrl1;
            ctrlE132_2 = ctrl2;
            ctrlE132_3 = ctrl3;
        }
        public void E101Check(bool value, string type, Control ctrl1, Control ctrl2, Control ctrl3)
        {
            E101 = value;
            E101Type = type;
            ctrlE101_1 = ctrl1;
            ctrlE101_2 = ctrl2;
            ctrlE101_3 = ctrl3;
        }
        public void E166Check(bool value,Control ctrl1,Control ctrl2)
        {
            E166 = value;
            ctrlE166_1 = ctrl1;
            ctrlE166_2 = ctrl2;
        }
        //NMW(2020-10-22)
        public void E103Check(bool value)
        {
            E103 = value;
        }
        //NMW(2020-10-23)
        public void E133Check(bool value, string type, Control ctrl1, Control ctrl2, Control ctrl3)
        {
            E133 = value;
            E133Type = type;
            ctrlE133_1 = ctrl1;
            ctrlE133_2 = ctrl2;
            ctrlE133_3 = ctrl3;
        }
        public void E104Check(bool value, Control ctrl1, Control ctrl2)
        {
            E104 = value;
            ctrlE104_1 = ctrl1;
            ctrlE104_2 = ctrl2;
            
        }
    }
}
