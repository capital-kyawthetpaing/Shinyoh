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

namespace MasterTouroku_Siiresaki
{
    public partial class MasterTourokuSiiresaki : BaseForm
    {
        public MasterTourokuSiiresaki()
        {
            InitializeComponent();
        }

        private void MasterTourokuSiiresaki_Load(object sender, EventArgs e)
        {
            ProgramID = "MasterTourokuSiiresaki";
            StartProgram();

        }
    }
}
