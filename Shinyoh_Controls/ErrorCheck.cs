using System.Windows.Forms;

namespace Shinyoh_Controls
{
    public class ErrorCheck
    {
        public string Check(Control ctrl)
        {
            if(ctrl is STextBox)
            {
                STextBox sTextBox = ctrl as STextBox;
                return TextBoxErrorCheck(sTextBox);
            }

            return "0";
        }

        private string TextBoxErrorCheck(STextBox sTextBox)
        {
            if(sTextBox.IsRequireCheck)
            {
                if (!string.IsNullOrWhiteSpace(sTextBox.Text))
                    return "E102";
            }

            if(sTextBox.IsZipCheck)
            {
                if(string.IsNullOrWhiteSpace(sTextBox.ctrlZip1.Text) && !string.IsNullOrWhiteSpace(sTextBox.ctrlZip2.Text))
                {
                    sTextBox.ctrlZip1.Focus();
                    return "E102";
                }
                else if(!string.IsNullOrWhiteSpace(sTextBox.ctrlZip1.Text) && string.IsNullOrWhiteSpace(sTextBox.ctrlZip2.Text))
                {
                    sTextBox.ctrlZip2.Focus();
                    return "E102";
                }
            }

            return "0";
        }
    }
}
