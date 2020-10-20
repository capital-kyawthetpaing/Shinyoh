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
            if(sTextBox.E102)
            {
                if (string.IsNullOrWhiteSpace(sTextBox.Text))
                {
                    ShowErrorMessage("E102");
                    sTextBox.Focus();
                    return "1";
                }                    
            }

            if(sTextBox.E102Multi)
            {
                if(string.IsNullOrWhiteSpace(sTextBox.ctrlE102_1.Text) && !string.IsNullOrWhiteSpace(sTextBox.ctrlE102_2.Text))
                {
                    ShowErrorMessage("E102");
                    sTextBox.ctrlE102_1.Focus();
                    return "1";
                }
                else if(!string.IsNullOrWhiteSpace(sTextBox.ctrlE102_1.Text) && string.IsNullOrWhiteSpace(sTextBox.ctrlE102_2.Text))
                {
                    ShowErrorMessage("E102");
                    sTextBox.ctrlE102_2.Focus();
                    return "1";
                }
            }

            return "0";
        }
    }
}
