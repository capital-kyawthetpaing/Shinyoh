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
    public partial class KouritenDetail : SearchBase
    {
        public KouritenEntity Access_Kouriten_obj=new KouritenEntity();
        public KouritenDetail()
        {
            InitializeComponent();
        }
        private void KouritenDetail_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Search, F11, "", false);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);

            txtCD.Focus();

            txtShort_Name.E102Check(true);
            txtLong_Name.E102Check(true);
            txtYubin2.E102MultiCheck(true, txtYubin1, txtYubin2);
            txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, string.Empty, string.Empty);

            //Get Data from JuchuuNyuuroku form
            Access_DB_Object(Access_Kouriten_obj);
        }
        private void Access_DB_Object(KouritenEntity obj)
        {
            txtCD.Text = obj.KouritenCD;
            txtLong_Name.Text = obj.KouritenName;
            txtShort_Name.Text = obj.KouritenRyakuName;
            lbl_Name.Text = obj.KouritenRyakuName;
            txtYubin1.Text = obj.YuubinNO1;
            txtYubin2.Text = obj.YuubinNO2;
            txtAddress1.Text = obj.Juusho1;
            txtAddress2.Text = obj.Juusho2;
            txtPhone1_1.Text = obj.Tel11;
            txtPhone1_2.Text = obj.Tel12;
            txtPhone1_3.Text = obj.Tel13;
            txtPhone2_1.Text = obj.Tel21;
            txtPhone2_2.Text = obj.Tel22;
            txtPhone2_3.Text = obj.Tel23;
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "3")
            {
                Access_Kouriten_obj.KouritenCD = txtCD.Text;
                Access_Kouriten_obj.KouritenName = txtLong_Name.Text;
                Access_Kouriten_obj.KouritenRyakuName = txtShort_Name.Text;
                Access_Kouriten_obj.YuubinNO1 = txtYubin1.Text;
                Access_Kouriten_obj.YuubinNO2 = txtYubin2.Text;
                Access_Kouriten_obj.Juusho1 = txtAddress1.Text;
                Access_Kouriten_obj.Juusho2 = txtAddress2.Text;
                Access_Kouriten_obj.Tel11 = txtPhone1_1.Text;
                Access_Kouriten_obj.Tel12 = txtPhone1_2.Text;
                Access_Kouriten_obj.Tel13 = txtPhone1_3.Text;
                Access_Kouriten_obj.Tel21 = txtPhone2_1.Text;
                Access_Kouriten_obj.Tel22 = txtPhone2_2.Text;
                Access_Kouriten_obj.Tel23 = txtPhone2_3.Text;
            }
            base.FunctionProcess(tagID);
        }
    }
}
