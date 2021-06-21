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
        public string hinbanCD = string.Empty;
        public string colorNO = string.Empty;
        public string colorName = string.Empty;
        public string sizeNO = string.Empty;
        public string sizeName = string.Empty;
        public string changeDate = string.Empty;
        public string parent_changeDate;
        ShouhinBL shouhinbl = new ShouhinBL();
        public Shouhin_Search()
        {
            InitializeComponent();
            dgDetail.ScrollBars = ScrollBars.Both;  //HET
        }

        private void Shouhin_Search_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Normal, F9, "検索(F9)", false);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);
            dgDetail.UseRowNo(true);
            //dgDetail.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgDetail.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (string.IsNullOrWhiteSpace(parent_changeDate))
                txtChangeDate.Text = string.Format("{0:yyyy/MM/dd}", DateTime.Now);
            else
                txtChangeDate.Text = string.Format("{0:yyyy/MM/dd}", parent_changeDate);

            txtHinbanCD1.E106Check(true, txtHinbanCD, txtHinbanCD1);
            txtJANCD1.E106Check(true, txtJANCD, txtJANCD1);
            txtExhibition1.E106Check(true, txtExhibition, txtExhibition1);
            txtBrand1.E106Check(true, txtBrand, txtBrand1);

            chkSS.Checked = true;
            chkFW.Checked = true;
            BindDataGrid();

            dgDetail.SetGridDesign();
            dgDetail.SetReadOnlyColumn("**");//readonly for search form 
            dgDetail.Select();
            dgDetail.Columns[1].Width = 150;
            dgDetail.Columns[2].Width = 100;
            dgDetail.Columns[3].Width = 270;
            dgDetail.Columns[4].Width = 100;
            dgDetail.Columns[5].Width = 270;
            dgDetail.Columns[6].Width = 320;
            dgDetail.Columns[7].Width = 100;
            dgDetail.Columns[8].Width = 100;
            dgDetail.Columns[9].Width = 160;
            dgDetail.Columns[10].Width = 270;
            dgDetail.Columns[11].Width = 60;
            dgDetail.Columns[12].Width = 100;
        }

        private void dgDetail_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetGridviewData(dgDetail.Rows[e.RowIndex]);
        }

        public override void FunctionProcess(string tagID)
        {
            if (tagID == "3")
            {
                BindDataGrid();
                dgDetail.Select();
            }
            if (tagID == "4")
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
            shouhin.HinbanCD = txtHinbanCD.Text;
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

            if(dt.Rows.Count == 0)  //HET
            {
                ClearSession();
            }

            this.dgDetail.CellPainting += new DataGridViewCellPaintingEventHandler(dgDetail_CellPainting);
            this.dgDetail.Paint += new PaintEventHandler(dgDetail_Paint);
            this.dgDetail.Scroll += new ScrollEventHandler(dgDetail_Scroll);
            this.dgDetail.ColumnWidthChanged += new DataGridViewColumnEventHandler(dgDetail_ColumnWidthChanged);

            this.dgDetail.Columns[0].Visible = false;
            this.dgDetail.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgDetail.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgDetail.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgDetail.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgDetail.Columns[2].HeaderText = "";
            this.dgDetail.Columns[3].HeaderText = "";
            this.dgDetail.Columns[4].HeaderText = "";
            this.dgDetail.Columns[5].HeaderText = "";
            this.dgDetail.Columns[9].HeaderText = "";
            this.dgDetail.Columns[10].HeaderText = "";
            this.dgDetail.Columns[11].HeaderText = "";
            this.dgDetail.Columns[12].HeaderText = "";
        }
        //HET
        private void ClearSession()
        {
            txtHinbanCD.Clear();
            txtHinbanCD1.Clear();
            txtProductName.Clear();
            txtKanaName.Clear();
            txtJANCD.Clear();
            txtJANCD1.Clear();
            txtExhibition.Clear();
            txtExhibition1.Clear();
            txtBrand.Clear();
            txtBrand1.Clear();
            txtRemarks.Clear();
            txtColor.Clear();
            txtSize.Clear();
            chkSS.Checked = true;
            chkFW.Checked = true;
            rdoRecentRevisionDate.Checked = true;
        }
        private void GetGridviewData(DataGridViewRow gvrow)
        {
            if (gvrow != null)
            {
                DataGridViewRow row = gvrow;
                shouhinCD = row.Cells["ShouhinCD"].Value.ToString();
                hinbanCD = row.Cells["品番"].Value.ToString();
                colorNO = row.Cells["ColorNO"].Value.ToString();
                colorName = row.Cells["ColorName"].Value.ToString();
                sizeNO = row.Cells["SizeNO"].Value.ToString();
                sizeName = row.Cells["SizeName"].Value.ToString();
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
            //string[] months = { "ブランド", "カラー", "サイズ", "単位" };
            string[] months = { "カラー", "サイズ"};
            for (int j = 0; j < 4;)
            {
                Rectangle r1 = this.dgDetail.GetCellDisplayRectangle(j+2 , -1, true);
                int w1 = this.dgDetail.GetCellDisplayRectangle(j +3, -1, true).Width;
                r1.X += 1;
                r1.Y += 1;
                r1.Width = r1.Width + w1 - 2;
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

            string[] months1 = { "ブランド", "単位" };
            for (int j = 0; j < 4;)
            {
                Rectangle r1 = this.dgDetail.GetCellDisplayRectangle(j + 9, -1, true);
                int w1 = this.dgDetail.GetCellDisplayRectangle(j + 10, -1, true).Width;
                r1.X += 1;
                r1.Y += 1;
                r1.Width = r1.Width + w1 - 2;
                r1.Height = r1.Height - 2;
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(191, 191, 191)), r1);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Near;
                format.LineAlignment = StringAlignment.Near;
                e.Graphics.DrawString(months1[j / 2],
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
