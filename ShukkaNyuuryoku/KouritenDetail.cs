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
    public partial class KouritenDetail : SearchBase {
        public KouritenEntity Access_Kouriten_obj = new KouritenEntity();
        string YuuBinNO1 = string.Empty;
        string YuuBinNO2 = string.Empty;
        string Address1 = string.Empty;
        string Address2 = string.Empty;
        public KouritenDetail()
        {
            InitializeComponent();
        }
        private void KouritenDetail_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Search, F11, "", false);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);

            txtKouritenCD.Focus();

            txtShort_Name.E102Check(true);
            txtLong_Name.E102Check(true);
            txtYubin2.E102MultiCheck(true, txtYubin1, txtYubin2);
            txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, string.Empty, string.Empty);

            //Get Data from JuchuuNyuuroku form
            Access_DB_Object(Access_Kouriten_obj);
        }
        //public void Datatable_Access(DataTable dt)
        //{
        //    txtShort_Name.Text = dt.Rows[0]["KouritenRyakuName"].ToString();
        //    txtLong_Name.Text = dt.Rows[0]["KouritenName"].ToString();
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

        private void Access_DB_Object(KouritenEntity obj)
        {
            txtKouritenCD.Text = obj.KouritenCD;
            lblKouriten_Name.Text = obj.KouritenRyakuName;
            txtLong_Name.Text = obj.KouritenName;
            txtShort_Name.Text = obj.KouritenRyakuName;
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

        private void txtYubin2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtYubin2.IsErrorOccurs)
                {
                    if (txtYubin2.IsDatatableOccurs.Rows.Count > 0)
                    {
                        DataTable dt = txtYubin2.IsDatatableOccurs;
                        txtAddress1.Text = dt.Rows[0]["Juusho1"].ToString();
                        txtAddress2.Text = dt.Rows[0]["Juusho2"].ToString();
                    }
                    else
                    {
                        if (txtYubin1.Text != YuuBinNO1 || txtYubin2.Text != YuuBinNO2)
                        {
                            txtAddress1.Text = string.Empty;
                            txtAddress2.Text = string.Empty;
                        }
                        else
                        {
                            txtAddress1.Text = Address1;
                            txtAddress2.Text = Address2;
                        }
                    }
                }
            }
        }
    }
}
