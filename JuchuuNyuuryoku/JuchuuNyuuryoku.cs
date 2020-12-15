﻿using BL;
using CKM_CommonFunction;
using Entity;
using Shinyoh;
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

namespace JuchuuNyuuryoku
{
    public partial class JuchuuNyuuryoku : BaseForm
    {
        CommonFunction cf;
        multipurposeEntity multi_Entity;
        BaseEntity base_Entity;
        BaseBL base_bl;
        KouritenDetail kobj = new KouritenDetail();
        SiiresakiDetail sobj = new SiiresakiDetail();
        TokuisakiDetail tobj = new TokuisakiDetail();
        
        DataTable gv1_to_dt1 = new DataTable();
        DataTable gv2_to_dt2 = new DataTable();
        DataTable F8_dt1 = new DataTable();
        DataTable F8_dt2 = new DataTable();

       
        public JuchuuNyuuryoku()
        {
            
            InitializeComponent();
            cf = new CommonFunction();
            base_bl = new BaseBL();
        }

        private void JuchuuNyuuryoku_Load(object sender, EventArgs e)
        {
            ProgramID = "JuchuuNyuuryoku";
            StartProgram();

            cboMode.Bind(false, multi_Entity);

            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "新規(F2)", true);
            SetButton(ButtonType.BType.Update, F3, "変更(F3)", true);
            SetButton(ButtonType.BType.Delete, F4, "削除(F4)", true);
            SetButton(ButtonType.BType.Inquiry, F5, "照会(F5)", true);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", false);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", true);
            SetButton(ButtonType.BType.Display, F10, "表示(F10)", true);
            SetButton(ButtonType.BType.Search, F11, "保存(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);

            txtTokuisakiCD.lblName = lblTokuisaki_Name;
            txtKouritenCD.lblName = lblKouriten_Name;
            txtStaffCD.lblName = lblStaff_Name;
            txtBrandCD.lblName = lblBrand_Name;

            txtTokuisakiCD.ChangeDate = txtJuchuuDate;
            txtKouritenCD.ChangeDate = txtJuchuuDate;
            txtStaffCD.ChangeDate = txtJuchuuDate;

            ChangeMode(Mode.New);

            base_Entity = _GetBaseData();

        }

        private void ChangeMode(Mode mode)
        {
            Mode_Setting();
            switch (mode)
            {
                case Mode.New:
                    ErrorCheck();
                    txtJuchuuNO.E102Check(false);
                    txtJuchuuNO.E133Check(false, "JuchuuNyuuryoku", txtJuchuuNO, null, null);
                    txtJuchuuNO.E160Check(false, "JuchuuNyuuryoku", txtJuchuuNO, null);

                    txtCopy.E102Check(true);
                    txtCopy.E133Check(true, "JuchuuNyuuryoku", txtCopy, null, null);

                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    break;

                case Mode.Update:
                    ErrorCheck();
                    txtJuchuuNO.E102Check(true);
                    txtCopy.E102Check(false);

                    txtJuchuuNO.E133Check(true, "JuchuuNyuuryoku", txtJuchuuNO, null, null);
                    txtJuchuuNO.E160Check(true, "JuchuuNyuuryoku", txtJuchuuNO, null);

                    Disable_UDI_Mode();
                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    ErrorCheck();
                    txtJuchuuNO.E102Check(true);
                    txtCopy.E102Check(false);

                    txtJuchuuNO.E133Check(true, "JuchuuNyuuryoku", txtJuchuuNO, null, null);
                    txtJuchuuNO.E160Check(true, "JuchuuNyuuryoku", txtJuchuuNO, null);

                    Disable_UDI_Mode();
                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;

                    break;
                case Mode.Inquiry:
                    txtJuchuuNO.E102Check(false);
                    txtCopy.E102Check(false);

                    Disable_UDI_Mode();
                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;
                    break;
            }
        }

        private void Mode_Setting()
        {
            cf.Clear(PanelTitle);
            cf.Clear(Panel_Detail);

            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(Panel_Detail);

            lblTokuisaki_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblKouriten_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblStaff_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblBrand_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;            
            lblYear.BorderStyle = System.Windows.Forms.BorderStyle.None;


            lblTokuisaki_Name.Text = string.Empty;
            lblKouriten_Name.Text = string.Empty;
            lblStaff_Name.Text = string.Empty;
            lblBrand_Name.Text = string.Empty;

            gv1_to_dt1 = new DataTable();
            gv2_to_dt2 = new DataTable();
            F8_dt1 = new DataTable();
            F8_dt2 = new DataTable();
            txtJuchuuNO.Focus();
        }

        public void Disable_UDI_Mode()
        {
            txtCopy.Enabled = false;
        }

