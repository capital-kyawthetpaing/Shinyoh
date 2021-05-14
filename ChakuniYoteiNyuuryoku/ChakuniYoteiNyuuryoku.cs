using System;
using Shinyoh;
using Entity;
using BL;
using CKM_CommonFunction;
using Shinyoh_Details;
using System.Windows.Forms;
using Shinyoh_Controls;
using Shinyoh_Search;
using System.Data;
using System.Linq;

namespace ChakuniYoteiNyuuryoku
{
    public partial class ChakuniYoteiNyuuryoku : BaseForm
    {
        CommonFunction cf;
        multipurposeEntity multi_Entity;
        BaseEntity base_Entity;
        StaffBL staffBL;
        SoukoBL soukoBL;
        BaseBL bbl;
        SiiresakiDetail sd;
        DataTable dtmain;
        DataTable F8_dt1;
        DataTable dtTemp;
        DataTable dtClear;
        public string detail_XML;
        ChakuniYoteiNyuuryokuEntity chkEntity;
        ChakuniYoteiNyuuryoku_BL cbl;
        public string tdDate;
        DataTable dt_Header, dt_Details;
        public ChakuniYoteiNyuuryoku()
        {
            InitializeComponent();
            cf = new CommonFunction();
            base_Entity = new BaseEntity();
            staffBL = new StaffBL();
            soukoBL = new SoukoBL();
            bbl = new BaseBL();
            dtmain = new DataTable();
            dt_Header = new DataTable();
            dt_Details = new DataTable();
            chkEntity = new ChakuniYoteiNyuuryokuEntity();
            cbl = new ChakuniYoteiNyuuryoku_BL();           
            F8_dt1 = CreateTable_Detail();
            dtTemp = new DataTable();
            dtClear= CreateTable_Detail();

            //this.gvChakuniYoteiNyuuryoku.Size = new System.Drawing.Size(1300, 387);
        }
        private void ChakuniYoteiNyuuryoku_Load(object sender, EventArgs e)
        {
            ProgramID = "ChakuniYoteiNyuuryoku";
            StartProgram();
            cboMode.Bind(false, multi_Entity);
            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "新規(F2)", true);
            SetButton(ButtonType.BType.Update, F3, "修正(F3)", true);
            SetButton(ButtonType.BType.Delete, F4, "削除(F4)", true);
            SetButton(ButtonType.BType.Inquiry, F5, "照会(F5)", true);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", true);
            SetButton(ButtonType.BType.Display, F10, "表示(F10)", true);
            SetButton(ButtonType.BType.Memory, F11, "保存(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            
            txtChakuniYoteiNO.Focus();
            base_Entity = _GetBaseData();
            txtSiiresaki.ChangeDate = txtDate;
            txtStaffCD.ChangeDate = txtDate;
            txtChakuniYoteiNO.ChangeDate = txtDate;
            txtShouhinCD.ChangeDate = txtDate;
            lblSiiresaki.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblStaff.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblWareHouse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblBrandName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            gvChakuniYoteiNyuuryoku.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvChakuniYoteiNyuuryoku.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvChakuniYoteiNyuuryoku.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvChakuniYoteiNyuuryoku.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvChakuniYoteiNyuuryoku.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvChakuniYoteiNyuuryoku.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvChakuniYoteiNyuuryoku.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvChakuniYoteiNyuuryoku.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
            txtSiiresaki.lblName = lblSiiresaki;
            txtStaffCD.lblName = lblStaff;
            txtSouko.lblName = lblWareHouse;
            txtBrandCD.lblName = lblBrandName;
            gvChakuniYoteiNyuuryoku.SetGridDesign();
            gvChakuniYoteiNyuuryoku.SetReadOnlyColumn("colShouhinCD,colShouhinName,colColorRyakuName,colColorNO,colSizeNO,colDate,colHacchuuSuu,colChakuniZumiSuu,colJanCD,colHacchuu");
            gvChakuniYoteiNyuuryoku.SetHiraganaColumn("colDetails");
            gvChakuniYoteiNyuuryoku.SetNumberColumn("colYoteiSuu");
            ChangeMode(Mode.New);
        }
        private void ChangeMode(Mode mode)
        {
            switch (mode)
            {
                case Mode.New:
                    ErrorCheck();
                    New_Mode();
                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    sd = new SiiresakiDetail();
                    btnNew.Visible = true;
                    cboMode.Enabled = false;
                    break;
                case Mode.Update:
                    txtChakuniYoteiNO.E102Check(true);
                    txtChakuniYoteiNO.E133Check(true, "ChakuniYoteiNyuuryoku", txtChakuniYoteiNO, null, null);
                    //txtChakuniYoteiNO.E268Check(true, "ChakuniYoteiNyuuryoku", txtChakuniYoteiNO, null);
                    Mode_Setting();
                    sd = new SiiresakiDetail();
                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    txtChakuniYoteiNO.E102Check(true);
                    txtChakuniYoteiNO.E133Check(true, "ChakuniYoteiNyuuryoku", txtChakuniYoteiNO, null, null);
                    //txtChakuniYoteiNO.E268Check(true, "ChakuniYoteiNyuuryoku", txtChakuniYoteiNO, null);
                    Mode_Setting();
                    sd = new SiiresakiDetail(false);
                    //btn_Siiresaki.Enabled = true;
                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;
                    break;
                case Mode.Inquiry:
                    txtChakuniYoteiNO.E102Check(true);
                    txtChakuniYoteiNO.E133Check(true, "ChakuniYoteiNyuuryoku", txtChakuniYoteiNO, null, null);
                    //txtChakuniYoteiNO.E268Check(true, "ChakuniYoteiNyuuryoku", txtChakuniYoteiNO, null);
                    Mode_Setting();
                    sd = new SiiresakiDetail(false);
                    //btn_Siiresaki.Enabled = true;
                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;
                    SetButton(ButtonType.BType.Save, F12, "登録(F12)", false);
                    break;
            }
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "2")
            {
                ChangeMode(Mode.New);
            }
            if (tagID == "3")
            {
                ChangeMode(Mode.Update);
            }
            if (tagID == "4")
            {
                ChangeMode(Mode.Delete);
            }
            if (tagID == "5")
            {
                ChangeMode(Mode.Inquiry);
            }
            if (tagID == "6")
            {
                if (cboMode.SelectedValue.Equals("1"))
                {
                    New_Mode();
                }
                else
                {
                    Mode_Setting();                 
                }
                dtTemp.Clear();
                Disable();
            }
            if (tagID == "8")
            {
                D_Exclusive_HacchuuNO_Delete();

                if (F8_dt1.Rows.Count > 0)
                {
                    var dtConfirm = F8_dt1.AsEnumerable().OrderBy(r => r.Field<string>("ShouhinCD")).ThenBy(r => r.Field<string>("HacchuuDate")).ThenBy(r => r.Field<string>("Hacchuu")).CopyToDataTable();
                    gvChakuniYoteiNyuuryoku.DataSource = dtConfirm;
                }
                else
                {
                    F8_dt1 = CreateTable_Detail();
                    gvChakuniYoteiNyuuryoku.DataSource = F8_dt1;
                }
            }
            if (tagID == "10")
            {
                F10_Gridview_Bind();
            }
            if (tagID == "11")
            {
                if (GV_Check())
                {
                    F11_Gridview_Bind();
                }
            }
            if (tagID == "12")
            {
                if (Temp_Null())
                {
                    if (F8_dt1.Rows.Count > 0 || dt_Details.Rows.Count > 0)
                    {
                        try
                        {
                            DBProcess();
                            switch (cboMode.SelectedValue)
                            {
                                case "1":
                                    ChangeMode(Mode.New);
                                    break;
                                case "2":
                                    ChangeMode(Mode.Update);
                                    break;
                                case "3":
                                    ChangeMode(Mode.Delete);
                                    break;
                                case "4":
                                    ChangeMode(Mode.Inquiry);
                                    break;
                                    //}
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, ex.Message, this.Text);
                        }
                    }
                }
            }
            base.FunctionProcess(tagID);
        }
        private void F10_Gridview_Bind()
        {
            gvChakuniYoteiNyuuryoku.ActionType = "F10";
            if (ErrorCheck(PanelDetail))
            {
                ChakuniYoteiNyuuryokuEntity chkEntity = new ChakuniYoteiNyuuryokuEntity();
                chkEntity.ChakuniYoteiNO = txtChakuniYoteiNO.Text;
                chkEntity.ChakuniYoteiDate = txtDate.Text;
                chkEntity.BrandCD = txtBrandCD.Text;
                chkEntity.HinbanCD = txtShouhinCD.Text;
                chkEntity.ShouhinName = txtShouhinName.Text;
                chkEntity.JANCD = txtJANCD.Text;
                chkEntity.YearTerm = txtYearTerm.Text;
                chkEntity.SeasonSS = chkSS.Checked ? "1" : "0";
                chkEntity.SeasonFW = chkFW.Checked ? "1" : "0";
                chkEntity.ColorNO = txtColorNo.Text;
                chkEntity.SizeNO = txtSizeNo.Text;
                chkEntity.SoukoCD = txtSouko.Text;
                chkEntity.ChakuniYoteiDateFrom = txtDateFrom.Text;
                chkEntity.ChakuniYoteiDateTo = txtDateTo.Text;
                chkEntity.OperatorCD = OperatorCD;
                chkEntity.ProgramID = ProgramID;
                chkEntity.PC = PCID;
                if (string.IsNullOrWhiteSpace(txtBrandCD.Text) && string.IsNullOrWhiteSpace(txtShouhinCD.Text) && string.IsNullOrWhiteSpace(txtShouhinName.Text) &&
                   string.IsNullOrWhiteSpace(txtJANCD.Text) && string.IsNullOrWhiteSpace(txtYearTerm.Text) && (!chkFW.Checked) && (!chkSS.Checked) && string.IsNullOrWhiteSpace(txtColorNo.Text) && string.IsNullOrWhiteSpace(txtDateFrom.Text) && string.IsNullOrWhiteSpace(txtDateTo.Text) && string.IsNullOrWhiteSpace(txtSizeNo.Text))
                {
                    bbl.ShowMessage("E111");
                    txtBrandCD.Focus();
                }
                else
                {
                    D_Exclusive_HacchuuNO_Delete();
                    
                    dtmain = cbl.ChakuniYoteiNyuuryoku_Display(chkEntity);
                  
                    foreach (DataRow dr in dtmain.Rows)
                    {
                        bool exists = false;
                        if (F8_dt1.Rows.Count > 0)
                        {
                            //重複行はDelete
                            string Hacchuu = dr["Hacchuu"].ToString();
                            DataRow existDr1 = F8_dt1.Select("Hacchuu ='" + Hacchuu + "'").SingleOrDefault();
                            if (existDr1 != null)
                            {
                                dr["ChakuniYoteiGyouNO"] = "9";    //未使用項目のため
                                exists = true;
                            }
                        }

                        if (!exists)
                        {
                            string HacchuuNO = dr["HacchuuNO"].ToString();
                            DataRow[] selectRow = F8_dt1.Select("HacchuuNO ='" + HacchuuNO + "'");
                            if (selectRow.Length > 0)
                                continue;

                            ChakuniNyuuryoku_Entity chkLockEntity = new ChakuniNyuuryoku_Entity();
                            chkLockEntity.DataKBN = 2;
                            chkLockEntity.Number = HacchuuNO;
                            chkLockEntity.ProgramID = ProgramID;
                            chkLockEntity.PC = PCID;
                            chkLockEntity.OperatorCD = OperatorCD;
                            DataTable dt1 = new DataTable();
                            cbl = new ChakuniYoteiNyuuryoku_BL();
                            dt1 = cbl.D_Exclusive_Lock_Check(chkLockEntity);
                            if (dt1.Rows[0]["MessageID"].ToString().Equals("S004"))
                            {
                                string Data1 = string.Empty, Data2 = string.Empty, Data3 = string.Empty;
                                Data1 = dt1.Rows[0]["Program"].ToString();
                                Data2 = dt1.Rows[0]["Operator"].ToString();
                                Data3 = dt1.Rows[0]["PC"].ToString();

                                bbl.ShowMessage("S004", Data1, Data2, Data3);
                                //if (dr != null)
                                //    Gvrow_Delete(dr);
                                D_Exclusive_HacchuuNO_Delete();
                                return;
                            }
                        }
                        //dtGridSource = dtmain.Copy();     
                    }

                    DataRow[] select_dr1 = dtmain.Select("ChakuniYoteiGyouNO = '9'");
                    foreach (DataRow dr in select_dr1)
                        dtmain.Rows.Remove(dr);

                    gvChakuniYoteiNyuuryoku.DataSource = dtmain;
                    gvChakuniYoteiNyuuryoku.Select();
                    Disable();
                    if (dtmain.Rows.Count > 0)   //HET
                        gvChakuniYoteiNyuuryoku.CurrentCell = gvChakuniYoteiNyuuryoku.Rows[0].Cells["colYoteiSuu"];
                }
            }
            gvChakuniYoteiNyuuryoku.ActionType = string.Empty;
        }
        private void D_Exclusive_HacchuuNO_Delete()
        {
            if (cboMode.SelectedValue.ToString() == "2" || cboMode.SelectedValue.ToString() == "1")//update
            {
                foreach (DataRow dr in dtmain.Rows)
                {
                    D_Exclusive_OneNumber_Delete(dr);
                }
            }
        }
        private void D_Exclusive_OneNumber_Delete(DataRow dr)
        {
            string HacchuuNO = dr["HacchuuNO"].ToString();

            DataRow[] selectRow = F8_dt1.Select("HacchuuNO ='" + HacchuuNO + "'");
            if (selectRow.Length > 0)
                return;

            ChakuniNyuuryoku_Entity chkLockEntity = new ChakuniNyuuryoku_Entity();
            chkLockEntity.DataKBN = 2;
            chkLockEntity.Number = HacchuuNO;
            chkLockEntity.ProgramID = ProgramID;
            chkLockEntity.PC = PCID;
            chkLockEntity.OperatorCD = OperatorCD;
            cbl.D_Exclusive_HacchuuNO_Delete(chkLockEntity);
        }
        private void D_Exclusive_OneNumber_Insert(DataRow dr)
        {
            string HacchuuNO = dr["HacchuuNO"].ToString();

            DataRow[] selectRow = F8_dt1.Select("HacchuuNO ='" + HacchuuNO + "'");
            if (selectRow.Length == 0)
                return;

            ChakuniNyuuryoku_Entity chkLockEntity = new ChakuniNyuuryoku_Entity();
            chkLockEntity.DataKBN = 2;
            chkLockEntity.Number = HacchuuNO;
            chkLockEntity.ProgramID = ProgramID;
            chkLockEntity.PC = PCID;
            chkLockEntity.OperatorCD = OperatorCD;
            cbl.D_Exclusive_Lock_Check(chkLockEntity);
        }
        //private void Gvrow_Delete(DataRow dr)
        //{
        //    DataRow[] existDr1;
        //    if (dr["HacchuuNO"] != null)
        //    {
        //        DataRow[] selectRow = F8_dt1.Select("HacchuuNO ='" + dr["HacchuuNO"] + "'");
        //        if (selectRow.Length > 0)
        //            return;

