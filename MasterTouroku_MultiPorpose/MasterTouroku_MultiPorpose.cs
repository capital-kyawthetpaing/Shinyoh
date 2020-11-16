using System;
using Shinyoh;
using Entity;
using BL;
using CKM_CommonFunction;
using System.Windows.Forms;
using Shinyoh_Controls;
using Shinyoh_Search;
using System.Data;


namespace MasterTouroku_MultiPorpose
{
    public partial class MasterTouroku_MultiPorpose : BaseForm
    {
        CommonFunction cf;
        BaseBL bbl;
        multipurposeEntity multi_Entity;
        public MasterTouroku_MultiPorpose()
        {
            InitializeComponent();
            cf = new CommonFunction();
            bbl = new BaseBL();
        }

        private void MasterTouroku_MultiPorpose_Load(object sender, EventArgs e)
        {
            ProgramID = "MasterTouroku_MultiPorpose";
            StartProgram();
            cboMode.Bind(false, multi_Entity);
            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "新規(F2)", true);
            SetButton(ButtonType.BType.Update, F3, "修正(F3)", true);
            SetButton(ButtonType.BType.Delete, F4, "削除(F4)", true);
            SetButton(ButtonType.BType.Inquiry, F5, "照会(F5)", true);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", true);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            SetButton(ButtonType.BType.Empty, F8, "", false);
            SetButton(ButtonType.BType.Empty, F10, "CSV取込(F10)", true);
            SetButton(ButtonType.BType.Empty, F11, "", false);

            ChangeMode(Mode.New);
            txtID.Focus();

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
                if (ErrorCheck(PanelTitle) && ErrorCheck(panelDetails))
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
        private void ChangeMode(Mode mode)
        {
            //Enable && Disable
            cf.Clear(PanelTitle);
            cf.Clear(panelTitle2);
            cf.Clear(panelDetails);
            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(panelDetails);
            txtID.Focus();
            switch (mode)
            {
                case Mode.New:
                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    break;

                case Mode.Update:
                    txtID.E102Check(true);
                    txtKEY.E102Check(true);
                    txtIDCopy.Enabled = false;
                    txtKEYCopy.Enabled = false;

                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    
                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;

                    break;
                case Mode.Inquiry:

                    txtIDCopy.Enabled = false;
                    txtKEYCopy.Enabled = false;
                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;
                    break;
            }
        }
        private void DBProcess()
        {
            multipurposeEntity entity = new multipurposeEntity();
            if (cboMode.SelectedValue.Equals("1"))
            {
                entity.Mode = "New";
                DoInsert(entity);
            }
            else if (cboMode.SelectedValue.Equals("2"))
            {
                entity.Mode = "Update";
                DoUpdate(entity);
            }
            else if (cboMode.SelectedValue.Equals("3"))
            {
                entity.Mode = "Delete";
                DoDelete(entity);
            }
        }
        private void DoInsert(multipurposeEntity mentity)
        {
            multipurposeBL mbl = new multipurposeBL();
            mbl.M_Multiporpose_Insert_Update(mentity);
        }
        private void DoUpdate(multipurposeEntity mentity)
        {
            multipurposeBL mbl = new multipurposeBL();
            mbl.M_Multiporpose_Insert_Update(mentity);
        }
        private void DoDelete(multipurposeEntity mentity)
        {
            multipurposeBL mbl = new multipurposeBL();
            mbl.M_Multiporpose_Insert_Update(mentity);
        }
        //private MasterTouroku_MultiPorpose GetData()
        //{
        //    multipurposeEntity mentity = new multipurposeEntity();
        //    mentity.IdName = txtIDName.Text;
        //    mentity.Char1 = txtChar1.Text;
        //    mentity.Char2 = txtChar2.Text;
        //    mentity.Char3 = txtChar3.Text;
        //    mentity.Char4 = txtChar4.Text;
        //    mentity.Char5 = txtChar5.Text;
        //    return mentity;
        //}
    }
}
