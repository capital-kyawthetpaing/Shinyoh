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

        private void ShippingNoSearch_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);
            lblCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblStaffName.BorderStyle = System.Windows.Forms.BorderStyle.None;

            gvShippingNo.UseRowNo(true);
            GridViewBind();
            txtShippingDateFrom.Focus();
            txtShippingDateFrom.E103Check(true);
            txtShippingDateTo.E103Check(true);
            txtShippingNoFrom.E103Check(true);
            txtShippingNoTo.E103Check(true);
            txtProductTo.E106Check(true, txtProductFrom, txtProductTo);
            sbStaff.E101Check(true, "staff", null, null, null);
            txtShippingDateFrom.Focus();
            //出荷予定日            
            txtShippingDateFrom.E103Check(true);
            txtShippingDateTo.E103Check(true);
            txtShippingDateTo.E106Check(true, txtShippingDateFrom, txtShippingDateTo);
            //得意先
            sbCustomer.E101Check(true, "Shipping", null, null, null);
            //担当スタッフ
            sbStaff.E101Check(true, "M_Staff", null, null, null);
            //伝票日付
            txtSlipDateFrom.E103Check(true);
            txtSlipDateTo.E103Check(true);
            txtSlipDateTo.E106Check(true, txtSlipDateFrom, txtSlipDateTo);
            //出荷指示番号
            txtShippingNoTo.E106Check(true, txtShippingNoFrom, txtShippingNoTo);
            //商品CD
            txtProductTo.E106Check(true, txtProductFrom, txtProductTo);
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
