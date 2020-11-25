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
            SetButton(ButtonType.BType.Search, F11, "", false);
            sbSupplier.Focus();
        }
        private void ErrorCheck()
        {
            txtSupplierCD.E102Check(true);
            txtSupplierName.E102Check(true);
            txtYubin2.E102MultiCheck(true, txtYubin1, txtYubin2);
            txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, string.Empty, string.Empty);
        }
        private void YuubinNO2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtYubin2.IsErrorOccurs && txtYubin2.IsDatatableOccurs.Rows.Count > 0)
                {
                    DataTable dt = txtYubin2.IsDatatableOccurs;
                    txtAddress1.Text = dt.Rows[0]["Juusho1"].ToString();
                    txtAddress2.Text = dt.Rows[0]["Juusho2"].ToString();
                }
            }
        }
    }
}
