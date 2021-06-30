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

            if (rdoAggregation.Checked)
                Radio_Changed(0);
        }
        private void rdoAggregation_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAggregation.Checked)
                Radio_Changed(0);
        }

        private void rdoDetails_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDetails.Checked)
                Radio_Changed(1);
        }

        private void rdoFreeInventory_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFreeInventory.Checked)
                Radio_Changed(2);
        }
        private void Radio_Changed(int type)
        {
           // cf.Clear(PanelDetail);
            lblBrandName.Text = string.Empty;
            lblKouritenName.Text = string.Empty;
            lblSoukoName.Text = string.Empty;
            lblTokuisakiName.Text = string.Empty;

           // initScr();

            switch (type)
            {
                case 0:
                    txtTokuisakiCD.Enabled = true;
                    txtKouritenCD.Enabled = true;
                    txtPostalCode1.Enabled = true;
                    txtPostalCode2.Enabled = true;
                    txtPhoneNo1.Enabled = true;
                    txtPhoneNo2.Enabled = true;
                    txtPhoneNo3.Enabled = true;
                    txtName.Enabled = true;
                    txtAddress.Enabled = true;
                    txtChakuniYoteiNO.Enabled = true;
                    this.txtSoukoCD.NextControlName = txtChakuniYoteiNO.Name;
                    chkType1.Enabled = true;
                    chkType2.Enabled = true;
                    F7.Enabled = false;
                    F8.Enabled = false;
                    F11.Enabled = false;
                    F12.Enabled = false;
                    btn_F8.Enabled = false;
                    btn_F11.Enabled = false;
                    gvAggregationDetails.Visible = true;
                    gvMainDetail.Visible = false;
                   // gvFreeInventoryDetails.Visible = false;
                   // gvAggregationDetails.Location = new Point(49, 262);
                   // gvAggregationDetails.Size = new Size(1430, 565);
                    //this.gvAggregationDetails.Size = new System.Drawing.Size(1300, 387);
                    txtKanriNO.NextControlName = "txtTokuisakiCD";
                    //gvMainDetail.ReadOnly = true;
                    //gvMainDetail.CellValidating -= new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gvMainDetail_CellValidating);
                    break;
                case 1:
                    txtTokuisakiCD.Enabled = false;
                    txtKouritenCD.Enabled = false;
                    txtPostalCode1.Enabled = false;
                    txtPostalCode2.Enabled = false;
                    txtPhoneNo1.Enabled = false;
                    txtPhoneNo2.Enabled = false;
                    txtPhoneNo3.Enabled = false;
                    txtName.Enabled = false;
                    txtAddress.Enabled = false;
                    txtChakuniYoteiNO.Enabled = true;
                    this.txtSoukoCD.NextControlName = txtChakuniYoteiNO.Name;
                    chkType1.Enabled = true;
                    chkType2.Enabled = true;
                    F7.Enabled = false;
                    F8.Enabled = true;
                    F11.Enabled = true;
                    F12.Enabled = true;
                    btn_F8.Enabled = true;
                    btn_F11.Enabled = true;
                    gvAggregationDetails.Visible = false;
                    gvMainDetail.Visible = true;
                   // gvFreeInventoryDetails.Visible = false;
                    //gvMainDetail.Location = new Point(49, 262);
                   // gvMainDetail.Size = new Size(1632, 565);
                    //this.gvMainDetail.Size = new System.Drawing.Size(1300, 387);
                    txtKanriNO.NextControlName = "txtShouhinCD";
                    //gvMainDetail.ReadOnly = false;
                    //gvMainDetail.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gvMainDetail_CellValidating);
                    break;
                case 2:
                    txtTokuisakiCD.Enabled = false;
                    txtKouritenCD.Enabled = false;
                    txtPostalCode1.Enabled = false;
                    txtPostalCode2.Enabled = false;
                    txtPhoneNo1.Enabled = false;
                    txtPhoneNo2.Enabled = false;
                    txtPhoneNo3.Enabled = false;
                    txtName.Enabled = false;
                    txtAddress.Enabled = false;
                    txtChakuniYoteiNO.Enabled = false;
                    this.txtSoukoCD.NextControlName = txtKanriNO.Name;
                    chkType1.Enabled = false;
                    chkType2.Enabled = false;
                    F7.Enabled = true;
                    F8.Enabled = false;
                    F11.Enabled = false;
                    F12.Enabled = false;
                    btn_F8.Enabled = false;
                    btn_F11.Enabled = false;
                    gvAggregationDetails.Visible = false;
                    gvMainDetail.Visible = false;
                    //gvFreeInventoryDetails.Visible = true;
                   // gvFreeInventoryDetails.DataSource = createMemoryTable(type);
                  //  gvFreeInventoryDetails.Location = new Point(49, 262);
                   // gvFreeInventoryDetails.Size = new Size(1100, 550);
                    //this.gvFreeInventoryDetails.Size = new System.Drawing.Size(1100, 387);
                    txtKanriNO.NextControlName = "txtShouhinCD";
                    //gvMainDetail.ReadOnly = true;
                    //gvMainDetail.CellValidating -= new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gvMainDetail_CellValidating);
                    break;
            }
            //gvMainDetail.DataSource = null;
            //gvMainDetail.Rows.Clear();
            //gvMainDetail.DataSource = createMemoryTable(type);
            //gvMainDetail.Columns[gvMainDetail.Columns.Count - 1].Visible = false;
        }
    }
}
