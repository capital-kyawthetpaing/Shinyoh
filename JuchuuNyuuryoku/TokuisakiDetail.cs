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

namespace JuchuuNyuuryoku
{
    public partial class TokuisakiDetail : SearchBase
    {
        public TokuisakiDetail()
        {
            InitializeComponent();
        }
        public void Datatable_Access(DataTable dt)
        {
            txtShort_Name.Text = dt.Rows[0]["SiiresakiRyakuName"].ToString();
            txtLong_Name.Text= dt.Rows[0]["SiiresakiName"].ToString();
            txtYubin1.Text= dt.Rows[0]["YuubinNO1"].ToString(); 
            txtYubin2.Text= dt.Rows[0]["YuubinNO2"].ToString();
            txtAddress1.Text= dt.Rows[0]["Juusho1"].ToString();
            txtAddress2.Text= dt.Rows[0]["Juusho2"].ToString();
            txtPhone1_1.Text= dt.Rows[0]["Tel11"].ToString();
            txtPhone1_2.Text= dt.Rows[0]["Tel12"].ToString();
            txtPhone1_3.Text= dt.Rows[0]["Tel13"].ToString();
            txtPhone2_1.Text= dt.Rows[0]["Tel21"].ToString();
            txtPhone2_2.Text=dt.Rows[0]["Tel22"].ToString();
            txtPhone2_3.Text= dt.Rows[0]["Tel23"].ToString();
        }
        private void TokuisakiDetail_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Search, F11, "", false);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);

            txtTokuisakiCD.Focus();

            txtShort_Name.E102Check(true);
            txtLong_Name.E102Check(true);
            txtYubin2.E102MultiCheck(true, txtYubin1, txtYubin2);
            txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, string.Empty, string.Empty);
        }
    }
}
