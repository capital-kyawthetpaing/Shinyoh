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

namespace HikiateHenkouShoukai_New
{
    public partial class HikiateHenkouShoukai_New : BaseForm
    {
        multipurposeEntity multi_Entity;
        public HikiateHenkouShoukai_New()
        {
            InitializeComponent();
        }

        private void HikiateHenkouShoukai_New_Load(object sender, EventArgs e)
        {
            ProgramID = "HikiateHenkouShoukai_New";
            StartProgram();
            cboMode.Bind(false, multi_Entity);
        }
    }
}
