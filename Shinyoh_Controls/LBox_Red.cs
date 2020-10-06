using System.Windows.Forms;
using System.Drawing;

namespace Shinyoh_Controls
{
   public  class LBox_Red : Label
    {
        public LBox_Red()
        {
            BackColor = Color.Red;
            AutoSize = false;
            TextAlign = ContentAlignment.MiddleCenter;
            BorderStyle = BorderStyle.None;
            FlatStyle = FlatStyle.Flat;
            ForeColor = Color.White;
            Font = new Font(this.Font, FontStyle.Bold);
            MinimumSize = new Size(100, 25);
        }
    }
}
