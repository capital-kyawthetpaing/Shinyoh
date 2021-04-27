using CKM_CommonFunction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shinyoh_Controls
{
    public class SCheckBox : CheckBox
    {
        CommonFunction cf;
        ErrorCheck errchk;

        [Browsable(true)]
        [Category("Shinyoh Properties")]
        [Description("NextControlName")]
        [DisplayName("NextControlName")]
        public string NextControlName { get; set; }
        public bool MoveNext { get; set; } = true;
        public Control NextControl { get; set; }

        //Constructor
        public SCheckBox()
        {
            this.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular);
            cf = new CommonFunction();
            errchk = new ErrorCheck();
        }
        public bool IsErrorOccurs { get; set; }
        public DataTable IsDatatableOccurs { get; set; }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (NextControl != null && !ErrorCheck())
                    NextControl.Focus();
                base.OnKeyDown(e);
            }
            base.OnKeyDown(e);
        }
        protected override void OnEnter(EventArgs e)
        {
            this.BackColor = Color.Cyan;
            base.OnEnter(e);
        }
        protected override void OnLeave(EventArgs e)
        {
            if (this.Parent.Name == "PanelTitle")
                this.BackColor = Color.FromArgb(0, 176, 240);
            else this.BackColor = SystemColors.Menu;
            base.OnLeave(e);
        }
        protected override void OnEnabledChanged(EventArgs e)
        {
            if (!Enabled)
                this.BackColor = Color.FromArgb(255, 230, 153);
            else
            {
                if (this.Parent.Name == "PanelTitle")
                    this.BackColor = Color.FromArgb(0, 176, 240);
                else this.BackColor = SystemColors.Control;
            }
            base.OnEnabledChanged(e);
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            base.AutoSize = false;
            base.Height = 19;
        }

        public bool E188;

        public SCheckBox ctrlE188_1;
        public SCheckBox ctrlE188_2;
        public string E188_ErrText;

        public void E188Check(bool value, SCheckBox ctrl1, SCheckBox ctrl2, string errText)
        {
            E188 = value;
            ctrlE188_1 = ctrl1;
            ctrlE188_2 = ctrl2;
            E188_ErrText= errText;
        }

        public bool ErrorCheck()
        {
            (bool, DataTable) r_value = errchk.Check(this);
            IsErrorOccurs = r_value.Item1;
            IsDatatableOccurs = r_value.Item2;
            if (!IsErrorOccurs)
            {
                Control nextControl = this.TopLevelControl.Controls.Find(NextControlName, true)[0];
                nextControl.Focus();
            }
            return IsErrorOccurs;
        }

        protected override void OnGotFocus(EventArgs e)
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
            base.OnGotFocus(e);
        }
    }
}
