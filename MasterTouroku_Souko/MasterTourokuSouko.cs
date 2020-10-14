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
              SetButton(ButtonType.Insert,F1, "F1(新規)");
              SetButton(ButtonType.Update, F2,"F2(変更)");
              SetButton(ButtonType.Delete, F3, "F3(削除)");
              SetButton(ButtonType.Inquiry, F4, "F4(照会)");
              SetButton(ButtonType.Print, F5, "F5(印刷)");
        }

        private void cboName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = cboName.SelectedIndex.ToString();
            if (item == "1")
            {
                txtSouko.Enabled = true;
                txtCopySouko.Enabled = true;
            }
            else
            {
                txtSouko.Enabled = true;
                txtCopySouko.Enabled = false;

            }
        }
    }
}
