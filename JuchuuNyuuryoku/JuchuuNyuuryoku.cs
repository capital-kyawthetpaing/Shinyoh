using BL;
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
        BaseBL base_bl;
        KouritenDetail kobj = new KouritenDetail();
        SiiresakiDetail sobj = new SiiresakiDetail();
        TokuisakiDetail tobj = new TokuisakiDetail();
          
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
                  //  DBProcess();
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

                //dt.Columns.Remove("SiiresakiRyakuName");
                //dt.Columns.Remove("SiiresakiYuubinNO1");
                //dt.Columns.Remove("SiiresakiYuubinNO2");
                //dt.Columns.Remove("SiiresakiJuusho1");
                //dt.Columns.Remove("SiiresakiJuusho2");
                //dt.Columns.Remove("SiiresakiTelNO11");
                //dt.Columns.Remove("SiiresakiTelNO12");
                //dt.Columns.Remove("SiiresakiTelNO13");
                //dt.Columns.Remove("SiiresakiTelNO21");
                //dt.Columns.Remove("SiiresakiTelNO22");
                //dt.Columns.Remove("SiiresakiTelNO23");

                dt.Columns.Remove("MessageID");
                DataTable dt1 = dt.Copy();
                dt1.Columns.Remove("JANCD");
                dt1.Columns.Remove("SoukoCD");
                dt1.Columns.Remove("SoukoName");
                dt1.Columns.Remove("SiiresakiCD");
                dt1.Columns.Remove("SiiresakiName");

                gv_1.DataSource = dt1;

                DataTable dt2 = dt.Copy();
                dt2.Columns.Remove("ShouhinCD");
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
                gv_2.DataSource = dt2;
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
            string free = gv_1.Rows[e.RowIndex].Cells["colFree"].Value.ToString();
            string JuchuuSuu = gv_1.Rows[e.RowIndex].Cells["colJuchuuSuu"].Value.ToString();
            if (gv_2.Columns[e.ColumnIndex].Name == "colSiiresakiCD")
            {
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
            if(gv_2.Columns[e.ColumnIndex].Name == "colexpectedDate")
            {
                DateTime JuchuuDate = string.IsNullOrEmpty(txtJuchuuDate.Text) ? DateTime.Now : Convert.ToDateTime(txtJuchuuDate.Text);
                string expectedDate = gv_2.Rows[e.RowIndex].Cells["colexpectedDate"].EditedFormattedValue.ToString();
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
                if(Convert.ToDateTime(expectedDate) < JuchuuDate )
                {
                    base_bl.ShowMessage("E267", "受注日");
                }
            }
            if (gv_2.Columns[e.ColumnIndex].Name == "colSoukoCD")
            {
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
            DataTable dt = obj_bl.JuchuuNyuuryoku_Display(obj);
            if(dt.Rows.Count>0)
            {
                DataTable dt1 = dt.Copy();
                dt1.Columns.Remove("JANCD");
                dt1.Columns.Remove("SoukoCD");
                dt1.Columns.Remove("SoukoName");
                dt1.Columns.Remove("SiiresakiCD");
                dt1.Columns.Remove("SiiresakiName");

                gv_1.DataSource = dt1;

                DataTable dt2 = dt.Copy();
                dt2.Columns.Remove("ShouhinCD");
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
                gv_2.DataSource = dt2;
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

    }
}
