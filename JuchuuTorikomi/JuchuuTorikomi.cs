using System;
using Shinyoh;
using Entity;
using BL;
using CKM_CommonFunction;
using System.Windows.Forms;
using Shinyoh_Controls;
using Shinyoh_Search;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace JuchuuTorikomi
{
    public partial class JuchuuTorikomi : BaseForm
    {
        CommonFunction cf;
        BaseEntity base_Entity;
        BaseBL bbl;
        JuchuuTorikomiBL JBL;
        JuchuuTorikomiEntity JEntity;
        DataTable dtMain;
        public JuchuuTorikomi()
        {
            InitializeComponent();
            cf = new CommonFunction();
            bbl = new BaseBL();
            JBL = new JuchuuTorikomiBL();
            JEntity = new JuchuuTorikomiEntity();
            dtMain = new DataTable();
        }

        private void JuchuuTorikomi_Load(object sender, EventArgs e)
        {
            ProgramID = "JuchuuTorikomi";
            StartProgram();
            cboMode.Visible = false;
            cboMode.Enabled = false;

            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "新規(F2)", false);
            SetButton(ButtonType.BType.Update, F3, "変更(F3)", false);
            SetButton(ButtonType.BType.Delete, F4, "削除(F4)", false);
            SetButton(ButtonType.BType.Inquiry, F5, "照会(F5)", false);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", false);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", true);
            SetButton(ButtonType.BType.Import, F10, "表示(F10)", true);
            SetButton(ButtonType.BType.Search, F11, "保存(F11)", false);
            SetButton(ButtonType.BType.Import, F12, "登録(F12)", true);

            base_Entity = _GetBaseData();
            BindData();
            Enable_Panel();
        }
        private void BindData()
        {
            multipurposeBL bl = new multipurposeBL();

            DataTable dt = bl.M_Multiporpose_SelectData(string.Empty, 3, string.Empty, string.Empty);

            if (dt.Rows.Count > 0)
            {
                txtImportFolder.Text = dt.Rows[0]["Char1"].ToString();
                txtImportFileName.Text = dt.Rows[0]["Char2"].ToString();
            }
            else
            {
                txtImportFolder.Text = string.Empty;
                txtImportFileName.Text = string.Empty;
            }
        }
        private void ErrorCheck()
        {
            txtImportFolder.E102Check(true);
            txtImportFileName.E102Check(true);
            txtDate1.E103Check(true);
            txtDate2.E103Check(true);
            txtDenpyouNO.E102Check(true);
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "6")
            {
                Clear();
            }
            if (tagID == "10")
            {
                GridviewBind();
            }
            base.FunctionProcess(tagID);
        }
        private void Clear()
        {
            rdo_Registration.Checked = true;
            BindData();
            txtDate1.Clear();
            txtDate2.Clear();
            txtDenpyouNO.Clear();
            gvJuchuuTorikomi.ClearSelection();
        }
        private void GridviewBind()
        {
            JEntity.TorikomiDenpyouNO = txtDenpyouNO.Text;
            dtMain = JBL.JuchuuTorikomi_Display(JEntity);
            gvJuchuuTorikomi.DataSource = dtMain;
        }
        private void Enable_Panel()
        {
            txtImportFolder.Enabled = true;
            txtImportFileName.Enabled = true;
            txtDate1.Enabled = false;
            txtDate2.Enabled = false;
            txtDenpyouNO.Enabled = false;
        }
        private void Disable_Panel()
        {
            txtImportFolder.Enabled = false;
            txtImportFolder.Text = string.Empty;
            txtImportFileName.Enabled = false;
            txtImportFileName.Text = string.Empty;
            txtDate1.Enabled = true;
            txtDate2.Enabled = true;
            txtDenpyouNO.Enabled = true;
        }
        private void rdo_Registration_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_Registration.Checked == true)
            {
                rdo_Delete.Checked = false;
                Enable_Panel();
            }
        }

        private void rdo_Delete_CheckedChanged(object sender, EventArgs e)
        {
            if(rdo_Delete.Checked==true)
            {
                rdo_Registration.Checked = false;
                Disable_Panel();
            }
        }
    }
}
