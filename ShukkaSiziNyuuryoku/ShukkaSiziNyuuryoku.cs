using System;
using Shinyoh;
using Entity;
using BL;
using CKM_CommonFunction;
using System.Windows.Forms;
using Shinyoh_Controls;
using Shinyoh_Search;
using System.Data;

namespace ShukkaSiziNyuuryoku
{
    public partial class ShukkaSiziNyuuryoku : BaseForm
    {
        CommonFunction cf;
        multipurposeEntity multi_Entity;
        StaffBL staffBL;
        ShukkasiziNyuuryokuBL sksz_bl;
        BaseBL bbl;
        TokuisakiDetails td = new TokuisakiDetails();
        KouritenDetails kd = new KouritenDetails();
        public string tdDate;
        DataTable dtgv1,dtgv2;
        DataTable dtTemp;
        public ShukkaSiziNyuuryoku()
        {
            InitializeComponent();
            cf = new CommonFunction();
            multi_Entity = new multipurposeEntity();
            staffBL = new StaffBL();
            sksz_bl = new ShukkasiziNyuuryokuBL();
            bbl = new BaseBL();
            tdDate = string.Empty;
            dtgv1 = new DataTable();
            dtgv2 = new DataTable();
            dtTemp = new DataTable();
        }

        private void ShukkaSiziNyuuryoku_Load(object sender, EventArgs e)
        {
            ProgramID = "ShukkaSiziNyuuryoku";
            StartProgram();
            cboMode.Bind(false, multi_Entity);
            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "新規(F2)", true);
            SetButton(ButtonType.BType.Update, F3, "変更(F3)", true);
            SetButton(ButtonType.BType.Delete, F4, "削除(F4)", true);
            SetButton(ButtonType.BType.Inquiry, F5, "照会(F5)", true);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", false);
            SetButton(ButtonType.BType.Display, F10, "表示(F10)", true);
            SetButton(ButtonType.BType.Search, F11, "保存(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            lblTokuisakiName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblKouritenName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblStaffName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            ChangeMode(Mode.New);
            sbShippingNO.Focus();
            multipurposeEntity multipurpose_entity = new multipurposeEntity();
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
                    sbShippingNO.Focus();                    
                    New_Mode();
                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    break;
                case Mode.Update:
                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;
                    break;
                case Mode.Inquiry:
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
                //if (ErrorCheck(PanelTitle) && ErrorCheck(panelDetails))
                //{
                //    DBProcess();
                //    switch (cboMode.SelectedValue)
                //    {
                //        case "1":
                //            ChangeMode(Mode.New);
                //            break;
                //        case "2":
                //            ChangeMode(Mode.Update);
                //            break;
                //        case "3":
                //            ChangeMode(Mode.Delete);
                //            break;
                //        case "4":
                //            ChangeMode(Mode.Inquiry);
                //            break;
                //    }
                //}
            }
                    
