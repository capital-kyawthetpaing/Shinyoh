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
        public SiiresakiEntity Access_Siiresaki_obj = new SiiresakiEntity();
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
            txtSupplierCD.E102Check(true);
            txtSupplierName.E102Check(true);
            txtYubin2.E102MultiCheck(true, txtYubin1, txtYubin2);
            txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, string.Empty, string.Empty);
            Access_DB_Object(Access_Siiresaki_obj);
        }
        private void Access_DB_Object(SiiresakiEntity obj)
        {
            sbSupplier.Text = obj.SiiresakiCD;
            txtSupplierCD.Text = obj.SiiresakiName;
            txtSupplierName.Text = obj.SiiresakiRyakuName;
            lbl_Name.Text = obj.SiiresakiRyakuName;
            txtYubin1.Text = obj.YuubinNO1;
            txtYubin2.Text = obj.YuubinNO2;
            txtAddress1.Text = obj.Juusho1;
            txtAddress2.Text = obj.Juusho2;
            txtPhNo1.Text = obj.Tel11;
            txtPhNo2.Text = obj.Tel12;
            txtPhNo3.Text = obj.Tel13;
            txtPhNo4.Text = obj.Tel21;
            txtPhNo5.Text = obj.Tel22;
            txtPhNo6.Text = obj.Tel23;
        }
    }
}
