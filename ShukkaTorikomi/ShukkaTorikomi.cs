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

namespace ShukkaTorikomi
{
    public partial class SqlDbType : BaseForm
    {
        CommonFunction cf;
        BaseEntity base_Entity;
        multipurposeEntity multi_Entity;
        TorikomiEntity SEntity;
        ShukkaTorikomi_BL ShukkaTorikomi_BL;
        //TorikomiEntity JEntity;
        BaseBL bbl;
        DataTable dt_Main;
        DataTable create_dt;
        DataTable dtShuKka;
        DataTable dt;

        public SqlDbType()
        {
            InitializeComponent();
            cf = new CommonFunction();
            multi_Entity = new multipurposeEntity();
            dt_Main = new DataTable();
            create_dt = new DataTable();
            dt = new DataTable();

            bbl = new BaseBL();
            SEntity = new TorikomiEntity();
            ShukkaTorikomi_BL = new ShukkaTorikomi_BL();
        }

        private void ShukkaTorikomi_Load(object sender, EventArgs e)
        {
            ProgramID = "ShukkaTorikomi";
            StartProgram();
            cboMode.Visible = false;
            cboMode.Enabled = false;
            cboMode.Bind(false, multi_Entity);
            gvShukkaTorikomi.SetGridDesign();
            gvShukkaTorikomi.SetReadOnlyColumn("**");

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
            //multipurposeEntity multipurpose_entity = new multipurposeEntity();

            txtImportFolder.Enabled = true;
            txtImportFileName.Enabled = true;

            txtImportFileName.TxtBox = txtImportFolder;         //Task 452

            txtDate1.Enabled = false;
            txtDate2.Enabled = false;
            txtDenpyouNO.Enabled = false;
            gvShukkaTorikomi.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvShukkaTorikomi.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvShukkaTorikomi.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvShukkaTorikomi.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            ErrorCheck();
            dataBind();
            gvShukkaTorikomi.UseRowNo(true);
            Control btnF10 = this.TopLevelControl.Controls.Find("BtnF10", true)[0];
            btnF10.Visible = false;
        }

        private void dataBind()
        {
            multipurposeBL bl = new multipurposeBL();

            dtShuKka = bl.M_Multiporpose_SelectData(string.Empty, 3, string.Empty, string.Empty);

            if (dtShuKka.Rows.Count > 0)
            {
                txtImportFolder.Text = dtShuKka.Rows[0]["Char1"].ToString();
                txtImportFileName.Text = dtShuKka.Rows[0]["Char2"].ToString();
            }
            else
            {
                txtImportFolder.Text = string.Empty;
                txtImportFileName.Text = string.Empty;
            }
        }