        public void ErrorCheck()
        {
            
            txtJuchuuDate.E102Check(true);
            txtJuchuuDate.E103Check(true);
            txtJuchuuDate.E115Check(true, "JuchuuNyuuryoku", txtJuchuuDate);
            txtTokuisakiCD.E102Check(true);
            txtTokuisakiCD.E101Check(true, "M_Tokuisaki", txtTokuisakiCD, txtJuchuuDate, null);            
            txtTokuisakiCD.E267Check(true, "M_Tokuisaki", txtTokuisakiCD, txtJuchuuDate);
            txtTokuisakiCD.E227Check(true, "M_Tokuisaki", txtTokuisakiCD, txtJuchuuDate);
            txtKouritenCD.E102Check(true);
            txtKouritenCD.E101Check(true, "M_Kouriten", txtKouritenCD, txtJuchuuDate, null);
            txtKouritenCD.E267Check(true, "M_Kouriten", txtKouritenCD, txtJuchuuDate);
            txtKouritenCD.E227Check(true, "M_Kouriten", txtKouritenCD, txtJuchuuDate);
            txtStaffCD.E102Check(true);
            txtStaffCD.E101Check(true, "M_Staff", txtStaffCD, txtJuchuuDate, null);
            txtStaffCD.E135Check(true, "M_Staff", txtStaffCD, txtJuchuuDate);
            
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
            if (tagID == "9")
            {
                SiiresakiSearch detail = new SiiresakiSearch();
                detail.ShowDialog();
            }
            if (tagID == "10")
            {
                
            }
            if (tagID == "12")
            {
                if (ErrorCheck(PanelTitle) && ErrorCheck(Panel_Detail))
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

        private void btn_Tokuisaki_Click(object sender, EventArgs e)
        {
           tobj.ShowDialog();
        }

        private void btn_Kouriten_Click(object sender, EventArgs e)
        {
            kobj.ShowDialog();
        }

        private void txtStaffCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtStaffCD.IsErrorOccurs)
                {
                    sobj.ShowDialog();
                }
            }
        }

        private void txtCopy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cboMode.SelectedValue.ToString() == "1")
            {
                if (!txtCopy.IsErrorOccurs)
                {
                    EnablePanel();
                    DataTable dt = txtCopy.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                        From_DB_To_Form(dt);
                }
            }
        }

        private void From_DB_To_Form(DataTable dt)
        {
            if (dt.Rows[0]["MessageID"].ToString() == "E132")
            {
                txtJuchuuDate.Text= String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["JuchuuDate"]);
                txtTokuisakiCD.Text = dt.Rows[0]["TokuisakiCD"].ToString();
                lblTokuisaki_Name.Text = dt.Rows[0]["TokuisakiRyakuName"].ToString();
                txtKouritenCD.Text = dt.Rows[0]["KouritenCD"].ToString();
                lblKouriten_Name.Text = dt.Rows[0]["KouritenRyakuName"].ToString();
                txtStaffCD.Text = dt.Rows[0]["StaffCD"].ToString();
                lblStaff_Name.Text = dt.Rows[0]["StaffName"].ToString();
                txtSenpouHacchuuNO.Text = dt.Rows[0]["SenpouHacchuuNO"].ToString();
                txtSenpouBusho.Text = dt.Rows[0]["SenpouBusho"].ToString();
                txtJuchuuDenpyouTekiyou.Text = dt.Rows[0]["JuchuuDenpyouTekiyou"].ToString();

                //show page load data in tokuisaki detail
                tobj.Access_Tokuisaki_obj = From_DB_To_Tokuisaki(dt);


                //show page load data in kouriten detail
                kobj.Access_Kouriten_obj = From_DB_To_Kouriten(dt);

                //show page load data in siiresaki detail
                //sobj.Access_Siiresaki_obj = From_DB_To_Siiresaki(dt);
                //
                dt.Columns.Remove("JuchuuDate");
                dt.Columns.Remove("StaffCD");
                dt.Columns.Remove("StaffName");
                dt.Columns.Remove("SenpouHacchuuNO");
                dt.Columns.Remove("SenpouBusho");
                dt.Columns.Remove("KibouNouki");
                dt.Columns.Remove("JuchuuDenpyouTekiyou");

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

               

                dt.Columns.Remove("MessageID");
                DataTable dt1 = dt.Copy();               
                dt1.Columns.Remove("JANCD");
                dt1.Columns.Remove("SoukoCD");
                dt1.Columns.Remove("SoukoName");
                dt1.Columns.Remove("SiiresakiCD");
                dt1.Columns.Remove("SiiresakiName");
                dt1.Columns.Remove("SiiresakiRyakuName");
                dt1.Columns.Remove("SiiresakiYuubinNO1");
                dt1.Columns.Remove("SiiresakiYuubinNO2");
                dt1.Columns.Remove("SiiresakiJuusho1");
                dt1.Columns.Remove("SiiresakiJuusho2");
                dt1.Columns.Remove("SiiresakiTelNO11");
                dt1.Columns.Remove("SiiresakiTelNO12");
                dt1.Columns.Remove("SiiresakiTelNO13");
                dt1.Columns.Remove("SiiresakiTelNO21");
                dt1.Columns.Remove("SiiresakiTelNO22");
                dt1.Columns.Remove("SiiresakiTelNO23");
                dt1.Columns.Remove("SiiresakiDetail");
                dt1.Columns.Remove("ExpectedDate");
                DataTable dt1_temp = dt1.Copy();
                gv1_to_dt1 = dt1_temp;
                gv_1.DataSource = dt1;

                DataTable dt2 = dt.Copy();
               // dt2.Columns.Remove("ShouhinCD");
                dt2.Columns.Remove("ShouhinName");
                dt2.Columns.Remove("ColorRyakuName");
                dt2.Columns.Remove("ColorNO");
                dt2.Columns.Remove("SizeNO");
                dt2.Columns.Remove("Free");
                dt2.Columns.Remove("GenZaikoSuu");
                dt2.Columns.Remove("JuchuuSuu");
                dt2.Columns.Remove("DJMSenpouHacchuuNO");
                dt2.Columns.Remove("UriageTanka");
                dt2.Columns.Remove("Tanka");
                DataTable dt2_temp = dt2.Copy();
                gv2_to_dt2 = dt2_temp;
                gv_2.DataSource = dt2;
                gv_2.Columns["ShouhinCD"].Visible = false;

                F8_dt1 = gv1_to_dt1.Clone();
                F8_dt2 = gv2_to_dt2.Clone();
            }
        }

        private void txtJuchuuNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtJuchuuNO.IsErrorOccurs)
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
                DataTable dt = txtJuchuuNO.IsDatatableOccurs;
                if (dt.Rows.Count > 0 && cboMode.SelectedValue.ToString() != "1")
                {
                    From_DB_To_Form(dt);
                }
            }
        }

        private void EnablePanel()
        {
            cf.EnablePanel(Panel_Detail);
            txtJuchuuDate.Focus();
            cf.DisablePanel(PanelTitle);
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
                obj.Juusho1 = dt.Rows[0]["Juusho2"].ToString();
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

        private SiiresakiEntity From_DB_To_Siiresaki(DataTable dt,DataGridViewRow selectedRow)
        {
            SiiresakiEntity obj = new SiiresakiEntity();
            obj.SiiresakiCD = dt.Rows[0]["SiiresakiCD"].ToString();
            obj.SiiresakiRyakuName = dt.Rows[0]["SiiresakiRyakuName"].ToString();
            obj.SiiresakiName = dt.Rows[0]["SiiresakiName"].ToString();
            if (dt.Columns.Contains("SiiresakiYuubinNO1"))
                obj.YuubinNO1 = dt.Rows[0]["SiiresakiYuubinNO1"].ToString();
            else
                obj.YuubinNO1 = dt.Rows[0]["YuubinNO1"].ToString();
            if (dt.Columns.Contains("SiiresakiYuubinNO2"))
                obj.YuubinNO2 = dt.Rows[0]["SiiresakiYuubinNO2"].ToString();
            else
                obj.YuubinNO2 = dt.Rows[0]["YuubinNO2"].ToString();
            if (dt.Columns.Contains("SiiresakiJuusho1"))
                obj.Juusho1 = dt.Rows[0]["SiiresakiJuusho1"].ToString();
            else
                obj.Juusho1 = dt.Rows[0]["Juusho1"].ToString();
            if (dt.Columns.Contains("SiiresakiJuusho2"))
                obj.Juusho2 = dt.Rows[0]["SiiresakiJuusho2"].ToString();
            else
                obj.Juusho2 = dt.Rows[0]["Juusho2"].ToString();
            if (dt.Columns.Contains("SiiresakiTelNO11"))
                obj.Tel11 = dt.Rows[0]["SiiresakiTelNO11"].ToString();
            else obj.Tel11 = dt.Rows[0]["Tel11"].ToString();
            if (dt.Columns.Contains("SiiresakiTelNO12"))
                obj.Tel12 = dt.Rows[0]["SiiresakiTelNO12"].ToString();
            else
                obj.Tel12 = dt.Rows[0]["Tel12"].ToString();
            if (dt.Columns.Contains("SiiresakiTelNO13"))
                obj.Tel13 = dt.Rows[0]["SiiresakiTelNO13"].ToString();
            else
                obj.Tel13 = dt.Rows[0]["Tel13"].ToString();
            if (dt.Columns.Contains("SiiresakiTelNO21"))
                obj.Tel21 = dt.Rows[0]["SiiresakiTelNO21"].ToString();
            else
                obj.Tel21 = dt.Rows[0]["Tel21"].ToString();
            if (dt.Columns.Contains("SiiresakiTelNO22"))
                obj.Tel22 = dt.Rows[0]["SiiresakiTelNO22"].ToString();
            else
                obj.Tel22 = dt.Rows[0]["Tel22"].ToString();
            if (dt.Columns.Contains("SiiresakiTelNO23"))
                obj.Tel23 = dt.Rows[0]["SiiresakiTelNO23"].ToString();
            else
                obj.Tel23 = dt.Rows[0]["Tel23"].ToString();

            selectedRow.Cells["colSiiresakiCD"].Value = obj.SiiresakiCD;
            selectedRow.Cells["colSiiresakiRyakuName"].Value = obj.SiiresakiRyakuName;
            selectedRow.Cells["colSiiresakiName"].Value = obj.SiiresakiName;
            selectedRow.Cells["colSiiresakiYuubinNO1"].Value = obj.YuubinNO1;
            selectedRow.Cells["colSiiresakiYuubinNO2"].Value = obj.YuubinNO2;
            selectedRow.Cells["colSiiresakiJuusho1"].Value = obj.Juusho1;
            selectedRow.Cells["colSiiresakiJuusho2"].Value = obj.Juusho2;
            selectedRow.Cells["colSiiresakiTelNO11"].Value = obj.Tel11;
            selectedRow.Cells["colSiiresakiTelNO12"].Value = obj.Tel12;
            selectedRow.Cells["colSiiresakiTelNO13"].Value = obj.Tel13;
            selectedRow.Cells["colSiiresakiTelNO21"].Value = obj.Tel21;
            selectedRow.Cells["colSiiresakiTelNO22"].Value = obj.Tel22;
            selectedRow.Cells["colSiiresakiTelNO23"].Value = obj.Tel23;

            return obj;
        }

        private void txtTokuisakiCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtTokuisakiCD.IsErrorOccurs)
                {
                    DataTable dt = txtTokuisakiCD.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                    {
                        tobj.Access_Tokuisaki_obj = From_DB_To_Tokuisaki(dt);
                    }
                }
            }
        }

        private void txtKouritenCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtKouritenCD.IsErrorOccurs)
                {
                    DataTable dt = txtKouritenCD.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                    {
                        kobj.Access_Kouriten_obj = From_DB_To_Kouriten(dt);
                    }
                }
            }
        }

        private void txtBrandCD_KeyDown(object sender, KeyEventArgs e)
        {
            multipurposeBL bl = new multipurposeBL();
            DataTable dt = bl.M_Multiporpose_SelectData(txtBrandCD.Text, 1, string.Empty, string.Empty);
            if (dt.Rows.Count > 0)
                lblBrand_Name.Text = dt.Rows[0]["Char1"].ToString();
        }

        private void gv_2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            List<bool> bl_list = new List<bool>();
            Control cbo = this.TopLevelControl.Controls.Find("cboMode", true)[0];
            Control[] ctrlArr = this.TopLevelControl.Controls.Find("BtnF9", true);
            if (gv_2.Columns[e.ColumnIndex].Name == "colSiiresakiCD")
            {
                if (ctrlArr.Length > 0)
                {
                    Control btnF9 = ctrlArr[0];
                    if (btnF9 != null)
                        btnF9.Visible = true;
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

        private void gv_2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataTable siiresaki_dt = new DataTable();
            bool bl = true;
            string isSelected = string.Empty;
            
            if (gv_2.Columns[e.ColumnIndex].Name == "colSiiresakiCD")
            {
                string free = gv_1.Rows[e.RowIndex].Cells["colFree"].Value.ToString();
                string JuchuuSuu = gv_1.Rows[e.RowIndex].Cells["colJuchuuSuu"].Value.ToString();

                string siiresakiCD = gv_2.Rows[e.RowIndex].Cells["colSiiresakiCD"].EditedFormattedValue.ToString();
                if (string.IsNullOrEmpty(free))
                    isSelected = "OFF";
                else isSelected = "ON";
                if (isSelected == "OFF" && JuchuuSuu != "0")
                {
                    bl = false;
                    base_bl.ShowMessage("E102");
                    e.Cancel = true;
                }
                SiiresakiBL sbl = new SiiresakiBL();
                DataTable dt = sbl.Siiresaki_Select_Check(siiresakiCD, txtJuchuuDate.Text, "E101");
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["MessageID"].ToString() == "E101")
                    {
                        bl = false;
                        base_bl.ShowMessage("E101");
                    }
                    else
                    {
                        siiresaki_dt = dt;
                    }
                }
                SiiresakiBL s_bl = new SiiresakiBL();
                DataTable dt_t1 = s_bl.Siiresaki_Select_Check(siiresakiCD, txtJuchuuDate.Text, "E227");
                if (dt_t1.Rows.Count > 0)
                {
                    if (dt_t1.Rows[0]["MessageID"].ToString() == "E227")
                    {
                        bl = false;
                        base_bl.ShowMessage("E227", "取引終了日");
                    }
                    else
                    {
                        siiresaki_dt = dt_t1;
                    }
                }
                DataTable dt_t2 = s_bl.Siiresaki_Select_Check(siiresakiCD, txtJuchuuDate.Text, "E267");
                if (dt_t2.Rows.Count > 0)
                {
                    if (dt_t2.Rows[0]["MessageID"].ToString() == "E267")
                    {
                        bl = false;
                        base_bl.ShowMessage("E267", "取引開始日");
                    }
                    else
                    {
                        siiresaki_dt = dt_t2;
                    }
                }
                if (bl == true)
                {
                    DataGridViewRow selectedRow= null;
                    if (gv_2.SelectedCells.Count > 0)
                    {
                        int selectedrowindex = gv_2.SelectedCells[0].RowIndex;
                        selectedRow = gv_2.Rows[selectedrowindex];
                    }
                    sobj.Access_Siiresaki_obj = From_DB_To_Siiresaki(siiresaki_dt, selectedRow);
                }
                   
            }
            if (gv_2.Columns[e.ColumnIndex].Name == "colexpectedDate")
            {
                string free = gv_1.Rows[e.RowIndex].Cells["colFree"].Value.ToString();
                string JuchuuSuu = gv_1.Rows[e.RowIndex].Cells["colJuchuuSuu"].Value.ToString();

                DateTime JuchuuDate = string.IsNullOrEmpty(txtJuchuuDate.Text) ? Convert.ToDateTime(base_Entity.LoginDate) : Convert.ToDateTime(txtJuchuuDate.Text);
                string expectedDate = string.IsNullOrEmpty(gv_2.Rows[e.RowIndex].Cells["colexpectedDate"].EditedFormattedValue.ToString()) ? base_Entity.LoginDate : gv_2.Rows[e.RowIndex].Cells["colexpectedDate"].EditedFormattedValue.ToString();
                if (string.IsNullOrEmpty(free))
                    isSelected = "OFF";
                else isSelected = "ON";
                if (isSelected == "OFF" && JuchuuSuu != "0")
                {
                    base_bl.ShowMessage("E102");
                    e.Cancel = true;
                }
                if (!cf.CheckDateValue(expectedDate))
                {
                    base_bl.ShowMessage("E103");
                }
                if (Convert.ToDateTime(expectedDate) < JuchuuDate)
                {
                    base_bl.ShowMessage("E267", "受注日");
                }
            }
            if (gv_2.Columns[e.ColumnIndex].Name == "colSoukoCD")
            {
                string free = gv_1.Rows[e.RowIndex].Cells["colFree"].Value.ToString();
                string JuchuuSuu = gv_1.Rows[e.RowIndex].Cells["colJuchuuSuu"].Value.ToString();

                string soukoCD = gv_2.Rows[e.RowIndex].Cells["colSoukoCD"].EditedFormattedValue.ToString();
                if (string.IsNullOrEmpty(free))
                    isSelected = "OFF";
                else isSelected = "ON";
                if (isSelected == "OFF" && JuchuuSuu != "0")
                {
                    base_bl.ShowMessage("E102");
                    e.Cancel = true;
                }
                SoukoBL sbl = new SoukoBL();
                DataTable dt = sbl.Souko_Select(soukoCD, "E101");
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["MessageID"].ToString() == "E101")
                    {
                        base_bl.ShowMessage("E101");
                    }
                    else
                    {
                        gv_2.Rows[e.RowIndex].Cells["colSoukoCD"].Value = dt.Rows[0]["SoukoCD"];
                        gv_2.Rows[e.RowIndex].Cells["colSoukoName"].Value = dt.Rows[0]["SoukoName"];
                    }
                }
            }
        }

        private void gv_2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.RowIndex >= 0)
            {
                
                var row = this.gv_2.Rows[e.RowIndex];
                if (senderGrid.Columns[e.ColumnIndex].ReadOnly == false)
                {
                    if (gv_2.Columns["colSiiresakiDetail"].Index == e.ColumnIndex)
                    {
                        sobj.Access_Siiresaki_obj.SiiresakiCD = gv_2.Rows[e.RowIndex].Cells["colSiiresakiCD"].Value.ToString();
                        sobj.Access_Siiresaki_obj.SiiresakiRyakuName = gv_2.Rows[e.RowIndex].Cells["colSiiresakiRyakuName"].Value.ToString();
                        sobj.Access_Siiresaki_obj.SiiresakiName = gv_2.Rows[e.RowIndex].Cells["colSiiresakiName"].Value.ToString();
                        sobj.Access_Siiresaki_obj.YuubinNO1 = gv_2.Rows[e.RowIndex].Cells["colSiiresakiYuubinNO1"].Value.ToString();
                        sobj.Access_Siiresaki_obj.YuubinNO2 = gv_2.Rows[e.RowIndex].Cells["colSiiresakiYuubinNO2"].Value.ToString();
                        sobj.Access_Siiresaki_obj.Juusho1 = gv_2.Rows[e.RowIndex].Cells["colSiiresakiJuusho1"].Value.ToString();
                        sobj.Access_Siiresaki_obj.Juusho2 = gv_2.Rows[e.RowIndex].Cells["colSiiresakiJuusho2"].Value.ToString();
                        sobj.Access_Siiresaki_obj.Tel11 = gv_2.Rows[e.RowIndex].Cells["colSiiresakiTelNO11"].Value.ToString();
                        sobj.Access_Siiresaki_obj.Tel12 = gv_2.Rows[e.RowIndex].Cells["colSiiresakiTelNO12"].Value.ToString();
                        sobj.Access_Siiresaki_obj.Tel13 = gv_2.Rows[e.RowIndex].Cells["colSiiresakiTelNO13"].Value.ToString();
                        sobj.Access_Siiresaki_obj.Tel21 = gv_2.Rows[e.RowIndex].Cells["colSiiresakiTelNO21"].Value.ToString();
                        sobj.Access_Siiresaki_obj.Tel22 = gv_2.Rows[e.RowIndex].Cells["colSiiresakiTelNO22"].Value.ToString();
                        sobj.Access_Siiresaki_obj.Tel23 = gv_2.Rows[e.RowIndex].Cells["colSiiresakiTelNO23"].Value.ToString();
                        sobj.ShowDialog();
                    }
                }
            }
        }

        private void btnNameF10_Click(object sender, EventArgs e)
        {
            JuchuuNyuuryokuBL obj_bl = new JuchuuNyuuryokuBL();
            JuchuuNyuuryokuEntity obj = new JuchuuNyuuryokuEntity();
            obj.BrandCD = txtBrandCD.Text;
            obj.ShouhinCD = txtShouhinCD.Text;
            obj.JANCD = txtJANCD.Text;
            obj.ShouhinName = txtShouhinName.Text;
            obj.YearTerm = txtYearTerm.Text;
            obj.SeasonSS = chk_SS.Checked ? "1" : "0";
            obj.SeasonFW = chk_FW.Checked ? "1" : "0";
            obj.ChangeDate = txtJuchuuDate.Text;
            DataTable dt = obj_bl.JuchuuNyuuryoku_Display(obj);
            if(dt.Rows.Count>0)
            {
                DataTable dt1 = dt.Copy();
                
                dt1.Columns.Remove("JANCD");
                dt1.Columns.Remove("SoukoCD");
                dt1.Columns.Remove("SoukoName");
                dt1.Columns.Remove("SiiresakiCD");
                dt1.Columns.Remove("SiiresakiName");
                dt1.Columns.Remove("SiiresakiRyakuName");
                dt1.Columns.Remove("SiiresakiYuubinNO1");
                dt1.Columns.Remove("SiiresakiYuubinNO2");
                dt1.Columns.Remove("SiiresakiJuusho1");
                dt1.Columns.Remove("SiiresakiJuusho2");
                dt1.Columns.Remove("SiiresakiTelNO11");
                dt1.Columns.Remove("SiiresakiTelNO12");
                dt1.Columns.Remove("SiiresakiTelNO13");
                dt1.Columns.Remove("SiiresakiTelNO21");
                dt1.Columns.Remove("SiiresakiTelNO22");
                dt1.Columns.Remove("SiiresakiTelNO23");
                dt1.Columns.Remove("SiiresakiDetail");
                dt1.Columns.Remove("ExpectedDate");
                DataTable dt1_temp = dt1.Copy();
                gv1_to_dt1 = dt1_temp;
               
                gv_1.DataSource = dt1;

                DataTable dt2 = dt.Copy();                
               // dt2.Columns.Remove("ShouhinCD");
                dt2.Columns.Remove("ShouhinName");
                dt2.Columns.Remove("ColorRyakuName");
                dt2.Columns.Remove("ColorNO");
                dt2.Columns.Remove("SizeNO");
                dt2.Columns.Remove("Free");
                dt2.Columns.Remove("GenZaikoSuu");
                dt2.Columns.Remove("JuchuuSuu");
                dt2.Columns.Remove("DJMSenpouHacchuuNO");
                dt2.Columns.Remove("UriageTanka");
                dt2.Columns.Remove("Tanka");

                DataTable dt2_temp = dt2.Copy();
                gv2_to_dt2 = dt2_temp;
               
                gv_2.DataSource = dt2;
                gv_2.Columns["ShouhinCD"].Visible = false;
            }
        }

        private void gv_2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                int row = gv_2.CurrentCell.RowIndex;
                int column = gv_2.CurrentCell.ColumnIndex;
                SiiresakiSearch detail = new SiiresakiSearch();
                detail.Date_Access_Siiresaki = txtJuchuuDate.Text;
                detail.ShowDialog();
                gv_2[column, row].Value = detail.SiiresakiCD.ToString();
                gv_2[column+1, row].Value = detail.SiiresakiName.ToString();
            }
        }

        private void btnNameF11_Click(object sender, EventArgs e)
        {
            F11_Gridview_Bind();
        }

        private void F11_Gridview_Bind()
        {
            txtBrandCD.Focus();

            for (int t = 0; t < gv_1.RowCount; t++)
            {
                bool bl = false;
                // grid 1 checking
                DataRow F8_drNew = F8_dt1.NewRow();// save updated data 
                DataGridViewRow row = gv_1.Rows[t];// grid view data
                string id = row.Cells[0].Value.ToString();

                DataRow[] select_dr1 = gv1_to_dt1.Select("ShouhinCD =" + id);// original data
                //DataRow existDr1 = F8_dt1.Select("column0 =" + id).SingleOrDefault();
                DataRow existDr1 = F8_dt1.Select("ShouhinCD =" + id).SingleOrDefault();

                F8_drNew[0] = id;
                for (int c = 1; c < gv_1.Columns.Count; c++)
                {
                    if (existDr1 != null)
                    {
                        if (select_dr1[0][c].ToString() != row.Cells[c].Value.ToString())
                        {
                            bl = true;
                            F8_drNew[c] = row.Cells[c].Value.ToString();
                        }
                        else
                        {
                            F8_drNew[c] = existDr1[c];
                        }
                    }
                    else
                    {
                        if (select_dr1[0][c].ToString() != row.Cells[c].Value.ToString())

                            bl = true;

                        //F8_drNew[c] = row.Cells[c].Value.ToString();
                        F8_drNew[c] = row.Cells[c].Value;
                    }
                }

                // grid 2 checking
                DataRow F8_drNew2 = F8_dt2.NewRow();// save updated data 
                DataGridViewRow row2 = gv_2.Rows[t];// grid view data

                DataRow[] select_dr2 = gv2_to_dt2.Select("ShouhinCD =" + id);// original data
                //DataRow existDr2 = F8_dt2.Select("column0 =" + id).SingleOrDefault();
                DataRow existDr2 = F8_dt2.Select("ShouhinCD =" + id).SingleOrDefault();

                F8_drNew2[0] = id;
                for (int c2 = 1; c2 < gv_2.Columns.Count; c2++)
                {
                    
                    if (existDr2 != null)
                    {
                        if (select_dr2[0][c2].ToString() != row2.Cells[c2].Value.ToString() && (c2 == 3 || c2 == 16))
                        {
                            bl = true;
                            F8_drNew2[c2] = row2.Cells[c2].Value.ToString();
                        }
                        else
                        {
                            F8_drNew2[c2] = existDr2[c2];
                        }
                    }
                    else
                    {
                        if (select_dr2[0][c2].ToString() != row2.Cells[c2].Value.ToString() && (c2 == 3 || c2 == 16))

                            bl = true;

                        F8_drNew2[c2] = row2.Cells[c2].Value.ToString();

                    }
                }
                // grid 1 and grid 2 insert (if exist, remove exist and insert)
                if (bl == true)
                {
                    if (existDr1 != null)
                        F8_dt1.Rows.Remove(existDr1);
                    if (existDr2 != null)
                        F8_dt2.Rows.Remove(existDr2);
                    F8_dt1.Rows.Add(F8_drNew);
                    F8_dt2.Rows.Add(F8_drNew2);
                }
            }

            
            ////For gridview 1 
            //foreach (DataGridViewRow row in gv_1.Rows)
            //{
            //    DataRow dr1 = internal_dt1.NewRow();
            //    DataRow F8_dr1 = F8_dt1.NewRow();

            //    DataRow dr2 = internal_dt2.NewRow();
            //    DataRow F8_dr2 = F8_dt2.NewRow();

            //    bool bl = false;
            //    //compare original data gridview 1
            //    DataRow[] select1_dr1 = gv1_to_dt1.Select("ShouhinCD =" + row.Cells[0].Value);
            //    DataRow[] select1_dr2 = gv2_to_dt2.Select("ShouhinCD =" + row.Cells[0].Value);

            //    for (int j = 0; j < gv_1.Columns.Count; j++)
            //    {
            //        if (select1_dr1[0][j].ToString() != row.Cells[j].Value.ToString())
            //        {
            //            bl = true;
            //            break;
            //        }
            //        dr1["column" + j.ToString()] = row.Cells[j].Value;
            //    }

            //    //compare update data
            //    if (bl == true)
            //    {
            //        //for gridivew 1
            //        DataRow[] updated_dr1 = F8_dt1.Select("column0 =" + row.Cells[0].Value);
            //        if (updated_dr1.Length == 0)
            //        {
            //            for (int i = 0; i < dr1.ItemArray.Length; i++)
            //            {
            //                F8_dr1[i] = dr1[i];
            //            }
            //            for (int i = 0; i < select1_dr2[0].ItemArray.Length; i++)
            //            {
            //                F8_dr2[i] = select1_dr2[0][i].ToString();
            //            }
            //            F8_dt1.Rows.Add(F8_dr1);
            //            F8_dt2.Rows.Add(F8_dr2);
            //        }
            //        else
            //        {
            //            for (int i = 0; i < gv_1.Columns.Count; i++)
            //            {
            //                F8_dt1.Rows[row.Index][i] = gv_1.Columns[i].ToString();
            //            }
            //            for (int i = 0; i < gv_2.Columns.Count; i++)
            //            {
            //                F8_dt2.Rows[row.Index][i] = gv_2.Columns[i].ToString();
            //            }
            //        }
            //    }
            //}

            ////For gridview 2
            //foreach (DataGridViewRow row in gv_2.Rows)
            //{
            //    DataRow dr1 = internal_dt1.NewRow();
            //    DataRow F8_dr1 = F8_dt1.NewRow();

            //    DataRow dr2 = internal_dt2.NewRow();
            //    DataRow F8_dr2 = F8_dt2.NewRow();

            //    bool bl = false;
            //    //compare original data gridview 2
            //    DataRow[] select2_dr1 = gv1_to_dt1.Select("ShouhinCD =" + row.Cells[0].Value);
            //    DataRow[] select2_dr2 = gv2_to_dt2.Select("ShouhinCD =" + row.Cells[0].Value);

            //    for (int j = 0; j < gv_2.Columns.Count; j++)
            //    {
            //        //for siiresaki cd and sokou cd
            //        if (j == 3 || j == 16)
            //        {
            //            if (select2_dr2[0][j].ToString() != row.Cells[j].Value.ToString())
            //            {
            //                bl = true;
            //            }
            //        }
            //        dr2["column" + j.ToString()] = row.Cells[j].Value;
            //    }

            //    //compare update data
            //    if (bl == true)
            //    {
            //        //for gridivew 1
            //        DataRow[] updated_dr1 = F8_dt2.Select("column0 =" + row.Cells[0].Value);
            //        if (updated_dr1.Length == 0)
            //        {
            //            for (int i = 0; i < select2_dr1[0].ItemArray.Length; i++)
            //            {
            //                F8_dr1[i] = select2_dr1[0][i].ToString();
            //            }
            //            for (int i = 0; i < dr2.ItemArray.Length; i++)
            //            {
            //                F8_dr2[i] = dr2[i].ToString();
            //            }
            //            F8_dt1.Rows.Add(F8_dr1);
            //            F8_dt2.Rows.Add(F8_dr2);
            //        }
            //        else
            //        {
            //            for (int i = 0; i < gv_1.Columns.Count; i++)
            //            {
            //                F8_dt1.Rows[row.Index][i] = gv_1.Columns[i].ToString();
            //            }
            //            for (int i = 0; i < gv_2.Columns.Count; i++)
            //            {
            //                F8_dt2.Rows[row.Index][i] = gv_2.Columns[i].ToString();
            //            }
            //        }
            //    }
            //}
        }

        private void btnNameF8_Click(object sender, EventArgs e)
        {
            F8_dt1.DefaultView.Sort = "ShouhinCD";
            F8_dt1.DefaultView.Sort = "ShouhinCD";
            
            gv_1.DataSource = F8_dt1.DefaultView.ToTable();
            gv_2.DataSource = F8_dt2.DefaultView.ToTable();
        }

        //private void gv_1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    //if (e.Control is DataGridViewTextBoxEditingControl)
        //    //{
        //    //    DataGridViewTextBoxEditingControl tb = e.Control as DataGridViewTextBoxEditingControl;
        //    //    //tb.PreviewKeyDown -= gv_1_PreviewKeyDown;
        //    //    //tb.PreviewKeyDown += gv_1_PreviewKeyDown;
        //    //}
        //}

        //private void gv_1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        //{
        //    //if (e.KeyData == Keys.Enter)
        //    //{
        //    //    DataRow dr1 = internal_dt1.NewRow();
        //    //    DataRow dr2 = internal_dt2.NewRow();
        //    //    int row = gv_1.CurrentCell.RowIndex;
        //    //    int column = gv_1.CurrentCell.ColumnIndex;
        //    //    if ((sender.ToString() != gv1_to_dt1.Rows[row][column].ToString()) && sender.ToString() !="")
        //    //    {
        //    //        gv_1[column, row].Value = (sender as DataGridViewTextBoxEditingControl).Text;
        //    //        for (int i = 0; i < gv_1.Columns.Count; i++)
        //    //        {
        //    //            dr1[i] = gv_1[i, row].Value;
        //    //        }
        //    //        for (int i = 0; i < gv_2.Columns.Count; i++)
        //    //        {
        //    //            dr2[i] = gv_2[i, row].Value;
        //    //        }

        //    //        DataRow[] dr = internal_dt1.Select("ShouhinCD =" + gv1_to_dt1.Rows[row]["ShouhinCD"].ToString());
        //    //        if (dr.Length == 0)
        //    //        {
        //    //            //internal_dt1.Rows.Add(dr1);
        //    //            //internal_dt2.Rows.Add(dr2);
        //    //        }
        //    //        else
        //    //        {
        //    //           //for(int i=0;i<dr1.ItemArray.Length;i++)
        //    //           // {
        //    //           //     internal_dt1.Rows[row][i] = dr1[i];
        //    //           // }
        //    //        }
        //    //    }
        //    //}
        //}

        //private void gv_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //if (e.RowIndex >= 0 && e.ColumnIndex == 5)
        //    //{
        //    //    DataGridViewRow row1 = gv_1.Rows[e.RowIndex];
        //    //    DataGridViewRow row2 = gv_2.Rows[e.RowIndex];
        //    //    bool check_value = !Convert.ToBoolean(row1.Cells["colFree"].EditedFormattedValue);
        //    //    row1.Cells["colFree"].Value = Convert.ToBoolean(row1.Cells["colFree"].EditedFormattedValue);
        //    //    DataRow dr1 = internal_dt1.NewRow();
        //    //    DataRow dr2 = internal_dt2.NewRow();
        //    //    for (int i = 0; i < row1.Cells.Count; i++)
        //    //    {
        //    //        dr1[i] = row1.Cells[i].Value;
        //    //    }
        //    //    for (int i = 0; i < row2.Cells.Count; i++)
        //    //    {
        //    //        dr2[i] = row2.Cells[i].Value;
        //    //    }
        //    //    DataRow[] dr = internal_dt1.Select("ShouhinCD =" + gv1_to_dt1.Rows[e.RowIndex]["ShouhinCD"].ToString());
        //    //    if (dr.Length == 0)
        //    //    {
        //    //        internal_dt1.Rows.Add(dr1);
        //    //        internal_dt2.Rows.Add(dr2);
        //    //    }
        //    //    else
        //    //    {
        //    //        for (int i = 0; i < dr1.ItemArray.Length; i++)
        //    //        {
        //    //            internal_dt1.Rows[e.RowIndex][i] = dr1[i];
        //    //        }
        //    //    }
        //    //}
        //}

        //private void gv_2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    //if (e.Control is DataGridViewTextBoxEditingControl)
        //    //{
        //    //    DataGridViewTextBoxEditingControl tb = e.Control as DataGridViewTextBoxEditingControl;
        //    //    //tb.PreviewKeyDown -= gv_2_PreviewKeyDown;
        //    //    //tb.PreviewKeyDown += gv_2_PreviewKeyDown;
        //    //}
        //}

        //private void gv_2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        //{
        //    //if (e.KeyData == Keys.Enter)
        //    //{
        //    //    DataRow dr1 = internal_dt1.NewRow();
        //    //    DataRow dr2 = internal_dt2.NewRow();
        //    //    int row = gv_2.CurrentCell.RowIndex;
        //    //    int column = gv_2.CurrentCell.ColumnIndex;
        //    //    if (gv_2.Columns[column].Name != "colexpectedDate")
        //    //    {
        //    //        gv_2[column, row].Value = (sender as DataGridViewTextBoxEditingControl).Text;
        //    //        if ((sender.ToString() != gv2_to_dt2.Rows[row][column].ToString()) && sender.ToString() != "")
        //    //        {
        //    //            for (int i = 0; i < gv_1.Columns.Count; i++)
        //    //            {
        //    //                dr1[i] = gv_1[i, row].Value;
        //    //            }
        //    //            for (int i = 0; i < gv_2.Columns.Count; i++)
        //    //            {
        //    //                dr2[i] = gv_2[i, row].Value;
        //    //            }
        //    //            DataRow[] dr = internal_dt2.Select("ShouhinCD =" + gv2_to_dt2.Rows[row]["ShouhinCD"].ToString());
        //    //            if (dr.Length == 0)
        //    //            {
        //    //                internal_dt1.Rows.Add(dr1);
        //    //                internal_dt2.Rows.Add(dr2);
        //    //            }
        //    //            else
        //    //            {
        //    //                for (int i = 0; i < dr2.ItemArray.Length; i++)
        //    //                {
        //    //                    internal_dt2.Rows[row][i] = dr2[i];
        //    //                }
        //    //            }
        //    //        }
        //    //    }
        //    //}
        //}

        private void DBProcess()
        {
            JuchuuNyuuryokuEntity entity = GetInsert();

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

        private JuchuuNyuuryokuEntity GetInsert()
        {
            JuchuuNyuuryokuEntity obj = new JuchuuNyuuryokuEntity();
            obj.HacchuuNO = "";//for asking
            obj.StaffCD = txtStaffCD.Text;
            obj.HacchuuDate = txtJuchuuDate.Text;
            obj.KaikeiYYMM= String.Format("{0:yyyyMM}", txtJuchuuDate.Text);
            obj.SiiresakiCD = "";//for detail form
            obj.SiiresakiRyakuName = "";//for detail form
            obj.SiharaisakiCD = "";
            obj.SiharaisakiRyakuName = "";
            obj.TuukaCD = "0";
            obj.RateKBN = "1";
            obj.SiireRate = "1";
            obj.HacchuuDenpyouTekiyou = txtJuchuuDenpyouTekiyou.Text;
            obj.DenpyouSiireHontaiKingaku = "0";
            obj.DenpyouSiireHenpinHontaiKingaku = "0";
            obj.DenpyouSiireNebikiHontaiKingaku = "0";
            obj.DenpyouSiireShouhizeiGaku = "0";
            obj.DenpyouSiireShouhizeiGakuTuujou = "0";
            obj.DenpyouSiireShouhizeiGakuKeigen = "0";
            obj.DenpyouGaikaSiireHontaiKingaku = "0";
            obj.DenpyouJoudaiShouhizeiGaku = "0";
            obj.DenpyouJoudaiHontaiKingaku = "0";
            obj.DenpyouGaikaSiireHenpinHontaiKingaku = "0";
            obj.DenpyouGaikaSiireNebikiHontaiKingaku = "0";
            obj.DenpyouGaikaSiireShouhizeiGaku = "0";
            obj.DenpyouGaikaJoudaiHontaiKingaku = "0";
            obj.DenpyouGaikaJoudaiShouhizeiGaku = "0";
            obj.SiharaiKBN = "0";
            obj.SiharaiChouhaKBN = null;
            obj.SiharaiHouhouCD = null;
            obj.HacchuushoTekiyou = null;
            obj.HacchuushoHuyouFLG = "0";
            obj.HacchuushoHakkouFLG = "0";
            obj.HacchuushoHakkouDatetime = null;
            obj.JuchuuNO = "";//check
            obj.ChakuniYoteiKanryouKBN = "0";
            obj.ChakuniKanryouKBN = "0";
            obj.TorikomiDenpyouNO = null;//condition
            obj.SiiresakiName = "";
            obj.SiiresakiYuubinNO1 = "";
            obj.SiiresakiYuubinNO2 = "";
            obj.SiiresakiJuusho1 = "";
            obj.SiiresakiJuusho2 = "";
            obj.SiiresakiTelNO11 = "";
            obj.SiiresakiTelNO12 = "";
            obj.SiiresakiTelNO13 = "";
            obj.SiiresakiTelNO21 = "";
            obj.SiiresakiTelNO22 = "";
            obj.SiiresakiTelNO23 = "";
            obj.SiharaisakiTantouBushoName = "";
            obj.SiharaisakiTantoushaYakushoku = "";
            obj.SiharaisakiTantoushaName = "";
            obj.SiiresakiName = "";//form detail
            obj.SiiresakiYuubinNO1 = "";
            obj.SiiresakiYuubinNO2 = "";
            obj.SiiresakiJuusho1 = "";
            obj.SiiresakiJuusho2 = "";
            obj.SiiresakiTelNO11 = "";
            obj.SiiresakiTelNO12 = "";
            obj.SiiresakiTelNO13 = "";
            obj.SiiresakiTelNO21 = "";
            obj.SiiresakiTelNO22 = "";
            obj.SiiresakiTelNO23 = "";
            obj.SiharaisakiTantouBushoName = null;
            obj.SiharaisakiTantoushaYakushoku = null;
            obj.InsertOperator = "";
            obj.UpdateOperator = "";
            return obj;
        }

        private void DoInsert(JuchuuNyuuryokuEntity obj)
        {
            JuchuuNyuuryokuBL objMethod = new JuchuuNyuuryokuBL();
            objMethod.JuchuuNyuuryoku_CUD(obj);
        }

        private void DoUpdate(JuchuuNyuuryokuEntity obj)
        {
            JuchuuNyuuryokuBL objMethod = new JuchuuNyuuryokuBL();
            objMethod.JuchuuNyuuryoku_CUD(obj);
        }

        private void DoDelete(JuchuuNyuuryokuEntity obj)
        {
            JuchuuNyuuryokuBL objMethod = new JuchuuNyuuryokuBL();
            objMethod.JuchuuNyuuryoku_CUD(obj);
        }

       
    }
}
