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
        BaseBL bbl;
        ErrorCheck err = new ErrorCheck();
        string YuuBinNO1 = string.Empty;
        string YuuBinNO2 = string.Empty;
        string Address1 = string.Empty;
        string Address2 = string.Empty;

        public MasterTouroku_Tokuisaki()
        {
            InitializeComponent();
            cf = new CommonFunction();
            bbl= new BaseBL();
        }

        private void MasterTouroku_Tokuisaki_Load(object sender, EventArgs e)
        {
            multipurposeEntity multipurposeEntity = new multipurposeEntity();
            ProgramID = "MasterTouroku_Tokuisaki";
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
            ChangeMode(GetMode(Mode.New));
            base_Entity = _GetBaseData();

            txtStaffCharge.ChangeDate = txtChange_Date;
            txt_Tokuisaki.ChangeDate = txtChange_Date;
            txtTokuisakiCopy.ChangeDate = txtTokuisaki_CopyDate;

            panel2.GotFocus += RadioPanel_GotFocus;
            panel3.GotFocus += RadioPanel_GotFocus;
        }

         

        private void ChangeMode(Mode mode)
        {
            Mode_Setting();
            ErrorCheck();

            switch (mode)
            {
                case Mode.New:
                    //ErrorCheck();
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
                    //ErrorCheck();
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
            sRadRegister.Checked = true;
            RadSaMa.Checked = true;
            RadNeed.Checked = true;

            //txtSearch.Text = "0";
            lblStaffCD_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            if (cboMode.SelectedValue.Equals("2") || cboMode.SelectedValue.Equals("3") || cboMode.SelectedValue.Equals("4"))
            {
                txtTokuisakiCopy.Enabled = false;
                txtTokuisaki_CopyDate.Enabled = false;
            }

            YuuBinNO1 = string.Empty;
            YuuBinNO2 = string.Empty;
            Address1 = string.Empty;
            Address2 = string.Empty;
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
                string Xml = ChooseFile();
                BaseBL bbl = new BaseBL();
                if (!string.IsNullOrEmpty(Xml))
                {
                    TokuisakiBL bl = new TokuisakiBL();
                    string chk_val = string.Empty;
                    if (sRadRegister.Checked)
                        chk_val = "create_Err_Check";
                    else chk_val = "delete_Err_Check";
                    DataTable dt = bl.CSV_M_Tokuisaki_CUD(Xml, chk_val);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Result"].ToString().Equals("1"))
                        {
                            if (bbl.ShowMessage("Q206") != DialogResult.Yes)
                            {
                                if (PreviousCtrl != null)
                                PreviousCtrl.Focus();
                            }
                            else
                            {
                                if (sRadRegister.Checked)
                                    chk_val = "create_update";
                                else chk_val = "delete";
                                dt = bl.CSV_M_Tokuisaki_CUD(Xml, chk_val);
                                if (dt.Rows.Count > 0)
                                {
                                    if (dt.Rows[0]["Result"].ToString().Equals("1"))
                                    {
                                        bbl.ShowMessage("I002");
                                        sRadRegister.Checked = true;
                                        sRadDelete.Checked = false;
                                    }
                                }

                            }
                        }
                        else
                        {
                            bbl.ShowMessage("E276", dt.Rows[0]["SEQ"].ToString(), dt.Rows[0]["Error1"].ToString(), dt.Rows[0]["Error2"].ToString());
                        }
                    }
                }
            }
            if (tagID == "12")
            {
               // if (ErrorCheck(PanelTitle) && ErrorCheck(PanelDetail))
               // {
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
                   // }
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
            string return_Bl = bl.M_Tokuisaki_CUD(tokuisakiEntity);
            if (return_Bl == "true")
                bbl.ShowMessage("I101");
        }
        private void DoUpdate(TokuisakiEntity tokuisakiEntity)
        {
            TokuisakiBL bl = new TokuisakiBL();
            string return_Bl = bl.M_Tokuisaki_CUD(tokuisakiEntity);
            if (return_Bl == "true")
                bbl.ShowMessage("I101");
        }
        private void DoDelete(TokuisakiEntity tokuisakiEntity)
        {
            TokuisakiBL bl = new TokuisakiBL();
            string return_Bl = bl.M_Tokuisaki_CUD(tokuisakiEntity);
            if (return_Bl == "true")
                bbl.ShowMessage("I101");
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
                        //txtBillAddress.NextControlName = RadSaMa.Name;
                    }
                    else if (dt.Rows[0]["AliasKBN"].ToString().Equals("2"))
                    {
                        RadOnchuu.Checked = true;
                        //txtBillAddress.NextControlName = RadOnchuu.Name;
                    }
                      
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
                    lblStaffCD_Name.Text = dt.Rows[0]["StaffName"].ToString();
                    txtStartDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["TorihikiKaisiDate"]);
                    txtEndDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["TorihikiShuuryouDate"]);

                    if (dt.Rows[0]["ShukkaSizishoHuyouKBN"].ToString().Equals("0"))
                    {
                        RadNeed.Checked = true;
                        //txtEndDate.NextControlName = RadNeed.Name;
                    }
                    else if (dt.Rows[0]["ShukkaSizishoHuyouKBN"].ToString().Equals("1"))
                    {
                        RadNoNeed.Checked = true;
                        //txtEndDate.NextControlName = RadNoNeed.Name;
                    }

                    txtRemark.Text = dt.Rows[0]["Remarks"].ToString();
                    txtSearch.Text = dt.Rows[0]["KensakuHyouziJun"].ToString();
                    Address1 = dt.Rows[0]["Juusho1"].ToString();
                    Address2 = dt.Rows[0]["Juusho2"].ToString();
                    YuuBinNO1 = dt.Rows[0]["YuubinNO1"].ToString();
                    YuuBinNO2 = dt.Rows[0]["YuubinNO2"].ToString();
                    txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, dt.Rows[0]["YuubinNO1"].ToString(), dt.Rows[0]["YuubinNO2"].ToString());
                }
            }
        }

        
        private void txtTokuisaki_CopyDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cboMode.SelectedValue.ToString() == "1")
            {
                if (ErrorCheck(PanelTitle))
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
                        if (cboMode.SelectedValue.ToString() == "3")
                        {
                            Control btnF12 = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                            btnF12.Focus();
                        }
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
            string error = string.Empty;
            var bl_List = new List<bool>();

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
                    string[] csvRows = File.ReadAllLines(filePath,Encoding.GetEncoding(932));

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
                        dr["UsedFlg"] = "0";
                        dr["InsertOperator"] = base_Entity.OperatorCD;
                        dr["UpdateOperator"] = base_Entity.OperatorCD;
                        dr["Error"] = error;
                        create_dt.Rows.Add(dr);

                        //05_12_2021[ssa]
                        if (create_dt.Rows.Count > 0)
                        {
                            for (int r = 0; r < create_dt.Rows.Count; r++)
                            {
                                //Task NO begin 592 NMW
                                TextBox txt1 = new TextBox();
                                txt1.Text = create_dt.Rows[r]["ChangeDate"].ToString();//column_1
                                if (cf.DateCheck(txt1))
                                    create_dt.Rows[r]["ChangeDate"] = txt1.Text;
                                string date1 = create_dt.Rows[r]["ChangeDate"].ToString();//column_1

                                TextBox txt2 = new TextBox();
                                txt2.Text = create_dt.Rows[r]["TorihikiKaisiDate"].ToString();//column_2
                                if (cf.DateCheck(txt2))
                                    create_dt.Rows[r]["TorihikiKaisiDate"] = txt2.Text;
                                string date2 = create_dt.Rows[r]["TorihikiKaisiDate"].ToString();//column_2
                                TextBox txt3 = new TextBox();
                                txt3.Text = create_dt.Rows[r]["TorihikiShuuryouDate"].ToString();//column_3
                                if (cf.DateCheck(txt3))
                                    create_dt.Rows[r]["TorihikiShuuryouDate"] = txt3.Text;
                                string date3 = create_dt.Rows[r]["TorihikiShuuryouDate"].ToString();//column_3
                                //TaskNo 592 end NMW
                                int line_No = r + 1;

                                if (Date_Check(date1, line_No, "入力可能値外エラー", "項目:改定日") == "true")
                                {
                                    return null;
                                }
                                else if (Date_Check(date2, line_No, "入力可能値外エラー", "取引開始日") == "true")
                                {
                                    return null;
                                }
                                else if (Date_Check(date3, line_No, "入力可能値外エラー", "取引終了日") == "true")
                                {
                                    return null;
                                }
                                else if (r == create_dt.Rows.Count - 1)
                                {
                                    Xml = cf.DataTableToXml(create_dt);
                                }
                            }
                        }

                        //obj.TokuisakiCD = splits[0];
                        //if (Null_Check(obj.TokuisakiCD, i, "得意先CD未入力エラー")) break;
                        //if (Byte_Check(10, obj.TokuisakiCD, i, "得意先CD桁数エラー")) break;

                        ////
                        //obj.ChangeDate = splits[1];
                        //if (Null_Check(obj.ChangeDate, i, "改定日未入力エラー")) break;
                        //if (Date_Check(obj.ChangeDate, i, "入力可能値外エラー", "改定日") == "true") break;
                        //else splits[1] = Date_Check(obj.ChangeDate, i, "入力可能値外エラー", "改定日");

                        ////
                        //obj.ShokutiFLG = Convert.ToInt32(splits[2]);
                        //if (!(obj.ShokutiFLG == 0 || obj.ShokutiFLG == 1))
                        //{
                        //    bbl.ShowMessage("E276", i.ToString(), "入力可能値外エラー", "項目:諸口区分(0～1)");
                        //    //bl_List.Add(true);
                        //    break;
                        //}
                        //if (Null_Check(obj.ShokutiFLG.ToString(), i, "諸口未入力エラー")) break;

                        ////
                        //obj.TokuisakiName = splits[3];
                        //if (Null_Check(obj.TokuisakiName, i, "得意先名未入力エラー")) break;
                        //if (Byte_Check(80, obj.TokuisakiName, i, "得意先名桁数エラー")) break;

                        ////
                        //obj.TokuisakiRyakuName = splits[4];
                        //if (Null_Check(obj.TokuisakiRyakuName, i, "略名未入力エラー")) break;
                        //if (Byte_Check(40, obj.TokuisakiRyakuName, i, "略名桁数エラー")) break;

                        ////
                        //obj.KanaName = splits[5];
                        //if (Byte_Check(80, obj.KanaName, i, "カナ名桁数エラー")) break;

                        ////no error check
                        //obj.KensakuHyouziJun = splits[6];

                        //obj.SeikyuusakiCD = splits[7];
                        //if (Null_Check(obj.SeikyuusakiCD, i, "請求先CD未入力エラー")) break;
                        //if (Byte_Check(10, obj.SeikyuusakiCD, i, "請求先CD桁数エラー")) break;

                        ////
                        //obj.AliasKBN = Convert.ToInt32(splits[8]);
                        //if (!(obj.AliasKBN == 1 || obj.AliasKBN == 2))
                        //{
                        //    bbl.ShowMessage("E276", i.ToString(), "入力可能値外エラー", "項目:敬称(1～2)");
                        //    //bl_List.Add(true);
                        //    break;
                        //}
                        //if (Null_Check(obj.AliasKBN.ToString(), i, "敬称未入力エラー")) break;

                        ////
                        //obj.YuubinNO1 = splits[9];
                        //if (Byte_Check(3, obj.YuubinNO1, i, "郵便番号１桁数エラー")) break;

                        ////
                        //obj.YuubinNO2 = splits[10];
                        //if (Byte_Check(4, obj.YuubinNO2, i, "郵便番号２桁数エラー")) break;

                        ////
                        //obj.Juusho1 = splits[11];
                        //if (Byte_Check(80, obj.Juusho1, i, "住所１桁数エラー")) break;

                        ////
                        //obj.Juusho2 = splits[12];
                        //if (Byte_Check(80, obj.Juusho2, i, "住所２桁数エラー")) break;

                        ////
                        //obj.Tel11 = splits[13];
                        //if (Byte_Check(6, obj.Tel11, i, "電話番号①-1桁数エラー")) break;

                        ////
                        //obj.Tel12 = splits[14];
                        //if (Byte_Check(5, obj.Tel12, i, "電話番号①-2桁数エラー")) break;

                        ////
                        //obj.Tel13 = splits[15];
                        //if (Byte_Check(5, obj.Tel13, i, "電話番号①-3桁数エラー")) break;

                        ////
                        //obj.Tel21 = splits[16];
                        //if (Byte_Check(6, obj.Tel21, i, "電話番号②-1桁数エラー")) break;

                        ////
                        //obj.Tel22 = splits[17];
                        //if (Byte_Check(5, obj.Tel22, i, "電話番号②-2桁数エラー")) break;

                        ////
                        //obj.Tel23 = splits[18];
                        //if (Byte_Check(5, obj.Tel23, i, "電話番号②-3桁数エラー")) break;

                        ////
                        //obj.TantouBusho = splits[19];
                        //if (Byte_Check(40, obj.TantouBusho, i, "担当部署桁数エラー")) break;

                        ////
                        //obj.TantouYakushoku = splits[20];
                        //if (Byte_Check(40, obj.TantouYakushoku, i, "担当役職桁数エラー")) break;

                        ////
                        //obj.TantoushaName = splits[21];
                        //if (Byte_Check(40, obj.TantoushaName, i, "担当者名桁数エラー")) break;

                        ////
                        //obj.MailAddress = splits[22];
                        //if (Byte_Check(100, obj.MailAddress, i, "メールアドレス桁数エラー")) break;

                        ////
                        //obj.StaffCD = splits[23];
                        //if (Null_Check(obj.StaffCD, i, "担当スタッフCD未入力エラー")) break;
                        //if (Byte_Check(10, obj.StaffCD, i, "担当スタッフCD桁数エラー")) break;

                        ////
                        //obj.TorihikiKaisiDate = splits[24];
                        //if (!string.IsNullOrEmpty(obj.TorihikiKaisiDate))
                        //{
                        //    if (Date_Check(obj.TorihikiKaisiDate, i, "入力可能値外エラー", "取引開始日") == "true") break;
                        //    else splits[24] = Date_Check(obj.TorihikiKaisiDate, i, "入力可能値外エラー", "取引開始日");
                        //}

                        ////
                        //obj.TorihikiShuuryouDate = splits[25];
                        //if (!string.IsNullOrEmpty(obj.TorihikiShuuryouDate))
                        //{
                        //    if (Date_Check(obj.TorihikiShuuryouDate, i, "入力可能値外エラー", "取引終了日") == "true") break;
                        //    else splits[25] = Date_Check(obj.TorihikiShuuryouDate, i, "入力可能値外エラー", "取引終了日");
                        //}

                        ////
                        //obj.ShukkaSizishoHuyouKBN = Convert.ToInt32(splits[26]);
                        //if (!(obj.ShukkaSizishoHuyouKBN == 0 || obj.ShukkaSizishoHuyouKBN == 1))
                        //{
                        //    bbl.ShowMessage("E276", i.ToString(), "入力可能値外エラー", "出荷指示書不要区分(0～1)");
                        //    //bl_List.Add(true);
                        //    break;

                        //}
                        //if (Null_Check(obj.ShukkaSizishoHuyouKBN.ToString(), i, "出荷指示書不要区分未入力エラー")) break;

                        ////
                        //obj.Remarks = splits[27];
                        //if (Byte_Check(80, obj.Remarks, i, "備考桁数エラー")) break;

                        ////
                        //DataTable dt = new DataTable();
                        //StaffBL sBL = new StaffBL();
                        //dt = sBL.Staff_Select_Check(obj.StaffCD, obj.ChangeDate, "E101");
                        //if (dt.Rows[0]["MessageID"].ToString() == "E101")
                        //{
                        //    bbl.ShowMessage("E276", i.ToString(), "担当スタッフCD未登録エラー");
                        //    //bl_List.Add(true);
                        //    break;
                        //}

                        //if (sRadRegister.Checked == true)
                        //{
                        //    DataTable dt1 = new DataTable();
                        //    TokuisakiBL TBL = new TokuisakiBL();
                        //    dt1 = TBL.M_Tokuisaki_Select(obj.TokuisakiCD, obj.ChangeDate, "E132");
                        //    if (dt1.Rows[0]["MessageID"].ToString() == "E132")
                        //    {
                        //        bbl.ShowMessage("E276", i.ToString(), "得意先CD登録済エラー");
                        //        //bl_List.Add(true);
                        //        break;
                        //    }
                        //}

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
                        //dr[28] = "0";
                        //dr[29] = base_Entity.OperatorCD;
                        //dr[30] = base_Entity.OperatorCD;
                        //dr[31] = error;
                        //create_dt.Rows.Add(dr);
                    }
                    //if (create_dt.Rows.Count == csvRows.Length - 1)
                    //Xml = cf.DataTableToXml(create_dt);

                   
                }
                else
                {
                    Xml = string.Empty;
                }
            }
            return Xml;
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
            //bool bl = false;
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

        private void RadSaMa_CheckedChanged(object sender, EventArgs e)
        {
            if (RadSaMa.Checked == true)
            {
                RadOnchuu.Checked = false;
                //txtBillAddress.NextControlName = RadSaMa.Name;
            }
        }

        private void RadOnchuu_CheckedChanged(object sender, EventArgs e)
        {
            if (RadOnchuu.Checked == true)
            {
                RadSaMa.Checked = false;
                //txtBillAddress.NextControlName = RadOnchuu.Name;
            }
        }

        private void RadNeed_CheckedChanged(object sender, EventArgs e)
        {
            if (RadNeed.Checked == true)
            {
                RadNoNeed.Checked = false;
                //txtEndDate.NextControlName = RadNeed.Name;
            }
        }

        private void RadNoNeed_CheckedChanged(object sender, EventArgs e)
        {
            if (RadNoNeed.Checked == true)
            {
                RadNeed.Checked = false;
                //txtEndDate.NextControlName = RadNoNeed.Name;
            }
        }
    }
}


