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
            SetButton(ButtonType.BType.Close, F1, "F1(終了)");
            SetButton(ButtonType.BType.New, F2, "F2(新規)");
            SetButton(ButtonType.BType.Update, F3, "F3(変更)");
            SetButton(ButtonType.BType.Delete, F4, "F4(削除)");
            SetButton(ButtonType.BType.Inquiry, F5, "F5(照会)");
            SetButton(ButtonType.BType.Cancel, F6, "F6(ｷｬﾝｾﾙ)");
            SetButton(ButtonType.BType.Search, F9, "F9(検索)");
            SetButton(ButtonType.BType.Save, F12, "F12(登録)");
            SetButton(ButtonType.BType.Empty, F7, "");
            SetButton(ButtonType.BType.Empty, F8, "");
            SetButton(ButtonType.BType.Empty, F10, "");
            SetButton(ButtonType.BType.Empty, F11, "");
        }

        private void cboName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = cboName.SelectedIndex.ToString();
            if (item == "1" || item == "0")
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
        private void cboName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                cboName.Focus();
                if (cboName.SelectedIndex > 0)
                {
                    cboName.DroppedDown = true;
                }
            }
        }
    }
}
