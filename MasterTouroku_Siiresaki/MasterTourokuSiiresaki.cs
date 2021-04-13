using BL;
using CKM_CommonFunction;
using Entity;
using Shinyoh;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Shinyoh_Controls;

namespace MasterTouroku_Siiresaki
{
    public partial class MasterTourokuSiiresaki : BaseForm
    {
        CommonFunction cf;
        BaseEntity base_Entity;
        multipurposeEntity multi_Entity;
        ErrorCheck err = new ErrorCheck();
        string YuuBinNO1 = string.Empty;
        string YuuBinNO2 = string.Empty;
        string Address1 = string.Empty;
        string Address2 = string.Empty;
        BaseBL bbl = new BaseBL();
        public MasterTourokuSiiresaki()
        {
            InitializeComponent();
            cf = new CommonFunction();
        }

        private void MasterTourokuSiiresaki_Load(object sender, EventArgs e)
        {
            ProgramID = "MasterTouroku_Siiresaki";

            StartProgram();
            cboMode.Bind(false, multi_Entity);

            txtStaffCD.lblName = lblStaffCD_Name;
            

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

            ChangeMode(Mode.New);
            txtSupplierCD.Focus();

            base_Entity = _GetBaseData();
            txtSupplierCD.ChangeDate = txtChangeDate;
            txtCopyCD.ChangeDate = txtCopyDate;
            txtStaffCD.ChangeDate = txtChangeDate;
        }

        private void ChangeMode(Mode mode)
        {
            ////Enable && Disable
            //cf.Clear(PanelTitle);
            //cf.Clear(Panel_Detail);
            //lblStaffCD_Name.Text = string.Empty;

            //cf.EnablePanel(PanelTitle);
            //cf.DisablePanel(Panel_Detail);
            //txtSupplierCD.Focus();
            //txtSearch.Text = "0";
            //lblStaffCD_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;

            Mode_Setting();

            switch (mode)
            {
                case Mode.New:
                    ErrorCheck();

                    txtChangeDate.E132Check(true, "M_Siiresaki", txtSupplierCD, txtChangeDate,null);
                    txtChangeDate.E133Check(false, "M_Siiresaki", txtSupplierCD, txtChangeDate, null);
                    txtChangeDate.E270Check(false, "M_Siiresaki", txtSupplierCD, txtChangeDate);


                    txtCopyDate.E103Check(true);
                    txtCopyDate.E102MultiCheck(true, txtCopyCD, txtCopyDate);
                    txtCopyDate.E133Check(true, "M_Siiresaki", txtCopyCD, txtCopyDate, null);

                    
                    txtChangeDate.NextControlName = txtCopyCD.Name;
                    txtCopyCD.Enabled = true;
                    txtCopyDate.Enabled = true;

                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    break;

                case Mode.Update:
                    ErrorCheck();

                    txtChangeDate.E132Check(false, "M_Siiresaki", txtSupplierCD, txtChangeDate, null);
                    txtChangeDate.E133Check(true, "M_Siiresaki", txtSupplierCD, txtChangeDate, null);
                    txtChangeDate.E270Check(false, "M_Siiresaki", txtSupplierCD, txtChangeDate);

                    Disable_UDI_Mode();
                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    txtChangeDate.E132Check(false, "M_Siiresaki", txtSupplierCD, txtChangeDate, null);
                    txtChangeDate.E133Check(true, "M_Siiresaki", txtSupplierCD, txtChangeDate, null);

                    txtChangeDate.E270Check(true, "M_Siiresaki", txtSupplierCD, txtChangeDate);

                    Disable_UDI_Mode();
                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;

                    break;
                case Mode.Inquiry:
                    txtChangeDate.E132Check(false, "M_Siiresaki", txtSupplierCD, txtChangeDate, null);
                    txtChangeDate.E133Check(true, "M_Siiresaki", txtSupplierCD, txtChangeDate, null);
                    txtChangeDate.E270Check(false, "M_Siiresaki", txtSupplierCD, txtChangeDate);

                    Disable_UDI_Mode();
                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;
                    break;
            }
        }
        public void Disable_UDI_Mode()
        {
            txtCopyCD.Enabled = false;
            txtCopyDate.Enabled = false;
            //rdo_Registragion.Enabled = false;
            //rdo_Delete.Enabled = false;
        }
        public void ErrorCheck()
        {
            txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, string.Empty, string.Empty);

