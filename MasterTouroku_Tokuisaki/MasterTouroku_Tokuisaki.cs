using Entity;
using Shinyoh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterTouroku_Tokuisaki {
    public partial class MasterTouroku_Tokuisaki : BaseForm {
        public MasterTouroku_Tokuisaki()
        {
            InitializeComponent();
        }

        private void MasterTouroku_Tokuisaki_Load(object sender, EventArgs e)
        {
            ProgramID = "MasterTourokuTokuisaki";
            StartProgram();
            cboMode.Bind(false);
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
            txt_Tokuisaki.Focus();
        }
    }
}
