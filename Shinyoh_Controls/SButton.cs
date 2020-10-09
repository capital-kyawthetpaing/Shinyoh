using System.Drawing;
using System.Windows.Forms;

namespace Shinyoh_Controls
{
    public class SButton : Button
    {
        public SButton()
        {
            this.BackColor = ColorTranslator.FromHtml("#BFBFBF");
            this.Font = new Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Size = new Size(116, 42);
            this.Dock = DockStyle.Bottom;
        }
    }
}
