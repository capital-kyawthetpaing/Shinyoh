using System;
using Shinyoh;
using Entity;
using BL;
using CKM_CommonFunction;
using System.Windows.Forms;
using Shinyoh_Controls;
using Shinyoh_Search;
using System.Data;
using System.Globalization;

namespace MasterTouroku_Souko
{
    public partial class MasterTourokuSouko : BaseForm
    {
        ButtonType type = new ButtonType();
        BaseEntity base_Entity;
        CommonFunction cf;
        public MasterTourokuSouko()
        {
            InitializeComponent();
            cf = new CommonFunction();
            
        }
        private void MasterTourokuSouko_Load(object sender, EventArgs e)
        {
            multipurposeEntity multipurpose_entity = new multipurposeEntity();
            ProgramID = "MasterTourokuSouko";
            StartProgram();
            cboMode.Bind(false, multipurpose_entity);
            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "新規(F2)", true);
            SetButton(ButtonType.BType.Update, F3, "変更(F3)", true);
            SetButton(ButtonType.BType.Delete, F4, "削除(F4)", true);
            SetButton(ButtonType.BType.Inquiry, F5, "照会(F5)", true);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", false);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);
            SetButton(ButtonType.BType.Empty, F7, "",false);
            SetButton(ButtonType.BType.Empty, F8, "",false);
            SetButton(ButtonType.BType.Empty, F10, "",false);
            SetButton(ButtonType.BType.Empty, F11, "",false);
            ChangeMode(Mode.New);
            txtSouko.Focus();
            base_Entity = _GetBaseData();

            txtSouko.ChangeDate = txtSoukoName;
            txtCopySouko.ChangeDate = txtSoukoName;
        }
        private void ChangeMode(Mode mode)
        {
            //Enable && Disable
            cf.Clear(PanelTitle);
            cf.Clear(PanelDetail);
            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(PanelDetail);
            txtSouko.Focus();
            txtSearch.Text = "0";
            switch (mode)
            {
                case Mode.New:
                    txtSouko.E102Check(true);
                    txtSouko.E132Check(true, "souko", null, null, null);
                    txtSouko.E101Check(false, null, null, null, null);
                    txtCopySouko.E101Check(true, "souko", null, null, null);
                    txtSoukoName.E102Check(true);
                    txtYubin2.E102MultiCheck(true, txtYubin1, txtYubin2);
                    txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, string.Empty, string.Empty);

                    cf.Clear(PanelTitle);
                    cf.Clear(PanelDetail);
                    cf.DisablePanel(PanelDetail);

                    txtSouko.Enabled = true;
                    txtCopySouko.Enabled = true;
                    txtSouko.Focus();

                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;

                    break;
                case Mode.Update:
                    txtSouko.E102Check(true);
                    txtSouko.E132Check(false, null, null, null, null);
                    txtSouko.E101Check(true, "souko", null, null, null);
                    txtYubin2.E102MultiCheck(true, txtYubin1, txtYubin2);
                    txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, string.Empty, string.Empty);

                    cf.Clear(PanelTitle);
                    cf.Clear(PanelDetail);
                    cf.DisablePanel(PanelDetail);

                    txtCopySouko.Enabled = false;
                    txtSouko.Enabled = true;
                    txtSouko.Focus();

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

                    txtCopySouko.Enabled = false;
                    txtSouko.Enabled = true;
                    txtSouko.Focus();

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

                    txtCopySouko.Enabled = false;
                    txtSouko.Enabled = true;
                    txtSouko.Focus();

                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;

