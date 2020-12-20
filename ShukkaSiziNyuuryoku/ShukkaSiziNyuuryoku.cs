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
        ShukkaSiziNyuuryokuEntity sksz_e;
        ShukkasiziNyuuryokuBL sksz_bl;
        BaseBL bbl;
        TokuisakiDetails td = new TokuisakiDetails();
        KouritenDetails kd = new KouritenDetails();
        public string tdDate;
        public string gv1_value;
        DataTable dtgv1,dtTemp1,dtGS1,dtClear;
        public ShukkaSiziNyuuryoku()
        {
            InitializeComponent();
            cf = new CommonFunction();
            multi_Entity = new multipurposeEntity();
            staffBL = new StaffBL();
            sksz_e = new ShukkaSiziNyuuryokuEntity();
            sksz_bl = new ShukkasiziNyuuryokuBL();
            bbl = new BaseBL();
            tdDate = string.Empty;
            dtTemp1 = new DataTable();
            dtgv1 = new DataTable();
            dtGS1 =CreateTable();
            dtClear = CreateTable();
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
            sbTokuisaki.E267Check(true, "M_Tokuisaki", sbTokuisaki, txtShippingDate);
            sbTokuisaki.E227Check(true, "M_Tokuisaki", sbTokuisaki, txtShippingDate);
            //E269
            //小売店
            sbKouriten.E101Check(true, "M_Kouriten", sbKouriten, txtShippingDate, null);
            sbKouriten.E267Check(true, "M_Kouriten", sbKouriten, txtShippingDate);
            sbKouriten.E227Check(true, "M_Kouriten", sbKouriten, txtShippingDate);
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
        private void F11_Clear()
        {
            //txtJuchuuNo.Clear();
            //txtAddress.Clear();
            txtSenpyouhachuuNo.Clear();
            txtYubin1.Clear();
            txtYubin2.Clear();
            txtAddress.Clear();
            txtPhone1.Clear();
            txtPhone2.Clear();
            txtPhone3.Clear();
            txtName.Clear();
        }
        private void DBProcess()
        {
            sksz_e = new ShukkaSiziNyuuryokuEntity();
            if (cboMode.SelectedValue.Equals("1"))
            {
                sksz_e.Mode = "New";
                //DoInsert(chkEntity);
            }
            else if (cboMode.SelectedValue.Equals("2"))
            {
                sksz_e.Mode = "Update";
                //DoUpdate(chkEntity);
            }
            else if (cboMode.SelectedValue.Equals("3"))
            {
                sksz_e.Mode = "Delete";
                //DoDeletet(chkEntity);
            }
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

                    sksz_bl = new ShukkasiziNyuuryokuBL();
                    DataTable dt_gv1 = new DataTable();
                    dt_gv1 = sksz_bl.ShukkasiziNyuuryoku_Data_Select(sbShippingNO.Text, txtShippingDate.Text, 1);
                    if (dt_gv1.Rows.Count > 0)
                        dgvShukkasizi.DataSource = dt_gv1;
                    string KBN = dtDetails.Rows[0]["ShukkaKanryouKBN"].ToString();
                    if (KBN.ToString().Equals("1"))
                    {
                        dgvShukkasizi.Columns["colArrivalTime"].ReadOnly = true;
                        dgvShukkasizi.Columns["chk"].ReadOnly = true;
                    }
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
            dtGridview();
            dgvShukkasizi.DataSource = dtgv1;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            dtTemp1 = dtGS1;//temp add
            F11_Clear();
            txtJuchuuNo.Focus();
            dgvShukkasizi.ClearSelection();
            dgvShukkasizi.DataSource = dtClear;
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {            
            if (dtTemp1.Rows.Count>0)
            {
                var dtConfirm = dtTemp1.AsEnumerable().OrderBy(r => r.Field<string>("SKMSNO")).ThenBy(r => r.Field<string>("ShouhinCD")).CopyToDataTable();
                dgvShukkasizi.DataSource = dtConfirm;
                dgvShukkasizi.Columns["colArrivalTime"].ReadOnly = true;
                dgvShukkasizi.Columns["colTanka"].ReadOnly = true;
                dgvShukkasizi.Columns["colPrice"].ReadOnly = true;
                dgvShukkasizi.Columns["chk"].ReadOnly = true;
               dgvShukkasizi.Columns["colDetails"].ReadOnly = true;
               dgvShukkasizi.Columns["SoukoCD"].ReadOnly = true;
            } 
            else
            {
                dtGS1 = CreateTable();
                dgvShukkasizi.DataSource = dtGS1;
            }
        }       
        private void gv_1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvShukkasizi.CurrentCell.RowIndex>=0)
            {
                dtGridview();
                if (!dgvShukkasizi.Rows[e.RowIndex].Cells["colArrivalTime"].Value.ToString().Equals("0"))
                {
                    if (dgvShukkasizi.Rows[e.RowIndex].Cells["colArrivalTime"].Value.ToString() == dtgv1.Rows[e.RowIndex]["KonkaiShukkaSiziSuu"].ToString() && dgvShukkasizi.Rows[e.RowIndex].Cells["chk"].Value.ToString() == dtgv1.Rows[e.RowIndex]["Kanryo"].ToString() && dgvShukkasizi.Rows[e.RowIndex].Cells["colDetails"].Value.ToString() == dtgv1.Rows[e.RowIndex]["ShukkaSiziMeisaiTekiyou"].ToString())
                    {
                        return;
                    }
                    else
                    {
                        if (dtGS1.Rows.Count > 0)
                        {
                            for (int i = dtGS1.Rows.Count - 1; i >= 0; i--)
                            {
                                string data = dtGS1.Rows[i]["SKMSNO"].ToString();
                                if (dgvShukkasizi.Rows[e.RowIndex].Cells["colJuchuuNo"].Value.ToString() == data)
                                {
                                    dtGS1.Rows[i].Delete();
                                }
                            }
                        }

                        dgvShukkasizi.Rows[e.RowIndex].Cells["colPrice"].Value = Convert.ToInt64(dgvShukkasizi.Rows[e.RowIndex].Cells["colArrivalTime"].Value.ToString()) * Convert.ToInt64(dgvShukkasizi.Rows[e.RowIndex].Cells["colTanka"].Value.ToString());
                        DataRow dr1 = dtGS1.NewRow();
                        for (int i = 0; i < dtGS1.Columns.Count; i++)
                        {
                            dr1[i] = dgvShukkasizi[i, e.RowIndex].Value;
                        }
                        dtGS1.Rows.Add(dr1);
                    }
                }
            }
        }
        private void dgvShukkasizi_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvShukkasizi.Columns[e.ColumnIndex].Name == "colArrivalTime")
            {
                string value = dgvShukkasizi.Rows[e.RowIndex].Cells["colArrivalTime"].EditedFormattedValue.ToString().Replace(",", "");
                if (Convert.ToInt64(value) < 0)
                {
                    bbl.ShowMessage("E109");
                    e.Cancel = true;
                }
                string value1 = dgvShukkasizi.Rows[e.RowIndex].Cells["colShukkakanousuu"].EditedFormattedValue.ToString();
                if (Convert.ToInt64(value) > Convert.ToInt64(value1))
                {
                    bbl.ShowMessage("E143");
                    e.Cancel = true;
                }
                string value2 = dgvShukkasizi.Rows[e.RowIndex].Cells["colJuchuuSuu"].EditedFormattedValue.ToString();
                string value3 = dgvShukkasizi.Rows[e.RowIndex].Cells["colShukkasizisou"].EditedFormattedValue.ToString();
                if (Convert.ToInt64(value) > (Convert.ToInt64(value2) - Convert.ToInt64(value3)))
                {
                    bbl.ShowMessage("E143");
                    e.Cancel = true;
                }

            }
        }
        private void F12_Event()
        {
            if(dtGS1.Rows.Count>0)
            {
                //Insert & Update D_Shukkasizi
                //Insert & Update D_ShukkaSiziMeisai
                // Insert & Update D_ShukkaSiziShousai
            }
            else
            {
                bbl.ShowMessage("E274");
            }
        }
        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ShouhinCD", typeof(string));
            dt.Columns.Add("ShouhinName", typeof(string));
            dt.Columns.Add("ColorRyakuName", typeof(string));
            dt.Columns.Add("ColorNO", typeof(string));
            dt.Columns.Add("SizeNO", typeof(string));
            dt.Columns.Add("JuchuuSuu", typeof(string));
            dt.Columns.Add("ShukkanouSuu", typeof(string));
            dt.Columns.Add("ShukkaSiziZumiSuu", typeof(string));
            dt.Columns.Add("KonkaiShukkaSiziSuu", typeof(string));
            dt.Columns.Add("UriageTanka", typeof(string));
            dt.Columns.Add("UriageKingaku", typeof(string));
            dt.Columns.Add("Kanryo", typeof(int));
            dt.Columns.Add("ShukkaSiziMeisaiTekiyou", typeof(string));
            dt.Columns.Add("SKMSNO", typeof(string));
            dt.Columns.Add("SoukoCD", typeof(string));
            dt.Columns.Add("SoukoName", typeof(string));
            dt.Columns.Add("TokuisakiCD", typeof(string));
            dt.Columns.Add("KouritenCD", typeof(string));
            dt.Columns.Add("KouritenRyakuName", typeof(string));
            dt.Columns.Add("KouritenName", typeof(string));
            dt.Columns.Add("KouritenYuubinNO1", typeof(string));
            dt.Columns.Add("KouritenYuubinNO2", typeof(string));
            dt.Columns.Add("KouritenJuusho1", typeof(string));
            dt.Columns.Add("KouritenJuusho2", typeof(string));
            dt.Columns.Add("KouritenTelNO1-1", typeof(string));
            dt.Columns.Add("KouritenTelNO1-2", typeof(string));
            dt.Columns.Add("KouritenTelNO1-3", typeof(string));
            dt.Columns.Add("KouritenTelNO2-1", typeof(string));
            dt.Columns.Add("KouritenTelNO2-2", typeof(string));
            dt.Columns.Add("KouritenTelNO2-3", typeof(string));

            dt.AcceptChanges();
            return dt;
        }
        private DataTable dtGridview()
        {
            sksz_e = GetShukkasiziEntity();

            sksz_bl = new ShukkasiziNyuuryokuBL();
            dtgv1 = sksz_bl.ShukkasiziNyuuryoku_Display(sksz_e);

            return dtgv1;
        }
        private ShukkaSiziNyuuryokuEntity GetShukkasiziEntity()
        {
            sksz_e = new ShukkaSiziNyuuryokuEntity()
            {
                ShippingDate = txtShippingDate.Text,
                TokuisakiCD = sbTokuisaki.Text,
                JuchuuNO = txtJuchuuNo.Text,
                SenpyouhachuuNo = txtSenpyouhachuuNo.Text,
                TokuisakiYuubinNO1 = txtYubin1.Text,
                TokuisakiYuubinNO2 = txtYubin2.Text,
                KouritenYuubinNO1 = txtYubin1.Text,
                KouritenYuubinNO2 = txtYubin2.Text,
                TokuisakiTelNO1_1 = txtPhone1.Text,
                TokuisakiTelNO1_2 = txtPhone2.Text,
                TokuisakiTelNO1_3 = txtPhone3.Text,
                KouritenTelNO1_1 = txtPhone1.Text,
                KouritenTelNO1_2 = txtPhone2.Text,
                KouritenTelNO1_3 = txtPhone3.Text,
                TokuisakiRyakuName = txtName.Text,
                KouritenRyakuName = txtName.Text,
                TokuisakiName = txtName.Text,
                KouritenName = txtName.Text,
                TokuisakiJuusho1 = txtAddress.Text,
                TokuisakiJuusho2 = txtAddress.Text,
                KouritenJuusho1 = txtAddress.Text,
                KouritenJuusho2 = txtAddress.Text,
                OperatorCD = OperatorCD,
                ProgramID = ProgramID,
                PC = PCID
            };

            return sksz_e;
        }
    }
}
