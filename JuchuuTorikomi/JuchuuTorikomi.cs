using System;
using Shinyoh;
using Entity;
using BL;
using CKM_CommonFunction;
using System.Windows.Forms;
using Shinyoh_Controls;
using Shinyoh_Search;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace JuchuuTorikomi
{
    public partial class JuchuuTorikomi : BaseForm
    {
        CommonFunction cf;
        BaseEntity base_Entity;
        BaseBL bbl;
        JuchuuTorikomiBL JBL;
        JuchuuTorikomiEntity JEntity;
        DataTable dtMain;
        public JuchuuTorikomi()
        {
            InitializeComponent();
            cf = new CommonFunction();
            bbl = new BaseBL();
            JBL = new JuchuuTorikomiBL();
            JEntity = new JuchuuTorikomiEntity();
            dtMain = new DataTable();
        }

        private void JuchuuTorikomi_Load(object sender, EventArgs e)
        {
            ProgramID = "JuchuuTorikomi";
            StartProgram();
            cboMode.Visible = false;
            cboMode.Enabled = false;
            gvJuchuuTorikomi.SetGridDesign();
            gvJuchuuTorikomi.SetReadOnlyColumn("**");

            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "新規(F2)", false);
            SetButton(ButtonType.BType.Update, F3, "変更(F3)", false);
            SetButton(ButtonType.BType.Delete, F4, "削除(F4)", false);
            SetButton(ButtonType.BType.Inquiry, F5, "照会(F5)", false);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", false);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", true);
            SetButton(ButtonType.BType.Import, F10, "表示(F10)", true);
            SetButton(ButtonType.BType.Search, F11, "保存(F11)", false);
            SetButton(ButtonType.BType.Import, F12, "登録(F12)", true);

            base_Entity = _GetBaseData();
            ErrorCheck();
            BindData();
            Enable_Panel();
            gvJuchuuTorikomi.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvJuchuuTorikomi.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvJuchuuTorikomi.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvJuchuuTorikomi.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        private void BindData()
        {
            multipurposeBL bl = new multipurposeBL();

            DataTable dt = bl.M_Multiporpose_SelectData(string.Empty, 2, "111", "1");

            if (dt.Rows.Count > 0)
            {
                txtImportFolder.Text = dt.Rows[0]["Char1"].ToString();
                txtImportFileName.Text = dt.Rows[0]["Char2"].ToString();
            }
            else
            {
                txtImportFolder.Text = string.Empty;
                txtImportFileName.Text = string.Empty;
            }
        }
        private void ErrorCheck()
        {
            if (rdo_Registration.Checked)
            {
                txtImportFolder.E102Check(true);
                txtImportFileName.E102Check(true);
                if (cf.DateCheck(txtDate1))
                    txtDate1.E103Check(false);
                if (cf.DateCheck(txtDate2))
                    txtDate2.E103Check(false);
                txtDate2.E106Check(false, txtDate1, txtDate1);
                txtDenpyouNO.E102Check(false);
                txtDenpyouNO.E160Check(false, "JuchuuTorikomi", txtDenpyouNO, null);
                txtDenpyouNO.E265Check(false, "JuchuuTorikomi", txtDenpyouNO);
            }
            else
            {
                txtImportFolder.E102Check(false);
                txtImportFileName.E102Check(false);
                if (cf.DateCheck(txtDate1))
                    txtDate1.E103Check(true);
                if (cf.DateCheck(txtDate2))
                    txtDate2.E103Check(true);
                txtDate2.E106Check(true, txtDate1, txtDate1);
                txtDenpyouNO.E102Check(true);
                txtDenpyouNO.E160Check(true, "JuchuuTorikomi", txtDenpyouNO, null);
                txtDenpyouNO.E265Check(true, "JuchuuTorikomi", txtDenpyouNO);
            }
        }
        //private void ErrorCheck()
        //{
        //    txtImportFolder.E102Check(true);
        //    txtImportFileName.E102Check(true);
        //    txtDate1.E103Check(true);
        //    txtDate2.E103Check(true);
        //    txtDate2.E104Check(true, txtDate1, txtDate1);
        //    txtDenpyouNO.E102Check(true);
        //    txtDenpyouNO.E160Check(true, "JuchuuTorikomi", txtDenpyouNO, null);
        //    txtDenpyouNO.E265Check(true, "JuchuuTorikomi", txtDenpyouNO);
        //}
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "6")
            {
                 Clear();
            }
            if (tagID == "10")
            {
                gvJuchuuTorikomi.ActionType = "F10";
                if (rdo_Delete.Checked == true)
                {
                    GridviewBind();
                }
                gvJuchuuTorikomi.ActionType = string.Empty;
            }
            if (tagID == "12")
            {
                (string, string) Xml = GetFile();
                BaseBL bbl = new BaseBL();
                if (!string.IsNullOrEmpty(Xml.Item1) && !string.IsNullOrEmpty(Xml.Item2))
                {
                    if (bbl.ShowMessage("Q206") != DialogResult.Yes)
                    {
                        if (PreviousCtrl != null)
                            PreviousCtrl.Focus();
                    }
                    else
                    {
                        JuchuuTorikomiBL Jbl = new JuchuuTorikomiBL();
                        //string chk_val = string.Empty;
                        string spname = string.Empty;
                        string DenpyouNO = txtDenpyouNO.Text;
                        if (rdo_Registration.Checked)
                        {
                            spname = "JuchuuTorikomi_Insert";
                        }
                        else
                        {
                            spname = "JuchuuTorikomi_Delete";
                            //chk_val = "delete";
                            //foreach (DataRow dr in dtMain.Rows)
                            //{
                            //    string JuchuuNO = dr["JuchuuNO"].ToString();
                            //    JEntity.DataKBN = 1;
                            //    JEntity.Number = JuchuuNO;
                            //    JEntity.ProgramID = ProgramID;
                            //    JEntity.PC = PCID;
                            //    JEntity.OperatorCD = OperatorCD;
                            //    DataTable dt1 = new DataTable();
                            //    dt1 = Jbl.D_Exclusive_Lock_Check(JEntity);
                            //    if (dt1.Rows[0]["MessageID"].ToString().Equals("S004"))
                            //    {
                            //        bbl.ShowMessage("S004");
                            //    }
                        }
                        DataTable return_BL1 = Jbl.JuchuuTorikomi_CUD(spname, Xml.Item1, Xml.Item2, DenpyouNO);
                        if (return_BL1.Rows.Count > 0)
                        {
                            if (return_BL1.Rows[0]["Result"].ToString().Equals("1"))
                                bbl.ShowMessage("I002");
                            else
                            {
                                bbl.ShowMessage("E276", return_BL1.Rows[0]["SEQ"].ToString(), return_BL1.Rows[0]["Error1"].ToString(), return_BL1.Rows[0]["Error2"].ToString());
                            }
                        }
                    }
                }
            }
              base.FunctionProcess(tagID);
        }
        private void Clear()
        {
            rdo_Registration.Checked = true;
            BindData();
            txtDate1.Clear();
            txtDate2.Clear();
            txtDenpyouNO.Clear();
            dtMain.Clear();
            gvJuchuuTorikomi.ClearSelection();
            rdo_Registration.Focus();
        }
        private void GridviewBind()
        {
            //if (!cf.DateCheck(txtDate1))
            //    txtDate1.E103Check(true);
            //if (!cf.DateCheck(txtDate2))
            //    txtDate2.E103Check(true);
            //txtDate2.E106Check(true, txtDate1, txtDate2);
            //txtDenpyouNO.E102Check(true);
            //txtDenpyouNO.E160Check(true, "JuchuuTorikomi", txtDenpyouNO, null);
            //txtDenpyouNO.E265Check(true, "JuchuuTorikomi", txtDenpyouNO);
            JEntity.TorikomiDenpyouNO = txtDenpyouNO.Text;
            dtMain = JBL.JuchuuTorikomi_Display(JEntity);
            gvJuchuuTorikomi.DataSource = dtMain;
        }
        private void Enable_Panel()
        {
            txtImportFolder.Enabled = true;
            txtImportFileName.Enabled = true;
            txtDate1.Enabled = false;
            txtDate2.Enabled = false;
            txtDenpyouNO.Enabled = false;
            F10.Visible = false;
        }
        private void Disable_Panel()
        {
            txtImportFolder.Enabled = false;
            txtImportFolder.Text = string.Empty;
            txtImportFileName.Enabled = false;
            txtImportFileName.Text = string.Empty;
            txtDate1.Enabled = true;
            txtDate2.Enabled = true;
            txtDenpyouNO.Enabled = true;
            F10.Enabled = true;
            F10.Visible = true;
        }
        private DataTable Create_gvColumn()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TorikomiDenpyouNO", typeof(string));
            dt.Columns.Add("InsertDateTime", typeof(string));
            dt.Columns.Add("JuchuuNO", typeof(string));
            dt.Columns.Add("JuchuuDate", typeof(string));
            dt.Columns.Add("TokuisakiCD", typeof(string));
            dt.Columns.Add("TokuisakiRyakuName", typeof(string));
            dt.Columns.Add("KouritenCD", typeof(string));
            dt.Columns.Add("KouritenRyakuName", typeof(string));
            return dt;
        }
        private (string,string) GetFile()
        {
            var filepath = string.Empty;
            JuchuuTorikomiEntity JEntity = new JuchuuTorikomiEntity();
            string Xml_Hacchuu = string.Empty;
            string Xml_Juchuu = string.Empty;
            string error = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\Csv\\";
                openFileDialog.Title = "Browse CSV Files";
                openFileDialog.Filter = "csv files (*.csv)|*.csv";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                DataTable create_dt = new DataTable();
                Create_Datatable_Column(create_dt);
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filepath = openFileDialog.FileName;
                    string[] csvRows = File.ReadAllLines(filepath);
                    var bl_List = new List<bool>();
                    for (int i = 1; i < csvRows.Length; i++)
                    {
                        //var splits = csvRows[i].Split(',');
                        //JEntity.JuchuuDate= splits[0];
                        //if (Null_Check(JEntity.JuchuuDate, i, "受注日")) break;
                        //if(Date_Check(JEntity.JuchuuDate,i, "受注日")) break;

                        //JEntity.TokuisakiCD = splits[1];
                        //if (Null_Check(JEntity.TokuisakiCD, i, "得意先CD")) break;
                        //if (Byte_Check(10, JEntity.TokuisakiCD, i, "得意先CD")) break;

                        //JEntity.TokuisakiName = splits[2];
                        //if (Null_Check(JEntity.TokuisakiName, i, "得意先名")) break;
                        //if (Byte_Check(80, JEntity.TokuisakiName, i, "得意先名")) break;

                        //JEntity.KouritenCD = splits[3];
                        //if (Null_Check(JEntity.KouritenCD, i, "小売店CD")) break;
                        //if (Byte_Check(10, JEntity.KouritenCD, i, "小売店CD")) break;

                        //JEntity.KouritenName = splits[4];
                        //if (Null_Check(JEntity.KouritenName, i, "小売店名")) break;
                        //if (Byte_Check(80, JEntity.KouritenName, i, "得意先名")) break;

                        //JEntity.StaffCD = splits[5];
                        //if (Null_Check(JEntity.StaffCD, i, "担当スタッフCD")) break;
                        //if (Byte_Check(10, JEntity.StaffCD, i, "担当スタッフCD")) break;

                        //JEntity.KibouNouki = splits[7];
                        //if (Date_Check(JEntity.KibouNouki, i, "希望納期")) break;

                        //JEntity.ShouhinCD = splits[10];
                        //if (Null_Check(JEntity.ShouhinCD, i, "商品CD")) break;
                        //if (Byte_Check(20, JEntity.ShouhinCD, i, "商品CD")) break;

                        //JEntity.ColorRyakuName = splits[11];
                        //if (Null_Check(JEntity.ColorRyakuName, i, "カラー")) break;

                        //JEntity.SizeNO = splits[12];
                        //if (Null_Check(JEntity.SizeNO, i, "サイズ")) break;

                        //JEntity.JANCD = splits[13];
                        //if (Null_Check(JEntity.JANCD, i, "JANCD")) break;
                        //if (Byte_Check(13, JEntity.JANCD, i, "JANCD")) break;

                        //JEntity.HacchuuSuu = splits[14];
                        //if (Number_Check(JEntity.HacchuuSuu, i, "数量")) break;

                        //JEntity.SenpouHacchuuNO = splits[15];
                        //if (Number_Check(JEntity.SenpouHacchuuNO, i, "発注単価")) break;

                        //JEntity.JuchuuDenpyouTekiyou = splits[16];///
                        //if (Number_Check(JEntity.JuchuuDenpyouTekiyou, i, "受注単価")) break;

                        //JEntity.SiiresakiCD = splits[18];
                        //if (Null_Check(JEntity.SiiresakiCD, i, "仕入先CD")) break;
                        //if (Byte_Check(10, JEntity.SiiresakiCD, i, "仕入先CD")) break;

                        //JEntity.SiiresakiName = splits[19];
                        //if (Byte_Check(80, JEntity.SiiresakiName, i, "仕入先名")) break;

                        //JEntity.ChakuniYoteiDate = splits[20];
                        //if (Null_Check(JEntity.ChakuniYoteiDate, i, "着荷予定日")) break;
                        //if (Date_Check(JEntity.ChakuniYoteiDate, i, "着荷予定日")) break;

                        //JEntity.SoukoCD = splits[21];
                        //if (Null_Check(JEntity.SoukoCD, i, "倉庫CD")) break;
                        //if (Byte_Check(10, JEntity.SoukoCD, i, "倉庫CD")) break;

                        //DataTable dt = new DataTable();
                        //TokuisakiBL tBL = new TokuisakiBL();
                        //dt = tBL.M_Tokuisaki_Select(JEntity.TokuisakiCD, JEntity.JuchuuDate, "E101");
                        //if (dt.Rows[0]["MessageID"].ToString() == "E101")
                        //{
                        //    bbl.ShowMessage("E101", i.ToString(), "得意先CD");
                        //    break;
                        //}

                        //DataTable dt1 = new DataTable();
                        //KouritenBL kBL = new KouritenBL();
                        //dt1 = kBL.Kouriten_Select_Check(JEntity.KouritenCD, JEntity.JuchuuDate, "E101");
                        //if (dt1.Rows[0]["MessageID"].ToString() == "E101")
                        //{
                        //    bbl.ShowMessage("E101", i.ToString(), "小売店CD");
                        //    break;
                        //}

                        //DataTable dt2 = new DataTable();
                        //StaffBL sBL = new StaffBL();
                        //dt2 = sBL.Staff_Select_Check(JEntity.StaffCD, JEntity.JuchuuDate, "E101");
                        //if (dt2.Rows[0]["MessageID"].ToString() == "E101")
                        //{
                        //    bbl.ShowMessage("E101", i.ToString(), "担当スタッフCD");
                        //    break;
                        //}

                        //DataTable dt3 = new DataTable();
                        //ShukkaTorikomi_BL rBL = new ShukkaTorikomi_BL();
                        //dt3 = rBL.ShukkaTorikomi_Check(JEntity.ShouhinCD, JEntity.JuchuuDate, "E101", "ShouhinCD");
                        //if (dt3.Rows.Count > 0 && dt3.Rows[0]["MessageID"].ToString() == "E101")
                        //{
                        //    bbl.ShowMessage("E101", i.ToString(), "商品CD");
                        //    break;
                        //}

                        //DataTable dt4 = new DataTable();
                        //ShukkaTorikomi_BL jBL = new ShukkaTorikomi_BL();
                        //dt4 = jBL.ShukkaTorikomi_Check(JEntity.JANCD, JEntity.JuchuuDate, "E101", "JANCD");
                        //if (dt4.Rows.Count > 0 && dt4.Rows[0]["MessageID"].ToString() == "E101")
                        //{
                        //    bbl.ShowMessage("E101", i.ToString(), "JANCD");
                        //    break;
                        //}

                        //DataTable dt5 = new DataTable();
                        //SiiresakiBL SiireBL = new SiiresakiBL();
                        //dt5 = SiireBL.Siiresaki_Select_Check(JEntity.SiiresakiCD, JEntity.JuchuuDate, "E101");
                        //if (dt5.Rows[0]["MessageID"].ToString() == "E101")
                        //{
                        //    bbl.ShowMessage("E101", i.ToString(), "仕入先CD");
                        //    break;
                        //}

                        //DataTable dt6 = new DataTable();
                        //SoukoBL soukoBL = new SoukoBL();
                        //dt6 = soukoBL.Souko_Select(JEntity.SoukoCD, "E101");
                        //if (dt6.Rows[0]["MessageID"].ToString() == "E101")
                        //{
                        //    bbl.ShowMessage("E101", i.ToString(), "倉庫CD");
                        //    break;
                        //}

                        //string error = string.Empty;
                        //if (bl_List.Contains(true))
                        //    error = "true";
                        //else error = "false";

                        //DataRow dr = create_dt.NewRow();
                        //for (int j = 0; j < splits.Length; j++)
                        //{
                        //    if (string.IsNullOrEmpty(splits[j]))
                        //        dr[j] = DBNull.Value;
                        //    else
                        //        dr[j] = splits[j].ToString();
                        //}
                        //dr[54] = base_Entity.OperatorCD;
                        //dr[55] = base_Entity.ProgramID;
                        //dr[56] = base_Entity.PC;
                        //dr[57] = error;
                        //create_dt.Rows.Add(dr);
                        error = "false";
                        var splits = csvRows[i].Split(',');
                        DataRow dr = create_dt.NewRow();
                        for (int j = 0; j < splits.Length; j++)
                        {
                            if (string.IsNullOrEmpty(splits[j]))
                                dr[j] = DBNull.Value;
                            else
                                dr[j] = splits[j].ToString();
                        }
                        dr[54] = base_Entity.OperatorCD;
                        dr[55] = base_Entity.ProgramID;
                        dr[56] = base_Entity.PC;
                        dr[57] = error;
                        create_dt.Rows.Add(dr);                       
                    }
                    create_dt.Columns.Add("JuchuuNO", typeof(string));
                    create_dt.Columns.Add("HacchuuNO", typeof(string));
                    for (int i = 0; i < create_dt.Rows.Count; i++)
                    {
                        DateTime date = DateTime.Parse(create_dt.Rows[i]["JuchuuDate"].ToString().Replace('-','/'));
                        DataTable Dt_JuchuuNO = JBL.GetJuchuuNO("1", date, "0");
                        DataTable Dt_HacchuuNO = JBL.GetHacchuuNO("2", date, "0");
                        create_dt.Rows[i]["JuchuuNO"] = Dt_JuchuuNO.Rows[0]["Column1"];
                        create_dt.Rows[i]["HacchuuNO"] = Dt_HacchuuNO.Rows[0]["Column1"];
                    }
                    DataTable dt_Main = new DataTable();
                    if (create_dt.Rows.Count > 0)
                    {
                        dt_Main = create_dt.AsEnumerable()
                              .GroupBy(r => new { Col1 = r["JuchuuDate"], Col2 = r["TokuisakiCD"], Col3 = r["KouritenCD"], Col4 = r["SenpouHacchuuNO"], Col5 = r["SenpouBusho"], Col6 = r["KibouNouki"], Col7 = r["SoukoCD"] })
                              .Select(g => g.OrderBy(r => r["JuchuuDate"]).First())
                              .CopyToDataTable();

                        Remove_Datatable_Column(dt_Main);
                        Xml_Hacchuu = cf.DataTableToXml(dt_Main);
                    }
                    // Xml_Juchuu = cf.DataTableToXml(create_dt);
                    //05_17_2021[ssa]
                    if (create_dt.Rows.Count > 0)
                    {
                        for (int r = 0; r < create_dt.Rows.Count; r++)
                        {
                            string date1 = create_dt.Rows[r]["JuchuuDate"].ToString();//column_1
                            string date2 = create_dt.Rows[r]["KibouNouki"].ToString();//column_2
                            string date3 = create_dt.Rows[r]["ChakuniYoteiDate"].ToString();//column_3
                            int line_No = r + 1;

                            if (Date_Check(date1, line_No, "入力可能値外エラー", "項目:改定日") == "true")
                            {
                                Xml_Hacchuu = string.Empty;
                            }
                            else if (Date_Check(date2, line_No, "入力可能値外エラー", "取引開始日") == "true")
                            {
                                Xml_Hacchuu = string.Empty;
                            }
                            else if (Date_Check(date3, line_No, "入力可能値外エラー", "取引終了日") == "true")
                            {
                                Xml_Hacchuu = string.Empty;
                            }
                            else if (r == create_dt.Rows.Count - 1)
                            {
                                Xml_Juchuu = cf.DataTableToXml(create_dt);
                            }
                        }
                    }
                }
                else
                {
                    Xml_Hacchuu = string.Empty;
                    Xml_Juchuu = string.Empty;
                }
            }
            return (Xml_Hacchuu,Xml_Juchuu);
        }
        public void Remove_Datatable_Column(DataTable dtRemove)
        {
            dtRemove.Columns.Remove("TokuisakiCD");
            dtRemove.Columns.Remove("TokuisakiName");
            dtRemove.Columns.Remove("TokuisakiYuubinNO1");
            dtRemove.Columns.Remove("TokuisakiYuubinNO2");
            dtRemove.Columns.Remove("TokuisakiJuusho1");
            dtRemove.Columns.Remove("TokuisakiJuusho2");
            dtRemove.Columns.Remove("TokuisakiTelNO1-1");
            dtRemove.Columns.Remove("TokuisakiTelNO1-2");
            dtRemove.Columns.Remove("TokuisakiTelNO1-3");
            dtRemove.Columns.Remove("TokuisakiTelNO2-1");
            dtRemove.Columns.Remove("TokuisakiTelNO2-2");
            dtRemove.Columns.Remove("TokuisakiTelNO2-3");
            dtRemove.Columns.Remove("KouritenCD");
            dtRemove.Columns.Remove("KouritenName");
            dtRemove.Columns.Remove("KouritenYuubinNO1");
            dtRemove.Columns.Remove("KouritenYuubinNO2");
            dtRemove.Columns.Remove("KouritenJuusho1");
            dtRemove.Columns.Remove("KouritenJuusho2");
            dtRemove.Columns.Remove("KouritenTelNO1-1");
            dtRemove.Columns.Remove("KouritenTelNO1-2");
            dtRemove.Columns.Remove("KouritenTelNO1-3");
            dtRemove.Columns.Remove("KouritenTelNO2-1");
            dtRemove.Columns.Remove("KouritenTelNO2-2");
            dtRemove.Columns.Remove("KouritenTelNO2-3");
            //dtRemove.Columns.Remove("ChakuniYoteiDate");
            dtRemove.Columns.Remove("SenpouHacchuuNO");
            dtRemove.Columns.Remove("SenpouBusho");
            dtRemove.Columns.Remove("KibouNouki");
            //dtRemove.Columns.Remove("HacchuuSuu");
            dtRemove.Columns.Remove("UriageTanka");
            //dtRemove.Columns.Remove("JuchuuMeisaiTekiyou");
        }
        //private bool Null_Check(string obj_text, int line_no, string error_msg)
        //{
        //    bool bl = false;
        //    if (string.IsNullOrWhiteSpace(obj_text))
        //    {
        //        bbl.ShowMessage("E102");
        //        bl = true;
        //    }
        //    return bl;
        //}
        //private bool Byte_Check(int obj_len, string obj_text, int line_no, string error_msg)
        //{
        //    bool bl = false;
        //    if (cf.IsByteLengthOver(obj_len, obj_text))
        //    {
        //        bbl.ShowMessage("E142");
        //        bl = true;
        //    }
        //    return bl;
        //}
        //public bool Date_Check(string csv_Date, int line_no, string error_msg)
        //{
        //    bool bl = false;
        //    if (!string.IsNullOrEmpty(csv_Date))
        //    {
        //        if (!cf.CheckDateValue(csv_Date))
        //        {
        //            bbl.ShowMessage("E103");
        //            bl = true;
        //        }
        //    }
        //    return bl;
        //}

        public string Date_Check(string csv_Date, int line_no, string error_msg1, string error_msg2)
        {
            TextBox txt = new TextBox();
            txt.Text = csv_Date;
            if (!string.IsNullOrEmpty(csv_Date))
            {
                if (!cf.DateCheck(txt))
                {
                    bbl.ShowMessage("E276", line_no.ToString(), error_msg1, error_msg2);
                    txt.Text = "true";
                }
            }
            return txt.Text;
        }
        //public bool Number_Check(string csv_number, int i, string v)
        //{
        //    bool bl = false; int result;
        //    if (!string.IsNullOrEmpty(csv_number))
        //    {
        //        bool parsedSuccessfully = int.TryParse(csv_number, out result);

        //        if (parsedSuccessfully == false)
        //        {
        //            bbl.ShowMessage("E103");
        //            bl = true;
        //        }
        //    }
        //    return bl;
        //}
        public void Create_Datatable_Column(DataTable create_dt)
        {
            create_dt.Columns.Add("JuchuuDate");
            create_dt.Columns.Add("TokuisakiCD");
            create_dt.Columns.Add("TokuisakiName");
            create_dt.Columns.Add("KouritenCD");
            create_dt.Columns.Add("KouritenName");
            create_dt.Columns.Add("StaffCD");
            create_dt.Columns.Add("SenpouHacchuuNO");
            create_dt.Columns.Add("SenpouBusho");
            create_dt.Columns.Add("KibouNouki");
            create_dt.Columns.Add("HacchuuDenpyouTekiyou");
            create_dt.Columns.Add("ShouhinCD");
            create_dt.Columns.Add("ColorRyakuName");
            create_dt.Columns.Add("SizeNO");
            create_dt.Columns.Add("JANCD");
            create_dt.Columns.Add("HacchuuSuu");
            create_dt.Columns.Add("HacchuuTanka");
            create_dt.Columns.Add("UriageTanka");
            create_dt.Columns.Add("JuchuuMeisaiTekiyou");
            create_dt.Columns.Add("SiiresakiCD");
            create_dt.Columns.Add("SiiresakiRyakuName");
            create_dt.Columns.Add("ChakuniYoteiDate");
            create_dt.Columns.Add("SoukoCD");
            create_dt.Columns.Add("SoukoName");
            //create_dt.Columns.Add("TokuisakiName");
            create_dt.Columns.Add("TokuisakiYuubinNO1");
            create_dt.Columns.Add("TokuisakiYuubinNO2");
            create_dt.Columns.Add("TokuisakiJuusho1");
            create_dt.Columns.Add("TokuisakiJuusho2");
            create_dt.Columns.Add("TokuisakiTelNO1-1");
            create_dt.Columns.Add("TokuisakiTelNO1-2");
            create_dt.Columns.Add("TokuisakiTelNO1-3");
            create_dt.Columns.Add("TokuisakiTelNO2-1");
            create_dt.Columns.Add("TokuisakiTelNO2-2");
            create_dt.Columns.Add("TokuisakiTelNO2-3");
            //create_dt.Columns.Add("KouritenName");
            create_dt.Columns.Add("KouritenYuubinNO1");
            create_dt.Columns.Add("KouritenYuubinNO2");
            create_dt.Columns.Add("KouritenJuusho1");
            create_dt.Columns.Add("KouritenJuusho2");
            create_dt.Columns.Add("KouritenTelNO1-1");
            create_dt.Columns.Add("KouritenTelNO1-2");
            create_dt.Columns.Add("KouritenTelNO1-3");
            create_dt.Columns.Add("KouritenTelNO2-1");
            create_dt.Columns.Add("KouritenTelNO2-2");
            create_dt.Columns.Add("KouritenTelNO2-3");
            create_dt.Columns.Add("SiiresakiName");
            create_dt.Columns.Add("SiiresakiYuubinNO1");
            create_dt.Columns.Add("SiiresakiYuubinNO2");
            create_dt.Columns.Add("SiiresakiJuusho1");
            create_dt.Columns.Add("SiiresakiJuusho2");
            create_dt.Columns.Add("SiiresakiTelNO1-1");
            create_dt.Columns.Add("SiiresakiTelNO1-2");
            create_dt.Columns.Add("SiiresakiTelNO1-3");
            create_dt.Columns.Add("SiiresakiTelNO2-1");
            create_dt.Columns.Add("SiiresakiTelNO2-2");
            create_dt.Columns.Add("SiiresakiTelNO2-3");
            create_dt.Columns.Add("Operator");
            create_dt.Columns.Add("ProgramID");
            create_dt.Columns.Add("PC");
            create_dt.Columns.Add("Error");
        }
        private void rdo_Registration_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_Registration.Checked == true)
            {
                rdo_Delete.Checked = false;
                Enable_Panel();
                Clear();
            }
        }

        private void rdo_Delete_CheckedChanged(object sender, EventArgs e)
        {
            if(rdo_Delete.Checked==true)
            {
                rdo_Registration.Checked = false;
                Disable_Panel();
            }
        }

        private void txtDate2_KeyDown(object sender, KeyEventArgs e)
        {
            //if(String.IsNullOrEmpty(txtDenpyouNO.Text))
            //{
            //    bbl.ShowMessage("E102");
            //    txtDenpyouNO.Focus();
            //}
            if (cf.DateCheck(txtDate1))
                txtDate1.E103Check(true);
            if (cf.DateCheck(txtDate2))
                txtDate2.E103Check(true);
            txtDate2.E106Check(true, txtDate1, txtDate2);
            txtDenpyouNO.E102Check(true);
            txtDenpyouNO.E160Check(true, "JuchuuTorikomi", txtDenpyouNO, null);
            txtDenpyouNO.E265Check(true, "JuchuuTorikomi", txtDenpyouNO);
            JEntity.TorikomiDenpyouNO = txtDenpyouNO.Text;
            dtMain = JBL.JuchuuTorikomi_Display(JEntity);
            gvJuchuuTorikomi.DataSource = dtMain;
        }
    }
}
