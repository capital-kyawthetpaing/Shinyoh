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

namespace MasterTouroku_Kouriten
{
    public partial class MasterTourokuKouriten : BaseForm
    {
        multipurposeEntity multi_Entity ;
        public MasterTourokuKouriten()
        {
            InitializeComponent();
        }

        private void MasterTourokuKouriten_Load(object sender, EventArgs e)
        {
            ProgramID = "MasterTourokuKouriten";
            StartProgram();
            cboMode.Bind(false, multi_Entity);
        }
    }
}
