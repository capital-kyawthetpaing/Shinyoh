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

            //txtShort_Name.E102Check(true);
            //txtLong_Name.E102Check(true);
            //txtYubin2.E102MultiCheck(true, txtYubin1, txtYubin2);
            //txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, string.Empty, string.Empty);

            ////Get Data from JuchuuNyuuroku form
            //Access_DB_Object(Access_Kouriten_obj);
        }
    }
}
