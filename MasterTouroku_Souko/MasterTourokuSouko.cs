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

namespace MasterTouroku_Souko
{
    public partial class MasterTourokuSouko : BaseForm
    {
        public MasterTourokuSouko()
        {
            InitializeComponent();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                tb.BackColor = Color.Silver;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                tb.BackColor = Color.White;
            }
        }

        private void MasterTourokuSouko_Load(object sender, EventArgs e)
        {
            ProgramID = "MasterTourokuSouko";
            StartProgram();
            cboName.Bind();
            SetButton(ButtonType.Close,F1, "F1(終了)");
            SetButton(ButtonType.Save, F2, "F2(新規)");
            SetButton(ButtonType.Update, F3,"F3(変更)");
            SetButton(ButtonType.Delete, F4, "F4(削除)");
            SetButton(ButtonType.Inquiry, F5, "F5(照会)");
            SetButton(ButtonType.Cancel, F6, "F6(ｷｬﾝｾﾙ)");
            SetButton(ButtonType.Search, F9, "F9(検索)");
            SetButton(ButtonType.Insert, F12, "F12(登録)");
            SetButton(ButtonType.Empty, F7, "");
            SetButton(ButtonType.Empty, F8, "");
            SetButton(ButtonType.Empty, F10, "");
            SetButton(ButtonType.Empty, F11, "");


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
    }
}
