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

            //ChangeMode(Mode.New);
            txtID.Focus();
        }
    }
}
