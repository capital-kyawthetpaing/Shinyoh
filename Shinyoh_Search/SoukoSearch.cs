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
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);

            GetDatatable();
        }
        
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "2")
            {
                GetDatatable();
            }
            if (tagID == "3")
            {
               
                
            }
            base.FunctionProcess(tagID);
        }
        private void GetDatatable()
        {
            SoukoBL bl = new SoukoBL();
            SoukoEntity soukoEntity = new SoukoEntity();
            DataTable dt = bl.Souko_Search(soukoEntity);
            gvSouko.DataSource = dt;
        }

        private void BtnF11_Soko_Click(object sender, EventArgs e)
        {
            FunctionProcess(BtnF11_Soko.Tag.ToString());
        }

        private void gvSouko_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gvSouko.Rows[e.RowIndex];
                //SokoCD = row.Cells[0].Value.ToString();
                //SouKoName = row.Cells[1].Value.ToString();
            }
        }
    }
}
