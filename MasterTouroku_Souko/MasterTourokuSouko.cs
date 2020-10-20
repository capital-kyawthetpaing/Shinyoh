using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shinyoh;
using Entity;
using Shinyoh_Controls;
using BL;

namespace MasterTouroku_Souko
{
    public partial class MasterTourokuSouko : BaseForm
    {
        ButtonType type = new ButtonType();
        public MasterTourokuSouko()
        {
            InitializeComponent();
        }
        private void MasterTourokuSouko_Load(object sender, EventArgs e)
        {
            ProgramID = "MasterTourokuSouko";
            StartProgram();
            cboMode.Bind(false);
            SetButton(ButtonType.BType.Close, F1, "F1(終了)",true);
            SetButton(ButtonType.BType.New, F2, "F2(新規)",true);
            SetButton(ButtonType.BType.Update, F3, "F3(変更)",true);
            SetButton(ButtonType.BType.Delete, F4, "F4(削除)",true);
            SetButton(ButtonType.BType.Inquiry, F5, "F5(照会)",true);
            SetButton(ButtonType.BType.Cancel, F6, "F6(ｷｬﾝｾﾙ)",true);
            SetButton(ButtonType.BType.Search, F9, "F9(検索)",false);
            SetButton(ButtonType.BType.Save, F12, "F12(登録)",true);
            SetButton(ButtonType.BType.Empty, F7, "",false);
            SetButton(ButtonType.BType.Empty, F8, "",false);
            SetButton(ButtonType.BType.Empty, F10, "",false);
            SetButton(ButtonType.BType.Empty, F11, "",false);

            ChangeMode(Mode.New);
        }

        private void ChangeMode(Mode mode)
        {
            switch(mode)
            {
                case Mode.New:
                    txtSouko.RequiredCheck(true);
                    txtSoukoName.RequiredCheck(true);
                    txtYubin2.ZipCheck(true,txtYubin1, txtYubin2, string.Empty);
                    break;
            }
        }

        private void cboName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = cboMode.SelectedIndex.ToString();
            if (item == "0")
            {
                txtSouko.Enabled = true;
                txtCopySouko.Enabled = true;
            }
            else
            {
                txtCopySouko.Enabled = false;
                txtSouko.Enabled = true;
            }
        }

        public override void FunctionProcess(string tagID)
        {
            if (tagID == "2")
            {
                cboMode.SelectedIndex = -1;
                cboMode.SelectedIndex = cboMode.SelectedIndex + 1;
            }
            if(tagID == "3")
            {
                cboMode.SelectedIndex = -1;
                cboMode.SelectedIndex = cboMode.SelectedIndex +2;
            }
            if (tagID == "4")
            {
                cboMode.SelectedIndex = -1;
                cboMode.SelectedIndex = cboMode.SelectedIndex + 3;
            }
            if (tagID == "5")
            {
                cboMode.SelectedIndex = -1;
                cboMode.SelectedIndex = cboMode.SelectedIndex + 4;
            }
            if(tagID == "12")
            {
                DBProcess();
            }
            base.FunctionProcess(tagID);
        }

        private void DBProcess()
        {
            SoukoEntity soukoEntity = GetSouko();
            if(cboMode.SelectedValue.Equals("1"))
            {
                soukoEntity.Mode = "New";
                DoInsert(soukoEntity);
            }
            else if(cboMode.SelectedValue.Equals("2"))
            {
                soukoEntity.Mode = "Update";
                DoUpdate(soukoEntity);
            }
            else if(cboMode.SelectedValue.Equals("3"))
            {
                soukoEntity.Mode = "Delete";
                DoDelete(soukoEntity);
            }
        }
        private SoukoEntity GetSouko()
        {
            SoukoEntity soukoEntity = new SoukoEntity();
            soukoEntity.SoukoCD = txtSouko.Text.ToString();
            soukoEntity.SoukoName = txtSoukoName.Text.ToString();
            soukoEntity.KanaName = txtKanaName.Text.ToString();
            soukoEntity.KensakuHyouziJun = txtSearch.Text.ToString();
            soukoEntity.YuubinNO1 = txtYubin1.Text.ToString();
            soukoEntity.YuubinNO2 = txtYubin2.Text.ToString();
            soukoEntity.Juusho1 = txtAddress1.Text.ToString();
            soukoEntity.Juusho2 = txtAddress2.Text.ToString();
            soukoEntity.TelNO = txtPhNo.Text.ToString();
            soukoEntity.FaxNO = txtFAX.Text.ToString();
            soukoEntity.Remarks = txtRemark.Text.ToString();
            soukoEntity.Mode = cboMode.SelectedIndex.ToString();
            return soukoEntity;
        }
        private void DoInsert(SoukoEntity soukoInsert) {
            SoukoBL souko = new SoukoBL();
            souko.M_Souko_CUD(soukoInsert);
        }
        private void DoUpdate(SoukoEntity soukoUpdate) {
            SoukoBL souko = new SoukoBL();
            souko.M_Souko_CUD(soukoUpdate);
        }
        private void DoDelete(SoukoEntity soukoDelete) {
            SoukoBL souko = new SoukoBL();
            souko.M_Souko_CUD(soukoDelete);
        }
    }
}
