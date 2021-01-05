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

namespace ShukkaTorikomi
{
    public partial class ShukkaTorikomi : BaseForm
    {
        CommonFunction cf;
        multipurposeEntity multi_Entity;
        ShukkaTorikomi_BL ShukkaTorikomi_BL;
        BaseBL bbl;

        public ShukkaTorikomi()
        {
            InitializeComponent();
            cf = new CommonFunction();
            multi_Entity = new multipurposeEntity();
            
            bbl = new BaseBL();
        }

        private void ShukkaTorikomi_Load(object sender, EventArgs e)
        {
            ProgramID = "ShukkaTorikomi";
            StartProgram();
            cboMode.Visible = false;

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
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);
            //multipurposeEntity multipurpose_entity = new multipurposeEntity();

            txtShukkaToNo1.Enabled = true;
            txtShukkaToNo2.Enabled = true;

            txtDate1.Enabled = false;
            txtDate2.Enabled = false;
            txtDenpyouNO.Enabled = false;

            ErrorCheck();
            dataBind();
            gvTorikomi.UseRowNo(true);
        }


        private void dataBind()
        {
            multipurposeBL bl = new multipurposeBL();

            DataTable dt = bl.M_Multiporpose_SelectData(string.Empty, 3, string.Empty, string.Empty);

            if (dt.Rows.Count > 0)
            {
                txtShukkaToNo1.Text = dt.Rows[0]["Char1"].ToString();
                txtShukkaToNo2.Text = dt.Rows[0]["Char2"].ToString();
            }
            else
            {
                txtShukkaToNo1.Text = string.Empty;
                txtShukkaToNo2.Text = string.Empty;
            }
        }