            txtSupplierCD.E102Check(true);
            txtChangeDate.E102Check(true);
            txtChangeDate.E103Check(true);

            txtSupplierName.E102Check(true);
            txtShort_Name.E102Check(true);
            txtPayCD.E102Check(true);
            txtYubin2.E102MultiCheck(true, txtYubin1, txtYubin2);
            

            txtCurrency.E102Check(true);
            txtStaffCD.E102Check(true);
            txtStaffCD.E101Check(true, "M_Staff", txtStaffCD, txtChangeDate, null);           

            txtStartDate.E103Check(true);
            txtEndDate.E103Check(true);
            txtEndDate.E104Check(true, txtStartDate, txtEndDate);
        }
        private void Mode_Setting()
        {
            cf.Clear(PanelTitle);
            cf.Clear(PanelDetail);
            lblStaffCD_Name.Text = string.Empty;

            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(PanelDetail);
            txtSupplierCD.Focus();
           // txtSearch.Text = "0";
            lblStaffCD_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;

            YuuBinNO1 = string.Empty;
            YuuBinNO2 = string.Empty;
            Address1 = string.Empty;
            Address2 = string.Empty;

            rdo_Registragion.Checked = true;
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
                if (cboMode.SelectedValue.Equals("2") || cboMode.SelectedValue.Equals("3") || cboMode.SelectedValue.Equals("4"))
                {
                    Disable_UDI_Mode();
                }
            }
            if (tagID == "10")
            {
                string Xml = ChooseFile();
                if (!string.IsNullOrEmpty(Xml))
                {
                    BaseBL bbl = new BaseBL();
                    if (bbl.ShowMessage("Q206") != DialogResult.Yes)
                    {
                        PreviousCtrl.Focus();
                    }
                    else
                    {
                        SiiresakiBL bl = new SiiresakiBL();
                        string chk_val = string.Empty;
                        if (rdo_Registragion.Checked)
                            chk_val = "create_update";
                        else chk_val = "delete";
                        DataTable dt= bl.CSV_M_Siiresaki_CUD(Xml, chk_val);
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["Result"].ToString().Equals("1"))
                            {
                                bbl.ShowMessage("I002");
                                rdo_Registragion.Checked = true;
                                rdo_Delete.Checked = false;
                            }
                                
                            else
                            {
                                bbl.ShowMessage("E276", dt.Rows[0]["SEQ"].ToString(), dt.Rows[0]["Error1"].ToString(), dt.Rows[0]["Error2"].ToString());
                            }
                        }
                    }
                }
            }
            if (tagID == "12")
            {
                //if (ErrorCheck(PanelTitle) && ErrorCheck(PanelDetail))
                //{
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
                //}
            }

            base.FunctionProcess(tagID);
        }

        private void DBProcess()
        {
            SiiresakiEntity entity = GetInsert();

            if (cboMode.SelectedValue.Equals("1"))
            {
                entity.Mode = "New";
                DoInsert(entity);
            }
            else if (cboMode.SelectedValue.Equals("2"))
            {
                entity.Mode = "Update";
                DoUpdate(entity);
            }
            else if (cboMode.SelectedValue.Equals("3"))
            {
                entity.Mode = "Delete";
                DoDelete(entity);
            }
        }

        private SiiresakiEntity GetInsert()
        {
            SiiresakiEntity obj = new SiiresakiEntity();
            obj.SiiresakiCD = txtSupplierCD.Text;
            obj.ChangeDate = txtChangeDate.Text;
            obj.ShokutiFLG = chk_Flag.Checked ? "1" : "0";
            obj.SiiresakiName = txtSupplierName.Text;
            obj.SiiresakiRyakuName = txtShort_Name.Text;
            obj.KanaName = txtLong_Name.Text;
            obj.SiharaisakiCD = txtPayCD.Text;
            obj.YuubinNO1 = txtYubin1.Text;
            obj.YuubinNO2 = txtYubin2.Text;
            obj.Juusho1 = txtAddress1.Text;
            obj.Juusho2 = txtAddress2.Text;
            obj.Tel11 = txtPhone1_1.Text;
            obj.Tel12 = txtPhone1_2.Text;
            obj.Tel13 = txtPhone1_3.Text;
            obj.Tel21 = txtPhone2_1.Text;
            obj.Tel22 = txtPhone2_2.Text;
            obj.Tel23 = txtPhone2_3.Text;
            obj.TantouBusho = txtTantouBusho.Text;
            obj.TantoushaName = txtTantoushaName.Text;
            obj.TantouYakushoku = txtTantouYakushoku.Text;
            obj.MailAddress = txtMail.Text;
            obj.TuukaCD = txtCurrency.Text;
            obj.StaffCD = txtStaffCD.Text;
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
            obj.ProgramID = base_Entity.ProgramID;
            obj.KeyItem = txtSupplierCD.Text + " " + txtChangeDate.Text;
            return obj;
        }

        private void DoInsert(SiiresakiEntity obj)
        {
            SiiresakiBL objMethod = new SiiresakiBL();
            string return_BL= objMethod.M_Siiresaki_CUD(obj);
            if (return_BL == "true")
                bbl.ShowMessage("I101");
        }
        private void DoUpdate(SiiresakiEntity obj)
        {
            SiiresakiBL objMethod = new SiiresakiBL();
            string return_BL = objMethod.M_Siiresaki_CUD(obj);
            if (return_BL == "true")
                bbl.ShowMessage("I101");
        }
        private void DoDelete(SiiresakiEntity obj)
        {
            SiiresakiBL objMethod = new SiiresakiBL();
            string return_BL = objMethod.M_Siiresaki_CUD(obj);
            if (return_BL == "true")
                bbl.ShowMessage("I102");
        }

        private void txtYubin2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
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
        }

        private void txtChangeDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtChangeDate.IsErrorOccurs)
                {
                    //if (ErrorCheck(PanelTitle))
                    //{
                        if (cboMode.SelectedValue.ToString() == "2")
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
                    //}
                }
                DataTable dt = txtChangeDate.IsDatatableOccurs;
                if (dt.Rows.Count > 0 && cboMode.SelectedValue.ToString() != "1")
                {
                    From_DB_To_Form(dt);
                }
            }
        }
        private void EnablePanel()
        {
            cf.EnablePanel(PanelDetail);
            chk_Flag.Focus();
            cf.DisablePanel(PanelTitle);
        }

        private void From_DB_To_Form(DataTable dt)
        {
            if (dt.Rows[0]["MessageID"].ToString() == "E132")
            {
                if (Convert.ToInt32(dt.Rows[0]["ShokutiFLG"]) == 1)
                    chk_Flag.Checked = true;
                else chk_Flag.Checked = false;
                txtSupplierName.Text = dt.Rows[0]["SiiresakiName"].ToString();
                txtShort_Name.Text = dt.Rows[0]["SiiresakiRyakuName"].ToString();
                txtLong_Name.Text = dt.Rows[0]["KanaName"].ToString();
                txtSearch.Text = dt.Rows[0]["KensakuHyouziJun"].ToString();
                txtPayCD.Text = dt.Rows[0]["SiharaisakiCD"].ToString();
                txtYubin1.Text = dt.Rows[0]["YuubinNO1"].ToString();
                txtYubin2.Text = dt.Rows[0]["YuubinNO2"].ToString();
                txtAddress1.Text = dt.Rows[0]["Juusho1"].ToString();
                txtAddress2.Text = dt.Rows[0]["Juusho2"].ToString();
                txtPhone1_1.Text = dt.Rows[0]["Tel11"].ToString();
                txtPhone1_2.Text = dt.Rows[0]["Tel12"].ToString();
                txtPhone1_3.Text = dt.Rows[0]["Tel13"].ToString();
                txtPhone2_1.Text = dt.Rows[0]["Tel21"].ToString();
                txtPhone2_2.Text = dt.Rows[0]["Tel22"].ToString();
                txtPhone2_3.Text = dt.Rows[0]["Tel23"].ToString();
                txtTantouBusho.Text = dt.Rows[0]["TantouBusho"].ToString();
                txtTantouYakushoku.Text = dt.Rows[0]["TantouYakushoku"].ToString();
                txtTantoushaName.Text = dt.Rows[0]["TantoushaName"].ToString();
                txtMail.Text = dt.Rows[0]["MailAddress"].ToString();
                txtCurrency.Text = dt.Rows[0]["TuukaCD"].ToString();
                txtStaffCD.Text = dt.Rows[0]["StaffCD"].ToString();
                lblStaffCD_Name.Text = dt.Rows[0]["StaffName"].ToString();
                txtStartDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["TorihikiKaisiDate"]);
                txtEndDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["TorihikiShuuryouDate"]);
                txtRemark.Text = dt.Rows[0]["Remarks"].ToString();

                Address1 = dt.Rows[0]["Juusho1"].ToString();
                Address2 = dt.Rows[0]["Juusho2"].ToString();
                YuuBinNO1 = dt.Rows[0]["YuubinNO1"].ToString();
                YuuBinNO2 = dt.Rows[0]["YuubinNO2"].ToString();
                txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, dt.Rows[0]["YuubinNO1"].ToString(), dt.Rows[0]["YuubinNO2"].ToString());
            }
        }

        private void txtCopyDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cboMode.SelectedValue.ToString() == "1")
            {
                if (ErrorCheck(PanelTitle))
                {
                    if (!txtCopyDate.IsErrorOccurs)
                    {
                        EnablePanel();
                        DataTable dt = txtCopyDate.IsDatatableOccurs;
                        if (dt.Rows.Count > 0)
                            From_DB_To_Form(dt);
                    }
                }
                else
                {
                    cf.Clear(PanelDetail);
                }
            }
        }

        //private void txtStaffCD_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (!txtStaffCD.IsErrorOccurs)
        //    {
        //        DataTable dt = txtStaffCD.IsDatatableOccurs;
        //        if (dt.Rows.Count > 0)
        //            lblStaffCD_Name.Text = dt.Rows[0]["StaffName"].ToString();
        //    }
        //}

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
            SiiresakiEntity obj = new SiiresakiEntity();
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
                    string[] csvRows = File.ReadAllLines(filePath);
                   
                    for (int i = 1; i < csvRows.Length; i++)
                    {
                        var splits = csvRows[i].Split(',');
                        //obj.SiiresakiCD = splits[0];
                        ////bl_List.Add(Null_Check(obj.SiiresakiCD,i, "仕入先CD未入力エラー"));
                        ////bl_List.Add(Byte_Check(10, obj.SiiresakiCD,i, "仕入先CD桁数エラー"));
                        //if (Null_Check(obj.SiiresakiCD, i, "仕入先CD未入力エラー")) break;
                        //if (Byte_Check(10, obj.SiiresakiCD, i, "仕入先CD桁数エラー")) break;

                        ////
                        //obj.ChangeDate = splits[1];
                        //if (Null_Check(obj.ChangeDate, i, "改定日未入力エラー")) break;
                        //if (Date_Check(obj.ChangeDate, i, "入力可能値外エラー", "改定日") == "true") break;
                        //else splits[1] = Date_Check(obj.ChangeDate, i, "入力可能値外エラー", "改定日");

                        ////
                        //obj.ShokutiFLG = string.IsNullOrEmpty(splits[2])? "" : splits[2];
                        //if(Null_Check(obj.ShokutiFLG,i, "諸口未入力エラー"))break;
                        //if (!(obj.ShokutiFLG == "0" || obj.ShokutiFLG == "1"))
                        //{
                        //    bbl.ShowMessage("E276",i.ToString(), "入力可能値外エラー", "項目:諸口区分(0～1)");
                        //    // bl_List.Add(true);
                        //    break;
                        //}
                        ////
                        //obj.SiiresakiName = splits[3];
                        //if (Null_Check(obj.SiiresakiName, i, "仕入先名未入力エラー")) break;
                        //if(Byte_Check(80, obj.SiiresakiName,i, "仕入先名桁数エラー"))break;
                        
                        ////
                        //obj.SiiresakiRyakuName = splits[4];
                        //if(Null_Check(obj.SiiresakiRyakuName,i, "略名未入力エラー"))break;
                        //if(Byte_Check(40, obj.SiiresakiRyakuName,i, "略名桁数エラー	"))break;
                        
                        ////
                        //obj.KanaName = splits[5];
                        //if(Byte_Check(80, obj.KanaName,i, "カナ名桁数エラー"))break;
                        
                        ////no error check
                        //obj.KensakuHyouziJun = splits[6];

                        ////
                        //obj.SiharaisakiCD = splits[7];
                        //if(Null_Check(obj.SiharaisakiCD,i, "支払先CD未入力エラー"))break;
                        //if(Byte_Check(10, obj.SiharaisakiCD,i, "支払先CD桁数エラー"))break;
                        
                        ////
                        //obj.YuubinNO1 = splits[8];
                        //if(Byte_Check(3, obj.YuubinNO1,i, "郵便番号１桁数エラー"))break;
                       
                        ////
                        //obj.YuubinNO2 = splits[9];
                        //if(Byte_Check(4, obj.YuubinNO2,i, "郵便番号２桁数エラー"))break;
                       
                        ////
                        //obj.Juusho1 = splits[10];
                        //if(Byte_Check(80, obj.Juusho1,i, "住所１桁数エラー"))break;
                        
                        ////
                        //obj.Juusho2 = splits[11];
                        //if(Byte_Check(80, obj.Juusho2,i, "住所２桁数エラー"))break;
                        
                        ////
                        //obj.Tel11 = splits[12];
                        //if(Byte_Check(6, obj.Tel11,i, "電話番号①-1桁数エラー"))break;
                        
                        ////
                        //obj.Tel12 = splits[13];
                        //if(Byte_Check(5, obj.Tel12,i, "電話番号①-2桁数エラー"))break;
                       
                        ////
                        //obj.Tel13 = splits[14];
                        //if(Byte_Check(5, obj.Tel13,i, "電話番号①-3桁数エラー"))break;
                        
                        ////
                        //obj.Tel21 = splits[15];
                        //if(Byte_Check(6, obj.Tel21,i, "電話番号②-1桁数エラー"))break;
                        
                        ////
                        //obj.Tel22 = splits[16];
                        //if(Byte_Check(5, obj.Tel22,i, "電話番号②-2桁数エラー"))break;
                        
                        ////
                        //obj.Tel23 = splits[17];
                        //if(Byte_Check(5, obj.Tel23,i, "電話番号②-3桁数エラー"))break;
                        
                        ////
                        //obj.TantouBusho = splits[18];
                        //if(Byte_Check(40, obj.TantouBusho,i, "担当部署桁数エラー"))break;
                        
                        ////
                        //obj.TantouYakushoku = splits[19];
                        //if(Byte_Check(40, obj.TantouYakushoku,i, "担当役職桁数エラー"))break;
                        
                        ////
                        //obj.TantoushaName = splits[20];
                        //if(Byte_Check(40, obj.TantoushaName,i, "担当者名桁数エラー"))break;
                        
                        ////
                        //obj.MailAddress = splits[21];
                        //if(Byte_Check(100, obj.MailAddress,i, "メールアドレス桁数エラー"))break;
                        
                        ////
                        //obj.TuukaCD = splits[22];
                        //if(Null_Check(obj.TuukaCD,i, "通貨CD未入力エラー"))break;
                        //if(Byte_Check(3, obj.TuukaCD,i, "通貨CD桁数エラー"))break;
                        
                        ////
                        //obj.StaffCD = splits[23];
                        //if(Null_Check(obj.StaffCD,i, "担当スタッフCD未入力エラー"))break;
                        //if(Byte_Check(10, obj.StaffCD,i,"担当スタッフCD桁数エラー"))break;
                        
                        ////
                        //obj.TorihikiKaisiDate = splits[24];
                        //if(!string.IsNullOrEmpty(obj.TorihikiKaisiDate))
                        //{
                        //    if (Date_Check(obj.TorihikiKaisiDate, i, "入力可能値外エラー", "取引開始日") == "true") break;
                        //    else splits[24] = Date_Check(obj.TorihikiKaisiDate, i, "入力可能値外エラー", "取引開始日");
                        //}
                        
                        ////
                        //obj.TorihikiShuuryouDate = splits[25];
                        //if(!string.IsNullOrEmpty(obj.TorihikiShuuryouDate))
                        //{
                        //    if (Date_Check(obj.TorihikiShuuryouDate, i, "入力可能値外エラー", "取引終了日") == "true") break;
                        //    else splits[25] = Date_Check(obj.TorihikiShuuryouDate, i, "入力可能値外エラー", "取引終了日");
                        //}
                       
                        ////
                        //obj.Remarks = splits[26];
                        //if(Byte_Check(80, obj.Remarks,i, "備考桁数エラー"))break;

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

                        //if (rdo_Registragion.Checked == true)
                        //{
                        //    DataTable dt1 = new DataTable();
                        //    SiiresakiBL SBL = new SiiresakiBL();
                        //    dt1 = SBL.Siiresaki_Select_Check(obj.SiiresakiCD, obj.ChangeDate, "E132");
                        //    if (dt1.Rows[0]["MessageID"].ToString() == "E132")
                        //    {
                        //        bbl.ShowMessage("E276", i.ToString(), "仕入先CD登録済エラー");
                        //        //bl_List.Add(true);
                        //        break;
                        //    }
                        //}

                        //if (bl_List.Contains(true))
                        //    error = "true";
                        //else error = "false";

                        DataRow dr = create_dt.NewRow();
                        for (int j=0;j<splits.Length;j++)
                        {
                            if (string.IsNullOrEmpty(splits[j]))
                                dr[j] = DBNull.Value;
                            else
                                dr[j] = splits[j].ToString();
                        }
                        dr[27] = "0";
                        dr[28] = base_Entity.OperatorCD;
                        dr[29] = base_Entity.OperatorCD;
                        dr[30] = error;
                        create_dt.Rows.Add(dr);
                    }

                    if(create_dt.Rows.Count==csvRows.Length-1)
                        Xml = cf.DataTableToXml(create_dt);
                }
                else
                {
                    Xml = string.Empty;
                }
            }
            return Xml;
        }
        
        private bool Null_Check(string obj_text,int line_no,string error_msg)
        {
            bool bl = false;
            if(string.IsNullOrWhiteSpace(obj_text))
            {
                bbl.ShowMessage("E276", line_no.ToString(), error_msg);
               // err.ShowErrorMessage("E102");
                bl = true;
            }
            return bl;
        }
        private bool Byte_Check(int obj_len,string obj_text,int line_no,string error_msg)
        {
            bool bl = false;
            if (cf.IsByteLengthOver(obj_len, obj_text))
            {
                bbl.ShowMessage("E276", line_no.ToString(), error_msg);
                // err.ShowErrorMessage("E142");
                bl = true;
            }
            return bl;
        }
        public string Date_Check(string csv_Date,int line_no,string error_msg1, string error_msg2)
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
            create_dt.Columns.Add("SiiresakiCD");
            create_dt.Columns.Add("ChangeDate");
            create_dt.Columns.Add("ShokutiFLG");
            create_dt.Columns.Add("SiiresakiName");
            create_dt.Columns.Add("SiiresakiRyakuName");
            create_dt.Columns.Add("KanaName");
            create_dt.Columns.Add("KensakuHyouziJun");
            create_dt.Columns.Add("SiharaisakiCD");
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
            create_dt.Columns.Add("TuukaCD");
            create_dt.Columns.Add("StaffCD");
            create_dt.Columns.Add("TorihikiKaisiDate");
            create_dt.Columns.Add("TorihikiShuuryouDate");
            create_dt.Columns.Add("Remarks");
            create_dt.Columns.Add("UsedFlg");
            create_dt.Columns.Add("InsertOperator");
            create_dt.Columns.Add("UpdateOperator");
            create_dt.Columns.Add("Error");
        }
    }
}

