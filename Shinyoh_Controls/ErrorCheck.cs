using System;
using System.Data;
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
        public bool Check(Control ctrl)
        {
            if(ctrl is STextBox)
            {
                STextBox sTextBox = ctrl as STextBox;
                return TextBoxErrorCheck(sTextBox);
            }

            return false;
        }

        private bool TextBoxErrorCheck(STextBox sTextBox)
        {
            if (sTextBox.E101 && !string.IsNullOrWhiteSpace(sTextBox.Text))
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
                    ShowErrorMessage("E101");
                    sTextBox.Focus();
                    return true;
                }
            }

            if (sTextBox.E102)
            {
                if (string.IsNullOrWhiteSpace(sTextBox.Text))
                {
                    ShowErrorMessage("E102");
                    sTextBox.Focus();
                    return true;
                }                    
            }

            if (sTextBox.E102Multi)
            {
                if (string.IsNullOrWhiteSpace(sTextBox.ctrlE102_1.Text) && !string.IsNullOrWhiteSpace(sTextBox.ctrlE102_2.Text))
                {
                    ShowErrorMessage("E102");
                    sTextBox.ctrlE102_1.Focus();
                    return true;
                }
                else if (!string.IsNullOrWhiteSpace(sTextBox.ctrlE102_1.Text) && string.IsNullOrWhiteSpace(sTextBox.ctrlE102_2.Text))
                {
                    ShowErrorMessage("E102");
                    sTextBox.ctrlE102_2.Focus();
                    return true;
                }
            }
            //NMW(2020-10-22)
            if (sTextBox.E103)
            {
                DateTime dt;
                bool bl = (DateTime.TryParse(sTextBox.Text.ToString(), out dt));
                if (!bl)
                {
                    ShowErrorMessage("E103");
                    sTextBox.Focus();
                    return true;
                }
            }
            //NMW(2020-10-23)
            if (sTextBox.E104)
            {
                DateTime JDate = Convert.ToDateTime(sTextBox.ctrlE104_1.Text);
                DateTime LDate = Convert.ToDateTime(sTextBox.ctrlE104_2.Text);
                if (JDate.Date>LDate.Date)
                {
                    ShowErrorMessage("E104");
                    sTextBox.Focus();
                    return true;
                }
            }

            if (sTextBox.E132)
            {
                string result = string.Empty;
                DataTable dt = new DataTable();
                switch (sTextBox.E132Type)
                {
                    case "souko":
                        SoukoBL bl = new SoukoBL();
                        SoukoEntity soukoEntity = new SoukoEntity();
                        soukoEntity.SoukoCD = sTextBox.Text;
                        soukoEntity = bl.Souko_Select(soukoEntity);
                        result = soukoEntity.MessageID;
                        break;
                    case "M_Staff":// NMW(2020-10-22)
                        StaffBL sBL = new StaffBL();
                        dt = sBL.Staff_Select_Check(sTextBox.ctrlE132_1.Text, Convert.ToDateTime(sTextBox.ctrlE132_2.Text));
                        result = dt.Rows[0]["MessageID"].ToString();
                        break;
                }
                if (result.Equals("E132"))
                {
                    ShowErrorMessage("E132");
                    sTextBox.Focus();
                    return true;
                }
            }

            if (sTextBox.E133)//NMW(2020-10-23)
            {
                DataTable dt = new DataTable();
                string result = string.Empty;
                StaffBL sBL = new StaffBL();
                switch (sTextBox.E133Type)
                {
                    case "M_Staff":// NMW(2020-10-22)
                        if(!string.IsNullOrEmpty(sTextBox.ctrlE133_1.Text) && !string.IsNullOrEmpty(sTextBox.ctrlE133_2.Text))
                        {
                            dt = sBL.Staff_Select_Check(sTextBox.ctrlE133_1.Text, Convert.ToDateTime(sTextBox.ctrlE133_2.Text));
                            result = dt.Rows[0]["MessageID"].ToString();
                        }
                        break;
                }
                if (result.Equals("E133"))
                {
                    ShowErrorMessage("E133");
                    sTextBox.Focus();
                    return true;
                }
            }

            if(sTextBox.E101 && !string.IsNullOrWhiteSpace(sTextBox.Text))
            {
                string result = string.Empty;
                switch (sTextBox.E101Type)
                {
                    case "souko":
                        SoukoBL bl = new SoukoBL();
                        SoukoEntity soukoEntity = new SoukoEntity();
                        soukoEntity.SoukoCD = sTextBox.Text;
                        soukoEntity = bl.Souko_Select(soukoEntity);
                        result = soukoEntity.MessageID;
                        break;
                }
                if (result.Equals("E101"))
                {
                    ShowErrorMessage("E101");
                    sTextBox.Focus();
                    return true;
                }
            }

            return false;
        }
    }
}