        private void rdo_Toroku_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_Toroku.Checked == true)
            {
                rdo_Sakujo.Checked = false;
                Enable_Method();
            }
        }

        private void Enable_Method()
        {
            txtShukkaToNo1.Enabled = true;
            txtShukkaToNo2.Enabled = true;
            txtDate1.Enabled = false;
            txtDate2.Enabled = false;
            txtDenpyouNO.Enabled = false;
        }
        private void Disable_Method()
        {
            txtShukkaToNo1.Text = string.Empty;
            txtShukkaToNo2.Text = string.Empty;
            txtDate1.Text = string.Empty;
            txtDate2.Text = string.Empty;
            txtDenpyouNO.Text = string.Empty;

            txtShukkaToNo1.Enabled = false;
            txtShukkaToNo2.Enabled = false;
            txtDate1.Enabled = true;
            txtDate2.Enabled = true;
            txtDenpyouNO.Enabled = true;
        }

        private void rdo_Sakujo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_Sakujo.Checked == true)
            {
                rdo_Toroku.Checked = false;
                Disable_Method();
            }
        }

        private void ErrorCheck()
        {
            txtShukkaToNo1.E102Check(true);
            txtShukkaToNo2.E102Check(true);
            txtDate1.E103Check(true);
            txtDate2.E103Check(true);
            txtDenpyouNO.E102Check(true);
            txtDenpyouNO.E165Check(true, "ShukkaTorikom", txtDenpyouNO,null);
        }

        public override void FunctionProcess(string tagID)
        {
            if (tagID == "6")
            {
                //Clear();
            }
            if (tagID == "10")
            {
                DataGridviewBind();
            }
            base.FunctionProcess(tagID);

            if (tagID == "12")
            {
                string Xml = ChooseFile();
                BaseBL bbl = new BaseBL();
                if (!string.IsNullOrEmpty(Xml))
                {
                    if (bbl.ShowMessage("Q206") != DialogResult.Yes)
                    {
                        PreviousCtrl.Focus();
                    }
                    else
                    {
                        ShukkaTorikomi_BL bl = new ShukkaTorikomi_BL();
                        string chk_val = string.Empty;
                        if (rdo_Toroku.Checked)
                            chk_val = "create_update";
                        else chk_val = "delete";
                        bl.CSV_M_ShukkaTorikomi_CUD(Xml, chk_val);
                    }
                }
            }
        }


        private void DataGridviewBind()
        {
            TorikomiEntity obj = new TorikomiEntity();
            ShukkaTorikomi_BL objMethod = new ShukkaTorikomi_BL();
            obj.TorikomiDenpyouNO = txtDenpyouNO.Text;
            DataTable dt = objMethod.ShukkaTorikomi_Select_Check(obj);
           
            gvTorikomi.DataSource = dt;
        }

        private string ChooseFile()
        {
            var filepath = string.Empty;
            TorikomiEntity obj = new TorikomiEntity();
            string Xml = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\CSV Folder\\";
                openFileDialog.Title = "Browse CSV Files";
                openFileDialog.Filter = "csv files (*.csv)|*.csv";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                DataTable create_dt = new DataTable();
                Creat_Datatable_Column(create_dt);
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filepath = openFileDialog.FileName;
                    string[] csvRows = File.ReadAllLines(filepath);
                    var bl_List = new List<bool>();
                    for (int i = 1; i < csvRows.Length; i++)
                    {
                        var splits = csvRows[i].Split(',');
                        obj.TokuisakiCD = splits[0];
                        bl_List.Add(Null_Check(obj.TokuisakiCD, i, "得意先CD未入力エラー"));
                        bl_List.Add(Byte_Check(10, obj.TokuisakiCD, i, "得意先CD桁数エラー"));

                       
                        

                        obj.KouritenCD = splits[1];
                        bl_List.Add(Null_Check(obj.KouritenCD, i, "小売店CD未入力エラー"));
                        bl_List.Add(Byte_Check(10, obj.KouritenCD, i, "小売店CD桁数エラー"));


                        obj.TokuisakiRyakuName = splits[2];
                        bl_List.Add(Null_Check(obj.TokuisakiRyakuName, i, "得意先略名未入力エラー"));
                        bl_List.Add(Byte_Check(40, obj.TokuisakiRyakuName, i, "得意先略名桁数エラー"));

                        obj.KouritenRyakuName = splits[3];
                        bl_List.Add(Null_Check(obj.KouritenRyakuName, i, "略名未入力エラー"));
                        bl_List.Add(Byte_Check(40, obj.KouritenRyakuName, i, "略名桁数エラー"));

                        obj.DenpyouDate = splits[4];
                        bl_List.Add(Null_Check(obj.DenpyouDate, i, "伝票日付未入力エラー"));
                        bl_List.Add(Date_Check(obj.DenpyouDate, i, "入力可能値外エラー"));


                        obj.ChangeDate = splits[5];
                        bl_List.Add(Null_Check(obj.ChangeDate, i, "改定日未入力エラー"));
                        bl_List.Add(Date_Check(obj.ChangeDate, i, "入力可能値外エラー"));


                        obj.ShouhinCD = splits[6];
                        bl_List.Add(Null_Check(obj.ShouhinCD, i, "商品コード未入力エラー"));
                        bl_List.Add(Byte_Check(10,obj.ShouhinCD, i, "商品コード桁数エラー"));

                        obj.ColorRyakuName = splits[7];
                        bl_List.Add(Null_Check(obj.ColorRyakuName, i, "カラー未入力エラー"));
                      

                        obj.SizeNO = splits[8];
                        bl_List.Add(Null_Check(obj.SizeNO, i, "ｻｲｽﾞ未入力エラー"));
                        

                        obj.JANCD = splits[9];
                        bl_List.Add(Null_Check(obj.JANCD, i, "JANｺｰﾄﾞ未入力エラー"));
                        bl_List.Add(Byte_Check(10,obj.JANCD, i, "JANｺｰﾄﾞ桁数エラー"));

                        obj.ShukkaSuu = splits[10];
                        bl_List.Add(Null_Check(obj.ShukkaSuu, i, "数量未入力エラー"));
                        bl_List.Add(Date_Check(obj.ShukkaSuu, i, "入力可能値外エラー"));


                        obj.ShukkaSiziGyouNO = splits[11];
                        bl_List.Add(Null_Check(obj.ShukkaSiziGyouNO, i, "出荷指示行番号未入力エラー"));
                        bl_List.Add(Byte_Check(10,obj.ShukkaSiziGyouNO, i, "出荷指示行番号桁数エラー"));

                        obj.UnitPrice = splits[12];
                        bl_List.Add(Date_Check(obj.UnitPrice, i, "入力可能値外エラー"));

                        obj.SellingPrice = splits[13];
                        bl_List.Add(Date_Check(obj.SellingPrice, i, "入力可能値外エラー"));

                        TokuisakiBL tBL = new TokuisakiBL();
                        DataTable t_dt = tBL.M_Tokuisaki_Select(obj.TokuisakiCD, obj.ChangeDate, "E101");
                        if (t_dt.Rows[0]["MessageID"].ToString() == "E101")
                        {
                            bbl.ShowMessage("E101");
                            //err.ShowErrorMessage("E101");
                            bl_List.Add(true);
                        }

                       
                        KouritenBL kBL = new KouritenBL();
                        DataTable k_dk = kBL.Kouriten_Select_Check(obj.KouritenCD, obj.ChangeDate, "E101");
                        if (k_dk.Rows[0]["MessageID"].ToString() == "E101")
                        {
                            bbl.ShowMessage("E101");
                            //err.ShowErrorMessage("E101");
                            bl_List.Add(true);
                        }

                        ShukkaTorikomi_BL rBL = new ShukkaTorikomi_BL();
                        DataTable r_dk = rBL.ShukkaTorikomi_Check(obj.ShouhinCD, obj.ChangeDate, "E101", "ShouhinCD");
                        if (r_dk.Rows[0]["MessageID"].ToString() == "E101")
                        {
                            bbl.ShowMessage("E101");
                            //err.ShowErrorMessage("E101");
                            bl_List.Add(true);
                        }

                        ShukkaTorikomi_BL jBL = new ShukkaTorikomi_BL();
                        DataTable j_dk = jBL.ShukkaTorikomi_Check(obj.JANCD, obj.ChangeDate, "E101", "JANCD");
                        if (j_dk.Rows[0]["MessageID"].ToString() == "E101")
                        {
                            bbl.ShowMessage("E101");
                            //err.ShowErrorMessage("E101");
                            bl_List.Add(true);
                        }
                    }
                }

            }
            return Xml;
        }

        private bool Null_Check(string obj_text, int line_no, string error_msg)
        {
            bool bl = false;
            if (string.IsNullOrWhiteSpace(obj_text))
            {
                bbl.ShowMessage("E102", line_no.ToString(), error_msg);
                bl = true;
            }
            return bl;
        }
        private bool Byte_Check(int obj_len, string obj_text, int line_no, string error_msg)
        {
            bool bl = false;
            if (cf.IsByteLengthOver(obj_len, obj_text))
            {
                bbl.ShowMessage("E142");
                bl = true;
            }
            return bl;
        }

        public bool Date_Check(string csv_Date, int line_no, string error_msg)
        {
            bool bl = false;
            if (!string.IsNullOrEmpty(csv_Date))
            {
                if (!cf.CheckDateValue(csv_Date))
                {
                    bbl.ShowMessage("E103");
                    bl = true;
                }
            }
            return bl;
        }

        public void Creat_Datatable_Column(DataTable create_dt)
        {
            create_dt.Columns.Add("TokuisakiCD");
            create_dt.Columns.Add("KouritenCD");
            create_dt.Columns.Add("TokuisakiRyakuName");    
            create_dt.Columns.Add("KouritenRyakuName");
            create_dt.Columns.Add("DenpyouNO");
            create_dt.Columns.Add("DenpyouDate");
            create_dt.Columns.Add("ChangeDate");
            create_dt.Columns.Add("ShouhinCD");
            create_dt.Columns.Add("ColorRyakuName");
            create_dt.Columns.Add("SizeNO");
            create_dt.Columns.Add("JANCD");
            create_dt.Columns.Add("ShukkaSuu");
            create_dt.Columns.Add("UnitPrice");
            create_dt.Columns.Add("SellingPrice");
            create_dt.Columns.Add("ShukkaSiziGyouNO");
            create_dt.Columns.Add("InsertOperator");
            create_dt.Columns.Add("UpdateOperator");
            create_dt.Columns.Add("Error");
            
        }
    }
}
