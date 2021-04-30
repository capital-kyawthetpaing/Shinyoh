﻿using BL;
using CKM_CommonFunction;
using Entity;
using Shinyoh;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HikiateHenkouShoukai
{
    public partial class HikiateHenkouShoukai : BaseForm
    {
        BaseEntity base_entity;
        BaseBL bbl = new BaseBL();
        CommonFunction cf;
        multipurposeEntity multi_Entity;
        DataTable dt, dtMain, F8_dt1, dtTemp;
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
            SetButton(ButtonType.BType.ExcelExport, F7, "出力(F7)", true);
            SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", true);
            SetButton(ButtonType.BType.Display, F10, "表示(F10)", true);
            SetButton(ButtonType.BType.Memory, F11, "保存(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);

            Modified_Panel();
            base_entity = _GetBaseData();
            txtTokuisakiCD.E102Type = base_entity.LoginDate;        //ChangeDate value For E101 Error check of txtTokuisakiCD
            txtKouritenCD.E102Type = base_entity.LoginDate;         //ChangeDate value For E101 Error check of txtKouritenCD
            if(rdoAggregation.Checked)
                Radio_Changed(0);

            gvAggregationDetails.SetGridDesign();
            gvAggregationDetails.SetReadOnlyColumn("*");

            gvMainDetail.SetGridDesign();
            gvMainDetail.SetReadOnlyColumn("col_Detail_ShouhinCD,col_Detail_ShouhinName,col_Detail_ColorNO,col_Detail_SizeNO,col_Detail_JuchuuSuu,col_Detail_ChakuniYoteiSuu,col_Detail_MiHikiateSuu,col_Detail_HikiateZumiSuu,col_Detail_ChakuniSuu,col_Detail_ShukkaSiziSuu,col_Detail_ShukkaSuu,col_Detail_JuchuuNO_JuchuuGyouNO,col_Detail_TokuisakiRyakuName,col_Detail_KanriNO,col_Detail_NyuukoDate,col_Detail_JuchuuDate,col_Detail_KibouNouki,col_Detail_JANCD");
            gvMainDetail.SetNumberColumn("col_Detail_HikiateSuu");

            gvFreeInventoryDetails.SetGridDesign();
            gvFreeInventoryDetails.SetReadOnlyColumn("*");
            Grid_UI();

            txtBrand.lblName = lblBrandName;
            txtTokuisakiCD.lblName = lblTokuisakiName;
            txtTokuisakiCD.ChangeDate = txtChangeDate;
            txtSoukoCD.lblName = lblSoukoName;
            txtKouritenCD.lblName = lblKouritenName;
            txtKouritenCD.ChangeDate = txtChangeDate;

            chkSeasonSS.Checked = true; //HET
            chkSeasonFW.Checked = true; //HET
            cboMode.SelectedIndex = 1;  //Update(F12押下時)
        }
        private void Grid_UI()
        {
            gvAggregationDetails.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvAggregationDetails.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvAggregationDetails.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvAggregationDetails.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvAggregationDetails.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvAggregationDetails.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvAggregationDetails.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvAggregationDetails.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvAggregationDetails.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvAggregationDetails.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvAggregationDetails.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvAggregationDetails.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvAggregationDetails.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvAggregationDetails.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;

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

            gvFreeInventoryDetails.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvFreeInventoryDetails.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvFreeInventoryDetails.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvFreeInventoryDetails.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

        }
        private void Modified_Panel()
        {
            cf.Clear(PanelDetail);           
            rdoAggregation.Focus();
            UI_ErrorCheck();

            lblBrandName.Text = string.Empty;
            lblTokuisakiName.Text = string.Empty;
            lblSoukoName.Text = string.Empty;
            lblKouritenName.Text = string.Empty;
            F8_dt1 = createMemoryTable(1);
            dtMain = new DataTable();
        }

        public override void FunctionProcess(string tagID)
        {
            if (tagID == "6")
            {
                Modified_Panel();
                chkSeasonSS.Checked = true; //HET
                chkSeasonFW.Checked = true; //HET
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
                gvMainDetail.ActionType = "F10";     //to skip gv error check at the ErrorCheck() of BaseForm.cs
                gvAggregationDetails.ActionType = "F10";    //to skip gv error check at the ErrorCheck() of BaseForm.cs
                gvFreeInventoryDetails.ActionType = "F10";    //to skip gv error check at the ErrorCheck() of BaseForm.cs
                if (ErrorCheck(PanelDetail))
                    Display_Data();
                gvMainDetail.ActionType = string.Empty;    //to check gv error at the ErrorCheck() of BaseForm.cs
                gvAggregationDetails.ActionType = string.Empty;    //to check gv error at the ErrorCheck() of BaseForm.cs
                gvFreeInventoryDetails.ActionType = string.Empty;    //to check gv error at the ErrorCheck() of BaseForm.cs
            }
            if (tagID == "11")
            {
                TemporarySave_Data();
            }
            if (tagID == "12")
            {
                if (F8_dt1 == null)
                    bbl.ShowMessage("E274");
                else if (F8_dt1.Rows.Count < 1)
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
            chkSeasonFW.E188Check(true, chkSeasonFW, chkSeasonSS, "展示会 SS、展示会 FW ");
            txtSoukoCD.E102Check(true);
            txtSoukoCD.E101Check(true, "souko", txtSoukoCD, null, null);
            txtChakuniYoteiNO.E133Check(true, "HikiateHenkouShoukai", txtChakuniYoteiNO, null, null);
            txtTokuisakiCD.E101Check(true, "HikiateHenkouShoukai" , txtTokuisakiCD, null, null);
            txtKouritenCD.E101Check(true, "HikiateHenkouShoukai", txtKouritenCD, null, null);

            lblBrandName.Text = string.Empty;
            lblBrandName.BorderStyle = BorderStyle.None;
            lblTokuisakiName.Text = string.Empty;
            lblTokuisakiName.BorderStyle = BorderStyle.None;
            lblSoukoName.Text = string.Empty;
            lblSoukoName.BorderStyle = BorderStyle.None;
            lblKouritenName.Text = string.Empty;
            lblKouritenName.BorderStyle = BorderStyle.None;
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
            cf.Clear(PanelDetail);
            lblBrandName.Text = string.Empty;
            lblKouritenName.Text = string.Empty;
            lblSoukoName.Text = string.Empty;
            lblTokuisakiName.Text = string.Empty;
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
                    gvFreeInventoryDetails.Visible = false;
                    gvAggregationDetails.Location = new Point(22, 250);
                    gvAggregationDetails.Size = new Size(1430, 630);
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
                    gvFreeInventoryDetails.Visible = false;
                    gvMainDetail.Location = new Point(22, 250);
                    gvMainDetail.Size = new Size(1660, 630);
                    this.gvMainDetail.Size = new System.Drawing.Size(1300, 387);
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
                    gvFreeInventoryDetails.Visible = true;
                    gvFreeInventoryDetails.DataSource = createMemoryTable(type);
                    gvFreeInventoryDetails.Location = new Point(22, 250);
                    gvFreeInventoryDetails.Size = new Size(1100, 630);
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

        private void chkSeasonSS_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkSeasonSS.Checked)
            //    chkSeasonFW.Checked = false;
        }

        private void chkSeasonFW_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkSeasonFW.Checked)
            //    chkSeasonSS.Checked = false;
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
            if(gvFreeInventoryDetails.Rows.Count > 0 && rdoFreeInventory.Checked)
            {
                DataTable dtExcel = new DataTable();
                dt = (DataTable)gvFreeInventoryDetails.DataSource;
                dtExcel = dt.Copy();
                dtExcel.Columns.Remove(dtExcel.Columns[4]);
                dtExcel.AcceptChanges();
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = @"C:\Excel";
                saveFileDialog1.DefaultExt = "xls";
                saveFileDialog1.Filter = "ExcelFile|*.xls";
                saveFileDialog1.FileName = "在庫表.xls";
                saveFileDialog1.RestoreDirectory = true;

                if (!System.IO.Directory.Exists("C:\\Excel"))
                    System.IO.Directory.CreateDirectory("C:\\Excel");

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ExcelDesignSetting obj = new ExcelDesignSetting();
                    obj.FilePath = saveFileDialog1.FileName;
                    obj.SheetName = "在庫表";
                    obj.Start_Interior_Column = "A1";
                    obj.End_Interior_Column = "G1";
                    obj.Interior_Color = Color.Orange;
                    obj.Start_Font_Column = "A1";
                    obj.End_Font_Column = "G1";
                    obj.Font_Color = Color.Black;
                    obj.Start_Title_Center_Column = "A1";
                    obj.End_Title_Center_Column = "G1";
                    ExportCSVExcel excel = new ExportCSVExcel();
                    excel.ExportDataTableToExcel(dtExcel, obj);

                    //cf.Clear(PanelDetail);
                    //rdoFreeInventory.Focus();

                    bbl.ShowMessage("I203");
                }
            }
            else
            {
                bbl.ShowMessage("E277");
            }    
        }

        private void Confirm_Data()
        {
          
            if (F8_dt1.Rows.Count > 0)
            {
                var dtConfirm = F8_dt1.AsEnumerable().OrderBy(r => r.Field<string>("商品")).ThenBy(r => r.Field<string>("引当調整数")).ThenBy(r => r.Field<string>("表示順")).ThenBy(r => r.Field<string>("受注番号-行番号")).CopyToDataTable();
                gvMainDetail.DataSource = dtConfirm;
                gvMainDetail.Memory_Row_Count = F8_dt1.Rows.Count;
                gvAggregationDetails.Memory_Row_Count = F8_dt1.Rows.Count;      //For Error Check
                gvFreeInventoryDetails.Memory_Row_Count = F8_dt1.Rows.Count;    //For Error Check

                //DataView dv = F8_dt1.DefaultView;
                //dv.Sort = "商品 ASC, 引当調整数 ASC, 表示順 ASC, [受注番号-行番号] ASC";
                //DataTable dtBind = dv.ToTable();
                //try
                //{
                //    dtBind.Columns.RemoveAt(21);
                //    dtBind.Columns.RemoveAt(22);
                //}
                //catch { }
                //dtBind.AcceptChanges();
                ////gvMainDetail.DataSource = null;
                ////gvMainDetail.Rows.Clear();
                //gvMainDetail.DataSource = dtBind;
                //gvMainDetail.Columns[gvMainDetail.Columns.Count - 1].Visible = false;
                //gvMainDetail.Columns[gvMainDetail.Columns.Count - 2].Visible = false;
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

            if (rdoAggregation.Checked)
            {
                gvAggregationDetails.DataSource = dtMain;
                gvAggregationDetails.Focus();

                if (dtMain.Rows.Count > 0)
                {
                    gvAggregationDetails.CurrentCell = gvAggregationDetails.Rows[0].Cells[3];
                    gvAggregationDetails.Select();
                }
            }
            else if (rdoDetails.Checked)
            {
                foreach (DataRow dr in dtMain.Rows)
                {
                    bool exists = false;
                    if (F8_dt1.Rows.Count > 0)
                    {
                        //重複行はDelete
                        string HinbanCD = dr["商品"].ToString();
                        string JuchuuNo = dr["受注番号-行番号"].ToString();
                        string KanriNO = dr["小売店名"].ToString();

                        DataRow existDr1 = F8_dt1.Select("([受注番号-行番号] ='" + JuchuuNo + "' OR [受注番号-行番号] IS NULL) AND 小売店名 = '" + KanriNO + "' AND 商品 = '" + HinbanCD + "'").SingleOrDefault();
                        if (existDr1 != null)
                        {
                            dr["表示順"] = "9";
                            exists = true;
                        }
                    }                    

                    if (!string.IsNullOrWhiteSpace(dr["受注番号"].ToString()) && !exists)
                    {
                        string JuchuuNO = dr["受注番号"].ToString();
                        entity.DataKBN = 1;
                        entity.Number = JuchuuNO;
                        entity.ProgramID = ProgramID;
                        entity.PC = PCID;
                        entity.OperatorCD = OperatorCD;
                        DataTable dt = new DataTable();
                        dt = hbl.D_Exclusive_Lock_Check(entity);

                        if (dt.Rows[0]["MessageID"].ToString().Equals("S004"))
                        {
                            string Data1 = string.Empty, Data2 = string.Empty, Data3 = string.Empty;
                            Data1 = dt.Rows[0]["Program"].ToString();
                            Data2 = dt.Rows[0]["Operator"].ToString();
                            Data3 = dt.Rows[0]["PC"].ToString();

                            D_Exclusive_JuchuuNO_Delete();
                            bbl.ShowMessage("S004", Data1, Data2, Data3);
                            return;

                        }
                    }
                }

                DataRow[] select_dr1 = dtMain.Select("表示順 = '9'");
                foreach (DataRow dr in select_dr1)
                    dtMain.Rows.Remove(dr);

                //dtMain.Columns.RemoveAt(20);
                //dtMain.Columns.RemoveAt(19);
                gvMainDetail.DataSource = dtMain;

                gvMainDetail.Columns[19].Visible = false;
                gvMainDetail.Columns[20].Visible = false;
                gvMainDetail.Columns[21].Visible = false;
                gvMainDetail.Focus();
                if (dtMain.Rows.Count > 0)
                {
                    gvMainDetail.CurrentCell = gvMainDetail.Rows[0].Cells[11];
                    gvMainDetail.Select();
                }
                //gvMainDetail.Columns[gvMainDetail.Columns.Count - 1].Visible = false;
            }
            else
            {
                gvFreeInventoryDetails.DataSource = dtMain;
                gvFreeInventoryDetails.Focus();
                gvFreeInventoryDetails.CurrentCell = gvFreeInventoryDetails.Rows[0].Cells[0];
            }

            if(dtTemp != null)
                dtTemp.Clear();
        }
        private void D_Exclusive_JuchuuNO_Delete()
        {
            foreach (DataRow dr in dtMain.Rows)
            {
                if (!string.IsNullOrWhiteSpace(dr["受注番号"].ToString()))
                {
                    string JuchuuNO = dr["受注番号"].ToString();

                    DataRow[] selectRow = F8_dt1.Select("受注番号 ='" + JuchuuNO + "'");
                    if (selectRow.Length > 0)
                        continue;

                    ChakuniNyuuryoku_Entity chkLockEntity = new ChakuniNyuuryoku_Entity();
                    chkLockEntity.DataKBN = 1;
                    chkLockEntity.Number = JuchuuNO;
                    chkLockEntity.ProgramID = ProgramID;
                    chkLockEntity.PC = PCID;
                    chkLockEntity.OperatorCD = OperatorCD;
                    hbl.D_Exclusive_JuchuuNO_Delete(chkLockEntity);
                }
            }
        }
        private void TemporarySave_Data()
        {
            if (rdoDetails.Checked && gvMainDetail != null)
            {
                if(!GridErrorCheck())
                {
                    //明細部で入力した引当調整数＜＞０の明細情報を保存(Save the detail information of "引当調整数" <> 0 entered in the detail section)
                    F11_Gridview_Bind();

                    if (F8_dt1 == null)
                        F8_dt1 = createMemoryTable(1);
                    if (dtTemp != null)
                    {
                        if (F8_dt1.Rows.Count == 0)
                        {
                            foreach (DataRow temp_row in dtTemp.Rows)
                            {
                                DataRow row = F8_dt1.NewRow();
                                for (int i = 0; i < F8_dt1.Columns.Count; i++)
                                {
                                    row[i] = temp_row[i].ToString();
                                }
                                F8_dt1.Rows.Add(row);
                            }
                        }
                        else
                        {
                            foreach (DataRow temp_row in dtTemp.Rows)
                            {
                                bool isexists = false;
                                int index = 0;
                                for (int i = 0; i < F8_dt1.Rows.Count; i++)
                                {
                                    if (temp_row["商品"].ToString() == F8_dt1.Rows[i]["商品"].ToString() && temp_row["小売店名"].ToString() == F8_dt1.Rows[i]["小売店名"].ToString() && temp_row["受注番号-行番号"].ToString() == F8_dt1.Rows[i]["受注番号-行番号"].ToString())
                                    {
                                        isexists = true;
                                        index = i;
                                        break;
                                    }
                                }

                                if (isexists)
                                {
                                    F8_dt1.Rows[index]["引当調整数"] = temp_row["引当調整数"].ToString();
                                }
                                else
                                {
                                    DataRow row = F8_dt1.NewRow();
                                    for (int i = 0; i < F8_dt1.Columns.Count; i++)
                                    {
                                        row[i] = temp_row[i].ToString();
                                    }
                                    F8_dt1.Rows.Add(row);
                                }
                            }
                        }
                        dtTemp.Clear();
                    }
                    txtShouhinCD.Focus();
                }
            }
        }
        private void F11_Gridview_Bind()
        {
            for (int t = 0; t < gvMainDetail.RowCount; t++)
            {
                DataRow F8_drNew = F8_dt1.NewRow();// save updated data 
                DataGridViewRow row = gvMainDetail.Rows[t];// grid view data
                string HinbanCD = row.Cells[0].Value.ToString();
                string JuchuuNo = row.Cells[12].Value.ToString();
                string KanriNO = row.Cells[14].Value.ToString();

                DataRow[] select_dr1 = dtMain.Select("([受注番号-行番号] ='" + JuchuuNo + "' OR [受注番号-行番号] IS NULL) AND 小売店名 = '" + KanriNO + "' AND 商品 = '" + HinbanCD + "'");// original data                
                DataRow existDr1 = F8_dt1.Select("([受注番号-行番号] ='" + JuchuuNo + "' OR [受注番号-行番号] IS NULL) AND 小売店名 = '" + KanriNO + "' AND 商品 = '" + HinbanCD + "'").SingleOrDefault();
                if (existDr1 != null)
                {
                    if (row.Cells[11].Value.ToString() == "0")
                    {
                        F8_dt1.Rows.Remove(existDr1);
                        existDr1 = null;
                    }
                }
                F8_drNew[0] = HinbanCD;
                if (row.Cells[11].Value.ToString() != "0")
                {
                    for (int c = 1; c < gvMainDetail.Columns.Count; c++)
                    {
                        if (c == 11)
                        {
                            if (existDr1 != null)
                            {
                                if (select_dr1.Length > 0 &&  select_dr1[0][c].ToString() != row.Cells[c].Value.ToString())
                                {
                                    //bl = true;
                                    F8_drNew[c] = row.Cells[c].Value;
                                }
                                else
                                {
                                    F8_drNew[c] = existDr1[c];
                                }
                            }
                            else
                            {
                                F8_drNew[c] = row.Cells[c].Value;
                            }
                        }
                        else
                        {
                            F8_drNew[c] = row.Cells[c].Value;
                        }
                    }
                    // grid 1 insert(if exist, remove exist and insert)
                    if (existDr1 != null)
                        F8_dt1.Rows.Remove(existDr1);
                    F8_dt1.Rows.Add(F8_drNew);

                }
            }
            gvMainDetail.Memory_Row_Count = F8_dt1.Rows.Count;
            gvAggregationDetails.Memory_Row_Count = F8_dt1.Rows.Count;      //For Error Check
            gvFreeInventoryDetails.Memory_Row_Count = F8_dt1.Rows.Count;    //For Error Check

            //Focus_Clear();
        }
        private bool GridErrorCheck()
        {
            bool iserror = false;
            foreach (DataGridViewRow gvrow in gvMainDetail.Rows)
            {
                //明細部で入力した引当調整数＜＞０の明細情報を保存(Save the detail information of "引当調整数" <> 0 entered in the detail section)
                if (gvrow.Cells[11].EditedFormattedValue.ToString() != "0")
                {
                    string val = gvrow.Cells[11].EditedFormattedValue.ToString();
                    Decimal Reserve_Val = Convert.ToDecimal(val);
                    Decimal MiHikiateSuu = Convert.ToDecimal(gvrow.Cells[6].EditedFormattedValue.ToString());
                    Decimal HikiateZumiSuu = Convert.ToDecimal(gvrow.Cells[7].EditedFormattedValue.ToString());

                    //該当行が受注行（受注番号-行番号 is not null）について、以下の場合はErrorとする。
                    if (!string.IsNullOrEmpty(gvrow.Cells[12].EditedFormattedValue.ToString()))
                    {
                        if (Decimal.ToInt32(HikiateZumiSuu) < Decimal.ToInt32(Reserve_Val)*(-1))
                        {
                            iserror = true;
                            bbl.ShowMessage("E271");
                        }

                        else if (Decimal.ToInt32(MiHikiateSuu) > Decimal.ToInt32(Reserve_Val))
                        {
                            iserror = true;
                            bbl.ShowMessage("E272");
                        }
                    }
                    //該当行が在庫行（受注番号-行番号 is null）について、以下の場合はErrorとする。
                    else
                    {
                        if (Decimal.ToInt32(Reserve_Val) > 0)
                        {
                            iserror = true;
                            bbl.ShowMessage("E275");
                        }

                        else if (Decimal.ToInt32(MiHikiateSuu) < Decimal.ToInt32(Reserve_Val)*(-1))
                        {
                            iserror = true;
                            bbl.ShowMessage("E272");
                        }
                    }

                    if (iserror)
                    {
                        gvMainDetail.Focus();
                        gvMainDetail.CurrentCell = gvrow.Cells[11];
                        break;
                    }
                    else
                    {
                        bool isexists = false;
                        int index = 0;
                        if (dtTemp == null)
                        {
                            dtTemp = createMemoryTable(1);
                            dtTemp.Columns.Add("RowNO");
                        }

                        for (int i = 0; i < dtTemp.Rows.Count; i++)
                        {
                            if (dtTemp.Rows[i]["商品"].ToString() == gvrow.Cells["col_Detail_ShouhinCD"].ToString() && dtTemp.Rows[i]["小売店名"].ToString() == gvrow.Cells["col_Detail_KanriNO"].ToString() && dtTemp.Rows[i]["受注番号-行番号"].ToString() == gvrow.Cells["col_Detail_JuchuuNO_JuchuuGyouNO"].ToString())
                            {
                                isexists = true;
                                index = i;
                                break;
                            }
                        }

                        if (isexists)    //For multi changes
                        {
                            dtTemp.Rows[index]["引当調整数"] = gvrow.Cells["col_Detail_HikiateSuu"].EditedFormattedValue;
                        }
                        //For new changes
                        else
                        {
                            DataRow row = dtTemp.NewRow();
                            for (int i = 0; i < gvMainDetail.Columns.Count; i++)
                            {
                                row[i] = gvrow.Cells[i].EditedFormattedValue;
                            }
                            row["RowNO"] = gvrow.Index;
                            dtTemp.Rows.Add(row);
                        }
                    }
                }
            }

            if (iserror)
                return true;
            else
                return false;
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
            if(type == 1)
            {
                dt.Columns.Add("表示順");
                dt.Columns.Add("倉庫");
                dt.Columns.Add("受注番号");
            }
            return dt;
        }

        private void gvMainDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(gvMainDetail.IsLastKeyEnter)
            {
                string val = gvMainDetail.Rows[e.RowIndex].Cells[11].EditedFormattedValue.ToString();
                if (string.IsNullOrEmpty(val))
                    gvMainDetail.Rows[e.RowIndex].Cells[11].Value = 0;
                else if (Convert.ToInt32(val) < 0)
                    gvMainDetail.Rows[e.RowIndex].Cells[11].Style.ForeColor = Color.Red;
            }
        }

        private void DBData_IU()
        {
            using (SqlConnection sqlConnection = new SqlConnection(hbl.GetCon()))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Transaction = sqlTransaction;
                sqlCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    string Xml = string.Empty;
                    Xml = cf.DataTableToXml(F8_dt1);

                    //for (int i = 0; i < F8_dt1.Rows.Count; i++)
                    //{
                    HikiateHenkouShoukaiEntity entity = new HikiateHenkouShoukaiEntity();
                    entity.InsertOperator = OperatorCD;
                    entity.PC = PCID;
                    //    entity.ShouhinCD = F8_dt1.Rows[i]["商品"].ToString();
                    //    entity.ShouhinName = F8_dt1.Rows[i]["商品名"].ToString();
                    //    entity.ColorNO = F8_dt1.Rows[i]["カラー"].ToString();
                    //    entity.SizeNO = F8_dt1.Rows[i]["サイズ"].ToString();
                    //    entity.JuchuuSuu = F8_dt1.Rows[i]["受注数"].ToString();
                    //    entity.ChakuniYoteiSuu = F8_dt1.Rows[i]["着荷予定数"].ToString();
                    //    entity.MiHikiateSuu = F8_dt1.Rows[i]["未引当数"].ToString();
                    //    entity.HikiateZumiSuu = F8_dt1.Rows[i]["引当済数"].ToString();
                    //    entity.ChakuniSuu = F8_dt1.Rows[i]["着荷済数"].ToString();
                    //    entity.ShukkaSiziSuu = F8_dt1.Rows[i]["出荷指示数"].ToString();
                    //    entity.ShukkaSuu = F8_dt1.Rows[i]["出荷済数"].ToString();
                    //    entity.HikiateSuu = F8_dt1.Rows[i]["引当調整数"].ToString();
                    //    entity.JuchuuNO_JuchuuGyouNO = F8_dt1.Rows[i]["受注番号-行番号"].ToString();
                    //    entity.TokuisakiRyakuName = F8_dt1.Rows[i]["得意先名"].ToString();
                    //    entity.KouritenRyakuName = F8_dt1.Rows[i]["小売店名"].ToString();
                    //    entity.NyuukoDate = F8_dt1.Rows[i]["入庫日"].ToString();
                    //    entity.JuchuuDate = F8_dt1.Rows[i]["受注日"].ToString();
                    //    entity.KibouNouki = F8_dt1.Rows[i]["希望納期"].ToString();
                    //    entity.JANCD = F8_dt1.Rows[i]["JANCD"].ToString();
                    //    entity.SoukoCD = F8_dt1.Rows[i]["倉庫"].ToString();
                    //    hbl.DBData_IU(entity);
                    //}

                    string return_BL = hbl.DBData_IU(entity, Xml, sqlCommand);
                    if (return_BL == "true")
                        bbl.ShowMessage("I101");

                    sqlTransaction.Commit();
                    
                    Modified_Panel();   //Clear Data
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    bbl.ShowMessage(ex.Message);
                }
            }
        }
    }
}
