using BL;
using CKM_CommonFunction;
using Entity;
using Shinyoh;
using Shinyoh_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterTouroku_Tokuisaki {
    public partial class MasterTouroku_Tokuisaki : BaseForm {
        BaseEntity base_Entity;
        CommonFunction cf;
        BaseBL bl;
        ErrorCheck err = new ErrorCheck();
        string YuuBinNO1 = string.Empty;
        string YuuBinNO2 = string.Empty;
        string Address1 = string.Empty;
        string Address2 = string.Empty;

        public MasterTouroku_Tokuisaki()
        {
            InitializeComponent();
            cf = new CommonFunction();
            bl= new BaseBL();
        }

        private void MasterTouroku_Tokuisaki_Load(object sender, EventArgs e)
        {
            multipurposeEntity multipurposeEntity = new multipurposeEntity();
            ProgramID = "MasterTourokuTokuisaki";
            StartProgram();
            cboMode.Bind(false,multipurposeEntity);
            txtStaffCharge.lblName = lblStaffCD_Name;

            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "新規(F2)", true);
            SetButton(ButtonType.BType.Update, F3, "修正(F3)", true);
            SetButton(ButtonType.BType.Delete, F4, "削除(F4)", true);
            SetButton(ButtonType.BType.Inquiry, F5, "照会(F5)", true);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", false);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            SetButton(ButtonType.BType.Empty, F8, "", false);
            SetButton(ButtonType.BType.Import, F10, "CSV取込(F10)", true);
            SetButton(ButtonType.BType.Empty, F11, "", false);
            txt_Tokuisaki.Focus();
            ChangeMode(Mode.New);
            base_Entity = _GetBaseData();

            txtStaffCharge.ChangeDate = txtChange_Date;
            txt_Tokuisaki.ChangeDate = txtChange_Date;
            txtTokuisakiCopy.ChangeDate = txtTokuisaki_CopyDate;
           
        }

        private void ChangeMode(Mode mode)
        {
            Mode_Setting();
            switch (mode)
            {
                case Mode.New:
                    ErrorCheck();
                    txtChange_Date.E132Check(true, "M_Tokuisaki", txt_Tokuisaki, txtChange_Date, null);
                    txtChange_Date.E133Check(false, "M_Tokuisaki", txt_Tokuisaki, txtChange_Date, null);
                    txtChange_Date.E270Check(false, "M_Tokuisaki", txt_Tokuisaki, txtChange_Date);

                    txtTokuisaki_CopyDate.E103Check(true);
                    txtTokuisaki_CopyDate.E102MultiCheck(true, txtTokuisakiCopy, txtTokuisaki_CopyDate);
                    txtTokuisaki_CopyDate.E133Check(true, "M_Tokuisaki", txtTokuisakiCopy, txtTokuisaki_CopyDate, null);

                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    break;

                case Mode.Update:
                    ErrorCheck();
                    txtChange_Date.E132Check(false, "M_Tokuisaki", txt_Tokuisaki, txtChange_Date, null);
                    txtChange_Date.E133Check(true, "M_Tokuisaki", txt_Tokuisaki, txtChange_Date, null);
                    txtChange_Date.E270Check(false, "M_Tokuisaki", txt_Tokuisaki, txtChange_Date);

                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    txtChange_Date.E132Check(false, "M_Tokuisaki", txt_Tokuisaki, txtChange_Date, null);
                    txtChange_Date.E133Check(true, "M_Tokuisaki", txt_Tokuisaki, txtChange_Date, null);
                    txtChange_Date.E270Check(true, "M_Tokuisaki", txt_Tokuisaki, txtChange_Date);

                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;

                    break;
                case Mode.Inquiry:
                    txtChange_Date.E132Check(false, "M_Tokuisaki", txt_Tokuisaki, txtChange_Date, null);
                    txtChange_Date.E133Check(true, "M_Tokuisaki", txt_Tokuisaki, txtChange_Date, null);
                    txtChange_Date.E270Check(false, "M_Tokuisaki", txt_Tokuisaki, txtChange_Date);

                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;
                    break;
            }
        }
        private void Mode_Setting()
        {
            cf.Clear(PanelTitle);
            cf.Clear(PanelDetail);
            lblStaffCD_Name.Text = string.Empty;

            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(PanelDetail);
            txt_Tokuisaki.Focus();
            //txtSearch.Text = "0";
            lblStaffCD_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            if (cboMode.SelectedValue.Equals("2") || cboMode.SelectedValue.Equals("3") || cboMode.SelectedValue.Equals("4"))
            {
                txtTokuisakiCopy.Enabled = false;
                txtTokuisaki_CopyDate.Enabled = false;
            }
        }
        public void ErrorCheck()
        {
            txtYubin2.E102MultiCheck(true, txtYubin1, txtYubin2);
            txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, string.Empty, string.Empty);

            txt_Tokuisaki.E102Check(true);
            txtChange_Date.E102Check(true);
            txtChange_Date.E103Check(true);

            txtTokuisakiName.E102Check(true);
            txtShortName.E102Check(true);
            txtBillAddress.E102Check(true);

            txtStaffCharge.E102Check(true);
            txtStaffCharge.E101Check(true, "M_Staff", txtStaffCharge, txtChange_Date, null);

            txtStartDate.E103Check(true);
            txtEndDate.E103Check(true);
            txtEndDate.E104Check(true, txtStartDate, txtEndDate);

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
            }
            if (tagID == "10")
            {
               // if (ErrorCheck(PanelTitle) && ErrorCheck(PanelDetail))
               // {
                    string Xml = ChooseFile();
                    BaseBL bbl = new BaseBL();
                    if (bbl.ShowMessage("Q206") != DialogResult.Yes)
                    {
                        PreviousCtrl.Focus();
                    }
                    else
                    {
                        TokuisakiBL bl = new TokuisakiBL();
                        string chk_val = string.Empty;
                        if (sRadRegister.Checked)
                            chk_val = "create_update";
                        else chk_val = "delete";
                        bl.CSV_M_Tokuisaki_CUD(Xml, chk_val);
                    }
               // }
            }
            if (tagID == "12")
            {
                if (ErrorCheck(PanelTitle) && ErrorCheck(PanelDetail))
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
            TokuisakiEntity tokuisaki = GetInsert();

            if (cboMode.SelectedValue.Equals("1"))
            {
                tokuisaki.Mode = "New";
                DoInsert(tokuisaki);
            }
            else if (cboMode.SelectedValue.Equals("2"))
            {
                tokuisaki.Mode = "Update";
                DoUpdate(tokuisaki);
            }
            else if (cboMode.SelectedValue.Equals("3"))
            {
                tokuisaki.Mode = "Delete";
                DoDelete(tokuisaki);
            }
        }

        private TokuisakiEntity GetInsert()
        {
            TokuisakiEntity obj = new TokuisakiEntity();
            obj.TokuisakiCD = txt_Tokuisaki.Text;
            obj.ChangeDate = txtChange_Date.Text;
            obj.ShokutiFLG = chk.Checked ? 1 : 0;
            if (RadSaMa.Checked == true)
            {
                obj.AliasKBN = 1;
            }else if(RadOnchuu.Checked == true)
                obj.AliasKBN = 2;
            if(RadNeed.Checked == true)
            {
                obj.ShukkaSizishoHuyouKBN = 0;
            }else if(RadNoNeed.Checked == true)
                obj.ShukkaSizishoHuyouKBN = 1;
            obj.TokuisakiName = txtTokuisakiName.Text;
            obj.TokuisakiRyakuName = txtShortName.Text;
            obj.KanaName = txtKanaName.Text;
            obj.SeikyuusakiCD = txtBillAddress.Text;
            obj.YuubinNO1 = txtYubin1.Text;
            obj.YuubinNO2 = txtYubin2.Text;
            obj.Juusho1 = txtAddress1.Text;
            obj.Juusho2 = txtAddress2.Text;
            obj.Tel11 = txtPhNo1.Text;
            obj.Tel12 = txtPhNo2.Text;
            obj.Tel13 = txtPhNo3.Text;
            obj.Tel21 = txtPhNo4.Text;
            obj.Tel22 = txtPhNo5.Text;
            obj.Tel23 = txtPhNo6.Text;
            obj.TantouBusho = txtDepCharge.Text;
            obj.TantouYakushoku = txtJobTitle.Text;
            obj.TantoushaName = txtPersonCharge.Text;
            obj.MailAddress = txtMailAddress.Text;
            obj.StaffCD = txtStaffCharge.Text;
            obj.TorihikiKaisiDate = txtStartDate.Text;
            obj.TorihikiShuuryouDate = txtEndDate.Text;
            obj.Remarks = txtRemark.Text;
            int int_val = 0;
            int.TryParse(txtSearch.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out int_val);
            obj.KensakuHyouziJun = int_val.ToString();
            obj.UsedFlg = 0;
            obj.InsertOperator = base_Entity.OperatorCD;
            obj.UpdateOperator = base_Entity.OperatorCD;

            //for log table
            obj.PC = base_Entity.PC;
            obj.KeyItem = txt_Tokuisaki.Text + " " + txtChange_Date.Text;
            return obj;
        }

        private void DoInsert(TokuisakiEntity tokuisakiEntity)
        {
            TokuisakiBL bl = new TokuisakiBL();
            bl.M_Tokuisaki_CUD(tokuisakiEntity);
        }
        private void DoUpdate(TokuisakiEntity tokuisakiEntity)
        {
            TokuisakiBL bl = new TokuisakiBL();
            bl.M_Tokuisaki_CUD(tokuisakiEntity);
        }
        private void DoDelete(TokuisakiEntity tokuisakiEntity)
        {
            TokuisakiBL bl = new TokuisakiBL();
            bl.M_Tokuisaki_CUD(tokuisakiEntity);
        }
        private void From_DB_To_TokuForm(DataTable dt)
        {
           if(dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["MessageID"].ToString() == "E132")
                {
                    if (dt.Rows[0]["ShokutiFLG"].ToString().Equals("1"))
                    {
                        chk.Checked = true;
                    }
                    else
                        chk.Checked = false;
                    txtTokuisakiName.Text = dt.Rows[0]["TokuisakiName"].ToString();
                    txtShortName.Text = dt.Rows[0]["TokuisakiRyakuName"].ToString();
                    txtKanaName.Text = dt.Rows[0]["KanaName"].ToString();
                    txtBillAddress.Text = dt.Rows[0]["SeikyuusakiCD"].ToString();

                    if (dt.Rows[0]["AliasKBN"].ToString().Equals("1"))
                    {
                        RadSaMa.Checked = true;
                    }
                    else if(dt.Rows[0]["AliasKBN"].ToString().Equals("2"))
                        RadOnchuu.Checked = true;

                    txtYubin1.Text = dt.Rows[0]["YuubinNO1"].ToString();
                    txtYubin2.Text = dt.Rows[0]["YuubinNO2"].ToString();
                    txtAddress1.Text = dt.Rows[0]["Juusho1"].ToString();
                    txtAddress2.Text = dt.Rows[0]["Juusho2"].ToString();
                    txtPhNo1.Text = dt.Rows[0]["Tel11"].ToString();
                    txtPhNo2.Text = dt.Rows[0]["Tel12"].ToString();
                    txtPhNo3.Text = dt.Rows[0]["Tel13"].ToString();
                    txtPhNo4.Text = dt.Rows[0]["Tel21"].ToString();
                    txtPhNo5.Text = dt.Rows[0]["Tel22"].ToString();
                    txtPhNo6.Text = dt.Rows[0]["Tel23"].ToString();
                    txtDepCharge.Text = dt.Rows[0]["TantouBusho"].ToString();
                    txtJobTitle.Text = dt.Rows[0]["TantouYakushoku"].ToString();
                    txtPersonCharge.Text = dt.Rows[0]["TantoushaName"].ToString();
                    txtMailAddress.Text = dt.Rows[0]["MailAddress"].ToString();
                    txtStaffCharge.Text = dt.Rows[0]["StaffCD"].ToString();
                    txtStartDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["TorihikiKaisiDate"]);
                    txtEndDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["TorihikiShuuryouDate"]);

                    if (dt.Rows[0]["ShukkaSizishoHuyouKBN"].ToString().Equals("0"))
                    {
                        RadNeed.Checked = true;
                    }
                    else if (dt.Rows[0]["ShukkaSizishoHuyouKBN"].ToString().Equals("1"))
                        RadNoNeed.Checked = true;

                    txtRemark.Text = dt.Rows[0]["Remarks"].ToString();
                    txtSearch.Text = dt.Rows[0]["KensakuHyouziJun"].ToString();

                    txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, dt.Rows[0]["YuubinNO1"].ToString(), dt.Rows[0]["YuubinNO2"].ToString());
                }
            }
        }

        private void txtTokuisaki_CopyDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cboMode.SelectedValue.ToString() == "1")
            {
                if (!txtTokuisaki_CopyDate.IsErrorOccurs)
                {
                    EnablePanel();
                    DataTable dt = txtTokuisaki_CopyDate.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                        From_DB_To_TokuForm(dt);
                }
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
                        txtAddress1.Text = dt.Rows[0]["Juusho1"].ToString();
                        txtAddress2.Text = dt.Rows[0]["Juusho2"].ToString();
                    }
                    else
                    {
                        if (txtYubin1.Text != YuuBinNO1 || txtYubin2.Text != YuuBinNO2)
                        {
                            txtAddress1.Text = string.Empty;
                            txtAddress2.Text = string.Empty;
                        }
                        else
                        {
                            txtAddress1.Text = Address1;
                            txtAddress2.Text = Address2;
                        }
                    }
                }
            }
        }
        private void txtChange_Date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtChange_Date.IsErrorOccurs)
                {
                    if (cboMode.SelectedValue.ToString() == "2")//update
                    {
                        EnablePanel();
                    }
                    else if (cboMode.SelectedValue.ToString() == "3" || cboMode.SelectedValue.ToString() == "4")
                    {
                        cf.DisablePanel(PanelTitle);
                    }
                }
                DataTable dt = txtChange_Date.IsDatatableOccurs;
                if (dt.Rows.Count > 0 && cboMode.SelectedValue.ToString() != "1")
                {
                    From_DB_To_TokuForm(dt);
                }

                //txtStaffCharge.ChangeDate = txtChange_Date;
            }
        }
        private void EnablePanel()
        {
            cf.EnablePanel(PanelDetail);
            chk.Focus();
            cf.DisablePanel(PanelTitle);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //string value = txtSearch.Text.Replace(",", "");
            //ulong ul;
            //if (ulong.TryParse(value, out ul))
            //{
            //    txtSearch.TextChanged -= txtSearch_TextChanged;
            //    txtSearch.Text = string.Format("{0:#,#0}", ul);
            //    txtSearch.SelectionStart = txtSearch.Text.Length;
            //    txtSearch.TextChanged += txtSearch_TextChanged;
            //}
            //else
            //{
            //    txtSearch.Text = "0";
            //}
        }
        private string ChooseFile()
        {

            var filePath = string.Empty;
            TokuisakiEntity obj = new TokuisakiEntity();
            string Xml = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\CSV Folder\\";
                openFileDialog.Title = "Browse CSV Files";
                openFileDialog.Filter = "csv files (*.csv)|*.csv";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                DataTable create_dt = new DataTable();
                Create_Datatable_Column(create_dt);
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    string[] csvRows = File.ReadAllLines(filePath);
                    var bl_List = new List<bool>();
                    for (int i = 1; i < csvRows.Length; i++)
                    {
                        var splits = csvRows[i].Split(',');
                        obj.TokuisakiCD = splits[0];
                        bl_List.Add(Null_Check(obj.TokuisakiCD));
                        bl_List.Add(Byte_Check(10, obj.TokuisakiCD));

                        //
                        obj.ChangeDate = splits[1];
                        bl_List.Add(Null_Check(obj.ChangeDate));
                        bl_List.Add(Date_Check(obj.ChangeDate));

                        //
                        obj.ShokutiFLG = Convert.ToInt32(splits[2]);
                        if (!(obj.ShokutiFLG == 0 || obj.ShokutiFLG == 1))
                        {
                            bl.ShowMessage("E117", "0", "1");
                            //err.ShowErrorMessage("E117");
                            bl_List.Add(true);
                        }
                        bl_List.Add(Null_Check(obj.ShokutiFLG.ToString()));

                        //
                        obj.TokuisakiName = splits[3];
                        bl_List.Add(Null_Check(obj.TokuisakiName.ToString()));
                        bl_List.Add(Byte_Check(80, obj.TokuisakiName));

                        //
                        obj.TokuisakiRyakuName = splits[4];
                        bl_List.Add(Null_Check(obj.TokuisakiRyakuName.ToString()));
                        bl_List.Add(Byte_Check(40, obj.TokuisakiRyakuName));

                        //
                        obj.KanaName = splits[5];
                        bl_List.Add(Byte_Check(80, obj.KanaName));

                        //no error check
                        obj.KensakuHyouziJun = splits[6];

                        obj.SeikyuusakiCD = splits[7];
                        bl_List.Add(Null_Check(obj.SeikyuusakiCD.ToString()));
                        bl_List.Add(Byte_Check(10, obj.SeikyuusakiCD));

                        //
                        obj.AliasKBN = Convert.ToInt32(splits[8]);
                        if (!(obj.AliasKBN == 1 || obj.AliasKBN == 2))
                        {
                            bl.ShowMessage("E117","1","2");
                            bl_List.Add(true);
                        }
                        bl_List.Add(Null_Check(obj.AliasKBN.ToString()));              

                        //
                        obj.YuubinNO1 = splits[9];
                        bl_List.Add(Byte_Check(3, obj.YuubinNO1));

                        //
                        obj.YuubinNO2 = splits[10];
                        bl_List.Add(Byte_Check(4, obj.YuubinNO2));

                        //
                        obj.Juusho1 = splits[11];
                        bl_List.Add(Byte_Check(80, obj.Juusho1));

                        //
                        obj.Juusho2 = splits[12];
                        bl_List.Add(Byte_Check(80, obj.Juusho2));

                        //
                        obj.Tel11 = splits[13];
                        bl_List.Add(Byte_Check(6, obj.Tel11));

                        //
                        obj.Tel12 = splits[14];
                        bl_List.Add(Byte_Check(5, obj.Tel12));

                        //
                        obj.Tel13 = splits[15];
                        bl_List.Add(Byte_Check(5, obj.Tel13));

                        //
                        obj.Tel21 = splits[16];
                        bl_List.Add(Byte_Check(6, obj.Tel21));

                        //
                        obj.Tel22 = splits[17];
                        bl_List.Add(Byte_Check(5, obj.Tel22));

                        //
                        obj.Tel23 = splits[18];
                        bl_List.Add(Byte_Check(5, obj.Tel23));

                        //
                        obj.TantouBusho = splits[19];
                        bl_List.Add(Byte_Check(40, obj.TantouBusho));

                        //
                        obj.TantouYakushoku = splits[20];
                        bl_List.Add(Byte_Check(40, obj.TantouYakushoku));

                        //
                        obj.TantoushaName = splits[21];
                        bl_List.Add(Byte_Check(40, obj.TantoushaName));

                        //
                        obj.MailAddress = splits[22];
                        bl_List.Add(Byte_Check(100, obj.MailAddress));

                        //
                        obj.StaffCD = splits[23];
                        bl_List.Add(Byte_Check(10, obj.StaffCD));

                        //
                        obj.TorihikiKaisiDate = splits[24];
                        bl_List.Add(Date_Check(obj.TorihikiKaisiDate));

                        //
                        obj.TorihikiShuuryouDate = splits[25];
                        bl_List.Add(Date_Check(obj.TorihikiShuuryouDate));

                        //
                        obj.ShukkaSizishoHuyouKBN = Convert.ToInt32(splits[26]);
                        if (!(obj.ShukkaSizishoHuyouKBN == 0 || obj.ShukkaSizishoHuyouKBN == 1))
                        {
                            bl.ShowMessage("E117", "0", "1");
                            bl_List.Add(true);
                        }
                        bl_List.Add(Null_Check(obj.ShukkaSizishoHuyouKBN.ToString()));

                        //
                        obj.Remarks = splits[27];
                        bl_List.Add(Byte_Check(80, obj.Remarks));

                        //
                        DataTable dt = new DataTable();
                        StaffBL sBL = new StaffBL();
                        dt = sBL.Staff_Select_Check(obj.StaffCD, obj.ChangeDate, "E101");
                        if (dt.Rows[0]["MessageID"].ToString() == "E101")
                        {
                            err.ShowErrorMessage("E101");
                           // bl_List.Add(true);
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
                        dr[28] = "0";
                        dr[29] = base_Entity.OperatorCD;
                        dr[30] = base_Entity.OperatorCD;
                        dr[31] = error;
                        create_dt.Rows.Add(dr);
                    }

                    Xml = cf.DataTableToXml(create_dt);
                }
            }
            return Xml;
        }
        private bool Null_Check(string obj_text)
        {
            bool bl = false;
            if (string.IsNullOrWhiteSpace(obj_text))
            {
                err.ShowErrorMessage("E102");
                bl = true;
            }
            return bl;
        }
        private bool Byte_Check(int obj_len, string obj_text)
        {
            bool bl = false;
            if (cf.IsByteLengthOver(obj_len, obj_text))
            {
                err.ShowErrorMessage("E142");
                bl = true;
            }
            return bl;
        }
        public bool Date_Check(string csv_Date)
        {
            bool bl = false;
            if (!string.IsNullOrEmpty(csv_Date))
            {
                if (!cf.CheckDateValue(csv_Date))
                {
                    err.ShowErrorMessage("E103");
                    bl = true;
                }
            }
            return bl;
        }
        public void Create_Datatable_Column(DataTable create_dt)
        {
            create_dt.Columns.Add("TokuisakiCD");
            create_dt.Columns.Add("ChangeDate");
            create_dt.Columns.Add("ShokutiFLG");
            create_dt.Columns.Add("TokuisakiName");
            create_dt.Columns.Add("TokuisakiRyakuName");
            create_dt.Columns.Add("KanaName");
            create_dt.Columns.Add("KensakuHyouziJun");
            create_dt.Columns.Add("SeikyuusakiCD");
            create_dt.Columns.Add("AliasKBN");
            create_dt.Columns.Add("YuubinNO1");
            create_dt.Columns.Add("YuubinNO2");
            create_dt.Columns.Add("Juusho1");
            create_dt.Columns.Add("Juusho2");
            create_dt.Columns.Add("Tel11");
            create_dt.Columns.Add("Tel12");
            create_dt.Columns.Add("Tel13");
            create_dt.Columns.Add("Tel21");
            create_dt.Columns.Add("Tel22");
            create_dt.Columns.Add("Tel23");
            create_dt.Columns.Add("TantouBusho");
            create_dt.Columns.Add("TantouYakushoku");
            create_dt.Columns.Add("TantoushaName");
            create_dt.Columns.Add("MailAddress");
            create_dt.Columns.Add("StaffCD");
            create_dt.Columns.Add("TorihikiKaisiDate");
            create_dt.Columns.Add("TorihikiShuuryouDate");
            create_dt.Columns.Add("ShukkaSizishoHuyouKBN");
            create_dt.Columns.Add("Remarks");
            create_dt.Columns.Add("UsedFlg");
            create_dt.Columns.Add("InsertOperator");
            create_dt.Columns.Add("UpdateOperator");
            create_dt.Columns.Add("Error");
        }
    }
}


