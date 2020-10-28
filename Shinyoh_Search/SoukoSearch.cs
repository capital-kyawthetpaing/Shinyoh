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
        private void btnF11_Click(object sender, EventArgs e)
        {
            SoukoBL bl = new SoukoBL();
            SoukoEntity soukoEntity = new SoukoEntity();
            DataTable dt= bl.Souko_Search(soukoEntity);
            gvSouko.DataSource = dt;
        }
    }
}
