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
        ChakuniYoteiNyuuryokuEntity chkEntity;
        ChakuniYoteiNyuuryoku_BL cbl;
        public string tdDate;
        public ChakuniYoteiNyuuryoku()
        {
            InitializeComponent();
            cf = new CommonFunction();
            base_Entity = new BaseEntity();
            staffBL = new StaffBL();
            soukoBL = new SoukoBL();
            bbl = new BaseBL();
            dtmain = new DataTable();
            chkEntity = new ChakuniYoteiNyuuryokuEntity();
            cbl = new ChakuniYoteiNyuuryoku_BL();
            sd = new SiiresakiDetail();
        }
        private void ChakuniYoteiNyuuryoku_Load(object sender, EventArgs e)
        {
            ProgramID = "ChakuniYoteiNyuuryoku";
            StartProgram();
            cboMode.Bind(false, multi_Entity);
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
            txtChakuniYoteiNO.Focus();
            base_Entity = _GetBaseData();
            txtSiiresaki.ChangeDate = txtDate;
            txtStaffCD.ChangeDate = txtDate;
            txtChakuniYoteiNO.ChangeDate = txtDate;
            lblSiiresaki.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblStaff.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblWareHouse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblBrandName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtSiiresaki.lblName = lblSiiresaki;
            txtStaffCD.lblName = lblStaff;
            txtSouko.lblName = lblWareHouse;
            txtBrandCD.lblName = lblBrandName;
            gvChakuniYoteiNyuuryoku.SetGridDesign();
            gvChakuniYoteiNyuuryoku.SetReadOnlyColumn("colShouhinCD,colShouhinName,colColorRyakuName,colColorNO,colSizeNO,colDate,colArrivalNo,colChakuniZumiSuu,colJanCD,colChakuniYoteiGyouNO,colHacchuuGyouNO");
            gvChakuniYoteiNyuuryoku.SetHiraganaColumn("colDetails");
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
                    txtChakuniYoteiNO.E102Check(true);
                    txtChakuniYoteiNO.E133Check(true, "ChakuniYoteiNyuuryoku", txtChakuniYoteiNO, null, null);
                    txtChakuniYoteiNO.E268Check(true, "ChakuniYoteiNyuuryoku", txtChakuniYoteiNO, null);
                    Mode_Setting();
                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    txtChakuniYoteiNO.E102Check(true);
                    txtChakuniYoteiNO.E133Check(true, "ChakuniYoteiNyuuryoku", txtChakuniYoteiNO, null, null);
                    txtChakuniYoteiNO.E268Check(true, "ChakuniYoteiNyuuryoku", txtChakuniYoteiNO, null);
                    Mode_Setting();
                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;
                    break;
                case Mode.Inquiry:
                    txtChakuniYoteiNO.E102Check(true);
                    txtChakuniYoteiNO.E133Check(true, "ChakuniYoteiNyuuryoku", txtChakuniYoteiNO, null, null);
                    txtChakuniYoteiNO.E268Check(true, "ChakuniYoteiNyuuryoku", txtChakuniYoteiNO, null);
                    Mode_Setting();
                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;
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
                Clear();
            }
            if (tagID == "8")
            {
                
            }
            if (tagID == "10")
            {
                
            }
            if (tagID == "11")
            {
                
            }
            if (tagID == "12")
            {
                if (ErrorCheck(PanelTitle) && ErrorCheck(PanelDetail))
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
        private void DBProcess()
        {
            
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
            txtChakuniYoteiNO.Focus();
            New_Mode();
        }
        private void Mode_Setting()
        {
            cf.Clear(PanelTitle);
            cf.Clear(PanelDetail);
            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(PanelDetail);
            txtChakuniYoteiNO.Focus();
        }
        private void New_Mode()
        {
            cf.Clear(PanelTitle);
            cf.Clear(PanelDetail);
            cf.DisablePanel(PanelTitle);
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
        }
        public void ErrorCheck()
        {
            txtDate.E102Check(true);
            txtDate.E103Check(true);
            txtSiiresaki.E102Check(true);
            txtSiiresaki.E101Check(true, "M_Siiresaki", txtSiiresaki, txtDate, null);
            txtSiiresaki.E227Check(true, "M_Siiresaki", txtSiiresaki, txtDate);
            txtSiiresaki.E267Check(true, "M_Siiresaki", txtSiiresaki, txtDate);
            txtStaffCD.E102Check(true);
            txtStaffCD.E101Check(true, "M_Staff", txtStaffCD, txtDate, null);
            txtStaffCD.E135Check(true, "M_Staff", txtStaffCD, txtDate);
            txtSouko.E102Check(true);
            txtSouko.E101Check(true, "souko", txtSouko, null, null);
            txtNumber.E102Check(true);
            txtDateFrom.E103Check(true);
            txtDateTo.E103Check(true);
            txtDateTo.E106Check(true, txtDateFrom, txtDateTo);
        }
        private ChakuniYoteiNyuuryokuEntity GetData()
        {
            ChakuniYoteiNyuuryokuEntity chkEntity = new ChakuniYoteiNyuuryokuEntity()
            {
                ChakuniYoteiNO = txtChakuniYoteiNO.Text,
                ChakuniYoteiDate = txtDate.Text,
                BrandCD = txtBrandCD.Text,
                ShouhinCD = txtShouhinCD.Text,
                ShouhinName = txtShouhinName.Text,
                JANCD = txtJANCD.Text,
                YearTerm = txtYearTerm.Text,
                SeasonSS = chkSS.Checked ? "1" : "0",
                SeasonFW = chkFW.Checked ? "1" : "0",
                ColorNO = txtColor.Text,
                SizeNO = txtSize.Text,
                SoukoCD = txtSouko.Text,
                ChakuniYoteiDateFrom = txtDateFrom.Text,
                ChakuniYoteiDateTo = txtDateTo.Text,
                OperatorCD = OperatorCD,
                ProgramID = ProgramID,
                PC = PCID
            };
            return chkEntity;
        }
        private DataTable dtGridview()
        {
            chkEntity = GetData();
            dtmain = cbl.ChakuniYoteiNyuuryoku_Display(chkEntity);

            return dtmain;
        }
        private void txtBrandCD_KeyDown(object sender, KeyEventArgs e)
        {
            multipurposeBL bl = new multipurposeBL();
            string a = txtBrandCD.Text.ToString();
            DataTable dt = bl.M_Multiporpose_SelectData(a, 1, string.Empty, string.Empty);

            if (dt.Rows.Count > 0)
                lblBrandName.Text = dt.Rows[0]["Char1"].ToString();
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
       
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBrandCD.Text) && string.IsNullOrWhiteSpace(txtShouhinCD.Text) && string.IsNullOrWhiteSpace(txtShouhinName.Text) && 
                string.IsNullOrWhiteSpace(txtJANCD.Text) && string.IsNullOrWhiteSpace(txtYearTerm.Text) && (!chkFW.Checked) && (!chkSS.Checked) && string.IsNullOrWhiteSpace(txtColor.Text) && string.IsNullOrWhiteSpace(txtDateFrom.Text) && string.IsNullOrWhiteSpace(txtDateTo.Text)  && string.IsNullOrWhiteSpace(txtSize.Text))
            {
                bbl.ShowMessage("E111");
                txtBrandCD.Focus();
            }
            else
            {
                dtGridview();
                gvChakuniYoteiNyuuryoku.DataSource = dtmain;
                gvChakuniYoteiNyuuryoku.Select();
            }
        }
        private void ChakuniYoteiNyuuryokuSelect(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["MessageID"].ToString() == "E132")
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
                    dt.Columns.Remove("SiiresakiCD");
                    dt.Columns.Remove("ChakuniYoteiDate");
                    dt.Columns.Remove("SiiresakiName");
                    dt.Columns.Remove("StaffCD");
                    dt.Columns.Remove("StaffName");
                    dt.Columns.Remove("SoukoCD");
                    dt.Columns.Remove("SoukoName");
                    dt.Columns.Remove("ChakuniYoteiDenpyouTekiyou");
                    dt.Columns.Remove("MessageID");
                    dt.Columns.Remove("KanriNO");
                    dt.Columns.Remove("HacchuuNo");
                    dt.Columns.Remove("HacchuuGyouNO");
                    gvChakuniYoteiNyuuryoku.DataSource = dt;
                }
            }
        }
        private void txtArrivalNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtChakuniYoteiNO.IsErrorOccurs)
                {
                    if (cboMode.SelectedValue.ToString() == "2" || cboMode.SelectedValue.ToString() == "1")
                    {
                        cf.EnablePanel(PanelDetail);
                        cf.DisablePanel(PanelTitle);
                        txtDate.Focus();
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
                    }
                }
                DataTable dt = txtChakuniYoteiNO.IsDatatableOccurs;
                if (dt.Rows.Count > 0 && cboMode.SelectedValue.ToString() != "1")
                {
                    if (dt.Rows[0]["MessageID"].ToString() == "E132")
                    {
                        ChakuniYoteiNyuuryokuSelect(dt);
                    }
                }
            }
        }

        private void btn_Siiresaki_Click(object sender, EventArgs e)
        {
            sd.ShowDialog();
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
    }
}