                    break;
            }
        }

        public override void FunctionProcess(string tagID)
        {
            if (tagID == "2")
            {
                ChangeMode(Mode.New);
            }
            if(tagID == "3")
            {
                ChangeMode(Mode.Update);
            }
            if (tagID == "4")
            {
                ChangeMode(Mode.Delete);
            }
            if (tagID == "5")
            {
                ChangeMode(Mode.Inquiry);
            }
            if(tagID == "12")
            {
                if (ErrorCheck(PanelTitle) && ErrorCheck(PanelDetail))
                {
                    DBProcess();
                    switch (cboMode.SelectedValue)
                    {
                        case "1":
                            ChangeMode(Mode.New);
                            break;
                        case "2":
                            ChangeMode(Mode.Update);
                            break;
                        case "3":
                            ChangeMode(Mode.Delete);
                            break;
                        case "4":
                            ChangeMode(Mode.Inquiry);
                            break;
                    }
                }
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
            int int_val = 0;
            int.TryParse(txtSearch.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out int_val);
            soukoEntity.KensakuHyouziJun = int_val.ToString();
            soukoEntity.YuubinNO1 = txtYubin1.Text.ToString();
            soukoEntity.YuubinNO2 = txtYubin2.Text.ToString();
            soukoEntity.Juusho1 = txtAddress1.Text.ToString();
            soukoEntity.Juusho2 = txtAddress2.Text.ToString();
            soukoEntity.TelNO = txtPhNo.Text.ToString();
            soukoEntity.FaxNO = txtFAX.Text.ToString();
            soukoEntity.Remarks = txtRemark.Text.ToString();
            soukoEntity.Mode = cboMode.SelectedIndex.ToString();
            soukoEntity.InsertOperator = base_Entity.OperatorCD;
            soukoEntity.UpdateOperator = base_Entity.OperatorCD;
            soukoEntity.KeyItem = txtSouko.Text;
            soukoEntity.PC = base_Entity.PC;
            soukoEntity.ProgramID = base_Entity.ProgramID;
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
        private void soukoSelect(DataTable dt)
        {
           if(dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["MessageID"].ToString() == "E132")
                {
                    txtSoukoName.Text = dt.Rows[0]["SoukoName"].ToString();
                    txtKanaName.Text = dt.Rows[0]["KanaName"].ToString();
                    txtSearch.Text = dt.Rows[0]["KensakuHyouziJun"].ToString();
                    txtYubin1.Text = dt.Rows[0]["YuubinNO1"].ToString();
                    txtYubin2.Text = dt.Rows[0]["YuubinNO2"].ToString();
                    txtAddress1.Text = dt.Rows[0]["Juusho1"].ToString();
                    txtAddress2.Text = dt.Rows[0]["Juusho2"].ToString();
                    txtPhNo.Text = dt.Rows[0]["TelNO"].ToString();
                    txtFAX.Text = dt.Rows[0]["FaxNO"].ToString();
                    txtRemark.Text = dt.Rows[0]["Remarks"].ToString();

                }
            }
        }
        private void txtSouko_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtSouko.IsErrorOccurs)
                {
                    if (cboMode.SelectedValue.ToString() == "2")//update
                    {
                        EnableAndDisablePanel();
                    }
                }
                DataTable dt = txtSouko.IsDatatableOccurs;
                if (dt.Rows.Count > 0 && cboMode.SelectedValue.ToString() != "1")
                {
                    soukoSelect(dt);
                    cf.DisablePanel(PanelTitle);
                }
            }
        }

        private void EnableAndDisablePanel()
        {
            cf.EnablePanel(PanelDetail);
            txtSoukoName.Focus();
            cf.DisablePanel(PanelTitle);
        }
        private void txtYubin2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtYubin2.IsErrorOccurs && txtYubin2.IsDatatableOccurs.Rows.Count > 0)
                {
                    DataTable dt = txtYubin2.IsDatatableOccurs;
                    txtAddress1.Text = dt.Rows[0]["Juusho1"].ToString();
                    txtAddress2.Text = dt.Rows[0]["Juusho2"].ToString();
                }
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string value = txtSearch.Text.Replace(",", "");
            ulong ul;
            if (ulong.TryParse(value, out ul))
            {
                txtSearch.TextChanged -= txtSearch_TextChanged;
                txtSearch.Text = string.Format("{0:#,#0}", ul);
                txtSearch.SelectionStart = txtSearch.Text.Length;
                txtSearch.TextChanged += txtSearch_TextChanged;
            }
            else
            {
                txtSearch.Text = "0";
            }
        }

        private void txtCopySouko_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cboMode.SelectedValue.ToString() == "1")
            {
                if (!txtCopySouko.IsErrorOccurs)
                {
                    EnableAndDisablePanel();
                    DataTable dt = txtCopySouko.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                        soukoSelect(dt);
                }
            }
        }
    }
}
