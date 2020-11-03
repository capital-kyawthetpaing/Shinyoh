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
    public partial class StaffSearch : SearchBase
    {
        public StaffSearch()
        {
            InitializeComponent();
        }

        private void StaffSearch_Load(object sender, EventArgs e)
        {
            txtStaff1.Focus();
        }

        private void txtStaff2_KeyDown(object sender, KeyEventArgs e)
        {
            txtStaff2.E106Check(true, txtStaff1, txtStaff2);
        }
    }
}
