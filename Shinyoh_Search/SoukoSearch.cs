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

        public string soukoCD = string.Empty;
        public string soukoName = string.Empty;

        public SoukoSearch()
        {
            InitializeComponent();
        }
        
        private void SoukoSearch_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);

            gvSouko.UseRowNo(true);
            GridViewBind();
            txtSouko2.E106Check(true, txtSouko1, txtSouko2);
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "2")
            {
                GridViewBind();
            }
            if (tagID == "3")
            {
                DataGridViewRow row = gvSouko.CurrentRow;
                GetGridviewData(row);
            }
            base.FunctionProcess(tagID);
        }
        private void GridViewBind()
        {
            SoukoBL bl = new SoukoBL();
            SoukoEntity soukoEntity = new SoukoEntity();
            soukoEntity.SoukoCD = txtSouko1.Text;
            soukoEntity.Tel11 = txtSouko2.Text; //for temp value
            soukoEntity.SoukoName = txtSoukoName.Text;
            soukoEntity.KanaName = txtKanaName.Text;
            DataTable dt = bl.Souko_Search(soukoEntity);
            gvSouko.DataSource = dt;
        }

        private void BtnF11_Soko_Click(object sender, EventArgs e)
        {
            FunctionProcess(BtnF11_Soko.Tag.ToString());
            GridViewBind();
        }
        private void GetGridviewData(DataGridViewRow gvrow)
        {
            if (gvrow.DataBoundItem != null)
            {
                DataGridViewRow row = gvrow;
                soukoCD= row.Cells["colSouko"].Value.ToString();
                soukoName = row.Cells["colSoukoName"].Value.ToString();
                this.Close();
            }
        }
        private void gvSouko_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetGridviewData(gvSouko.Rows[e.RowIndex]);
        }
    }
}