        private void rdo_Toroku_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_Toroku.Checked == true)
            {
                rdo_Sakujo.Checked = false;
                Disable_Enable_Method();
                if (dtShuKka != null)
                {
                    if (dtShuKka.Rows.Count > 0)
                    {
                        txtImportFolder.Text = dtShuKka.Rows[0]["Char1"].ToString();
                        txtImportFileName.Text = dtShuKka.Rows[0]["Char2"].ToString();
                    }
                }
                ErrorCheck();
            }
        }

        private void Disable_Enable_Method()
        {
            txtImportFolder.Text = string.Empty;
            txtImportFileName.Text = string.Empty;
            txtDate1.Text = string.Empty;
            txtDate2.Text = string.Empty;
            txtDenpyouNO.Text = string.Empty;
           

            if(rdo_Toroku.Checked)
            {
                txtImportFolder.Enabled = true;
                txtImportFileName.Enabled = true;
                txtDate1.Enabled = false;
                txtDate2.Enabled = false;
                txtDenpyouNO.Enabled = false;
                //F10.Enabled = false;
                //F6.Enabled = true;
                Control btnF10 = this.TopLevelControl.Controls.Find("BtnF10", true)[0];
                btnF10.Visible = false;

                Control btnF12 = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                txtImportFileName.NextControlName = btnF12.Name;
            }
            else
            {
                txtImportFolder.Enabled = false;
                txtImportFileName.Enabled = false;
                txtDate1.Enabled = true;
                txtDate2.Enabled = true;
                txtDenpyouNO.Enabled = true;
                rdo_Sakujo.NextControlName = txtDate1.Name;
                txtDate1.NextControlName = txtDate2.Name;
                txtDate2.NextControlName = txtDenpyouNO.Name;
                //F10.Enabled = true;
                //F6.Enabled = true;
                Control btnF10 = this.TopLevelControl.Controls.Find("BtnF10", true)[0];
                btnF10.Visible = true;
                Control btnF12 = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                txtDenpyouNO.NextControlName = btnF12.Name;
            }
        }

        private void rdo_Sakujo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_Sakujo.Checked == true)
            {
                rdo_Toroku.Checked = false;
                Disable_Enable_Method();
                ErrorCheck();
            }
        }

        private void ErrorCheck()
        {
            if(rdo_Toroku.Checked)
            {
                txtImportFolder.E102Check(true);
                txtImportFileName.E102Check(true);
                txtDate1.E103Check(false);
                txtDate2.E103Check(false);
                txtDate2.E104Check(false, txtDate1, txtDate2); //HET
                txtDenpyouNO.E102Check(false);
                txtDenpyouNO.E165Check(false, "ShukkaTorikom", txtDenpyouNO, null);  
            }
            else
            {
                txtImportFolder.E102Check(false);
                txtImportFileName.E102Check(false);
                txtDate1.E103Check(true);
                txtDate2.E103Check(true);
                txtDate2.E104Check(true, txtDate1, txtDate2); //HET
                txtDenpyouNO.E102Check(false);
                txtDenpyouNO.E165Check(false, "ShukkaTorikom", txtDenpyouNO, null);  
            }
        }

        public override void FunctionProcess(string tagID)
        {
            if (tagID == "6")
            {
                //Clear();
                rdo_Toroku.Checked = true;
                rdo_Toroku.Focus();
                Control btnF10 = this.TopLevelControl.Controls.Find("BtnF10", true)[0];
                btnF10.Visible = false;
                dataBind();
                gvShukkaTorikomi.ClearSelection();
                dt.Clear();
            }
            if (tagID == "10")
            {
                gvShukkaTorikomi.ActionType = "F10";
                if (rdo_Sakujo.Checked)
                {
                    txtDenpyouNO.E102Check(false);
                    txtDenpyouNO.E165Check(false, "ShukkaTorikom", txtDenpyouNO, null);
                }               
                if (ErrorCheck(PanelDetail))
                    DataGridviewBind();
                gvShukkaTorikomi.ActionType = string.Empty;
            }
            //base.FunctionProcess(tagID);

            if (tagID == "12")
            {
                //HET
                (string, string) Xml = (string.Empty,string.Empty);
                gvShukkaTorikomi.ActionType = "F10";
                if (rdo_Sakujo.Checked)
                {
                    txtDenpyouNO.E102Check(true);
                    txtDenpyouNO.E165Check(true, "ShukkaTorikom", txtDenpyouNO, null);
                }
                if (ErrorCheck(PanelDetail))             //HET
                {
                    if(rdo_Toroku.Checked)
                        Xml = ChooseFile();
                    else
                       Xml = ChooseFileDelete();

                    BaseBL bbl = new BaseBL();
                    if (!string.IsNullOrEmpty(Xml.Item1) && !string.IsNullOrEmpty(Xml.Item2))
                    {
                        DataTable return_DT = new DataTable();
                        ShukkaTorikomi_BL bl = new ShukkaTorikomi_BL();
                        string spname = string.Empty;
                        string TorikomiDenpyouNO = txtDenpyouNO.Text;

                        if (rdo_Toroku.Checked)
                        {
                            return_DT = bl.ShukkaTorikomi_CUD("ShukkaTorikomi_Insert", Xml.Item1, Xml.Item2, "ErrorCheck");
                            if (return_DT.Rows.Count > 0)
                            {
                                if (return_DT.Rows[0]["Result"].ToString().Equals("1"))
                                {
                                    if (bbl.ShowMessage("Q206") == DialogResult.Yes)
                                    {
                                        return_DT = bl.ShukkaTorikomi_CUD("ShukkaTorikomi_Insert", Xml.Item1, Xml.Item2, TorikomiDenpyouNO);
                                        if (return_DT.Rows.Count > 0)
                                        {
                                            if (return_DT.Rows[0]["Result"].ToString().Equals("1"))
                                                bbl.ShowMessage("I002");
                                            rdo_Toroku.Checked = true;
                                            rdo_Toroku.Focus();
                                        }
                                    }
                                    else
                                    {
                                        if (PreviousCtrl != null)
                                            PreviousCtrl.Focus();
                                    }
                                }
                                else
                                {
                                    bbl.ShowMessage("E276", return_DT.Rows[0]["SEQ"].ToString(), return_DT.Rows[0]["Error1"].ToString(), return_DT.Rows[0]["Error2"].ToString());
                                }
                            }
                        }
                        else
                        {
                            return_DT = bl.ShukkaTorikomi_CUD("NewShukkaTorikomi_Delete", Xml.Item1, Xml.Item2, TorikomiDenpyouNO);
                            if (return_DT.Rows.Count > 0)
                            {
                                if (return_DT.Rows[0]["Result"].ToString().Equals("1"))
                                {
                                    if (bbl.ShowMessage("Q102") == DialogResult.Yes)
                                    {
                                        return_DT = bl.ShukkaTorikomi_CUD("NewShukkaTorikomi_Delete", Xml.Item1, Xml.Item2, TorikomiDenpyouNO);
                                        bbl.ShowMessage("I002");
                                        rdo_Sakujo.Checked = true;
                                        txtDate1.Clear();
                                        txtDate2.Clear();
                                        txtDenpyouNO.Clear();
                                        txtDenpyouNO.Focus();
                                        DataGridviewBind();
                                    }
                                }
                                else
                                {
                                    bbl.ShowMessage("S013");
                                    txtDenpyouNO.Focus();
                                }
                            }
                            else
                            {
                                if (PreviousCtrl != null)
                                    PreviousCtrl.Focus();
                            }
                        }

                        //START         COMMENT BY TZA FOR TASK 437 28/05/2021
                        //if (bbl.ShowMessage("Q206") == DialogResult.Yes)
                        //{
                        //    if (rdo_Toroku.Checked)
                        //        return_DT = bl.ShukkaTorikomi_CUD("ShukkaTorikomi_Insert", Xml.Item1, Xml.Item2, TorikomiDenpyouNO);
                        //    else
                        //        return_DT = bl.ShukkaTorikomi_CUD("NewShukkaTorikomi_Delete", Xml.Item1, Xml.Item2, TorikomiDenpyouNO);
                        //    if (return_DT.Rows.Count > 0)
                        //    {
                        //        if (return_DT.Rows[0]["Result"].ToString().Equals("1"))
                        //            bbl.ShowMessage("I002");
                        //        else
                        //        {
                        //            bbl.ShowMessage("E276", return_DT.Rows[0]["SEQ"].ToString(), return_DT.Rows[0]["Error1"].ToString(), return_DT.Rows[0]["Error2"].ToString());
                        //        }
                        //    }

                        //}
                        //else
                        //{

                        //}
                        //END         COMMENT BY TZA FOR TASK 437 28/05/2021


                        //DataTable return_DT = new DataTable();

                        //if (return_DT.Rows.Count > 0)
                        //{



                        //else
                        //{
                        //    if (rdo_Toroku.Checked)
                        //    {
                        //        spname = "ShukkaTorikomi_Insert";
                        //    }
                        //    else
                        //    {
                        //        spname = "NewShukkaTorikomi_Delete";
                        //    }
                        //    return_DT = bl.ShukkaTorikomi_CUD(spname, Xml.Item1, Xml.Item2, TorikomiDenpyouNO);
                        //    if (return_DT.Rows.Count > 0)
                        //    {
                        //        if (return_DT.Rows[0]["Result"].ToString().Equals("1"))
                        //        {

                        //        }
                        //    }
                        //}
                        // }
                        //else
                        //{

                        //}
                        //}
                    }
                }
            }
        }
            
        
        private void DataGridviewBind()
        {  
            //TaskNo456 HET
            SEntity.DateFrom = txtDate1.Text;
            SEntity.DateTo = txtDate2.Text;
            dt = ShukkaTorikomi_BL.ShukkaTorikomi_Select_Check(SEntity);
            if (dt.Rows.Count > 0)
            {
                gvShukkaTorikomi.DataSource = dt;
            }
            else
            {
                bbl.ShowMessage("S013");
                dt.Clear();
                gvShukkaTorikomi.DataSource = dt;
                txtDate1.Focus();
            }
        }

        private (string,string) ChooseFile()
        {
            var filepath = string.Empty;
            TorikomiEntity obj = new TorikomiEntity();
            string Xml_Main = string.Empty;
            string Xml_Detail = string.Empty;
            string error = string.Empty;
            //using (OpenFileDialog openFileDialog = new OpenFileDialog())         //Task 452
            if (File.Exists(txtImportFolder.Text + txtImportFileName.Text))         //Task 452
            {               
                DataTable create_dt = new DataTable();                          //HET
                Creat_Datatable_Column(create_dt);
                //openFileDialog.FileName = txtImportFolder.Text + txtImportFileName.Text;         //Task 452
                filepath = txtImportFolder.Text + txtImportFileName.Text;         //Task 452
                string[] csvRows = File.ReadAllLines(txtImportFolder.Text + txtImportFileName.Text, Encoding.GetEncoding(932));
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
                    //dr["UsedFlg"] = "0";
                    dr["InsertOperator"] = base_Entity.OperatorCD;
                    dr["UpdateOperator"] = base_Entity.OperatorCD;
                    dr["Error"] = error;
                    create_dt.Rows.Add(dr);

                    //var splits = csvRows[i].Split(',');
                    //obj.TokuisakiCD = splits[0];
                    //if(Null_Check(obj.TokuisakiCD, i, "店CD未入力エラー"))break;
                    //if(Byte_Check(10, obj.TokuisakiCD, i, "店CD桁数エラー"))break;

                    //obj.KouritenCD = splits[1];
                    //if(Null_Check(obj.KouritenCD, i, "支店CD未入力エラー"))break;
                    //if(Byte_Check(10, obj.KouritenCD, i, "支店CD桁数エラー"))break;

                    //obj.TokuisakiRyakuName = splits[2];
                    //if(Null_Check(obj.TokuisakiRyakuName, i, "店名未入力エラー"))break;
                    //if(Byte_Check(80, obj.TokuisakiRyakuName, i, "店名桁数エラー"))break;

                    //obj.KouritenRyakuName = splits[3];
                    //if(Null_Check(obj.KouritenRyakuName, i, "支店名未入力エラー"))break;
                    //if(Byte_Check(80, obj.KouritenRyakuName, i, "支店名桁数エラー"))break;

                    //obj.DenpyouNO = splits[4];
                    ////if(Null_Check(obj.DenpyouNO, i, "伝票番号未入力エラー"))break;

                    //obj.DenpyouDate = splits[5];
                    //if(Null_Check(obj.DenpyouDate, i, "伝票日付未入力エラー"))break;
                    //if (Date_Check(obj.DenpyouDate, i, "入力可能値外エラー") == "true") break;
                    //else splits[5] = Date_Check(obj.DenpyouDate, i, "入力可能値外エラー");

                    //obj.ChangeDate = splits[6];
                    //if(Null_Check(obj.ChangeDate, i, "出荷日未入力エラー"))break;
                    //if (Date_Check(obj.ChangeDate, i, "入力可能値外エラー") == "true") break;
                    //else splits[6] = Date_Check(obj.ChangeDate, i, "入力可能値外エラー");

                    //obj.HinbanCD = splits[7];
                    //if(Null_Check(obj.HinbanCD, i, "品番未入力エラー"))break;
                    //if(Byte_Check(20, obj.HinbanCD, i, "品番桁数エラー"))break;

                    //obj.ColorRyakuName = splits[8];
                    //if(Null_Check(obj.ColorRyakuName, i, "ｶﾗｰ未入力エラー"))break;

                    //obj.SizeNO = splits[9];
                    //if(Null_Check(obj.SizeNO, i, "ｻｲｽﾞ未入力エラー"))break;

                    //obj.JANCD = splits[10];
                    //if(Null_Check(obj.JANCD, i, "JANｺｰﾄﾞ未入力エラー"))break;
                    //if(Byte_Check(13, obj.JANCD, i, "JANｺｰﾄﾞ桁数エラー"))break;

                    //obj.ShukkaSuu = splits[11];
                    //if(Null_Check(obj.ShukkaSuu, i, "数量未入力エラー")) break;
                    //if(Number_Check(obj.ShukkaSuu, i, "入力可能値外エラー"))break;

                    //obj.UnitPrice = splits[12];
                    //if(Number_Check(obj.UnitPrice, i, "入力可能値外エラー"))break;

                    //obj.SellingPrice = splits[13];
                    //if(Number_Check(obj.SellingPrice, i, "入力可能値外エラー"))break;

                    //obj.ShukkaDenpyouTekiyou = splits[14];

                    //obj.ShukkaSiziNO = splits[15];
                    //if(Null_Check(obj.ShukkaSiziNO, i, "出荷指示番号未入力エラー"))break;
                    //if(Byte_Check(12, obj.ShukkaSiziNO, i, "出荷指示番号桁数エラー"))break;

                    //DataTable dt = new DataTable();
                    //TokuisakiBL tBL = new TokuisakiBL();
                    //dt = tBL.M_Tokuisaki_Select(obj.TokuisakiCD, obj.ChangeDate, "E101");
                    //if (dt.Rows[0]["MessageID"].ToString() == "E101")
                    //{
                    //    bbl.ShowMessage("E276", i.ToString(), "店CD未登録エラー");
                    //    //err.ShowErrorMessage("E101");
                    //    //bl_List.Add(true);
                    //    break;
                    //}

                    //DataTable dt1 = new DataTable();
                    //KouritenBL kBL = new KouritenBL();
                    //dt1 = kBL.Kouriten_Select_Check(obj.KouritenCD, obj.ChangeDate, "E101");
                    //if (dt1.Rows[0]["MessageID"].ToString() == "E101")
                    //{
                    //    bbl.ShowMessage("E276", i.ToString(), "支店CD未登録エラー");
                    //    //err.ShowErrorMessage("E101");
                    //    //bl_List.Add(true);
                    //    break;
                    //}

                    //DataTable dt2 = new DataTable();
                    //ShukkaTorikomi_BL rBL = new ShukkaTorikomi_BL();
                    //dt2 = rBL.ShukkaTorikomi_Check(obj.HinbanCD + obj.ColorRyakuName + obj.SizeNO, obj.ChangeDate, "E276", "ShouhinCD");
                    //if (dt2.Rows[0]["MessageID"].ToString() == "E276")
                    //{
                    //    bbl.ShowMessage("E276", i.ToString(), "品番CD未登録エラー");
                    //    //bl_List.Add(true);
                    //        break;
                    //}

                    //DataTable dt3 = new DataTable();
                    //ShukkaTorikomi_BL jBL = new ShukkaTorikomi_BL();
                    //dt3 = jBL.ShukkaTorikomi_Check(obj.JANCD, obj.ChangeDate, "E276", "JANCD");
                    //if (dt3.Rows[0]["MessageID"].ToString() == "E276")
                    //{
                    //    bbl.ShowMessage("E276", i.ToString(), "JANCD未登録エラー");
                    //    //err.ShowErrorMessage("E101");
                    //    //bl_List.Add(true);
                    //    break;
                    //}

                    //DataTable dt4 = new DataTable();
                    //ShukkaTorikomi_BL sBL = new ShukkaTorikomi_BL();
                    //dt4 = sBL.ShukkaTorikomi_Slip_Check(obj.ShukkaSiziNO, obj.HinbanCD + obj.ColorRyakuName + obj.SizeNO, "Slip");
                    //if (dt4.Rows.Count > 0 && dt4.Rows[0]["MessageID"].ToString() == "E276")
                    //{
                    //    bbl.ShowMessage("E276", i.ToString(), "出荷指示伝票未登録エラー", "出荷指示番号：" + obj.ShukkaSiziNO);
                    //    break;
                    //}

                    //DataTable dt5 = new DataTable();
                    //ShukkaTorikomi_BL cBL = new ShukkaTorikomi_BL();
                    //dt5 = cBL.ShukkaTorikomi_Slip_Check(obj.ShukkaSiziNO, obj.HinbanCD + obj.ColorRyakuName + obj.SizeNO, "Shipped");
                    //if (dt5.Rows.Count > 0 && dt5.Rows[0]["MessageID"].ToString() == "E276")
                    //{
                    //    bbl.ShowMessage("E276", i.ToString(), "出荷済エラー", "出荷指示番号：" + obj.ShukkaSiziNO + " 品番：" + obj.HinbanCD + obj.ColorRyakuName + obj.SizeNO);
                    //    break;
                    //}

                    //DataTable dt6 = new DataTable();
                    //ShukkaTorikomi_BL mBL = new ShukkaTorikomi_BL();
                    //dt6 = mBL.ShukkaTorikomi_Slip_Check(obj.ShukkaSiziNO, obj.HinbanCD + obj.ColorRyakuName + obj.SizeNO, "Shippable");
                    //if (dt6.Rows.Count > 0 && dt6.Rows[0]["MessageID"].ToString() == "E276")
                    //{
                    //    bbl.ShowMessage("E276", i.ToString(), "出荷可能数を超えるデータ", "出荷指示番号：" + obj.ShukkaSiziNO + " 品番：" + obj.HinbanCD + obj.ColorRyakuName + obj.SizeNO);
                    //    break;
                    //}

                    //    string error = string.Empty;
                    //    if (bl_List.Contains(true))
                    //        error = "true";
                    //    else error = "false";

                    //    DataRow dr = create_dt.NewRow();
                    //    for (int j = 0; j < splits.Length; j++)
                    //    {
                    //        if (string.IsNullOrEmpty(splits[j]))
                    //            dr[j] = DBNull.Value;
                    //        else
                    //            dr[j] = splits[j].ToString();
                    //    }
                    //    //dr[28] = "0";
                    //    dr[16] = base_Entity.OperatorCD;
                    //    dr[17] = base_Entity.OperatorCD;
                    //    dr[18] = base_Entity.ProgramID;
                    //    dr[19] = base_Entity.PC;
                    //    dr[20] = error;
                    //    create_dt.Rows.Add(dr);
                    }

                    DataTable dt_Main = new DataTable();
                if (create_dt.Rows.Count>0)
                {
                    dt_Main = create_dt.AsEnumerable()
                            .GroupBy(r => new { Col1 = r["TokuisakiCD"], Col2 = r["KouritenCD"], Col3 = r["TokuisakiRyakuName"], Col4 = r["KouritenRyakuName"], Col5 = r["DenpyouNO"], Col6 = r["DenpyouDate"], Col7 = r["ChangeDate"], Col8 = r["ShukkaDenpyouTekiyou"]})
                            .Select(g => g.OrderBy(r => r["TokuisakiCD"]).First())
                            .CopyToDataTable();


                    create_dt.Columns.Add("ShukkaNO", typeof(string));
                    create_dt.Columns.Add("ShukkaGyouNO", typeof(string));
                    dt_Main.Columns.Add("ShukkaNO", typeof(string));

                    for (int i = 0; i < dt_Main.Rows.Count; i++)
                    {
                        DateTime date =DateTime.Parse(dt_Main.Rows[i]["ChangeDate"].ToString());
                        DataTable shukkano_dt = ShukkaTorikomi_BL.GetShukkaNO("6", date, "0");
                        dt_Main.Rows[i]["ShukkaNO"] = shukkano_dt.Rows[0]["Column1"];
                        string tokuisakiCD = dt_Main.Rows[i]["TokuisakiCD"].ToString();
                        string kouritenCD = dt_Main.Rows[i]["KouritenCD"].ToString();
                        string tokuisakiryakuName = dt_Main.Rows[i]["TokuisakiRyakuName"].ToString();
                        string kouritenryakuName = dt_Main.Rows[i]["KouritenRyakuName"].ToString();
                        string denpyouNO = dt_Main.Rows[i]["DenpyouNO"].ToString();
                        string denpyouDate = dt_Main.Rows[i]["DenpyouDate"].ToString();
                        string changeDate = dt_Main.Rows[i]["ChangeDate"].ToString();
                        string shukkadenpyouTekiyou= dt_Main.Rows[i]["ShukkadenpyouTekiyou"].ToString();
                        string null_val= string.Empty;
                        DataRow[] select_dr = null;
                        if (string.IsNullOrEmpty(shukkadenpyouTekiyou))
                            null_val = " and [ShukkadenpyouTekiyou] IS NULL";
                        if (!string.IsNullOrEmpty(null_val))
                            select_dr = create_dt.Select("TokuisakiCD = '" + tokuisakiCD + "'and KouritenCD='" + kouritenCD + "' and TokuisakiRyakuName='" + tokuisakiryakuName + "' and KouritenRyakuName='" + kouritenryakuName + "' and DenpyouNO='" + denpyouNO + "'and DenpyouDate = '" + denpyouDate + "' and ChangeDate='" + changeDate + "'" + null_val + "");
                        else select_dr = create_dt.Select("TokuisakiCD = '" + tokuisakiCD + "'and KouritenCD='" + kouritenCD + "' and TokuisakiRyakuName='" + tokuisakiryakuName + "' and KouritenRyakuName='" + kouritenryakuName + "' and DenpyouNO='" + denpyouNO + "'and DenpyouDate = '" + denpyouDate + "' and ChangeDate='" + changeDate + "'");
                        if (select_dr.Length > 0)
                        {
                            for (int j = 0; j < select_dr.Length; j++)
                            {
                                select_dr[j]["ShukkaNO"] = shukkano_dt.Rows[0]["Column1"];
                                select_dr[j]["ShukkaGyouNO"] = j + 1;
                            }
                        }
                    }
                      
                    Column_Remove_Datatable(dt_Main);

                    Xml_Main = cf.DataTableToXml(dt_Main);
                }
                if (create_dt.Rows.Count > 0)
                {
                    for (int r = 0; r < create_dt.Rows.Count; r++)
                    {
                        string date1 = create_dt.Rows[r]["DenpyouDate"].ToString();//column_1
                        string date2 = create_dt.Rows[r]["ChangeDate"].ToString();//column_2
                        int line_No = r + 1;

                        if (Date_Check(date1, line_No, "入力可能値外エラー", "項目:改定日") == "true")
                        {
                            Xml_Detail = string.Empty;
                            r = create_dt.Rows.Count; //chg 24-05-2021 ssa

                        }
                        else if (Date_Check(date2, line_No, "入力可能値外エラー", "取引開始日") == "true")
                        {
                            Xml_Detail = string.Empty;
                            r = create_dt.Rows.Count;//chg 24-05-2021 ssa
                        }
                      
                        else if (r == create_dt.Rows.Count - 1)
                        {
                            Xml_Detail = cf.DataTableToXml(create_dt);
                        }
                    }
                }
                //if (create_dt.Rows.Count == csvRows.Length - 1)
                //{
                //    Xml_Detail = cf.DataTableToXml(create_dt);
                //}              
                else
                {
                    Xml_Detail = string.Empty;
                    Xml_Main = string.Empty;
                }
            }
            else //2021 / 05 / 24 ssa CHG TaskNO 492
            {
                bbl.ShowMessage("E281");
                txtImportFolder.Focus();
            }
            return (Xml_Detail, Xml_Main);
        }

        private (string, string) ChooseFileDelete()
        {
            string Xml_Main = string.Empty;
            string Xml_Detail = string.Empty;
            DataTable gv_dt = gvShukkaTorikomi.DataSource as DataTable;
            DataTable dt = gv_dt.Copy();
            dt.Columns.Remove("TorikomiDenpyouNO");
            dt.Columns.Remove("InsertDateTime");
            dt.Columns.Remove("TokuisakiRyakuName");
            dt.Columns.Remove("KouritenRyakuName");
            DataColumn dataColumn = new DataColumn("InsertOperator", typeof(string));
            dataColumn.DefaultValue = base_Entity.OperatorCD;
            dt.Columns.Add(dataColumn);
            DataColumn dataColumn1 = new DataColumn("PC", typeof(string));
            dataColumn.DefaultValue = base_Entity.PC;
            dt.Columns.Add(dataColumn1);
            if (dt.Rows.Count>0)
            {
                Xml_Detail = cf.DataTableToXml(dt);
                Xml_Main = txtDenpyouNO.Text;
            }
            return (Xml_Detail, Xml_Main);
        }

        //private bool Null_Check(string obj_text, int line_no, string error_msg)
        //{
        //    bool bl = false;
        //    if (string.IsNullOrWhiteSpace(obj_text))
        //    {
        //        bbl.ShowMessage("E276", line_no.ToString(), error_msg);
        //        bl = true;
        //    }
        //    return bl;
        //}
        //private bool Byte_Check(int obj_len, string obj_text, int line_no, string error_msg)
        //{
        //    bool bl = false;
        //    if (cf.IsByteLengthOver(obj_len, obj_text))
        //    {
        //        bbl.ShowMessage("E276", line_no.ToString(), error_msg);
        //        bl = true;
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

        //public bool Number_Check(string csv_number, int line_no, string error_msg)
        //{
        //    bool bl = false; //int result;
        //    int n;
        //    decimal d;
        //    if (!string.IsNullOrEmpty(csv_number))
        //    {
        //        if (!int.TryParse(csv_number, out n))
        //        {
        //            if (!decimal.TryParse(csv_number, out d))
        //            {
        //                bbl.ShowMessage("E276", line_no.ToString(), error_msg);
        //                bl = true;
        //            }
        //        }
        //    }
        //    return bl;
        //}

        public void Creat_Datatable_Column(DataTable create_dt)
        {
            create_dt.Columns.Add("TokuisakiCD");
            create_dt.Columns.Add("KouritenCD");
            create_dt.Columns.Add("TokuisakiRyakuName");    
            create_dt.Columns.Add("KouritenRyakuName");
            create_dt.Columns.Add("DenpyouNO");
            create_dt.Columns.Add("DenpyouDate");
            create_dt.Columns.Add("ChangeDate");
            create_dt.Columns.Add("HinbanCD");
            create_dt.Columns.Add("ColorRyakuName");
            create_dt.Columns.Add("SizeNO");
            create_dt.Columns.Add("JANCD");
            create_dt.Columns.Add("ShukkaSuu");
            create_dt.Columns.Add("UnitPrice");
            create_dt.Columns.Add("SellingPrice");
            create_dt.Columns.Add("ShukkaDenpyouTekiyou");
            create_dt.Columns.Add("ShukkaSiziNO");
            create_dt.Columns.Add("InsertOperator");
            create_dt.Columns.Add("UpdateOperator");
            create_dt.Columns.Add("ProgramID");
            create_dt.Columns.Add("PC");
            create_dt.Columns.Add("Error");            
        }

        public void Column_Remove_Datatable(DataTable remove_dt)
        {
            remove_dt.Columns.Remove("HinbanCD");
            remove_dt.Columns.Remove("ColorRyakuName");
            remove_dt.Columns.Remove("SizeNO");
            remove_dt.Columns.Remove("JANCD");
            remove_dt.Columns.Remove("ShukkaSuu");
            remove_dt.Columns.Remove("UnitPrice");
            remove_dt.Columns.Remove("SellingPrice");
            remove_dt.Columns.Remove("ShukkaSiziNO");
            //remove_dt.Columns.Remove("ShukkaGyouNO");
        }

        private void txtDate2_KeyDown(object sender, KeyEventArgs e)
        {
            DataGridviewBind();
        }        
    }
}
