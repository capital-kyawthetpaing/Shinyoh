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
            cbDivision.Focus();
        }

        private void ChangeMode(Mode mode)
        {
            cf.Clear(PanelTitle);
            cf.Clear(PanelDetail);
            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(PanelDetail);
            switch (mode)
            {
                case Mode.New:
                    break;
                case Mode.Update:
                    break;
                case Mode.Delete:
                    break;
                case Mode.Inquiry:
                    break;
            }
        }

    }
}
