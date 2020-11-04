using BL;
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

namespace Shinyoh_Search {
    public partial class SoukoSearch : SearchBase {
        public SoukoSearch()
        {
            InitializeComponent();
        }
        SoukoBL bl = new SoukoBL();
        SoukoEntity soukoEntity = new SoukoEntity();
        private void SoukoSearch_Load(object sender, EventArgs e)
        {
            txtSouko1.Focus();
            DataTable dt = bl.Souko_Search(soukoEntity);
            gvSouko.DataSource = dt;
        }
        private void btnF11_Click(object sender, EventArgs e)
        {
            soukoEntity.SoukoCD = txtSouko1.Text;
            soukoEntity.FaxNO = txtSouko2.Text;
            soukoEntity.SoukoName = txtSoukoName.Text;
            soukoEntity.KanaName = txtKanaName.Text;
            DataTable dt = bl.Souko_Search(soukoEntity);
            gvSouko.DataSource = dt;
        }
        private void txtSouko2_KeyDown(object sender, KeyEventArgs e)
        {
            txtSouko2.E106Check(true, txtSouko1, txtSouko2);
        }
    }
}
