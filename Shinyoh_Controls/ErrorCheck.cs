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
            if(ctrl is ComboBox)
            {
                SCombo  sCombo = ctrl as SCombo;
                (bool, DataTable) r_value = ComboErrorCheck(sCombo);
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
                        rDt = bl.Souko_Select(sTextBox.ctrlE101_1.Text, "E101");
                        result = rDt.Rows[0]["MessageID"].ToString();
                        break;
                    case "M_Staff":
                        StaffBL sBL = new StaffBL();
                        rDt = sBL.Staff_Select_Check(sTextBox.ctrlE101_1.Text, sTextBox.ctrlE101_2.Text,"E101");
                        result = rDt.Rows[0]["MessageID"].ToString();
                        break;
                    case "M_Tokuisaki":
                        TokuisakiBL tBL = new TokuisakiBL();
                        rDt = tBL.M_Tokuisaki_Select(sTextBox.ctrlE101_1.Text, sTextBox.ctrlE101_2.Text, "E101");
                        result = rDt.Rows[0]["MessageID"].ToString();
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
                if(!string.IsNullOrEmpty(sTextBox.ctrlE104_2.Text))
                {
                    DateTime LDate = Convert.ToDateTime(sTextBox.ctrlE104_2.Text);
                    DateTime JDate = Convert.ToDateTime(sTextBox.ctrlE104_1.Text);
                    if (JDate.Date > LDate.Date)
                    {
                        ShowErrorMessage("E104");
                        sTextBox.Focus();
                        return (true, rDt);
                    }
                }
            }
            if (sTextBox.E106)
            {
                if (!string.IsNullOrEmpty(sTextBox.ctrlE106_1.Text) && !string.IsNullOrEmpty(sTextBox.ctrlE106_2.Text))
                {
                    int from_val = int.Parse(sTextBox.ctrlE106_1.Text);
                    int to_val = int.Parse(sTextBox.ctrlE106_2.Text);
                    if (from_val > to_val)
                    {
                        ShowErrorMessage("E106");
                        sTextBox.Focus();
                        return (true, rDt);
                    }
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
                        rDt = bl.Souko_Select(sTextBox.ctrlE132_1.Text, "E132");
                        result = rDt.Rows[0]["MessageID"].ToString();
                        break;
                    case "M_Staff":
                        StaffBL sBL = new StaffBL();
                        dt = sBL.Staff_Select_Check(sTextBox.ctrlE132_1.Text, sTextBox.ctrlE132_2.Text,string.Empty);
                        rDt = dt;
                        result = dt.Rows[0]["MessageID"].ToString();
                        break;
                    case "M_Siiresaki":
                        SiiresakiBL obj = new SiiresakiBL();
                        dt = obj.Siiresaki_Select_Check(sTextBox.ctrlE132_1.Text, sTextBox.ctrlE132_2.Text,string.Empty);
                        rDt = dt;
                        result = dt.Rows[0]["MessageID"].ToString();
                        break;
                    case "M_Tokuisaki":
                        TokuisakiBL tokuisakiBL = new TokuisakiBL();
                        dt = tokuisakiBL.M_Tokuisaki_Select(sTextBox.ctrlE132_1.Text, sTextBox.ctrlE132_2.Text,string.Empty);
                        rDt = dt;
                        result = dt.Rows[0]["MessageID"].ToString();
                        break;
                    case "M_Kouriten":
                        KouritenBL objK = new KouritenBL();
                        dt = objK.Kouriten_Select_Check(sTextBox.ctrlE132_1.Text, sTextBox.ctrlE132_2.Text, string.Empty);
                        rDt = dt;
                        result = dt.Rows[0]["MessageID"].ToString();
                        break;
                    case "ChakuniNyuuryoku":
                        chakuniNyuuryoku_BL cbl = new chakuniNyuuryoku_BL();
                        dt = cbl.ChakuniNyuuryoku_Select(sTextBox.ctrlE132_1.Text, null, string.Empty);
                        rDt = dt;
                        result = dt.Rows[0]["MessageID"].ToString();
                        break;
                    case "denpyou":
                        DenpyouNOEntity denpyou_entity = new DenpyouNOEntity();
                        DenpyouNOBL denpyou_bl = new DenpyouNOBL();
                        denpyou_entity.RenbenKBN = Convert.ToInt32(sTextBox.ctrlE102_c.SelectedValue.ToString());
                        denpyou_entity.seqno = Convert.ToInt32(sTextBox.ctrlE132_1.Text);
                        denpyou_entity.prefix = sTextBox.ctrlE132_2.Text;
                        denpyou_entity.MessageID = "E132";
                        rDt = denpyou_bl.DenpyouNO_Check(denpyou_entity);
                        result = rDt.Rows[0]["MessageID"].ToString();
                        break;
                }
                if (result.Equals("E132"))
                {
                    ShowErrorMessage("E132");
                    sTextBox.Focus();
                    return (true, rDt);
                }
            }

            if (sTextBox.E133)
            {
                DataTable dt = new DataTable();
                string result = string.Empty;
                StaffBL sBL = new StaffBL();
                switch (sTextBox.E133Type)
                {
                    case "M_Staff":
                        if (!string.IsNullOrEmpty(sTextBox.ctrlE133_1.Text) && !string.IsNullOrEmpty(sTextBox.ctrlE133_2.Text))
                        {
                            dt = sBL.Staff_Select_Check(sTextBox.ctrlE133_1.Text, sTextBox.ctrlE133_2.Text,string.Empty);
                            rDt = dt;
                            result = dt.Rows[0]["MessageID"].ToString();
                        }
                        break;
                    case "M_Siiresaki":
                        if (!string.IsNullOrEmpty(sTextBox.ctrlE133_1.Text) && !string.IsNullOrEmpty(sTextBox.ctrlE133_2.Text))
                        {
                            SiiresakiBL obj = new SiiresakiBL();
                            dt = obj.Siiresaki_Select_Check(sTextBox.ctrlE133_1.Text, sTextBox.ctrlE133_2.Text,string.Empty);
                            rDt = dt;
                            result = dt.Rows[0]["MessageID"].ToString();
                        }
                        break;
                    case "M_Tokuisaki":
                        if (!string.IsNullOrEmpty(sTextBox.ctrlE133_1.Text) && !string.IsNullOrEmpty(sTextBox.ctrlE133_2.Text))
                        {
                            TokuisakiBL tokuisakiBL = new TokuisakiBL();
                            dt = tokuisakiBL.M_Tokuisaki_Select(sTextBox.ctrlE133_1.Text, sTextBox.ctrlE133_2.Text,string.Empty);
                            rDt = dt;
                            result = dt.Rows[0]["MessageID"].ToString();
                        }
                        break;
                    case "M_Kouriten":
                        if (!string.IsNullOrEmpty(sTextBox.ctrlE133_1.Text) && !string.IsNullOrEmpty(sTextBox.ctrlE133_2.Text))
                        {
                            KouritenBL objK = new KouritenBL();
                            dt = objK.Kouriten_Select_Check(sTextBox.ctrlE133_1.Text, sTextBox.ctrlE133_2.Text, string.Empty);
                            rDt = dt;
                            result = dt.Rows[0]["MessageID"].ToString();
                        }
                        break;
                    case "denpyou":
                        DenpyouNOEntity denpyou_entity = new DenpyouNOEntity();
                        DenpyouNOBL denpyou_bl = new DenpyouNOBL();
                        denpyou_entity.RenbenKBN = Convert.ToInt32(sTextBox.ctrlE102_c.SelectedValue.ToString());
                        denpyou_entity.seqno = Convert.ToInt32(sTextBox.Text);
                        denpyou_entity.prefix = sTextBox.ctrlE133_1.Text;
                        denpyou_entity.MessageID = "E133";
                        rDt = denpyou_bl.DenpyouNO_Check(denpyou_entity);
                        result = rDt.Rows[0]["MessageID"].ToString();
                        break;
                    case "ChakuniNyuuryoku":
                        chakuniNyuuryoku_BL cbl = new chakuniNyuuryoku_BL();
                        dt = cbl.ChakuniNyuuryoku_Select(sTextBox.ctrlE133_1.Text,string.Empty, "E133");
                        rDt = dt;
                        result = dt.Rows[0]["MessageID"].ToString();
                        break;
                }
                if (result.Equals("E133"))
                {
                    ShowErrorMessage("E133");
                    sTextBox.Focus();
                    return (true, rDt);
                }
            }
            //if (sTextBox.E142)
            //{
            //    if (string.IsNullOrWhiteSpace(sTextBox.Text))
            //    {
            //        ShowErrorMessage("E142");
            //        sTextBox.Focus();
            //        return (true, rDt);
            //    }
            //}
            if (sTextBox.E166)
            {
                if (!sTextBox.ctrlE166_1.Text.Equals(sTextBox.ctrlE166_2.Text))
                {
                    ShowErrorMessage("E166");
                    sTextBox.Focus();
                    return (true, rDt);
                }
            }
            if (sTextBox.E270)
            {
                string result = string.Empty;                
                switch (sTextBox.E270Type)
                {
                    case "souko":
                        if (!string.IsNullOrEmpty(sTextBox.ctrlE270_1.Text))
                        {
                            SoukoBL sBL = new SoukoBL();
                            rDt = sBL.Souko_Select(sTextBox.ctrlE270_1.Text,"E270");
                            result = rDt.Rows[0]["MessageID"].ToString();
                        }
                        break;
                    case "M_Staff":
                        if (!string.IsNullOrEmpty(sTextBox.ctrlE270_1.Text) && !string.IsNullOrEmpty(sTextBox.ctrlE270_2.Text))
                        {
                            StaffBL sBL = new StaffBL();
                            rDt = sBL.Staff_Select_Check(sTextBox.ctrlE270_1.Text, sTextBox.ctrlE270_2.Text, "E270");
                            result = rDt.Rows[0]["MessageID"].ToString();
                        }
                        break;
                    case "M_Siiresaki":
                        if (!string.IsNullOrEmpty(sTextBox.ctrlE270_1.Text) && !string.IsNullOrEmpty(sTextBox.ctrlE270_2.Text))
                        {
                            SiiresakiBL obj = new SiiresakiBL();
                            rDt = obj.Siiresaki_Select_Check(sTextBox.ctrlE270_1.Text, sTextBox.ctrlE270_2.Text, "E270" );                            
                            result = rDt.Rows[0]["MessageID"].ToString();
                        }
                        break;
                    case "M_Tokuisaki":
                        if (!string.IsNullOrEmpty(sTextBox.ctrlE270_1.Text) && !string.IsNullOrEmpty(sTextBox.ctrlE270_2.Text))
                        {
                            TokuisakiBL tBL = new TokuisakiBL();
                            rDt = tBL.M_Tokuisaki_Select(sTextBox.ctrlE270_1.Text, sTextBox.ctrlE270_2.Text, "E270");
                            result = rDt.Rows[0]["MessageID"].ToString();
                        }
                        break;
                    case "M_Kouriten":
                        if (!string.IsNullOrEmpty(sTextBox.ctrlE270_1.Text) && !string.IsNullOrEmpty(sTextBox.ctrlE270_2.Text))
                        {
                            KouritenBL objK = new KouritenBL();
                            rDt = objK.Kouriten_Select_Check(sTextBox.ctrlE270_1.Text, sTextBox.ctrlE270_2.Text, "E270");
                            result = rDt.Rows[0]["MessageID"].ToString();
                        }
                        break;
                }
                if (result.Equals("E270"))
                {
                    ShowErrorMessage("E270");
                    sTextBox.Focus();
                    return (true, rDt);
                }
            }
            if (sTextBox.CYuubin_Juusho)
            {
                if (sTextBox.ctrl1Yuubin_Juusho.Text != sTextBox.check1Yuubin_Juusho  && sTextBox.ctrl2Yuubin_Juusho.Text != sTextBox.check2Yuubin_Juusho)
                {
                    YuubinNOBL obj = new YuubinNOBL();
                    YuubinNOEntity entity = new YuubinNOEntity();
                    entity.YuubinNO1 = sTextBox.ctrl1Yuubin_Juusho.Text;
                    entity.YuubinNO2 = sTextBox.ctrl2Yuubin_Juusho.Text;
                    rDt = obj.Yuubin_Search(entity);
                }
            }
            return (false, rDt);
        }

        private (bool, DataTable) ComboErrorCheck(SCombo sCombo)
        {
            DataTable rDt = new DataTable();

            if (sCombo.E102)
            {
                if (sCombo.SelectedValue.ToString()=="-1")
                {
                    ShowErrorMessage("E102");
                    sCombo.Focus();
                    return (true, rDt);
                }
            }

            return (false, rDt);
        }
    }
}
