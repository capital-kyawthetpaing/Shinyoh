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
        BaseEntity base_Entity;
        BaseBL base_bl;
        KouritenDetail kobj;
        SiiresakiDetail sobj;
        TokuisakiDetail tobj;
        
        DataTable gv1_to_dt1;
        DataTable F8_dt1;
        JuchuuNyuuryokuBL obj_bl;

        SiiresakiBL siiresaki_bl;
        

        public JuchuuNyuuryoku()
        {
            
            InitializeComponent();
            cf = new CommonFunction();
            base_bl = new BaseBL();
            kobj = new KouritenDetail();
            sobj = new SiiresakiDetail();
            tobj = new TokuisakiDetail();
            gv1_to_dt1 = new DataTable();
            F8_dt1 = new DataTable();
            obj_bl = new JuchuuNyuuryokuBL();
            siiresaki_bl = new SiiresakiBL();
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
            SetButton(ButtonType.BType.Memory, F11, "保存(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);

            txtTokuisakiCD.lblName = lblTokuisakiShort_Name;
            txtKouritenCD.lblName = lblKouriten_Name;
            txtStaffCD.lblName = lblStaff_Name;
            txtBrandCD.lblName = lblBrand_Name;

            txtTokuisakiCD.ChangeDate = txtJuchuuDate;
            txtKouritenCD.ChangeDate = txtJuchuuDate;
            txtStaffCD.ChangeDate = txtJuchuuDate;

            txtShouhinCD.ChangeDate = txtJuchuuDate;

            ChangeMode(Mode.New);

            base_Entity = _GetBaseData();

            txtJuchuuNO.ChangeDate = txtJuchuuDate;
            txtCopy.ChangeDate = txtJuchuuDate;


            gv_1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv_1.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            gv_1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gv_1.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            gv_1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gv_1.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            gv_1.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gv_1.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
            gv_1.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gv_1.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;
            gv_1.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv_1.Columns[16].SortMode = DataGridViewColumnSortMode.NotSortable;

            gv_1.SetGridDesign();
            gv_1.SetReadOnlyColumn("colShouhinCD,colShouhinName,colColorRyakuName,colColorNO,colSizeNO,colGenZaikoSuu,colUriageTanka,colTanka,colJANCD,colSiiresakiName,colSoukoName");

            gv_1.SetHiraganaColumn("colJuchuuMeisaiTekiyou");
            gv_1.SetNumberColumn("colJuchuuSuu");
            
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

                    txtJuchuuNO.E133Check(true, "JuchuuNyuuryoku", txtJuchuuNO, null, null);
                    txtJuchuuNO.E160Check(false, "JuchuuNyuuryoku", txtJuchuuNO, null);

                    Disable_UDI_Mode();
                    Control btn12 = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btn12.Visible = false;
                    Control btn10 = this.TopLevelControl.Controls.Find("BtnF10", true)[0];
                    btn10.Visible = false;
                    Control btn11 = this.TopLevelControl.Controls.Find("BtnF11", true)[0];
                    btn11.Visible = false;
                    break;
            }
        }

        private void Mode_Setting()
        {
            cf.Clear(PanelTitle);
            cf.Clear(Panel_Detail);

            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(Panel_Detail);

            lblTokuisakiShort_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblKouriten_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblStaff_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblBrand_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;            
            lblYear.BorderStyle = System.Windows.Forms.BorderStyle.None;


            lblTokuisakiShort_Name.Text = string.Empty;
            lblKouriten_Name.Text = string.Empty;
            lblStaff_Name.Text = string.Empty;
            lblBrand_Name.Text = string.Empty;

            gv1_to_dt1 = new DataTable();
            F8_dt1 = new DataTable();
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

            txtKibouNouki.E103Check(true);
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
            if (tagID == "8")
            {
               // F8_Gridview_Bind();
            }
            if (tagID == "9")
            {
                SiiresakiSearch detail = new SiiresakiSearch();
                detail.ShowDialog();
            }
            if (tagID == "10")
            {
                F10_Gridview_Bind();
            }
            if (tagID == "11")
            {
                F11_Gridview_Bind();
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

        private void txtJuchuuDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtJuchuuDate.IsErrorOccurs)
                {
                    if (!string.IsNullOrEmpty(txtTokuisakiCD.Text))
                    {
                        TokuisakiBL tBL = new TokuisakiBL();
                        DataTable tokui_DT = tBL.M_Tokuisaki_Select(txtTokuisakiCD.Text, txtJuchuuDate.Text, "E101");
                        if (tokui_DT.Rows.Count > 0 && tokui_DT.Rows[0]["MessageID"].ToString()!="E101")
                        {
                            lblTokuisakiShort_Name.Text = tokui_DT.Rows[0]["TokuisakiRyakuName"].ToString();
                            tobj.Access_Tokuisaki_obj = From_DB_To_Tokuisaki(tokui_DT);
                        }
                        else
                        {
                            base_bl.ShowMessage("E101");
                        }
                    }
                    
                    if(!string.IsNullOrEmpty(txtKouritenCD.Text))
                    {
                        KouritenBL kBL = new KouritenBL();
                        DataTable kou_DT = kBL.Kouriten_Select_Check(txtKouritenCD.Text, txtJuchuuDate.Text, "E101");
                        if (kou_DT.Rows.Count > 0 && kou_DT.Rows[0]["MessageID"].ToString() != "E101")
                        {
                            lblKouriten_Name.Text = kou_DT.Rows[0]["KouritenRyakuName"].ToString();
                            kobj.Access_Kouriten_obj = From_DB_To_Kouriten(kou_DT);
                        }
                        else
                        {
                            base_bl.ShowMessage("E101");
                        }
                    }
                    if(!string.IsNullOrEmpty(txtStaffCD.Text))
                    {
                        StaffBL sBL = new StaffBL();
                        DataTable sf_DT = sBL.Staff_Select_Check(txtStaffCD.Text, txtJuchuuDate.Text, "E101");
                        if (sf_DT.Rows.Count > 0 && sf_DT.Rows[0]["MessageID"].ToString() != "E101")
                        {
                            txtStaffCD.Text = sf_DT.Rows[0]["StaffCD"].ToString();
                            lblStaff_Name.Text = sf_DT.Rows[0]["StaffName"].ToString();
                        }
                        else
                        {
                            base_bl.ShowMessage("E101");
                        }
                    }
                }
            }
        }

        private void From_DB_To_Form(DataTable dt)
        {
            if (dt.Rows[0]["MessageID"].ToString() == "E132")
            {
                txtJuchuuDate.Text= String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["JuchuuDate"]);
                txtTokuisakiCD.Text = dt.Rows[0]["TokuisakiCD"].ToString();
                lblTokuisakiShort_Name.Text = dt.Rows[0]["TokuisakiRyakuName"].ToString();
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
               
                gv_1.DataSource = dt;

                DataTable dt_temp = dt.Copy();
                gv1_to_dt1 = dt_temp;

                if (cboMode.SelectedValue.ToString() == "1")
                    F8_dt1 = gv1_to_dt1.Clone();
                else
                    F8_dt1 = gv1_to_dt1.Copy();
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
        
        private void gv_1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            List<bool> bl_list = new List<bool>();
            Control cbo = this.TopLevelControl.Controls.Find("cboMode", true)[0];
            Control[] ctrlArr = this.TopLevelControl.Controls.Find("BtnF9", true);
            if (gv_1.Columns[e.ColumnIndex].Name == "colSiiresakiCD")
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

        private void gv_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.RowIndex >= 0)
            {
                var row = this.gv_1.Rows[e.RowIndex];
                if (senderGrid.Columns[e.ColumnIndex].ReadOnly == true)
                {
                    if (gv_1.Columns["colSiiresakiDetail"].Index == e.ColumnIndex)
                    {
                        sobj.Access_Siiresaki_obj.SiiresakiCD = gv_1.Rows[e.RowIndex].Cells["colSiiresakiCD"].Value.ToString();
                        sobj.Access_Siiresaki_obj.SiiresakiRyakuName = gv_1.Rows[e.RowIndex].Cells["colSiiresakiRyakuName"].Value.ToString();
                        sobj.Access_Siiresaki_obj.SiiresakiName = gv_1.Rows[e.RowIndex].Cells["colSiiresakiName"].Value.ToString();
                        sobj.Access_Siiresaki_obj.YuubinNO1 = gv_1.Rows[e.RowIndex].Cells["colSiiresakiYuubinNO1"].Value.ToString();
                        sobj.Access_Siiresaki_obj.YuubinNO2 = gv_1.Rows[e.RowIndex].Cells["colSiiresakiYuubinNO2"].Value.ToString();
                        sobj.Access_Siiresaki_obj.Juusho1 = gv_1.Rows[e.RowIndex].Cells["colSiiresakiJuusho1"].Value.ToString();
                        sobj.Access_Siiresaki_obj.Juusho2 = gv_1.Rows[e.RowIndex].Cells["colSiiresakiJuusho2"].Value.ToString();
                        sobj.Access_Siiresaki_obj.Tel11 = gv_1.Rows[e.RowIndex].Cells["colSiiresakiTelNO11"].Value.ToString();
                        sobj.Access_Siiresaki_obj.Tel12 = gv_1.Rows[e.RowIndex].Cells["colSiiresakiTelNO12"].Value.ToString();
                        sobj.Access_Siiresaki_obj.Tel13 = gv_1.Rows[e.RowIndex].Cells["colSiiresakiTelNO13"].Value.ToString();
                        sobj.Access_Siiresaki_obj.Tel21 = gv_1.Rows[e.RowIndex].Cells["colSiiresakiTelNO21"].Value.ToString();
                        sobj.Access_Siiresaki_obj.Tel22 = gv_1.Rows[e.RowIndex].Cells["colSiiresakiTelNO22"].Value.ToString();
                        sobj.Access_Siiresaki_obj.Tel23 = gv_1.Rows[e.RowIndex].Cells["colSiiresakiTelNO23"].Value.ToString();
                        sobj.ShowDialog();


                        SiiresakiEntity s_obj = sobj.Access_Siiresaki_obj;
                        gv_1["colSiiresakiCD", e.RowIndex].Value = s_obj.SiiresakiCD;
                        gv_1["colSiiresakiName", e.RowIndex].Value = s_obj.SiiresakiName;
                        gv_1["colSiiresakiRyakuName", e.RowIndex].Value = s_obj.SiiresakiRyakuName;
                        gv_1["colSiiresakiYuubinNO1", e.RowIndex].Value = s_obj.YuubinNO1;
                        gv_1["colSiiresakiYuubinNO2", e.RowIndex].Value = s_obj.YuubinNO2;
                        gv_1["colSiiresakiJuusho1", e.RowIndex].Value = s_obj.Juusho1;
                        gv_1["colSiiresakiJuusho2", e.RowIndex].Value = s_obj.Juusho2;
                        gv_1["colSiiresakiTelNO11", e.RowIndex].Value = s_obj.Tel11;
                        gv_1["colSiiresakiTelNO12", e.RowIndex].Value = s_obj.Tel12;
                        gv_1["colSiiresakiTelNO13", e.RowIndex].Value = s_obj.Tel13;
                        gv_1["colSiiresakiTelNO21", e.RowIndex].Value = s_obj.Tel21;
                        gv_1["colSiiresakiTelNO22", e.RowIndex].Value = s_obj.Tel22;
                        gv_1["colSiiresakiTelNO23", e.RowIndex].Value = s_obj.Tel23;
                       
                    }
                }
            }
        }
       
        private (bool, DataTable) Gridview_Error_Check(string errorType, string CD, string type)
        {
            bool return_error = false;
            DataTable dt = new DataTable();
            if (type == "Siiresaki")
            {
                DataTable Siiresaki_dt = siiresaki_bl.Siiresaki_Select_Check(CD, txtJuchuuDate.Text, errorType);
                if (errorType == "E101")
                {
                    if (Siiresaki_dt.Rows.Count > 0)
                    {
                        if (Siiresaki_dt.Rows[0]["MessageID"].ToString() == "E101")
                        {
                            return_error = true;
                            base_bl.ShowMessage("E101");
                        }
                    }
                }
                else if (errorType == "E227")
                {
                    if (Siiresaki_dt.Rows.Count > 0)
                    {
                        if (Siiresaki_dt.Rows[0]["MessageID"].ToString() == "E227")
                        {
                            return_error = true;
                            base_bl.ShowMessage("E227", "取引終了日");
                        }
                    }
                }
                else if (errorType == "E267")
                {
                    if (Siiresaki_dt.Rows.Count > 0)
                    {
                        if (Siiresaki_dt.Rows[0]["MessageID"].ToString() == "E267")
                        {
                            return_error = true;
                            base_bl.ShowMessage("E267", "取引開始日");
                        }
                    }
                }
                if (return_error == false)
                    dt = Siiresaki_dt;
            }
            if (type == "Souko")
            {
                SoukoBL sbl = new SoukoBL();
                DataTable Souko_dt = sbl.Souko_Select(CD, "E101");
                if (Souko_dt.Rows.Count > 0)
                {
                    if (Souko_dt.Rows[0]["MessageID"].ToString() == "E101")
                    {
                        return_error = true;
                        base_bl.ShowMessage("E101");
                    }
                }
                if (return_error == false)
                    dt = Souko_dt;
            }

            if (return_error)
                return (true, null);
            else return (false, dt);

        }

        private void gv_1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                int row = gv_1.CurrentCell.RowIndex;
                int column = gv_1.CurrentCell.ColumnIndex;
                SiiresakiSearch detail = new SiiresakiSearch();
                detail.Date_Access_Siiresaki = txtJuchuuDate.Text;
                detail.ShowDialog();

                gv_1[column, row].Value = detail.SiiresakiCD.ToString();
                gv_1[column + 1, row].Value = detail.SiiresakiName.ToString();
            }
        }

        private void btnNameF10_Click(object sender, EventArgs e)
        {
            F10_Gridview_Bind();
        }   

        private void F10_Gridview_Bind()
        {
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
            if (dt.Rows.Count > 0)
            {
                gv_1.DataSource = dt;

                DataTable dt_temp = dt.Copy();
                gv1_to_dt1 = dt_temp;

                F8_dt1 = gv1_to_dt1.Clone();
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
                string id = row.Cells["colShouhinCD"].Value.ToString();

                DataRow[] select_dr1 = gv1_to_dt1.Select("ShouhinCD ='" + id+"'");// original data
                DataRow existDr1 = F8_dt1.Select("ShouhinCD ='" + id+"'").SingleOrDefault();

                F8_drNew[0] = id;
                for (int c = 1; c < gv_1.Columns.Count; c++)
                {
                   if(gv_1.Columns[c].Name == "colFree" || gv_1.Columns[c].Name == "colJuchuuSuu" || gv_1.Columns[c].Name == "colSenpouHacchuuNO" || gv_1.Columns[c].Name == "colSiiresakiCD" || gv_1.Columns[c].Name == "colSoukoCD")
                    {
                        if (existDr1 != null)
                        {
                            if (select_dr1[0][c].ToString() != row.Cells[c].Value.ToString())
                            {
                                bl = true;
                                F8_drNew[c] = row.Cells[c].Value;
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

                            F8_drNew[c] = row.Cells[c].Value;
                        }
                    }
                   else
                    {
                        F8_drNew[c] = row.Cells[c].Value;
                    } 
                }
                // grid 1 insert(if exist, remove exist and insert)
                if (bl == true)
                {
                    if (existDr1 != null)
                        F8_dt1.Rows.Remove(existDr1);
                    F8_dt1.Rows.Add(F8_drNew);
                }
            }
    }

        private void btnNameF8_Click(object sender, EventArgs e)
        {
            F8_Gridview_Bind();
        }

        private void F8_Gridview_Bind()
        {
            F8_dt1.DefaultView.Sort = "ShouhinCD";
            gv_1.DataSource = F8_dt1.DefaultView.ToTable();
        }

        private void DBProcess()
        {
            string mode = string.Empty;
            (string,string,string) obj = GetInsert();
            if (cboMode.SelectedValue.Equals("1"))
            {
                mode = "New";
                DoInsert(mode,obj.Item1,obj.Item2,obj.Item3);
            }
            else if (cboMode.SelectedValue.Equals("2"))
            {
                mode = "Update";
                DoUpdate(mode, obj.Item1, obj.Item2, obj.Item3);
            }
            else if (cboMode.SelectedValue.Equals("3"))
            {
                mode = "Delete";
                DoUpdate(mode, obj.Item1, obj.Item2, obj.Item3);
            }
        }

        private (string,string,string) GetInsert()
        {
            TokuisakiEntity t_obj = tobj.Access_Tokuisaki_obj;
            KouritenEntity k_obj = kobj.Access_Kouriten_obj;

            DataTable dt = new DataTable();
            Create_Datatable_Column(dt);
            DataRow dr = dt.NewRow();
            dr["JuchuuNO"] = txtJuchuuNO.Text;
            dr["JuchuuDate"] = txtJuchuuDate.Text;
            dr["StaffCD"] = txtStaffCD.Text;
            dr["TokuisakiCD"] = t_obj.TokuisakiCD;
            dr["TokuisakiName"] = t_obj.TokuisakiName;
            dr["TokuisakiRyakuName"] = t_obj.TokuisakiRyakuName;
            dr["TokuisakiYuubinNO1"] = t_obj.YuubinNO1;
            dr["TokuisakiYuubinNO2"] = t_obj.YuubinNO2;
            dr["TokuisakiJuusho1"] = t_obj.Juusho1;
            dr["TokuisakiJuusho2"] = t_obj.Juusho2;
            dr["TokuisakiTel11"] = t_obj.Tel11;
            dr["TokuisakiTel12"] = t_obj.Tel12;
            dr["TokuisakiTel13"] = t_obj.Tel13;
            dr["TokuisakiTel21"] = t_obj.Tel21;
            dr["TokuisakiTel22"] = t_obj.Tel22;
            dr["TokuisakiTel23"] = t_obj.Tel23;

            dr["KouritenCD"] = k_obj.KouritenCD;
            dr["KouritenName"] = k_obj.KouritenName;
            dr["KouritenRyakuName"] = k_obj.KouritenRyakuName;
            dr["KouritenYuubinNO1"] = k_obj.YuubinNO1;
            dr["KouritenYuubinNO2"] = k_obj.YuubinNO2;
            dr["KouritenJuusho1"] = k_obj.Juusho1;
            dr["KouritenJuusho2"] = k_obj.Juusho2;
            dr["KouritenTel11"] = k_obj.Tel11;
            dr["KouritenTel12"] = k_obj.Tel12;
            dr["KouritenTel13"] = k_obj.Tel13;
            dr["KouritenTel21"] = k_obj.Tel21;
            dr["KouritenTel22"] = k_obj.Tel22;
            dr["KouritenTel23"] = k_obj.Tel23;            

            dr["SenpouHacchuuNO"] = txtSenpouHacchuuNO.Text;
            dr["SenpouBusho"] = txtSenpouBusho.Text;
            dr["KibouNouki"] = txtKibouNouki.Text;
            dr["JuchuuDenpyouTekiyou"] = txtJuchuuDenpyouTekiyou.Text;
            dr["BrandCD"] = txtBrandCD.Text;
            dr["ShouhinCD"] = txtShouhinCD.Text;
            dr["ShouhinName"] = txtShouhinName.Text;
            dr["JANCD"] = txtJANCD.Text;
            dr["YearTerm"] = txtYearTerm.Text;
            dr["SeasonSS"] = chk_SS.Checked ? "1" : "0";
            dr["SeasonFW"] = chk_FW.Checked ? "1" : "0";
            dr["ColorNO"] = txtColorNo.Text;
            dr["SizeNO"] = txtSizeNo.Text;
            dr["InsertOperator"] = base_Entity.OperatorCD;
            dr["UpdateOperator"] = base_Entity.OperatorCD;
            dr["PC"] = base_Entity.PC;
            dr["ProgramID"] = base_Entity.ProgramID;
            dt.Rows.Add(dr);
            string header_XML = cf.DataTableToXml(dt);

            F8_dt1.Columns.Remove("SiiresakiDetail");
            DataRow[] F8_dr = F8_dt1.Select("Free =" + 1); 
            foreach (DataRow row in F8_dr)
                F8_dt1.Rows.Remove(row);
         

            DataTable dt_Main = F8_dt1.AsEnumerable()
                           .GroupBy(r => new { Col1 = r["SiiresakiCD"], Col2 = r["SiiresakiName"],Col3=r["SoukoCD"] })
                           .Select(g => g.OrderBy(r => r["SiiresakiCD"]).First())
                           .CopyToDataTable();
           if(cboMode.SelectedValue.ToString()=="1")
            {
                for (int i = 0; i < dt_Main.Rows.Count; i++)
                {
                    DataTable hacchuu_dt = obj_bl.GetJuchuuNO("2", txtJuchuuDate.Text, "0");
                    DataTable Juchuu_dt = obj_bl.GetJuchuuNO("1", txtJuchuuDate.Text, "0");
                    dt_Main.Rows[i]["HacchuuNO"] = hacchuu_dt.Rows[0]["Column1"];
                    dt_Main.Rows[i]["JuchuuNO"] = Juchuu_dt.Rows[0]["Column1"];
                    string siiresakiCD = dt_Main.Rows[i]["SiiresakiCD"].ToString();
                    string name = dt_Main.Rows[i]["SiiresakiName"].ToString();
                    string soukoCD = dt_Main.Rows[i]["SoukoCD"].ToString();
                    DataRow[] select_dr = F8_dt1.Select("SiiresakiCD = '" + siiresakiCD + "'and SiiresakiName='" + name + "' and SoukoCD='" + soukoCD + "'");
                    if (select_dr.Length > 0)
                    {
                        for (int j = 0; j < select_dr.Length; j++)
                        {
                            select_dr[j]["HacchuuNO"] = hacchuu_dt.Rows[0]["Column1"];
                            select_dr[j]["HacchuuGyouNO"] = j + 1;
                            select_dr[j]["JuchuuNO"] = Juchuu_dt.Rows[0]["Column1"];
                            select_dr[j]["JuchuuGyouNO"] = j + 1;
                        }
                    }
                }
            }
            Column_Remove_Datatable(dt_Main);
            string main_XML = cf.DataTableToXml(dt_Main);
            string detail_XML = cf.DataTableToXml(F8_dt1);
            return (header_XML,main_XML,detail_XML); 
        }

        public void Create_Datatable_Column(DataTable create_dt)
        {
            create_dt.Columns.Add("JuchuuNO");
            create_dt.Columns.Add("StaffCD");
            create_dt.Columns.Add("JuchuuDate");
            
            create_dt.Columns.Add("TokuisakiCD");
            create_dt.Columns.Add("TokuisakiName");
            create_dt.Columns.Add("TokuisakiRyakuName");
            create_dt.Columns.Add("TokuisakiYuubinNO1");
            create_dt.Columns.Add("TokuisakiYuubinNO2");
            create_dt.Columns.Add("TokuisakiJuusho1");
            create_dt.Columns.Add("TokuisakiJuusho2");
            create_dt.Columns.Add("TokuisakiTel11");
            create_dt.Columns.Add("TokuisakiTel12");
            create_dt.Columns.Add("TokuisakiTel13");
            create_dt.Columns.Add("TokuisakiTel21");
            create_dt.Columns.Add("TokuisakiTel22");
            create_dt.Columns.Add("TokuisakiTel23");
           
            create_dt.Columns.Add("KouritenCD");
            create_dt.Columns.Add("KouritenName");
            create_dt.Columns.Add("KouritenRyakuName");
            create_dt.Columns.Add("KouritenYuubinNO1");
            create_dt.Columns.Add("KouritenYuubinNO2");
            create_dt.Columns.Add("KouritenJuusho1");
            create_dt.Columns.Add("KouritenJuusho2");
            create_dt.Columns.Add("KouritenTel11");
            create_dt.Columns.Add("KouritenTel12");
            create_dt.Columns.Add("KouritenTel13");
            create_dt.Columns.Add("KouritenTel21");
            create_dt.Columns.Add("KouritenTel22");
            create_dt.Columns.Add("KouritenTel23");
            
            create_dt.Columns.Add("SenpouHacchuuNO");
            create_dt.Columns.Add("SenpouBusho");
            create_dt.Columns.Add("KibouNouki");
            create_dt.Columns.Add("JuchuuDenpyouTekiyou");
            create_dt.Columns.Add("BrandCD");
            create_dt.Columns.Add("ShouhinCD");
            create_dt.Columns.Add("ShouhinName");
            create_dt.Columns.Add("JANCD");
            create_dt.Columns.Add("YearTerm");
            create_dt.Columns.Add("SeasonSS");
            create_dt.Columns.Add("SeasonFW");
            create_dt.Columns.Add("ColorNO");
            create_dt.Columns.Add("SizeNO");

            create_dt.Columns.Add("InsertOperator");
            create_dt.Columns.Add("UpdateOperator");
            create_dt.Columns.Add("PC");
            create_dt.Columns.Add("ProgramID");
        }

        private void DoInsert(string mode,string str_header,string str_main,string str_detail)
        {
            JuchuuNyuuryokuBL objMethod = new JuchuuNyuuryokuBL();
            objMethod.JuchuuNyuuryoku_CUD(mode,str_header,str_main,str_detail);
        }

        private void DoUpdate(string mode, string str_header, string str_main, string str_detail)
        {
            JuchuuNyuuryokuBL objMethod = new JuchuuNyuuryokuBL();
            objMethod.JuchuuNyuuryoku_CUD(mode, str_header, str_main, str_detail);
        }

        private void DoDelete(string mode, string str_header, string str_main, string str_detail)
        {
            JuchuuNyuuryokuBL objMethod = new JuchuuNyuuryokuBL();
            objMethod.JuchuuNyuuryoku_CUD(mode, str_header, str_main, str_detail);
        }

       private void Column_Remove_Datatable(DataTable dt)
        {
            dt.Columns.Remove("ShouhinCD");
            dt.Columns.Remove("ShouhinName");
            dt.Columns.Remove("ColorRyakuName");
            dt.Columns.Remove("ColorNO");
            dt.Columns.Remove("SizeNO");
            dt.Columns.Remove("Free");
            dt.Columns.Remove("GenZaikoSuu");
            dt.Columns.Remove("JuchuuSuu");
            dt.Columns.Remove("DJMSenpouHacchuuNO");
            dt.Columns.Remove("UriageTanka");
            dt.Columns.Remove("Tanka");
            dt.Columns.Remove("JuchuuMeisaiTekiyou");
            dt.Columns.Remove("JANCD");
            dt.Columns.Remove("ExpectedDate");
            dt.Columns.Remove("SoukoCD");
            dt.Columns.Remove("SoukoName");
            dt.Columns.Remove("HacchuuGyouNO");
            dt.Columns.Remove("JuchuuGyouNO");
        }
      
        private void gv_1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string isSelected = string.Empty;
            string free = gv_1.Rows[e.RowIndex].Cells["colFree"].Value.ToString();
            string JuchuuSuu = gv_1.Rows[e.RowIndex].Cells["colJuchuuSuu"].Value.ToString();

            string siiresakiCD = gv_1.Rows[e.RowIndex].Cells["colSiiresakiCD"].EditedFormattedValue.ToString();
            if (string.IsNullOrEmpty(free))
                isSelected = "OFF";
            else isSelected = "ON";

            if (isSelected == "OFF" && JuchuuSuu != "0")
            {
                if (gv_1.Columns[e.ColumnIndex].Name == "colSiiresakiCD")
                {
                    DataTable siiresaki_dt = new DataTable();
                    bool bl_error = false;
                    if (string.IsNullOrEmpty(siiresakiCD))
                    {
                        base_bl.ShowMessage("E102");
                        bl_error = true;
                    }
                    if (bl_error == false)
                    {
                        (bl_error, siiresaki_dt) = Gridview_Error_Check("E101", siiresakiCD, "Siiresaki");
                        if (bl_error == false)
                            (bl_error, siiresaki_dt) = Gridview_Error_Check("E227", siiresakiCD, "Siiresaki");
                        if (bl_error == false)
                            (bl_error, siiresaki_dt) = Gridview_Error_Check("E267", siiresakiCD, "Siiresaki");
                    }
                    if (bl_error == false)
                    {
                        DataGridViewRow selectedRow = null;
                        if (gv_1.SelectedCells.Count > 0)
                        {
                            int selectedrowindex = gv_1.SelectedCells[0].RowIndex;
                            selectedRow = gv_1.Rows[selectedrowindex];
                        }
                        sobj.Access_Siiresaki_obj = From_DB_To_Siiresaki(siiresaki_dt, selectedRow);
                        gv_1.MoveNextCell();
                    }
                    else
                    {
                        gv_1.CurrentCell = gv_1.Rows[e.RowIndex].Cells["colSiiresakiCD"];
                    }
                }

                if (gv_1.Columns[e.ColumnIndex].Name == "colexpectedDate")
                {
                    bool exp_error = false;
                    DateTime JuchuuDate = string.IsNullOrEmpty(txtJuchuuDate.Text) ? Convert.ToDateTime(base_Entity.LoginDate) : Convert.ToDateTime(txtJuchuuDate.Text);

                    string expectedDate = gv_1.Rows[e.RowIndex].Cells["colexpectedDate"].EditedFormattedValue.ToString();
                    if (string.IsNullOrEmpty(expectedDate))
                    {
                        base_bl.ShowMessage("E102");
                        exp_error = true;
                    }
                    if (exp_error == false)
                    {
                        TextBox txt = new TextBox();
                        txt.Text = expectedDate;
                        if (!cf.DateCheck(txt))
                        {
                            base_bl.ShowMessage("E103");
                            exp_error = true;
                        }
                        if (exp_error == false)
                        {
                            gv_1.Rows[e.RowIndex].Cells["colexpectedDate"].Value = txt.Text;
                            expectedDate = string.IsNullOrEmpty(txt.Text) ? base_Entity.LoginDate : txt.Text;
                            if (Convert.ToDateTime(expectedDate) < JuchuuDate)
                                base_bl.ShowMessage("E267", "受注日");
                        }
                    }
                    if(exp_error==false)
                    {
                        gv_1.MoveNextCell();
                    }
                    else
                    {
                        gv_1.CurrentCell = gv_1.Rows[e.RowIndex].Cells["colexpectedDate"];
                    }
                }

                if (gv_1.Columns[e.ColumnIndex].Name == "colSoukoCD")
                {
                    DataTable souko_dt = new DataTable();
                    bool err_souko = false;
                    string soukoCD = gv_1.Rows[e.RowIndex].Cells["colSoukoCD"].EditedFormattedValue.ToString();
                    if (string.IsNullOrEmpty(soukoCD))
                    {
                        base_bl.ShowMessage("E102");
                        err_souko = true;
                    }
                    if (err_souko == false)
                    {
                        (err_souko, souko_dt) = Gridview_Error_Check("E101", soukoCD, "Souko");
                    }
                    if (err_souko == false)
                    {
                        gv_1.Rows[e.RowIndex].Cells["colSoukoCD"].Value = souko_dt.Rows[0]["SoukoCD"];
                        gv_1.Rows[e.RowIndex].Cells["colSoukoName"].Value = souko_dt.Rows[0]["SoukoName"];
                        gv_1.MoveNextCell();
                    }
                    else
                    {
                        gv_1.CurrentCell = gv_1.Rows[e.RowIndex].Cells["colSoukoCD"];
                    }
                }
            }
            if (gv_1.Columns[e.ColumnIndex].Name == "colFree")
                gv_1.MoveNextCell();
            if (gv_1.Columns[e.ColumnIndex].Name == "colJuchuuSuu")
                gv_1.MoveNextCell();
            if (gv_1.Columns[e.ColumnIndex].Name == "colSenpouHacchuuNO")
                gv_1.MoveNextCell();
            if (gv_1.Columns[e.ColumnIndex].Name == "colSenpouHacchuuNO")
                gv_1.MoveNextCell();
        }

       
    }
}