        //        existDr1 = dtmain.Select("HacchuuNO ='" + dr["HacchuuNO"] + "'");
        //        foreach (DataRow row in existDr1)
        //        {
        //            dtmain.Rows.Remove(row);// Here The given DataRow is not in the current DataRowCollection
        //        }
        //    }
        //}

        private void DBProcess()
        {
            string mode = string.Empty;
            (string, string) obj = GetInsert();
            if (cboMode.SelectedValue.Equals("1"))
            {
                mode = "New";
                DoInsert(mode, obj.Item1, obj.Item2);
            }
            else if (cboMode.SelectedValue.Equals("2"))
            {
                mode = "Update";
                DoUpdate(mode, obj.Item1, obj.Item2);
            }
            else if (cboMode.SelectedValue.Equals("3"))
            {
                mode = "Delete";
                DoDelete(mode, obj.Item1, obj.Item2);
            }
        }
        private void DoInsert(string mode, string str_main, string str_detail)
        {
            ChakuniYoteiNyuuryoku_BL bl = new ChakuniYoteiNyuuryoku_BL();
            bl.ChakuniYoteiNyuuryoku_IUD(mode, str_main, str_detail);
            bbl.ShowMessage("I101");
        }
        private void DoUpdate(string mode, string str_main, string str_detail)
        {
            ChakuniYoteiNyuuryoku_BL bl = new ChakuniYoteiNyuuryoku_BL();
            bl.ChakuniYoteiNyuuryoku_IUD(mode, str_main, str_detail);
            bbl.ShowMessage("I101");
        }
        private void DoDelete(string mode, string str_main, string str_detail)
        {
            ChakuniYoteiNyuuryoku_BL bl = new ChakuniYoteiNyuuryoku_BL();
            bl.ChakuniYoteiNyuuryoku_IUD(mode, str_main, str_detail);
            bbl.ShowMessage("I102");
        }
        public void Create_Datatable_Column(DataTable create_dt)
        {
            create_dt.Columns.Add("ChakuniYoteiNO", typeof(string));
            create_dt.Columns.Add("ChakuniYoteiDate", typeof(string));
            create_dt.Columns.Add("SiiresakiCD", typeof(string));
            create_dt.Columns.Add("SiiresakiName", typeof(string));
            create_dt.Columns.Add("SiiresakiRyakuName", typeof(string));
            create_dt.Columns.Add("SiiresakiYuubinNO1", typeof(string));
            create_dt.Columns.Add("SiiresakiYuubinNO2", typeof(string));
            create_dt.Columns.Add("SiiresakiJuusho1", typeof(string));
            create_dt.Columns.Add("SiiresakiJuusho2", typeof(string));
            create_dt.Columns.Add("SiiresakiTelNO11", typeof(string));
            create_dt.Columns.Add("SiiresakiTelNO12", typeof(string));
            create_dt.Columns.Add("SiiresakiTelNO13", typeof(string));
            create_dt.Columns.Add("SiiresakiTelNO21", typeof(string));
            create_dt.Columns.Add("SiiresakiTelNO22", typeof(string));
            create_dt.Columns.Add("SiiresakiTelNO23", typeof(string));
            create_dt.Columns.Add("StaffCD", typeof(string));
            create_dt.Columns.Add("SoukoCD", typeof(string));
            create_dt.Columns.Add("KanriNO", typeof(string));
            create_dt.Columns.Add("ChakuniYoteiDenpyouTekiyou", typeof(string));
            create_dt.Columns.Add("BrandCD", typeof(string));
            create_dt.Columns.Add("ShouhinCD", typeof(string));
            create_dt.Columns.Add("ShouhinName", typeof(string));
            create_dt.Columns.Add("JANCD", typeof(string));
            create_dt.Columns.Add("YearTerm", typeof(string));
            create_dt.Columns.Add("SeasonSS", typeof(string));
            create_dt.Columns.Add("SeasonFW", typeof(string));
            create_dt.Columns.Add("ColorNO", typeof(string));
            create_dt.Columns.Add("ChakuniYoteiDateFrom", typeof(string));
            create_dt.Columns.Add("ChakuniYoteiDateTo", typeof(string));
            create_dt.Columns.Add("SizeNO", typeof(string));
            create_dt.Columns.Add("Operator", typeof(string));
            create_dt.Columns.Add("PC", typeof(string));
            create_dt.Columns.Add("ProgramID", typeof(string));
        }
        private (string, string) GetInsert()
        {
            SiiresakiEntity s_obj = sd.Access_Siiresaki_obj;
            DataTable dt = new DataTable();
            Create_Datatable_Column(dt);
            DataRow dr = dt.NewRow();
            if (cboMode.SelectedValue.ToString() != "1")
            {
                dr["ChakuniYoteiNO"] = txtChakuniYoteiNO.Text;
            }
            dr["ChakuniYoteiDate"] = txtDate.Text;
            dr["SiiresakiCD"] = txtSiiresaki.Text;
            dr["SiiresakiName"] = s_obj.SiiresakiName;
            dr["SiiresakiRyakuName"] = s_obj.SiiresakiRyakuName;
            dr["SiiresakiYuubinNO1"] = string.IsNullOrEmpty(s_obj.YuubinNO1) ? null : s_obj.YuubinNO1;
            dr["SiiresakiYuubinNO2"] = string.IsNullOrEmpty(s_obj.YuubinNO2) ? null : s_obj.YuubinNO2;
            dr["SiiresakiJuusho1"] = string.IsNullOrEmpty(s_obj.Juusho1) ? null : s_obj.Juusho1;
            dr["SiiresakiJuusho2"] = string.IsNullOrEmpty(s_obj.Juusho2) ? null : s_obj.Juusho2;
            dr["SiiresakiTelNO11"] = string.IsNullOrEmpty(s_obj.Tel11) ? null : s_obj.Tel11;
            dr["SiiresakiTelNO12"] = string.IsNullOrEmpty(s_obj.Tel12) ? null : s_obj.Tel12;
            dr["SiiresakiTelNO13"] = string.IsNullOrEmpty(s_obj.Tel13) ? null : s_obj.Tel13;
            dr["SiiresakiTelNO21"] = string.IsNullOrEmpty(s_obj.Tel21) ? null : s_obj.Tel21;
            dr["SiiresakiTelNO22"] = string.IsNullOrEmpty(s_obj.Tel22) ? null : s_obj.Tel22;
            dr["SiiresakiTelNO23"] = string.IsNullOrEmpty(s_obj.Tel23) ? null : s_obj.Tel23;
            dr["StaffCD"] = txtStaffCD.Text;
            dr["SoukoCD"] = txtSouko.Text;
            dr["KanriNO"] = txtNumber.Text;
            dr["ChakuniYoteiDenpyouTekiyou"] = string.IsNullOrEmpty(txtDescription.Text) ? null : txtDescription.Text;
            dr["BrandCD"] = string.IsNullOrEmpty(txtBrandCD.Text) ? null : txtBrandCD.Text;
            dr["ShouhinCD"] = string.IsNullOrEmpty(txtShouhinCD.Text) ? null : txtShouhinCD.Text;
            dr["ShouhinName"] = string.IsNullOrEmpty(txtShouhinName.Text) ? null : txtShouhinName.Text;
            dr["JANCD"] = string.IsNullOrEmpty(txtJANCD.Text) ? null : txtJANCD.Text;
            dr["YearTerm"] = string.IsNullOrEmpty(txtYearTerm.Text) ? null : txtYearTerm.Text;
            dr["SeasonSS"] = chkSS.Checked ? "1" : "0";
            dr["SeasonFW"] = chkFW.Checked ? "1" : "0";
            dr["ColorNO"] = string.IsNullOrEmpty(txtColorNo.Text) ? null : txtColorNo.Text;
            dr["ChakuniYoteiDateFrom"] = string.IsNullOrEmpty(txtDateFrom.Text) ? null : txtDateFrom.Text;
            dr["ChakuniYoteiDateTo"] = string.IsNullOrEmpty(txtDateTo.Text) ? null : txtDateTo.Text;
            dr["SizeNO"] = string.IsNullOrEmpty(txtSizeNo.Text) ? null : txtSizeNo.Text;

            dr["Operator"] = base_Entity.OperatorCD;
            dr["PC"] = base_Entity.PC;
            dr["ProgramID"] = base_Entity.ProgramID;
            dt.Rows.Add(dr);
            string main_XML = cf.DataTableToXml(dt);
            if (cboMode.SelectedValue.ToString() == "3")
            {
                //DataTable dt1 = txtChakuniYoteiNO.IsDatatableOccurs;
                //dt1.Columns.Remove("ChakuniYoteiDate");
                //dt1.Columns.Remove("SiiresakiCD");
                //dt1.Columns.Remove("SiiresakiName");
                //dt1.Columns.Remove("SiiresakiRyakuName");
                //dt1.Columns.Remove("SiiresakiYuubinNO1");
                //dt1.Columns.Remove("SiiresakiYuubinNO2");
                //dt1.Columns.Remove("SiiresakiJuusho1");
                //dt1.Columns.Remove("SiiresakiJuusho2");
                //dt1.Columns.Remove("SiiresakiTelNO1-1");
                //dt1.Columns.Remove("SiiresakiTelNO1-2");
                //dt1.Columns.Remove("SiiresakiTelNO1-3");
                //dt1.Columns.Remove("SiiresakiTelNO2-1");
                //dt1.Columns.Remove("SiiresakiTelNO2-2");
                //dt1.Columns.Remove("SiiresakiTelNO2-3");
                //dt1.Columns.Remove("KanriNO");
                //dt1.Columns.Remove("StaffCD");
                //dt1.Columns.Remove("StaffName");
                //dt1.Columns.Remove("SoukoCD");
                //dt1.Columns.Remove("SoukoName");
                //dt1.Columns.Remove("ChakuniYoteiDenpyouTekiyou");
                //dt1.Columns.Remove("MessageID");
                //dt1.Columns.Remove("Hacchuu");
                detail_XML = cf.DataTableToXml(dt_Details);
            }
            else
            {
                detail_XML = cf.DataTableToXml(F8_dt1);
            }

            return (main_XML, detail_XML);
        }
        private void Mode_Setting()
        {
            cf.Clear(PanelTitle);
            cf.Clear(PanelDetail);
            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(PanelDetail);
            lblSiiresaki.Text = string.Empty;
            lblStaff.Text = string.Empty;
            lblWareHouse.Text = string.Empty;
            txtChakuniYoteiNO.Focus();
            chkSS.Checked = true; //HET
            chkFW.Checked = true; //HET

            F8_dt1 = CreateTable_Detail();

            BaseEntity be = new BaseEntity();
            be.ProgramID = ProgramID;
            be.OperatorCD = OperatorCD;
            be.PC = PCID;
            BaseBL bbl = new BaseBL();
            bbl.D_Exclusive_Number_Remove(be);

            //HET
            if (cboMode.SelectedValue.Equals("2") || cboMode.SelectedValue.Equals("3") || cboMode.SelectedValue.Equals("4"))
            {
                txtChakuniYoteiNO.Focus();
                SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", false);
                SetButton(ButtonType.BType.Display, F10, "表示(F10)", false);
                SetButton(ButtonType.BType.Memory, F11, "保存(F11)", false);
            }
        }
        private void New_Mode()
        {
            cf.Clear(PanelTitle);
            cf.Clear(PanelDetail);
            cf.DisablePanel(PanelTitle);
            //cboMode.Enabled = true;       //Task 291 TZA
            cf.EnablePanel(PanelDetail);
            txtDate.Focus();
            tdDate = DateTime.Now.ToString("yyyy/MM/dd");
            txtDate.Text = tdDate;
            StaffEntity staffEntity = new StaffEntity
            {
                StaffCD = OperatorCD
            };
            staffEntity = staffBL.GetStaffEntity(staffEntity);
            txtStaffCD.Text = OperatorCD;
            lblStaff.Text = staffEntity.StaffName;
            SoukoEntity soukoEntity = new SoukoEntity();
            soukoEntity = soukoBL.GetSoukoEntity(soukoEntity);
            txtSouko.Text = soukoEntity.SoukoCD;
            lblWareHouse.Text = soukoEntity.SoukoName;
            lblSiiresaki.Text = string.Empty;
            chkSS.Checked = true; //HET
            chkFW.Checked = true; //HET

            F8_dt1 = CreateTable_Detail();

            BaseEntity be = new BaseEntity();
            be.ProgramID = ProgramID;
            be.OperatorCD = OperatorCD;
            be.PC = PCID;
            BaseBL bbl = new BaseBL();
            bbl.D_Exclusive_Number_Remove(be);

            //HET
            SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", true);
            SetButton(ButtonType.BType.Display, F10, "表示(F10)", true);
            SetButton(ButtonType.BType.Memory, F11, "保存(F11)", true);
        }
        private bool Temp_Null()
        {
            if (cboMode.SelectedValue.ToString().Equals("1") && F8_dt1.Rows.Count == 0 || cboMode.SelectedValue.ToString().Equals("2") && F8_dt1.Rows.Count == 0)
            {
                bbl.ShowMessage("E274");
                return false;
            }
            return true;
        }
        public void ErrorCheck()
        {
            txtDate.E102Check(true);
            txtDate.E103Check(true);
            txtSiiresaki.E102Check(true);
            txtSiiresaki.E101Check(true, "M_Siiresaki", txtSiiresaki, txtDate, null);
            //txtSiiresaki.E227Check(true, "M_Siiresaki", txtSiiresaki, txtDate);
            //txtSiiresaki.E267Check(true, "M_Siiresaki", txtSiiresaki, txtDate);
            txtStaffCD.E102Check(true);
            txtStaffCD.E101Check(true, "M_Staff", txtStaffCD, txtDate, null);
            txtStaffCD.E135Check(true, "M_Staff", txtStaffCD, txtDate);
            txtSouko.E102Check(true);
            txtSouko.E101Check(true, "souko", txtSouko, null, null);
            txtNumber.E102Check(true);
            txtDateFrom.E103Check(true);
            txtDateTo.E103Check(true);
            txtDateTo.E106Check(true, txtDateFrom, txtDateTo);
            txtChakuniYoteiNO.E102Check(false);//ktp add remove 102 check in new mode
            txtChakuniYoteiNO.E133Check(false, "ChakuniYoteiNyuuryoku", txtChakuniYoteiNO, null, null);//ktp add remove 133 check in new mode
            //txtChakuniYoteiNO.E268Check(false, "ChakuniYoteiNyuuryoku", txtChakuniYoteiNO, null);//ktp add remove 268 check in new mode

            //txtBrandCD.E101Check(true, "M_MultiPorpose", txtBrandCD, txtDate, null);
            //txtColorNo.E101Check(true, "M_MultiPorpose", txtColorNo, txtDate, null);
            //txtSizeNo.E101Check(true, "M_MultiPorpose", txtSizeNo, txtDate, null);
        }
        private DataTable CreateTable_Detail()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("HinbanCD", typeof(string));
            dt.Columns.Add("ShouhinName", typeof(string));
            dt.Columns.Add("ColorRyakuName", typeof(string));
            dt.Columns.Add("ColorNO", typeof(string));
            dt.Columns.Add("SizeNO", typeof(string));
            dt.Columns.Add("HacchuuDate", typeof(string));
            dt.Columns.Add("HacchuuSuu", typeof(string));
            dt.Columns.Add("ChakuniYoteiZumiSuu", typeof(string));
            dt.Columns.Add("ChakuniYoteiSuu", typeof(string));
            dt.Columns.Add("ChakuniYoteiMeisaiTekiyou", typeof(string));
            dt.Columns.Add("JANCD", typeof(string));
            dt.Columns.Add("HacchuuNO", typeof(string));
            dt.Columns.Add("HacchuuGyouNO", typeof(string));
            dt.Columns.Add("Hacchuu", typeof(string));
            dt.Columns.Add("ShouhinCD", typeof(string));
            dt.Columns.Add("ChakuniYoteiGyouNO", typeof(int));
            dt.AcceptChanges();
            return dt;
        }
        private void txtBrandCD_KeyDown(object sender, KeyEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtBrandCD.Text))
            {
                multipurposeBL bl = new multipurposeBL();
                string a = txtBrandCD.Text.ToString();
                DataTable dt = bl.M_Multiporpose_SelectData(a, 1, string.Empty, string.Empty);

                if (dt.Rows.Count > 0)
                    lblBrandName.Text = dt.Rows[0]["Char1"].ToString();
                else
                {
                    txtBrandCD.Focus();
                    lblBrandName.Text = string.Empty;
                    bbl.ShowMessage("E101");
                }
            }
            

        }
        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrWhiteSpace(txtSiiresaki.Text))
                {
                    SiiresakiBL sbl = new SiiresakiBL();
                    DataTable dt1 = sbl.Siiresaki_Select_Check(txtSiiresaki.Text, txtDate.Text, "E227");
                    DataTable dt2 = sbl.Siiresaki_Select_Check(txtSiiresaki.Text, txtDate.Text, "E267");
                    if (dt1.Rows[0]["MessageID"].ToString() == "E227")
                    {
                        bbl.ShowMessage("E227");
                        txtSiiresaki.Focus();
                        return;
                    }
                    else if (dt2.Rows[0]["MessageID"].ToString() == "E267")
                    {
                        bbl.ShowMessage("E267");
                        txtSiiresaki.Focus();
                    }
                }
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (F8_dt1.Rows.Count > 0)
            {
                var dtConfirm = F8_dt1.AsEnumerable().OrderBy(r => r.Field<string>("ShouhinCD")).ThenBy(r => r.Field<string>("HacchuuDate")).ThenBy(r => r.Field<string>("Hacchuu")).CopyToDataTable();
                gvChakuniYoteiNyuuryoku.DataSource = dtConfirm;
                Disable();
            }
            else
            {
                F8_dt1 = CreateTable_Detail();
                gvChakuniYoteiNyuuryoku.DataSource = F8_dt1;
                Disable();
            }
        }
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            F10_Gridview_Bind();
        }
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            FunctionProcess("11");
        }
        public void SaveClear()
        {
            txtBrandCD.Clear();
            lblBrandName.Text = string.Empty;
            txtShouhinCD.Clear();
            txtShouhinName.Clear();
            txtJANCD.Clear();
            txtYearTerm.Clear();
            txtColorNo.Clear();
            chkSS.Checked = false;
            chkFW.Checked = false;
            txtDateFrom.Clear();
            txtDateTo.Clear();
            txtSizeNo.Clear();
            txtBrandCD.Focus();
        }
        //private void ChakuniYoteiNyuuryokuSelect(DataTable dt)
        //{
        //    if (dt.Rows.Count > 0)
        //    {
        //        if (dt.Rows[0]["MessageID"].ToString() == "E132")
        //        {
        //            txtDate.Text = dt.Rows[0]["ChakuniYoteiDate"].ToString();
        //            txtSiiresaki.Text = dt.Rows[0]["SiiresakiCD"].ToString();
        //            lblSiiresaki.Text = dt.Rows[0]["SiiresakiRyakuName"].ToString();
        //            txtStaffCD.Text = dt.Rows[0]["StaffCD"].ToString();
        //            lblStaff.Text = dt.Rows[0]["StaffName"].ToString();
        //            txtSouko.Text = dt.Rows[0]["SoukoCD"].ToString();
        //            lblWareHouse.Text = dt.Rows[0]["SoukoName"].ToString();
        //            txtNumber.Text = dt.Rows[0]["KanriNO"].ToString();
        //            txtDescription.Text = dt.Rows[0]["ChakuniYoteiDenpyouTekiyou"].ToString();
        //            sd.Access_Siiresaki_obj.SiiresakiCD = dt.Rows[0]["SiiresakiCD"].ToString();
        //            sd.Access_Siiresaki_obj.SiiresakiRyakuName = dt.Rows[0]["SiiresakiRyakuName"].ToString();
        //            sd.Access_Siiresaki_obj.SiiresakiName = dt.Rows[0]["SiiresakiName"].ToString();
        //            sd.Access_Siiresaki_obj.YuubinNO1 = dt.Rows[0]["SiiresakiYuubinNO1"].ToString();
        //            sd.Access_Siiresaki_obj.YuubinNO2 = dt.Rows[0]["SiiresakiYuubinNO2"].ToString();
        //            sd.Access_Siiresaki_obj.Juusho1 = dt.Rows[0]["SiiresakiJuusho1"].ToString();
        //            sd.Access_Siiresaki_obj.Juusho2 = dt.Rows[0]["SiiresakiJuusho2"].ToString();
        //            sd.Access_Siiresaki_obj.Tel11 = dt.Rows[0]["SiiresakiTelNO1-1"].ToString();
        //            sd.Access_Siiresaki_obj.Tel12 = dt.Rows[0]["SiiresakiTelNO1-2"].ToString();
        //            sd.Access_Siiresaki_obj.Tel13 = dt.Rows[0]["SiiresakiTelNO1-3"].ToString();
        //            sd.Access_Siiresaki_obj.Tel21 = dt.Rows[0]["SiiresakiTelNO2-1"].ToString();
        //            sd.Access_Siiresaki_obj.Tel22 = dt.Rows[0]["SiiresakiTelNO2-2"].ToString();
        //            sd.Access_Siiresaki_obj.Tel23 = dt.Rows[0]["SiiresakiTelNO2-3"].ToString();
        //            dt.Columns.Remove("SiiresakiRyakuName");
        //            dt.Columns.Remove("SiiresakiYuubinNO1");
        //            dt.Columns.Remove("SiiresakiYuubinNO2");
        //            dt.Columns.Remove("SiiresakiJuusho1");
        //            dt.Columns.Remove("SiiresakiJuusho2");
        //            dt.Columns.Remove("SiiresakiTelNO1-1");
        //            dt.Columns.Remove("SiiresakiTelNO1-2");
        //            dt.Columns.Remove("SiiresakiTelNO1-3");
        //            dt.Columns.Remove("SiiresakiTelNO2-1");
        //            dt.Columns.Remove("SiiresakiTelNO2-2");
        //            dt.Columns.Remove("SiiresakiTelNO2-3");
        //            dt.Columns.Remove("SiiresakiCD");
        //            dt.Columns.Remove("ChakuniYoteiDate");
        //            dt.Columns.Remove("SiiresakiName");
        //            dt.Columns.Remove("StaffCD");
        //            dt.Columns.Remove("StaffName");
        //            dt.Columns.Remove("SoukoCD");
        //            dt.Columns.Remove("SoukoName");
        //            dt.Columns.Remove("ChakuniYoteiDenpyouTekiyou");
        //            dt.Columns.Remove("MessageID");
        //            dt.Columns.Remove("KanriNO");
        //            dt.Columns.Remove("HacchuuNo");
        //            dt.Columns.Remove("HacchuuGyouNO");
        //            gvChakuniYoteiNyuuryoku.DataSource = dt;
        //        }
        //    }
        //}
        private void txtArrivalNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtChakuniYoteiNO.IsErrorOccurs)
                {
                    if (cboMode.SelectedValue.ToString() == "2" || cboMode.SelectedValue.ToString() == "3")
                    {
                        if (!Update_Data(true))
                            return;


                        if (!ChakuniYoteiNO_Check())
                        {
                            return;
                        }
                    }

                    if (cboMode.SelectedValue.ToString() == "2" || cboMode.SelectedValue.ToString() == "1")
                    {
                        cf.EnablePanel(PanelDetail);
                        cf.DisablePanel(PanelTitle);
                        txtDate.Focus();

                        //HET
                        SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", true);
                        SetButton(ButtonType.BType.Display, F10, "表示(F10)", true);
                        SetButton(ButtonType.BType.Memory, F11, "保存(F11)", true);
                    }
                    else if (cboMode.SelectedValue.ToString() == "3" || cboMode.SelectedValue.ToString() == "4")
                    {
                        cf.DisablePanel(PanelTitle);
                        Control BtnF9 = this.TopLevelControl.Controls.Find("BtnF9", true)[0];
                        BtnF9.Visible = false;
                        if (cboMode.SelectedValue.ToString() == "3")
                        {
                            Control btnF12 = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                            btnF12.Focus();
                        }

                        btn_Siiresaki.Enabled = true;
                        //HET
                        SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", false);
                        SetButton(ButtonType.BType.Display, F10, "表示(F10)", false);
                        SetButton(ButtonType.BType.Memory, F11, "保存(F11)", false);
                    }
                }
                DataTable dt = txtChakuniYoteiNO.IsDatatableOccurs;
                if (dt.Rows.Count > 0 && cboMode.SelectedValue.ToString() != "1")
                {
                    Update_Data();
                    Disable();
                }
            }
        }
        private bool ChakuniYoteiNO_Check()
        {
            ChakuniNyuuryoku_Entity chkEntity = new ChakuniNyuuryoku_Entity();
            chkEntity.DataKBN = 16;
            chkEntity.Number = txtChakuniYoteiNO.Text;
            chkEntity.ProgramID = ProgramID;
            chkEntity.PC = PCID;
            chkEntity.OperatorCD = OperatorCD;
            DataTable dt = new DataTable();
            cbl = new ChakuniYoteiNyuuryoku_BL();
            dt = cbl.D_Exclusive_Lock_Check(chkEntity);
            if (dt.Rows[0]["MessageID"].ToString().Equals("1"))
            {
                return true;
            }

            string Data1 = string.Empty, Data2 = string.Empty, Data3 = string.Empty;
            Data1 = dt.Rows[0]["Program"].ToString();
            Data2 = dt.Rows[0]["Operator"].ToString();
            Data3 = dt.Rows[0]["PC"].ToString();

            bbl.ShowMessage("S004", Data1, Data2, Data3);
            txtChakuniYoteiNO.Focus();
            return false;
        }
        private bool Update_Data(bool check = false)
        {
            chkEntity = new ChakuniYoteiNyuuryokuEntity();
            chkEntity.ChakuniYoteiDate = string.IsNullOrEmpty(txtDate.Text) ? System.DateTime.Now.ToString("yyyy-MM-dd") : txtDate.Text;
            chkEntity.ChakuniYoteiNO = txtChakuniYoteiNO.Text;

            cbl = new ChakuniYoteiNyuuryoku_BL();
            dt_Header = cbl.ChakuniYoteiNyuuryoku_Update_Select(chkEntity, 1);
            if (dt_Header.Rows.Count > 0)
            {
                if (check)
                {
                    if (dt_Header.Rows[0]["ChakuniKanryouKBN"].ToString() != "0" || dt_Header.Rows[0]["ChakuniZumiSuu_Sum"].ToString() != "0")
                    {
                        bbl.ShowMessage("E163");
                        txtChakuniYoteiNO.Focus();
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                ChakuniYoteiNyuuryokuSelect(dt_Header);
            }

            dt_Details = cbl.ChakuniYoteiNyuuryoku_Update_Select(chkEntity, 2);
            if (dt_Details.Rows.Count > 0)
            {
                dtTemp = dt_Details.Copy();
                dtmain = dtTemp;
                gvChakuniYoteiNyuuryoku.DataSource = dt_Details;
            }
            else
                gvChakuniYoteiNyuuryoku.DataSource = dtClear;

            foreach (DataRow dr in dt_Header.Rows)
            {
                if (dr["SiireKanryouKBN"].ToString().Equals("1"))
                {
                    gvChakuniYoteiNyuuryoku.Columns["colYoteiSuu"].ReadOnly = true;
                }
                else
                {
                    gvChakuniYoteiNyuuryoku.Columns["colYoteiSuu"].ReadOnly = false;
                }
            }
            return true;
        }
        private void ChakuniYoteiNyuuryokuSelect(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                txtDate.Text = dt.Rows[0]["ChakuniYoteiDate"].ToString();
                txtSiiresaki.Text = dt.Rows[0]["SiiresakiCD"].ToString();
                lblSiiresaki.Text = dt.Rows[0]["SiiresakiRyakuName"].ToString();
                txtStaffCD.Text = dt.Rows[0]["StaffCD"].ToString();
                lblStaff.Text = dt.Rows[0]["StaffName"].ToString();
                txtSouko.Text = dt.Rows[0]["SoukoCD"].ToString();
                lblWareHouse.Text = dt.Rows[0]["SoukoName"].ToString();
                txtNumber.Text = dt.Rows[0]["KanriNO"].ToString();
                txtDescription.Text = dt.Rows[0]["ChakuniYoteiDenpyouTekiyou"].ToString();
                sd.Access_Siiresaki_obj.SiiresakiCD = dt.Rows[0]["SiiresakiCD"].ToString();
                sd.Access_Siiresaki_obj.SiiresakiRyakuName = dt.Rows[0]["SiiresakiRyakuName"].ToString();
                sd.Access_Siiresaki_obj.SiiresakiName = dt.Rows[0]["SiiresakiName"].ToString();
                sd.Access_Siiresaki_obj.YuubinNO1 = dt.Rows[0]["SiiresakiYuubinNO1"].ToString();
                sd.Access_Siiresaki_obj.YuubinNO2 = dt.Rows[0]["SiiresakiYuubinNO2"].ToString();
                sd.Access_Siiresaki_obj.Juusho1 = dt.Rows[0]["SiiresakiJuusho1"].ToString();
                sd.Access_Siiresaki_obj.Juusho2 = dt.Rows[0]["SiiresakiJuusho2"].ToString();
                sd.Access_Siiresaki_obj.Tel11 = dt.Rows[0]["SiiresakiTelNO1-1"].ToString();
                sd.Access_Siiresaki_obj.Tel12 = dt.Rows[0]["SiiresakiTelNO1-2"].ToString();
                sd.Access_Siiresaki_obj.Tel13 = dt.Rows[0]["SiiresakiTelNO1-3"].ToString();
                sd.Access_Siiresaki_obj.Tel21 = dt.Rows[0]["SiiresakiTelNO2-1"].ToString();
                sd.Access_Siiresaki_obj.Tel22 = dt.Rows[0]["SiiresakiTelNO2-2"].ToString();
                sd.Access_Siiresaki_obj.Tel23 = dt.Rows[0]["SiiresakiTelNO2-3"].ToString();
            }
        }
        private void btn_Siiresaki_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSiiresaki.Text) && !txtSiiresaki.IsErrorOccurs)
                sd.ShowDialog();
            else
                txtSiiresaki.Focus();
        }
        private SiiresakiEntity From_DB_To_Siiresaki(DataTable dtSiiresaki)
        {
            SiiresakiEntity obj = new SiiresakiEntity();
            obj.SiiresakiCD = dtSiiresaki.Rows[0]["SiiresakiCD"].ToString();
            obj.SiiresakiName = dtSiiresaki.Rows[0]["SiiresakiName"].ToString();
            obj.SiiresakiRyakuName = dtSiiresaki.Rows[0]["SiiresakiRyakuName"].ToString();
            if (dtSiiresaki.Columns.Contains("SiiresakiYuubinNO1"))
                obj.YuubinNO1 = dtSiiresaki.Rows[0]["SiiresakiYuubinNO1"].ToString();
            else
                obj.YuubinNO1 = dtSiiresaki.Rows[0]["YuubinNO1"].ToString();
            if (dtSiiresaki.Columns.Contains("SiiresakiYuubinNO2"))
                obj.YuubinNO2 = dtSiiresaki.Rows[0]["SiiresakiYuubinNO2"].ToString();
            else
                obj.YuubinNO2 = dtSiiresaki.Rows[0]["YuubinNO2"].ToString();
            if (dtSiiresaki.Columns.Contains("SiiresakiJuusho1"))
                obj.Juusho1 = dtSiiresaki.Rows[0]["SiiresakiJuusho1"].ToString();
            else
                obj.Juusho1 = dtSiiresaki.Rows[0]["Juusho1"].ToString();
            if (dtSiiresaki.Columns.Contains("SiiresakiJuusho2"))
                obj.Juusho2 = dtSiiresaki.Rows[0]["SiiresakiJuusho2"].ToString();
            else
                obj.Juusho2 = dtSiiresaki.Rows[0]["Juusho2"].ToString();
            if (dtSiiresaki.Columns.Contains("SiiresakiTelNO1-1"))
                obj.Tel11 = dtSiiresaki.Rows[0]["SiiresakiTelNO1-1"].ToString();
            else
                obj.Tel11 = dtSiiresaki.Rows[0]["Tel11"].ToString();
            if (dtSiiresaki.Columns.Contains("SiiresakiTelNO1-2"))
                obj.Tel12 = dtSiiresaki.Rows[0]["SiiresakiTelNO1-2"].ToString();
            else
                obj.Tel12 = dtSiiresaki.Rows[0]["Tel12"].ToString();
            if (dtSiiresaki.Columns.Contains("SiiresakiTelNO1-3"))
                obj.Tel13 = dtSiiresaki.Rows[0]["SiiresakiTelNO1-3"].ToString();
            else
                obj.Tel13 = dtSiiresaki.Rows[0]["Tel13"].ToString();
            if (dtSiiresaki.Columns.Contains("SiiresakiTelNO2-1"))
                obj.Tel21 = dtSiiresaki.Rows[0]["SiiresakiTelNO2-1"].ToString();
            else
                obj.Tel21 = dtSiiresaki.Rows[0]["Tel21"].ToString();
            if (dtSiiresaki.Columns.Contains("SiiresakiTelNO2-2"))
                obj.Tel22 = dtSiiresaki.Rows[0]["SiiresakiTelNO2-2"].ToString();
            else
                obj.Tel22 = dtSiiresaki.Rows[0]["Tel22"].ToString();
            if (dtSiiresaki.Columns.Contains("SiiresakiTelNO2-3"))
                obj.Tel23 = dtSiiresaki.Rows[0]["SiiresakiTelNO2-3"].ToString();
            else
                obj.Tel23 = dtSiiresaki.Rows[0]["Tel23"].ToString();
            return obj;
        }
        private void txtSiiresaki_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblSiiresaki.Text = string.Empty;
                if (!txtSiiresaki.IsErrorOccurs)
                {
                    DataTable dtSiiresaski = txtSiiresaki.IsDatatableOccurs;
                    if (!string.IsNullOrWhiteSpace(txtSiiresaki.Text))
                    {
                        lblSiiresaki.Text = dtSiiresaski.Rows[0]["SiiresakiName"].ToString();
                        sd.Access_Siiresaki_obj = From_DB_To_Siiresaki(dtSiiresaski);
                    }
                }
            }
        }
        private bool Grid_ErrorCheck(int row, int col)
        {
            if (gvChakuniYoteiNyuuryoku.Columns[col].Name == "colYoteiSuu")
            {
                string value = gvChakuniYoteiNyuuryoku.Rows[row].Cells["colYoteiSuu"].EditedFormattedValue.ToString().Replace(",", "");
                int Konkai_Number = string.IsNullOrEmpty(gvChakuniYoteiNyuuryoku.Rows[row].Cells["colYoteiSuu"].EditedFormattedValue.ToString()) ? 0 : Convert.ToInt32(value);
                gvChakuniYoteiNyuuryoku.Rows[row].Cells["colYoteiSuu"].Value = Konkai_Number.ToString();
                if (Convert.ToInt64(value) < 0)
                {
                    bbl.ShowMessage("E109");
                    return false;
                }
            }
            if (gvChakuniYoteiNyuuryoku.Columns[col].Name == "colDetails")   //HET
            {
                int MaxLength = ((DataGridViewTextBoxColumn)gvChakuniYoteiNyuuryoku.Columns["colDetails"]).MaxInputLength;

                string byte_text = gvChakuniYoteiNyuuryoku.Rows[row].Cells["colDetails"].EditedFormattedValue.ToString();
                if (cf.IsByteLengthOver(MaxLength, byte_text))
                {
                    MessageBox.Show("入力された文字が長すぎます", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        private bool GV_Check()
        {
            foreach (DataGridViewRow gv in gvChakuniYoteiNyuuryoku.Rows)
            {
                if (gv.Cells["colYoteiSuu"].Value.ToString() != "0")
                {
                    for (int i = 0; i < gv.Cells.Count; i++)
                    {
                        string colName = gvChakuniYoteiNyuuryoku.Columns[i].Name;
                        if (colName == "colYoteiSuu" || colName == "colDetails")
                        {
                            if (!Grid_ErrorCheck(gv.Index, i))
                            {
                                gvChakuniYoteiNyuuryoku.CurrentCell = gvChakuniYoteiNyuuryoku.Rows[gv.Index].Cells[i];
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        private void F11_Gridview_Bind()
        {
            for (int t = 0; t < gvChakuniYoteiNyuuryoku.RowCount; t++)
            {
                //bool bl = false;
                // grid 1 checkingTemptb1
                DataRow F8_drNew = F8_dt1.NewRow();// save updated data 
                DataGridViewRow row = gvChakuniYoteiNyuuryoku.Rows[t];// grid view data
                string HinbanCD = row.Cells["colShouhinCD"].Value.ToString();
                string Konkai = row.Cells["colYoteiSuu"].Value.ToString();
                string Hacchu = row.Cells["colHacchuu"].Value.ToString();
                string Detail = row.Cells["colDetails"].EditedFormattedValue.ToString();

                DataRow[] select_dr1 = dtmain.Select("Hacchuu ='" + Hacchu + "'");// original data
                DataRow existDr1 = F8_dt1.Select("Hacchuu='" + Hacchu + "'").SingleOrDefault();
                if (existDr1 != null)
                {
                    if (row.Cells["colYoteiSuu"].Value.ToString() == "0" )
                    {
                        //確認テーブルの中で１つの場合にはDeleteしてOK
                        DataRow[] dataRows = F8_dt1.Select("HacchuuNO ='" + existDr1["HacchuuNO"].ToString() + "'");
                        if (dataRows.Length == 1)
                        {
                            ChakuniNyuuryoku_Entity chkLockEntity = new ChakuniNyuuryoku_Entity();
                            chkLockEntity.DataKBN = 2;
                            chkLockEntity.Number = existDr1["HacchuuNO"].ToString();
                            chkLockEntity.ProgramID = ProgramID;
                            chkLockEntity.PC = PCID;
                            chkLockEntity.OperatorCD = OperatorCD;
                            cbl.D_Exclusive_HacchuuNO_Delete(chkLockEntity);
                        }

                        F8_dt1.Rows.Remove(existDr1);
                        existDr1 = null;
                    }
                }
                F8_drNew[0] = HinbanCD;
                if (row.Cells["colYoteiSuu"].Value.ToString() != "0")
                {
                    for (int c = 1; c < gvChakuniYoteiNyuuryoku.Columns.Count; c++)
                    {
                        if (gvChakuniYoteiNyuuryoku.Columns[c].Name == "colYoteiSuu" || gvChakuniYoteiNyuuryoku.Columns[c].Name == "colDetails")
                        {
                            if (existDr1 != null)
                            {
                                if (select_dr1.Length > 0 && select_dr1[0][c].ToString() != row.Cells[c].Value.ToString())
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
                                //if (select_dr1[0][c].ToString() != row.Cells[c].Value.ToString())
                                //    bl = true;

                                F8_drNew[c] = row.Cells[c].Value;
                            }
                        }
                        else
                        {
                            F8_drNew[c] = row.Cells[c].Value;
                        }
                    }
                    // grid 1 insert(if exist, remove exist and insert)
                    //if (bl == true)
                    //{
                    if (existDr1 != null)
                        F8_dt1.Rows.Remove(existDr1);
                    F8_dt1.Rows.Add(F8_drNew);

                    D_Exclusive_OneNumber_Insert(F8_drNew);
                    // }
                }
                else
                {
                    if (select_dr1.Length > 0)
                        //排他Delete
                        D_Exclusive_OneNumber_Delete(select_dr1[0]);
                }
            }
            gvChakuniYoteiNyuuryoku.Memory_Row_Count = F8_dt1.Rows.Count;

            Focus_Clear();
            Disable();
        }
        private void Focus_Clear()
        {
            SaveClear();
            gvChakuniYoteiNyuuryoku.ClearSelection();
            gvChakuniYoteiNyuuryoku.DataSource = dtClear;
            gvChakuniYoteiNyuuryoku.Memory_Row_Count = F8_dt1.Rows.Count;
            chkSS.Checked = true;
            chkFW.Checked = true;
            
        }
        private void Disable()
        {
            if(gvChakuniYoteiNyuuryoku.Columns.Contains("ChakuniYoteiGyouNO"))
            gvChakuniYoteiNyuuryoku.Columns["ChakuniYoteiGyouNO"].Visible = false;
        }
        private void gvChakuniYoteiNyuuryoku_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Grid_ErrorCheck(e.RowIndex, e.ColumnIndex))
            {
                //Temp_Save(e.RowIndex, true);
            }
        }
        private void txtSizeNo_KeyDown(object sender, KeyEventArgs e)
        {
            F10_Gridview_Bind();
        }

        private void txtNumber_KeyDown(object sender, KeyEventArgs e)
        {
            ChakuniYoteiNyuuryokuEntity chkEntity = new ChakuniYoteiNyuuryokuEntity()
            {
                KanriNO = txtNumber.Text
            };
            DataTable dt = cbl.ChakuniYoteiDataCheck(chkEntity);
            if(dt.Rows.Count>0)
            {
                if(bbl.ShowMessage("Q325") == DialogResult.No) 
                    txtNumber.Focus();
            }

        }
    }
}
