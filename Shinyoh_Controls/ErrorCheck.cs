using System.Windows.Forms;
using BL;
using Entity;

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

            if(sTextBox.E166)
            {
                if (!sTextBox.ctrlE166_1.Text.Equals(sTextBox.ctrlE166_2.Text))
                {
                    ShowErrorMessage("E166");
                    sTextBox.Focus();
                    return "1";
                }
            }

            if (sTextBox.E132)
            {
                string result=string.Empty;
                switch (sTextBox.E132Type)
                {
                    case "souko":
                        SoukoBL bl = new SoukoBL();
                        SoukoEntity soukoEntity = new SoukoEntity();
                        soukoEntity.SoukoCD = sTextBox.Text;
                        soukoEntity= bl.Souko_Select(soukoEntity);
                        result= soukoEntity.MessageID;
                        break;
                }
                if (result.Equals("E132"))
                {
                    ShowErrorMessage("E132");
                    sTextBox.Focus();
                    return "1";
                }
            }
            if (sTextBox.E101)
            {
                string result = string.Empty;
                switch (sTextBox.E101Type)
                {
                    case "copySouko":
                        SoukoBL bl = new SoukoBL();
                        SoukoEntity soukoEntity = new SoukoEntity();
                        soukoEntity.SoukoCD = sTextBox.Text;
                        soukoEntity = bl.Souko_Select(soukoEntity);
                        result = soukoEntity.MessageID;
                        break;
                }
                if (result.Equals("E101"))
                {
                    if (string.IsNullOrWhiteSpace(sTextBox.ctrlE101_1.Text))
                    {
                        sTextBox.ctrlE101_1.Focus();
                    }
                    else
                    {
                        ShowErrorMessage("E101");
                        return "1";
                    }
                }
            }

            return "0";
        }
    }
}
