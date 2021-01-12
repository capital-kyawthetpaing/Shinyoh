using System;
using Shinyoh;
using Entity;
using BL;
using CKM_CommonFunction;
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
        DataTable dtmain;
        ChakuniYoteiNyuuryokuEntity chkEntity;
        ChakuniYoteiNyuuryoku_BL cbl;
        public string tdDate;
        public ChakuniYoteiNyuuryoku()
        {
            InitializeComponent();
            base_Entity = new BaseEntity();
            staffBL = new StaffBL();
            soukoBL = new SoukoBL();
            bbl = new BaseBL();
            dtmain = new DataTable();
            chkEntity = new ChakuniYoteiNyuuryokuEntity();
            cbl = new ChakuniYoteiNyuuryoku_BL();
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
            txtArrivalNO.Focus();
            base_Entity = _GetBaseData();
            txtArrivalNO.ChangeDate = txtDate;
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
                    txtArrivalNO.E102Check(true);
                    txtArrivalNO.E133Check(true, "ChakuniNyuuryoku", txtArrivalNO, null, null);
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
            txtArrivalNO.Focus();
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
                ChakuniYoteiNO = txtArrivalNO.Text,
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
    }
}
