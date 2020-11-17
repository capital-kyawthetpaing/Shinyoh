using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shinyoh_Controls
{
    public class SRadio : RadioButton
    {
        [Browsable(true)]
        [Category("Shinyoh Properties")]
        [Description("NextControlName")]
        [DisplayName("NextControlName")]
        public string NextControlName { get; set; }
        public bool MoveNext { get; set; } = true;
        public Control NextControl { get; set; }

        public SRadio() : base()
        {
            base.AutoSize = false;
            base.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            base.Size = new Size(100, 19);
        }
        protected override bool ShowFocusCues
        {
            get { return true; }
        }
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
    }
}
