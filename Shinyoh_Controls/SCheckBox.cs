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
        //ErrorCheck errchk;

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
        }
        public bool IsErrorOccurs { get; set; }
        public DataTable IsDatatableOccurs { get; set; }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (NextControl != null)
                    NextControl.Focus();
                base.OnKeyDown(e);
            }
        }
        protected override void OnEnter(EventArgs e)
        {
            this.BackColor = Color.Cyan;
            base.OnEnter(e);
        }
        protected override void OnLeave(EventArgs e)
        {
            this.BackColor = SystemColors.Menu;
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

        //public bool ErrorCheck()
        //{
        //    (bool, DataTable) r_value = errchk.Check(this);
        //    IsErrorOccurs = r_value.Item1;
        //    IsDatatableOccurs = r_value.Item2;
        //    if (!IsErrorOccurs)
        //    {
        //        Control nextControl = this.TopLevelControl.Controls.Find(NextControlName, true)[0];
        //        nextControl.Focus();
        //    }
        //    return IsErrorOccurs;
        //}
    }
}
