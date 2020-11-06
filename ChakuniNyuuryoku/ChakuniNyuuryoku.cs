using System;
using Shinyoh;
using Entity;
using BL;
using CKM_CommonFunction;
using System.Windows.Forms;
using Shinyoh_Controls;
using Shinyoh_Search;
using System.Data;

namespace ChakuniNyuuryoku
{
    public partial class ChakuniNyuuryoku : BaseForm
    {
        CommonFunction cf;
        public ChakuniNyuuryoku()
        {
            InitializeComponent();
            cf = new CommonFunction();
        }

        private void ChakuniNyuuryoku_Load(object sender, EventArgs e)
        {
            ProgramID = "ChakuniNyuuryoku";
            StartProgram();
            cboMode.Bind(false);
            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "新規(F2)", true);
            SetButton(ButtonType.BType.Update, F3, "変更(F3)", true);
            SetButton(ButtonType.BType.Delete, F4, "削除(F4)", true);
            SetButton(ButtonType.BType.Inquiry, F5, "照会(F5)", true);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", true);
            SetButton(ButtonType.BType.Display, F10, "表示(F10)", true);
            SetButton(ButtonType.BType.Search, F11, "保存(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            ChangeMode(Mode.New);
            txtArrivalNO.Focus();
        }
        private void ChangeMode(Mode mode)
        {
            cf.Clear(PanelTitle);
            cf.Clear(panelDetails);
            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(panelDetails);
            txtArrivalNO.Focus();
            switch (mode)
            {
                case Mode.New:
                    txtArrivalDate.E102Check(true);
                    txtArrivalDate.E103Check(true);
                    sbSupplier.E102Check(true);

                    break;
            }
        }
    }
}
