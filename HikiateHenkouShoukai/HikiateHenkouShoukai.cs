using BL;
using CKM_CommonFunction;
using Entity;
using Shinyoh;
using Shinyoh_Search;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace HikiateHenkouShoukai
{
    public partial class HikiateHenkouShoukai : BaseForm
    {
        BaseEntity base_entity;
        BaseBL bbl = new BaseBL();
        CommonFunction cf;
        multipurposeEntity multi_Entity;
        DataTable dt, dtMain, dtMemory, dtTemp;
        HikiateHenkouShoukaiBL hbl = new HikiateHenkouShoukaiBL();
        public HikiateHenkouShoukai()
        {
            InitializeComponent();
            cf = new CommonFunction();
        }

        private void HikiateHenkouShoukai_Load(object sender, EventArgs e)
        {
            ProgramID = "HikiateHenkouShoukai";
            StartProgram();
            cboMode.Bind(false, multi_Entity);
            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "", false);
            SetButton(ButtonType.BType.Update, F3, "", false);
            SetButton(ButtonType.BType.Delete, F4, "", false);
            SetButton(ButtonType.BType.Inquiry, F5, "", false);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Export, F7, "出力(F7)", true);
            SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", true);
            SetButton(ButtonType.BType.Display, F10, "表示(F10)", true);
            SetButton(ButtonType.BType.Memory, F11, "保存(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);

            Modified_Panel();
            rdoAggregation.Focus();
            base_entity = _GetBaseData();
            txtTokuisakiCD.E102Type = base_entity.LoginDate;        //ChangeDate value For E101 Error check of txtTokuisakiCD
            txtKouritenCD.E102Type = base_entity.LoginDate;         //ChangeDate value For E101 Error check of txtKouritenCD
            if(rdoAggregation.Checked)
                Radio_Changed(0);
        }

        private void Modified_Panel()
        {
            cf.Clear(PanelDetail);
            //UI_ErrorCheck();

            lblBrandName.Text = string.Empty;
            lblTokuisakiName.Text = string.Empty;
            lblSoukoName.Text = string.Empty;
            lblKouritenName.Text = string.Empty;
        }

        public override void FunctionProcess(string tagID)
        {
            if (tagID == "6")
            {
                Modified_Panel();
            }
            if (tagID == "7")
            {
                if(rdoFreeInventory.Checked)
                    Excel_Export();
            }
            if (tagID == "8")
            {
                Confirm_Data();
            }
            if (tagID == "10")
            {
                if(ErrorCheck(PanelDetail))
                    Display_Data();
            }
            if (tagID == "11")
            {
                TemporarySave_Data();
            }
            if (tagID == "12")
            {
                if (dtMemory == null)
                    bbl.ShowMessage("E274");
                else if (dtMemory.Rows.Count < 1)
                    bbl.ShowMessage("E274");
                else
                {
                    DBData_IU();
                    txtBrand.Focus();
                }
            }

            base.FunctionProcess(tagID);
        }

        private void btn_F8_Click(object sender, EventArgs e)
        {
            FunctionProcess("8");
        }

        private void btn_F10_Click(object sender, EventArgs e)
        {
            FunctionProcess("10");
        }

        private void btn_F11_Click(object sender, EventArgs e)
        {
            FunctionProcess("11");
        }

        private void UI_ErrorCheck()
        {
            txtBrand.E102Check(true);
            txtBrand.E101Check(true, "M_Shouhin", txtBrand, null, null);

            txtPostalCode2.E102MultiCheck(true, txtPostalCode1, txtPostalCode2);
            txtPostalCode2.Yuubin_Juusho(true, txtPostalCode1, txtPostalCode2, string.Empty, string.Empty);

            txtYearTerm.E102Check(true);
            chkSeasonFW.E188Check(true, chkSeasonFW, chkSeasonSS);
            txtSoukoCD.E102Check(true);
            txtSoukoCD.E101Check(true, "souko", txtSoukoCD, null, null);
            txtChakuniYoteiNO.E133Check(true, "HikiateHenkouShoukai", txtChakuniYoteiNO, null, null);
            txtTokuisakiCD.E101Check(true, "HikiateHenkouShoukai" , txtTokuisakiCD, null, null);
            txtKouritenCD.E101Check(true, "HikiateHenkouShoukai", txtKouritenCD, null, null);
        }

        private void rdoAggregation_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoAggregation.Checked)
                Radio_Changed(0);
        }

        private void rdoDetails_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoDetails.Checked)
                Radio_Changed(1);
        }

        private void rdoFreeInventory_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoFreeInventory.Checked)
                Radio_Changed(2);
        }

        private void Radio_Changed(int type)
        {
            switch(type)
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
                    chkType1.Enabled = true;
                    chkType2.Enabled = true;
                    F7.Enabled = false;
                    F8.Enabled = false;
                    F11.Enabled = false;
                    F12.Enabled = false;
                    btn_F8.Enabled = false;
                    btn_F11.Enabled = false;
                    gvMainDetail.ReadOnly = true;
                    gvMainDetail.CellValidating -= new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gvMainDetail_CellValidating);
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
                    chkType1.Enabled = true;
                    chkType2.Enabled = true;
                    F7.Enabled = false;
                    F8.Enabled = true;
                    F11.Enabled = true;
                    F12.Enabled = true;
                    btn_F8.Enabled = true;
                    btn_F11.Enabled = true;
                    gvMainDetail.ReadOnly = false;
                    gvMainDetail.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gvMainDetail_CellValidating);
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
                    chkType1.Enabled = false;
                    chkType2.Enabled = false;
                    F7.Enabled = true;
                    F8.Enabled = false;
                    F11.Enabled = false;
                    F12.Enabled = false;
                    btn_F8.Enabled = false;
                    btn_F11.Enabled = false;
                    gvMainDetail.ReadOnly = true;
                    gvMainDetail.CellValidating -= new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gvMainDetail_CellValidating);
                    break;
            }
            gvMainDetail.DataSource = null;
            gvMainDetail.Rows.Clear();
            gvMainDetail.DataSource = createMemoryTable(type);
            gvMainDetail.Columns[gvMainDetail.Columns.Count - 1].Visible = false;
        }

        private void txtBrand_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                lblBrandName.Text = "";
                if(!txtBrand.IsErrorOccurs)
                {
                    dt = txtBrand.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                        lblBrandName.Text = dt.Rows[0]["char1"].ToString();
                }
            }
        }

        private void chkSeasonSS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeasonSS.Checked)
                chkSeasonFW.Enabled = false;
            else
                chkSeasonFW.Enabled = true;
        }

        private void chkSeasonFW_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeasonFW.Checked)
                chkSeasonSS.Enabled = false;
            else
                chkSeasonSS.Enabled = true;
        }

        private void txtSoukoCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblSoukoName.Text = "";
                if (!txtSoukoCD.IsErrorOccurs)
                {
                    dt = txtSoukoCD.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                        lblSoukoName.Text = dt.Rows[0]["SoukoName"].ToString();
                }
            }
        }

        private void txtTokuisakiCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblTokuisakiName.Text = "";
                if (!txtTokuisakiCD.IsErrorOccurs)
                {
                    dt = txtTokuisakiCD.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                        lblTokuisakiName.Text = dt.Rows[0]["TokuisakiName"].ToString();
                }
            }
        }

        private void txtKouritenCD_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                lblKouritenName.Text = "";
                if(!txtKouritenCD.IsErrorOccurs)
                {
                    dt = txtKouritenCD.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                        lblKouritenName.Text = dt.Rows[0]["KouritenName"].ToString();
                }
            }
        }

        private void txtPostalCode2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(!txtPostalCode2.IsErrorOccurs)
                {
                    dt = txtPostalCode2.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                        txtAddress.Text = dt.Rows[0]["Juusho1"].ToString();
                }
            }
        }

        private void Excel_Export()
        {
            if(gvMainDetail.Rows.Count > 0 && rdoFreeInventory.Checked)
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = false; 
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "在庫表";
                for (int i = 1; i < gvMainDetail.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = gvMainDetail.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < gvMainDetail.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < gvMainDetail.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = gvMainDetail.Rows[i].Cells[j].Value.ToString();
                    }
                }
                if (!System.IO.Directory.Exists("C:\\Output Excel Files"))
                    System.IO.Directory.CreateDirectory("C:\\Output Excel Files");
                workbook.SaveAs("C:\\Output Excel Files\\在庫表.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                app.Quit();
            }
            else
            {
                bbl.ShowMessage("E277");
            }    
        }

        private void Confirm_Data()
        {
            if(dtMemory != null)
            {
                DataView dv = dtMemory.DefaultView;
                dv.Sort = "商品 ASC, 引当調整数 ASC, 表示順 ASC, [受注番号-行番号] ASC";
                gvMainDetail.DataSource = null;
                gvMainDetail.Rows.Clear();
                gvMainDetail.DataSource = dv.ToTable();
                gvMainDetail.Columns[gvMainDetail.Columns.Count - 1].Visible = false;
            }
        }

        private void Display_Data()
        {
            HikiateHenkouShoukaiEntity entity = new HikiateHenkouShoukaiEntity();
            if (rdoAggregation.Checked)
                entity.Representation = 0;
            else if (rdoDetails.Checked)
                entity.Representation = 1;
            else
                entity.Representation = 2;
            entity.BrandCD = txtBrand.Text;
            entity.ChakuniYoteiNO = txtChakuniYoteiNO.Text;
            entity.KanriNO = txtKanriNO.Text;
            entity.YearTerm = txtYearTerm.Text;
            entity.SeasonSS = chkSeasonSS.Checked ? 1 : 0;
            entity.SeasonFW = chkSeasonFW.Checked ? 1 : 0;
            entity.TokuisakiCD = txtTokuisakiCD.Text;
            entity.SoukoCD = txtSoukoCD.Text;
            entity.KouritenCD = txtKouritenCD.Text;
            entity.PostalCode1 = txtPostalCode1.Text;
            entity.PostalCode2 = txtPostalCode2.Text;
            entity.Phoneno1 = txtPhoneNo1.Text;
            entity.Phoneno2 = txtPhoneNo2.Text;
            entity.Phoneno3 = txtPhoneNo3.Text;
            entity.Name = txtName.Text;
            entity.Address = txtAddress.Text;
            entity.ShouhinCD = txtShouhinCD.Text;
            entity.JANCD = txtJANCD.Text;
            entity.ColorNO = txtColorNO.Text;
            entity.SizeNO = txtSizeNO.Text;
            entity.ShouhinName = txtShouhinName.Text;
            entity.Type1 = chkType1.Checked ? 1 : 0;
            entity.Type2 = chkType2.Checked ? 1 : 0;
            entity.OperatorCD = base_entity.OperatorCD;
            entity.PC = base_entity.PC;
            entity.ProgramID = base_entity.ProgramID;
            dtMain = hbl.Select_DisplayData(entity);
            gvMainDetail.DataSource = dtMain;
            if (rdoDetails.Checked)
            {
                for(int i=0; i<gvMainDetail.Columns.Count; i++)
                {
                    if (i == 11)
                        gvMainDetail.Columns[i].ReadOnly = false;
                    else
                        gvMainDetail.Columns[i].ReadOnly = true;
                }
                gvMainDetail.Columns[gvMainDetail.Columns.Count - 2].Visible = false;
                gvMainDetail.Columns[gvMainDetail.Columns.Count - 1].Visible = false;
            }
            if(dtTemp != null)
                dtTemp.Clear();
        }

        private void TemporarySave_Data()
        {
            if(gvMainDetail != null)
            {
                if (dtMemory == null)
                    dtMemory = createMemoryTable(1);
                if(dtTemp != null)
                {
                    if(dtMemory.Rows.Count == 0)
                    {
                        foreach(DataRow temp_row in dtTemp.Rows)
                        {
                            DataRow row = dtMemory.NewRow();
                            for (int i = 0; i < dtMemory.Columns.Count; i++)
                            {
                                row[i] = temp_row[i].ToString();
                            }
                            dtMemory.Rows.Add(row);
                        }
                    }
                    else
                    {
                        foreach (DataRow temp_row in dtTemp.Rows)
                        {
                            bool isexists = false;
                            int index = 0;
                            for (int i = 0; i < dtMemory.Rows.Count; i++)
                            {
                                if (temp_row["商品"].ToString() == dtMemory.Rows[i]["商品"].ToString() && temp_row["小売店名"].ToString() == dtMemory.Rows[i]["小売店名"].ToString() && temp_row["JANCD"].ToString() == dtMemory.Rows[i]["JANCD"].ToString())
                                {
                                    isexists = true;
                                    index = i;
                                    break;
                                }
                            }
                            
                            if(isexists)
                            {
                                dtMemory.Rows[index]["引当調整数"] = temp_row["引当調整数"].ToString();
                            }
                            else
                            {
                                DataRow row = dtMemory.NewRow();
                                for (int i = 0; i < dtMemory.Columns.Count; i++)
                                {
                                    row[i] = temp_row[i].ToString();
                                }
                                dtMemory.Rows.Add(row);
                            }
                        }
                    }
                    dtTemp.Clear();
                }
            }
            txtShouhinCD.Focus();
        }

        private DataTable createMemoryTable(int type)
        {
            dt = new DataTable();
            dt.Columns.Add("商品");
            dt.Columns.Add("商品名");
            dt.Columns.Add("カラー");
            dt.Columns.Add("サイズ");
            if (type != 2)
            {
                dt.Columns.Add("受注数");
                dt.Columns.Add("着荷予定数");
                dt.Columns.Add("未引当数");
            }
            dt.Columns.Add("引当済数");
            switch(type)
            {
                case 0:
                    dt.Columns.Add("着荷済数");
                    dt.Columns.Add("出荷指示数");
                    dt.Columns.Add("出荷済数");
                    break;
                case 1:
                    dt.Columns.Add("着荷済数");
                    dt.Columns.Add("出荷指示数");
                    dt.Columns.Add("出荷済数");
                    dt.Columns.Add("引当調整数");
                    dt.Columns.Add("受注番号-行番号");
                    dt.Columns.Add("得意先名");
                    dt.Columns.Add("小売店名");
                    dt.Columns.Add("入庫日");
                    dt.Columns.Add("受注日");
                    dt.Columns.Add("希望納期");
                    break;
                case 2:
                    dt.Columns.Add("現在庫数");
                    dt.Columns.Add("管理番号");
                    break;
            }
            dt.Columns.Add("JANCD");
            dt.Columns.Add("表示順");
            dt.Columns.Add("倉庫");
            return dt;
        }

        private void gvMainDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if(e.ColumnIndex == 11)
            {
                string val = gvMainDetail.Rows[e.RowIndex].Cells[11].EditedFormattedValue.ToString();
                if (string.IsNullOrEmpty(val))
                    gvMainDetail.Rows[e.RowIndex].Cells[11].Value = 0;
                else if (Convert.ToInt32(val) < 0)
                    gvMainDetail.Rows[e.RowIndex].Cells[11].Style.BackColor = Color.Red;

                Decimal Reserve_Val = Convert.ToDecimal(val);
                Decimal MiHikiateSuu = Convert.ToDecimal(gvMainDetail.Rows[e.RowIndex].Cells[6].EditedFormattedValue.ToString());
                Decimal HikiateZumiSuu = Convert.ToDecimal(gvMainDetail.Rows[e.RowIndex].Cells[7].EditedFormattedValue.ToString());

                if (!string.IsNullOrEmpty(gvMainDetail.Rows[e.RowIndex].Cells[12].EditedFormattedValue.ToString()))
                {
                    if (Decimal.ToInt32(HikiateZumiSuu) < Decimal.ToInt32(Reserve_Val))
                        bbl.ShowMessage("E271");

                    if (Decimal.ToInt32(MiHikiateSuu) > Decimal.ToInt32(Reserve_Val))
                        bbl.ShowMessage("E272");
                }
                else if (string.IsNullOrEmpty(gvMainDetail.Rows[e.RowIndex].Cells[12].EditedFormattedValue.ToString()))
                {
                    if (Decimal.ToInt32(Reserve_Val) > 0)
                        bbl.ShowMessage("E275");

                    if (Decimal.ToInt32(MiHikiateSuu) < Decimal.ToInt32(Reserve_Val))
                        bbl.ShowMessage("E272");
                }
            }
        }

        private void gvMainDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                bool isexists = false;
                int index = 0;
                if (dtTemp == null)
                {
                    dtTemp = createMemoryTable(1);
                    dtTemp.Columns.Add("RowNO");
                }

                for(int i = 0; i< dtTemp.Rows.Count; i++)
                {
                    if(Convert.ToInt32(dtTemp.Rows[i]["RowNO"].ToString()) == e.RowIndex)
                    {
                        isexists = true;
                        index = i;
                        break;
                    }
                }

                if(isexists)    //For multi changes
                {
                    dtTemp.Rows[index]["引当調整数"] = gvMainDetail.Rows[e.RowIndex].Cells["引当調整数"].EditedFormattedValue;
                }
                //For new changes
                else
                {
                    DataRow row = dtTemp.NewRow();
                    for(int i = 0; i< gvMainDetail.Columns.Count; i++)
                    {
                        row[i] = gvMainDetail.Rows[e.RowIndex].Cells[i].EditedFormattedValue;
                    }
                    row["RowNO"] = e.RowIndex;
                    dtTemp.Rows.Add(row);
                }
            }
        }

        private void DBData_IU()
        {
            //string Xml = string.Empty;
            //Xml = cf.DataTableToXml(dtMemory);

            for(int i=0; i<dtMemory.Rows.Count; i++)
            {
                HikiateHenkouShoukaiEntity entity = new HikiateHenkouShoukaiEntity();
                entity.ShouhinCD = dtMemory.Rows[i]["商品"].ToString();
                entity.ShouhinName = dtMemory.Rows[i]["商品名"].ToString();
                entity.ColorNO = dtMemory.Rows[i]["カラー"].ToString();
                entity.SizeNO = dtMemory.Rows[i]["サイズ"].ToString();
                entity.JuchuuSuu = dtMemory.Rows[i]["受注数"].ToString();
                entity.ChakuniYoteiSuu = dtMemory.Rows[i]["着荷予定数"].ToString();
                entity.MiHikiateSuu = dtMemory.Rows[i]["未引当数"].ToString();
                entity.HikiateZumiSuu = dtMemory.Rows[i]["引当済数"].ToString();
                entity.ChakuniSuu = dtMemory.Rows[i]["着荷済数"].ToString();
                entity.ShukkaSiziSuu = dtMemory.Rows[i]["出荷指示数"].ToString();
                entity.ShukkaSuu = dtMemory.Rows[i]["出荷済数"].ToString();
                entity.HikiateSuu = dtMemory.Rows[i]["引当調整数"].ToString();
                entity.JuchuuNO_JuchuuGyouNO = dtMemory.Rows[i]["受注番号-行番号"].ToString();
                entity.TokuisakiRyakuName = dtMemory.Rows[i]["得意先名"].ToString();
                entity.KouritenRyakuName = dtMemory.Rows[i]["小売店名"].ToString();
                entity.NyuukoDate = dtMemory.Rows[i]["入庫日"].ToString();
                entity.JuchuuDate = dtMemory.Rows[i]["受注日"].ToString();
                entity.KibouNouki = dtMemory.Rows[i]["希望納期"].ToString();
                entity.JANCD = dtMemory.Rows[i]["JANCD"].ToString();
                entity.SoukoCD = dtMemory.Rows[i]["倉庫"].ToString();
                hbl.DBData_IU(entity);
            }

            dtMemory.Clear();
            Modified_Panel();   //Clear Data
        }
    }
}
