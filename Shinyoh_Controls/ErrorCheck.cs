using System;
using System.Data;
using System.Windows.Forms;
using BL;
using Entity;
using CKM_CommonFunction;

namespace Shinyoh_Controls
{
    public class ErrorCheck
    {
        CommonFunction cf;
        public void ShowErrorMessage(string messageID)
        {
            BaseBL bbl = new BaseBL();
            bbl.ShowMessage(messageID);
        }

        public (bool,DataTable) Check(Control ctrl)
        {
            DataTable dt = new DataTable();
            if (ctrl is STextBox)
            {
                STextBox sTextBox = ctrl as STextBox;
                (bool,DataTable) r_value= TextBoxErrorCheck(sTextBox);
                return r_value;
            }
            return (false,dt);
        }
        private (bool,DataTable) TextBoxErrorCheck(STextBox sTextBox)
        {
            DataTable rDt = new DataTable();
            if (sTextBox.E101 && !string.IsNullOrWhiteSpace(sTextBox.Text))
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
                    return (true,rDt);
                }
            }

            if (sTextBox.E102)
            {
                if (string.IsNullOrWhiteSpace(sTextBox.Text))
                {
                    ShowErrorMessage("E102");
                    sTextBox.Focus();
                    return (true, rDt);
                }
            }

            if (sTextBox.E102Multi)
            {
                if (string.IsNullOrWhiteSpace(sTextBox.ctrlE102_1.Text) && !string.IsNullOrWhiteSpace(sTextBox.ctrlE102_2.Text))
                {
                    ShowErrorMessage("E102");
                    sTextBox.ctrlE102_1.Focus();
                    return (true, rDt);
                }
                else if (!string.IsNullOrWhiteSpace(sTextBox.ctrlE102_1.Text) && string.IsNullOrWhiteSpace(sTextBox.ctrlE102_2.Text))
                {
                    ShowErrorMessage("E102");
                    sTextBox.ctrlE102_2.Focus();
                    return (true, rDt);
                }
            }
            
            if (sTextBox.E103)
            {
                cf = new CommonFunction();
                if(!cf.DateCheck(sTextBox))
                {
                    ShowErrorMessage("E103");
                    sTextBox.Focus();

                    return (true, rDt);
                }
            }
            
            if (sTextBox.E104)
            {
                DateTime JDate = Convert.ToDateTime(sTextBox.ctrlE104_1.Text);
                DateTime LDate = Convert.ToDateTime(sTextBox.ctrlE104_2.Text);
                if (JDate.Date > LDate.Date)
                {
                    ShowErrorMessage("E104");
                    sTextBox.Focus();
                    return (true, rDt);
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
                        rDt = dt;
                        result = dt.Rows[0]["MessageID"].ToString();
                        break;
                }
                if (result.Equals("E132"))
                {
                    ShowErrorMessage("E132");
                    sTextBox.Focus();
                    return (true, rDt);
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
                        if (!string.IsNullOrEmpty(sTextBox.ctrlE133_1.Text) && !string.IsNullOrEmpty(sTextBox.ctrlE133_2.Text))
                        {
                            dt = sBL.Staff_Select_Check(sTextBox.ctrlE133_1.Text, Convert.ToDateTime(sTextBox.ctrlE133_2.Text));
                            rDt = dt;
                            result = dt.Rows[0]["MessageID"].ToString();
                        }
                        break;
                }
                if (result.Equals("E133"))
                {
                    ShowErrorMessage("E133");
                    sTextBox.Focus();
                    return (true, rDt);
                }
            }

            if (sTextBox.E166)
            {
                if (!sTextBox.ctrlE166_1.Text.Equals(sTextBox.ctrlE166_2.Text))
                {
                    ShowErrorMessage("E166");
                    sTextBox.Focus();
                    return (true, rDt);
                }
            }
            return (false, rDt);
        }
    }
}
