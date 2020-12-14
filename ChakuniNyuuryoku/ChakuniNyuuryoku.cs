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
        public ChakuniNyuuryoku()
        {
            InitializeComponent();
            cf = new CommonFunction();
            bbl = new BaseBL();
            cbl = new chakuniNyuuryoku_BL();
            dtmain = new DataTable();
            dtTemp = new DataTable();
        }

        private void ChakuniNyuuryoku_Load(object sender, EventArgs e)
        {
            ProgramID = "ChakuniNyuuryoku";
            StartProgram();
            cboMode.Bind(false, multi_Entity);
            txtSiiresaki.lblName = lblSiiresaki;
            txtStaffCD.lblName = lblStaff;
            sbWareHouse.lblName = lblWareHouse;
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
            SetButton(ButtonType.BType.Search, F11, "保存(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            lblSiiresaki.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblStaff.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblWareHouse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            ChangeMode(Mode.New);
            txtArrivalNO.Focus();
            multipurposeEntity multipurpose_entity = new multipurposeEntity();
            txtSiiresaki.ChangeDate = txtArrivalDate;
            txtSiiresaki.lblName = lblSiiresaki;
            txtStaffCD.ChangeDate = txtArrivalDate;
        }
        private void ChangeMode(Mode mode)
        {
            switch (mode)
            {
                case Mode.New:
                    ErrorCheck();
                    cf.Clear(PanelTitle);
                    cf.Clear(panelDetails);
                    cf.EnablePanel(PanelTitle);
                    cf.EnablePanel(panelDetails);
                    txtArrivalDate.Text= DateTime.Now.ToString("yyyy/MM/dd");
                    txtArrivalNO.Focus();
                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    F9.Visible = false;
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
            Clear();
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
        }
        private void DBProcess()
        {
            ChakuniNyuuryoku_Entity chkEntity = getData();
            if (cboMode.SelectedValue.Equals("1"))
            {
                chkEntity.Mode = "New";
                DoInsert(chkEntity);
            }
            else if (cboMode.SelectedValue.Equals("2"))
            {
                chkEntity.Mode = "Update";
                DoUpdate(chkEntity);
            }
            else if (cboMode.SelectedValue.Equals("3"))
            {
                chkEntity.Mode = "Delete";
                DoDeletet(chkEntity);
            }
        }
        private ChakuniNyuuryoku_Entity getData()
        {
            ChakuniNyuuryoku_Entity chk = new ChakuniNyuuryoku_Entity();
            
            return chk;
        }
        private void DoInsert(ChakuniNyuuryoku_Entity insert)
        {
            chakuniNyuuryoku_BL bl = new chakuniNyuuryoku_BL();
        }
        private void DoUpdate(ChakuniNyuuryoku_Entity update)
        {
            chakuniNyuuryoku_BL bl = new chakuniNyuuryoku_BL();
        }
        private void DoDeletet(ChakuniNyuuryoku_Entity delete)
        {
            chakuniNyuuryoku_BL bl = new chakuniNyuuryoku_BL();
        }
        private void GetData()
        {
            string Xml = string.Empty;
            ChakuniNyuuryoku_Entity chkEntity = new ChakuniNyuuryoku_Entity();
            chkEntity.ChakuniNO = txtArrivalNO.Text;
            chkEntity.ChakuniDate = txtArrivalDate.Text;
            chkEntity.ChakuniYoteiNO = txtScheduledNo.Text;
            chkEntity.ShouhinCD = txtShouhinCD.Text;
            chkEntity.ShouhinName = txtShouhinName.Text;
            chkEntity.JANCD = txtJANCD.Text;
            chkEntity.BrandCD = sbBrand.Text;
            chkEntity.ColorNO = txtColor.Text;
            chkEntity.SizeNO = txtSize.Text;
            chkEntity.KanriNO = txtControlNo.Text;
            chkEntity.SoukoCD = sbWareHouse.Text;
            chkEntity.YearTerm = txtYearTerm.Text;
            //chkEntity.CheckValue = CheckValue();
            chkEntity.SeasonSS = chkSS.Checked ? "1" : "0";
            chkEntity.SeasonFW = chkFW.Checked ? "1" : "0";
            dtmain  = cbl.ChakuniNyuuryoku_Display(chkEntity,Xml);
            
            DataTable dtcha = new DataTable();
            dtcha = dtmain.Copy();
            dtcha.Columns.Remove("JANCD");
            dtcha.Columns.Remove("a");
            dtcha.Columns.Remove("b");
            gvChakuniNyuuryoku.DataSource = dtcha;
            DataTable dtcopy = new DataTable();
            dtcopy = dtmain.Copy();
            dtcopy.Columns.Remove("ShouhinCD");
            dtcopy.Columns.Remove("ShouhinName");
            dtcopy.Columns.Remove("ColorRyakuName");
            dtcopy.Columns.Remove("ColorNO");
            dtcopy.Columns.Remove("SizeNO");
            dtcopy.Columns.Remove("ChakuniYoteiDate");
            dtcopy.Columns.Remove("ChakuniYoteiSuu");
            dtcopy.Columns.Remove("ChakuniZumiSuu");
            dtcopy.Columns.Remove("ChakuniSuu");
            dtcopy.Columns.Remove("d");
            gvJancd.DataSource = dtcopy;
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
            sbWareHouse.E102Check(true);
            sbWareHouse.E101Check(true, "souko", sbWareHouse, null, null);
            txtScheduledNo.E133Check(true, "M_Siiresaki", txtScheduledNo, txtArrivalDate, null);
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
                    sbWareHouse.Text = dt.Rows[0]["SoukoCD"].ToString();
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
                    dtmain = dt.Copy();
                    if (dtmain.Columns.Contains("SiiresakiCD"))
                    {
                        dtmain.Columns.Remove("SiiresakiCD");
                        dtmain.Columns.Remove("ChakuniDate");
                        dtmain.Columns.Remove("SiiresakiName");
                        dtmain.Columns.Remove("StaffCD");
                        dtmain.Columns.Remove("SoukoCD");
                        dtmain.Columns.Remove("ChakuniDenpyouTekiyou");
                        dtmain.Columns.Remove("MessageID");
                        dtmain.Columns.Remove("StaffName");
                        dtmain.Columns.Remove("SoukoName");
                        dtmain.Columns.Remove("ChakuniYoteiNO");
                        dtmain.Columns.Remove("ChakuniSuu");
                        dtmain.Columns.Remove("JANCD");
                        dtmain.Columns.Remove("a");
                        dtmain.Columns.Remove("b");
                        dtmain.Columns.Remove("ChakuniMeisaiTekiyou");
                        gvChakuniNyuuryoku.DataSource = dtmain;
                    }
                    DataTable dtcopy = new DataTable();
                    dtcopy = dt.Copy();
                    if (dtcopy.Columns.Contains("JANCD"))
                    {
                        dtcopy.Columns.Remove("ShouhinCD");
                        dtcopy.Columns.Remove("ShouhinName");
                        dtcopy.Columns.Remove("SiiresakiCD");
                        dtcopy.Columns.Remove("ChakuniDate");
                        dtcopy.Columns.Remove("SiiresakiName");
                        dtcopy.Columns.Remove("StaffCD");
                        dtcopy.Columns.Remove("SoukoCD");
                        dtcopy.Columns.Remove("ChakuniDenpyouTekiyou");
                        dtcopy.Columns.Remove("MessageID");
                        dtcopy.Columns.Remove("StaffName");
                        dtcopy.Columns.Remove("SoukoName");
                        dtcopy.Columns.Remove("ChakuniYoteiNO");
                        dtcopy.Columns.Remove("ChakuniSuu");
                        dtcopy.Columns.Remove("ColorRyakuName");
                        dtcopy.Columns.Remove("ColorNO");
                        dtcopy.Columns.Remove("SizeNO");
                        dtcopy.Columns.Remove("ChakuniYoteiSuu");
                        dtcopy.Columns.Remove("ChakuniZumiSuu");
                        dtcopy.Columns.Remove("ChakuniMeisaiTekiyou");
                        dtcopy.Columns.Remove("ChakuniYoteiDate");
                        gvJancd.DataSource = dtcopy;
                    }
                }
            }
        }
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtScheduledNo.Text) && string.IsNullOrWhiteSpace(txtShouhinCD.Text) && string.IsNullOrWhiteSpace(txtShouhinName.Text) && string.IsNullOrWhiteSpace(txtControlNo.Text) &&
                 string.IsNullOrWhiteSpace(txtJANCD.Text) && string.IsNullOrWhiteSpace(sbBrand.Text) && string.IsNullOrWhiteSpace(txtColor.Text)&& (!chkFW.Checked) && (!chkSS.Checked) && string.IsNullOrWhiteSpace(txtSize.Text))
            {
                GetData();
            }
            else
            {
                bbl.ShowMessage("E111");
                txtScheduledNo.Focus();
            }
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
            GetData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dtGridSource = (DataTable)gvChakuniNyuuryoku.DataSource;
            savedata();
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
        }
        private DataTable savedata()
        {

            //if(dtGridSource.Rows.Count>0)
            //{
            //    gvChakuniNyuuryoku.DataSource = dtGridSource;
            //    gvJancd.DataSource = dtGridSource;
            //}
            return dtGridSource;
        }
        
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DataTable dtsave = new DataTable();
            dtsave = savedata();
            gvChakuniNyuuryoku.DataSource = dtsave;
            DataTable dtcopy = new DataTable();
            dtcopy = dtmain.Copy();
            dtcopy.Columns.Remove("ShouhinCD");
            dtcopy.Columns.Remove("ShouhinName");
            dtcopy.Columns.Remove("ColorRyakuName");
            dtcopy.Columns.Remove("ColorNO");
            dtcopy.Columns.Remove("SizeNO");
            dtcopy.Columns.Remove("ChakuniYoteiDate");
            dtcopy.Columns.Remove("ChakuniYoteiSuu");
            dtcopy.Columns.Remove("ChakuniZumiSuu");
            dtcopy.Columns.Remove("ChakuniSuu");
            dtcopy.Columns.Remove("d");
            gvJancd.DataSource = dtcopy;
        }
        private void gvChakuniNyuuryoku_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (gvChakuniNyuuryoku.Columns[e.ColumnIndex].Name == "colArrivalTime")
            {
               string value =gvChakuniNyuuryoku.Rows[e.RowIndex].Cells["colArrivalTime"].EditedFormattedValue.ToString();
                if (Convert.ToDecimal(value)<0)
                {
                    bbl.ShowMessage("E109");
                    e.Cancel = true;
                }
            }
        }

        private void txtArrivalNO_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtArrivalNO.IsErrorOccurs)
                {
                    if (cboMode.SelectedValue.ToString() == "2")
                    {
                        cf.EnablePanel(panelDetails);
                        cf.DisablePanel(PanelTitle);
                        txtArrivalDate.Focus();
                    }
                }
                DataTable dt = txtArrivalNO.IsDatatableOccurs;
                if (dt.Rows.Count > 0 && cboMode.SelectedValue.ToString() != "1")
                {
                   string kbn = dt.Rows[0]["SiireKanryouKBN"].ToString();
                   if (Convert.ToDecimal(kbn)== 1)
                   {
                      ChakuniNyuuryokuSelect(dt);
                      gvChakuniNyuuryoku.Columns["colArrivalTime"].ReadOnly = true;
                   }
                }
            }
        }

        private void btn_Siiresaki_Click(object sender, EventArgs e)
        {
            sd.ShowDialog();
        }
    }
}
