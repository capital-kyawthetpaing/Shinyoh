using System.Windows.Forms;
using System.Drawing;

namespace Shinyoh_Controls
{
   public  class LBox_Buff : Label
    {
        public LBox_Buff()
        {
            BackColor = Color.FromArgb(255, 230, 153);
            AutoSize = false;
            TextAlign = ContentAlignment.MiddleCenter;
            BorderStyle = BorderStyle.None;
            MinimumSize = new Size(100, 25);
            FlatStyle = FlatStyle.Flat;
            Font = new Font(Label.DefaultFont, FontStyle.Bold);
        }
    }
}
