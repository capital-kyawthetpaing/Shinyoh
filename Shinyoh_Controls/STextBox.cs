using System;
using System.ComponentModel;
using System.Windows.Forms;
using CKM_CommonFunction;
using BL;
using System.Drawing;

namespace Shinyoh_Controls
{
    public class STextBox : TextBox
    {
        CommonFunction cf;
        BaseBL bbl;
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
        private bool IsRequire { get; set; } = false;

        [Browsable(true)]
        [Category("Shinyoh Properties")]
        [Description("NextControlName")]
        [DisplayName("NextControlName")]
        private string NextControlName { get; set; }

        //Constructor
        public STextBox()
        {
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            cf = new CommonFunction();
            bbl = new BaseBL();

            base.MinimumSize = new Size(100, 25);
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
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((IsRequire && string.IsNullOrWhiteSpace(Text)))
                {
                    ShowErrorMessage("E102");
                }

                if(cf.IsByteLengthOver(MaxLength,Text))
                {
                    MessageBox.Show("入力された文字が長すぎます", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            base.OnKeyDown(e);
        }

        private void ShowErrorMessage(string messageID)
        {
            bbl.ShowMessage(messageID);
            this.SelectionStart = 0;
            this.SelectionLength = this.Text.Length;
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            base.AutoSize = false;
            base.Height = 25;
        }
    }
}
