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
        public TokuisakiEntity Access_Tokuisaki_obj = new TokuisakiEntity();
        public TokuisakiDetail()
        {
            InitializeComponent();
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

            //Get Data from JuchuuNyuuroku form
            Access_DB_Object(Access_Tokuisaki_obj);
        }
        private void Access_DB_Object(TokuisakiEntity obj)
        {
            txtTokuisakiCD.Text = obj.TokuisakiCD;
            txtLong_Name.Text = obj.TokuisakiName;
            txtShort_Name.Text = obj.TokuisakiRyakuName;
            lblTokuisaki_Name.Text = obj.TokuisakiRyakuName;
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
                Access_Tokuisaki_obj.TokuisakiCD = txtTokuisakiCD.Text;
                Access_Tokuisaki_obj.TokuisakiName = txtLong_Name.Text;
                Access_Tokuisaki_obj.TokuisakiRyakuName = txtShort_Name.Text;
                Access_Tokuisaki_obj.YuubinNO1 = txtYubin1.Text;
                Access_Tokuisaki_obj.YuubinNO2 = txtYubin2.Text;
                Access_Tokuisaki_obj.Juusho1 = txtAddress1.Text;
                Access_Tokuisaki_obj.Juusho2 = txtAddress2.Text;
                Access_Tokuisaki_obj.Tel11 = txtPhone1_1.Text;
                Access_Tokuisaki_obj.Tel12 = txtPhone1_2.Text;
                Access_Tokuisaki_obj.Tel13 = txtPhone1_3.Text;
                Access_Tokuisaki_obj.Tel21 = txtPhone2_1.Text;
                Access_Tokuisaki_obj.Tel22 = txtPhone2_2.Text;
                Access_Tokuisaki_obj.Tel23 = txtPhone2_3.Text;
            }
            base.FunctionProcess(tagID);
        }
    }
}
