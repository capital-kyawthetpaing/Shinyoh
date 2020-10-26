using System;
using Shinyoh;
using Entity;
using BL;
using CKM_CommonFunction;
using System.Windows.Forms;

namespace MasterTouroku_Souko
{
    public partial class MasterTourokuSouko : BaseForm
    {
        ButtonType type = new ButtonType();
        CommonFunction cf;
        public MasterTourokuSouko()
        {
            InitializeComponent();
            cf = new CommonFunction();
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
            txtSouko.Focus();

        }

        private void ChangeMode(Mode mode)
        {
            switch(mode)
            {
                case Mode.New:
                    txtSouko.E102Check(true);
                    txtSouko.E132Check(true,"souko",null,null,null);
                    txtSouko.E101Check(false, null, null, null, null);
                    txtCopySouko.E101Check(true, "souko", null,null,null);
                    txtSoukoName.E102Check(true);
                    txtYubin2.E102MultiCheck(true, txtYubin1, txtYubin2);

                    cf.Clear(PanelTitle);
                    cf.Clear(PanelDetail);
                    cf.DisablePanel(PanelDetail);
                    cboMode.SelectedValue = 1;

                    txtSouko.Enabled = true;
                    txtCopySouko.Enabled = true;

                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;

                    break;
                case Mode.Update:
                    txtSouko.E102Check(true);
                    txtSouko.E132Check(false, null, null, null, null);
                    txtSouko.E101Check(true, "souko", null, null, null);

                    cf.Clear(PanelTitle);
                    cf.Clear(PanelDetail);
                    cf.DisablePanel(PanelDetail);
                    cboMode.SelectedValue = 2;

                    txtCopySouko.Enabled = false;
                    txtSouko.Enabled = true;

                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;

                    break;
                case Mode.Delete:
                    txtSouko.E102Check(true);
                    txtSouko.E132Check(false, null, null, null, null);
                    txtSouko.E101Check(true, "souko", null, null, null);

                    cf.Clear(PanelTitle);
                    cf.Clear(PanelDetail);
                    cf.DisablePanel(PanelDetail);
                    cboMode.SelectedValue = 3;

                    txtCopySouko.Enabled = false;
                    txtSouko.Enabled = true;

                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;

                    break;
                case Mode.Inquiry:
                    txtSouko.E102Check(true);
                    txtSouko.E132Check(false, null, null, null, null);
                    txtSouko.E101Check(true, "souko", null, null, null);

                    cf.Clear(PanelTitle);
                    cf.Clear(PanelDetail);
                    cf.DisablePanel(PanelDetail);
                    cboMode.SelectedValue = 4;

                    txtCopySouko.Enabled = false;
                    txtSouko.Enabled = true;

                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;

                    break;
            }
        }

        private void cboName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = cboMode.SelectedIndex.ToString();
            if (item.Equals("1"))
            {
               // ChangeMode(Mode.New);
            }
            else if (item.Equals("2"))
            {
               // ChangeMode(Mode.Update);
            }
        }

        public override void FunctionProcess(string tagID)
        {
            if (tagID == "2")
            {
                cboMode.SelectedIndex = -1;
                cboMode.SelectedIndex = cboMode.SelectedIndex + 1;

                ChangeMode(Mode.New);
            }
            if(tagID == "3")
            {
                cboMode.SelectedIndex = -1;
                cboMode.SelectedIndex = cboMode.SelectedIndex +2;

                ChangeMode(Mode.Update);
            }
            if (tagID == "4")
            {
                cboMode.SelectedIndex = -1;
                cboMode.SelectedIndex = cboMode.SelectedIndex + 3;

                ChangeMode(Mode.Delete);
            }
            if (tagID == "5")
            {
                cboMode.SelectedIndex = -1;
                cboMode.SelectedIndex = cboMode.SelectedIndex + 4;

                ChangeMode(Mode.Inquiry);
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

        private void txtCopySouko_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (cboMode.SelectedValue.Equals("1"))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!txtCopySouko.IsErrorOccurs)
                    {
                        cf.EnablePanel(PanelDetail);
                        txtSoukoName.Focus();
                    }
                }
            }       
        }
        private void soukoSelect()
        {
            SoukoBL bl = new SoukoBL();
            SoukoEntity soukoEntity = GetSouko();
            soukoEntity = bl.Souko_Select(soukoEntity);
            txtSoukoName.Text = soukoEntity.SoukoName.ToString();
            txtKanaName.Text = soukoEntity.KanaName.ToString();
            txtSearch.Text = soukoEntity.KensakuHyouziJun.ToString();
            txtYubin1.Text = soukoEntity.YuubinNO1.ToString();
            txtYubin2.Text = soukoEntity.YuubinNO2.ToString();
            txtAddress1.Text = soukoEntity.Juusho1.ToString();
            txtAddress2.Text = soukoEntity.Juusho2.ToString();
            txtPhNo.Text = soukoEntity.TelNO.ToString();
            txtFAX.Text = soukoEntity.FaxNO.ToString();
            txtRemark.Text = soukoEntity.Remarks.ToString();
        }
        private void txtSouko_KeyDown(object sender, KeyEventArgs e)
        {
            if (cboMode.SelectedValue.Equals("2"))
            {
                if (!txtSouko.IsErrorOccurs)
                {
                    soukoSelect();
                    cf.EnablePanel(PanelDetail);
                    txtSoukoName.Focus();
                }
            }else if (cboMode.SelectedValue.Equals("3"))
            {
                if (!txtSouko.IsErrorOccurs)
                {
                    soukoSelect();
                }
            }
            else 
            {
                if (!txtSouko.IsErrorOccurs)
                {
                    soukoSelect();
                }
            }
        }
    }
}
