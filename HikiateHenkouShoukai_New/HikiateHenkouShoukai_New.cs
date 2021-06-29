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
            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "", false);
            SetButton(ButtonType.BType.Update, F3, "", false);
            SetButton(ButtonType.BType.Delete, F4, "", false);
            SetButton(ButtonType.BType.Inquiry, F5, "", false);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.ExcelExport, F7, "出力(F7)", true);
            SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", true);
            SetButton(ButtonType.BType.Display, F10, "表示(F10)", true);
            SetButton(ButtonType.BType.Memory, F11, "保存(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);

            if (rdoAggregation.Checked)
                Radio_Changed(0);

            //gvAggregationDetails.SetGridDesign();
            //gvAggregationDetails.SetReadOnlyColumn("*");

            var col = gvMainDetail.Columns;
            DataGridViewTextBoxColumn newCol = new DataGridViewTextBoxColumn();
            newCol.Name = "ShouhinCD";
            newCol.DataPropertyName = "ShouhinCD";
            newCol.Visible = false;
            col.Insert(col.Count, newCol);
            newCol.DisplayIndex = col.Count - 1;

            gvMainDetail.SetGridDesign();
            gvMainDetail.SetReadOnlyColumn("col_Detail_ShouhinCD,col_Detail_ShouhinName,col_Detail_ColorNO,col_Detail_SizeNO,col_Detail_JuchuuSuu,col_Detail_ChakuniYoteiSuu,col_Detail_MiHikiateSuu,col_Detail_HikiateZumiSuu,col_Detail_ChakuniSuu,col_Detail_ShukkaSiziSuu,col_Detail_ShukkaSuu,col_Detail_JuchuuNO_JuchuuGyouNO,col_Detail_TokuisakiRyakuName,col_Detail_KanriNO,col_Detail_NyuukoDate,col_Detail_JuchuuDate,col_Detail_KibouNouki,col_Detail_JANCD,ShouhinCD");
            gvMainDetail.SetNumberColumn("col_Detail_HikiateSuu");

            //gvFreeInventoryDetails.SetGridDesign();
            //gvFreeInventoryDetails.SetReadOnlyColumn("*");

            Header_Alignment();
            Creat_DataTable();

        }
        private void Header_Alignment()
        {
            //gvAggregationDetails.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //gvAggregationDetails.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            //gvAggregationDetails.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //gvAggregationDetails.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            //gvAggregationDetails.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //gvAggregationDetails.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            //gvAggregationDetails.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //gvAggregationDetails.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            //gvAggregationDetails.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //gvAggregationDetails.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
            //gvAggregationDetails.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //gvAggregationDetails.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
            //gvAggregationDetails.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //gvAggregationDetails.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;

            gvMainDetail.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvMainDetail.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvMainDetail.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvMainDetail.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvMainDetail.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvMainDetail.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvMainDetail.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvMainDetail.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvMainDetail.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvMainDetail.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvMainDetail.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvMainDetail.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvMainDetail.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvMainDetail.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvMainDetail.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvMainDetail.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvMainDetail.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvMainDetail.Columns[15].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvMainDetail.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvMainDetail.Columns[16].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvMainDetail.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvMainDetail.Columns[17].SortMode = DataGridViewColumnSortMode.NotSortable;

            //gvFreeInventoryDetails.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //gvFreeInventoryDetails.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            //gvFreeInventoryDetails.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //gvFreeInventoryDetails.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

        }
        private void Radio_Changed(int type)
        {
            //cf.Clear(PanelDetail);
            //lblBrandName.Text = string.Empty;
            //lblKouritenName.Text = string.Empty;
            //lblSoukoName.Text = string.Empty;
            //lblTokuisakiName.Text = string.Empty;

            //initScr();

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
                    //gvAggregationDetails.Visible = true;
                    gvMainDetail.Visible = false;
                    //gvFreeInventoryDetails.Visible = false;
                    //gvAggregationDetails.Location = new Point(45, 264);
                    //gvAggregationDetails.Size = new Size(1430, 550);
                    txtKanriNO.NextControlName = "txtTokuisakiCD";
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
                    //gvAggregationDetails.Visible = false;
                    gvMainDetail.Visible = true;
                    //gvFreeInventoryDetails.Visible = false;
                    gvMainDetail.Location = new Point(45, 264);
                    gvMainDetail.Size = new Size(1632, 565);
                    txtKanriNO.NextControlName = "txtShouhinCD";
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
                    //gvAggregationDetails.Visible = false;
                    gvMainDetail.Visible = false;
                    //gvFreeInventoryDetails.Visible = true;
                    //gvFreeInventoryDetails.DataSource = createMemoryTable(type);
                    //gvFreeInventoryDetails.Location = new Point(45, 264);
                    //gvFreeInventoryDetails.Size = new Size(1100, 550);
                    txtKanriNO.NextControlName = "txtShouhinCD";
                    break;
            }
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

        private void Creat_DataTable()
        {
            //DataTable dt_AggregationDetails = new DataTable();
            //dt_AggregationDetails.Columns.Add("商品");
            //dt_AggregationDetails.Columns.Add("商品名");
            //dt_AggregationDetails.Columns.Add("カラー");
            //dt_AggregationDetails.Columns.Add("サイズ");
           
            //dt_AggregationDetails.Columns.Add("受注数");
            //dt_AggregationDetails.Columns.Add("着荷予定数");
            //dt_AggregationDetails.Columns.Add("未引当数");
            //dt_AggregationDetails.Columns.Add("引当済数");
            //dt_AggregationDetails.Columns.Add("着荷済数");
            //dt_AggregationDetails.Columns.Add("出荷指示数");
            //dt_AggregationDetails.Columns.Add("出荷済数");            
            //dt_AggregationDetails.Columns.Add("JANCD");
            //dt_AggregationDetails.Columns.Add("表示順");
            //dt_AggregationDetails.Columns.Add("倉庫");
            //dt_AggregationDetails.Columns.Add("受注番号");            

            //for (int i = 0; i < 30; i++)
            //{
            //    DataRow row = dt_AggregationDetails.NewRow();
            //    row["商品"] = "AKC-0001";
            //    row["商品名"] = "AKIII RUMBLE";
            //    row["カラー"] = "BLK";
            //    row["サイズ"] = "23.0";
            //    row["受注数"] = "1,023";
            //    row["着荷予定数"] = "1,010";
            //    row["未引当数"] = "13";
            //    row["引当済数"] = "10";
            //    row["着荷済数"] = "0";
            //    row["出荷指示数"] = "10,000";
            //    row["出荷済数"] = "0";
            //    row["JANCD"] = "4580543959141";
            //    row["表示順"] = "";
            //    row["倉庫"] = "";
            //    row["受注番号"] = "";
            //    dt_AggregationDetails.Rows.Add(row);
            //}
            //gvAggregationDetails.DataSource = dt_AggregationDetails;

            DataTable dt_Detail = new DataTable();
            dt_Detail.Columns.Add("商品");
            dt_Detail.Columns.Add("商品名");
            dt_Detail.Columns.Add("カラー");
            dt_Detail.Columns.Add("サイズ");
            dt_Detail.Columns.Add("受注数");
            dt_Detail.Columns.Add("着荷予定数");
            dt_Detail.Columns.Add("未引当数");
            dt_Detail.Columns.Add("引当済数");
            dt_Detail.Columns.Add("着荷済数");
            dt_Detail.Columns.Add("出荷指示数");
            dt_Detail.Columns.Add("出荷済数");
            dt_Detail.Columns.Add("引当調整数");
            dt_Detail.Columns.Add("受注番号-行番号");
            dt_Detail.Columns.Add("得意先名");
            dt_Detail.Columns.Add("小売店名");
            dt_Detail.Columns.Add("入庫日");
            dt_Detail.Columns.Add("受注日");
            dt_Detail.Columns.Add("希望納期");
            dt_Detail.Columns.Add("JANCD");

            for (int i = 0; i < 30; i++)
            {
                DataRow row = dt_Detail.NewRow();
                row["商品"] = "AKC-0001";
                row["商品名"] = "AKIII RUMBLE";
                row["カラー"] = "BLK";
                row["サイズ"] = "23.0";
                row["受注数"] = "23";
                row["着荷予定数"] = "10";
                row["未引当数"] = "13";
                row["引当済数"] = "10";
                row["着荷済数"] = "0";
                row["出荷指示数"] = "0";
                row["出荷済数"] = "0";
                row["引当調整数"] = "0";
                row["受注番号-行番号"] = "A00000000006-001";
                row["得意先名"] = "ｻﾞｲﾛｶﾝﾄｳ";
                row["小売店名"] = "ﾑﾗｻｷｻﾞｲｺ";
                row["入庫日"] = "2021/06/11";
                row["受注日"] = "2021/06/11";
                row["希望納期"] = "2021/06/11";
                row["JANCD"] = "4580543959141";
                dt_Detail.Rows.Add(row);
            }
            gvMainDetail.DataSource = dt_Detail;

            //DataTable dt_Free = new DataTable();
            //dt_Free.Columns.Add("商品");
            //dt_Free.Columns.Add("商品名");
            //dt_Free.Columns.Add("カラー");
            //dt_Free.Columns.Add("サイズ");
            //dt_Free.Columns.Add("引当済数");
            //dt_Free.Columns.Add("現在庫数");
            //dt_Free.Columns.Add("管理番号");
            //dt_Free.Columns.Add("JANCD");

            //for (int i = 0; i < 30; i++)
            //{
            //    DataRow row = dt_Free.NewRow();
            //    row["商品"] = "AKC-0001";
            //    row["商品名"] = "AKIII RUMBLE";
            //    row["カラー"] = "BLK";
            //    row["サイズ"] = "23.0";
            //    row["引当済数"] = "0";
            //    row["現在庫数"] = "500";
            //    row["管理番号"] = "A000000001";
            //    row["JANCD"] = "4580543959141";
            //    dt_Free.Rows.Add(row);
            //}
            //gvFreeInventoryDetails.DataSource = dt_Free;
        }

    }
}
