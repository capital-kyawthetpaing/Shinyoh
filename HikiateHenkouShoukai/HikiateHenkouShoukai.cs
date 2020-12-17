using BL;
using CKM_CommonFunction;
using Entity;
using Shinyoh;
using Shinyoh_Search;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HikiateHenkouShoukai
{
    public partial class HikiateHenkouShoukai : BaseForm
    {
        BaseEntity base_entity;
        CommonFunction cf;
        public HikiateHenkouShoukai()
        {
            InitializeComponent();
            cf = new CommonFunction();
        }

        private void HikiateHenkouShoukai_Load(object sender, EventArgs e)
        {
            ProgramID = "HikiateHenkouShoukai";
            StartProgram();
            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "", false);
            SetButton(ButtonType.BType.Update, F3, "", false);
            SetButton(ButtonType.BType.Delete, F4, "", false);
            SetButton(ButtonType.BType.Inquiry, F5, "", false);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Empty, F7, "出力(F7)", true);
            SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", true);
            SetButton(ButtonType.BType.Display, F10, "表示(F10)", true);
            SetButton(ButtonType.BType.Search, F11, "保存(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);

            Clear_Panel();
            rdoAggregation.Focus();
            base_entity = _GetBaseData();
            Radio_Changed(1);
        }

        private void Clear_Panel()
        {
            cf.Clear(PanelDetail);
        }

        public override void FunctionProcess(string tagID)
        {
            if (tagID == "6")
            {
            }
            if (tagID == "7")
            {
            }
            if (tagID == "8")
            {
            }
            if (tagID == "9")
            {
            }
            if (tagID == "10")
            {
            }
            if (tagID == "11")
            {
            }
            if (tagID == "12")
            {
            }

            base.FunctionProcess(tagID);
        }

        private void UI_ErrorCheck()
        {

        }

        private void rdoAggregation_CheckedChanged(object sender, EventArgs e)
        {
            Radio_Changed(1);
        }

        private void rdoDetails_CheckedChanged(object sender, EventArgs e)
        {
            Radio_Changed(2);
        }

        private void rdoFreeInventory_CheckedChanged(object sender, EventArgs e)
        {
            Radio_Changed(3);
        }

        private void Radio_Changed(int type)
        {
            switch(type)
            {
                case 1:
                    txtTokuisakiCD.Enabled = true;
                    txtKouritenCD.Enabled = true;
                    txtPostalCode1.Enabled = true;
                    txtPostalCode2.Enabled = true;
                    txtPhoneNo1.Enabled = true;
                    txtPhoneNo2.Enabled = true;
                    txtPhoneNo3.Enabled = true;
                    txtName.Enabled = true;
                    txtAddress.Enabled = true;
                    chkType1.Enabled = true;
                    chkType2.Enabled = true;
                    F7.Enabled = false;
                    F8.Enabled = false;
                    F11.Enabled = false;
                    F12.Enabled = false;
                    btn_F8.Enabled = false;
                    btn_F11.Enabled = false;
                    break;
                case 2:
                    txtTokuisakiCD.Enabled = false;
                    txtKouritenCD.Enabled = false;
                    txtPostalCode1.Enabled = false;
                    txtPostalCode2.Enabled = false;
                    txtPhoneNo1.Enabled = false;
                    txtPhoneNo2.Enabled = false;
                    txtPhoneNo3.Enabled = false;
                    txtName.Enabled = false;
                    txtAddress.Enabled = false;
                    chkType1.Enabled = true;
                    chkType2.Enabled = true;
                    F7.Enabled = false;
                    F8.Enabled = true;
                    F11.Enabled = true;
                    F12.Enabled = true;
                    btn_F8.Enabled = true;
                    btn_F11.Enabled = true;
                    break;
                case 3:
                    txtTokuisakiCD.Enabled = false;
                    txtKouritenCD.Enabled = false;
                    txtPostalCode1.Enabled = false;
                    txtPostalCode2.Enabled = false;
                    txtPhoneNo1.Enabled = false;
                    txtPhoneNo2.Enabled = false;
                    txtPhoneNo3.Enabled = false;
                    txtName.Enabled = false;
                    txtAddress.Enabled = false;
                    chkType1.Enabled = false;
                    chkType2.Enabled = false;
                    F7.Enabled = true;
                    F8.Enabled = false;
                    F11.Enabled = false;
                    F12.Enabled = false;
                    btn_F8.Enabled = false;
                    btn_F11.Enabled = false;
                    break;
            }
        }
    }
}
