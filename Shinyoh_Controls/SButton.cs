using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entity;

namespace Shinyoh_Controls
{
    public class SButton : Button
    {
        public ButtonType.BType ButtonType { get; set; }
        public Control NextControl { get; set; }
        [Browsable(true)]
        [Category("Shinyoh Properties")]
        [Description("NextControlName")]
        [DisplayName("NextControlName")]
        public string NextControlName { get; set; }
        public SButton()
        {
            this.BackColor = ColorTranslator.FromHtml("#BFBFBF");
            this.Font = new Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.FlatStyle = FlatStyle.Popup;
        }
        protected override void OnClick(EventArgs e)
        {
            if (NextControlName != null)
            {
                Control[] ctrlArr = this.TopLevelControl.Controls.Find(NextControlName,true);
                Control ctrl = null;
                if(ctrlArr.Length > 0)
                {
                    ctrl = ctrlArr[0];
                }
                else
                {
                    ctrl = this.Controls[NextControlName];
                }
                ctrl.Focus();
            }
            base.OnClick(e);
        }
    }
}
