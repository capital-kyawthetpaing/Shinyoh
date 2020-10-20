using System.Windows.Forms;
using BL;

namespace Shinyoh_Controls
{
    public class ErrorCheck
    {
        public void ShowErrorMessage(string messageID)
        {
            BaseBL bbl = new BaseBL();
            bbl.ShowMessage(messageID);
        }
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
                if (string.IsNullOrWhiteSpace(sTextBox.Text))
                {
                    ShowErrorMessage("E102");
                    sTextBox.Focus();
                    return "1";
                }                    
            }

            if(sTextBox.IsZipCheck)
            {
                if(string.IsNullOrWhiteSpace(sTextBox.ctrlZip1.Text) && !string.IsNullOrWhiteSpace(sTextBox.ctrlZip2.Text))
                {
                    ShowErrorMessage("E102");
                    sTextBox.ctrlZip1.Focus();
                    return "1";
                }
                else if(!string.IsNullOrWhiteSpace(sTextBox.ctrlZip1.Text) && string.IsNullOrWhiteSpace(sTextBox.ctrlZip2.Text))
                {
                    ShowErrorMessage("E102");
                    sTextBox.ctrlZip2.Focus();
                    return "1";
                }
            }

            return "0";
        }
    }
}
