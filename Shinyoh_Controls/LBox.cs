using System.Windows.Forms;
using System.Drawing;

namespace Shinyoh_Controls
{
    public class LBox : Label
    {
        public LBox()
        {
            this.BackColor = Color.Yellow;
            this.AutoSize = false;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
