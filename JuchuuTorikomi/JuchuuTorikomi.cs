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

            DataTable dt = bl.M_Multiporpose_SelectData(string.Empty, 3, string.Empty, string.Empty);

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
            txtImportFolder.E102Check(true);
            txtImportFileName.E102Check(true);
            txtDate1.E103Check(true);
            txtDate2.E103Check(true);
            txtDenpyouNO.E102Check(true);
            txtDenpyouNO.E160Check(true, "JuchuuTorikomi", txtDenpyouNO, null);
            //txtDenpyouNO.E265Check(true, "JuchuuTorikomi", txtDenpyouNO, null);
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "6")
            {
                Clear();
            }
            if (tagID == "10")
            {
                GridviewBind();
            }
            if (tagID == "12")
            {
                (string, string) Xml = GetFile();
                BaseBL bbl = new BaseBL();
                if (!string.IsNullOrEmpty(Xml.Item1) && !string.IsNullOrEmpty(Xml.Item2))
                {

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
            gvJuchuuTorikomi.ClearSelection();
        }
        private void GridviewBind()
        {
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
        }
        private (string, string) GetFile()
        {
            var filepath = string.Empty;
            JuchuuTorikomiEntity JEntity = new JuchuuTorikomiEntity();
            string Xml_Main = string.Empty;
            string Xml_Detail = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\csv\\";
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
                        var splits = csvRows[i].Split(',');
                        JEntity.JuchuuDate= splits[0];
                        if (Null_Check(JEntity.JuchuuDate, i, "受注日")) break;
                        if(Date_Check(JEntity.JuchuuDate,i, "受注日")) break;

                        JEntity.TokuisakiCD = splits[1];
                        if (Null_Check(JEntity.TokuisakiCD, i, "得意先CD")) break;
                        if (Byte_Check(10, JEntity.TokuisakiCD, i, "得意先CD")) break;

                        JEntity.TokuisakiName = splits[2];
                        if (Null_Check(JEntity.TokuisakiName, i, "得意先名")) break;
                        if (Byte_Check(80, JEntity.TokuisakiName, i, "得意先名")) break;

                        JEntity.KouritenCD = splits[3];
                        if (Null_Check(JEntity.KouritenCD, i, "小売店CD")) break;
                        if (Byte_Check(10, JEntity.KouritenCD, i, "小売店CD")) break;

                        JEntity.KouritenName = splits[4];
                        if (Null_Check(JEntity.KouritenName, i, "小売店名")) break;
                        if (Byte_Check(80, JEntity.KouritenName, i, "得意先名")) break;

                        JEntity.StaffCD = splits[5];
                        if (Null_Check(JEntity.StaffCD, i, "担当スタッフCD")) break;
                        if (Byte_Check(10, JEntity.StaffCD, i, "担当スタッフCD")) break;

                        JEntity.ShouhinCD = splits[10];
                        if (Null_Check(JEntity.ShouhinCD, i, "商品CD")) break;
                        if (Byte_Check(20, JEntity.ShouhinCD, i, "商品CD")) break;

                        JEntity.KibouNouki = splits[7];
                        if (Date_Check(JEntity.KibouNouki, i, "希望納期")) break;

                        JEntity.ColorNO = splits[11];
                        if (Null_Check(JEntity.ColorNO, i, "カラー")) break;

                        JEntity.SizeNO = splits[12];
                        if (Null_Check(JEntity.SizeNO, i, "サイズ")) break;

                        JEntity.JANCD = splits[13];
                        if (Null_Check(JEntity.JANCD, i, "JANCD")) break;
                        if (Byte_Check(13, JEntity.JANCD, i, "JANCD")) break;

                        JEntity.Type = splits[14];
                        if (Null_Check(JEntity.Type, i, "数量")) break;

                       
                        JEntity.SenpouHacchuuNO = splits[15];
                        if (Number_Check(JEntity.SenpouHacchuuNO, i, "発注単価")) break;

                        JEntity.JuchuuDenpyouTekiyou = splits[16];
                        if (Number_Check(JEntity.JuchuuDenpyouTekiyou, i, "受注単価")) break;

                        JEntity.SiiresakiCD = splits[18];
                        if (Null_Check(JEntity.SiiresakiCD, i, "仕入先CD")) break;
                        if (Byte_Check(10, JEntity.SiiresakiCD, i, "仕入先CD")) break;

                        JEntity.SiiresakiName = splits[19];
                        if (Byte_Check(80, JEntity.SiiresakiName, i, "仕入先名")) break;

                        JEntity.ChakuniYoteiDate = splits[20];
                        if (Null_Check(JEntity.ChakuniYoteiDate, i, "着荷予定日")) break;
                        if (Date_Check(JEntity.ChakuniYoteiDate, i, "着荷予定日")) break;


                        JEntity.SoukoCD = splits[21];
                        if (Null_Check(JEntity.SoukoCD, i, "倉庫CD")) break;
                        if (Byte_Check(10, JEntity.SoukoCD, i, "倉庫CD")) break;

                        DataTable dt = new DataTable();
                        TokuisakiBL tBL = new TokuisakiBL();
                        dt = tBL.M_Tokuisaki_Select(JEntity.TokuisakiCD, JEntity.ChangeDate, "E101");
                        if (dt.Rows[0]["MessageID"].ToString() == "E101")
                        {
                            bbl.ShowMessage("E101", i.ToString(), "得意先CD");
                            break;
                        }

                        DataTable dt1 = new DataTable();
                        KouritenBL kBL = new KouritenBL();
                        dt1 = kBL.Kouriten_Select_Check(JEntity.KouritenCD, JEntity.ChangeDate, "E101");
                        if (dt1.Rows[0]["MessageID"].ToString() == "E101")
                        {
                            bbl.ShowMessage("E101", i.ToString(), "小売店CD");
                            break;
                        }

                        DataTable dt2 = new DataTable();
                        StaffBL sBL = new StaffBL();
                        dt2 = sBL.Staff_Select_Check(JEntity.StaffCD, JEntity.ChangeDate, "E101");
                        if (dt2.Rows[0]["MessageID"].ToString() == "E101")
                        {
                            bbl.ShowMessage("E101", i.ToString(), "担当スタッフCD");
                            break;
                        }

                        DataTable dt3 = new DataTable();
                        ShukkaTorikomi_BL rBL = new ShukkaTorikomi_BL();
                        dt3 = rBL.ShukkaTorikomi_Check(JEntity.ShouhinCD, JEntity.ChangeDate, "E101", "ShouhinCD");
                        if (dt3.Rows.Count > 0 && dt3.Rows[0]["MessageID"].ToString() == "E101")
                        {
                            bbl.ShowMessage("E101", i.ToString(), "商品CD");
                            break;
                        }

                        DataTable dt4 = new DataTable();
                        ShukkaTorikomi_BL jBL = new ShukkaTorikomi_BL();
                        dt4 = jBL.ShukkaTorikomi_Check(JEntity.JANCD, JEntity.ChangeDate, "E101", "JANCD");
                        if (dt4.Rows.Count > 0 && dt4.Rows[0]["MessageID"].ToString() == "E101")
                        {
                            bbl.ShowMessage("E101", i.ToString(), "JANCD");
                            break;
                        }

                        DataTable dt5 = new DataTable();
                        SiiresakiBL SiireBL = new SiiresakiBL();
                        dt5 = SiireBL.Siiresaki_Select_Check(JEntity.SiiresakiCD, JEntity.ChangeDate, "E101");
                        if (dt5.Rows[0]["MessageID"].ToString() == "E101")
                        {
                            bbl.ShowMessage("E101", i.ToString(), "仕入先CD");
                            break;
                        }

                        DataTable dt6 = new DataTable();
                        SoukoBL soukoBL = new SoukoBL();
                        dt6 = soukoBL.Souko_Select(JEntity.SoukoCD, "E101");
                        if (dt6.Rows[0]["MessageID"].ToString() == "E101")
                        {
                            bbl.ShowMessage("E101", i.ToString(), "倉庫CD");
                            break;
                        }

                        string error = string.Empty;
                        if (bl_List.Contains(true))
                            error = "true";
                        else error = "false";

                        DataRow dr = create_dt.NewRow();
                        for (int j = 0; j < splits.Length; j++)
                        {
                            if (string.IsNullOrEmpty(splits[j]))
                                dr[j] = DBNull.Value;
                            else
                                dr[j] = splits[j].ToString();
                        }
                        dr[54] = base_Entity.OperatorCD;
                        dr[55] = base_Entity.OperatorCD;
                        dr[56] = error;
                        create_dt.Rows.Add(dr);
                    }
                    if (create_dt.Rows.Count == csvRows.Length - 1)
                        Xml_Main = cf.DataTableToXml(create_dt);
                }
                else
                {
                    Xml_Main = string.Empty;
                }
            }
            return (Xml_Detail, Xml_Main);
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
        public bool Number_Check(string csv_number, int i, string v)
        {
            bool bl = false; int result;
            if (!string.IsNullOrEmpty(csv_number))
            {
                bool parsedSuccessfully = int.TryParse(csv_number, out result);

                if (parsedSuccessfully == false)
                {
                    bbl.ShowMessage("E103");
                    bl = true;
                }
            }
            return bl;
        }
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
            create_dt.Columns.Add("JuchuuDenpyouTekiyou");
            create_dt.Columns.Add("ShouhinCD");
            create_dt.Columns.Add("ColorNO");
            create_dt.Columns.Add("SizeNO");
            create_dt.Columns.Add("JANCD");
            create_dt.Columns.Add("Type");
            create_dt.Columns.Add("HacchuuTanka");
            create_dt.Columns.Add("JuchuuNO");
            create_dt.Columns.Add("HacchuuMeisaiTekiyou");
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
            create_dt.Columns.Add("InsertOperator");
            create_dt.Columns.Add("UpdateOperator");
            create_dt.Columns.Add("Error");
        }
        private void rdo_Registration_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_Registration.Checked == true)
            {
                rdo_Delete.Checked = false;
                Enable_Panel();
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
    }
}
