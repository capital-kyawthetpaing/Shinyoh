﻿using BL;
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
            ProgramID = "MasterTourokuSouko";
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
            txtSEQNO.ChangeDate = txtPrefix;
            txtSEQNO.ctrlE102_c = cbDivision;
            txtPrefix.ctrlE102_c = cbDivision;
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
                    txtSEQNO.E132Check(true, "denpyou", txtSEQNO, txtPrefix, null);
                    txtSEQNO.E133Check(false, null, null, null, null);
                    txtPrefix.E102Check(true);
                    txtPrefix.E132Check(true, "denpyou", txtSEQNO, txtPrefix, null);
                    txtCounter.E102Check(true);
                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    break;
                case Mode.Update:
                    cbDivision.E102Check(true);
                    txtSEQNO.E102Check(true);
                    txtSEQNO.E132Check(false, null, null, null, null);
                    txtSEQNO.E133Check(true, "denpyou", txtPrefix, null, null);
                    txtPrefix.E102Check(true);
                    txtPrefix.E132Check(false, null, null, null, null);
                    txtCounter.E102Check(true);
                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    cbDivision.E102Check(true);
                    txtSEQNO.E102Check(true);
                    txtSEQNO.E132Check(false, null, null, null, null);
                    txtSEQNO.E133Check(true, "denpyou", txtPrefix, null, null);
                    txtPrefix.E102Check(true);
                    txtPrefix.E132Check(false, null, null, null, null);
                    txtCounter.E102Check(true);
                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;
                    break;
                case Mode.Inquiry:
                    cbDivision.E102Check(true);
                    txtSEQNO.E102Check(true);
                    txtSEQNO.E132Check(false, null, null, null, null);
                    txtSEQNO.E133Check(true, "denpyou", txtPrefix, null, null);
                    txtPrefix.E102Check(true);
                    txtPrefix.E132Check(false, null, null, null, null);
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
            DNOentity.RenbenKBN = Convert.ToInt32(cbDivision.SelectedIndex.ToString());
            DNOentity.seqno = Convert.ToInt32(txtSEQNO.Text);
            DNOentity.prefix = txtPrefix.Text;
            DNOentity.counter = Convert.ToInt32(txtCounter.Text);
            DNOentity.InsertOperator = entity.OperatorCD;
            DNOentity.UpdateOperator = entity.OperatorCD;
            DNOentity.PC = entity.PC;
            DNOentity.ProgramID = entity.ProgramID;
            DNOentity.KeyItem = txtSEQNO.Text;
            return DNOentity;
        }

        private void Denpyou_IUD(DenpyouNOEntity DNOEntity)
        {
            DenpyouNOBL denpyoubl = new DenpyouNOBL();
            denpyoubl.DenpyouNO_IUD(DNOEntity);
        }

        private void txtSEQNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtSEQNO.IsErrorOccurs)
                {
                    if (cboMode.SelectedValue.ToString() == "2")//update
                    {
                        EnableAndDisablePanel();
                    }
                }
                DataTable dt = txtSEQNO.IsDatatableOccurs;
                if (dt.Rows.Count > 0 && cboMode.SelectedValue.ToString() != "1")
                {
                    if(dt.Rows[0]["MessageID"].ToString() != "E133")
                    {
                        DenpyouSelect(dt);
                        EnableAndDisablePanel();
                    }
                }
            }
        }

        private void EnableAndDisablePanel()
        {
            cf.EnablePanel(PanelDetail);
            txtCounter.Focus();
            cf.DisablePanel(PanelTitle);
        }

        private void DenpyouSelect(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                txtCounter.Text = dt.Rows[0]["Counter"].ToString();
            }
        }

        private void txtPrefix_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cboMode.SelectedValue.ToString() == "1")
            {
                if (!txtPrefix.IsErrorOccurs)
                {
                    EnableAndDisablePanel();
                    DataTable dt = txtPrefix.IsDatatableOccurs;
                    if(dt.Rows[0]["MessageID"].ToString() != "0")
                        DenpyouSelect(dt);
                }
            }
        }
    }
}
