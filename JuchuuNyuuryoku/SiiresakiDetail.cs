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
    public partial class SiiresakiDetail : SearchBase
    {
        public SiiresakiEntity Access_Siiresaki_obj = new SiiresakiEntity();
        public SiiresakiDetail()
        {
            InitializeComponent();
        }

        private void SiiresakiDetail_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Search, F11, "", false);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);
            lbl_Name.BorderStyle= System.Windows.Forms.BorderStyle.None;

            txtCD.Focus();

            txtShort_Name.E102Check(true);
            txtLong_Name.E102Check(true);
            txtYubin2.E102MultiCheck(true, txtYubin1, txtYubin2);
            txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, string.Empty, string.Empty);

            //Get Data from JuchuuNyuuroku form
            Access_DB_Object(Access_Siiresaki_obj);
        }
        private void Access_DB_Object(SiiresakiEntity obj)
        {
            txtCD.Text = obj.SiiresakiCD;
            txtLong_Name.Text = obj.SiiresakiName;
            txtShort_Name.Text = obj.SiiresakiRyakuName;
            lbl_Name.Text = obj.SiiresakiRyakuName;
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
                Access_Siiresaki_obj.SiiresakiCD = txtCD.Text;
                Access_Siiresaki_obj.SiiresakiName = txtLong_Name.Text;
                Access_Siiresaki_obj.SiiresakiRyakuName = txtShort_Name.Text;
                Access_Siiresaki_obj.YuubinNO1 = txtYubin1.Text;
                Access_Siiresaki_obj.YuubinNO2 = txtYubin2.Text;
                Access_Siiresaki_obj.Juusho1 = txtAddress1.Text;
                Access_Siiresaki_obj.Juusho2 = txtAddress2.Text;
                Access_Siiresaki_obj.Tel11 = txtPhone1_1.Text;
                Access_Siiresaki_obj.Tel12 = txtPhone1_2.Text;
                Access_Siiresaki_obj.Tel13 = txtPhone1_3.Text;
                Access_Siiresaki_obj.Tel21 = txtPhone2_1.Text;
                Access_Siiresaki_obj.Tel22 = txtPhone2_2.Text;
                Access_Siiresaki_obj.Tel23 = txtPhone2_3.Text;

                this.Close();
            }
            base.FunctionProcess(tagID);
        }
    }
}
