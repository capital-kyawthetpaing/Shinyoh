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
        DataTable dtGS1;
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
            dtGS1 = CreateTable_Details();
            base_Entity = new BaseEntity();
            multi_Entity = new multipurposeEntity();
            staffBL = new StaffBL();
            soukoBL = new SoukoBL();
            dtClear = CreateTable_Details();
            sd = new SiiresakiDetail();
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
            SetButton(ButtonType.BType.Update, F3, "変更(F3)", true);
            SetButton(ButtonType.BType.Delete, F4, "削除(F4)", true);
            SetButton(ButtonType.BType.Inquiry, F5, "照会(F5)", true);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", true);
            SetButton(ButtonType.BType.Display, F10, "表示(F10)", true);
            SetButton(ButtonType.BType.Memory, F11, "保存(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            ChangeMode(Mode.New);
            txtArrivalNO.Focus();
            txtArrivalNO.ChangeDate = txtArrivalDate;
            txtSiiresaki.ChangeDate = txtArrivalDate;
            txtSiiresaki.lblName = lblSiiresaki;
            txtStaffCD.ChangeDate = txtArrivalDate;
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
            gvChakuniNyuuryoku.SetReadOnlyColumn("ShouhinCD,ShouhinName,ColorRyakuName,ColorNO,SizeNO,ChakuniYoteiDate,ChakuniYoteiSuu,ChakuniZumiSuu,JanCD,Chakuni,Hacchuu");
            gvChakuniNyuuryoku.SetHiraganaColumn("ChakuniMeisaiTekiyou");
        }
        private void ChangeMode(Mode mode)
        {
            switch (mode)
            {
                case Mode.New:
                    ErrorCheck();
                    New_Mode();
                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    break;
                case Mode.Update:
                    txtArrivalNO.E102Check(true);
                    txtArrivalNO.E133Check(true, "ChakuniNyuuryoku",txtArrivalNO,null,null);
                    txtArrivalNO.E268Check(true, "ChakuniNyuuryoku", txtArrivalNO, null);
                    Mode_Setting();
                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    txtArrivalNO.E102Check(true);
                    txtArrivalNO.E133Check(true, "ChakuniNyuuryoku", txtArrivalNO, null, null);
                    txtArrivalNO.E268Check(true, "ChakuniNyuuryoku", txtArrivalNO, null);
                    Mode_Setting();
                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;
                    break;
                case Mode.Inquiry:
                    txtArrivalNO.E102Check(true);
                    txtArrivalNO.E133Check(true, "ChakuniNyuuryoku", txtArrivalNO, null, null);
                    txtArrivalNO.E268Check(true, "ChakuniNyuuryoku", txtArrivalNO, null);
                    Mode_Setting();
                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;
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
        }
        private void New_Mode()
        {
            cf.Clear(PanelTitle);
            cf.Clear(PanelDetail);
            cf.DisablePanel(PanelTitle);
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
            txtScheduled.E133Check(true, "M_Siiresaki", txtScheduled, txtArrivalDate, null);
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
                if(cboMode.SelectedValue.Equals("1"))
                {
                    New_Mode();
                }
                else
                {
                    Mode_Setting();
                }
                dtTemp.Clear();
            }
            if(tagID=="8")
            {
                if (dtTemp.Rows.Count > 0)
                {
                    var dtConfirm = dtTemp.AsEnumerable().OrderBy(r => r.Field<string>("ShouhinCD")).ThenBy(r => r.Field<string>("ChakuniYoteiDate")).ThenBy(r => r.Field<string>("ChakuniYoteiGyouNO")).ThenBy(r => r.Field<string>("HacchuuGyouNO")).CopyToDataTable();
                    gvChakuniNyuuryoku.DataSource = dtConfirm;
                }
                else
                {
                    dtGS1 = CreateTable_Details();
                    gvChakuniNyuuryoku.DataSource = dtGS1;
                }
            }
            if (tagID == "10")
            {
                dtGridview();
                gvChakuniNyuuryoku.DataSource = dtmain;
                gvChakuniNyuuryoku.Select();
            }
            if (tagID == "11")
            {
                dtTemp = dtGS1;
                txtScheduled.Clear();
                txtShouhinCD.Clear();
                txtShouhinName.Clear();
                txtControlNo.Clear();
                txtJANCD.Clear();
                sbBrand.Clear();
                lblBrandName.Text = string.Empty;
                txtColor.Clear();
                txtYearTerm.Clear();
                txtSize.Clear();
                txtScheduled.Focus();
                gvChakuniNyuuryoku.ClearSelection();
                gvChakuniNyuuryoku.DataSource = dtClear;
            }
            if (tagID == "12")
            {
                if (ErrorCheck(PanelTitle) && ErrorCheck(PanelDetail) && Temp_Null())
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
                    }
                }
            }
            base.FunctionProcess(tagID);
        }
        private bool Temp_Null()
        {
            if (cboMode.SelectedValue.ToString().Equals("1") && dtTemp.Rows.Count == 0 || cboMode.SelectedValue.ToString().Equals("2") && dtTemp.Rows.Count == 0)
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
        private (string,string) GetInsert()
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
            dr["ShouhinCD"] = string.IsNullOrEmpty(txtShouhinCD.Text) ? null : txtShouhinCD.Text;
            dr["ShouhinName"] = string.IsNullOrEmpty(txtShouhinName.Text) ? null : txtShouhinName.Text;
            dr["KanriNO"] = string.IsNullOrEmpty(txtControlNo.Text) ? null : txtControlNo.Text;
            dr["JANCD"] = string.IsNullOrEmpty(txtJANCD.Text) ? null : txtJANCD.Text;
            dr["BrandCD"] = string.IsNullOrEmpty(sbBrand.Text) ? null : sbBrand.Text;
            dr["YearTerm"] = txtYearTerm.Text;
            dr["SeasonSS"] = chkSS.Checked ? "1" : "0";
            dr["SeasonFW"] = chkFW.Checked ? "1" : "0";
            dr["ColorNO"] = string.IsNullOrEmpty(txtColor.Text) ? null : txtColor.Text;
            dr["SizeNO"] = string.IsNullOrEmpty(txtSize.Text) ? null : txtSize.Text;
            dr["Operator"] = base_Entity.OperatorCD;
            dr["PC"] = base_Entity.PC;
            dr["ProgramID"] = base_Entity.ProgramID;
            dt.Rows.Add(dr);
            string main_XML = cf.DataTableToXml(dt);
            if(cboMode.SelectedValue.ToString()=="3")
            {
                detail_XML = cf.DataTableToXml(dt_Details);
                //DataTable dt1 = txtArrivalNO.IsDatatableOccurs;
                //dt1.Columns.Remove("ChakuniDate");
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
                //dt1.Columns.Remove("SiireKanryouKBN");
                //dt1.Columns.Remove("StaffCD");
                //dt1.Columns.Remove("StaffName");
                //dt1.Columns.Remove("SoukoCD");
                //dt1.Columns.Remove("SoukoName");
                //dt1.Columns.Remove("ChakuniDenpyouTekiyou");
                //dt1.Columns.Remove("MessageID");
                //dt1.Columns.Remove("ChakuniYoteiNO");
                //dt1.Columns.Remove("Chakuni");
                //dt1.Columns.Remove("Hacchuu");
                //detail_XML = cf.DataTableToXml(dt1);
            }
            else
            {
                detail_XML = cf.DataTableToXml(dtTemp);
            }

            return (main_XML, detail_XML);
        }
        private void DoInsert(string mode,string str_main, string str_detail)
        {
            chakuniNyuuryoku_BL bl = new chakuniNyuuryoku_BL();
            bl.ChakuniNyuuryoku_CUD(mode,str_main, str_detail);
            bbl.ShowMessage("I101");
        }
        private void DoUpdate(string mode,string str_main, string str_detail)
        {
            chakuniNyuuryoku_BL bl = new chakuniNyuuryoku_BL();
            bl.ChakuniNyuuryoku_CUD(mode, str_main, str_detail);
            bbl.ShowMessage("I101");
        }
        private void DoDelete(string mode,string str_main, string str_detail)
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
            HinbanCD = txtShouhinCD.Text,
            ShouhinName = txtShouhinName.Text,
            JANCD = txtJANCD.Text,
            BrandCD = sbBrand.Text,
            ColorNO = txtColor.Text,
            SizeNO = txtSize.Text,
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
            if (dtTemp.Rows.Count > 0)
            {
                var dtConfirm = dtTemp.AsEnumerable().OrderBy(r => r.Field<string>("ShouhinCD")).ThenBy(r => r.Field<string>("ChakuniYoteiDate")).ThenBy(r => r.Field<string>("Chakuni")).ThenBy(r => r.Field<string>("Hacchuu")).CopyToDataTable();
                gvChakuniNyuuryoku.DataSource = dtConfirm;
            }
            else
            {
                dtGS1 = CreateTable_Details();
                gvChakuniNyuuryoku.DataSource = dtGS1;
            }
        }
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtScheduled.Text) && string.IsNullOrWhiteSpace(txtShouhinCD.Text) && string.IsNullOrWhiteSpace(txtShouhinName.Text) && string.IsNullOrWhiteSpace(txtControlNo.Text) &&
                 string.IsNullOrWhiteSpace(txtJANCD.Text) && string.IsNullOrWhiteSpace(sbBrand.Text) && string.IsNullOrWhiteSpace(txtColor.Text)&& string.IsNullOrWhiteSpace(txtYearTerm.Text) && (!chkFW.Checked) && (!chkSS.Checked) && string.IsNullOrWhiteSpace(txtSize.Text))
            {
                bbl.ShowMessage("E111");
                txtScheduled.Focus();
            }
            else
            {
                dtGridview();
                gvChakuniNyuuryoku.DataSource = dtmain;
                gvChakuniNyuuryoku.Select();
            }
        }
        private DataTable dtGridview()
        {
            chkEntity = GetEntity();
            dtmain = cbl.ChakuniNyuuryoku_Display(chkEntity);
            return dtmain;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (GV_Check())
            {
                dtTemp = dtGS1;
                txtScheduled.Clear();
                txtShouhinCD.Clear();
                txtShouhinName.Clear();
                txtControlNo.Clear();
                txtJANCD.Clear();
                sbBrand.Clear();
                lblBrandName.Text = string.Empty;
                txtColor.Clear();
                txtYearTerm.Clear();
                txtSize.Clear();
                txtScheduled.Focus();
                gvChakuniNyuuryoku.ClearSelection();
                gvChakuniNyuuryoku.DataSource = dtClear;
            }
        }
        private bool GV_Check()
        {
            foreach (DataGridViewRow gv in gvChakuniNyuuryoku.Rows)
            {
                string value = gv.Cells["ChakuniSuu"].EditedFormattedValue.ToString().Replace(",", "");
                if (Convert.ToInt32(value) < 0)
                {
                    bbl.ShowMessage("E109");
                    return false;
                }
            }
            return true;
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
            dt.Columns.Add("ChakuniYoteiGyouNO", typeof(string));
            dt.Columns.Add("Chakuni", typeof(string));
            dt.Columns.Add("HacchuuNO", typeof(string));
            dt.Columns.Add("HacchuuGyouNO", typeof(string));
            dt.Columns.Add("Hacchuu", typeof(string));
            dt.Columns.Add("ShouhinCD", typeof(string));

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
        private void txtSize_KeyDown(object sender, KeyEventArgs e)
        {
            dtGridview();
            gvChakuniNyuuryoku.DataSource = dtmain;
            gvChakuniNyuuryoku.Select();
        }
        private void txtArrivalNO_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtArrivalNO.IsErrorOccurs)
                {
                    if (cboMode.SelectedValue.ToString() == "2" || cboMode.SelectedValue.ToString()=="1")
                    {
                        cf.EnablePanel(PanelDetail);
                        cf.DisablePanel(PanelTitle);
                        txtArrivalDate.Focus();
                    }
                    else if(cboMode.SelectedValue.ToString() == "3" || cboMode.SelectedValue.ToString() == "4")
                    {
                        cf.DisablePanel(PanelTitle);
                        Control BtnF9 = this.TopLevelControl.Controls.Find("BtnF9", true)[0];
                        BtnF9.Visible = false;
                        if (cboMode.SelectedValue.ToString() == "3")
                        {
                            Control btnF12 = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                            btnF12.Focus();
                        }
                    }
                }
                DataTable dt=txtArrivalNO.IsDatatableOccurs;
                if (dt.Rows.Count > 0 && cboMode.SelectedValue.ToString() != "1")
                {
                    Update_Data();
                }
                else
                {
                    txtArrivalDate.Focus();
                }
            }
        }
        private void Update_Data()
        {
            chkEntity = new ChakuniNyuuryoku_Entity();
            chkEntity .ChakuniDate=string.IsNullOrEmpty(txtArrivalDate.Text)?System.DateTime.Now.ToString("yyyy-MM-dd"):txtArrivalDate.Text;
            chkEntity.ChakuniNO = txtArrivalNO.Text;

            cbl = new chakuniNyuuryoku_BL();
            dt_Header = cbl.ChakuniNyuuryoku_Update_Select(chkEntity, 1);
            if (dt_Header.Rows.Count > 0)
                ChakuniNyuuryokuSelect(dt_Header);

            
            dt_Details= cbl.ChakuniNyuuryoku_Update_Select(chkEntity, 2);
            if (dt_Details.Rows.Count > 0)
            {
                gvChakuniNyuuryoku.DataSource = dt_Details;
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
        }
        private void btn_Siiresaki_Click(object sender, EventArgs e)
        {
            sd.ShowDialog();
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
            if (Grid_ErrorCheck(e.RowIndex, e.ColumnIndex))
            {
                if (cboMode.SelectedValue.ToString().Equals("2"))
                {
                    dtTemp.Clear();
                }
                Temp_Save(e.RowIndex);
            }
        }
        private void Temp_Save(int row)
        {
            if ((!gvChakuniNyuuryoku.Rows[row].Cells["ChakuniSuu"].EditedFormattedValue.ToString().Equals("0")))
            {
                dtGridview();
                //string a= gvChakuniNyuuryoku.Rows[row].Cells["colShouhinCD"].EditedFormattedValue.ToString();
                if (dtGS1.Rows.Count > 0)
                {
                    for (int i = dtGS1.Rows.Count - 1; i >= 0; i--)
                    {
                        string data = dtGS1.Rows[i]["ChakuniSuu"].ToString();
                        if (gvChakuniNyuuryoku.Rows[row].Cells["ChakuniSuu"].Value.ToString() == data)
                        {
                            dtGS1.Rows[i].Delete();
                        }
                    }
                }


                DataRow dr1 = dtGS1.NewRow();
                for (int i = 0; i < dtGS1.Columns.Count; i++)
                {
                    if (i == 10)
                        dr1[i] = gvChakuniNyuuryoku.Rows[row].Cells[dtGS1.Columns[i].ColumnName].EditedFormattedValue;
                    else
                       dr1[i] = string.IsNullOrEmpty(gvChakuniNyuuryoku.Rows[row].Cells[dtGS1.Columns[i].ColumnName].ToString().Trim()) ? null : gvChakuniNyuuryoku[i, row].EditedFormattedValue.ToString();

                }
                //{

                dtGS1.Rows.Add(dr1);


            }
        }
        private bool Grid_ErrorCheck(int row, int col)
        {
            if (gvChakuniNyuuryoku.Columns[col].Name == "ChakuniSuu")
            {
                string value = gvChakuniNyuuryoku.Rows[row].Cells["ChakuniSuu"].EditedFormattedValue.ToString().Replace(",", "");
                if (Convert.ToInt64(value) < 0)
                {
                    bbl.ShowMessage("E109");
                    return false;
                }
                else
                {
                    gvChakuniNyuuryoku.MoveNextCell();
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
                    DataTable dt1 = sbl.Siiresaki_Select_Check(txtSiiresaki.Text,txtArrivalDate.Text,"E227");
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

        private void txtSiiresaki_TextChanged(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtSiiresaki.Text))
            {
                txtSiiresaki.Text = string.Empty;
            }
        }

        private void gvChakuniNyuuryoku_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 9)
            {
                if (Convert.ToBoolean(gvChakuniNyuuryoku.Rows[e.RowIndex].Cells["SiireKanryouKBN"].EditedFormattedValue))
                {
                    Temp_Save(e.RowIndex);
                    gvChakuniNyuuryoku.MoveNextCell();
                }
            }
        }
    }
}
