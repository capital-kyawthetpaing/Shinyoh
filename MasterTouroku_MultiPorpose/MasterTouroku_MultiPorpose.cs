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
        multipurposeEntity mentity;
        BaseEntity base_Entity;
        multipurposeBL mbl;
        public MasterTouroku_MultiPorpose()
        {
            InitializeComponent();
            cf = new CommonFunction();
            bbl = new BaseBL();
            mbl = new multipurposeBL();
        }

        private void MasterTouroku_MultiPorpose_Load(object sender, EventArgs e)
        {
            ProgramID = "MasterTouroku_MultiPorpose";
            StartProgram();
            cboMode.Bind(false, mentity);
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
            SetButton(ButtonType.BType.Empty, F10, "", false);
            SetButton(ButtonType.BType.Empty, F11, "", false);
            ChangeMode(Mode.New);
            base_Entity = _GetBaseData();
            txtID.Focus();
            txtKEY.ChangeDate = txtIDName;
            txtKEYCopy.ChangeDate = txtIDName;

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
                Mode_Setting();
                if (cboMode.SelectedValue.Equals("2") || cboMode.SelectedValue.Equals("3") || cboMode.SelectedValue.Equals("4"))
                {
                    Disable_UDI_Mode();
                }
            }
            if (tagID == "12")
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
            base.FunctionProcess(tagID);
        }
        private void ChangeMode(Mode mode)
        {
            Mode_Setting();
            switch (mode)
            {
                case Mode.New:
                    txtID.E102Check(true);
                    txtKEY.E102Check(true);
                    txtIDName.E102Check(true);
                    txtDate1.E103Check(true);
                    txtDate2.E103Check(true);
                    txtDate3.E103Check(true);
                    txtKEY.E132Check(false, "M_Multiporpose", txtID, txtKEY, null);
                    cf.Clear(PanelTitle);
                    cf.Clear(PanelDetail);
                    cf.EnablePanel(PanelTitle);
                    cf.DisablePanel(PanelDetail);
                    txtID.Enabled = true;
                    txtCopyID.Enabled = true;
                    txtKEYCopy.NextControlName = txtIDName.Name;
                    txtID.Focus();

                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    break;

                case Mode.Update:
                    txtID.E102Check(true);
                    txtKEY.E102Check(true);
                    txtIDName.E102Check(true);
                    txtDate1.E103Check(true);
                    txtDate2.E103Check(true);
                    txtDate3.E103Check(true);
                    Mode_Setting();
                    Disable_UDI_Mode();
                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    txtID.E102Check(true);
                    txtKEY.E102Check(true);
                    txtKEY.E132Check(false, "M_Multiporpose", txtID, txtKEY, null);
                    Mode_Setting();
                    Disable_UDI_Mode();
                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;

                    break;
                case Mode.Inquiry:
                    txtID.E102Check(true);
                    txtKEY.E102Check(true);
                    txtIDName.E102Check(true);
                    Mode_Setting();
                    Disable_UDI_Mode();
                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;
                    break;
            }
        }
        private void Mode_Setting()
        {
            cf.Clear(PanelTitle);
            cf.Clear(PanelDetail);
            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(PanelDetail);
            txtID.Focus();
        }
        public void Disable_UDI_Mode()
        {
            txtCopyID.Enabled = false;
            txtKEYCopy.Enabled = false;
        }
        private void DisplayData(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                txtIDName.Text = dt.Rows[0]["IDName"].ToString();
                txtChar1.Text = dt.Rows[0]["Char1"].ToString();
                txtChar2.Text = dt.Rows[0]["Char2"].ToString();
                txtChar3.Text = dt.Rows[0]["Char3"].ToString();
                txtChar4.Text = dt.Rows[0]["Char4"].ToString();
                txtChar5.Text = dt.Rows[0]["Char5"].ToString();
                txtNum1.Text= dt.Rows[0]["Num1"].ToString();
                txtNum2.Text = dt.Rows[0]["Num2"].ToString();
                txtNum3.Text = dt.Rows[0]["Num3"].ToString();
                txtNum4.Text = dt.Rows[0]["Num4"].ToString();
                txtNum5.Text = dt.Rows[0]["Num5"].ToString();
                txtDate1.Text = dt.Rows[0]["Date1"].ToString();
                txtDate2.Text = dt.Rows[0]["Date2"].ToString();
                txtDate3.Text = dt.Rows[0]["Date3"].ToString();
            }
        }
        private void DBProcess()
        {
           multipurposeEntity entity = GetData();
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
            mbl.M_Multiporpose_Insert_Update(mentity);
        }
        private void DoUpdate(multipurposeEntity mentity)
        {
           mbl.M_Multiporpose_Insert_Update(mentity);
        }
        private void DoDelete(multipurposeEntity mentity)
        {
           mbl.M_Multiporpose_Insert_Update(mentity);
        }
        private multipurposeEntity GetData()
        {
            multipurposeEntity mentity = new multipurposeEntity();
            mentity.ID = txtID.Text;
            mentity.Key = txtKEY.Text;
            mentity.IdName = txtIDName.Text;
            mentity.Char1 = txtChar1.Text;
            mentity.Char2 = txtChar2.Text;
            mentity.Char3 = txtChar3.Text;
            mentity.Char4 = txtChar4.Text;
            mentity.Char5 = txtChar5.Text;
            mentity.Num1 = txtNum1.Text;
            mentity.Num2 = txtNum2.Text;
            mentity.Num3 = txtNum3.Text;
            mentity.Num4 = txtNum4.Text;
            mentity.Num5 = txtNum5.Text;
            mentity.Date1 = txtDate1.Text;
            mentity.Date2 = txtDate2.Text;
            mentity.Date3 = txtDate3.Text;
            mentity.InsertOperator = base_Entity.OperatorCD;
            mentity.UpdateOperator = base_Entity.OperatorCD;
            mentity.PC = base_Entity.PC;
            mentity.ProgramID = base_Entity.ProgramID;
            mentity.KeyItem = txtID.Text + " " + txtKEY.Text;
            return mentity;
        }
        private void txtKEY_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtKEY.IsErrorOccurs)
                {
                    if (cboMode.SelectedValue.ToString() == "2")//update
                    {
                        cf.EnablePanel(PanelDetail);
                        txtIDName.Focus();
                        cf.DisablePanel(PanelTitle);
                    }
                    else if (cboMode.SelectedValue.ToString() == "3" || cboMode.SelectedValue.ToString() == "4")
                    {
                        cf.DisablePanel(PanelTitle);
                        Control BtnF9 = this.TopLevelControl.Controls.Find("BtnF9", true)[0];
                        BtnF9.Visible = false;
                    }
                }
                DataTable dt = new DataTable();
                GetData();
                dt = mbl.M_Multiporpose_SelectData(string.Empty,2,txtID.Text, txtKEY.Text);
                if (dt.Rows.Count > 0 && cboMode.SelectedValue.ToString() != "1")
                {
                   DisplayData(dt);
                }
            }
        }

        private void txtKEYCopy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cboMode.SelectedValue.ToString() == "1")
            {
                DataTable dt = new DataTable();
                multipurposeEntity mentity = new multipurposeEntity();
                mentity.ID = txtCopyID.Text;
                mentity.Key = txtKEYCopy.Text;
                dt = mbl.M_Multiporpose_SelectData(string.Empty, 2, txtCopyID.Text, txtKEYCopy.Text);
                if (dt.Rows.Count > 0)
                {
                    DisplayData(dt);
                }
                cf.EnablePanel(PanelDetail);
                txtIDName.Focus();
                cf.DisablePanel(PanelTitle);
            }
        }
    }
}
