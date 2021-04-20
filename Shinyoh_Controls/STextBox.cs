using System;
using System.ComponentModel;
using System.Windows.Forms;
using CKM_CommonFunction;
using BL;
using System.Drawing;
using Entity;
using static Entity.SearchType;
using System.Data;
using System.Runtime.InteropServices;
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
            Japanese = 1,
            JapaneseHalf = 2
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
        public bool IsUseInitializedLayout { get; set; } = true; // PTK
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
        public bool E132Multi;
        public string E132Type;  
        public bool E133;
        public bool E133Multi;
        public string E133Type;
        public bool E135;
        public string E135Type;
        public bool E227;
        public string E227Type;
        public bool E265;
        public string E265Type;
        public bool E266;
        public string E266Type;
        public bool E267;
        public string E267Type;
        public bool E268;
        public string E268Type;
        public bool E159;
        public string E159Type;
        public bool E160;
        public string E165Type;
        public bool E165;
        public bool E166;
        public string E160Type;
        public bool E270;
        public bool E270Multi;
        public string E270Type;
        public bool CYuubin_Juusho;
        public bool E128;

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
        public Control ctrlE132_4;
        public Control ctrlE133_1;
        public Control ctrlE133_2;
        public Control ctrlE133_3;
        public Control ctrlE133_4;
        public Control ctrlE135_1;
        public Control ctrlE135_2;
        public Control ctrlE159_1;
        public Control ctrlE160_1;
        public Control ctrlE160_2;
        public Control ctrlE165_1;
        public Control ctrlE165_2;
        public Control ctrlE166_1;
        public Control ctrlE166_2;
        public Control ctrlE227_1;
        public Control ctrlE227_2;
        public Control ctrlE265_1;
        public Control ctrlE266_1;
        public Control ctrlE267_1;
        public Control ctrlE267_2;
        public Control ctrlE270_1;
        public Control ctrlE270_2;
        public Control ctrlE270_3;
        public Control ctrlE270_4;
        public Control ctrlE128_1;
        public PictureBox ctrlE128_2;


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
            else if (SType == STextBoxType.Time)
            {
                e.Handled = !cf.IsNumberKey(e.KeyChar, AllowMinus);
            }
            //else if (SType == STextBoxType.Date)
            //{
            //    e.Handled = !cf.IsYYYYMMKey(e.KeyChar);
            //}     
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
                if(!ErrorCheck())
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
            else if(DefaultKeyboard == DefKey.JapaneseHalf)
            {
                foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
                {
                    if (lang.LayoutName.Equals("Japanese"))
                    {
                        InputLanguage.CurrentInputLanguage = lang;
                        this.ImeMode = ImeMode.KatakanaHalf;
                        break;
                    }
                }
            }


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
                    string mode = string.Empty;
                    Control[] ctlmode = this.TopLevelControl.Controls.Find("cboMode", true);
                    if (ctlmode.Length > 0)
                    {
                        Control cbo = this.TopLevelControl.Controls.Find("cboMode", true)[0];
                        mode = cbo.Text;
                    }
                    Control[] ctrlArr = this.TopLevelControl.Controls.Find("BtnF9", true);
                    if (DepandOnMode == false || (DepandOnMode == true && mode != "新規"))
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
            base.OnEnter(e);
        }
        protected override void OnLostFocus(EventArgs e)
        {
            //if (this.TopLevelControl != null && (SType == STextBoxType.Normal) || SType == STextBoxType.Number)   // PTK Proceed for haita, KTP's below unfinished one (2021-03-18)
            //{
            //    try
            //    {
            //        (((Shinyoh.BaseForm)(((System.Windows.Forms.Form.ControlCollection)this.TopLevelControl.Controls).Owner as Form)).Controls.Find("BtnF9", true)[0] as Control).Visible = false;
            //    }
            //    catch (Exception ex) //can get catch for in some Codition
            //    {
            //        var msg = ex.Message;
            //    }
            //}
            base.OnLostFocus(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {

            base.OnMouseLeave(e);
        }

        protected override void OnValidated(EventArgs e)
        {
            CheckTime();
            base.OnValidated(e);
        }
        private void CheckTime()
        {
            if (SType == STextBoxType.Time)
            {
                TimeCheck();
            }
        }
        public bool TimeCheck()
        {
            if (!string.IsNullOrWhiteSpace(Text))
            {
                string hour = string.Empty;
                string minutes = string.Empty;
                string seconds = string.Empty;

                string temp = Text;

                temp = temp.Contains(":") ? temp : System.Text.RegularExpressions.Regex.Replace(temp, ".{2}", "$0:");
                temp = temp.TrimEnd(':');

                string[] strtime = temp.Split(':');
                if (strtime.Length > 2)
                {
                    bbl.ShowMessage("E103");
                    Focus();
                    return false;
                }
                else
                {
                    hour = strtime[0].Trim().PadLeft(2, '0');
                    minutes = strtime.Length > 1 ? strtime[1].Trim().PadLeft(2, '0') : "00";
                    seconds = strtime.Length > 2 ? strtime[2].Trim().PadLeft(2, '0') : "00";

                    if (!IsCorrectTime(hour, minutes, seconds))
                    {
                        bbl.ShowMessage("E103");
                        Focus();
                        return false;
                    }

                    Text = hour + ":" + minutes;// + ":" + seconds;
                }
            }

            return true;
        }
        private bool IsCorrectTime(string hour, string minutes, string seconds)
        {
            if (Convert.ToInt32(hour) > 23 || Convert.ToInt32(minutes) > 59 || Convert.ToInt32(seconds) > 59)
                return false;
            return true;
        }

        protected override void OnLeave(EventArgs e)
        {
           
            if (SType == STextBoxType.Price)
            {
                string value = Text.Replace(",", "");
                //int num;
                long num;
                int a = Convert.ToInt32(this.DecimalPlace);

                if (Int64.TryParse(value, out num))
                {
                    if (!Text.Equals("0"))
                    {
                        if (a != 0)
                        {
                            Text = string.Format("{0:#,#.0}", num); ;
                            while (Text.Split('.')[1].Length < a)
                            {
                                Text = Text + "0";
                            }
                        }
                        else
                            Text = string.Format("{0:#,#}", num);
                    }
                }
                else if (string.IsNullOrWhiteSpace(value))
                {
                    if (a != 0)
                    {
                        Text = "0.0";
                        while (Text.Split('.')[1].Length < a)
                        {
                            Text = Text + "0";
                        }
                    }
                    else
                        Text = "0";
                }
                else
                {
                    Text = string.Format("{0:#,#}", value);

                    string[] p = Text.Split('.');
                    if (a != p[1].Length)
                    {
                        if (Int64.TryParse(p[0].ToString(), out num))
                        {
                            if (p[1].Length < a)
                            {
                                if(!p[0].ToString().Equals("0"))
                                    Text = string.Format("{0:#,#}", num) + "." + p[1].ToString();
                                else
                                    Text = num + "." + p[1].ToString();
                                while (Text.Split('.')[1].Length < a)
                                {
                                    Text = Text + "0";
                                }
                            }
                            else
                            {
                                if (!p[0].ToString().Equals("0"))
                                    Text = string.Format("{0:#,#}", num) + "." + p[1].Substring(0, a);
                                else
                                    Text = num + "." + p[1].Substring(0, a);
                            }
                        }
                        else
                        {
                            bbl.ShowMessage("E118");
                            this.Focus();
                        }
                    }
                    else
                    {
                        Text = p[0].ToString();
                        if (Int64.TryParse(Text, out num))
                        {
                            if (!Text.Equals("0"))
                                Text = string.Format("{0:#,#}", num);
                            this.Text = Text + "." + p[1].ToString();
                        }
                    }
                }
            }


           
            //KTP commented because of BtnF9 Click doesn't work
            //if (this.TopLevelControl != null)
            //{
            //    Control[] ctrlArr = this.TopLevelControl.Controls.Find("BtnF9", true);
            //    if (ctrlArr.Length > 0)
            //    {
            //        Control btnF9 = ctrlArr[0];
            //        if (btnF9 != null)
            //            btnF9.Visible = false;
            //    }
            //}

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
            if (IsUseInitializedLayout)
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
        public void E128Check(bool value, Control ctrl1, PictureBox ctrl2)
        {
            E128 = value;
            ctrlE128_1 = ctrl1;
            ctrlE128_2 = ctrl2;
        }
        public void E132Check(bool value,string type,Control ctrl1,Control ctrl2,Control ctrl3)
        {
            E132 = value;
            E132Type = type;
            ctrlE132_1 = ctrl1;
            ctrlE132_2 = ctrl2;
            ctrlE132_3 = ctrl3;
        }
        public void E132MultiCheck(bool value, string type, Control ctrl1, Control ctrl2, Control ctrl3, Control ctrl4)
        {
            E132Multi = value;
            E132Type = type;
            ctrlE132_1 = ctrl1;
            ctrlE132_2 = ctrl2;
            ctrlE132_3 = ctrl3;
            ctrlE132_4 = ctrl4;
        }
        public void E133Check(bool value, string type, Control ctrl1, Control ctrl2, Control ctrl3)
        {
            E133 = value;
            E133Type = type;
            ctrlE133_1 = ctrl1;
            ctrlE133_2 = ctrl2;
            ctrlE133_3 = ctrl3;
        }
        public void E133MultiCheck(bool value, string type, Control ctrl1, Control ctrl2, Control ctrl3, Control ctrl4)
        {
            E133Multi = value;
            E133Type = type;
            ctrlE133_1 = ctrl1;
            ctrlE133_2 = ctrl2;
            ctrlE133_3 = ctrl3;
            ctrlE133_4 = ctrl4;
        }
        public void E135Check(bool value, string type, Control ctrl1, Control ctrl2)
        {
            E135 = value;
            E135Type = type;
            ctrlE135_1 = ctrl1;
            ctrlE135_2 = ctrl2;
        }
        public void E159Check(bool value, string type, Control ctrl1)
        {
            E159 = value;
            E159Type = type;
            ctrlE159_1 = ctrl1;

        }
        public void E160Check(bool value,string type, Control ctrl1, Control ctrl2)
        {
            E160 = value;
            E160Type = type;
            ctrlE160_1 = ctrl1;
            ctrlE160_2 = ctrl2;
        }
        public void E165Check(bool value, string type, Control ctrl1, Control ctrl2)
        {
            E165 = value;
            E165Type = type;
            ctrlE165_1 = ctrl1;
            ctrlE165_2 = ctrl2;
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
        public void E265Check(bool value, string type, Control ctrl1)
        {
            E265 = value;
            E265Type = type;
            ctrlE265_1 = ctrl1;
        }
        public void E266Check(bool value, string type, Control ctrl1)
        {
            E266 = value;
            E266Type = type;
            ctrlE266_1 = ctrl1;
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
        public void E270Check(bool value, string type, Control ctrl1, Control ctrl2, [Optional]Control ctrl3)
        {
            E270 = value;
            E270Type = type;
            ctrlE270_1 = ctrl1;
            ctrlE270_2 = ctrl2;
            ctrlE270_3 = ctrl3;
        }
        public void E270MultiCheck(bool value, string type, Control ctrl1, Control ctrl2, [Optional]Control ctrl3, Control ctrl4)
        {
            E270Multi = value;
            E270Type = type;
            ctrlE270_1 = ctrl1;
            ctrlE270_2 = ctrl2;
            ctrlE270_3 = ctrl3;
            ctrlE270_4 = ctrl4;
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
