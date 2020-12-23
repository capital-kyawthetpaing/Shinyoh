using System;
using Shinyoh;
using Entity;
using BL;
using CKM_CommonFunction;
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
        DataTable dtmain;
        DataTable dtTemp;
        DataTable dtGridSource = new DataTable();
        SiiresakiDetails sd = new SiiresakiDetails();
        DataTable dtGS1;
        BaseEntity base_Entity;
        StaffBL staffBL;
        SoukoBL soukoBL;
        DataTable dtClear;
        public string tdDate;
        ChakuniNyuuryoku_Entity chkEntity;
        public ChakuniNyuuryoku()
        {
            InitializeComponent();
            cf = new CommonFunction();
            bbl = new BaseBL();
            cbl = new chakuniNyuuryoku_BL();
            dtmain = new DataTable();
            dtTemp = new DataTable();
            dtGS1 = CreateTable();
            base_Entity = new BaseEntity();
            staffBL = new StaffBL();
            soukoBL = new SoukoBL();
            dtClear = CreateTable();
            chkEntity = new ChakuniNyuuryoku_Entity();
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
            lblSiiresaki.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblStaff.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblWareHouse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblBrandName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            ChangeMode(Mode.New);
            txtArrivalNO.Focus();
            multipurposeEntity multipurpose_entity = new multipurposeEntity();
            txtSiiresaki.ChangeDate = txtArrivalDate;
            txtSiiresaki.lblName = lblSiiresaki;
            txtStaffCD.ChangeDate = txtArrivalDate;
            base_Entity = _GetBaseData();
        }
        private void ChangeMode(Mode mode)
        {
            Mode_Setting();
            switch (mode)
            {
                case Mode.New:
                    ErrorCheck();
                    cf.Clear(PanelTitle);
                    cf.Clear(panelDetails);
                    cf.EnablePanel(PanelTitle);
                    cf.EnablePanel(panelDetails);
                    txtArrivalNO.Focus();
                    New_Mode();
                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    break;
                case Mode.Update:
                    txtArrivalNO.E102Check(true);
                    txtArrivalNO.E133Check(true, "ChakuniNyuuryoku",txtArrivalNO,null,null);
                    txtArrivalNO.E268Check(true, "ChakuniNyuuryoku", txtArrivalNO, null);
                    cf.Clear(PanelTitle);
                    cf.Clear(panelDetails);
                    cf.EnablePanel(PanelTitle);
                    cf.EnablePanel(panelDetails);
                    txtArrivalNO.Enabled = true;
                    txtArrivalNO.Focus();
                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    txtArrivalNO.E133Check(true, "ChakuniNyuuryoku", txtArrivalNO, null, null);
                    txtArrivalNO.E268Check(true, "ChakuniNyuuryoku", txtArrivalNO, null);
                    cf.Clear(PanelTitle);
                    cf.Clear(panelDetails);
                    cf.EnablePanel(PanelTitle);
                    cf.DisablePanel(panelDetails);
                    txtArrivalNO.Enabled = true;
                    txtArrivalNO.Focus();
                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;
                    break;
                case Mode.Inquiry:
                    txtArrivalNO.E133Check(true, "ChakuniNyuuryoku", txtArrivalNO, null, null);
                    txtArrivalNO.E268Check(true, "ChakuniNyuuryoku", txtArrivalNO, null);
                    cf.Clear(PanelTitle);
                    cf.Clear(panelDetails);
                    cf.EnablePanel(PanelTitle);
                    cf.DisablePanel(panelDetails);
                    txtArrivalNO.Enabled = true;
                    txtArrivalNO.Focus();
                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;
                    break;
            }
        }
        private void Mode_Setting()
        {
            cf.Clear(PanelTitle);
            cf.Clear(panelDetails);
            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(panelDetails);
            txtArrivalNO.Focus();
        }
        private void New_Mode()
        {
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
        }
        public void ErrorCheck()
        {
            txtArrivalNO.E102Check(true);
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
            txtScheduledNo.E133Check(true, "M_Siiresaki", txtScheduledNo, txtArrivalDate, null);
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
                Clear();
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
                    dtGS1 = CreateTable();
                    gvChakuniNyuuryoku.DataSource = dtGS1;
                }
            }
            if (tagID == "10")
            {
                dtGridview();
                gvChakuniNyuuryoku.DataSource = dtmain;
            }
            if (tagID == "11")
            {
                dtTemp = dtGS1;
                txtScheduledNo.Clear();
                txtShouhinCD.Clear();
                txtShouhinName.Clear();
                txtControlNo.Clear();
                txtJANCD.Clear();
                sbBrand.Clear();
                lblBrandName.Text = string.Empty;
                txtColor.Clear();
                txtYearTerm.Clear();
                txtSize.Clear();
                txtScheduledNo.Focus();
                gvChakuniNyuuryoku.ClearSelection();
                gvChakuniNyuuryoku.DataSource = dtClear;
            }
            if (tagID == "12")
            {
                if (ErrorCheck(PanelTitle) && ErrorCheck(panelDetails))
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
            //Clear();
            base.FunctionProcess(tagID);
        }
        public void Clear()
        {
            cf.Clear(PanelTitle);
            cf.Clear(panelDetails);
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
        }
        public void Create_Datatable_Column(DataTable create_dt)
        {
            create_dt.Columns.Add("ChakuniNO");
            create_dt.Columns.Add("ChakuniDate");
            create_dt.Columns.Add("SiiresakiCD");
            create_dt.Columns.Add("SiiresakiName");
            create_dt.Columns.Add("SiiresakiRyakuName");
            create_dt.Columns.Add("SiiresakiYuubinNO1");
            create_dt.Columns.Add("SiiresakiYuubinNO2");
            create_dt.Columns.Add("SiiresakiJuusho1");
            create_dt.Columns.Add("SiiresakiJuusho2");
            create_dt.Columns.Add("SiiresakiTelNO11");
            create_dt.Columns.Add("SiiresakiTelNO12");
            create_dt.Columns.Add("SiiresakiTelNO13");
            create_dt.Columns.Add("SiiresakiTelNO21");
            create_dt.Columns.Add("SiiresakiTelNO22");
            create_dt.Columns.Add("SiiresakiTelNO23");
            create_dt.Columns.Add("StaffCD");
            create_dt.Columns.Add("SoukoCD");
            create_dt.Columns.Add("ChakuniDenpyouTekiyou");
            create_dt.Columns.Add("ChakuniYoteiNO");
            create_dt.Columns.Add("ShouhinCD");
            create_dt.Columns.Add("ShouhinName");
            create_dt.Columns.Add("JANCD");
            create_dt.Columns.Add("KanriNO");
            create_dt.Columns.Add("BrandCD");
            create_dt.Columns.Add("YearTerm");
            create_dt.Columns.Add("SeasonSS");
            create_dt.Columns.Add("SeasonFW");
            create_dt.Columns.Add("ColorNO");
            create_dt.Columns.Add("SizeNO");

            create_dt.Columns.Add("InsertOperator");
            create_dt.Columns.Add("UpdateOperator");
            create_dt.Columns.Add("PC");
            create_dt.Columns.Add("ProgramID");

        }
        private (string, string) GetInsert()
        {
            SiiresakiEntity s_obj = sd.Access_Siiresaki_obj;
            DataTable dt = new DataTable();
            Create_Datatable_Column(dt);
            DataRow dr = dt.NewRow();
            dr["ChakuniNO"] = txtArrivalNO.Text;
            dr["ChakuniDate"] = txtArrivalDate.Text;
            dr["SiiresakiCD"] = txtSiiresaki.Text;
            dr["SiiresakiName"] = s_obj.SiiresakiName;
            dr["SiiresakiRyakuName"] = s_obj.SiiresakiRyakuName;
            dr["SiiresakiYuubinNO1"] = s_obj.YuubinNO1;
            dr["SiiresakiYuubinNO2"] = s_obj.YuubinNO2;
            dr["SiiresakiJuusho1"] = s_obj.Juusho1;
            dr["SiiresakiJuusho2"] = s_obj.Juusho2;
            dr["SiiresakiTelNO11"] = s_obj.Tel11;
            dr["SiiresakiTelNO12"] = s_obj.Tel12;
            dr["SiiresakiTelNO13"] = s_obj.Tel13;
            dr["SiiresakiTelNO21"] = s_obj.Tel21;
            dr["SiiresakiTelNO22"] = s_obj.Tel22;
            dr["SiiresakiTelNO23"] = s_obj.Tel23;
            dr["StaffCD"] = txtStaffCD.Text;
            dr["SoukoCD"] = txtSouko.Text;
            dr["ChakuniDenpyouTekiyou"] = txtDescription.Text;
            dr["ChakuniYoteiNO"] = txtScheduledNo.Text;
            dr["ShouhinCD"] = txtShouhinCD.Text;
            dr["ShouhinName"] = txtShouhinName.Text;
            dr["KanriNO"] = txtControlNo.Text;
            dr["JANCD"] = txtJANCD.Text;
            dr["BrandCD"] = sbBrand.Text;
            dr["YearTerm"] = txtYearTerm.Text;
            dr["SeasonSS"] = chkSS.Checked ? "1" : "0";
            dr["SeasonFW"] = chkFW.Checked ? "1" : "0";
            dr["ColorNO"] = txtColor.Text;
            dr["SizeNO"] = txtSize.Text;
            dr["InsertOperator"] = base_Entity.OperatorCD;
            dr["UpdateOperator"] = base_Entity.OperatorCD;
            dr["PC"] = base_Entity.PC;
            dr["ProgramID"] = base_Entity.ProgramID;
            dt.Rows.Add(dr);
            string main_XML = cf.DataTableToXml(dt);
            string detail_XML = cf.DataTableToXml(dtTemp);//ses

            return (main_XML, detail_XML);
        }
        private void DoInsert(string mode, string str_main, string str_detail)
        {
            chakuniNyuuryoku_BL bl = new chakuniNyuuryoku_BL();
            bl.ChakuniNyuuryoku_CUD(mode, str_main, str_detail);
        }
        private ChakuniNyuuryoku_Entity GetEntity()
        {
            ChakuniNyuuryoku_Entity chkEntity = new ChakuniNyuuryoku_Entity()
            {
             ChakuniNO = txtArrivalNO.Text,
            ChakuniDate = txtArrivalDate.Text,
            ChakuniYoteiNO = txtScheduledNo.Text,
            ShouhinCD = txtShouhinCD.Text,
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
                if (dt.Rows[0]["MessageID"].ToString() == "E132")
                {
                    txtArrivalDate.Text = dt.Rows[0]["ChakuniDate"].ToString();
                    txtSiiresaki.Text = dt.Rows[0]["SiiresakiCD"].ToString();
                    lblSiiresaki.Text = dt.Rows[0]["SiiresakiRyakuName"].ToString();
                    txtStaffCD.Text = dt.Rows[0]["StaffCD"].ToString();
                    lblStaff.Text = dt.Rows[0]["StaffName"].ToString();
                    txtSouko.Text = dt.Rows[0]["SoukoCD"].ToString();
                    lblWareHouse.Text = dt.Rows[0]["SoukoName"].ToString();
                    txtDescription.Text = dt.Rows[0]["ChakuniDenpyouTekiyou"].ToString();
                    //txtScheduledNo.Text = dt.Rows[0]["ChakuniYoteiNO "].ToString();
                    //txtShouhinCD.Text = dt.Rows[0]["ShouhinCD"].ToString();
                    //txtShouhinName.Text = dt.Rows[0]["ShouhinName"].ToString();
                    //sbBrand.Text = dt.Rows[0]["BrandCD"].ToString();
                    //txtJANCD.Text = dt.Rows[0]["JANCD"].ToString();
                    //txtSize.Text = dt.Rows[0]["SizeNO"].ToString();
                    //txtColor.Text = dt.Rows[0]["ColorNO"].ToString();

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

                    dt.Columns.Remove("SiiresakiRyakuName");
                    dt.Columns.Remove("SiiresakiYuubinNO1");
                    dt.Columns.Remove("SiiresakiYuubinNO2");
                    dt.Columns.Remove("SiiresakiJuusho1");
                    dt.Columns.Remove("SiiresakiJuusho2");
                    dt.Columns.Remove("SiiresakiTelNO1-1");
                    dt.Columns.Remove("SiiresakiTelNO1-2");
                    dt.Columns.Remove("SiiresakiTelNO1-3");
                    dt.Columns.Remove("SiiresakiTelNO2-1");
                    dt.Columns.Remove("SiiresakiTelNO2-2");
                    dt.Columns.Remove("SiiresakiTelNO2-3");
                    dt.Columns.Remove("SiireKanryouKBN");
                    dt.Columns.Remove("SiiresakiCD");
                    dt.Columns.Remove("ChakuniDate");
                    dt.Columns.Remove("SiiresakiName");
                    dt.Columns.Remove("StaffCD");
                    dt.Columns.Remove("SoukoCD");
                    dt.Columns.Remove("ChakuniDenpyouTekiyou");
                    dt.Columns.Remove("MessageID");
                    dt.Columns.Remove("StaffName");
                    dt.Columns.Remove("SoukoName");
                    dt.Columns.Remove("ChakuniYoteiNO");
                    dt.Columns.Remove("ChakuniSuu");
                    dt.Columns.Remove("ChakuniMeisaiTekiyou");
                    dt.Columns.Remove("a");
                    dt.Columns.Remove("b");
                    gvChakuniNyuuryoku.DataSource = dt;
                }
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dtTemp.Rows.Count > 0)
            {
                var dtConfirm = dtTemp.AsEnumerable().OrderBy(r => r.Field<string>("ShouhinCD")).ThenBy(r => r.Field<string>("ChakuniYoteiDate")).ThenBy(r => r.Field<string>("ChakuniYoteiGyouNO")).ThenBy(r => r.Field<string>("HacchuuGyouNO")).CopyToDataTable();
                gvChakuniNyuuryoku.DataSource = dtConfirm;
            }
            else
            {
                dtGS1 = CreateTable();
                gvChakuniNyuuryoku.DataSource = dtGS1;
            }
        }
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtScheduledNo.Text) && string.IsNullOrWhiteSpace(txtShouhinCD.Text) && string.IsNullOrWhiteSpace(txtShouhinName.Text) && string.IsNullOrWhiteSpace(txtControlNo.Text) &&
                 string.IsNullOrWhiteSpace(txtJANCD.Text) && string.IsNullOrWhiteSpace(sbBrand.Text) && string.IsNullOrWhiteSpace(txtColor.Text)&& string.IsNullOrWhiteSpace(txtYearTerm.Text) && (!chkFW.Checked) && (!chkSS.Checked) && string.IsNullOrWhiteSpace(txtSize.Text))
            {
                bbl.ShowMessage("E111");
                txtScheduledNo.Focus();
            }
            else
            {
                dtGridview();
                gvChakuniNyuuryoku.DataSource = dtmain;
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
            dtTemp = dtGS1;
            txtScheduledNo.Clear();
            txtShouhinCD.Clear();
            txtShouhinName.Clear();
            txtControlNo.Clear();
            txtJANCD.Clear();
            sbBrand.Clear();
            lblBrandName.Text = string.Empty;
            txtColor.Clear();
            txtYearTerm.Clear();
            txtSize.Clear();
            txtScheduledNo.Focus();
            gvChakuniNyuuryoku.ClearSelection();
            gvChakuniNyuuryoku.DataSource = dtClear;
        }
        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ShouhinCD", typeof(string));
            dt.Columns.Add("ShouhinName", typeof(string));
            dt.Columns.Add("ColorRyakuName", typeof(string));
            dt.Columns.Add("ColorNO", typeof(string));
            dt.Columns.Add("SizeNO", typeof(string));
            dt.Columns.Add("ChakuniYoteiDate", typeof(string));
            dt.Columns.Add("ChakuniYoteiSuu", typeof(string));
            dt.Columns.Add("ChakuniZumiSuu", typeof(string));
            dt.Columns.Add("ChakuniSuu", typeof(string));
            //dt.Columns.Add("chk", typeof(int));
            dt.Columns.Add("d", typeof(string));
            dt.Columns.Add("JanCD", typeof(string));
            dt.Columns.Add("ChakuniYoteiGyouNO", typeof(string));
            dt.Columns.Add("HacchuuGyouNO", typeof(string));
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
        }
        private void txtArrivalNO_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtArrivalNO.IsErrorOccurs)
                {
                    if (cboMode.SelectedValue.ToString() == "2" || cboMode.SelectedValue.ToString()=="1")
                    {
                        cf.EnablePanel(panelDetails);
                        cf.DisablePanel(PanelTitle);
                        txtArrivalDate.Focus();
                    }
                    else if(cboMode.SelectedValue.ToString() == "3" || cboMode.SelectedValue.ToString() == "4")
                    {
                        cf.DisablePanel(PanelTitle);
                    }
                }
                DataTable dt = txtArrivalNO.IsDatatableOccurs;
                if (dt.Rows.Count > 0 && cboMode.SelectedValue.ToString() != "1")
                {
                    if(dt.Rows[0]["MessageID"].ToString()=="E132")
                    {
                        string KBN = dt.Rows[0]["SiireKanryouKBN"].ToString();
                        if (KBN.ToString().Equals("1"))
                        {
                            ChakuniNyuuryokuSelect(dt);
                            gvChakuniNyuuryoku.Columns["colArrivalTime"].ReadOnly = true;
                        }

                    }
                }
                else
                {
                    txtArrivalDate.Focus();
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
                if (!txtSiiresaki.IsErrorOccurs)
                {
                    DataTable dt = txtSiiresaki.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                    {
                       sd.Access_Siiresaki_obj = From_DB_To_Siiresaki(dt);
                        lblSiiresaki.Text = dt.Rows[0]["SiiresakiName"].ToString();
                    }
                    else
                    {
                        lblSiiresaki.Text = string.Empty;
                    }
                }
            }
        }
        private SiiresakiEntity From_DB_To_Siiresaki(DataTable dt)
        {
            SiiresakiEntity obj = new SiiresakiEntity();
            obj.SiiresakiCD = dt.Rows[0]["SiiresakiCD"].ToString();
            obj.SiiresakiName = dt.Rows[0]["SiiresakiName"].ToString();
            obj.SiiresakiRyakuName = dt.Rows[0]["SiiresakiRyakuName"].ToString();
            if (dt.Columns.Contains("SiiresakiYuubinNO1"))
                obj.YuubinNO1 = dt.Rows[0]["SiiresakiYuubinNO1"].ToString();
            else
                obj.YuubinNO1 = dt.Rows[0]["YuubinNO1"].ToString();
            if (dt.Columns.Contains("SiiresakiYuubinNO2"))
                obj.YuubinNO2 = dt.Rows[0]["SiiresakiYuubinNO2"].ToString();
            else
                obj.YuubinNO2 = dt.Rows[0]["YuubinNO2"].ToString();
            if (dt.Columns.Contains("SiiresakiJuusho1"))
                obj.Juusho1 = dt.Rows[0]["SiiresakiJuusho1"].ToString();
            else
                obj.Juusho1 = dt.Rows[0]["Juusho1"].ToString();
            if (dt.Columns.Contains("SiiresakiJuusho2"))
                obj.Juusho2 = dt.Rows[0]["SiiresakiJuusho2"].ToString();
            else
                obj.Juusho2 = dt.Rows[0]["Juusho2"].ToString();
            if (dt.Columns.Contains("SiiresakiTelNO1-1"))
                obj.Tel11 = dt.Rows[0]["SiiresakiTelNO1-1"].ToString();
            else
                obj.Tel11 = dt.Rows[0]["Tel11"].ToString();
            if (dt.Columns.Contains("SiiresakiTelNO1-2"))
                obj.Tel12 = dt.Rows[0]["SiiresakiTelNO1-2"].ToString();
            else
                obj.Tel12 = dt.Rows[0]["Tel12"].ToString();
            if (dt.Columns.Contains("SiiresakiTelNO1-3"))
                obj.Tel13 = dt.Rows[0]["SiiresakiTelNO1-3"].ToString();
            else
                obj.Tel13 = dt.Rows[0]["Tel13"].ToString();
            if (dt.Columns.Contains("SiiresakiTelNO2-1"))
                obj.Tel21 = dt.Rows[0]["SiiresakiTelNO2-1"].ToString();
            else
                obj.Tel21 = dt.Rows[0]["Tel21"].ToString();
            if (dt.Columns.Contains("SiiresakiTelNO2-2"))
                obj.Tel22 = dt.Rows[0]["SiiresakiTelNO2-2"].ToString();
            else
                obj.Tel22 = dt.Rows[0]["Tel22"].ToString();
            if (dt.Columns.Contains("SiiresakiTelNO2-3"))
                obj.Tel23 = dt.Rows[0]["SiiresakiTelNO2-3"].ToString();
            else
                obj.Tel23 = dt.Rows[0]["Tel23"].ToString();
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
        private void gvChakuniNyuuryoku_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (gvChakuniNyuuryoku.Columns[e.ColumnIndex].Name == "colArrivalTime")
            {
                var value = gvChakuniNyuuryoku.Rows[e.RowIndex].Cells["colArrivalTime"].EditedFormattedValue.ToString();
                if (Convert.ToInt64(value) < 0)
                {
                    bbl.ShowMessage("E109");
                    e.Cancel = true;
                }
            }
        }
        private void gvChakuniNyuuryoku_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
                dtGridview();
                if (!gvChakuniNyuuryoku.Rows[e.RowIndex].Cells["colArrivalTime"].EditedFormattedValue.ToString().Equals("0"))
                {
                    if (gvChakuniNyuuryoku.Rows[e.RowIndex].Cells["colArrivalTime"].Value.ToString() == dtmain.Rows[e.RowIndex]["ChakuniSuu"].ToString() &&   gvChakuniNyuuryoku.Rows[e.RowIndex].Cells["colDetails"].Value.ToString() == dtmain.Rows[e.RowIndex]["d"].ToString())
                    { 
                        return;
                    }
                    else
                    {
                        if (dtGS1.Rows.Count > 0)
                        {
                            for (int i = dtGS1.Rows.Count - 1; i >= 0; i--)
                            {
                                string data = dtGS1.Rows[i]["ChakuniSuu"].ToString();
                                if (gvChakuniNyuuryoku.Rows[e.RowIndex].Cells["colArrivalTime"].Value.ToString() == data)
                                {
                                    dtGS1.Rows[i].Delete();
                                }
                            }
                        }
                        DataRow dr1 = dtGS1.NewRow();
                        for (int i = 0; i < dtGS1.Columns.Count; i++)
                        {
                            dr1[i] = gvChakuniNyuuryoku[i+1, e.RowIndex].Value;
                        }
                        dtGS1.Rows.Add(dr1);
                    }
                }
        }
    }
}
