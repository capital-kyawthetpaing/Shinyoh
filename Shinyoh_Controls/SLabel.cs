using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Shinyoh_Controls
{
    public class SLabel : Label
    {
        public SLabel():base()
        {
            BackColor = Color.FromArgb(255, 230, 153);
            base.AutoSize = false;
            TextAlign = ContentAlignment.MiddleCenter;
            BorderStyle = BorderStyle.FixedSingle;
            FlatStyle = FlatStyle.Flat;
            base.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            base.Size = new Size(100, 19);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            base.AutoSize = false;
            base.Height = 19;
        }
    }
}
