using BL;
using CKM_CommonFunction;
using Entity;
using Shinyoh;
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

            ChangeMode(Mode.New);
           
        }
        private void ChangeMode(Mode mode)
        {
           // Mode_Setting();
            switch (mode)
            {
                case Mode.New:
                    ErrorCheck();
                    txtCopy.E102Check(true);
                    txtCopy.E133Check(true, "JuchuuNyuuryoku", txtCopy, null, null);

                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    break;

                case Mode.Update:
                    ErrorCheck();
                    txtJuchuuNO.E102Check(true);
                    txtJuchuuNO.E133Check(true, "JuchuuNyuuryoku", txtJuchuuNO, null, null);
                    txtJuchuuNO.E160Check(true, "JuchuuNyuuryoku", txtJuchuuNO, null);

                    Disable_UDI_Mode();
                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    ErrorCheck();
                    txtJuchuuNO.E102Check(true);
                    txtJuchuuNO.E133Check(true, "JuchuuNyuuryoku", txtJuchuuNO, null, null);
                    txtJuchuuNO.E160Check(true, "JuchuuNyuuryoku", txtJuchuuNO, null);

                    Disable_UDI_Mode();
                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;

                    break;
                case Mode.Inquiry:
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

            lblTokuisaki_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblKouriten_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblStaff_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblBrand_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;            
            lblYear.BorderStyle = System.Windows.Forms.BorderStyle.None;

            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(Panel_Detail);

            txtJuchuuNO.Focus();
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
            txtKouritenCD.E267Check(true, "M_Kouriten", txtTokuisakiCD, txtJuchuuDate);
            txtKouritenCD.E227Check(true, "M_Kouriten", txtTokuisakiCD, txtJuchuuDate);
            txtStaffCD.E102Check(true);
            txtStaffCD.E101Check(true, "M_Staff", txtStaffCD, txtJuchuuDate, null);
            txtStaffCD.E135Check(true, "M_Staff", txtStaffCD, txtJuchuuDate);
            
        }
        public void Disable_UDI_Mode()
        {
            txtCopy.Enabled = false;
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
                   // EnablePanel();
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
                txtTokuisakiCD.Text = dt.Rows[0]["TokuisakiCD"].ToString();
                lblTokuisaki_Name.Text = dt.Rows[0]["TokuisakiRyakuName"].ToString();
                txtKouritenCD.Text = dt.Rows[0]["KouritenCD"].ToString();
                lblKouriten_Name.Text = dt.Rows[0]["KouritenRyakuName"].ToString();
                txtStaffCD.Text = dt.Rows[0]["StaffCD"].ToString();
                lblStaff_Name.Text = dt.Rows[0]["StaffName"].ToString();
                txtSenpouHacchuuNO.Text = dt.Rows[0]["SenpouHacchuuNO"].ToString();
                txtSenpouBusho.Text = dt.Rows[0]["SenpouBusho"].ToString();
                txtJuchuuDenpyouTekiyou.Text = dt.Rows[0]["JuchuuDenpyouTekiyou"].ToString();

                
                tobj.Access_Tokuisaki_obj.TokuisakiCD = dt.Rows[0]["TokuisakiCD"].ToString();
                tobj.Access_Tokuisaki_obj.TokuisakiRyakuName= dt.Rows[0]["TokuisakiRyakuName"].ToString();
                tobj.Access_Tokuisaki_obj.TokuisakiName = dt.Rows[0]["TokuisakiName"].ToString();
                tobj.Access_Tokuisaki_obj.YuubinNO1 = dt.Rows[0]["TokuisakiYuubinNO1"].ToString();
                tobj.Access_Tokuisaki_obj.YuubinNO2 = dt.Rows[0]["TokuisakiYuubinNO2"].ToString();
                tobj.Access_Tokuisaki_obj.Juusho1 = dt.Rows[0]["TokuisakiJuusho1"].ToString();
                tobj.Access_Tokuisaki_obj.Juusho2 = dt.Rows[0]["TokuisakiJuusho2"].ToString();
                tobj.Access_Tokuisaki_obj.Tel11 = dt.Rows[0]["TokuisakiTelNO1-1"].ToString();
                tobj.Access_Tokuisaki_obj.Tel12 = dt.Rows[0]["TokuisakiTelNO1-2"].ToString();
                tobj.Access_Tokuisaki_obj.Tel13 = dt.Rows[0]["TokuisakiTelNO1-3"].ToString();
                tobj.Access_Tokuisaki_obj.Tel21 = dt.Rows[0]["TokuisakiTelNO2-1"].ToString();
                tobj.Access_Tokuisaki_obj.Tel22 = dt.Rows[0]["TokuisakiTelNO2-2"].ToString();
                tobj.Access_Tokuisaki_obj.Tel23 = dt.Rows[0]["TokuisakiTelNO2-3"].ToString();

               
                kobj.Access_Kouriten_obj.KouritenCD = dt.Rows[0]["KouritenCD"].ToString();
                kobj.Access_Kouriten_obj.KouritenRyakuName = dt.Rows[0]["KouritenRyakuName"].ToString();
                kobj.Access_Kouriten_obj.KouritenName = dt.Rows[0]["KouritenName"].ToString();
                kobj.Access_Kouriten_obj.YuubinNO1 = dt.Rows[0]["KouritenYuubinNO1"].ToString();
                kobj.Access_Kouriten_obj.YuubinNO2 = dt.Rows[0]["KouritenYuubinNO2"].ToString();
                kobj.Access_Kouriten_obj.Juusho1 = dt.Rows[0]["KouritenJuusho1"].ToString();
                kobj.Access_Kouriten_obj.Juusho2 = dt.Rows[0]["KouritenJuusho2"].ToString();
                kobj.Access_Kouriten_obj.Tel11 = dt.Rows[0]["KouritenTelNO1-1"].ToString();
                kobj.Access_Kouriten_obj.Tel12 = dt.Rows[0]["KouritenTelNO1-2"].ToString();
                kobj.Access_Kouriten_obj.Tel13 = dt.Rows[0]["KouritenTelNO1-3"].ToString();
                kobj.Access_Kouriten_obj.Tel21 = dt.Rows[0]["KouritenTelNO2-1"].ToString();
                kobj.Access_Kouriten_obj.Tel22 = dt.Rows[0]["KouritenTelNO2-2"].ToString();
                kobj.Access_Kouriten_obj.Tel23 = dt.Rows[0]["KouritenTelNO2-3"].ToString();

               
                sobj.Access_Siiresaki_obj.SiiresakiCD = dt.Rows[0]["SiiresakiCD"].ToString();
                sobj.Access_Siiresaki_obj.SiiresakiRyakuName = dt.Rows[0]["SiiresakiRyakuName"].ToString();
                sobj.Access_Siiresaki_obj.SiiresakiName = dt.Rows[0]["SiiresakiName"].ToString();
                sobj.Access_Siiresaki_obj.YuubinNO1 = dt.Rows[0]["SiiresakiYuubinNO1"].ToString();
                sobj.Access_Siiresaki_obj.YuubinNO2 = dt.Rows[0]["SiiresakiYuubinNO2"].ToString();
                sobj.Access_Siiresaki_obj.Juusho1 = dt.Rows[0]["SiiresakiJuusho1"].ToString();
                sobj.Access_Siiresaki_obj.Juusho2 = dt.Rows[0]["SiiresakiJuusho2"].ToString();
                sobj.Access_Siiresaki_obj.Tel11 = dt.Rows[0]["SiiresakiTelNO11"].ToString();
                sobj.Access_Siiresaki_obj.Tel12 = dt.Rows[0]["SiiresakiTelNO12"].ToString();
                sobj.Access_Siiresaki_obj.Tel13 = dt.Rows[0]["SiiresakiTelNO13"].ToString();
                sobj.Access_Siiresaki_obj.Tel21 = dt.Rows[0]["SiiresakiTelNO21"].ToString();
                sobj.Access_Siiresaki_obj.Tel22 = dt.Rows[0]["SiiresakiTelNO22"].ToString();
                sobj.Access_Siiresaki_obj.Tel23 = dt.Rows[0]["SiiresakiTelNO23"].ToString();

                gv_1.DataSource = dt;
               
                gv_2.DataSource = dt;
               

            }
        }
    }
}
