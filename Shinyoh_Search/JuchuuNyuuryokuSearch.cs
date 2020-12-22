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

namespace Shinyoh_Search
{
    public partial class JuchuuNyuuryokuSearch : SearchBase
    {
        public JuchuuNyuuryokuSearch()
        {
            InitializeComponent();
        }

        private void JuchuuNyuuryokuSearch_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);

            txtDate1.Focus();
            txtDate1.E103Check(true);
            txtDate2.E103Check(true);
            txtDate2.E104Check(true, txtDate1, txtDate2);
            
            gv_1.UseRowNo(true);
        }
    }
}
