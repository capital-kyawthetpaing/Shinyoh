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

namespace MasterTouroku_Tokuisaki {
    public partial class MasterTouroku_Tokuisaki : BaseForm {
        public MasterTouroku_Tokuisaki()
        {
            InitializeComponent();
        }

        private void MasterTouroku_Tokuisaki_Load(object sender, EventArgs e)
        {
            ProgramID = "MasterTourokuTokuisaki";
            StartProgram();
            cboMode.Bind(false);
            txt_Tokuisaki.Focus();
        }
    }
}
