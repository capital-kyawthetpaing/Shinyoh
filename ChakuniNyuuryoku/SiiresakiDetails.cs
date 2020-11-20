using BL;
using Entity;
using Shinyoh;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ChakuniNyuuryoku
{
    public partial class SiiresakiDetails :SearchBase
    {
        public SiiresakiDetails()
        {
            InitializeComponent();
        }

        private void SiiresakiDetails_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);

            sbSupplier.Focus();
        }
    }
}
