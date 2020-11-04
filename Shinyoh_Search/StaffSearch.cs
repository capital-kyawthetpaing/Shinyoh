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

namespace Shinyoh_Search
{
    public partial class StaffSearch : SearchBase
    {
        public string staffCD = string.Empty;
        public string changeDate = string.Empty;
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

        private void btnStaff_F11_Click(object sender, EventArgs e)
        {
            MasterTourokuStaff obj = new MasterTourokuStaff();
            obj.StaffCD = txtStaff1.Text;
            obj.Passward = txtStaff2.Text;//using tempory for assign data
            obj.StaffName = txtStaffName.Text;
            obj.KanaName = txtKanaName.Text;

            StaffBL objMethod = new StaffBL();
            DataTable dt=  objMethod.Staff_Search(obj);
            gvStaff.DataSource = dt;
        }
    }
}
