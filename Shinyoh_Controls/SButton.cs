using System.Drawing;
using System.Windows.Forms;
using Entity;

namespace Shinyoh_Controls
{
    public class SButton : Button
    {
        public ButtonType.BType ButtonType { get; set; }
        public SButton()
        {
            this.BackColor = ColorTranslator.FromHtml("#BFBFBF");
            this.Font = new Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.FlatStyle = FlatStyle.Popup;
        }
    }
}
