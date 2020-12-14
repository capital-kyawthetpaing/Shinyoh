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

namespace ShukkaNyuuryoku {
    public partial class TokuisakiDetail : SearchBase {
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

            //Get Data from ShukkaNyuuroku form
            Access_DB_Object(Access_Tokuisaki_obj);
        }
        //public void Datatable_Access(DataTable dt)
        //{
        //    txtShort_Name.Text = dt.Rows[0]["TokuisakiRyakuName"].ToString();
        //    txtLong_Name.Text = dt.Rows[0]["TokuisakiName"].ToString();
        //    txtYubin1.Text = dt.Rows[0]["YuubinNO1"].ToString();
        //    txtYubin2.Text = dt.Rows[0]["YuubinNO2"].ToString();
        //    txtAddress1.Text = dt.Rows[0]["Juusho1"].ToString();
        //    txtAddress2.Text = dt.Rows[0]["Juusho2"].ToString();
        //    txtPhone1_1.Text = dt.Rows[0]["Tel11"].ToString();
        //    txtPhone1_2.Text = dt.Rows[0]["Tel12"].ToString();
        //    txtPhone1_3.Text = dt.Rows[0]["Tel13"].ToString();
        //    txtPhone2_1.Text = dt.Rows[0]["Tel21"].ToString();
        //    txtPhone2_2.Text = dt.Rows[0]["Tel22"].ToString();
        //    txtPhone2_3.Text = dt.Rows[0]["Tel23"].ToString();
        //}
        private void Access_DB_Object(TokuisakiEntity obj)
        {
            txtTokuisakiCD.Text = obj.TokuisakiCD;
            lblTokuisaki_Name.Text = obj.TokuisakiRyakuName;
            txtShort_Name.Text = obj.TokuisakiRyakuName;
            txtLong_Name.Text = obj.TokuisakiName;
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
    }
}
