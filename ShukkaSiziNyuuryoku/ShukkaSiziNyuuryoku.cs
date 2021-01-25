using System;
using Shinyoh;
using Entity;
using BL;
using Shinyoh_Details;
using CKM_CommonFunction;
using System.Windows.Forms;
using Shinyoh_Controls;
using Shinyoh_Search;
using System.Data;
using System.Linq;

namespace ShukkaSiziNyuuryoku
{
    public partial class ShukkaSiziNyuuryoku : BaseForm
    {
        CommonFunction cf;
        multipurposeEntity multi_Entity;
        StaffBL staffBL;
        ShukkaSiziNyuuryokuEntity sksz_e;
        ShukkasiziNyuuryokuBL sksz_bl;
        BaseEntity be;
        BaseBL bbl;
        TokuisakiDetail td;
        KouritenDetail kd;
        public string tdDate, Detail_XML;
        DataTable dtgv1, dtTemp1, dtGS1, dtClear, dt_Header,dtResult, dtHaita;
        public ShukkaSiziNyuuryoku()
        {
            InitializeComponent();
            cf = new CommonFunction();
            multi_Entity = new multipurposeEntity();
            staffBL = new StaffBL();
            be = new BaseEntity();
            sksz_e = new ShukkaSiziNyuuryokuEntity();
            sksz_bl = new ShukkasiziNyuuryokuBL();
            bbl = new BaseBL();
            tdDate = string.Empty;
            dtTemp1 = new DataTable();
            dtgv1 = new DataTable();
            dt_Header = new DataTable();
            dtResult = new DataTable();
            dtHaita = new DataTable();
            dtGS1 = CreateTable_Details();
            dtClear = CreateTable_Details();
            dgvShukkasizi.CellEndEdit += DgvShukkasizi_CellEndEdit;
            dgvShukkasizi.CellContentClick += DgvShukkasizi_CellContentClick;
            sbShippingNO.ChangeDate = txtShippingDate;
            dgvShukkasizi.SetGridDesign();
            dgvShukkasizi.SetHiraganaColumn("colDetails");
            dgvShukkasizi.SetReadOnlyColumn("colShouhinCD,colShouhinName,colColorRyakuName,colColorNO,colSizeNO,colJuchuuSuu,colShukkakanousuu,colShukkasizisou,colJuchuuNo,SoukoName");
            td = new TokuisakiDetail();
            kd = new KouritenDetail();
        }
        private void ShukkaSiziNyuuryoku_Load(object sender, EventArgs e)
        {
            ProgramID = "ShukkaSiziNyuuryoku";
            StartProgram();
            cboMode.Bind(false, multi_Entity);
            ModeType(4);
            ChangeMode(Mode.New);
            be = _GetBaseData();
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
                if(cboMode.SelectedValue.ToString().Equals("1"))
                {
                    ModeType(1);
                }
                else
                {
                    ModeType(2);
                }
                ModeType(3);
                dtResult.Clear();
                dtTemp1.Clear();
            }
            if(tagID=="8")
            {
                FunctionProcedure(8);
            }
            if (tagID == "10")
            {
                
                FunctionProcedure(10);
            }
            if(tagID=="11")
            {
                FunctionProcedure(11);
            }
            if (tagID == "12")
            {
                if (ErrorCheck(PanelTitle) && ErrorCheck(PanelDetail)&& Temp_Null())
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
        private void ChangeMode(Mode mode)
        {
            ModeType(3);
            switch (mode)
            {               
                case Mode.New:
                    ModeType(1);
                    Form_ErrorCheck();
                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    F9.Visible = false;
                    break;
                case Mode.Update:
                    ModeType(2);
                    Form_ErrorCheck();
                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    ModeType(2);
                    Form_ErrorCheck();
                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;
                    break;
                case Mode.Inquiry:
                    ModeType(2);
                    Form_ErrorCheck();
                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;
                    break;
            }
        }
        private void btn_Tokuisaki_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(sbTokuisaki.Text) && td.Access_Tokuisaki_obj.TokuisakiCD != null)
            {
                if (!td.Access_Tokuisaki_obj.TokuisakiCD.ToString().Equals(sbTokuisaki.Text))
                {

                    bbl.ShowMessage("E269");
                    sbTokuisaki.Focus();
                }
                else
                {
                    td.ShowDialog();
                }
            }
            else
            {
                sbTokuisaki.Focus();
            }
        }
        private void btnKouriren_Detail_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(sbKouriten.Text) && kd.Access_Kouriten_obj.KouritenCD!=null)
            {
                if (!kd.Access_Kouriten_obj.KouritenCD.ToString().Equals(sbKouriten.Text))
                {
                    bbl.ShowMessage("E269");
                    sbKouriten.Focus(); 
                }
                else
                {
                    kd.ShowDialog();
                }
            } 
            else
            {
                sbKouriten.Focus();
            }
        }
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            FunctionProcedure(10);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            FunctionProcedure(11);
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            FunctionProcedure(8);
        }
        private void DgvShukkasizi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 11)
            {
                if (Convert.ToBoolean(dgvShukkasizi.Rows[e.RowIndex].Cells["chk"].EditedFormattedValue))
                {
                    Temp_Save(e.RowIndex);
                    dgvShukkasizi.MoveNextCell();
                }
            }
        }
        private void dgvShukkasizi_Paint(object sender, PaintEventArgs e)
        {
            var col = dgvShukkasizi.Columns;
            for (int i = 5; i < col.Count; i++)
            {
                while (i <= 10)
                {
                    col[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //dgvShukkasizi.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    ++i;
                }
                if (i == 11)
                {
                    col[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    return;
                }
            }
        }
        private void DgvShukkasizi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Grid_ErrorCheck(e.RowIndex, e.ColumnIndex))
            {
                if(cboMode.SelectedValue.ToString().Equals("2"))
                {
                    dtResult.Clear();
                    dtTemp1.Clear();
                }
                Temp_Save(e.RowIndex);
            }
        }
        //DataTable
        private void ShukkasiziNyuuryoku_Header_Select(DataTable dt)
        {
            //Header 
            txtShippingDate.Text= dt.Rows[0]["ShukkaYoteiDate"].ToString();
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

            td.Access_Tokuisaki_obj = Tokuisaki_Data_Select(dt);
            kd.Access_Kouriten_obj = Kouriten_Data_Select(dt);

        }
        private void Temp_Save(int row)
        {  
            //price change case
            if (dgvShukkasizi.CurrentCell == dgvShukkasizi.Rows[row].Cells["colTanka"] || dgvShukkasizi.CurrentCell == dgvShukkasizi.Rows[row].Cells["colArrivalTime"])
            {
                dgvShukkasizi.Rows[row].Cells["colPrice"].Value = Convert.ToInt32(dgvShukkasizi.Rows[row].Cells["colArrivalTime"].EditedFormattedValue.ToString()) * Convert.ToInt32(dgvShukkasizi.Rows[row].Cells["colTanka"].EditedFormattedValue.ToString());
                dgvShukkasizi.MoveNextCell();
            }

            //souko bind case//倉庫検索
            if (dgvShukkasizi.CurrentCell == dgvShukkasizi.Rows[row].Cells["SoukoCD"])
            {
                int rows = dgvShukkasizi.CurrentCell.RowIndex;
                int col = dgvShukkasizi.CurrentCell.ColumnIndex;
                SoukoSearch ss = new SoukoSearch();
                ss.ShowDialog();
                //pyin yan 
                if(!string.IsNullOrEmpty(ss.soukoCD))
                {
                    dgvShukkasizi["SoukoCD", rows].Value = ss.soukoCD.ToString();
                    dgvShukkasizi["SoukoName", rows].Value = ss.soukoName.ToString();
                }                
                dgvShukkasizi.MoveNextCell();               
            }

            //ShukkaSiziMeisaiTekiyou
            if (dgvShukkasizi.CurrentCell == dgvShukkasizi.Rows[row].Cells["colDetails"])
            {
                dgvShukkasizi.MoveNextCell();
            }

            //data temp save
            if ((!dgvShukkasizi.Rows[row].Cells["colArrivalTime"].EditedFormattedValue.ToString().Equals("0")))
            {
                dtGridview(2);
                if (dtgv1.Rows.Count == 0)
                {
                    dtGridview(1);
                }
                if (dtGS1.Rows.Count > 0)
                {
                    for (int i = dtGS1.Rows.Count - 1; i >= 0; i--)
                    {
                        string data = dtGS1.Rows[i]["SKMSNO"].ToString();
                        if (dgvShukkasizi.Rows[row].Cells["colJuchuuNo"].Value.ToString() == data)
                        {
                            dtGS1.Rows[i].Delete();
                        }
                    }
                }

                DataRow dr1 = dtGS1.NewRow();
                for (int i = 0; i < dtGS1.Columns.Count; i++)
                {
                    if (i == 11)
                        dr1[i] = dgvShukkasizi[i, row].EditedFormattedValue;
                    else
                        dr1[i] = string.IsNullOrEmpty(dgvShukkasizi[i, row].EditedFormattedValue.ToString().Trim()) ? null : dgvShukkasizi[i, row].EditedFormattedValue.ToString();
                }
                dtGS1.Rows.Add(dr1);

            }
        }
        private void Update_Data()
        {
            sksz_e = new ShukkaSiziNyuuryokuEntity();
            sksz_e.ShippingDate = txtShippingDate.Text;
            sksz_e.ShippinNo = sbShippingNO.Text;

            sksz_bl = new ShukkasiziNyuuryokuBL();
            dt_Header = sksz_bl.ShukkasiziNyuuryoku_Data_Select(sksz_e, 1);
            if (dt_Header.Rows.Count > 0)
                ShukkasiziNyuuryoku_Header_Select(dt_Header);

            dtGridview(1);
            if (dtgv1.Rows.Count > 0)
            {
                dgvShukkasizi.DataSource = dtgv1;
            }
            else
                dgvShukkasizi.DataSource = dtClear;

            foreach (DataRow dr in dt_Header.Rows)
            {
                if (dr["ShukkaKanryouKBN"].ToString().Equals("1"))
                {
                    dgvShukkasizi.Columns["colArrivalTime"].ReadOnly = true;
                    dgvShukkasizi.Columns["chk"].ReadOnly = true;
                }
                else
                {
                    dgvShukkasizi.Columns["colArrivalTime"].ReadOnly = false;
                    dgvShukkasizi.Columns["chk"].ReadOnly = false;
                }
            }
        }
        private DataTable dtGridview(int dt)
        {
            switch(dt)
            {
                case 1://Update_Data_Details
                    sksz_e = new ShukkaSiziNyuuryokuEntity();
                    sksz_e.ShippinNo = sbShippingNO.Text;
                    sksz_e.ShippingDate = txtShippingDate.Text;
                    sksz_e.OperatorCD = OperatorCD;
                    sksz_e.ProgramID = ProgramID;
                    sksz_e.PC = PCID;
                    sksz_bl = new ShukkasiziNyuuryokuBL();
                    dtgv1 = sksz_bl.ShukkasiziNyuuryoku_Data_Select(sksz_e, 2);
                    break;

                case 2:
                    sksz_e = GetShukkasiziEntity();
                    sksz_bl = new ShukkasiziNyuuryokuBL();
                    dtgv1 = sksz_bl.ShukkasiziNyuuryoku_Display(sksz_e);
                    break;
            }           

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
        private TokuisakiEntity Tokuisaki_Data_Select(DataTable dt)
        {
            TokuisakiEntity te = new TokuisakiEntity();
            {
                te.TokuisakiCD = dt.Rows[0]["TokuisakiCD"].ToString();
                te.TokuisakiRyakuName = dt.Rows[0]["TokuisakiRyakuName"].ToString();
                te.TokuisakiName = dt.Rows[0]["TokuisakiName"].ToString();
                if (dt.Columns.Contains("TokuisakiYuubinNO1"))
                    te.YuubinNO1 = dt.Rows[0]["TokuisakiYuubinNO1"].ToString();
                else
                    te.YuubinNO1 = dt.Rows[0]["YuubinNO1"].ToString();
                if (dt.Columns.Contains("TokuisakiYuubinNO2"))
                    te.YuubinNO2 = dt.Rows[0]["TokuisakiYuubinNO2"].ToString();
                else
                    te.YuubinNO2 = dt.Rows[0]["YuubinNO2"].ToString();
                if (dt.Columns.Contains("TokuisakiJuusho1"))
                    te.Juusho1 = dt.Rows[0]["TokuisakiJuusho1"].ToString();
                else
                    te.Juusho1 = dt.Rows[0]["Juusho1"].ToString();
                if (dt.Columns.Contains("TokuisakiJuusho2"))
                    te.Juusho2 = dt.Rows[0]["TokuisakiJuusho2"].ToString();
                else
                    te.Juusho1 = dt.Rows[0]["Juusho2"].ToString();
                if (dt.Columns.Contains("TokuisakiTelNO1-1"))
                    te.Tel11 = dt.Rows[0]["TokuisakiTelNO1-1"].ToString();
                else
                    te.Tel11 = dt.Rows[0]["Tel11"].ToString();
                if (dt.Columns.Contains("TokuisakiTelNO1-2"))
                    te.Tel12 = dt.Rows[0]["TokuisakiTelNO1-2"].ToString();
                else
                    te.Tel12 = dt.Rows[0]["Tel12"].ToString();
                if (dt.Columns.Contains("TokuisakiTelNO1-3"))
                    te.Tel13 = dt.Rows[0]["TokuisakiTelNO1-3"].ToString();
                else
                    te.Tel13 = dt.Rows[0]["Tel13"].ToString();
                if (dt.Columns.Contains("TokuisakiTelNO2-1"))
                    te.Tel21 = dt.Rows[0]["TokuisakiTelNO2-1"].ToString();
                else
                    te.Tel21 = dt.Rows[0]["Tel21"].ToString();
                if (dt.Columns.Contains("TokuisakiTelNO2-2"))
                    te.Tel22 = dt.Rows[0]["TokuisakiTelNO2-2"].ToString();
                else
                    te.Tel22 = dt.Rows[0]["Tel22"].ToString();
                if (dt.Columns.Contains("TokuisakiTelNO2-3"))
                    te.Tel23 = dt.Rows[0]["TokuisakiTelNO2-3"].ToString();
                else
                    te.Tel23 = dt.Rows[0]["Tel23"].ToString();
            }
            return te;
        }
        private KouritenEntity Kouriten_Data_Select(DataTable dt)
        {
            KouritenEntity ke = new KouritenEntity();
            {
                ke.KouritenCD = dt.Rows[0]["KouritenCD"].ToString();
                ke.KouritenRyakuName = dt.Rows[0]["KouritenRyakuName"].ToString();
                ke.KouritenName = dt.Rows[0]["KouritenName"].ToString();
                if (dt.Columns.Contains("KouritenYuubinNO1"))
                    ke.YuubinNO1 = dt.Rows[0]["KouritenYuubinNO1"].ToString();
                else
                    ke.YuubinNO1 = dt.Rows[0]["YuubinNO1"].ToString();
                if (dt.Columns.Contains("KouritenYuubinNO2"))
                    ke.YuubinNO2 = dt.Rows[0]["KouritenYuubinNO2"].ToString();
                else
                    ke.YuubinNO2 = dt.Rows[0]["YuubinNO2"].ToString();
                if (dt.Columns.Contains("KouritenJuusho1"))
                    ke.Juusho1 = dt.Rows[0]["KouritenJuusho1"].ToString();
                else
                    ke.Juusho1 = dt.Rows[0]["Juusho1"].ToString();
                if (dt.Columns.Contains("KouritenJuusho2"))
                    ke.Juusho2 = dt.Rows[0]["KouritenJuusho2"].ToString();
                else
                    ke.Juusho2 = dt.Rows[0]["Juusho2"].ToString();
                if (dt.Columns.Contains("KouritenTelNO1-1"))
                    ke.Tel11 = dt.Rows[0]["KouritenTelNO1-1"].ToString();
                else
                    ke.Tel11 = dt.Rows[0]["Tel11"].ToString();
                if (dt.Columns.Contains("KouritenTelNO1-2"))
                    ke.Tel12 = dt.Rows[0]["KouritenTelNO1-2"].ToString();
                else
                    ke.Tel12 = dt.Rows[0]["Tel12"].ToString();
                if (dt.Columns.Contains("KouritenTelNO1-3"))
                    ke.Tel13 = dt.Rows[0]["KouritenTelNO1-3"].ToString();
                else
                    ke.Tel13 = dt.Rows[0]["Tel13"].ToString();
                if (dt.Columns.Contains("KouritenTelNO2-1"))
                    ke.Tel21 = dt.Rows[0]["KouritenTelNO2-1"].ToString();
                else
                    ke.Tel21 = dt.Rows[0]["Tel21"].ToString();
                if (dt.Columns.Contains("KouritenTelNO2-2"))
                    ke.Tel22 = dt.Rows[0]["KouritenTelNO2-2"].ToString();
                else
                    ke.Tel22 = dt.Rows[0]["Tel22"].ToString();
                if (dt.Columns.Contains("KouritenTelNO2-3"))
                    ke.Tel23 = dt.Rows[0]["KouritenTelNO2-3"].ToString();
                else
                    ke.Tel23 = dt.Rows[0]["Tel23"].ToString();
            }
            return ke;
            
        }
        private DataTable CreateTable_Header()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ShukkaSiziNO", typeof(string));
            dt.Columns.Add("StaffCD", typeof(string));
            dt.Columns.Add("ShukkaYoteiDate", typeof(string));
            dt.Columns.Add("DenpyouDate", typeof(string));

            dt.Columns.Add("TokuisakiCD", typeof(string));
            dt.Columns.Add("TokuisakiName", typeof(string));
            dt.Columns.Add("TokuisakiRyakuName", typeof(string));
            dt.Columns.Add("TokuisakiYuubinNO1", typeof(string));
            dt.Columns.Add("TokuisakiYuubinNO2", typeof(string));
            dt.Columns.Add("TokuisakiJuusho1", typeof(string));
            dt.Columns.Add("TokuisakiJuusho2", typeof(string));
            dt.Columns.Add("TokuisakiTel11", typeof(string));
            dt.Columns.Add("TokuisakiTel12", typeof(string));
            dt.Columns.Add("TokuisakiTel13", typeof(string));
            dt.Columns.Add("TokuisakiTel21", typeof(string));
            dt.Columns.Add("TokuisakiTel22", typeof(string));
            dt.Columns.Add("TokuisakiTel23", typeof(string));


            dt.Columns.Add("KouritenCD", typeof(string));
            dt.Columns.Add("KouritenName", typeof(string));
            dt.Columns.Add("KouritenRyakuName", typeof(string));
            dt.Columns.Add("KouritenYuubinNO1", typeof(string));
            dt.Columns.Add("KouritenYuubinNO2", typeof(string));
            dt.Columns.Add("KouritenJuusho1", typeof(string));
            dt.Columns.Add("KouritenJuusho2", typeof(string));
            dt.Columns.Add("KouritenTel11", typeof(string));
            dt.Columns.Add("KouritenTel12", typeof(string));
            dt.Columns.Add("KouritenTel13", typeof(string));
            dt.Columns.Add("KouritenTel21", typeof(string));
            dt.Columns.Add("KouritenTel22", typeof(string));
            dt.Columns.Add("KouritenTel23", typeof(string));


            dt.Columns.Add("ShukkaSiziDenpyouTekiyou", typeof(string));
            dt.Columns.Add("ShukkaSizishoHuyouKBN", typeof(string));
            dt.Columns.Add("OperatorCD", typeof(string));
            dt.Columns.Add("PC", typeof(string));
            dt.Columns.Add("ProgramID", typeof(string));

            dt.AcceptChanges();
            return dt;
        }
        private DataTable CreateTable_Details()
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
            dt.Columns.Add("JuchuuNO", typeof(string));
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
            dt.Columns.Add("Hidden_ShouhinCD", typeof(string));
            
            dt.AcceptChanges();
            return dt;
        }

        //KeyDown_Event
        private void sbShippingNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!sbShippingNO.IsErrorOccurs)
                {
                    if (cboMode.SelectedValue.ToString() == "2")
                    {
                        cf.DisablePanel(PanelTitle);
                        cf.EnablePanel(PanelDetail);
                        txtShippingDate.Focus();
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
                //DataTable dt = new DataTable();
                //dt = sbShippingNO.IsDatatableOccurs;
                if(!sbShippingNO.IsErrorOccurs && (cboMode.SelectedValue.ToString() != "1"))
                {
                    Update_Data();
                    //if (dt.rows.count > 0 && (cbomode.selectedvalue.tostring() != "1"))
                    //{
                    //    update_data();
                    //}
                }
                
            }
        }
        private void txtShippingDate_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if(!string.IsNullOrEmpty(txtShippingDate.Text))
                {
                    if (!string.IsNullOrWhiteSpace(sbTokuisaki.Text))
                    {
                        TokuisakiBL tbl = new TokuisakiBL();

                        DataTable dt1 = tbl.M_Tokuisaki_Select(sbTokuisaki.Text, txtShippingDate.Text, "E227");
                        DataTable dt2 = tbl.M_Tokuisaki_Select(sbTokuisaki.Text, txtShippingDate.Text, "E267");
                        if (dt1.Rows[0]["MessageID"].ToString()=="E227")
                        {
                            bbl.ShowMessage("E227");
                            sbTokuisaki.Focus();
                            return;
                        }
                        else if(dt2.Rows[0]["MessageID"].ToString() == "E267")
                        {
                            bbl.ShowMessage("E267");
                            sbTokuisaki.Focus();
                        }                        
                    }
                   if (!string.IsNullOrWhiteSpace(sbKouriten.Text))
                    {
                        KouritenBL kbl = new KouritenBL();
                        DataTable dt1 =kbl.Kouriten_Select_Check(sbKouriten.Text, txtShippingDate.Text, "E227");
                        DataTable dt2 = kbl.Kouriten_Select_Check(sbKouriten.Text, txtShippingDate.Text, "E267");
                        if (dt1.Rows[0]["MessageID"].ToString() == "E227")
                        {
                            bbl.ShowMessage("E227");
                            sbKouriten.Focus();
                        }
                        else if (dt2.Rows[0]["MessageID"].ToString() == "E267")
                        {
                            bbl.ShowMessage("E267");
                            sbKouriten.Focus();
                        }                        
                    }
                }                
            }
        }
        private void sbTokuisaki_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblTokuisakiName.Text = string.Empty;

                if (!sbTokuisaki.IsErrorOccurs)
                {
                    DataTable dt = sbTokuisaki.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                    {
                        lblTokuisakiName.Text = dt.Rows[0]["TokuisakiRyakuName"].ToString();
                        td.Access_Tokuisaki_obj = Tokuisaki_Data_Select(dt);
                    }
                }
            }
        }
        private void sbKouriten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblKouritenName.Text = string.Empty;
                DataTable dt = sbKouriten.IsDatatableOccurs;
                if (!string.IsNullOrWhiteSpace(sbKouriten.Text))
                {
                    if (ErrorCheck_Select(dt))
                    {
                        lblKouritenName.Text = dt.Rows[0]["KouritenRyakuName"].ToString();
                        kd.Access_Kouriten_obj = Kouriten_Data_Select(dt);
                    }
                    else
                    {
                        sbKouriten.Focus();
                    }
                }
            }
        }
        private void sbStaffCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblStaffName.Text = string.Empty;

                if (!sbStaffCD.IsErrorOccurs)
                {
                    DataTable dt = sbStaffCD.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                    {
                        lblStaffName.Text = dt.Rows[0]["StaffName"].ToString();
                    }
                }
            }
        }
        private void txtJuchuuNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                JuchuuNo_ErrorCheck();
            }
        }
        private void txtYubin2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtYubin2.IsErrorOccurs)
                {
                    if (txtYubin2.IsDatatableOccurs.Rows.Count > 0)
                    {
                        DataTable dt = txtYubin2.IsDatatableOccurs;
                        txtAddress.Text = dt.Rows[0]["Juusho1"].ToString();
                    }
                    else
                    {
                        txtAddress.Text = string.Empty;
                    }
                }
            }

        }
        private void dgvShukkasizi_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.F9)
            {
                int row = dgvShukkasizi.CurrentCell.RowIndex;
                int col = dgvShukkasizi.CurrentCell.ColumnIndex;
                SoukoSearch ss = new SoukoSearch();
                ss.ShowDialog();

                if(!string.IsNullOrEmpty(ss.soukoCD))
                {                    
                    dgvShukkasizi["SoukoCD", row].Value = ss.soukoCD.ToString();
                    dgvShukkasizi["SoukoName", row].Value = ss.soukoName.ToString();
                }
            }
        }

        //Error_Check
        private void Form_ErrorCheck()
        {
            if (cboMode.SelectedValue.ToString().Equals("1"))
            {
                //出荷予定日
                txtShippingDate.E102Check(true);
                txtShippingDate.E103Check(true);
                //得意先
                sbTokuisaki.E102Check(true);
                sbTokuisaki.E101Check(true, "M_Tokuisaki", sbTokuisaki, txtShippingDate, null);
                sbTokuisaki.E267Check(true, "M_Tokuisaki", sbTokuisaki, txtShippingDate);
                sbTokuisaki.E227Check(true, "M_Tokuisaki", sbTokuisaki, txtShippingDate);
                //小売店
                sbKouriten.E101Check(true, "M_Kouriten", sbKouriten, txtShippingDate, null);
                //担当スタッフCD
                sbStaffCD.E102Check(true);
                sbStaffCD.E101Check(true, "M_Staff", sbStaffCD, txtShippingDate, null);
                sbStaffCD.E135Check(true, "M_Staff", sbStaffCD, txtShippingDate);
                //伝票日付
                txtSlipDate.E102Check(true);
                txtSlipDate.E103Check(true);
                //受注番号
                JuchuuNo_ErrorCheck();
                //false case
                sbShippingNO.E102Check(false);
                sbShippingNO.E133Check(false, "ShukkaSiziNyuuryoku", sbShippingNO, null, null);
                sbShippingNO.E115Check(false, "ShukkaSiziNyuuryoku", sbShippingNO);
                sbShippingNO.E160Check(false, "ShukkaSiziNyuuryoku", sbShippingNO, null);
            }
            else
            {
               sbShippingNO.E102Check(true);
                sbShippingNO.E133Check(true, "ShukkaSiziNyuuryoku", sbShippingNO, null, null);
                sbShippingNO.E115Check(true, "ShukkaSiziNyuuryoku", sbShippingNO);
                sbShippingNO.E160Check(true, "ShukkaSiziNyuuryoku", sbShippingNO, null);
            }
            txtYubin2.E102MultiCheck(true, txtYubin1, txtYubin2);
            txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, string.Empty, string.Empty);

        }
        private bool Temp_Null()
        {
            if (cboMode.SelectedValue.ToString().Equals("1") && dtTemp1.Rows.Count == 0 || cboMode.SelectedValue.ToString().Equals("2") && dtTemp1.Rows.Count == 0)          
            {
                bbl.ShowMessage("E274");
                return false;
            }
            return true;
        }
        private void JuchuuNo_ErrorCheck()
        {
            sksz_bl = new ShukkasiziNyuuryokuBL();
            DataTable dt = new DataTable();
            if (!string.IsNullOrWhiteSpace(txtJuchuuNo.Text))
            {
                dt = sksz_bl.JuchuuNo_Check(txtJuchuuNo.Text, "E133");
                if (dt.Rows[0]["MessageID"].ToString().Equals("E133"))
                {
                    bbl.ShowMessage("E133");
                    txtJuchuuNo.Focus();
                }
            }
        }
        private bool ErrorCheck_Select(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                string TorihikiKaisiDate = dt.Rows[0]["TorihikiKaisiDate"].ToString();
                string TorihikiShuuryouDate = dt.Rows[0]["TorihikiShuuryouDate"].ToString();
                if (!string.IsNullOrEmpty(TorihikiKaisiDate) && Convert.ToDateTime(TorihikiKaisiDate) > Convert.ToDateTime(txtShippingDate.Text))
                {
                    bbl.ShowMessage("E267");
                    return false;
                }
                else if (!string.IsNullOrEmpty(TorihikiShuuryouDate) && Convert.ToDateTime(TorihikiShuuryouDate) < Convert.ToDateTime(txtShippingDate.Text))
                {
                    bbl.ShowMessage("E227");
                    return false;
                }
            }
            return true;
        }
        private bool Grid_ErrorCheck(int row, int col)
        {
            if (dgvShukkasizi.Columns[col].Name == "colArrivalTime")
            {
                string value = dgvShukkasizi.Rows[row].Cells["colArrivalTime"].EditedFormattedValue.ToString().Replace(",", "");
                if (Convert.ToInt32(value) < 0)
                {
                    bbl.ShowMessage("E109");
                    return false;
                }
                string value1 = dgvShukkasizi.Rows[row].Cells["colShukkakanousuu"].EditedFormattedValue.ToString();
                if (Convert.ToInt32(value) > Convert.ToInt32(value1))
                {
                    bbl.ShowMessage("E143");
                    dgvShukkasizi.CurrentCell = dgvShukkasizi.Rows[row].Cells["colArrivalTime"];
                    return false;
                }
                string value2 = dgvShukkasizi.Rows[row].Cells["colJuchuuSuu"].EditedFormattedValue.ToString();
                string value3 = dgvShukkasizi.Rows[row].Cells["colShukkasizisou"].EditedFormattedValue.ToString().Replace(",", "");
                if (Convert.ToInt32(value) > (Convert.ToInt32(value2) - Convert.ToInt32(value3)))
                {
                    bbl.ShowMessage("E143");
                    return false;
                }
            }
            if (dgvShukkasizi.Columns[col].Name == "SoukoCD")
            {
                if (dgvShukkasizi.Rows[row].Cells["SoukoCD"].Value.ToString().Equals("") && (!dgvShukkasizi.Rows[row].Cells["colArrivalTime"].EditedFormattedValue.ToString().Equals("0")))
                {
                    bbl.ShowMessage("E102");
                    dgvShukkasizi.CurrentCell = dgvShukkasizi.Rows[row].Cells["SoukoCD"];
                    return false;
                }
            }

            return true;
        }
        private bool GV_Check()
        {
            foreach (DataGridViewRow gv in dgvShukkasizi.Rows)
            {
                if(gv.Cells["colArrivalTime"].Value.ToString()!=gv.Cells["colArrivalTime"].EditedFormattedValue.ToString())
                {
                    string value = gv.Cells["colArrivalTime"].EditedFormattedValue.ToString().Replace(",", "");
                    if (Convert.ToInt32(value) < 0)
                    {
                        bbl.ShowMessage("E109");
                        return false;
                    }
                    string value1 = gv.Cells["colShukkakanousuu"].Value.ToString();
                    if (Convert.ToInt32(value) > Convert.ToInt32(value1))
                    {
                        bbl.ShowMessage("E143");
                        dgvShukkasizi.CurrentCell = gv.Cells["colArrivalTime"];
                        return false;
                    }

                    string value2 = gv.Cells["colJuchuuSuu"].Value.ToString();
                    string value3 = gv.Cells["colShukkasizisou"].Value.ToString();
                    if (Convert.ToInt32(value) > (Convert.ToInt32(value2) - Convert.ToInt32(value3)))
                    {
                        bbl.ShowMessage("E143");
                        dgvShukkasizi.CurrentCell = gv.Cells["colArrivalTime"];
                        return false;
                    }

                    if (gv.Cells["SoukoCD"].Value.ToString().Equals("") && (!gv.Cells["colArrivalTime"].EditedFormattedValue.ToString().Equals("0")))
                    {
                        bbl.ShowMessage("E102");
                        dgvShukkasizi.CurrentCell = gv.Cells["SoukoCD"];
                        return false;
                    }
                }                
            }
            return true;
        }
        private void sbTokuisaki_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(sbTokuisaki.Text))
            {
                lblTokuisakiName.Text = string.Empty;
            }
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

        //Mode_Procedure
        private void FunctionProcedure(int tagID)
        {
            switch (tagID)
            {
                case 8:
                    if (dtTemp1.Rows.Count > 0)
                    {
                        var dtConfirm = dtTemp1.AsEnumerable().OrderBy(r => r.Field<string>("SKMSNO")).ThenBy(r => r.Field<string>("ShouhinCD")).CopyToDataTable();
                        dgvShukkasizi.DataSource = dtConfirm;
                    }
                    else
                    {
                        dtGS1 = CreateTable_Details();
                        dgvShukkasizi.DataSource = dtGS1;
                    }
                       break;
                case 10:

                    if (cboMode.SelectedValue.ToString().Equals("2"))
                    {
                        dtGridview(1);

                    }
                    else
                    {
                        dtGridview(2);
                    }
                    dtHaita = dtgv1.Copy();                   
                    //Table_Y/排他テーブルに追加
                    if (dtgv1.Rows.Count>0)
                    {
                        var dtRow = dtgv1.AsEnumerable().OrderBy(r => r.Field<string>("SKMSNO")).ThenBy(r => r.Field<string>("JuchuuNO")).CopyToDataTable();
                        JuchuuNO_Delete();
                        foreach (DataRow dr in dtRow.Rows)
                        {
                            string JuchuuNO = dr["JuchuuNO"].ToString();
                            sksz_e = new ShukkaSiziNyuuryokuEntity();
                            sksz_e.DataKBN = 1;
                            sksz_e.JuchuuNO = JuchuuNO;
                            sksz_e.ProgramID = ProgramID;
                            sksz_e.PC = PCID;
                            sksz_e.OperatorCD = OperatorCD;

                            DataTable dt = new DataTable();
                            sksz_bl = new ShukkasiziNyuuryokuBL();
                            dt = sksz_bl.D_Exclusive_Lock_Check(sksz_e);

                            if (dt.Rows[0]["MessageID"].ToString().Equals("S004"))
                            {
                                bbl.ShowMessage("S004");
                                Gvrow_Delete(dr);
                            }
                        }
                    }
                   // dtHaita.Columns.Remove("JuchuuNO");
                    dgvShukkasizi.DataSource = dtHaita;
                    dgvShukkasizi.Columns["colArrivalTime"].ReadOnly = false;
                    dgvShukkasizi.Columns["chk"].ReadOnly = false;                    
                    break;
                case 11:
                    if(GV_Check())
                    {
                        dtTemp1 = dtGS1;//temp add

                        F11_Clear();
                        txtJuchuuNo.Focus();
                        dgvShukkasizi.ClearSelection();
                        dgvShukkasizi.DataSource = dtClear;
                    }                    
                    break;
            }
        }
        private void JuchuuNO_Delete()
        {
            sksz_e = new ShukkaSiziNyuuryokuEntity();
            sksz_e.DataKBN = 1;
            sksz_e.OperatorCD = OperatorCD;
            sksz_e.ProgramID = ProgramID;
            sksz_e.PC = PCID;
            sksz_bl = new ShukkasiziNyuuryokuBL();
            sksz_bl.SKSZ_D_Exclusive_JuchuuNO_Delete(sksz_e);
        }
        private void Gvrow_Delete(DataRow dr)
        {
            DataRow[] existDr1 = dtHaita.Select("JuchuuNO ='" + dr["JuchuuNO"] + "'");

            foreach (DataRow row in existDr1)
            {
                dtHaita.Rows.Remove(row);// Here The given DataRow is not in the current DataRowCollection
            }
        }
        private void ModeType(int type)
        {
            switch (type)
            {
                case 1://New_Mode
                    cf.Clear(PanelTitle);
                    cf.Clear(PanelDetail);
                    cf.DisablePanel(PanelTitle);
                    cf.EnablePanel(PanelDetail);
                    txtShippingDate.Focus();
                    rdoNeed.Checked = true;
                    tdDate = System.DateTime.Now.ToString("yyyy/MM/dd");
                    txtShippingDate.Text = tdDate;
                    txtSlipDate.Text = tdDate;
                    StaffEntity staffEntity = new StaffEntity
                    {
                        StaffCD = OperatorCD
                    };
                    staffEntity = staffBL.GetStaffEntity(staffEntity);
                    sbStaffCD.Text = OperatorCD;
                    lblStaffName.Text = staffEntity.StaffName;
                    break;

                case 2://F3
                    cf.Clear(PanelTitle);
                    cf.Clear(PanelDetail);
                    cf.EnablePanel(PanelTitle);
                    cf.DisablePanel(PanelDetail);
                    sbShippingNO.Focus();
                    rdoNeed.Checked = true;
                    break;

                case 3:
                    lblTokuisakiName.Text = string.Empty;
                    lblKouritenName.Text = string.Empty;
                    lblStaffName.Text = string.Empty;
                    break;

                case 4:  //start_Mode
                    SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
                    SetButton(ButtonType.BType.New, F2, "新規(F2)", true);
                    SetButton(ButtonType.BType.Update, F3, "変更(F3)", true);
                    SetButton(ButtonType.BType.Delete, F4, "削除(F4)", true);
                    SetButton(ButtonType.BType.Inquiry, F5, "照会(F5)", true);
                    SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
                    SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", true);
                    SetButton(ButtonType.BType.Search, F9, "検索(F9)", false);
                    SetButton(ButtonType.BType.Display, F10, "表示(F10)", true);
                    SetButton(ButtonType.BType.Memory, F11, "保存(F11)", true);
                    SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);
                    SetButton(ButtonType.BType.Empty, F7, "", false);

                    lblTokuisakiName.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    lblKouritenName.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    lblStaffName.BorderStyle = System.Windows.Forms.BorderStyle.None;

                    sbTokuisaki.lblName = lblTokuisakiName;
                    sbKouriten.lblName = lblKouritenName;
                    sbStaffCD.lblName = lblStaffName;
                    sbTokuisaki.ChangeDate = txtShippingDate;
                    sbKouriten.ChangeDate = txtShippingDate;
                    sbStaffCD.ChangeDate = txtShippingDate;
                    break;                
            }
        }

        //F12
        private void DBProcess()
        {
            (string,string, string) obj = GetInsert();
            sksz_bl = new ShukkasiziNyuuryokuBL(); 

            if(cboMode.SelectedValue.Equals("3"))
            {
                Konkai_Price(dtTemp1);
                sksz_bl.ShukkasiziNyuuryoku_IUD(obj.Item1, obj.Item2, obj.Item3);
                bbl.ShowMessage("I102");
            }
            else
            {
                sksz_bl.ShukkasiziNyuuryoku_IUD(obj.Item1, obj.Item2, obj.Item3);
                Konkai_Price(dtTemp1);
                bbl.ShowMessage("I101");
            }
        }
        private void Konkai_Price(DataTable dtTemp1)
        {
            foreach (DataRow dr in dtTemp1.Rows)
            {
                //string shukkasizisuu= dr.Cells["colArrivalTime"].Value.ToString();
                //string JuchuuNO = dr.Cells["JuchuuNO"].Value.ToString();
                //string ShouhinCD= dr.Cells["colShouhinCD"].Value.ToString();
                string shukkasizisuu = dr["KonkaiShukkaSiziSuu"].ToString();
                string JuchuuNO_GyouNO = dr["SKMSNO"].ToString();
                string ShouhinCD = dr["ShouhinCD"].ToString();
                sksz_bl.Shukkasizi_Price(shukkasizisuu, JuchuuNO_GyouNO, ShouhinCD);
            }
        }
        private (string, string, string) GetInsert()
        {
            TokuisakiEntity t_obj = td.Access_Tokuisaki_obj;
            KouritenEntity k_obj = kd.Access_Kouriten_obj;

            dtResult = CreateTable_Header();
           
            DataRow dr = dtResult.NewRow();
            sksz_bl = new ShukkasiziNyuuryokuBL();
            if (cboMode.SelectedValue.ToString() != "1")
            {
                dr["ShukkaSiziNO"] = sbShippingNO.Text;
            }
            dr["StaffCD"] = sbStaffCD.Text;
            dr["ShukkaYoteiDate"] = txtShippingDate.Text;
            dr["DenpyouDate"] = txtSlipDate.Text;
            
            dr["TokuisakiCD"] =sbTokuisaki.Text;
            dr["TokuisakiRyakuName"] = t_obj.TokuisakiRyakuName;
            dr["TokuisakiName"] = t_obj.TokuisakiName;
            dr["TokuisakiYuubinNO1"] = t_obj.YuubinNO1;
            dr["TokuisakiYuubinNO2"] = t_obj.YuubinNO2;
            dr["TokuisakiJuusho1"] = t_obj.Juusho1;
            dr["TokuisakiJuusho2"] = t_obj.Juusho2;
            dr["TokuisakiTel11"] = t_obj.Tel11;
            dr["TokuisakiTel12"] = t_obj.Tel12;
            dr["TokuisakiTel13"] = t_obj.Tel13;
            dr["TokuisakiTel21"] = t_obj.Tel21;
            dr["TokuisakiTel22"] = t_obj.Tel22;
            dr["TokuisakiTel23"] = t_obj.Tel23;

            dr["KouritenCD"] = sbKouriten.Text;
            dr["KouritenRyakuName"] = k_obj.KouritenRyakuName;
            dr["KouritenName"] = k_obj.KouritenName;
            dr["KouritenYuubinNO1"] = k_obj.YuubinNO1;
            dr["KouritenYuubinNO2"] = k_obj.YuubinNO2;
            dr["KouritenJuusho1"] = k_obj.Juusho1;
            dr["KouritenJuusho2"] = k_obj.Juusho2;
            dr["KouritenTel11"] = k_obj.Tel11;
            dr["KouritenTel12"] = k_obj.Tel12;
            dr["KouritenTel13"] = k_obj.Tel13;
            dr["KouritenTel21"] = k_obj.Tel21;
            dr["KouritenTel22"] = k_obj.Tel22;
            dr["KouritenTel23"] = k_obj.Tel23;

            dr["ShukkaSiziDenpyouTekiyou"] = string.IsNullOrEmpty(txtSlip_Description.Text)?null:txtSlip_Description.Text;
            dr["ShukkaSizishoHuyouKBN"] =rdoNO.Checked?"1":"0";
            dr["OperatorCD"] = be.OperatorCD;
            dr["PC"] = be.PC;
            dr["ProgramID"] = be.ProgramID;

            DataRow dr1 = dtResult.NewRow();
            for (int i = 0; i < dtResult.Columns.Count; i++)
            {
                dr1[i] = string.IsNullOrEmpty(dr[i].ToString().Trim()) ? null : dr[i].ToString();
            }
            dtResult.Rows.Add(dr1);
            string Header_XML = cf.DataTableToXml(dtResult);
            if (cboMode.SelectedValue.ToString().Equals("3"))
            {
                DataTable dt = new DataTable();
                dt=dtGridview(1);
                Detail_XML = cf.DataTableToXml(dt);
            }
            else
            {
                Detail_XML = cf.DataTableToXml(dtTemp1);
            }             

            string Mode = string.Empty;
            if (cboMode.SelectedValue.Equals("1"))
            {
                Mode = "New";
            }
            else if (cboMode.SelectedValue.Equals("2"))
            {
                Mode = "Update";
            }
            else if (cboMode.SelectedValue.Equals("3"))
            {
                Mode = "Delete";
            }

            return (Mode,Header_XML, Detail_XML);
        }        
    }
}
