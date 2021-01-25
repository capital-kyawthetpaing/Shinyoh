using BL;
using Entity;
using Shinyoh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Shinyoh_Search
{
    public partial class Shouhin_Search : SearchBase
    {
        public string shouhinCD = string.Empty;
        public string changeDate = string.Empty;
        public string parent_changeDate;
        ShouhinBL shouhinbl = new ShouhinBL();
        public Shouhin_Search()
        {
            InitializeComponent();
        }

        private void Shouhin_Search_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);
            dgDetail.UseRowNo(true);
            //dgDetail.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgDetail.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (string.IsNullOrWhiteSpace(parent_changeDate))
                txtChangeDate.Text = string.Format("{0:yyyy/MM/dd}", DateTime.Now);
            else
                txtChangeDate.Text = string.Format("{0:yyyy/MM/dd}", parent_changeDate);
            BindDataGrid();

            txtHinbanCD1.E106Check(true, txtHinbanCD, txtHinbanCD1);
            txtJANCD1.E106Check(true, txtJANCD, txtJANCD1);
            txtExhibition1.E106Check(true, txtExhibition, txtExhibition1);
            txtBrand1.E106Check(true, txtBrand, txtBrand1);

            dgDetail.SetGridDesign();
            dgDetail.SetReadOnlyColumn("**");//readonly for search form 
            dgDetail.Select();
            dgDetail.Columns[1].Width = 150;
            dgDetail.Columns[2].Width = 320;
            dgDetail.Columns[3].Width = 100;
            dgDetail.Columns[4].Width = 100;
            dgDetail.Columns[5].Width = 80;
            dgDetail.Columns[6].Width = 270;
            dgDetail.Columns[7].Width = 100;
            dgDetail.Columns[8].Width = 270;
            dgDetail.Columns[9].Width = 100;
            dgDetail.Columns[10].Width = 270;
            dgDetail.Columns[11].Width = 50;
            dgDetail.Columns[12].Width = 150;
            dgDetail.Columns[13].Width = 100;
        }

        private void dgDetail_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetGridviewData(dgDetail.Rows[e.RowIndex]);
        }

        public override void FunctionProcess(string tagID)
        {
            if (tagID == "2")
            {
                BindDataGrid();
                dgDetail.Select();
            }
            if (tagID == "3")
            {
                DataGridViewRow row = dgDetail.CurrentRow;
                GetGridviewData(row);
            }
            base.FunctionProcess(tagID);
        }

        private void btn_F11_Click(object sender, EventArgs e)
        {
            FunctionProcess(btn_F11.Tag.ToString());
            BindDataGrid();
        }

        private void BindDataGrid()
        {
            ShouhinEntity shouhin = new ShouhinEntity();
            if (rdoRecentRevisionDate.Checked)
                shouhin.DisplayTarget = 0;
            else
                shouhin.DisplayTarget = 1;
            shouhin.RevisionDate = txtChangeDate.Text;
            shouhin.Product = txtHinbanCD.Text;
            shouhin.HinbanCD1 = txtHinbanCD1.Text;
            shouhin.JANCD = txtJANCD.Text;
            shouhin.JANCD1 = txtJANCD1.Text;
            shouhin.Remarks = txtRemarks.Text;
            shouhin.ProductName = txtProductName.Text;
            shouhin.Exhibition = txtExhibition.Text;
            shouhin.Exhibition1 = txtExhibition1.Text;
            shouhin.SS = chkSS.Checked ? "1" : "0";
            shouhin.FW = chkFW.Checked ? "1" : "0";
            shouhin.Color = txtColor.Text;
            shouhin.KatakanaName = txtKanaName.Text;
            shouhin.BrandCD = txtBrand.Text;
            shouhin.BrandCD1 = txtBrand1.Text;
            shouhin.Size = txtSize.Text;
            DataTable dt = shouhinbl.Shouhin_SearchData(shouhin);
            dgDetail.DataSource = dt;

            this.dgDetail.CellPainting += new DataGridViewCellPaintingEventHandler(dgDetail_CellPainting);
            this.dgDetail.Paint += new PaintEventHandler(dgDetail_Paint);
            this.dgDetail.Scroll += new ScrollEventHandler(dgDetail_Scroll);
            this.dgDetail.ColumnWidthChanged += new DataGridViewColumnEventHandler(dgDetail_ColumnWidthChanged);

            this.dgDetail.Columns[0].Visible = false;
            this.dgDetail.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgDetail.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgDetail.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgDetail.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgDetail.Columns[5].HeaderText = "";
            this.dgDetail.Columns[6].HeaderText = "";
            this.dgDetail.Columns[7].HeaderText = "";
            this.dgDetail.Columns[8].HeaderText = "";
            this.dgDetail.Columns[9].HeaderText = "";
            this.dgDetail.Columns[10].HeaderText = "";
            this.dgDetail.Columns[11].HeaderText = "";
            this.dgDetail.Columns[12].HeaderText = "";
        }

        private void GetGridviewData(DataGridViewRow gvrow)
        {
            if (gvrow != null)
            {
                DataGridViewRow row = gvrow;
                shouhinCD = row.Cells["ShouhinCD"].Value.ToString();
                changeDate = Convert.ToDateTime(row.Cells["改定日"].Value.ToString()).ToString("yyyy/MM/dd");
            }
            this.Close();
        }

        private void dgDetail_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Rectangle rtHeader = this.dgDetail.DisplayRectangle;
            rtHeader.Height = this.dgDetail.ColumnHeadersHeight / 2;
            this.dgDetail.Invalidate(rtHeader);
        }

        private void dgDetail_Scroll(object sender, ScrollEventArgs e)
        {
            Rectangle rtHeader = this.dgDetail.DisplayRectangle;
            rtHeader.Height = this.dgDetail.ColumnHeadersHeight / 2;
            this.dgDetail.Invalidate(rtHeader);
        }

        private void dgDetail_Paint(object sender, PaintEventArgs e)
        {
            string[] months = { "ブランド", "カラー", "サイズ", "単位" };
            for (int j = 0; j < 8;)
            {
                Rectangle r1 = this.dgDetail.GetCellDisplayRectangle(j + 5, -1, true);
                int w2 = this.dgDetail.GetCellDisplayRectangle(j + 6, -1, true).Width;
                r1.X += 1;
                r1.Y += 1;
                r1.Width = r1.Width + w2 - 2;
                r1.Height = r1.Height - 2;
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(191, 191, 191)), r1);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Near;
                format.LineAlignment = StringAlignment.Near;
                e.Graphics.DrawString(months[j / 2],
                    this.dgDetail.ColumnHeadersDefaultCellStyle.Font,
                    new SolidBrush(this.dgDetail.ColumnHeadersDefaultCellStyle.ForeColor),
                    r1,
                    format);
                j += 2;
            }
        }

        private void dgDetail_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                Rectangle r2 = e.CellBounds;
                r2.Y += e.CellBounds.Height / 2;
                r2.Height = e.CellBounds.Height / 2;
                e.PaintBackground(r2, true);
                e.PaintContent(r2);
                e.Handled = true;
            }
        }

        private void dgDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(dgDetail.CurrentCell != null)
                    GetGridviewData(dgDetail.Rows[dgDetail.CurrentCell.RowIndex]);
            }
        }
    }
}
