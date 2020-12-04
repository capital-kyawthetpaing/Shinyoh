using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Shinyoh;
using Shinyoh_Controls;
using Shinyoh_Search;

namespace Shinyoh_Search
{
    public partial class ShippingNoSearch : SearchBase
    {
        public string ShippingNo= string.Empty;
        public string changeDate = string.Empty;
        public string changeDate_Access = string.Empty;
        public ShippingNoSearch()
        {
            InitializeComponent();
        }

        public void ShippingNoSearch_Load(object sender,EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);

            gvShippingNo.UseRowNo(true);
            GridViewBind();
            txtDateFrom.Focus();
            txtDateFrom.E103Check(true);
            txtDateTo.E103Check(true);
            txtShippingNoFrom.E103Check(true);
            txtShippingNoTo.E103Check(true);
            txtProductTo.E106Check(true, txtProductFrom, txtProductTo);
            sbStaff.E101Check(true, "staff", null, null, null);
        }

        public override void FunctionProcess(string tagID)
        {
            if (tagID == "2")
            {
                GridViewBind();
            }
            if (tagID == "3")
            {
                DataGridViewRow row = gvShippingNo.CurrentRow;
            }
            base.FunctionProcess(tagID);
        }

        private void GridViewBind()
        {

        }

    }
}
