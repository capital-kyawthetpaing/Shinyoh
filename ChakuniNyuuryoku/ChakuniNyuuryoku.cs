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

namespace ChakuniNyuuryoku
{
    public partial class ChakuniNyuuryoku : BaseForm
    {
        CommonFunction cf;
        multipurposeEntity multi_Entity;
        chakuniNyuuryoku_BL cbl;
        BaseBL bbl;
        DataTable dtmain, dt_Header;
        DataTable dtTemp;
        DataTable dtGridSource = new DataTable();
        SiiresakiDetail sd;
        DataTable F8_dt1; 
        BaseEntity base_Entity;
        StaffBL staffBL;
        SoukoBL soukoBL;
        DataTable dtClear;
        public string tdDate;
        public string detail_XML;
        ChakuniNyuuryoku_Entity chkEntity;
        DataTable dt_Details;
        public ChakuniNyuuryoku()
        {
            InitializeComponent();
            cf = new CommonFunction();
            bbl = new BaseBL();
            cbl = new chakuniNyuuryoku_BL();
            dtmain = new DataTable();
            dtTemp = new DataTable();
            F8_dt1 = CreateTable_Details();
            base_Entity = new BaseEntity();
            multi_Entity = new multipurposeEntity();
            staffBL = new StaffBL();
            soukoBL = new SoukoBL();
            dtClear = CreateTable_Details();
            //sd = new SiiresakiDetail();
            chkEntity = new ChakuniNyuuryoku_Entity();
            dt_Header = new DataTable();
            dt_Details = new DataTable();
        }
        private void ChakuniNyuuryoku_Load(object sender, EventArgs e)
        {
            ProgramID = "ChakuniNyuuryoku";
            StartProgram();
            cboMode.Bind(false, multi_Entity);
            txtSiiresaki.lblName = lblSiiresaki;
            txtStaffCD.lblName = lblStaff;
            txtSouko.lblName = lblWareHouse;
            sbBrand.lblName = lblBrandName;
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
            
            txtArrivalNO.Focus();
            txtArrivalNO.ChangeDate = txtArrivalDate;
            txtSiiresaki.ChangeDate = txtArrivalDate;
            txtSiiresaki.lblName = lblSiiresaki;
            txtStaffCD.ChangeDate = txtArrivalDate;
            txtHinbanCD.ChangeDate = txtArrivalDate;
            txtScheduled.ChangeDate= txtArrivalDate;
        
            base_Entity = _GetBaseData();
            lblSiiresaki.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblStaff.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblWareHouse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblBrandName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            gvChakuniNyuuryoku.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvChakuniNyuuryoku.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvChakuniNyuuryoku.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvChakuniNyuuryoku.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvChakuniNyuuryoku.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvChakuniNyuuryoku.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvChakuniNyuuryoku.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvChakuniNyuuryoku.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvChakuniNyuuryoku.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvChakuniNyuuryoku.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvChakuniNyuuryoku.SetGridDesign();
            gvChakuniNyuuryoku.SetReadOnlyColumn("HinbanCD,ShouhinName,ColorRyakuName,ColorNO,SizeNO,ChakuniYoteiDate,ChakuniYoteiSuu,ChakuniZumiSuu,JanCD,Chakuni,Hacchuu");
            gvChakuniNyuuryoku.SetHiraganaColumn("ChakuniMeisaiTekiyou");
            gvChakuniNyuuryoku.SetNumberColumn("ChakuniSuu");         
            ChangeMode(GetMode(Mode.New));
        }
        private void ChangeMode(Mode mode)
        {
            switch (mode)
            {
                case Mode.New:
                    txtArrivalNO.E102Check(false);
                    txtArrivalNO.E133Check(false, "ChakuniNyuuryoku", txtArrivalNO, null, null);
                    txtArrivalNO.E159Check(false, "ChakuniNyuuryoku", txtArrivalNO);
                    //txtArrivalNO.E268Check(false, "ChakuniNyuuryoku", txtArrivalNO, null);
                    txtArrivalNO.E280Check(false, "ChakuniNyuuryoku", txtArrivalNO, null, null);
                    ErrorCheck();
                    New_Mode();
                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    sd = new SiiresakiDetail();
                    cboMode.Enabled = false;
                    break;
                case Mode.Update:
                    txtArrivalNO.E102Check(true);
                    txtArrivalNO.E133Check(true, "ChakuniNyuuryoku", txtArrivalNO, null, null);
                    txtArrivalNO.E159Check(true, "ChakuniNyuuryoku", txtArrivalNO);
                    //txtArrivalNO.E268Check(true, "ChakuniNyuuryoku", txtArrivalNO, null);
                    txtArrivalNO.E280Check(true, "ChakuniNyuuryoku", txtArrivalNO, null, null);
                    Mode_Setting();
                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    sd = new SiiresakiDetail();
                    break;
                case Mode.Delete:
                    txtArrivalNO.E102Check(true);
                    txtArrivalNO.E133Check(true, "ChakuniNyuuryoku", txtArrivalNO, null, null);
                    txtArrivalNO.E159Check(true, "ChakuniNyuuryoku", txtArrivalNO);
                    //txtArrivalNO.E268Check(true, "ChakuniNyuuryoku", txtArrivalNO, null);
                    txtArrivalNO.E280Check(true, "ChakuniNyuuryoku", txtArrivalNO, null, null);
                    Mode_Setting();
                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;
                    sd = new SiiresakiDetail(false);
                    break;
                case Mode.Inquiry:
                    txtArrivalNO.E102Check(true);
                    txtArrivalNO.E133Check(true, "ChakuniNyuuryoku", txtArrivalNO, null, null);
                    txtArrivalNO.E159Check(false, "ChakuniNyuuryoku", txtArrivalNO);
                    //txtArrivalNO.E268Check(true, "ChakuniNyuuryoku", txtArrivalNO, null);
                    txtArrivalNO.E280Check(false, "ChakuniNyuuryoku", txtArrivalNO, null, null);
                    Mode_Setting();
                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;
                    sd = new SiiresakiDetail(false);
                    break;
            }
        }
        private void Mode_Setting()
        {
            cf.Clear(PanelTitle);
            cf.Clear(PanelDetail);
            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(PanelDetail);
            lblSiiresaki.Text = string.Empty;
            lblStaff.Text = string.Empty;
            lblBrandName.Text = string.Empty;
            lblWareHouse.Text = string.Empty;
            txtArrivalNO.Focus();
            chkSS.Checked = true; //HET
            chkFW.Checked = true; //HET

            F8_dt1 = CreateTable_Details();

            BaseEntity be = new BaseEntity();
            be.ProgramID = ProgramID;
            be.OperatorCD = OperatorCD;
            be.PC = PCID;
            BaseBL bbl = new BaseBL();
            bbl.D_Exclusive_Number_Remove(be);

            //HET
            if (cboMode.SelectedValue.Equals("2") || cboMode.SelectedValue.Equals("3") || cboMode.SelectedValue.Equals("4"))
            {
                txtArrivalNO.Focus();
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
            //cboMode.Enabled = true;       //Task 292 TZA
            cf.EnablePanel(PanelDetail);
            txtArrivalDate.Focus();
            tdDate = DateTime.Now.ToString("yyyy/MM/dd");
            txtArrivalDate.Text = tdDate;
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
            //NMW
            dtmain = new DataTable();
            dt_Header = new DataTable();
            dt_Details = new DataTable();
            F8_dt1 = CreateTable_Details();
            dtTemp = new DataTable();
            dtClear = CreateTable_Details();
            //dtGridSource = new DataTable();

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
        public void ErrorCheck()
        {
            txtArrivalDate.E102Check(true);
            txtArrivalDate.E103Check(true);
            txtSiiresaki.E102Check(true);
            txtSiiresaki.E101Check(true, "M_Siiresaki", txtSiiresaki, txtArrivalDate, null);
            txtSiiresaki.E227Check(true, "M_Siiresaki", txtSiiresaki, txtArrivalDate);
            txtSiiresaki.E267Check(true, "M_Siiresaki", txtSiiresaki, txtArrivalDate);
            txtStaffCD.E102Check(true);
            txtStaffCD.E101Check(true, "M_Staff", txtStaffCD, txtArrivalDate, null);
            txtStaffCD.E135Check(true, "M_Staff", txtStaffCD, txtArrivalDate);
            txtSouko.E102Check(true);
            txtSouko.E101Check(true, "souko", txtSouko, null, null);
            //sbBrand.E101Check(true, "M_MultiPorpose", sbBrand, txtArrivalDate, null);
            //txtColorNo.E101Check(true, "M_MultiPorpose", txtColorNo, txtArrivalDate, null);
            //txtSizeNo.E101Check(true, "M_MultiPorpose", txtSizeNo, txtArrivalDate, null);
            //txtScheduled.E133Check(true, "ChakuniYotei", txtScheduled, txtArrivalDate, null);
            //txtScheduled.E268Check(true, "ChakuniYotei", txtScheduled, null);
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
                D_Exclusive_Number_Delete();

                if (F8_dt1.Rows.Count > 0)//
                {
                    var dtConfirm = F8_dt1.AsEnumerable().OrderBy(r => r.Field<string>("ShouhinCD")).ThenBy(r => r.Field<string>("ChakuniYoteiDate")).ThenBy(r => r.Field<string>("Chakuni")).ThenBy(r => r.Field<string>("Hacchuu")).CopyToDataTable();
                    gvChakuniNyuuryoku.DataSource = dtConfirm;
                    gvChakuniNyuuryoku.Focus();
                    gvChakuniNyuuryoku.Memory_Row_Count = F8_dt1.Rows.Count;
                }
                else
                {
                    F8_dt1 = CreateTable_Details();
                    gvChakuniNyuuryoku.DataSource = F8_dt1;
                    Disable();
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
                if (ErrorCheck(PanelTitle) && ErrorCheck(PanelDetail) && Temp_Null())
                {
                    if (F8_dt1.Rows.Count > 0 || dt_Details.Rows.Count > 0)
                    {
                        switch (cboMode.SelectedValue)
                        {
                            case "1":
                            case "2":
                                DataRow[] dataRows = F8_dt1.Select("SiireKanryouKBN='1'");
                                if (dataRows.Length > 0)
                                {
                                    //F11保存ボタンで保存されている情報の中で、完了チェックがONの明細が存在する場合、警告
                                    if (bbl.ShowMessage("Q327") == DialogResult.No)
                                        return;
                                }
                                break;
                        }

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
                        }
                    }
                }
            }
            base.FunctionProcess(tagID);
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
        public void Clear()
        {
            cf.Clear(PanelTitle);
            cf.Clear(PanelDetail);
            cf.EnablePanel(PanelTitle);
            lblSiiresaki.Text = string.Empty;
            lblStaff.Text = string.Empty;
            lblBrandName.Text = string.Empty;
            lblWareHouse.Text = string.Empty;
            txtArrivalNO.Focus();
            New_Mode();
        }
        private void DBProcess()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
            }
        }
        public void Create_Datatable_Column(DataTable create_dt)
        {
            create_dt.Columns.Add("ChakuniNO", typeof(string));
            create_dt.Columns.Add("ChakuniDate", typeof(string));
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
            create_dt.Columns.Add("ChakuniDenpyouTekiyou", typeof(string));
            create_dt.Columns.Add("ChakuniYoteiNO", typeof(string));
            create_dt.Columns.Add("ShouhinCD", typeof(string));
            create_dt.Columns.Add("ShouhinName", typeof(string));
            create_dt.Columns.Add("JANCD", typeof(string));
            create_dt.Columns.Add("KanriNO", typeof(string));
            create_dt.Columns.Add("BrandCD", typeof(string));
            create_dt.Columns.Add("YearTerm", typeof(string));
            create_dt.Columns.Add("SeasonSS", typeof(string));
            create_dt.Columns.Add("SeasonFW", typeof(string));
            create_dt.Columns.Add("ColorNO", typeof(string));
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
            cbl = new chakuniNyuuryoku_BL();
            if (cboMode.SelectedValue.ToString() != "1")
            {
                dr["ChakuniNO"] = txtArrivalNO.Text;
            }
            dr["ChakuniDate"] = txtArrivalDate.Text;
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
            dr["ChakuniDenpyouTekiyou"] = txtDescription.Text;
            dr["ChakuniYoteiNO"] = txtScheduled.Text;
            dr["ShouhinCD"] = string.IsNullOrEmpty(txtHinbanCD.Text) ? null : txtHinbanCD.Text;
            dr["ShouhinName"] = string.IsNullOrEmpty(txtShouhinName.Text) ? null : txtShouhinName.Text;
            dr["KanriNO"] = string.IsNullOrEmpty(txtControlNo.Text) ? null : txtControlNo.Text;
            dr["JANCD"] = string.IsNullOrEmpty(txtJANCD.Text) ? null : txtJANCD.Text;
            dr["BrandCD"] = string.IsNullOrEmpty(sbBrand.Text) ? null : sbBrand.Text;
            dr["YearTerm"] = txtYearTerm.Text;
            dr["SeasonSS"] = chkSS.Checked ? "1" : "0";
            dr["SeasonFW"] = chkFW.Checked ? "1" : "0";
            dr["ColorNO"] = string.IsNullOrEmpty(txtColorNo.Text) ? null : txtColorNo.Text;
            dr["SizeNO"] = string.IsNullOrEmpty(txtSizeNo.Text) ? null : txtSizeNo.Text;
            dr["Operator"] = base_Entity.OperatorCD;
            dr["PC"] = base_Entity.PC;
            dr["ProgramID"] = base_Entity.ProgramID;
            dt.Rows.Add(dr);
            string main_XML = cf.DataTableToXml(dt);
            if (cboMode.SelectedValue.ToString() == "3")
            {
                detail_XML = cf.DataTableToXml(dt_Details);
            }
            else
            {
                detail_XML = cf.DataTableToXml(F8_dt1);
            }

            return (main_XML, detail_XML);
        }
        private void DoInsert(string mode, string str_main, string str_detail)
        {
            chakuniNyuuryoku_BL bl = new chakuniNyuuryoku_BL();
            bl.ChakuniNyuuryoku_CUD(mode, str_main, str_detail);
            bbl.ShowMessage("I101");
        }
        private void DoUpdate(string mode, string str_main, string str_detail)
        {
            chakuniNyuuryoku_BL bl = new chakuniNyuuryoku_BL();
            bl.ChakuniNyuuryoku_CUD(mode, str_main, str_detail);
            bbl.ShowMessage("I101");
        }
        private void DoDelete(string mode, string str_main, string str_detail)
        {
            chakuniNyuuryoku_BL bl = new chakuniNyuuryoku_BL();
            bl.ChakuniNyuuryoku_CUD(mode, str_main, str_detail);
            bbl.ShowMessage("I102");
        }
        private ChakuniNyuuryoku_Entity GetEntity()
        {
            ChakuniNyuuryoku_Entity chkEntity = new ChakuniNyuuryoku_Entity()
            {
                ChakuniDate = txtArrivalDate.Text,
                ChakuniYoteiNO = txtScheduled.Text,
                HinbanCD = txtHinbanCD.Text,
                ShouhinName = txtShouhinName.Text,
                JANCD = txtJANCD.Text,
                BrandCD = sbBrand.Text,
                ColorNO = txtColorNo.Text,
                SizeNO = txtSizeNo.Text,
                KanriNO = txtControlNo.Text,
                SoukoCD = txtSouko.Text,
                YearTerm = txtYearTerm.Text,
                SeasonSS = chkSS.Checked ? "1" : "0",
                SeasonFW = chkFW.Checked ? "1" : "0",
                OperatorCD = OperatorCD,
                ProgramID = ProgramID,
                PC = PCID
            };

            return chkEntity;
        }
        private void ChakuniNyuuryokuSelect(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                txtArrivalDate.Text = dt.Rows[0]["ChakuniDate"].ToString();
                txtSiiresaki.Text = dt.Rows[0]["SiiresakiCD"].ToString();
                lblSiiresaki.Text = dt.Rows[0]["SiiresakiRyakuName"].ToString();
                txtStaffCD.Text = dt.Rows[0]["StaffCD"].ToString();
                lblStaff.Text = dt.Rows[0]["StaffName"].ToString();
                txtSouko.Text = dt.Rows[0]["SoukoCD"].ToString();
                lblWareHouse.Text = dt.Rows[0]["SoukoName"].ToString();
                txtDescription.Text = dt.Rows[0]["ChakuniDenpyouTekiyou"].ToString();
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
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            FunctionProcess("8");
            //if (F8_dt1.Rows.Count > 0)
            //{
            //   // var dtConfirm = F8_dt1.AsEnumerable().OrderBy(r => r.Field<string>("ShouhinCD")).ThenBy(r => r.Field<string>("ChakuniYoteiDate")).ThenBy(r => r.Field<string>("Chakuni")).ThenBy(r => r.Field<string>("Hacchuu")).CopyToDataTable();
            //    var dtF8 = F8_dt1.Copy();//Task_NO351_ssa
            //    gvChakuniNyuuryoku.DataSource = dtF8;//Task_NO351_ssa
            //    Disable();
            //}
            //else
            //{
            //    F8_dt1 = CreateTable_Details();
            //    gvChakuniNyuuryoku.DataSource = F8_dt1;
            //    Disable();
            //}
        }
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            FunctionProcess("10");
            //ChakuniYoteiNO_Delete();
            //foreach (DataRow dr in dtmain.Rows)
            //{
            //    string ChakuniYoteiNO = dr["ChakuniYoteiNO"].ToString();
            //    chkEntity = new ChakuniNyuuryoku_Entity();
            //    chkEntity.DataKBN = 16;
            //    chkEntity.Number = ChakuniYoteiNO;
            //    chkEntity.ProgramID = ProgramID;
            //    chkEntity.PC = PCID;
            //    chkEntity.OperatorCD = OperatorCD;
            //    DataTable dt = new DataTable();
            //    cbl = new chakuniNyuuryoku_BL();
            //    dt = cbl.D_Exclusive_Lock_Check(chkEntity);
            //    if (dt.Rows[0]["MessageID"].ToString().Equals("S004"))
            //    {
            //        bbl.ShowMessage("S004");
            //        Gvrow_Delete(dr);
            //    }
            //    string HacchuuNO = dr["HacchuuNO"].ToString();
            //    chkEntity = new ChakuniNyuuryoku_Entity();
            //    chkEntity.DataKBN = 2;
            //    chkEntity.Number = HacchuuNO;
            //    chkEntity.ProgramID = ProgramID;
            //    chkEntity.PC = PCID;
            //    chkEntity.OperatorCD = OperatorCD;
            //    DataTable dt1 = new DataTable();
            //    cbl = new chakuniNyuuryoku_BL();
            //    dt1 = cbl.D_Exclusive_Lock_Check(chkEntity);
            //    if (dt.Rows[0]["MessageID"].ToString().Equals("S004"))
            //    {
            //        bbl.ShowMessage("S004");
            //        if (dr != null)
            //            Gvrow_Delete(dr);
            //    }
            //    gvChakuniNyuuryoku.DataSource = dtmain;
            //    gvChakuniNyuuryoku.Columns["ChakuniSuu"].ReadOnly = false;
            //    gvChakuniNyuuryoku.Columns["SiireKanryouKBN"].ReadOnly = false;
            //    gvChakuniNyuuryoku.Select();
            //}
        }
        private void D_Exclusive_Number_Delete()
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
            string ChakuniYoteiNO = dr["ChakuniYoteiNO"].ToString();
            string HacchuuNO = dr["HacchuuNO"].ToString();
            ChakuniNyuuryoku_Entity chkLockEntity = new ChakuniNyuuryoku_Entity();
            chkLockEntity.ProgramID = ProgramID;
            chkLockEntity.PC = PCID;
            chkLockEntity.OperatorCD = OperatorCD;

