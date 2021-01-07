using BL;
using Entity;
using Shinyoh;
using System;
using CKM_CommonFunction;
using System.Windows.Forms;
using System.Data;
using Shinyoh_Controls;
using Shinyoh_Search;

namespace MasterTouroku_DenpyouNO
{
    public partial class MasterTouroku_DenpyouNO : BaseForm
    {
        BaseEntity entity;
        CommonFunction cf;
        public MasterTouroku_DenpyouNO()
        {
            InitializeComponent();
            cf = new CommonFunction();
        }

        private void MasterTouroku_DenpyouNO_Load(object sender, EventArgs e)
        {
            multipurposeEntity multipurpose_entity = new multipurposeEntity();
            multipurpose_entity.id = 101;
            ProgramID = "MasterTouroku_DenpyouNO";
            StartProgram();
            cboMode.Bind(false, multipurpose_entity);
            cbDivision.Bind(true, multipurpose_entity);
            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "新規(F2)", true);
            SetButton(ButtonType.BType.Update, F3, "修正(F3)", true);
            SetButton(ButtonType.BType.Delete, F4, "削除(F4)", true);
            SetButton(ButtonType.BType.Inquiry, F5, "照会(F5)", true);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", false);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            SetButton(ButtonType.BType.Empty, F8, "", false);
            SetButton(ButtonType.BType.Empty, F10, "", false);
            SetButton(ButtonType.BType.Empty, F11, "", false);
            ChangeMode(Mode.New);
            entity = _GetBaseData();

            txtSEQNO.Combo = cbDivision;
            txtSEQNO.TxtBox = txt_Prefix;
            txtSEQNO.ctrl_combo = cbDivision;

            txt_Prefix.Combo = cbDivision;
            txt_Prefix.TxtBox = txtSEQNO;
            txt_Prefix.ctrl_combo = cbDivision;
        }

        private void ChangeMode(Mode mode)
        {
            cf.Clear(PanelTitle);
            cf.Clear(PanelDetail);
            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(PanelDetail);
            cbDivision.Focus();
            switch (mode)
            {
                case Mode.New:
                    cbDivision.E102Check(true);
                    txtSEQNO.E102Check(true);
                    txt_Prefix.E102Check(true);
                    txt_Prefix.E132Check(true, "denpyou", txt_Prefix, txtSEQNO, cbDivision);
                    txt_Prefix.E133Check(false, "denpyou", txt_Prefix, txtSEQNO, cbDivision);
                    txtCounter.E102Check(true);
                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    //F9.Visible = false;
                    break;
                case Mode.Update:
                    cbDivision.E102Check(true);
                    txtSEQNO.E102Check(true);
                    txt_Prefix.E102Check(true);
                    txt_Prefix.E132Check(false, null, null, null, null);
                    txt_Prefix.E133Check(true, "denpyou", txt_Prefix, txtSEQNO, cbDivision);
                    txtCounter.E102Check(true);
                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    cbDivision.E102Check(true);
                    txtSEQNO.E102Check(true);
                    txt_Prefix.E102Check(true);
                    txt_Prefix.E132Check(false, null, null, null, null);
                    txt_Prefix.E133Check(true, "denpyou", txt_Prefix, txtSEQNO, cbDivision);
                    txtCounter.E102Check(true);
                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;
                    break;
                case Mode.Inquiry:
                    cbDivision.E102Check(true);
                    txtSEQNO.E102Check(true);
                    txt_Prefix.E102Check(true);
                    txt_Prefix.E132Check(false, null, null, null, null);
                    txt_Prefix.E133Check(true, "denpyou", txt_Prefix, txtSEQNO, cbDivision);
                    txtCounter.E102Check(true);
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
            if (tagID == "3")
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
            if(tagID=="6")
            {
                Clear();
            }
            if (tagID == "12")
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
        public void Clear()
        {
            cf.Clear(PanelTitle);
            cf.Clear(PanelDetail);
            cbDivision.Focus();
            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(PanelDetail);
            cbDivision.Select();
            //Control btnSearch = this.TopLevelControl.Controls.Find("BtnF9", true)[0];
            //btnSearch.Visible = false;
        }
        private void DBProcess()
        {
            DenpyouNOBL denpyoubl = new DenpyouNOBL();
            DenpyouNOEntity DNOEntity = getDenpyou();
            switch(cboMode.SelectedValue)
            {
                case "1":
                    DNOEntity.Mode = "New";
                    break;
                case "2":
                    DNOEntity.Mode = "Update";
                    break;
                case "3":
                    DNOEntity.Mode = "Delete";
                    break;
            }
            Denpyou_IUD(DNOEntity);
        }

        private DenpyouNOEntity getDenpyou()
        {
            DenpyouNOEntity DNOentity = new DenpyouNOEntity();
            DNOentity.RenbenKBN = cbDivision.SelectedIndex.ToString();
            DNOentity.seqno = txtSEQNO.Text;
            DNOentity.prefix = txt_Prefix.Text;
            DNOentity.counter = txtCounter.Text;
            DNOentity.InsertOperator = entity.OperatorCD;
            DNOentity.UpdateOperator = entity.OperatorCD;
            DNOentity.PC = entity.PC;
            DNOentity.ProgramID = entity.ProgramID;
            DNOentity.KeyItem = cbDivision.Text+" "+txtSEQNO.Text+" "+txt_Prefix.Text;
            return DNOentity;
        }

        private void Denpyou_IUD(DenpyouNOEntity DNOEntity)
        {
            DenpyouNOBL denpyoubl = new DenpyouNOBL();
            denpyoubl.DenpyouNO_IUD(DNOEntity);
        }

        private void EnableAndDisablePanel()
        {
            cf.DisablePanel(PanelTitle);
            cf.EnablePanel(PanelDetail);
            txtCounter.Focus();
        }

        private void DenpyouSelect(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                txtCounter.Text = dt.Rows[0]["Counter"].ToString();
            }
        }
        private void txt_Prefix_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txt_Prefix.IsErrorOccurs)
                {
                    if (cboMode.SelectedValue.ToString() == "1" || cboMode.SelectedValue.ToString() == "2")
                    {
                        EnableAndDisablePanel();
                    }
                    else if(cboMode.SelectedValue.ToString() == "3" || cboMode.SelectedValue.ToString() == "4")
                    {
                        cf.DisablePanel(PanelTitle);
                        cf.DisablePanel(PanelDetail);
                        if(cboMode.SelectedValue.ToString() == "3")
                        {
                            Control btnF12 = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                            btnF12.Focus();
                        }
                    }
                }
                DataTable dt = txt_Prefix.IsDatatableOccurs;
                if (dt.Rows.Count > 0 && cboMode.SelectedValue.ToString() != "1")
                {
                    if (dt.Rows[0]["MessageID"].ToString() == "0")
                    {
                        DenpyouSelect(dt);
                    }
                }
            }
        }
    }
}
