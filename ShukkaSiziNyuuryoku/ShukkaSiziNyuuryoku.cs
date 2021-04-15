using System;
using Shinyoh;
using Entity;
using BL;
using Shinyoh_Details;
using CKM_CommonFunction;
using System.Windows.Forms;
using Shinyoh_Search;
using System.Data;
using System.Linq;
using Shinyoh_Controls;

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
        string Data1 = string.Empty, Data2 = string.Empty, Data3 = string.Empty;
        DataTable dtgv1, dtGS1, dtClear, dt_Header, dtResult, dtHaita, dtShippingNO;

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
            dtgv1 = new DataTable();
            dt_Header = new DataTable();
            dtResult = new DataTable();
            dtHaita = new DataTable();
            dtGS1 = CreateTable_Details();
            dtClear = CreateTable_Details();
            dgvShukkasizi.CellEndEdit += DgvShukkasizi_CellEndEdit;
            dgvShukkasizi.CellContentClick += DgvShukkasizi_CellContentClick;
            dgvShukkasizi.KeyDown += dgvShukkasizi_KeyDown;
            dgvShukkasizi.CellEnter += dgvShukkasizi_CellEnter;
            sbShippingNO.ChangeDate = txtShippingDate;
            //td = new TokuisakiDetail();
            //kd = new KouritenDetail(); 
            sbKouriten.TxtBox = sbTokuisaki;//ses
            GridView_UI();

            //this.dgvShukkasizi.Size = new System.Drawing.Size(1300, 387);
        }
        private void GridView_UI()
        {
            dgvShukkasizi.SetGridDesign();
            dgvShukkasizi.Columns["colKonkaiShukkaSiziSuu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvShukkasizi.SetNumberColumn("colKonkaiShukkaSiziSuu,colTanka,colPrice");
            dgvShukkasizi.SetHiraganaColumn("colDetails");
            dgvShukkasizi.SetReadOnlyColumn("colShouhinCD,colShouhinName,colColorRyakuName,colColorNO,colSizeNO,colJuchuuSuu,colShukkakanousuu,colShukkaSiziZumiSuu,colJuchuuNo,SoukoName");
           
            var col = dgvShukkasizi.Columns;

            DataGridViewTextBoxColumn newCol = new DataGridViewTextBoxColumn();
            newCol.Name = "Hidden_ShukkaSiziGyouNO";
            newCol.DataPropertyName = "Hidden_ShukkaSiziGyouNO";
            newCol.Visible = false;
            dgvShukkasizi.Columns.Insert(col.Count,newCol);
            newCol.DisplayIndex = col.Count - 1;

            for (int i = 5; i < col.Count; i++)
            {
                while (i <= 10)
                {
                    col[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    ++i;
                }
                if (i == 11)
                {
                    col[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    return;
                }
            }
        }
        private void ShukkaSiziNyuuryoku_Load(object sender, EventArgs e)
        {
            ProgramID = "ShukkaSiziNyuuryoku";
            StartProgram();
            cboMode.Bind(false, multi_Entity);
            ModeType(4);
            be = _GetBaseData();
            ChangeMode(Mode.New);
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
                if (cboMode.SelectedValue.ToString().Equals("1"))
                {
                    ModeType(1);
                }
                else
                {
                    ModeType(2);
                }
                ModeType(3);
                BaseEntity be = new BaseEntity();
                be.ProgramID = ProgramID;
                be.OperatorCD = OperatorCD;
                be.PC = PCID;
                BaseBL bbl = new BaseBL();
                bbl.D_Exclusive_Number_Remove(be);
            }
            if (tagID == "8")
            {
                FunctionProcedure(8);
            }
            if (tagID == "10")
            {
                dgvShukkasizi.ActionType = "F10";     //to skip gv error check at the ErrorCheck() of BaseForm.cs
                if (ErrorCheck(PanelDetail))
                    FunctionProcedure(10);
                dgvShukkasizi.ActionType = string.Empty;    //to check gv error at the ErrorCheck() of BaseForm.cs
            }
            if (tagID == "11")
            {
                FunctionProcedure(11);
            }
            if (tagID == "12")
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
                dtResult.Clear();
                dtGS1.Clear();
                //}
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

                    td = new TokuisakiDetail();
                    kd = new KouritenDetail();
                    break;
                case Mode.Update:
                    ModeType(2);
                    Form_ErrorCheck();
                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;

                    td = new TokuisakiDetail();
                    kd = new KouritenDetail();
                    break;
                case Mode.Delete:
                    ModeType(2);
                    Form_ErrorCheck();
                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;

                    td = new TokuisakiDetail(false);
                    kd = new KouritenDetail(false);
                    break;
                case Mode.Inquiry:
                    ModeType(2);
                    Form_ErrorCheck();
                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;

                    td = new TokuisakiDetail(false);
                    kd = new KouritenDetail(false);
                    break;
            }
        }

        //DataTable
        private void ShukkasiziNyuuryoku_Header_Select(DataTable dt)
        {
            //Header 
            txtShippingDate.Text = dt.Rows[0]["ShukkaYoteiDate"].ToString();
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
            if (dgvShukkasizi.CurrentCell == dgvShukkasizi.Rows[row].Cells["colTanka"] || dgvShukkasizi.CurrentCell == dgvShukkasizi.Rows[row].Cells["colKonkaiShukkaSiziSuu"])
            {
                string colKonkaiShukkaSiziSuu = dgvShukkasizi.Rows[row].Cells["colKonkaiShukkaSiziSuu"].EditedFormattedValue.ToString().Replace(",", "");
                string colTanka = dgvShukkasizi.Rows[row].Cells["colTanka"].EditedFormattedValue.ToString().Replace(",", "");
                if (colKonkaiShukkaSiziSuu.All(char.IsDigit)  && (colTanka.All(char.IsDigit)))
                {
                    string val = Convert.ToString(Convert.ToInt64(colKonkaiShukkaSiziSuu) * Convert.ToInt64(colTanka));
                    dgvShukkasizi.Rows[row].Cells["colPrice"].Value = FormatPriceValue(val);
                }
            }
           
            //souko bind case
            if (dgvShukkasizi.CurrentCell == dgvShukkasizi.Rows[row].Cells["SoukoCD"])
            {
                dtGridview(2);
                if (dtgv1.Rows.Count == 0)
                {
                    dtGridview(1);
                }

                string SoukoCD = dgvShukkasizi.Rows[row].Cells["SoukoCD"].EditedFormattedValue.ToString();
                if (SoukoCD != dtgv1.Rows[row]["SoukoCD"].ToString())
                {
                    SoukoBL sb = new SoukoBL();
                    if (!string.IsNullOrEmpty(SoukoCD))
                    {
                        DataTable dt = sb.Souko_Select(SoukoCD, "E101");
                        if (dt.Rows[0]["MessageID"].ToString().Equals("E101"))
                        {
                            bbl.ShowMessage("E101");
                            dgvShukkasizi["SoukoName", row].Value = string.Empty;
                        }
                        else
                        {
                            dgvShukkasizi["SoukoCD", row].Value = dt.Rows[0]["SoukoCD"].ToString();
                            dgvShukkasizi["SoukoName", row].Value = dt.Rows[0]["SoukoName"].ToString();
                            if(dgvShukkasizi.Rows.Count>1)
                            {
                                dgvShukkasizi.CurrentCell = dgvShukkasizi.Rows[row + 1].Cells[8];
                            }
                        }
                    }
                    else
                    {
                        dgvShukkasizi["SoukoName", row].Value = string.Empty;
                    }
                }
                else//original_value
                {
                    dgvShukkasizi["SoukoCD", row].Value = dtgv1.Rows[row]["SoukoCD"].ToString();
                    dgvShukkasizi["SoukoName", row].Value = dtgv1.Rows[row]["SoukoName"].ToString();
                    if (dgvShukkasizi.Rows.Count > 1)
                    {
                        dgvShukkasizi.CurrentCell = dgvShukkasizi.Rows[row + 1].Cells[8];
                    }
                }
            }           
        }
        private void Update_Data()
        {
            sksz_e = new ShukkaSiziNyuuryokuEntity();
            sksz_e.ShippinNo = sbShippingNO.Text;
            sksz_e.ProgramID = ProgramID;
            sksz_e.OperatorCD = OperatorCD;
            sksz_e.PC = PCID;
            //Header
            sksz_bl = new ShukkasiziNyuuryokuBL();
            dt_Header = sksz_bl.ShukkasiziNyuuryoku_Data_Select(sksz_e, 1);
            if (dt_Header.Rows.Count > 0)
            {
                ShukkasiziNyuuryoku_Header_Select(dt_Header);
                if (dt_Header.Rows[0]["ShukkaKanryouKBN"].ToString().Equals("1"))
                {
                    dgvShukkasizi.Columns["colKonkaiShukkaSiziSuu"].ReadOnly = true;
                    dgvShukkasizi.Columns["chk"].ReadOnly = true;
                }
            }               
            //Details
            dtGridview(1);

            if (dtgv1.Rows.Count > 0)
            {
                dgvShukkasizi.DataSource = dtgv1;
            }
            else
                dgvShukkasizi.DataSource = dtClear;
           
        }
        private DataTable dtGridview(int dt)
        {
            switch (dt)
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
                    te.Juusho2 = dt.Rows[0]["Juusho2"].ToString();
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
            dt.Columns.Add("Hidden_ShukkaSiziGyouNO", typeof(int));

            dt.AcceptChanges();
            return dt;
        }

        //Button_Click
        private void btn_Tokuisaki_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(sbTokuisaki.Text) && td.Access_Tokuisaki_obj.TokuisakiCD != null)
            {
                if (!td.Access_Tokuisaki_obj.TokuisakiCD.ToString().Equals(sbTokuisaki.Text))
                {

                    bbl.ShowMessage("E269", "受注時", "得意先");
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
            if (!string.IsNullOrWhiteSpace(sbKouriten.Text))
            {
                kd.ShowDialog();
            }
            else
            {
                sbKouriten.Focus();
            }
        }
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            dgvShukkasizi.ActionType = "F10";
            if (ErrorCheck(PanelDetail))
                FunctionProcedure(10);
            dgvShukkasizi.ActionType = string.Empty;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            FunctionProcedure(11);
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            FunctionProcedure(8);
        }

        //GV_Event
        private void DgvShukkasizi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvShukkasizi.IsLastKeyEnter)
            {
                if (Grid_ErrorCheck(e.RowIndex, e.ColumnIndex))
                {
                    if(e.ColumnIndex==8 || e.ColumnIndex==9 || e.ColumnIndex==10)
                    {
                        string formatvalue = !string.IsNullOrEmpty(dgvShukkasizi.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString())? dgvShukkasizi.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() : "0";
                        formatvalue = FormatPriceValue(formatvalue);
                        dgvShukkasizi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = formatvalue;
                       
                    }

                    if (cboMode.SelectedValue.ToString().Equals("2"))
                    {
                        dtResult.Clear();
                        dtGS1.Clear();
                    }
                    Temp_Save(e.RowIndex);
                }
            }           
        }
        private void DgvShukkasizi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 11)
            {
                if (Convert.ToBoolean(dgvShukkasizi.Rows[e.RowIndex].Cells["chk"].EditedFormattedValue))
                {
                    Temp_Save(e.RowIndex);
                    //dgvShukkasizi.MoveNextCell();
                }
            }
        }
        private void dgvShukkasizi_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(cboMode.SelectedValue.ToString().Equals("1") || cboMode.SelectedValue.ToString().Equals("2"))
            {
                Gridview_F9ShowHide(e.ColumnIndex, "Show");
            }
        }
        private void dgvShukkasizi_KeyDown(object sender, KeyEventArgs e)
        {
            SCombo cbo = new SCombo();

            if(this.TopLevelControl.Controls.Find("cboMode", true).Count() > 0 )
                cbo = this.TopLevelControl.Controls.Find("cboMode", true)[0] as SCombo;
            if (e.KeyCode == Keys.F9 && (cbo.SelectedValue.Equals("1") || cbo.SelectedValue.Equals("2")))
            {
                int row = dgvShukkasizi.CurrentCell.RowIndex;
                int col = dgvShukkasizi.CurrentCell.ColumnIndex;
                if (row >= 0 && col == 15)
                {
                    SoukoSearch ss = new SoukoSearch();
                    ss.ShowDialog();
                    if (!string.IsNullOrEmpty(ss.soukoCD))
                    {
                        dgvShukkasizi["SoukoCD", row].Value = ss.soukoCD.ToString();
                        dgvShukkasizi["SoukoName", row].Value = ss.soukoName.ToString();
                        if(dgvShukkasizi.Rows.Count>1)
                        {
                            dgvShukkasizi.CurrentCell = dgvShukkasizi.Rows[row + 1].Cells[8];
                        }
                    }
                }
            }
        }

        //KeyDown_Event
        private void sbShippingNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!sbShippingNO.IsErrorOccurs && (cboMode.SelectedValue.ToString() != "1"))
                {
                    if (cboMode.SelectedValue.ToString().Equals("2") || cboMode.SelectedValue.ToString().Equals("3"))
                    {
                        if (ShippingNO_Check())
                        {
                            if (cboMode.SelectedValue.ToString().Equals("2"))
                            {
                                cf.DisablePanel(PanelTitle);
                                cf.EnablePanel(PanelDetail);
                                txtShippingDate.Focus();
                                Control BtnF9 = this.TopLevelControl.Controls.Find("BtnF9", true)[0];
                                BtnF9.Visible = false;
                                SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", true);
                                SetButton(ButtonType.BType.Display, F10, "表示(F10)", true);
                                SetButton(ButtonType.BType.Memory, F11, "保存(F11)", true);
                            }
                            else if (cboMode.SelectedValue.ToString().Equals("3"))
                            {
                                cf.DisablePanel(PanelTitle);
                                Control BtnF9 = this.TopLevelControl.Controls.Find("BtnF9", true)[0];
                                BtnF9.Visible = false;
                                Control btnF12 = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                                btnF12.Focus();
                            }

                            Update_Data();
                        }
                        else
                        {
                            bbl.ShowMessage("S004", Data1, Data2, Data3);
                            sbShippingNO.Focus();
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
                    }
                }
            }
        }
        private void txtShippingDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtShippingDate.Text))
                {
                    if (!string.IsNullOrWhiteSpace(sbTokuisaki.Text))
                    {
                        TokuisakiBL tbl = new TokuisakiBL();

                        DataTable dt1 = tbl.M_Tokuisaki_Select(sbTokuisaki.Text, txtShippingDate.Text, "E227");
                        DataTable dt2 = tbl.M_Tokuisaki_Select(sbTokuisaki.Text, txtShippingDate.Text, "E267");
                        if (dt1.Rows.Count > 0 && dt1.Rows[0]["MessageID"].ToString() == "E227")
                        {
                            bbl.ShowMessage("E227", "取引終了日");
                            sbTokuisaki.Focus();
                            return;
                        }
                        else if (dt2.Rows.Count > 0 && dt2.Rows[0]["MessageID"].ToString() == "E267")
                        {
                            bbl.ShowMessage("E267", "取引開始日");
                            sbTokuisaki.Focus();
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(sbKouriten.Text))
                    {
                        KouritenBL kbl = new KouritenBL();
                        DataTable dt1 = kbl.Kouriten_Select_Check(sbKouriten.Text, txtShippingDate.Text, "E227");
                        DataTable dt2 = kbl.Kouriten_Select_Check(sbKouriten.Text, txtShippingDate.Text, "E267");
                        if (dt1.Rows.Count > 0 && dt1.Rows[0]["MessageID"].ToString() == "E227")
                        {
                            bbl.ShowMessage("E227", "取引終了日");
                            sbKouriten.Focus();
                        }
                        else if (dt2.Rows.Count > 0 && dt2.Rows[0]["MessageID"].ToString() == "E267")
                        {
                            bbl.ShowMessage("E267", "取引開始日");
                            sbKouriten.Focus();
                        }
                    }
                    if (string.IsNullOrEmpty(txtSlipDate.Text))
                    {
                        txtSlipDate.Text = txtShippingDate.Text;
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
                    bbl.ShowMessage("E267", "取引開始日");
                    return false;
                }
                else if (!string.IsNullOrEmpty(TorihikiShuuryouDate) && Convert.ToDateTime(TorihikiShuuryouDate) < Convert.ToDateTime(txtShippingDate.Text))
                {
                    bbl.ShowMessage("E227", "取引終了日");
                    return false;
                }
            }
            return true;
        }
        private bool Grid_ErrorCheck(int row, int col)
        {
            if (col == 8 || col == 9 || col == 10)
            {
                string Result = dgvShukkasizi.Rows[row].Cells[col].EditedFormattedValue.ToString().Replace(",","");
                if (string.IsNullOrEmpty(Result))
                {
                    dgvShukkasizi.Rows[row].Cells[col].Value = "0";
                }
                else if (Convert.ToInt64(Result) < 0)
                {
                    bbl.ShowMessage("E109");
                    return false;
                }
            }

            if (col == 8 || col == 12 || col == 15)
            {
                if (!ColKonkaiShukkaSiziSuu(row, col))
                {
                  return false;
                }
            }
            return true;
        }
        private bool ColKonkaiShukkaSiziSuu(int row, int col)
        {            
            if (col == 12)
            {
                int MaxLength = ((DataGridViewTextBoxColumn)dgvShukkasizi.Columns[12]).MaxInputLength;

                string byte_text = dgvShukkasizi.Rows[row].Cells[12].EditedFormattedValue.ToString();
                if (cf.IsByteLengthOver(MaxLength, byte_text))
                {
                    MessageBox.Show("入力された文字が長すぎます", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvShukkasizi.CurrentCell = dgvShukkasizi.Rows[row].Cells[12];
                    return false;
                }
            }
            else if (col == 15)
            {
                if (dgvShukkasizi.Rows[row].Cells["SoukoCD"].EditedFormattedValue.ToString().Equals("") && (!dgvShukkasizi.Rows[row].Cells["colKonkaiShukkaSiziSuu"].EditedFormattedValue.ToString().Equals("0")))
                {
                    bbl.ShowMessage("E102");
                    dgvShukkasizi.Rows[row].Cells["SoukoName"].Value = string.Empty;
                    dgvShukkasizi.CurrentCell = dgvShukkasizi.Rows[row].Cells["SoukoCD"];
                    return false;
                }
            }
            else
            {
                string value = dgvShukkasizi.Rows[row].Cells["colKonkaiShukkaSiziSuu"].EditedFormattedValue.ToString().Replace(",", "");
                string value1 = dgvShukkasizi.Rows[row].Cells["colShukkakanousuu"].EditedFormattedValue.ToString().Replace(",", "");
                if (Convert.ToInt64(value) > Convert.ToInt64(value1))
                {
                    bbl.ShowMessage("E143", "出荷可能数", "大きい");
                    dgvShukkasizi.CurrentCell = dgvShukkasizi.Rows[row].Cells["colKonkaiShukkaSiziSuu"];
                    return false;
                }

                string value2 = dgvShukkasizi.Rows[row].Cells["colJuchuuSuu"].EditedFormattedValue.ToString().Replace(",", "");
                string value3 = dgvShukkasizi.Rows[row].Cells["colShukkaSiziZumiSuu"].EditedFormattedValue.ToString().Replace(",", "");
                if (Convert.ToInt64(value) != 0 && Convert.ToInt64(value) > (Convert.ToInt64(value2) - Convert.ToInt64(value3)))        //add new condition(Convert.ToInt64(value) != 0) by tza to avoid showing error msg even the input value is 0
                {
                    bbl.ShowMessage("E143", "未出荷指示数", "大きい");
                    return false;
                }

            }
            return true;
        }
        private bool F11_Gridivew_ErrorCheck()
        {
            bool bl_error = false;

            foreach (DataGridViewRow gv in dgvShukkasizi.Rows)
            {
                if (gv.Cells["colKonkaiShukkaSiziSuu"].EditedFormattedValue.ToString() != "0")
                {
                    for (int i = 0; i < gv.Cells.Count; i++)
                    {
                        string colName = dgvShukkasizi.Columns[i].Name;
                        if (colName == "colKonkaiShukkaSiziSuu" || colName == "colTanka" || colName == "colPrice" ||colName== "colDetails"|| colName == "SoukoCD")
                        {
                            if (!Grid_ErrorCheck(gv.Index, i))
                            {
                                dgvShukkasizi.CurrentCell = dgvShukkasizi.Rows[gv.Index].Cells[i];
                                bl_error = true;
                                break;
                            }
                        }
                    }
                }
                if (bl_error)
                    return true;
            }
            return bl_error;
        }
        private void F11_Clear()
        {
            txtJuchuuNo.Clear();
            txtSenpyouhachuuNo.Clear();
            txtYubin1.Clear();
            txtYubin2.Clear();
            txtAddress.Clear();
            txtPhone1.Clear();
            txtPhone2.Clear();
            txtPhone3.Clear();
            txtName.Clear();
            txtAddress.Clear();
        }

        //Mode_Procedure
        private void FunctionProcedure(int tagID)
        {
            switch (tagID)
            {
                case 8:
                    if (dtGS1.Rows.Count > 0)
                    {
                        var dtConfirm = dtGS1.AsEnumerable().OrderBy(r => r.Field<string>("SKMSNO")).ThenBy(r => r.Field<string>("ShouhinCD")).CopyToDataTable();
                        dgvShukkasizi.DataSource = dtConfirm;
                    }
                    else
                    {
                        DataTable dt = new DataTable();
                        dt = CreateTable_Details();
                        dgvShukkasizi.DataSource = dt;
                    }
                    break;
                case 10:
                    sksz_bl = new ShukkasiziNyuuryokuBL();
                    DataTable dt1 = new DataTable();
                    if (!string.IsNullOrWhiteSpace(txtJuchuuNo.Text))
                    {
                        dt1 = sksz_bl.JuchuuNo_Check(txtJuchuuNo.Text, "E133");
                        if (dt1.Rows[0]["MessageID"].ToString().Equals("E133"))
                        {
                            bbl.ShowMessage("E133");
                            txtJuchuuNo.Focus();
                            return;
                        }
                    }

                    if (cboMode.SelectedValue.ToString().Equals("2"))
                    {
                        dtGridview(1);
                    }
                    else
                    {
                        dtGridview(2);
                    }
                    dtHaita = dtgv1.Copy();
                    dgvShukkasizi.ActionType = "F10";  //to skip gv error check at the ErrorCheck() of BaseForm.cs
                    bool count = false;
                    //Table_Y/排他テーブルに追加
                    if (dtgv1.Rows.Count > 0)
                    {
                        var dtRow = dtgv1.AsEnumerable().OrderBy(r => r.Field<string>("SKMSNO")).ThenBy(r => r.Field<string>("JuchuuNO")).CopyToDataTable();
                        JuchuuNO_Delete();
                        foreach (DataRow dr in dtRow.Rows)
                        {
                            string JuchuuNO = dr["JuchuuNO"].ToString();
                            sksz_e = new ShukkaSiziNyuuryokuEntity();
                            sksz_e.DataKBN = 1;
                            sksz_e.Number = JuchuuNO;
                            sksz_e.ProgramID = ProgramID;
                            sksz_e.PC = PCID;
                            sksz_e.OperatorCD = OperatorCD;
                            DataTable dt = new DataTable();
                            sksz_bl = new ShukkasiziNyuuryokuBL();
                            dt = sksz_bl.D_Exclusive_Lock_Check(sksz_e);

                            if (dt.Rows[0]["MessageID"].ToString().Equals("S004"))
                            {
                                count = true;
                                Data1 = dt.Rows[0]["Program"].ToString();
                                Data2 = dt.Rows[0]["Operator"].ToString();
                                Data3 = dt.Rows[0]["PC"].ToString();
                                Gvrow_Delete(dr);
                            }
                        }
                    }
                    if (count)
                    {
                        bbl.ShowMessage("S004", Data1, Data2, Data3);
                    }
                    dgvShukkasizi.DataSource = dtHaita;
                    if(dtHaita.Rows.Count>0)
                    {
                        dgvShukkasizi.CurrentCell = dgvShukkasizi.Rows[0].Cells["colKonkaiShukkaSiziSuu"];
                        dgvShukkasizi.Focus();
                    }
                    dgvShukkasizi.Columns["colKonkaiShukkaSiziSuu"].ReadOnly = false;
                    dgvShukkasizi.Columns["chk"].ReadOnly = false;
                    break;
                case 11:
                    if ( !F11_Gridivew_ErrorCheck())
                    {                      
                        foreach (DataGridViewRow gv in dgvShukkasizi.Rows)
                        {
                            if (gv.Cells["colKonkaiShukkaSiziSuu"].EditedFormattedValue.ToString() != "0")
                            {
                                DataRowAdd(gv.Index);
                            }
                            else
                            {
                                //0に変更された場合はワークテーブルから削除
                                if (dtGS1.Rows.Count > 0)
                                {
                                    for (int i = dtGS1.Rows.Count - 1; i >= 0; i--)
                                    {
                                        string data = dtGS1.Rows[i]["SKMSNO"].ToString();
                                        if (gv.Cells["colJuchuuNo"].Value.ToString() == data)
                                        {
                                            dtGS1.Rows[i].Delete();
                                        }
                                    }
                                }
                            }
                        }
                        F11_Clear();
                        txtJuchuuNo.Focus();
                        dgvShukkasizi.ClearSelection();
                        DataTable dt = new DataTable();
                        dt = CreateTable_Details();
                       dgvShukkasizi.DataSource = dt;
                        dgvShukkasizi.Memory_Row_Count = dtGS1.Rows.Count;
                    }
                    break;
            }
        }
        private bool ShippingNO_Check()
        {
            sksz_e = new ShukkaSiziNyuuryokuEntity();
            sksz_e.DataKBN = 12;
            sksz_e.Number = sbShippingNO.Text;
            sksz_e.ProgramID = ProgramID;
            sksz_e.PC = PCID;
            sksz_e.OperatorCD = OperatorCD;
            DataTable dtshippingno = new DataTable();
            sksz_bl = new ShukkasiziNyuuryokuBL();
            dtshippingno = sksz_bl.D_Exclusive_Lock_Check(sksz_e);
            if (dtshippingno.Rows[0]["MessageID"].ToString().Equals("1"))
            {
                return true;
            }
            Data1 = dtshippingno.Rows[0]["Program"].ToString();
            Data2 = dtshippingno.Rows[0]["Operator"].ToString();
            Data3 = dtshippingno.Rows[0]["PC"].ToString();
            return false;
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
            dgvShukkasizi.Memory_Row_Count = 0;
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
                    SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", true);
                    SetButton(ButtonType.BType.Display, F10, "表示(F10)", true);
                    SetButton(ButtonType.BType.Memory, F11, "保存(F11)", true);

                    break;

                case 2://F3
                    cf.Clear(PanelTitle);
                    cf.Clear(PanelDetail);
                    cf.EnablePanel(PanelTitle);
                    cf.DisablePanel(PanelDetail);
                    sbShippingNO.Focus();
                    rdoNeed.Checked = true;
                    SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", false);
                    SetButton(ButtonType.BType.Display, F10, "表示(F10)", false);
                    SetButton(ButtonType.BType.Memory, F11, "保存(F11)", false);
                    break;

                case 3:
                    lblTokuisakiName.Text = string.Empty;
                    lblKouritenName.Text = string.Empty;
                    lblStaffName.Text = string.Empty;
                    dtResult.Clear();
                    dtGS1.Clear();
                    break;

                case 4:  //start_Mode
                    SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
                    SetButton(ButtonType.BType.New, F2, "新規(F2)", true);
                    SetButton(ButtonType.BType.Update, F3, "修正(F3)", true);
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

        //Call_Function
        private void Gridview_F9ShowHide(int col, string type)
        {
            SCombo cbo = this.TopLevelControl.Controls.Find("cboMode", true)[0] as SCombo;
            Control[] ctrlArr = this.TopLevelControl.Controls.Find("BtnF9", true);
            if (dgvShukkasizi.Columns[col].Name == "SoukoCD")
            {
                Control btnF9 = ctrlArr[0];
                if (ctrlArr.Length > 0 && type == "Show")
                {
                    if (cbo.SelectedValue.Equals("3") || cbo.SelectedValue.Equals("4"))
                        btnF9.Visible = false;
                    else if (btnF9 != null)
                        btnF9.Visible = true;
                }
                else
                {
                    if (btnF9 != null)
                        btnF9.Visible = false;
                }
            }
            else
            {
                if (ctrlArr.Length > 0)
                {
                    Control btnF9 = ctrlArr[0];
                    if (btnF9 != null)
                        btnF9.Visible = false;
                }
            }
        }
        private string FormatPriceValue(string val)
        {
            string value = val.Replace(",", "");
            //int num;
            long num;
            int a = 0;

            if (Int64.TryParse(value, out num))
            {
                if (!val.Equals("0"))
                {
                    if (a != 0)
                    {
                        val = string.Format("{0:#,#.0}", num); ;
                        while (val.Split('.')[1].Length < a)
                        {
                            val = val + "0";
                        }
                    }
                    else
                        val = string.Format("{0:#,#}", num);
                }
            }
            else if (string.IsNullOrWhiteSpace(value))
            {
                if (a != 0)
                {
                    val = "0.0";
                    while (val.Split('.')[1].Length < a)
                    {
                        val = val + "0";
                    }
                }
                else
                    val = "0";
            }
            else
            {
                val = string.Format("{0:#,#}", value);

                string[] p = val.Split('.');
                if (a != p[1].Length)
                {
                    if (Int64.TryParse(p[0].ToString(), out num))
                    {
                        if (p[1].Length < a)
                        {
                            if (!p[0].ToString().Equals("0"))
                                val = string.Format("{0:#,#}", num) + "." + p[1].ToString();
                            else
                                val = num + "." + p[1].ToString();
                            while (val.Split('.')[1].Length < a)
                            {
                                val = Text + "0";
                            }
                        }
                        else
                        {
                            if (!p[0].ToString().Equals("0"))
                                val = string.Format("{0:#,#}", num) + "." + p[1].Substring(0, a);
                            else
                                val = num + "." + p[1].Substring(0, a);
                        }
                    }
                    else
                    {
                        bbl.ShowMessage("E118");
                    }
                }
                else
                {
                    val = p[0].ToString();
                    if (Int64.TryParse(Text, out num))
                    {
                        if (!val.Equals("0"))
                            val = string.Format("{0:#,#}", num);
                        val = val + "." + p[1].ToString();
                    }
                }
            }

            return val;
        }
        private void DataRowAdd(int row)
        {
            //data temp save
            if ((!dgvShukkasizi.Rows[row].Cells["colKonkaiShukkaSiziSuu"].EditedFormattedValue.ToString().Equals("0")))
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
        private DataTable CommaRemove(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                dt.Columns.Add("ShukkaSiziGyouNO");

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    for (int k = 5; k < 11; k++)
                    {
                        if (dt.Rows[j][k].ToString().Contains(","))
                        {
                            dt.Rows[j][k] = dt.Rows[j][k].ToString().Replace(",", "");
                        }
                    }
                    if (cboMode.SelectedValue.Equals("1"))
                        dt.Rows[j]["ShukkaSiziGyouNO"] = j + 1;
                    else
                        dt.Rows[j]["ShukkaSiziGyouNO"] = dt.Rows[j]["Hidden_ShukkaSiziGyouNO"];
                }
            }
            return dt;
        }

        //F12
        private void DBProcess()
        {
            try
            {
                (string, string, string) obj = GetInsert();
                sksz_bl = new ShukkasiziNyuuryokuBL();

                if (cboMode.SelectedValue.Equals("3"))//delete
                {
                    sksz_bl.ShukkasiziNyuuryoku_IUD(obj.Item1, obj.Item2, obj.Item3);
                    //sksz_bl.Get_HikiateFunctionNO("12", sbShippingNO.Text, "30", sksz_e.OperatorCD);
                    bbl.ShowMessage("I102");
                }
                else
                {
                    sksz_bl.ShukkasiziNyuuryoku_IUD(obj.Item1, obj.Item2, obj.Item3);
                    //if (cboMode.SelectedValue.Equals("1"))
                    //{
                    //    string FunctionNO = string.Empty;
                    //    FunctionNO = dtResult.Rows[0]["ShukkaSiziNO"].ToString();
                    //    if (!string.IsNullOrEmpty(FunctionNO))
                    //    {
                    //        sksz_bl.Get_HikiateFunctionNO("12", FunctionNO, "10", sksz_e.OperatorCD);
                    //    }
                    //}
                    //else if (cboMode.SelectedValue.Equals("2"))
                    //{
                    //    sksz_bl.Get_HikiateFunctionNO("12", sbShippingNO.Text, "20", sksz_e.OperatorCD);
                    //    sksz_bl.Get_HikiateFunctionNO("12", sbShippingNO.Text, "21", sksz_e.OperatorCD);
                    //}
                    bbl.ShowMessage("I101");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            else
            {
                dtShippingNO = new DataTable();
                dtShippingNO = sksz_bl.GetFunctionNO("12", txtShippingDate.Text, "0");
                dr["ShukkaSiziNO"] = dtShippingNO.Rows[0]["Column1"].ToString();
            }
            dr["StaffCD"] = sbStaffCD.Text;
            dr["ShukkaYoteiDate"] = txtShippingDate.Text;
            dr["DenpyouDate"] = txtSlipDate.Text;

            dr["TokuisakiCD"] = sbTokuisaki.Text;
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

            dr["ShukkaSiziDenpyouTekiyou"] = string.IsNullOrEmpty(txtSlip_Description.Text) ? null : txtSlip_Description.Text;
            dr["ShukkaSizishoHuyouKBN"] = rdoNO.Checked ? "1" : "0";
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
                dt = dtGridview(1);
                dt = CommaRemove(dt);
                Detail_XML = cf.DataTableToXml(dt);
                dt.Columns.Remove("ShukkaSiziGyouNO");
            }
            else
            {
                dtGS1 = CommaRemove(dtGS1);
                Detail_XML = cf.DataTableToXml(dtGS1);
                dtGS1.Columns.Remove("ShukkaSiziGyouNO");
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

            return (Mode, Header_XML, Detail_XML);
        }
    }
}
