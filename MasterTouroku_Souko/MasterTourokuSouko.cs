using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shinyoh;
using Entity;
using Shinyoh_Controls;

namespace MasterTouroku_Souko
{
    public partial class MasterTourokuSouko : BaseForm
    {
        ButtonType type = new ButtonType();
        public MasterTourokuSouko()
        {
            InitializeComponent();
        }
        private void MasterTourokuSouko_Load(object sender, EventArgs e)
        {
            ProgramID = "MasterTourokuSouko";
            StartProgram();
            cboName.Bind(false);
            SetButton(ButtonType.BType.Close, F1, "F1(終了)",true);
            SetButton(ButtonType.BType.New, F2, "F2(新規)",true);
            SetButton(ButtonType.BType.Update, F3, "F3(変更)",true);
            SetButton(ButtonType.BType.Delete, F4, "F4(削除)",true);
            SetButton(ButtonType.BType.Inquiry, F5, "F5(照会)",true);
            SetButton(ButtonType.BType.Cancel, F6, "F6(ｷｬﾝｾﾙ)",true);
            SetButton(ButtonType.BType.Search, F9, "F9(検索)",false);
            SetButton(ButtonType.BType.Save, F12, "F12(登録)",true);
            SetButton(ButtonType.BType.Empty, F7, "",false);
            SetButton(ButtonType.BType.Empty, F8, "",false);
            SetButton(ButtonType.BType.Empty, F10, "",false);
            SetButton(ButtonType.BType.Empty, F11, "",false);
        }

        private void cboName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = cboName.SelectedIndex.ToString();
            if (item == "0")
            {
                txtSouko.Enabled = true;
                txtCopySouko.Enabled = true;
            }
            else
            {
                txtCopySouko.Enabled = false;
                txtSouko.Enabled = true;
            }
        }
    }
}
