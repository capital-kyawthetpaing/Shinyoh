using BL;
using CKM_CommonFunction;
using Entity;
using Shinyoh;
using Shinyoh_Details;
using Shinyoh_Search;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShukkaNyuuryoku {
    public partial class ShukkaNyuuryoku : BaseForm {
        multipurposeEntity multi_Entity;
        CommonFunction cf;
        StaffBL staffBL;
        BaseBL bbl;
        BaseEntity base_Entity;
        ShukkaNyuuryokuEntity obj;
        ShukkaNyuuryokuBL bl;
        TokuisakiDetail tokuisakiDetail;//= new TokuisakiDetail();
        KouritenDetail kouritenDetail;// = new KouritenDetail();
        string YuuBinNO1 = string.Empty;
        string YuuBinNO2 = string.Empty;
        string Address = string.Empty;
        public string Detail_XML;
        DataTable Main_dt, Temptb1, gvdt1, F8_dt1, dtClear, dtHaita;
        string Data1 = string.Empty, Data2 = string.Empty, Data3 = string.Empty;
        public ShukkaNyuuryoku()
        {
            InitializeComponent();
            multi_Entity = new multipurposeEntity();
            cf = new CommonFunction();
            bbl = new BaseBL();
            staffBL = new StaffBL();
            Main_dt = new DataTable();
            Temptb1 = new DataTable();
            gvdt1 = new DataTable();
            F8_dt1 = CreateTable();
            dtHaita = new DataTable();
            dtClear = CreateTable();

            //this.gvShukka1.Size = new System.Drawing.Size(1300, 387);
        }

        private void ShukkaNyuuryoku_Load(object sender, EventArgs e)
        {
            ProgramID = "ShukkaNyuuryoku";
            StartProgram();
            cboMode.Bind(false, multi_Entity);

            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "新規(F2)", true);
            SetButton(ButtonType.BType.Update, F3, "修正(F3)", true);
            SetButton(ButtonType.BType.Delete, F4, "削除(F4)", true);
            SetButton(ButtonType.BType.Inquiry, F5, "照会(F5)", true);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", true);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", true);
            SetButton(ButtonType.BType.Display, F10, "表示(F10)", true);
            SetButton(ButtonType.BType.Memory, F11, "保存(F11)", true);

            txtTokuisaki.lblName = lblTokuisakiName;
            txtKouriten.lblName = lblKouritenName;
            txtStaff.lblName = lblStatffName;

            txtTokuisaki.ChangeDate = txtShukkaDate;
            txtKouriten.ChangeDate = txtShukkaDate;
            txtStaff.ChangeDate = txtShukkaDate;

            base_Entity = _GetBaseData();

            txtShukkaNo.ChangeDate = txtShukkaDate;
            txtShukkaSijiNo.ChangeDate = txtShukkaYoteiDate1;

            current_gv.SetGridDesign();
            current_gv.SetHiraganaColumn("col_Detail");
            current_gv.SetReadOnlyColumn("col_JANCD,col_Shouhin,col_ShouhinName,col_ColorShortName,col_ColorNO,col_Size,col_Shukkazansuu,col_Miryoku,col_ShukkaSiziNOGyouNO");
            current_gv.SetNumberColumn("col_Konkai");
            current_gv.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            current_gv.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            current_gv.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            current_gv.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            current_gv.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            current_gv.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
            current_gv.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            current_gv.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
            txtKouriten.TxtBox = txtTokuisaki;

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
                Mode_Setting();
                if (cboMode.SelectedValue.Equals("1"))
                {
                    cf.EnablePanel(PanelDetail);
                    cf.DisablePanel(PanelTitle);
                    txtShukkaDate.Focus();
                }
               F8_dt1.Clear();

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
            if (tagID == "9")
            {
                ShukkaNoSearch shukka = new ShukkaNoSearch();
                shukka.ShowDialog();
            }
            if (tagID == "10")
            {
                F10_Show();
            }
            if (tagID == "11")
            {
                F11_Save();
            }
            if (tagID == "12")
            {
                if (F8_dt1.Rows.Count > 0 || gvdt1.Rows.Count > 0)
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
            try
            {
                (string, string, string) obj = GetInsert();
                ShukkaNyuuryokuBL sBL = new ShukkaNyuuryokuBL();
                // Konkai_Price(F8_dt1);
                string return_Bl = sBL.ShukkaNyuuryoku_CUD(obj.Item1, obj.Item2, obj.Item3);
                Konkai_Price(F8_dt1);
                Juchuu_Price(F8_dt1);
                if (return_Bl == "true")
                    bbl.ShowMessage("I101");
                gvdt1.Clear();
                F8_dt1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
            }
        }
        private void Konkai_Price(DataTable dtTemp1)
        {
            foreach (DataRow dr in dtTemp1.Rows)
            {
                string shukkasuu = dr["ShukkaSuu"].ToString();
                string ShukkaSiziNOGyouNO = dr["ShukkaSiziNOGyouNO"].ToString();
                string ShouhinCD = dr["ShouhinCD"].ToString();
                bl.Shukka_Price(shukkasuu, ShukkaSiziNOGyouNO, ShouhinCD);
            }
        }
        private void Juchuu_Price(DataTable dtTemp1)
        {
            foreach (DataRow dr in dtTemp1.Rows)
            {
                string shukkasuu = dr["ShukkaSuu"].ToString();
                string JuchuuNOGyouNO = dr["JuchuuNOGyouNO"].ToString();
                string ShouhinCD = dr["ShouhinCD"].ToString();
                bl.JuchuuShousai_Price(shukkasuu, JuchuuNOGyouNO, ShouhinCD);
            }
        }

        private (string, string, string) GetInsert()
        {
            TokuisakiEntity t_obj = tokuisakiDetail.Access_Tokuisaki_obj;
            KouritenEntity k_obj = kouritenDetail.Access_Kouriten_obj;

            DataTable dtResult = new DataTable();
            Create_Datatable_Column(dtResult);

            DataRow dr = dtResult.NewRow();
            ShukkaNyuuryokuBL sBL = new ShukkaNyuuryokuBL();
            if (cboMode.SelectedValue.ToString() != "1")
            {
                dr["ShukkaNO"] = txtShukkaNo.Text;
            }

            dr["StaffCD"] = txtStaff.Text;
            dr["ShukkaDate"] = txtShukkaDate.Text;

            dr["TokuisakiCD"] = txtTokuisaki.Text;
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

            dr["KouritenCD"] = txtKouriten.Text;
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

            dr["ShukkaDenpyouTekiyou"] = string.IsNullOrEmpty(txtDenpyou.Text) ? null : txtDenpyou.Text;
            dr["InsertOperator"] = base_Entity.OperatorCD;
            dr["UpdateOperator"] = base_Entity.OperatorCD;
            dr["PC"] = base_Entity.PC;
            dr["ProgramID"] = base_Entity.ProgramID;

            DataRow dr1 = dtResult.NewRow();
            for (int i = 0; i < dtResult.Columns.Count; i++)
            {
                dr1[i] = string.IsNullOrEmpty(dr[i].ToString().Trim()) ? null : dr[i].ToString();
            }
            dtResult.Rows.Add(dr1);
            string Header_XML = cf.DataTableToXml(dtResult);
            if (cboMode.SelectedValue.ToString().Equals("3"))
            {
                //DataTable dt = new DataTable();
                //dt = dtGridview(1);
                Detail_XML = cf.DataTableToXml(gvdt1);
            }
            else
            {
                Detail_XML = cf.DataTableToXml(F8_dt1);
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
        private void ChangeMode(Mode mode)
        {
            Mode_Setting();
            switch (mode)
            {
                case Mode.New:
                    ErrorCheck();
                    txtShukkaNo.E102Check(false);
                    txtShukkaNo.E133Check(false, "ShukkaNyuuryoku", txtShukkaNo, null, null);
                    //txtShukkaNo.E160Check(false, "ShukkaNyuuryoku", txtShukkaNo, null);
                    txtShukkaNo.E165Check(false, "ShukkaNyuuryoku", txtShukkaNo, null);

                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    cboMode.Enabled = false;
                    txtShukkaNo.Enabled = false;
                    cf.EnablePanel(PanelDetail);
                    txtShukkaDate.Focus();
                    SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", true);
                    SetButton(ButtonType.BType.Display, F10, "表示(F10)", true);
                    SetButton(ButtonType.BType.Memory, F11, "保存(F11)", true);
                    tokuisakiDetail = new TokuisakiDetail();
                    kouritenDetail = new KouritenDetail();
                    break;

                case Mode.Update:
                    ErrorCheck();
                    txtShukkaNo.E102Check(true);
                    txtShukkaNo.E133Check(true, "ShukkaNyuuryoku", txtShukkaNo, null, null);
                    //txtShukkaNo.E160Check(true, "ShukkaNyuuryoku", txtShukkaNo, null);
                    txtShukkaNo.E165Check(true, "ShukkaNyuuryoku", txtShukkaNo, null);

                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    txtShukkaNo.Focus();
                    gvdt1.Clear();
                    F8_dt1.Clear();

                    tokuisakiDetail = new TokuisakiDetail();
                    kouritenDetail = new KouritenDetail();
                    break;
                case Mode.Delete:
                    ErrorCheck();
                    txtShukkaNo.E102Check(true);
                    txtShukkaNo.E133Check(true, "ShukkaNyuuryoku", txtShukkaNo, null, null);
                    //txtShukkaNo.E160Check(true, "ShukkaNyuuryoku", txtShukkaNo, null);
                    txtShukkaNo.E165Check(true, "ShukkaNyuuryoku", txtShukkaNo, null);

                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;
                    txtShukkaNo.Focus();

                    tokuisakiDetail = new TokuisakiDetail(false);
                    kouritenDetail = new KouritenDetail(false);
                    break;
                case Mode.Inquiry:
                    txtShukkaNo.E102Check(true);
                    txtShukkaNo.E133Check(true, "ShukkaNyuuryoku", txtShukkaNo, null, null);
                    txtShukkaNo.E160Check(true, "ShukkaNyuuryoku", txtShukkaNo, null);

                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;
                    txtShukkaNo.Focus();

                    tokuisakiDetail = new TokuisakiDetail(false);
                    kouritenDetail = new KouritenDetail(false);
                    break;
            }
        }
        public void Create_Datatable_Column(DataTable create_dt)
        {
            create_dt.Columns.Add("ShukkaNO");
            create_dt.Columns.Add("StaffCD");
            create_dt.Columns.Add("ShukkaDate");
            create_dt.Columns.Add("ShukkaDenpyouTekiyou");

            create_dt.Columns.Add("TokuisakiCD");
            create_dt.Columns.Add("TokuisakiName");
            create_dt.Columns.Add("TokuisakiRyakuName");
            create_dt.Columns.Add("TokuisakiYuubinNO1");
            create_dt.Columns.Add("TokuisakiYuubinNO2");
            create_dt.Columns.Add("TokuisakiJuusho1");
            create_dt.Columns.Add("TokuisakiJuusho2");
            create_dt.Columns.Add("TokuisakiTel11");
            create_dt.Columns.Add("TokuisakiTel12");
            create_dt.Columns.Add("TokuisakiTel13");
            create_dt.Columns.Add("TokuisakiTel21");
            create_dt.Columns.Add("TokuisakiTel22");
            create_dt.Columns.Add("TokuisakiTel23");

            create_dt.Columns.Add("KouritenCD");
            create_dt.Columns.Add("KouritenName");
            create_dt.Columns.Add("KouritenRyakuName");
            create_dt.Columns.Add("KouritenYuubinNO1");
            create_dt.Columns.Add("KouritenYuubinNO2");
            create_dt.Columns.Add("KouritenJuusho1");
            create_dt.Columns.Add("KouritenJuusho2");
            create_dt.Columns.Add("KouritenTel11");
            create_dt.Columns.Add("KouritenTel12");
            create_dt.Columns.Add("KouritenTel13");
            create_dt.Columns.Add("KouritenTel21");
            create_dt.Columns.Add("KouritenTel22");
            create_dt.Columns.Add("KouritenTel23");

            create_dt.Columns.Add("InsertOperator");
            create_dt.Columns.Add("UpdateOperator");
            create_dt.Columns.Add("PC");
            create_dt.Columns.Add("ProgramID");
        }
        private void New_Mode()
        {
            BaseEntity baseEntity = _GetBaseData();
            txtShukkaDate.Text = baseEntity.LoginDate;

            StaffEntity staffEntity = new StaffEntity
            {
                StaffCD = OperatorCD
            };
            staffEntity = staffBL.GetStaffEntity(staffEntity);
            txtStaff.Text = OperatorCD;
            lblStatffName.Text = staffEntity.StaffName;
        }
        private void Mode_Setting()
        {
            cf.Clear(PanelTitle);
            cf.Clear(PanelDetail);

            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(PanelDetail);

            lblTokuisakiName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblKouritenName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblStatffName.BorderStyle = System.Windows.Forms.BorderStyle.None;

            lblTokuisakiName.Text = string.Empty;
            lblKouritenName.Text = string.Empty;
            lblStatffName.Text = string.Empty;

            F8_dt1 = CreateTable();

            BaseEntity be = new BaseEntity();
            be.ProgramID = ProgramID;
            be.OperatorCD = OperatorCD;
            be.PC = PCID;
            BaseBL bbl = new BaseBL();
            bbl.D_Exclusive_Number_Remove(be);

            if (cboMode.SelectedValue.Equals("2") || cboMode.SelectedValue.Equals("3") || cboMode.SelectedValue.Equals("4"))
            {
                txtShukkaNo.Focus();
                SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", false);
                SetButton(ButtonType.BType.Display, F10, "表示(F10)", false);
                SetButton(ButtonType.BType.Memory, F11, "保存(F11)", false);
            }else
                New_Mode();
        }
        private void FunctionProcedure(int tagID)
        {
            switch (tagID)
            {
                case 8:
                    if (F8_dt1.Rows.Count > 0)
                    {
                        if(F8_dt1.Columns.Contains("ShukkaSiziNO"))
                        {
                            F8_dt1.Columns.Remove("ShukkaSiziNO");
                        }
                        if (F8_dt1.Columns.Contains("UriageKanryouKBN"))
                        {
                            F8_dt1.Columns.Remove("UriageKanryouKBN");
                        }

                        F8_dt1.DefaultView.Sort = "JANCD";
                        current_gv.DataSource = F8_dt1.DefaultView.ToTable();
                        current_gv.Memory_Row_Count = F8_dt1.Rows.Count;

                      
                    }
                    else if(current_gv.Rows.Count > 0)
                    {
                        DataTable dtSource = (DataTable)current_gv.DataSource;
                        dtSource.Rows.Clear();
                    }             
                    break;
                case 10:
                    ShukkaSiziNo_Check();
                    if (cboMode.SelectedValue.ToString() == "1")
                    {
                        ShukkaNyuuryokuEntity obj = new ShukkaNyuuryokuEntity();
                        ShukkaNyuuryokuBL sBL = new ShukkaNyuuryokuBL();
                        BaseEntity baseEntity = _GetBaseData();
                        obj.TokuisakiCD = txtTokuisaki.Text;
                        obj.ShukkaSiziNO1 = txtShukkaSijiNo.Text;
                        obj.ShukkaDate1 = txtShukkaYoteiDate1.Text;
                        obj.ShukkaDate2 = txtShukkaYoteiDate2.Text;
                        obj.DenpyouDate1 = txtDenpyouDate1.Text;
                        obj.DenpyouDate2 = txtDenpyouDate2.Text;
                        obj.Yuubin1 = txtYubin1.Text;
                        obj.Yuubin2 = txtYubin2.Text;
                        obj.TelNO1 = txtTelNo1.Text;
                        obj.TelNO2 = txtTelNo2.Text;
                        obj.TelNO3 = txtTelNo3.Text;
                        obj.Name = txtName.Text;
                        obj.Juusho = txtJuusho.Text;
                        obj.ChangeDate = baseEntity.LoginDate;
                        obj.OperatorCD = OperatorCD;
                        obj.ProgramID = ProgramID;
                        obj.PC = PCID;

                        DataTable dt = sBL.ShukkaNyuuryoku_Display(obj);
                        if (dt.Rows.Count > 0)
                        {
                            //dt.Columns.Remove("SoukoCD");
                            dt.Columns.Remove("TokuisakiCD");
                            dt.Columns.Remove("KouritenCD");
                            //dt.Columns.Remove("ShouhinCD");
                            //dt.Columns.Remove("DenpyouDate");
                            //dt.Columns.Remove("JuchuuNOGyouNO");

                            //gvShukka1.DataSource = dt;
                            DataTable dt_temp = dt.Copy();
                            gvdt1 = dt_temp;

                            //if (obj.Condition == "1")
                            //{
                            //    gvShukka1.DataSource = dt;
                            //    DataTable dt_temp = dt.Copy();
                            //    gvdt1 = dt_temp;
                            //    //if (gvdt1.Rows.Count > 0)
                            //    //{
                            //    //    F8_dt1 = new DataTable();
                            //    //    F8_dt1 = CreateTable();
                            //    //}
                            //}
                            //else
                            //{
                            //    gvShukka1.DataSource = dt;
                            //    DataTable dt_temp = dt.Copy();
                            //    gvdt1 = dt_temp;
                            //    //if (gvdt1.Rows.Count > 0)
                            //    //{
                            //    //    F8_dt1 = new DataTable();
                            //    //    F8_dt1 = CreateTable();
                            //    //}
                            //}
                            //ShukkaSiZiNO_Delete();
                            current_gv.ActionType = "F10";  //to skip gv error check at the ErrorCheck() of BaseForm.cs
                            bool count = false;
                            foreach (DataRow dr in gvdt1.Rows)
                            {
                                bool exists = false;
                                if (F8_dt1.Rows.Count > 0)
                                {
                                    //重複行はDelete
                                    string ShukkaSiziNOGyouNO = dr["ShukkaSiziNOGyouNO"].ToString();
                                    DataRow existDr1 = F8_dt1.Select("ShukkaSiziNOGyouNO ='" + ShukkaSiziNOGyouNO + "'").SingleOrDefault();
                                    if (existDr1 != null)
                                    {
                                        dr["Kanryou"] = "9";    //未使用項目のため
                                        exists = true;
                                    }
                                }

                                if (!exists)
                                {
                                    string ShukkaSiziNO = dr["ShukkaSiziNO"].ToString();
                                    obj = new ShukkaNyuuryokuEntity();
                                    obj.DataKBN = 12;
                                    obj.Number = ShukkaSiziNO;
                                    obj.ProgramID = ProgramID;
                                    obj.PC = PCID;
                                    obj.OperatorCD = OperatorCD;

                                    DataTable dataTable = new DataTable();
                                    bl = new ShukkaNyuuryokuBL();
                                    dt = bl.D_Exclusive_Lock_Check(obj);
                                    if (dt.Rows[0]["MessageID"].ToString().Equals("S004"))
                                    {
                                        count = true;

                                        Data1 = dt.Rows[0]["Program"].ToString();
                                        Data2 = dt.Rows[0]["Operator"].ToString();
                                        Data3 = dt.Rows[0]["PC"].ToString();
                                        //Gvrow_Delete(dr);
                                        D_Exclusive_ShukkaSiziNO_Delete();
                                        bbl.ShowMessage("S004", Data1, Data2, Data3);
                                        return;
                                    }
                                }
                                if (count)
                                {
                                    bbl.ShowMessage("S004", Data1, Data2, Data3);
                                    return;
                                }
                            }

                            DataRow[] select_dr1 = gvdt1.Select("Kanryou = '9'");
                            foreach (DataRow dr in select_dr1)
                                gvdt1.Rows.Remove(dr);

                            dtHaita = gvdt1.Copy();

                            gvShukka1.DataSource = dtHaita;
                            gvShukka1.Columns[12].Visible = false;
                            gvShukka1.Columns[13].Visible = false;
                            gvShukka1.Columns[14].Visible = false;
                            gvShukka1.Columns[15].Visible = false;

                            if (dtHaita.Columns.Contains("ShukkaSiziNO"))
                                dtHaita.Columns.Remove("ShukkaSiziNO");
                            //gvShukka1.Rows[0].Cells[8].Value = "1";
                            //gvShukka1.Rows[1].Cells[8].Value = "1";
                            if (dtHaita.Rows.Count > 0)
                            {
                                current_gv.CurrentCell = current_gv.Rows[0].Cells["col_Konkai"];
                            }
                            //else
                            //{
                            //    if (PreviousCtrl != null)
                            //        PreviousCtrl.Focus();
                            //    return;
                            //}
                        }
                    }
                    else
                    {
                        Display();                        
                    }

                    break;
                case 11:
                    Function_F11();
                    break;
            }
        }   
        private void Display()
        {
            Main_dt = txtShukkaNo.IsDatatableOccurs;
            if (Main_dt.Rows.Count > 0)
            {
                if (!Main_dt.Columns.Contains("MessageID"))
                    Main_dt.Columns.Add("MessageID", typeof(string));
                From_DB_To_Form(Main_dt);
                if (current_gv.Columns.Contains("ShukkaSiziNO"))
                {
                    current_gv.Columns.Remove("ShukkaSiziNO");
                }
                if (current_gv.Columns.Contains("MessageID"))
                {
                    current_gv.Columns.Remove("MessageID");
                }
                if (Main_dt.Rows[0]["UriageKanryouKBN"].ToString().Equals("1"))
                {
                    current_gv.Columns["col_Konkai"].ReadOnly = true;
                    current_gv.Columns["col_Complete"].ReadOnly = true;
                    if(current_gv.Columns.Contains("UriageKanryouKBN"))
                    current_gv.Columns.Remove("UriageKanryouKBN");

                }
                else if (Main_dt.Rows[0]["UriageKanryouKBN"].ToString().Equals("0"))
                {
                    current_gv.Columns["col_Konkai"].ReadOnly = false;
                    current_gv.Columns["col_Complete"].ReadOnly = false;
                    if (current_gv.Columns.Contains("UriageKanryouKBN"))
                        current_gv.Columns.Remove("UriageKanryouKBN");
                }
            }
        }
        private void D_Exclusive_ShukkaSiziNO_Delete()
        {
            if (cboMode.SelectedValue.ToString() == "2" || cboMode.SelectedValue.ToString() == "1")//update
            {
                foreach (DataRow dr in gvdt1.Rows)
                {
                    string ShukkaSiziNO = dr["ShukkaSiziNO"].ToString();

                    DataRow[] selectRow = F8_dt1.Select("ShukkaSiziNO ='" + ShukkaSiziNO + "'");
                    if (selectRow.Length > 0)
                        continue;

                    ChakuniNyuuryoku_Entity chkLockEntity = new ChakuniNyuuryoku_Entity();
                    chkLockEntity.DataKBN = 12;
                    chkLockEntity.Number = ShukkaSiziNO;
                    chkLockEntity.ProgramID = ProgramID;
                    chkLockEntity.PC = PCID;
                    chkLockEntity.OperatorCD = OperatorCD;
                    bl.D_Exclusive_ShukkaSiziNO_Delete(chkLockEntity);
                }
            }
        }
        //private void Gvrow_Delete(DataRow dr)
        //{
        //    DataRow[] existDr1 = dtHaita.Select("ShukkaSiziNO ='" + dr["ShukkaSiziNO"] + "'");

        //    foreach (DataRow row in existDr1)
        //    {
        //        dtHaita.Rows.Remove(row);// Here The given DataRow is not in the current DataRowCollection
        //    }
        //}
        private void Function_F11()
        {
            if (F11_Gridivew_ErrorCheck())
                return;
            else
                F11_Gridview_Bind();           
        }
        private void F11_Gridview_Bind()
        {         
            if (!F8_dt1.Columns.Contains("ShukkaSiziNO"))
            {
                F8_dt1.Columns.Add("ShukkaSiziNO", typeof(string));
            }        
            for (int t = 0; t < current_gv.RowCount; t++)
            {

                //bool bl = false;
                // grid 1 checkingTemptb1
                DataRow F8_drNew = F8_dt1.NewRow();// save updated data 
                DataGridViewRow row = current_gv.Rows[t];// grid view data
                string JANCD = row.Cells["col_JANCD"].Value.ToString();
                string HinbanCD = row.Cells["col_Shouhin"].Value.ToString();
                string Konkai = row.Cells["col_Konkai"].Value.ToString();
                string ShukkaSiziNOGyouNO = row.Cells["col_ShukkaSiziNOGyouNO"].Value.ToString();
                //string chk_value = row.Cells["colComplete"].EditedFormattedValue.ToString();
                string Detail = row.Cells["col_Detail"].EditedFormattedValue.ToString();

                //string color = row.Cells["colColorNO"].Value.ToString();
                //string size = row.Cells["colSize"].Value.ToString();

                DataRow[] select_dr1 = gvdt1.Select("ShukkaSiziNOGyouNO ='" + ShukkaSiziNOGyouNO + "'");// original data
                //DataRow[] select_dr1 = gvdt1.Select("HinbanCD ='" + HinbanCD + "'");// original data
                // DataRow existDr1 = F8_dt1.Select("JANCD ='" + JANCD + "' and ShukkaSuu='" + Konkai + "' and ShukkaSiziNOGyouNO='" + ShukkaSiziNOGyouNO + "'").SingleOrDefault();
                DataRow existDr1 = F8_dt1.Select("ShukkaSiziNOGyouNO='" + ShukkaSiziNOGyouNO + "'").SingleOrDefault();
                if (existDr1 != null)
                {
                    if (row.Cells["colKonkai"].Value.ToString() == "0")
                    {
                        F8_dt1.Rows.Remove(existDr1);
                        existDr1 = null;
                    }
                }
                F8_drNew[0] = JANCD;
                if (row.Cells["colKonkai"].Value.ToString() != "0" || row.Cells["colComplete"].Value.ToString() == "1")
                {
                    for (int c = 1; c < current_gv.Columns.Count; c++)
                    {
                        if (current_gv.Columns[c].Name == "col_Konkai" || current_gv.Columns[c].Name == "col_Detail")
                        {
                            if (existDr1 != null)
                            {
                                if (select_dr1[0][c].ToString() != row.Cells[c].Value.ToString())
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
                    // }
                }
            }          
            current_gv.Memory_Row_Count = F8_dt1.Rows.Count;          
            Focus_Clear();
        }

        private void Focus_Clear()
        {
            txtShukkaSijiNo.Focus();
            txtShukkaYoteiDate1.Clear();
            txtShukkaYoteiDate2.Clear();
            txtDenpyouDate1.Clear();
            txtDenpyouDate2.Clear();
            txtYubin1.Clear();
            txtYubin2.Clear();
            txtJuusho.Clear();
            txtTelNo1.Clear();
            txtTelNo2.Clear();
            txtTelNo3.Clear();
            txtName.Clear();
            current_gv.DataSource = dtClear;
        }

        private bool F11_Gridivew_ErrorCheck()
        {
            bool bl_error = false;

            foreach (DataGridViewRow gv in current_gv.Rows)
            {
                if (gv.Cells["col_Konkai"].Value.ToString() != "0")
                {
                    for (int i = 0; i < gv.Cells.Count; i++)
                    {
                        string colName = current_gv.Columns[i].Name;
                        if (colName == "col_Konkai" || colName == "col_Detail")
                        {
                            if (ErrorCheck_CellEndEdit(gv.Index, i))
                            {
                                current_gv.CurrentCell = current_gv.Rows[gv.Index].Cells[i];
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
        private bool ErrorCheck_CellEndEdit(int row, int col)
        {

            string Konkai = gvShukka1.Rows[row].Cells["colKonkai"].Value.ToString();
            string a = gvShukka1.Rows[row].Cells["colShukkazansuu"].Value.ToString();
            string b = gvShukka1.Rows[row].Cells["colMiryoku"].Value.ToString();
            string old = cboMode.SelectedValue.ToString().Equals("2") ? gvShukka1.Rows[row].Cells["OldShukkasuu"].Value.ToString() : "0";
            if (old == "")
                old = "0";

            decimal c = Convert.ToDecimal(old) +Convert.ToDecimal(a) - Convert.ToDecimal(b);

            bool bl_error = false;
            string col_Name = current_gv.Columns[col].Name;

            if (col_Name == "col_Konkai")
            {
                string split_val = current_gv.Rows[row].Cells["col_Konkai"].EditedFormattedValue.ToString().Replace(",", "");
                int Konkai_Number = string.IsNullOrEmpty(current_gv.Rows[row].Cells["col_Konkai"].EditedFormattedValue.ToString()) ? 0 : Convert.ToInt32(split_val);
                current_gv.Rows[row].Cells["col_Konkai"].Value = Konkai_Number.ToString();

                if (Konkai_Number < 0)
                {
                    bbl.ShowMessage("E109");
                    bl_error = true;
                }
                else if (Convert.ToDecimal(Konkai_Number) > c)
                {
                    bbl.ShowMessage("E143", "出荷残数 - 未入荷数", "大きい");
                    bl_error = true;
                }
                return bl_error;
            }
            if (col_Name == "col_Detail")
            {
                int MaxLength = ((DataGridViewTextBoxColumn)current_gv.Columns[col_Name]).MaxInputLength;

                string byte_text = current_gv.Rows[row].Cells[col_Name].EditedFormattedValue.ToString();
                if (cf.IsByteLengthOver(MaxLength, byte_text))
                {
                    MessageBox.Show("入力された文字が長すぎます", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bl_error = true;
                    return bl_error;
                }
            }
            return bl_error;
        }

        private void ShukkaSiZiNO_Delete()
        {
            obj = new ShukkaNyuuryokuEntity();
            obj.DataKBN = 12;
            obj.OperatorCD = OperatorCD;
            obj.ProgramID = ProgramID;
            obj.PC = PCID;
            bl = new ShukkaNyuuryokuBL();
            bl.D_Exclusive_ShukkaSiZiNo_Delete(obj);
        }
        private void ErrorCheck()
        {
            txtShukkaDate.E102Check(true);
            txtShukkaDate.E103Check(true);
            txtShukkaDate.E115Check(true, "ShukkaNyuuryoku", txtShukkaDate);

            txtTokuisaki.E102Check(true);
            txtTokuisaki.E101Check(true, "M_Tokuisaki", txtTokuisaki, txtShukkaDate, null);
            txtTokuisaki.E267Check(true, "M_Tokuisaki", txtTokuisaki, txtShukkaDate);
            txtTokuisaki.E227Check(true, "M_Tokuisaki", txtTokuisaki, txtShukkaDate);

            txtKouriten.E102Check(true);
            txtKouriten.E101Check(true, "M_Kouriten", txtKouriten, txtShukkaDate, null);
            txtKouriten.E267Check(true, "M_Kouriten", txtKouriten, txtShukkaDate);
            txtKouriten.E227Check(true, "M_Kouriten", txtKouriten, txtShukkaDate);

            txtStaff.E102Check(true);
            txtStaff.E101Check(true, "M_Staff", txtStaff, txtShukkaDate, null);
            txtStaff.E135Check(true, "M_Staff", txtStaff, txtShukkaDate);

            //txtShukkaSijiNo.E133Check(true, "ShukkaNyuuryoku", txtShukkaSijiNo, null, null);

            txtShukkaYoteiDate1.E103Check(true);
            txtShukkaYoteiDate2.E103Check(true);
            txtShukkaYoteiDate2.E104Check(true, txtShukkaYoteiDate1, txtShukkaYoteiDate2);

            txtDenpyouDate1.E103Check(true);
            txtDenpyouDate2.E103Check(true);
            txtDenpyouDate2.E104Check(true, txtDenpyouDate1, txtDenpyouDate2);

            txtYubin2.E102MultiCheck(true, txtYubin1, txtYubin2);
            txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, null, null);
        }
        private void btnDetail1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTokuisaki.Text) && tokuisakiDetail.Access_Tokuisaki_obj.TokuisakiCD != null)
            {
                if (!tokuisakiDetail.Access_Tokuisaki_obj.TokuisakiCD.ToString().Equals(txtTokuisaki.Text))
                {
                    bbl.ShowMessage("E269", "出荷指示時", "得意先");
                    txtTokuisaki.Focus();
                }
                else
                {
                    tokuisakiDetail.ShowDialog();
                }
            }
            else if (!string.IsNullOrWhiteSpace(txtTokuisaki.Text))
            {
                txtTokuisaki.Focus();
            }
        }

        private void btnDetail2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtKouriten.Text) && kouritenDetail.Access_Kouriten_obj.KouritenCD != null)
            {
                if (!kouritenDetail.Access_Kouriten_obj.KouritenCD.ToString().Equals(txtKouriten.Text))
                {
                    bbl.ShowMessage("E269", "出荷指示時", "小売店");
                    txtKouriten.Focus();
                }
                else
                {
                    kouritenDetail.ShowDialog();
                }
            }
            else if (!string.IsNullOrWhiteSpace(txtKouriten.Text))
            {
                txtKouriten.Focus();
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
                        txtJuusho.Text = dt.Rows[0]["Juusho1"].ToString();
                    }
                    else
                    {
                        if (txtYubin1.Text != YuuBinNO1 || txtYubin2.Text != YuuBinNO2)
                        {
                            txtJuusho.Text = string.Empty;
                        }
                        else
                        {
                            txtJuusho.Text = Address;
                        }
                    }
                }

            }
        }
        private TokuisakiEntity From_DB_To_Tokuisaki(DataTable dt)
        {
            TokuisakiEntity obj = new TokuisakiEntity();
            obj.TokuisakiCD = dt.Rows[0]["TokuisakiCD"].ToString();
            obj.TokuisakiRyakuName = dt.Rows[0]["TokuisakiRyakuName"].ToString();
            obj.TokuisakiName = dt.Rows[0]["TokuisakiName"].ToString();
            if (dt.Columns.Contains("TokuisakiYuubinNO1"))
                obj.YuubinNO1 = dt.Rows[0]["TokuisakiYuubinNO1"].ToString();
            else
                obj.YuubinNO1 = dt.Rows[0]["YuubinNO1"].ToString();
            if (dt.Columns.Contains("TokuisakiYuubinNO2"))
                obj.YuubinNO2 = dt.Rows[0]["TokuisakiYuubinNO2"].ToString();
            else
                obj.YuubinNO2 = dt.Rows[0]["YuubinNO2"].ToString();
            if (dt.Columns.Contains("TokuisakiJuusho1"))
                obj.Juusho1 = dt.Rows[0]["TokuisakiJuusho1"].ToString();
            else
                obj.Juusho1 = dt.Rows[0]["Juusho1"].ToString();
            if (dt.Columns.Contains("TokuisakiJuusho2"))
                obj.Juusho2 = dt.Rows[0]["TokuisakiJuusho2"].ToString();
            else
                obj.Juusho2 = dt.Rows[0]["Juusho2"].ToString();
            if (dt.Columns.Contains("TokuisakiTelNO1-1"))
                obj.Tel11 = dt.Rows[0]["TokuisakiTelNO1-1"].ToString();
            else
                obj.Tel11 = dt.Rows[0]["Tel11"].ToString();
            if (dt.Columns.Contains("TokuisakiTelNO1-2"))
                obj.Tel12 = dt.Rows[0]["TokuisakiTelNO1-2"].ToString();
            else
                obj.Tel12 = dt.Rows[0]["Tel12"].ToString();
            if (dt.Columns.Contains("TokuisakiTelNO1-3"))
                obj.Tel13 = dt.Rows[0]["TokuisakiTelNO1-3"].ToString();
            else
                obj.Tel13 = dt.Rows[0]["Tel13"].ToString();
            if (dt.Columns.Contains("TokuisakiTelNO2-1"))
                obj.Tel21 = dt.Rows[0]["TokuisakiTelNO2-1"].ToString();
            else
                obj.Tel21 = dt.Rows[0]["Tel21"].ToString();
            if (dt.Columns.Contains("TokuisakiTelNO2-2"))
                obj.Tel22 = dt.Rows[0]["TokuisakiTelNO2-2"].ToString();
            else
                obj.Tel22 = dt.Rows[0]["Tel22"].ToString();
            if (dt.Columns.Contains("TokuisakiTelNO2-3"))
                obj.Tel23 = dt.Rows[0]["TokuisakiTelNO2-3"].ToString();
            else
                obj.Tel23 = dt.Rows[0]["Tel23"].ToString();
            return obj;
        }
        private void EnablePanel()
        {
            cf.EnablePanel(PanelDetail);
            txtShukkaNo.Focus();
            cf.DisablePanel(PanelTitle);
            SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", true);
            SetButton(ButtonType.BType.Display, F10, "表示(F10)", true);
            SetButton(ButtonType.BType.Memory, F11, "保存(F11)", true);
        }
        private void txtTokuisaki_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtTokuisaki.IsErrorOccurs)
                {
                    DataTable dt = txtTokuisaki.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                    {
                        tokuisakiDetail.Access_Tokuisaki_obj = From_DB_To_Tokuisaki(dt);
                    }
                }
            }
        }

        private void txtKouriten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtKouriten.IsErrorOccurs)
                {
                    DataTable dt = txtKouriten.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                    {
                        kouritenDetail.Access_Kouriten_obj = From_DB_To_Kouriten(dt);
                    }
                }
            }
        }
        //private bool GV_Check()
        //{
        //    foreach (DataGridViewRow gv in gvShukka1.Rows)
        //    {
        //        string value = gv.Cells["colKonkai"].EditedFormattedValue.ToString().Replace(",", "");
        //        if (Convert.ToDecimal(value) < 0)
        //        {
        //            bbl.ShowMessage("E109");
        //            return false;
        //        }
        //        string a = gv.Cells["colShukkazansuu"].FormattedValue.ToString();
        //        string b = gv.Cells["colMiryoku"].FormattedValue.ToString();
        //        decimal c = Convert.ToDecimal(a) - Convert.ToDecimal(b);
        //        if (Convert.ToDecimal(value) > c)
        //        {
        //            bbl.ShowMessage("E143", "出荷残数 - 未入荷数", "大きい");
        //            return false;
        //        }
        //    }
        //    return true;
        //}
        //private void gvShukka1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        //    if (gvShukka1.Columns[e.ColumnIndex].Name == "colKonkai")
        //    {
        //        string value = gvShukka1.Rows[e.RowIndex].Cells["colKonkai"].EditedFormattedValue.ToString();
        //        string a = gvShukka1.Rows[e.RowIndex].Cells["colShukkazansuu"].EditedFormattedValue.ToString();
        //        string b = gvShukka1.Rows[e.RowIndex].Cells["colMiryoku"].EditedFormattedValue.ToString();
        //        decimal c = Convert.ToDecimal(a) - Convert.ToDecimal(b);

        //        if (Convert.ToDecimal(value) < 0)
        //        {
        //            bbl.ShowMessage("E109");
        //            e.Cancel = true;
        //        }
        //        else if (Convert.ToDecimal(value) > c)
        //        {
        //            bbl.ShowMessage("E143", "出荷残数 - 未入荷数", "大きい");
        //            e.Cancel = true;
        //        }
        //    }
        //}

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            FunctionProcedure(8);
        }
        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("JANCD", typeof(string));
            dt.Columns.Add("HinbanCD", typeof(string));
            dt.Columns.Add("ShouhinName", typeof(string));
            dt.Columns.Add("ColorRyakuName", typeof(string));
            dt.Columns.Add("ColorNO", typeof(string));
            dt.Columns.Add("SizeNO", typeof(string));
            dt.Columns.Add("ShukkaSiziZumiSuu", typeof(string));
            dt.Columns.Add("MiNyuukaSuu", typeof(string));
            dt.Columns.Add("ShukkaSuu", typeof(string));
            dt.Columns.Add("Kanryou", typeof(int));
            dt.Columns.Add("ShukkaMeisaiTekiyou", typeof(string));
            dt.Columns.Add("ShukkaSiziNOGyouNO", typeof(string));
            dt.Columns.Add("DenpyouDate", typeof(string));
            dt.Columns.Add("JuchuuNOGyouNO", typeof(string));
            dt.Columns.Add("SoukoCD", typeof(string));
            dt.Columns.Add("ShouhinCD", typeof(string));          
            dt.Columns.Add("ShukkaSiziNO", typeof(string));
            dt.Columns.Add("OldShukkaSuu", typeof(string));
            //dt.Columns.Add("SoukoCD", typeof(string));

            //dt.Columns.Add("DenpyouDate", typeof(string));
            //dt.Columns.Add("JuchuuNOGyouNO", typeof(string));
            //dt.Columns.Add("ShouhinCD", typeof(string));

            //dt.Columns.Add("SoukoCD", typeof(string));
            //dt.Columns.Add("TokuisakiCD", typeof(string));
            //dt.Columns.Add("KouritenCD", typeof(string));



            dt.AcceptChanges();
            return dt;
        }
        private void Gridview_F9ShowHide(int col, string type)
        {
            Control[] ctrlArr = this.TopLevelControl.Controls.Find("BtnF9", true);
           
        if (ctrlArr.Length > 0)
            {
                Control btnF9 = ctrlArr[0];
                if (btnF9 != null)
                    btnF9.Visible = false;
            }
            
        }
        private void txtShukkaSijiNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ShukkaSiziNo_Check();
            }
        }
        private void ShukkaSiziNo_Check()
        {
            bl = new ShukkaNyuuryokuBL();
            DataTable dt = new DataTable();
            if (!string.IsNullOrWhiteSpace(txtShukkaSijiNo.Text))
            {
                dt = bl.ShukkaSiziNo_Check(txtShukkaSijiNo.Text, "E133");
                if (dt.Rows[0]["MessageID"].ToString().Equals("E133"))
                {
                    bbl.ShowMessage("E133");
                    txtShukkaSijiNo.Focus();
                }
            }
        }

        private void current_gv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Gridview_F9ShowHide(e.ColumnIndex, "Show");
        }

        private void current_gv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (current_gv.IsLastKeyEnter)
            {
                if (ErrorCheck_CellEndEdit(e.RowIndex, e.ColumnIndex))
                    current_gv.CurrentCell = current_gv.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            F11_Save();
        }
        private void F11_Save()
        {
            if (F8_dt1.Rows.Count == 0)
            {
                FunctionProcedure(11);
                current_gv.Columns["DenpyouDate"].Visible=false;
                current_gv.Columns["JuchuuNOGyouNO"].Visible = false;
                current_gv.Columns["SoukoCD"].Visible = false;
                current_gv.Columns["ShouhinCD"].Visible = false;
            }
        }
        private void ShukkaNo_KeyDown()
        {
            if (!txtShukkaNo.IsErrorOccurs && (cboMode.SelectedValue.ToString() != "1"))
            {
                if (cboMode.SelectedValue.ToString().Equals("2") || cboMode.SelectedValue.ToString().Equals("3"))
                {
                    if (ShukkaNO_Check())
                    {
                        if (cboMode.SelectedValue.ToString().Equals("2"))
                        {
                            EnablePanel();
                        }
                        else if (cboMode.SelectedValue.ToString().Equals("3"))
                        {
                            cf.DisablePanel(PanelTitle);
                            Control btnSearch = this.TopLevelControl.Controls.Find("BtnF9", true)[0];
                            btnSearch.Visible = false;

                            btnDetail1.Enabled = true;
                            btnDetail2.Enabled = true;
                        }
                        Display();
                    }
                    else
                    {
                        bbl.ShowMessage("S004", Data1, Data2, Data3);
                        txtShukkaNo.Focus();
                    }
                }
                else if (cboMode.SelectedValue.ToString().Equals("4"))
                {
                    cf.DisablePanel(PanelTitle);
                    Control btnSearch = this.TopLevelControl.Controls.Find("BtnF9", true)[0];
                    btnSearch.Visible = false;

                    Display();

                    btnDetail1.Enabled = true;
                    btnDetail2.Enabled = true;
                }
            }
            else
            {
                EnablePanel();
            }
        }
        private void txtShukkaNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ShukkaNo_KeyDown(); 
            }
            //if (e.KeyCode == Keys.Enter)
            //{

            //    if (!txtShukkaNo.IsErrorOccurs)
            //    {

            //        if (cboMode.SelectedValue.ToString() == "2" || cboMode.SelectedValue.ToString() == "1")
            //        {
            //            if (cboMode.SelectedValue.ToString() == "2") //update
            //            {
            //                sBL.ShukkaNyuuryoku_Exclusive_Insert(obj_shukka);
            //            }
            //            EnablePanel();
            //        }
            //        else if (cboMode.SelectedValue.ToString() == "3" || cboMode.SelectedValue.ToString() == "4")
            //        {
            //            if (cboMode.SelectedValue.ToString() == "3")//delete
            //            {
            //                sBL.ShukkaNyuuryoku_Exclusive_Insert(obj_shukka);
            //            }
            //            cf.DisablePanel(PanelTitle);
            //            Control btnSearch = this.TopLevelControl.Controls.Find("BtnF9", true)[0];
            //            btnSearch.Visible = false;
            //        }
            //    }
            //    Main_dt = txtShukkaNo.IsDatatableOccurs;
            //    if (Main_dt.Rows.Count > 0 && cboMode.SelectedValue.ToString() != "1")
            //    {
            //        From_DB_To_Form(Main_dt);
            //        if (gvShukka1.Columns.Count == 13)
            //        {
            //            gvShukka1.Columns.Remove("ShukkaSiziNO");
            //        }

            //    }
            //}
        }
        private bool ShukkaNO_Check()
        {
            obj = new ShukkaNyuuryokuEntity();
            obj.DataKBN = 6;
            obj.Number = txtShukkaNo.Text;
            obj.ProgramID = ProgramID;
            obj.PC = PCID;
            obj.OperatorCD = OperatorCD;
            DataTable dt = new DataTable();
            bl = new ShukkaNyuuryokuBL();
            dt = bl.D_Exclusive_Lock_Check(obj);
            if (dt.Rows[0]["MessageID"].ToString().Equals("1"))
            {
                return true;
            }

            Data1 = dt.Rows[0]["Program"].ToString();
            Data2 = dt.Rows[0]["Operator"].ToString();
            Data3 = dt.Rows[0]["PC"].ToString();
            return false;
        }
        private void From_DB_To_Form(DataTable dt)
        {
            if (dt.Rows[0]["MessageID"].ToString() == "E132")
            {
                txtShukkaDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["ShukkaDate"]);
                txtTokuisaki.Text = dt.Rows[0]["TokuisakiCD"].ToString();
                lblTokuisakiName.Text = dt.Rows[0]["TokuisakiRyakuName"].ToString();
                txtKouriten.Text = dt.Rows[0]["KouritenCD"].ToString();
                lblKouritenName.Text = dt.Rows[0]["KouritenRyakuName"].ToString();
                txtStaff.Text = dt.Rows[0]["StaffCD"].ToString();
                lblStatffName.Text = dt.Rows[0]["StaffName"].ToString();
                txtDenpyou.Text = dt.Rows[0]["ShukkaDenpyouTekiyou"].ToString();

                //show page load data in tokuisaki detail
                tokuisakiDetail.Access_Tokuisaki_obj = From_DB_To_Tokuisaki(dt);


                //show page load data in kouriten detail
                kouritenDetail.Access_Kouriten_obj = From_DB_To_Kouriten(dt);

                //
                dt.Columns.Remove("ShukkaDate");
                dt.Columns.Remove("StaffCD");
                dt.Columns.Remove("StaffName");
                dt.Columns.Remove("ShukkaDenpyouTekiyou");

                dt.Columns.Remove("TokuisakiCD");
                dt.Columns.Remove("TokuisakiRyakuName");
                dt.Columns.Remove("TokuisakiName");
                dt.Columns.Remove("TokuisakiYuubinNO1");
                dt.Columns.Remove("TokuisakiYuubinNO2");
                dt.Columns.Remove("TokuisakiJuusho1");
                dt.Columns.Remove("TokuisakiJuusho2");
                dt.Columns.Remove("TokuisakiTelNO1-1");
                dt.Columns.Remove("TokuisakiTelNO1-2");
                dt.Columns.Remove("TokuisakiTelNO1-3");
                dt.Columns.Remove("TokuisakiTelNO2-1");
                dt.Columns.Remove("TokuisakiTelNO2-2");
                dt.Columns.Remove("TokuisakiTelNO2-3");

                dt.Columns.Remove("KouritenCD");
                dt.Columns.Remove("KouritenRyakuName");
                dt.Columns.Remove("KouritenName");
                dt.Columns.Remove("KouritenYuubinNO1");
                dt.Columns.Remove("KouritenYuubinNO2");
                dt.Columns.Remove("KouritenJuusho1");
                dt.Columns.Remove("KouritenJuusho2");
                dt.Columns.Remove("KouritenTelNO1-1");
                dt.Columns.Remove("KouritenTelNO1-2");
                dt.Columns.Remove("KouritenTelNO1-3");
                dt.Columns.Remove("KouritenTelNO2-1");
                dt.Columns.Remove("KouritenTelNO2-2");
                dt.Columns.Remove("KouritenTelNO2-3");
                //dt.Columns.Remove("DenpyouDate");
                //dt.Columns.Remove("JuchuuNOGyouNO");
                //dt.Columns.Remove("SoukoCD");
                //dt.Columns.Remove("ShouhinCD");
                dt.Columns.Remove("MessageID");

                DataColumn column = new DataColumn();
                column.ColumnName = "OldShukkaSuu";
                dt.Columns.Add(column);
                foreach(DataRow dr in dt.Rows)
                {
                    dr["OldShukkaSuu"] = dr["ShukkaSuu"];
                }

                current_gv.DataSource = dt;
                current_gv.Columns[13].Visible = false;
                current_gv.Columns[14].Visible = false;
                current_gv.Columns[15].Visible = false;
                current_gv.Columns[16].Visible = false;
                current_gv.Columns[18].Visible = false;
                //gvShukka1.ClearSelection();

                DataTable dt_temp = dt.Copy();
                gvdt1 = dt_temp;

                //if (F8_dt1.Rows.Count == 0)
                //    F8_dt1 = gvdt1.Clone();
            }
        }

        private KouritenEntity From_DB_To_Kouriten(DataTable dt)
        {
            KouritenEntity obj = new KouritenEntity();
            obj.KouritenCD = dt.Rows[0]["KouritenCD"].ToString();
            obj.KouritenRyakuName = dt.Rows[0]["KouritenRyakuName"].ToString();
            obj.KouritenName = dt.Rows[0]["KouritenName"].ToString();
            if (dt.Columns.Contains("KouritenYuubinNO1"))
                obj.YuubinNO1 = dt.Rows[0]["KouritenYuubinNO1"].ToString();
            else
                obj.YuubinNO1 = dt.Rows[0]["YuubinNO1"].ToString();
            if (dt.Columns.Contains("KouritenYuubinNO2"))
                obj.YuubinNO2 = dt.Rows[0]["KouritenYuubinNO2"].ToString();
            else
                obj.YuubinNO2 = dt.Rows[0]["YuubinNO2"].ToString();
            if (dt.Columns.Contains("KouritenJuusho1"))
                obj.Juusho1 = dt.Rows[0]["KouritenJuusho1"].ToString();
            else
                obj.Juusho1 = dt.Rows[0]["Juusho1"].ToString();
            if (dt.Columns.Contains("KouritenJuusho2"))
                obj.Juusho2 = dt.Rows[0]["KouritenJuusho2"].ToString();
            else
                obj.Juusho2 = dt.Rows[0]["Juusho2"].ToString();
            if (dt.Columns.Contains("KouritenTelNO1-1"))
                obj.Tel11 = dt.Rows[0]["KouritenTelNO1-1"].ToString();
            else
                obj.Tel11 = dt.Rows[0]["Tel11"].ToString();
            if (dt.Columns.Contains("KouritenTelNO1-2"))
                obj.Tel12 = dt.Rows[0]["KouritenTelNO1-2"].ToString();
            else
                obj.Tel12 = dt.Rows[0]["Tel12"].ToString();
            if (dt.Columns.Contains("KouritenTelNO1-3"))
                obj.Tel13 = dt.Rows[0]["KouritenTelNO1-3"].ToString();
            else
                obj.Tel13 = dt.Rows[0]["Tel13"].ToString();
            if (dt.Columns.Contains("KouritenTelNO2-1"))
                obj.Tel21 = dt.Rows[0]["KouritenTelNO2-1"].ToString();
            else
                obj.Tel21 = dt.Rows[0]["Tel21"].ToString();
            if (dt.Columns.Contains("KouritenTelNO2-2"))
                obj.Tel22 = dt.Rows[0]["KouritenTelNO2-2"].ToString();
            else
                obj.Tel22 = dt.Rows[0]["Tel22"].ToString();
            if (dt.Columns.Contains("KouritenTelNO2-3"))
                obj.Tel23 = dt.Rows[0]["KouritenTelNO2-3"].ToString();
            else
                obj.Tel23 = dt.Rows[0]["Tel23"].ToString();
            return obj;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            F10_Show();
        }
        private void F10_Show()
        {
            current_gv.ActionType = "F10";
            if (ErrorCheck(PanelDetail))
                FunctionProcedure(10);
            current_gv.ActionType = string.Empty;
            if (Main_dt.Rows.Count > 0)
            {
                current_gv.CurrentCell = current_gv.Rows[0].Cells["col_Konkai"];
            }

        }
    }
}
