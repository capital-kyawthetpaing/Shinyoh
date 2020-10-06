using System.Windows.Forms;
using System.Drawing;

namespace Shinyoh_Controls
{
    public class LBox_Red : Label
    {
        public LBox_Red()
        {
            BackColor = Color.Red;
            AutoSize = false;
            TextAlign = ContentAlignment.MiddleCenter;
            BorderStyle = BorderStyle.None;
            MinimumSize = new Size(100, 25);
            FlatStyle = FlatStyle.Flat;
            Font = new Font(Label.DefaultFont, FontStyle.Bold);
            ForeColor = Color.White;
        }
    }
}
