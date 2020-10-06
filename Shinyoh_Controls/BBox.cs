using System.Windows.Forms;
using System.Drawing;

namespace Shinyoh_Controls {
    public class BBox : Button {
        public BBox()
        {
            this.BackColor = ColorTranslator.FromHtml("#c0c0c0");
            this.Font  = new Font("Microsoft Sans Serif", 15);
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Dock = DockStyle.Bottom;

        }
    }
}