            base.FunctionProcess(tagID);
        }
        private void ErrorCheck()
        {
            sbShippingNO.E102Check(true);
            sbShippingNO.E133Check(true, "ShukkaSiziNyuuryoku", sbShippingNO, null, null);
            sbShippingNO.E115Check(true, "ShukkaSiziNyuuryoku", sbShippingNO);
            sbShippingNO.E160Check(true, "ShukkaSiziNyuuryoku", sbShippingNO,null);
            //出荷予定日
            txtShippingDate.E102Check(true);
            txtShippingDate.E103Check(true);
            //txtShippingDate.E267Check(true, "M_Tokuisaki", null, txtShippingDate);
            //txtShippingDate.E227Check(true, "M_Tokuisaki", null, txtShippingDate);
            //得意先
            sbTokuisaki.E102Check(true);
            sbTokuisaki.E101Check(true, "M_Tokuisaki", sbTokuisaki, txtShippingDate, null);
            //sbTokuisaki.E267Check(true, "M_Tokuisaki", null, txtShippingDate);
            //sbTokuisaki.E227Check(true, "M_Tokuisaki", null, txtShippingDate);
            //E269
            //小売店
            sbKouriten.E101Check(true, "M_Kouriten", sbKouriten, txtShippingDate, null);
            //sbKouriten.E267Check(true, "M_Kouriten", null, txtShippingDate);
            //sbKouriten.E227Check(true, "M_Kouriten", null, txtShippingDate);
            //担当スタッフCD
            sbStaffCD.E102Check(true);
            sbStaffCD.E101Check(true, "M_Staff", sbStaffCD, txtShippingDate, null);
            sbStaffCD.E135Check(true, "M_Staff", sbStaffCD, txtShippingDate);
            //伝票日付
            txtSlipDate.E102Check(true);
            txtSlipDate.E103Check(true);
            //受注番号(searchshi)
            txtJuchuuNo.E133Check(true, "JuchuuNyuuryoku", txtJuchuuNo, null, null);
        }
        private void New_Mode()
        {
            tdDate = DateTime.Now.ToString("yyyy/MM/dd");
            txtShippingDate.Text = tdDate;
            txtSlipDate.Text = tdDate;

            StaffEntity staffEntity = new StaffEntity
            {
                StaffCD = OperatorCD
            };
            staffEntity = staffBL.GetStaffEntity(staffEntity);
            sbStaffCD.Text = OperatorCD;
            lblStaffName.Text = staffEntity.StaffName;
        }
        private void Clear()
        {
            
        }                      
        private void ShukkasiziNyuuryoku_Header_Select(DataTable dt)
        {
            if (dt.Rows[0]["ShukkaKanryouKBN"].ToString() == "1") { }
            //Header            
            sbTokuisaki.Text = dt.Rows[0]["TokuisakiCD"].ToString();
            lblTokuisakiName.Text = dt.Rows[0]["TokuisakiRyakuName"].ToString();
            sbKouriten.Text = dt.Rows[0]["KouritenCD"].ToString();
            lblKouritenName.Text = dt.Rows[0]["KouritenRyakuName"].ToString();
            sbStaffCD.Text = dt.Rows[0]["StaffCD"].ToString();
            lblStaffName.Text = dt.Rows[0]["StaffName"].ToString();

            txtSlipDate.Text = dt.Rows[0]["DenpyouDate"].ToString();
            txtSlip_Description.Text = dt.Rows[0]["ShukkaSiziDenpyouTekiyou"].ToString();
            if (dt.Rows[0]["ShukkaSizishoHuyouKBN"].ToString() == "0")
                rdoNeed.Checked = true;
            else
                rdoNO.Checked = true;

            //Access_Tokuisaki_obj
            td.Access_Tokuisaki_obj.TokuisakiCD = dt.Rows[0]["TokuisakiCD"].ToString();
            td.Access_Tokuisaki_obj.TokuisakiRyakuName = dt.Rows[0]["TokuisakiRyakuName"].ToString();
            td.Access_Tokuisaki_obj.TokuisakiName = dt.Rows[0]["TokuisakiName"].ToString();
            td.Access_Tokuisaki_obj.YuubinNO1 = dt.Rows[0]["TokuisakiYuubinNO1"].ToString();
            td.Access_Tokuisaki_obj.YuubinNO2 = dt.Rows[0]["TokuisakiYuubinNO2"].ToString();
            td.Access_Tokuisaki_obj.Juusho1 = dt.Rows[0]["TokuisakiJuusho1"].ToString();
            td.Access_Tokuisaki_obj.Juusho2 = dt.Rows[0]["TokuisakiJuusho2"].ToString();
            td.Access_Tokuisaki_obj.Tel11 = dt.Rows[0]["TokuisakiTelNO1-1"].ToString();
            td.Access_Tokuisaki_obj.Tel12 = dt.Rows[0]["TokuisakiTelNO1-2"].ToString();
            td.Access_Tokuisaki_obj.Tel13 = dt.Rows[0]["TokuisakiTelNO1-3"].ToString();
            td.Access_Tokuisaki_obj.Tel21 = dt.Rows[0]["TokuisakiTelNO2-1"].ToString();
            td.Access_Tokuisaki_obj.Tel22 = dt.Rows[0]["TokuisakiTelNO2-2"].ToString();
            td.Access_Tokuisaki_obj.Tel23 = dt.Rows[0]["TokuisakiTelNO2-3"].ToString();

            //Access_Kouriten_obj
            kd.Access_Kouriten_obj.KouritenCD = dt.Rows[0]["KouritenCD"].ToString();
            kd.Access_Kouriten_obj.KouritenRyakuName = dt.Rows[0]["KouritenRyakuName"].ToString();
            kd.Access_Kouriten_obj.KouritenName = dt.Rows[0]["KouritenRyakuName"].ToString();
            kd.Access_Kouriten_obj.YuubinNO1 = dt.Rows[0]["KouritenYuubinNO1"].ToString();
            kd.Access_Kouriten_obj.YuubinNO2 = dt.Rows[0]["KouritenYuubinNO2"].ToString();
            kd.Access_Kouriten_obj.Juusho1 = dt.Rows[0]["KouritenJuusho1"].ToString();
            kd.Access_Kouriten_obj.Juusho2 = dt.Rows[0]["KouritenJuusho2"].ToString();
            kd.Access_Kouriten_obj.Tel11 = dt.Rows[0]["KouritenTelNO1-1"].ToString();
            kd.Access_Kouriten_obj.Tel12 = dt.Rows[0]["KouritenTelNO1-2"].ToString();
            kd.Access_Kouriten_obj.Tel13 = dt.Rows[0]["KouritenTelNO1-3"].ToString();
            kd.Access_Kouriten_obj.Tel21 = dt.Rows[0]["KouritenTelNO2-1"].ToString();
            kd.Access_Kouriten_obj.Tel22 = dt.Rows[0]["KouritenTelNO2-2"].ToString();
            kd.Access_Kouriten_obj.Tel23 = dt.Rows[0]["KouritenTelNO2-3"].ToString();
        }
        private void gvChakuniNyuuryoku_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (gvChakuniNyuuryoku.Columns[e.ColumnIndex].Name == "colArrivalTime")
            {
                string value = gvChakuniNyuuryoku.Rows[e.RowIndex].Cells["colArrivalTime"].EditedFormattedValue.ToString();
                if (Convert.ToDecimal(value) < 0)
                {
                    bbl.ShowMessage("E109");
                    e.Cancel = true;
                }
            }
        }
        private void sbStaffCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = sbStaffCD.IsDatatableOccurs;

                if (dt.Rows.Count > 0)
                {
                    lblStaffName.Text = dt.Rows[0]["StaffName"].ToString();
                }
                else
                {
                    bbl.ShowMessage("E135");
                    lblStaffName.Focus();
                }
            }
        }
        private void sbShippingNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!sbShippingNO.IsErrorOccurs)
                {
                    if (cboMode.SelectedValue.ToString() == "2")
                    {
                        cf.EnablePanel(panelDetails);
                        cf.DisablePanel(PanelTitle);
                        sbShippingNO.Focus();
                    }
                }
                sksz_bl = new ShukkasiziNyuuryokuBL();
                DataTable dt_Header = new DataTable();
                dt_Header = sksz_bl.ShukkasiziNyuuryoku_Data_Select(sbShippingNO.Text, txtShippingDate.Text, 3);
                if (dt_Header.Rows.Count > 0)
                    ShukkasiziNyuuryoku_Header_Select(dt_Header);

                if (cboMode.SelectedValue.ToString() != "1")
                {
                    sksz_bl = new ShukkasiziNyuuryokuBL();
                    DataTable dtDetails = new DataTable();
                    dtDetails = sksz_bl.ShukkasiziNyuuryoku_Data_Select(sbShippingNO.Text, txtShippingDate.Text, 2);
                    if (dtDetails.Rows.Count > 0)
                        gvDetail.DataSource = dtDetails;

                    sksz_bl = new ShukkasiziNyuuryokuBL();
                    DataTable dt_gv1 = new DataTable();
                    dt_gv1 = sksz_bl.ShukkasiziNyuuryoku_Data_Select(sbShippingNO.Text, txtShippingDate.Text, 1);
                    if (dt_gv1.Rows.Count > 0)
                        gvChakuniNyuuryoku.DataSource = dt_gv1;
                }
            }
        }
        private void sbTokuisaki_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!sbTokuisaki.IsErrorOccurs)
                {
                    DataTable dt = sbTokuisaki.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                    {
                        lblTokuisakiName.Text = dt.Rows[0]["TokuisakiRyakuName"].ToString();
                    }
                    else
                    {
                        lblTokuisakiName.Text = string.Empty;
                    }
                }
            }
        }
        private void sbKouriten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!sbKouriten.IsErrorOccurs)
                {
                    DataTable dt = sbKouriten.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                    {
                        lblKouritenName.Text = dt.Rows[0]["KouritenRyakuName"].ToString();
                    }
                    //no count case
                    else
                    {
                        lblKouritenName.Text = string.Empty;
                    }
                }
            }
        }
        private void btn_Tokuisaki_Click(object sender, EventArgs e)
        {
            td.ShowDialog();
        }
        private void btnKouriren_Detail_Click(object sender, EventArgs e)
        {
            kd.ShowDialog();
        }
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            ShukkaSiziNyuuryokuEntity sksz_e = new ShukkaSiziNyuuryokuEntity();
            sksz_e.TokuisakiCD = sbTokuisaki.Text;
            sksz_e.JuchuuNO = txtJuchuuNo.Text;
            sksz_e.SenpyouhachuuNo = txtSenpyouhachuuNo.Text;
            sksz_bl = new ShukkasiziNyuuryokuBL();            
            dtgv1= sksz_bl.ShukkasiziNyuuryoku_Display(sksz_e, 1);
            gvChakuniNyuuryoku.DataSource = dtgv1;
            dtgv2 = sksz_bl.ShukkasiziNyuuryoku_Display(sksz_e, 2);
            gvDetail.DataSource = dtgv2;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
