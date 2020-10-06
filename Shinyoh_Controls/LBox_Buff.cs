using System.Windows.Forms;
using System.Drawing;
namespace Shinyoh_Controls
{
    public class LBox_Buff : Label
    {
        public LBox_Buff()
        {
            BackColor = Color.FromArgb(255, 230, 153);
            AutoSize = false;
            TextAlign = ContentAlignment.MiddleCenter;
            BorderStyle = BorderStyle.None;
            FlatStyle = FlatStyle.Flat;
            Font = new Font(this.Font, FontStyle.Bold);
            MinimumSize = new Size(100, 25);

        }
    }
}
