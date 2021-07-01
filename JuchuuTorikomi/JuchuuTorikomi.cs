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
using System.Text;

namespace JuchuuTorikomi
{
    public partial class JuchuuTorikomi : BaseForm
    {
        CommonFunction cf;
        BaseEntity base_Entity;
        BaseBL bbl;
        JuchuuTorikomiBL JBL;
        JuchuuTorikomiEntity JEntity;
        DataTable dtMain, dt1,dtResult;
        //string Data1 = string.Empty, Data2 = string.Empty, Data3 = string.Empty;

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

            txtImportFileName.TxtBox = txtImportFolder;         //Task 453
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
                txtDate2.E104Check(false, txtDate1, txtDate2);
                txtDenpyouNO.E102Check(false);
                txtDenpyouNO.E160Check(false, "JuchuuTorikomi", txtDenpyouNO, null);
                txtDenpyouNO.E265Check(false, "JuchuuTorikomi", txtDenpyouNO);
            }
            else
            {
                txtImportFolder.E102Check(false);
                txtImportFileName.E102Check(false);
                txtDate1.E103Check(true);
                txtDate2.E103Check(true);
                txtDate2.E104Check(true, txtDate1, txtDate2);
                txtDenpyouNO.E102Check(false);
                txtDenpyouNO.E160Check(false, "JuchuuTorikomi", txtDenpyouNO, null);
                txtDenpyouNO.E265Check(false, "JuchuuTorikomi", txtDenpyouNO);
            }
        }
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
                    txtDenpyouNO.E102Check(false);
                    txtDenpyouNO.E160Check(false, "JuchuuTorikomi", txtDenpyouNO, null);
                    txtDenpyouNO.E265Check(false, "JuchuuTorikomi", txtDenpyouNO);
                }
                if (ErrorCheck(PanelDetail))
                    GridviewBind();
                gvJuchuuTorikomi.ActionType = string.Empty;
            }
            if (tagID == "12")
            {
                gvJuchuuTorikomi.ActionType = "F10";
                string spname = string.Empty;
                if (rdo_Delete.Checked)
                {
                    txtDenpyouNO.E102Check(true);
                    txtDenpyouNO.E160Check(true, "JuchuuTorikomi", txtDenpyouNO, null);
                    txtDenpyouNO.E265Check(true, "JuchuuTorikomi", txtDenpyouNO);
                }
                else
                {
                    txtDenpyouNO.E102Check(false);
                    txtDenpyouNO.E160Check(false, "JuchuuTorikomi", txtDenpyouNO, null);
                    txtDenpyouNO.E265Check(false, "JuchuuTorikomi", txtDenpyouNO);
                }
                if (ErrorCheck(PanelDetail))
                {
                    if (rdo_Registration.Checked)
                    {
                        (string, string) Xml = GetFile();
                        if (!string.IsNullOrEmpty(Xml.Item1) && !string.IsNullOrEmpty(Xml.Item2))
                        {
                            {
                                spname = "JuchuuTorikomi_Insert";
                                DataTable return_BL1 = JBL.JuchuuTorikomi_CUD(spname, Xml.Item1, Xml.Item2, "ErrorCheck");
                                if (return_BL1.Rows.Count > 0)
                                {
                                    if (return_BL1.Rows[0]["Result"].ToString().Equals("1"))
                                    {
                                        if (bbl.ShowMessage("Q206") != DialogResult.Yes)
                                        {
                                            if (PreviousCtrl != null)
                                                PreviousCtrl.Focus();
                                        }
                                        else
                                        {
                                            return_BL1 = JBL.JuchuuTorikomi_CUD(spname, Xml.Item1, Xml.Item2, "");
                                            if (return_BL1.Rows.Count > 0)
                                            {
                                                if (return_BL1.Rows[0]["Result"].ToString().Equals("1"))
                                                {
                                                    bbl.ShowMessage("I002");
                                                    rdo_Registration.Focus();
                                                    BindData();

                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        bbl.ShowMessage("E276", return_BL1.Rows[0]["SEQ"].ToString(), return_BL1.Rows[0]["Error1"].ToString(), return_BL1.Rows[0]["Error2"].ToString());
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        string DenpyouNO = txtDenpyouNO.Text;
                        gvJuchuuTorikomi.DataSource = dtMain;
                        if (Data_Check())
                        {
                            txtDenpyouNO.Focus();
                            return;
                        }
                        else if (dtMain.Rows.Count > 0)                            
                        {
                            //if (bbl.ShowMessage("Q102") == DialogResult.Yes)
                            //{
                                string Xml = string.Empty;
                                spname = "JuchuuTorikomi_Delete";

                                //DataRow[] dtgv_row = dtMain.Select("TorikomiDenpyouNO ='" + DenpyouNO + "'");
                            var result = dtMain.AsEnumerable().Where(dr => dr.Field<string>("TorikomiDenpyouNO") == DenpyouNO);
                            Xml = cf.DataTableToXml(result.CopyToDataTable());
                            if(result!=null)
                            {
                                foreach(DataRow dr in result)
                                {
                                    string JuchuuNO = dr["JuchuuNO"].ToString();
                                    JEntity.DataKBN = 1;
                                    JEntity.Number = JuchuuNO;
                                    JEntity.ProgramID = ProgramID;
                                    JEntity.PC = PCID;
                                    JEntity.OperatorCD = OperatorCD;
                                    dt1 = new DataTable();
                                    dt1 = JBL.D_Exclusive_Lock_Check(JEntity);
                                    if (dt1.Rows[0]["MessageID"].ToString().Equals("S004"))
                                    {
                                        bbl.ShowMessage("S004", ProgramID, PCID, OperatorCD);
                                        return;
                                    }
                                }
                                JEntity.OperatorCD = base_Entity.OperatorCD;
                                JEntity.ProgramID = base_Entity.ProgramID;
                                JEntity.PC = base_Entity.PC;
                                JEntity.OperateMode = "Delete";
                                DataTable return_BL1 = JBL.JuchuuTorikomi_Delete(spname, Xml, DenpyouNO, JEntity);
                                bbl.ShowMessage("I002");
                                rdo_Delete.Checked = true;
                                txtDate1.Clear();
                                txtDate2.Clear();
                                txtDenpyouNO.Clear();
                                txtDenpyouNO.Focus();
                                GridviewBind();

                            }
                            //if (dtgv_row != null)
                            //    {
                                    //foreach (DataRow dr in dtgv_row)
                                    //{
                                    //    string JuchuuNO = dr["JuchuuNO"].ToString();
                                    //    JEntity.DataKBN = 1;
                                    //    JEntity.Number = JuchuuNO;
                                    //    JEntity.ProgramID = ProgramID;
                                    //    JEntity.PC = PCID;
                                    //    JEntity.OperatorCD = OperatorCD;
                                    //    dt1 = new DataTable();
                                    //    dt1 = JBL.D_Exclusive_Lock_Check(JEntity);
                                    //    if (dt1.Rows[0]["MessageID"].ToString().Equals("S004"))
                                    //    {
                                    //        bbl.ShowMessage("S004", ProgramID, PCID, OperatorCD);
                                    //        return;
                                    //    }
                                    //}
                                    //JEntity.OperatorCD = base_Entity.OperatorCD;
                                    //JEntity.ProgramID = base_Entity.ProgramID;
                                    //JEntity.PC = base_Entity.PC;
                                    //JEntity.OperateMode = "Delete";
                                    //DataTable return_BL1 = JBL.JuchuuTorikomi_Delete(spname, Xml, DenpyouNO, JEntity);
                                    //if (return_BL1.Rows.Count > 0)
                                    //{
                                        //if (return_BL1.Rows[0]["Result"].ToString().Equals("1"))
                                        //{
                                            //bbl.ShowMessage("I002");
                                            //rdo_Delete.Checked = true;
                                            //txtDate1.Clear();
                                            //txtDate2.Clear();
                                            //txtDenpyouNO.Clear();
                                            //txtDenpyouNO.Focus();
                                            //GridviewBind();
                                        //}
                                        //else
                                        //{
                                        //    bbl.ShowMessage("S013");
                                        //    txtDenpyouNO.Focus();
                                        //}
                                    //}
                                //}
                           // }
                            //else
                            //{
                            //    if (PreviousCtrl != null)
                            //        PreviousCtrl.Focus();
                            //}
                        }
                        else
                        {
                            bbl.ShowMessage("E274");
                            txtDate1.Focus();
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
            JEntity.DateFrom = txtDate1.Text;
            JEntity.DateTo = txtDate2.Text;
            dtMain = JBL.JuchuuTorikomi_Display(JEntity);
            if(dtMain.Rows.Count > 0)
            {
                gvJuchuuTorikomi.DataSource = dtMain;
            }
            else
            {
                //bbl.ShowMessage("S013");//to need F10
                dtMain.Clear();
                gvJuchuuTorikomi.DataSource = dtMain;  
                txtDate1.Focus();
                return;
            }
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
       
        private (string,string) GetFile()
        {
            JuchuuTorikomiEntity JEntity = new JuchuuTorikomiEntity();
            string Xml_Hacchuu = string.Empty;
            string Xml_Juchuu = string.Empty;
            string error = string.Empty;
            string path = txtImportFolder.Text + txtImportFileName.Text;
            if (File.Exists(path))         //Task 453
            {
                DataTable create_dt = new DataTable();
                Create_Datatable_Column(create_dt);
                //openFileDialog.FileName = txtImportFolder.Text + txtImportFileName.Text;         //Task 453
                string[] csvRows = File.ReadAllLines(txtImportFolder.Text + txtImportFileName.Text,Encoding.GetEncoding(932));//Task 453 --repaired encoding 2021/05/29 ssa CHG TaskNO 469
                var bl_List = new List<bool>();
                for (int i = 1; i < csvRows.Length; i++)
                {
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
                    dr[56-1] = base_Entity.OperatorCD;
                    dr[57 - 1] = base_Entity.ProgramID;
                    dr[58 - 1] = base_Entity.PC;
                    dr[59 - 1] = error;
                    create_dt.Rows.Add(dr);
                }
                create_dt.Columns.Add("JuchuuNO", typeof(string));
                    create_dt.Columns.Add("HacchuuNO", typeof(string));
                for (int i = 0; i < create_dt.Rows.Count; i++)
                {
                    TextBox txt = new TextBox();
                    txt.Text = create_dt.Rows[i]["JuchuuDate"].ToString();
                    string date = string.Empty;
                    if (cf.DateCheck(txt))
                    {
                        create_dt.Rows[i]["JuchuuDate"] = txt.Text;
                        date = create_dt.Rows[i]["JuchuuDate"].ToString();
                    }
                    if (!string.IsNullOrEmpty(date))
                    {
                        DataTable Dt_JuchuuNO = JBL.GetJuchuuNO("1", date, "0");
                        DataTable Dt_HacchuuNO = JBL.GetHacchuuNO("2", date, "0");
                        create_dt.Rows[i]["JuchuuNO"] = Dt_JuchuuNO.Rows[0]["Column1"];
                        create_dt.Rows[i]["HacchuuNO"] = Dt_HacchuuNO.Rows[0]["Column1"];
                    }

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
                    if (create_dt.Rows.Count > 0)
                    {
                        for (int r = 0; r < create_dt.Rows.Count; r++)
                        {
                        //NMW task NO. 592 begin
                        TextBox txt1 = new TextBox();
                        txt1.Text = create_dt.Rows[r]["JuchuuDate"].ToString();//column_1
                        if (cf.DateCheck(txt1))
                            create_dt.Rows[r]["JuchuuDate"] = string.IsNullOrEmpty(txt1.Text) ? null : txt1.Text;
                        string date1 = create_dt.Rows[r]["JuchuuDate"].ToString();//column_1

                        TextBox txt2 = new TextBox();
                        txt2.Text = create_dt.Rows[r]["KibouNouki"].ToString();//column_1
                        if (cf.DateCheck(txt2))
                            create_dt.Rows[r]["KibouNouki"] = string.IsNullOrEmpty(txt2.Text) ? null : txt2.Text;
                        string date2 = create_dt.Rows[r]["KibouNouki"].ToString();//column_2

                        TextBox txt3 = new TextBox();
                        txt3.Text = create_dt.Rows[r]["ChakuniYoteiDate"].ToString();//column_3
                        if (cf.DateCheck(txt3))
                            create_dt.Rows[r]["ChakuniYoteiDate"] = string.IsNullOrEmpty(txt3.Text) ? null : txt3.Text;
                        string date3 = create_dt.Rows[r]["ChakuniYoteiDate"].ToString();//column_3
                        //NMW task NO.592 end

                        int line_No = r + 1;

                        if (Date_Check(date1, line_No, "入力可能値外エラー", "項目:受注日") == "true")
                        {
                            return (null, null);
                        }
                        else if (Date_Check(date2, line_No, "入力可能値外エラー", "項目:希望納期") == "true")
                        {
                            return (null, null);
                        }
                        else if (Date_Check(date3, line_No, "入力可能値外エラー", "項目:着荷予定日") == "true")
                        {
                            return (null, null);
                        }
                        else if (r == create_dt.Rows.Count - 1)
                        {
                            Xml_Juchuu = cf.DataTableToXml(create_dt);
                        }
                    }
                    }
                else
                {
                    Xml_Hacchuu = string.Empty;
                    Xml_Juchuu = string.Empty;
                }
            }
            else
            {
                if(txtDenpyouNO.Enabled==true)
                {
                    bbl.ShowMessage("E281");
                    txtImportFolder.Focus();
                }
            }
            return (Xml_Hacchuu,Xml_Juchuu);
        }
        public void Remove_Datatable_Column(DataTable dtRemove)
        {
            dtRemove.Columns.Remove("TokuisakiCD");
            dtRemove.Columns.Remove("TokuisakiRyakuName");
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
            dtRemove.Columns.Remove("KouritenRyakuName");
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
        
        public void Create_Datatable_Column(DataTable create_dt)
        {
            create_dt.Columns.Add("JuchuuDate");
            create_dt.Columns.Add("TokuisakiCD");
            create_dt.Columns.Add("TokuisakiRyakuName");
            create_dt.Columns.Add("KouritenCD");
            create_dt.Columns.Add("KouritenRyakuName");
            create_dt.Columns.Add("StaffCD");
            create_dt.Columns.Add("SenpouHacchuuNO");
            create_dt.Columns.Add("SenpouBusho");
            create_dt.Columns.Add("KibouNouki");
            create_dt.Columns.Add("HacchuuDenpyouTekiyou");
            create_dt.Columns.Add("ShouhinCD");
            create_dt.Columns.Add("ColorRyakuName");
            create_dt.Columns.Add("SizeNO");
            //create_dt.Columns.Add("JANCD");
            create_dt.Columns.Add("HacchuuSuu");
            create_dt.Columns.Add("HacchuuTanka");
            create_dt.Columns.Add("UriageTanka");
            create_dt.Columns.Add("JuchuuMeisaiTekiyou");
            create_dt.Columns.Add("SiiresakiCD");
            create_dt.Columns.Add("SiiresakiRyakuName");
            create_dt.Columns.Add("ChakuniYoteiDate");
            create_dt.Columns.Add("SoukoCD");
            create_dt.Columns.Add("SoukoName");

            create_dt.Columns.Add("TokuisakiuName");
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

            create_dt.Columns.Add("KouritenName");
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
            ErrorCheck();
        }

        private void rdo_Delete_CheckedChanged(object sender, EventArgs e)
        {
            if(rdo_Delete.Checked==true)
            {
                rdo_Registration.Checked = false;
                Disable_Panel();
            }
            ErrorCheck();
        }

        private void txtDenpyouNO_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
               if (Data_Check())
                {
                    txtDenpyouNO.Focus();
                }
            }
        }

        //TaskNo678 HET
        private void gvJuchuuTorikomi_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow row = gvJuchuuTorikomi.CurrentRow;
            if (row != null)
                txtDenpyouNO.Text = row.Cells["colTorikomiDenpyouNO"].Value.ToString();
        }

        private bool Data_Check()
        {
            dtResult = new DataTable();
            dtResult = JBL.TorikomiDenpyouNO_Check(ProgramID, txtDenpyouNO.Text);
            if (dtResult.Rows.Count > 0 && dtResult.Rows[0]["Result"].ToString().Equals("0"))
            {
                bbl.ShowMessage("S013");
                return true;
            }
            return false;
        }

        private void txtDate2_KeyDown(object sender, KeyEventArgs e)
        {
              GridviewBind();
        }
    }
}