            DataRow[] selectRowC = F8_dt1.Select("ChakuniYoteiNO ='" + ChakuniYoteiNO + "'");
            if (selectRowC.Length == 0)
            {
                chkLockEntity.DataKBN = 16;
                chkLockEntity.Number = ChakuniYoteiNO;

                cbl.D_Exclusive_Number_Delete(chkLockEntity);
            }
            DataRow[] selectRow = F8_dt1.Select("HacchuuNO ='" + HacchuuNO + "'");
            if (selectRow.Length == 0)
            {
                chkLockEntity.DataKBN = 2;
                chkLockEntity.Number = HacchuuNO;
                cbl.D_Exclusive_Number_Delete(chkLockEntity);
            }
        }
        private void D_Exclusive_OneNumber_Insert(DataRow dr)
        {
            string ChakuniYoteiNO = dr["ChakuniYoteiNO"].ToString();
            string HacchuuNO = dr["HacchuuNO"].ToString();
            ChakuniNyuuryoku_Entity chkLockEntity = new ChakuniNyuuryoku_Entity();
            chkLockEntity.ProgramID = ProgramID;
            chkLockEntity.PC = PCID;
            chkLockEntity.OperatorCD = OperatorCD;

            DataRow[] selectRowC = F8_dt1.Select("ChakuniYoteiNO ='" + ChakuniYoteiNO + "'");
            if (selectRowC.Length > 0)
            {
                chkLockEntity.DataKBN = 16;
                chkLockEntity.Number = ChakuniYoteiNO;

                cbl.D_Exclusive_Lock_Check(chkLockEntity);
            }
            DataRow[] selectRow = F8_dt1.Select("HacchuuNO ='" + HacchuuNO + "'");
            if (selectRow.Length > 0)
            {
                chkLockEntity.DataKBN = 2;
                chkLockEntity.Number = HacchuuNO;
                cbl.D_Exclusive_Lock_Check(chkLockEntity);
            }
        }
        //private void Gvrow_Delete(DataRow dr)
        //{
        //    DataRow[] existDr1;
        //    if (dr["ChakuniYoteiNO"] != null)
        //    {
        //        existDr1 = dtmain.Select("ChakuniYoteiNO ='" + dr["ChakuniYoteiNO"] + "'");
        //        foreach (DataRow row in existDr1)
        //        {
        //            dtmain.Rows.Remove(row);// Here The given DataRow is not in the current DataRowCollection
        //        }
        //    }
        //    else if (dr["HacchuuNO"] != null)
        //    {
        //        existDr1 = dtmain.Select("HacchuuNO ='" + dr["HacchuuNO"] + "'");
        //        foreach (DataRow row in existDr1)
        //        {
        //            dtmain.Rows.Remove(row);// Here The given DataRow is not in the current DataRowCollection
        //        }
        //    }
        //}
        private void ChakuniYoteiNO_Delete()
        {
            chkEntity = new ChakuniNyuuryoku_Entity();
            chkEntity.DataKBN = 16;
            chkEntity.OperatorCD = OperatorCD;
            chkEntity.ProgramID = ProgramID;
            chkEntity.PC = PCID;
            cbl = new chakuniNyuuryoku_BL();
            cbl.D_Exclusive_ChakuniYoteiNyuuryokuNO_Delete(chkEntity);
        }
        
        private DataTable dtGridview()
        {
            chkEntity = GetEntity();
            dtmain = cbl.ChakuniNyuuryoku_Display(chkEntity);
            return dtmain;
        }
        private void F10_Gridview_Bind()
        {
            gvChakuniNyuuryoku.ActionType = "F10";
            if (ErrorCheck(PanelDetail))
            {
                ChakuniNyuuryoku_Entity chkEntity = new ChakuniNyuuryoku_Entity();
                chkEntity.ChakuniDate = txtArrivalDate.Text;
                chkEntity.ChakuniYoteiNO = txtScheduled.Text;
                chkEntity.HinbanCD = txtHinbanCD.Text;
                chkEntity.ShouhinName = txtShouhinName.Text;
                chkEntity.JANCD = txtJANCD.Text;
                chkEntity.BrandCD = sbBrand.Text;
                chkEntity.ColorNO = txtColorNo.Text;
                chkEntity.SizeNO = txtSizeNo.Text;
                chkEntity.KanriNO = txtControlNo.Text;
                chkEntity.SoukoCD = txtSouko.Text;
                chkEntity.YearTerm = txtYearTerm.Text;
                chkEntity.SeasonSS = chkSS.Checked ? "1" : "0";
                chkEntity.SeasonFW = chkFW.Checked ? "1" : "0";
                chkEntity.OperatorCD = OperatorCD;
                chkEntity.ProgramID = ProgramID;
                chkEntity.PC = PCID;
                if (string.IsNullOrWhiteSpace(txtScheduled.Text) && string.IsNullOrWhiteSpace(txtHinbanCD.Text) && string.IsNullOrWhiteSpace(txtShouhinName.Text) && string.IsNullOrWhiteSpace(txtControlNo.Text) &&
                     string.IsNullOrWhiteSpace(txtJANCD.Text) && string.IsNullOrWhiteSpace(sbBrand.Text) && string.IsNullOrWhiteSpace(txtColorNo.Text) && string.IsNullOrWhiteSpace(txtYearTerm.Text) && (!chkFW.Checked) && (!chkSS.Checked) && string.IsNullOrWhiteSpace(txtSizeNo.Text))
                {
                    bbl.ShowMessage("E111");
                    txtScheduled.Focus();
                    return;//ktp added (show error message and stop process)
                }
                D_Exclusive_Number_Delete();

                dtmain = cbl.ChakuniNyuuryoku_Display(chkEntity);
                
                foreach (DataRow dr in dtmain.Rows)
                {
                    bool exists = false;
                    if (F8_dt1.Rows.Count > 0)
                    {
                        //重複行はDelete
                        string Chakuni = dr["Chakuni"].ToString();
                        DataRow existDr1 = F8_dt1.Select("Chakuni ='" + Chakuni + "'").SingleOrDefault();
                        if (existDr1 != null)
                        {
                            dr["SiireKanryouKBN"] = "9";    //未使用項目のため
                            exists = true;
                        }
                    }

                    if (!exists)
                    {
                        string ChakuniYoteiNO = dr["ChakuniYoteiNO"].ToString();
                        chkEntity = new ChakuniNyuuryoku_Entity();
                        chkEntity.DataKBN = 16;
                        chkEntity.Number = ChakuniYoteiNO;
                        chkEntity.ProgramID = ProgramID;
                        chkEntity.PC = PCID;
                        chkEntity.OperatorCD = OperatorCD;
                        DataTable dt = new DataTable();
                        cbl = new chakuniNyuuryoku_BL();
                        dt = cbl.D_Exclusive_Lock_Check(chkEntity);
                        if (dt.Rows[0]["MessageID"].ToString().Equals("S004"))
                        {
                            string Data1 = string.Empty, Data2 = string.Empty, Data3 = string.Empty;
                            Data1 = dt.Rows[0]["Program"].ToString();
                            Data2 = dt.Rows[0]["Operator"].ToString();
                            Data3 = dt.Rows[0]["PC"].ToString();

                            bbl.ShowMessage("S004", Data1, Data2, Data3);
                            //Gvrow_Delete(dr);
                            D_Exclusive_Number_Delete();
                            return;
                        }
                        string HacchuuNO = dr["HacchuuNO"].ToString();
                        chkEntity = new ChakuniNyuuryoku_Entity();
                        chkEntity.DataKBN = 2;
                        chkEntity.Number = HacchuuNO;
                        chkEntity.ProgramID = ProgramID;
                        chkEntity.PC = PCID;
                        chkEntity.OperatorCD = OperatorCD;
                        DataTable dt1 = new DataTable();
                        cbl = new chakuniNyuuryoku_BL();
                        dt1 = cbl.D_Exclusive_Lock_Check(chkEntity);
                        if (dt1.Rows[0]["MessageID"].ToString().Equals("S004"))
                        {
                            string Data1 = string.Empty, Data2 = string.Empty, Data3 = string.Empty;
                            Data1 = dt1.Rows[0]["Program"].ToString();
                            Data2 = dt1.Rows[0]["Operator"].ToString();
                            Data3 = dt1.Rows[0]["PC"].ToString();

                            bbl.ShowMessage("S004", Data1, Data2, Data3);
                            //if (dr != null)
                            //    Gvrow_Delete(dr);
                            D_Exclusive_Number_Delete();
                            return;
                        }
                    }
                    //dtGridSource = dtmain.Copy();     
                }
                DataRow[] select_dr1 = dtmain.Select("SiireKanryouKBN = '9'");
                foreach (DataRow dr in select_dr1)
                    dtmain.Rows.Remove(dr);

                gvChakuniNyuuryoku.DataSource = dtmain;
                DataTable dt_temp = dtmain.Copy();
                dt_Details = dt_temp;
                
                gvChakuniNyuuryoku.Columns["ChakuniSuu"].ReadOnly = false;
                gvChakuniNyuuryoku.Columns["SiireKanryouKBN"].ReadOnly = false;

                if(dtmain.Rows.Count > 0)
                    gvChakuniNyuuryoku.CurrentCell = gvChakuniNyuuryoku.Rows[0].Cells["ChakuniSuu"];
                //gvChakuniNyuuryoku.Columns["SiireKanryouKBN_Head"].Visible = false;
                //gvChakuniNyuuryoku.Columns["SiireZumiSuu_Sum"].Visible = false;
                Disable();
                gvChakuniNyuuryoku.Select();
            }
            gvChakuniNyuuryoku.ActionType = string.Empty;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            FunctionProcess("11");
        }
        private bool GV_Check()
        {
            foreach (DataGridViewRow gv in gvChakuniNyuuryoku.Rows)
            {
                if (gv.Cells["ChakuniSuu"].Value.ToString() != "0")
                {
                    for (int i = 0; i < gv.Cells.Count; i++)
                    {
                        string colName = gvChakuniNyuuryoku.Columns[i].Name;
                        if (colName == "ChakuniSuu" || colName == "ChakuniMeisaiTekiyou")
                        {
                            if (!Grid_ErrorCheck(gv.Index, i))
                            {
                                gvChakuniNyuuryoku.CurrentCell = gvChakuniNyuuryoku.Rows[gv.Index].Cells[i];
                                return false;
                            }
                        }
                    }
                }

                //if (Convert.ToInt64(value) != 0)
                //{
                //    Temp_Save(gv.Index);
                //}
            }
            return true;
        }
        private void F11_Gridview_Bind()
        {
            for (int t = 0; t < gvChakuniNyuuryoku.RowCount; t++)
            {

                //bool bl = false;
                // grid 1 checkingTemptb1
                DataRow F8_drNew = F8_dt1.NewRow();// save updated data 
                DataGridViewRow row = gvChakuniNyuuryoku.Rows[t];// grid view data
                string HinbanCD = row.Cells["HinbanCD"].Value.ToString();
                string Konkai = row.Cells["ChakuniSuu"].Value.ToString();
                string Chakuni = row.Cells["Chakuni"].Value.ToString();
                string Detail = row.Cells["ChakuniMeisaiTekiyou"].EditedFormattedValue.ToString();
                
                DataRow[] select_dr1 = dt_Details.Select("Chakuni ='" + Chakuni + "'");// original data
                DataRow existDr1 = F8_dt1.Select("Chakuni='" + Chakuni + "'").SingleOrDefault();
                if (existDr1 != null)
                {
                    if (row.Cells["ChakuniSuu"].Value.ToString() == "0")
                    {
                        D_Exclusive_OneNumber_Delete(existDr1);
                        F8_dt1.Rows.Remove(existDr1);
                        existDr1 = null;
                    }
                }
                F8_drNew[0] = HinbanCD;
                if (row.Cells["ChakuniSuu"].Value.ToString() != "0" || row.Cells["SiireKanryouKBN"].Value.ToString() == "1")
                {
                    for (int c = 1; c < gvChakuniNyuuryoku.Columns.Count; c++)
                    {
                        if (gvChakuniNyuuryoku.Columns[c].Name == "ChakuniSuu" || gvChakuniNyuuryoku.Columns[c].Name == "ChakuniMeisaiTekiyou")
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
                    if(select_dr1.Length > 0)
                        //排他Delete
                        D_Exclusive_OneNumber_Delete(select_dr1[0]);
                }
            }
            gvChakuniNyuuryoku.Memory_Row_Count = F8_dt1.Rows.Count;

            Focus_Clear();
            Disable();
        }
        private void Focus_Clear()
        {
            txtScheduled.Clear();
            txtHinbanCD.Clear();
            txtShouhinName.Clear();
            txtControlNo.Clear();
            txtJANCD.Clear();
            sbBrand.Clear();
            lblBrandName.Text = string.Empty;
            txtColorNo.Clear();
            txtYearTerm.Clear();
            txtSizeNo.Clear();
            txtScheduled.Focus();
            gvChakuniNyuuryoku.ClearSelection();
            gvChakuniNyuuryoku.DataSource = dtClear;
            chkSS.Checked = true; //HET
            chkFW.Checked = true; //HET
        }

        //HET
        private void Disable()
        {
            if(gvChakuniNyuuryoku.Columns.Contains("SiireKanryouKBN_Head"))
                gvChakuniNyuuryoku.Columns["SiireKanryouKBN_Head"].Visible = false;
            if (gvChakuniNyuuryoku.Columns.Contains("SiireZumiSuu_Sum"))
                gvChakuniNyuuryoku.Columns["SiireZumiSuu_Sum"].Visible = false;
            if (gvChakuniNyuuryoku.Columns.Contains("ChakuniGyouNO"))
                gvChakuniNyuuryoku.Columns["ChakuniGyouNO"].Visible = false;

            //gvChakuniNyuuryoku.Columns["SiireKanryouKBN_Head"].Visible = false;
            //gvChakuniNyuuryoku.Columns["SiireZumiSuu_Sum"].Visible = false;
            //gvChakuniNyuuryoku.Columns["ChakuniGyouNO"].Visible = false;
        }
        private DataTable CreateTable_Details()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("HinbanCD", typeof(string));
            dt.Columns.Add("ShouhinName", typeof(string));
            dt.Columns.Add("ColorRyakuName", typeof(string));
            dt.Columns.Add("ColorNO", typeof(string));
            dt.Columns.Add("SizeNO", typeof(string));
            dt.Columns.Add("ChakuniYoteiDate", typeof(string));
            dt.Columns.Add("ChakuniYoteiSuu", typeof(string));
            dt.Columns.Add("ChakuniZumiSuu", typeof(string));
            dt.Columns.Add("ChakuniSuu", typeof(string));
            dt.Columns.Add("SiireKanryouKBN", typeof(string));
            dt.Columns.Add("ChakuniMeisaiTekiyou", typeof(string));
            dt.Columns.Add("JanCD", typeof(string));
            dt.Columns.Add("ChakuniYoteiNO", typeof(string));
            dt.Columns.Add("ChakuniYoteiGyouNO", typeof(int));
            dt.Columns.Add("Chakuni", typeof(string));
            dt.Columns.Add("HacchuuNO", typeof(string));
            dt.Columns.Add("HacchuuGyouNO", typeof(int));
            dt.Columns.Add("Hacchuu", typeof(string));
            dt.Columns.Add("ShouhinCD", typeof(string));
            dt.Columns.Add("SiireKanryouKBN_Head", typeof(string));
            dt.Columns.Add("SiireZumiSuu_Sum", typeof(string));
            dt.Columns.Add("ChakuniGyouNO", typeof(int));

            dt.AcceptChanges();
            return dt;
        }
        private void sbBrand_KeyDown(object sender, KeyEventArgs e)
        {
            multipurposeBL bl = new multipurposeBL();
            string a = sbBrand.Text.ToString();
            DataTable dt = bl.M_Multiporpose_SelectData(a, 1, string.Empty, string.Empty);

            if (dt.Rows.Count > 0)
                lblBrandName.Text = dt.Rows[0]["Char1"].ToString();
        }
        
        private void txtArrivalNO_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtArrivalNO.IsErrorOccurs && (cboMode.SelectedValue.ToString() != "1"))
                {
                    if (cboMode.SelectedValue.ToString().Equals("2") || cboMode.SelectedValue.ToString().Equals("3"))
                    {
                        if (!Update_Data(true))
                            return;

                        if (ChakuniNO_Check())
                        {
                            if (cboMode.SelectedValue.ToString() == "2" )
                            {
                                cf.EnablePanel(PanelDetail);
                                cf.DisablePanel(PanelTitle);
                                txtArrivalDate.Focus();

                                //HET
                                SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", true);
                                SetButton(ButtonType.BType.Display, F10, "表示(F10)", true);
                                SetButton(ButtonType.BType.Memory, F11, "保存(F11)", true);
                            }
                            else if (cboMode.SelectedValue.ToString() == "3")
                            {
                                cf.DisablePanel(PanelTitle);
                                Control BtnF9 = this.TopLevelControl.Controls.Find("BtnF9", true)[0];
                                BtnF9.Visible = false;
                                Control btnF12 = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                                btnF12.Focus();
                                btn_Siiresaki.Enabled = true;
                                DisableTag();
                            }
                            Update_Data();
                            Disable();
                        }

                    }
                    else if (cboMode.SelectedValue.ToString().Equals("4"))
                    {
                        cf.DisablePanel(PanelTitle);
                        Control BtnF9 = this.TopLevelControl.Controls.Find("BtnF9", true)[0];
                        BtnF9.Visible = false;
                        Control btnF12 = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                        btnF12.Focus();
                        Update_Data();
                        btn_Siiresaki.Enabled = true;
                        Disable();
                        DisableTag();
                        SetButton(ButtonType.BType.Save, F12, "登録(F12)", false);
                    }
                   
                }
            }
        }
        private void DisableTag()
        {
            //HET
            SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", false);
            SetButton(ButtonType.BType.Display, F10, "表示(F10)", false);
            SetButton(ButtonType.BType.Memory, F11, "保存(F11)", false);
        }
        private bool ChakuniNO_Check()
        {
            chkEntity = new ChakuniNyuuryoku_Entity();
            chkEntity.DataKBN = 5;
            chkEntity.Number = txtArrivalNO.Text;
            chkEntity.ProgramID = ProgramID;
            chkEntity.PC = PCID;
            chkEntity.OperatorCD = OperatorCD;
            DataTable dt = new DataTable();
            cbl = new chakuniNyuuryoku_BL();
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
            txtArrivalNO.Focus();
            return false;
        }
        private bool Update_Data(bool check = false)
        {
            chkEntity = new ChakuniNyuuryoku_Entity();
            chkEntity.ChakuniDate = string.IsNullOrEmpty(txtArrivalDate.Text) ? System.DateTime.Now.ToString("yyyy-MM-dd") : txtArrivalDate.Text;
            chkEntity.ChakuniNO = txtArrivalNO.Text;
            chkEntity.ProgramID = ProgramID;
            chkEntity.PC = PCID;
            chkEntity.OperatorCD = OperatorCD;
            cbl = new chakuniNyuuryoku_BL();
            dt_Header = cbl.ChakuniNyuuryoku_Update_Select(chkEntity, 1);
            if (dt_Header.Rows.Count > 0)
            {
                if (check)
                {
                    if (dt_Header.Rows[0]["SiireKanryouKBN_Head"].ToString() != "0"|| dt_Header.Rows[0]["SiireZumiSuu_Sum"].ToString() != "0")
                    {
                        bbl.ShowMessage("E164");
                        txtArrivalNO.Focus();
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                ChakuniNyuuryokuSelect(dt_Header);
            }

            dt_Details = cbl.ChakuniNyuuryoku_Update_Select(chkEntity, 2);
            if (dt_Details.Rows.Count > 0)
            {
                gvChakuniNyuuryoku.DataSource = dt_Details;

                dtTemp = dt_Details.Copy();
                dtmain = dtTemp;

                if (F8_dt1.Rows.Count == 0)
                    F8_dt1 = dt_Details.Clone();

                if (cboMode.SelectedValue.ToString() == "3" || cboMode.SelectedValue.ToString() == "2")
                {
                    F8_dt1 = dtmain.Copy();
                    gvChakuniNyuuryoku.Memory_Row_Count = F8_dt1.Rows.Count;
                }

                //if (cboMode.SelectedValue.ToString() == "3")
                //{
                //    gvChakuniNyuuryoku.Memory_Row_Count = dt_Details.Rows.Count;
                //}
            }
            else
                gvChakuniNyuuryoku.DataSource = dtClear;

            foreach (DataRow dr in dt_Header.Rows)
            {
                if (dr["SiireKanryouKBN"].ToString().Equals("1"))
                {
                    gvChakuniNyuuryoku.Columns["ChakuniSuu"].ReadOnly = true;
                    gvChakuniNyuuryoku.Columns["SiireKanryouKBN"].ReadOnly = true;
                }
                else
                {
                    gvChakuniNyuuryoku.Columns["ChakuniSuu"].ReadOnly = false;
                    gvChakuniNyuuryoku.Columns["SiireKanryouKBN"].ReadOnly = false;
                }
            }
            return true;
        }
        private void btn_Siiresaki_Click(object sender, EventArgs e)
            {
            //if (cboMode.Equals("1") || cboMode.Equals("2"))
            //    sd = new SiiresakiDetail();
            //else if (cboMode.Equals("3") || cboMode.Equals("4"))
            //    sd = new SiiresakiDetail(false);
            if (!string.IsNullOrWhiteSpace(txtSiiresaki.Text) && !txtSiiresaki.IsErrorOccurs)
                sd.ShowDialog();
            else
                txtSiiresaki.Focus();
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
        private void txtSouko_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!txtSouko.IsErrorOccurs)
                    {
                        DataTable dt = txtSouko.IsDatatableOccurs;
                        if (dt.Rows.Count > 0)
                        {
                            lblWareHouse.Text = dt.Rows[0]["SoukoName"].ToString();
                        }
                        else
                        {
                            lblWareHouse.Text = string.Empty;
                        }
                    }
                }
            }
        private void gvChakuniNyuuryoku_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (gvChakuniNyuuryoku.IsLastKeyEnter)
            {
                if (Grid_ErrorCheck(e.RowIndex, e.ColumnIndex))
                {
                    if (cboMode.SelectedValue.ToString().Equals("2"))
                    {
                        dtTemp.Clear();
                    }
                    //Temp_Save(e.RowIndex, true);
                }
            }
        }
        private bool Grid_ErrorCheck(int row, int col)
        {
            if (gvChakuniNyuuryoku.Columns[col].Name == "ChakuniSuu")
            {
                string value = gvChakuniNyuuryoku.Rows[row].Cells["ChakuniSuu"].EditedFormattedValue.ToString().Replace(",", "");
                int Konkai_Number = string.IsNullOrEmpty(gvChakuniNyuuryoku.Rows[row].Cells["ChakuniSuu"].EditedFormattedValue.ToString()) ? 0 : Convert.ToInt32(value);
                gvChakuniNyuuryoku.Rows[row].Cells["ChakuniSuu"].Value = Konkai_Number.ToString();
                if (Convert.ToInt64(value) < 0)
                {
                    bbl.ShowMessage("E109");
                    return false;
                }
            }
            if (gvChakuniNyuuryoku.Columns[col].Name == "ChakuniMeisaiTekiyou")   //HET
            {
                int MaxLength = ((DataGridViewTextBoxColumn)gvChakuniNyuuryoku.Columns["ChakuniMeisaiTekiyou"]).MaxInputLength;

                string byte_text = gvChakuniNyuuryoku.Rows[row].Cells["ChakuniMeisaiTekiyou"].EditedFormattedValue.ToString();
                if (cf.IsByteLengthOver(MaxLength, byte_text))
                {
                    MessageBox.Show("入力された文字が長すぎます", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void txtArrivalDate_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!string.IsNullOrWhiteSpace(txtSiiresaki.Text))
                    {
                        SiiresakiBL sbl = new SiiresakiBL();
                        DataTable dt1 = sbl.Siiresaki_Select_Check(txtSiiresaki.Text, txtArrivalDate.Text, "E227");
                        DataTable dt2 = sbl.Siiresaki_Select_Check(txtSiiresaki.Text, txtArrivalDate.Text, "E267");
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

        private void txtSizeNo_KeyDown(object sender, KeyEventArgs e)
        {
            F10_Gridview_Bind();
        }

        private void txtScheduled_KeyDown(object sender, KeyEventArgs e)
        {
            if(! string.IsNullOrEmpty(txtScheduled.Text))
            {
                bool bl_Next = false;
                chakuniNyuuryoku_BL bl = new chakuniNyuuryoku_BL();
                DataTable  dt_E133 = bl.ChakuniNyuuryoku_ErrorCheck(txtScheduled.Text, string.Empty, "E133");
                if (dt_E133.Rows[0]["MessageID"].ToString() == "E133")
                {
                    txtScheduled.Text = string.Empty;
                    txtScheduled.Focus();
                    bbl.ShowMessage("E133");
                    bl_Next = true;
                }
                if(bl_Next == false)
                {
                    DataTable dt_E268 = bl.ChakuniNyuuryoku_ErrorCheck(txtScheduled.Text, string.Empty, "E268");
                    if (dt_E268.Rows[0]["MessageID"].ToString() == "E268")
                    {
                        txtScheduled.Text = string.Empty;
                        txtScheduled.Focus();
                        bbl.ShowMessage("E268");
                    }
                }
            }
        }
        private void gvChakuniNyuuryoku_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             if (e.RowIndex >= 0 && e.ColumnIndex == 9)
             {
                 if (Convert.ToBoolean(gvChakuniNyuuryoku.Rows[e.RowIndex].Cells["SiireKanryouKBN"].EditedFormattedValue))
                 {
                        //Temp_Save(e.RowIndex);
                        //gvChakuniNyuuryoku.MoveNextCell();
                 }
             }
        }
    }
}
