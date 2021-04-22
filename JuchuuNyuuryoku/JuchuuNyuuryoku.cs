using BL;
using CKM_CommonFunction;
using Entity;
using Shinyoh;
using Shinyoh_Controls;
using Shinyoh_Details;
using Shinyoh_Search;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        
        DataTable gvdt1;
        DataTable F8_dt1;
        JuchuuNyuuryokuBL obj_bl;
        SiiresakiBL siiresaki_bl;
      

        public JuchuuNyuuryoku()
        {
            
            InitializeComponent();
            cf = new CommonFunction();
            base_bl = new BaseBL();
            //kobj = new KouritenDetail();
            //sobj = new SiiresakiDetail(false);
            //tobj = new TokuisakiDetail();
            gvdt1 = new DataTable();
            F8_dt1 = new DataTable();
            obj_bl = new JuchuuNyuuryokuBL();
            siiresaki_bl = new SiiresakiBL();
            
            //this.gv_JuchuuNyuuryoku.Size = new System.Drawing.Size(1300, 387);
        }

        private void JuchuuNyuuryoku_Load(object sender, EventArgs e)
        {
            ProgramID = "JuchuuNyuuryoku";
            StartProgram();

            cboMode.Bind(false, multi_Entity);

            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "新規(F2)", true);
            SetButton(ButtonType.BType.Update, F3, "修正(F3)", true);
            SetButton(ButtonType.BType.Delete, F4, "削除(F4)", true);
            SetButton(ButtonType.BType.Inquiry, F5, "照会(F5)", true);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", false);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", true);
            SetButton(ButtonType.BType.Display, F10, "表示(F10)", false);
            SetButton(ButtonType.BType.Memory, F11, "保存(F11)", false);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);

            txtTokuisakiCD.lblName = lblTokuisakiShort_Name;
            txtKouritenCD.lblName = lblKouriten_Name;
            txtStaffCD.lblName = lblStaff_Name;
            txtBrandCD.lblName = lblBrand_Name;

            txtTokuisakiCD.ChangeDate = txtJuchuuDate;
            txtKouritenCD.ChangeDate = txtJuchuuDate;
            txtStaffCD.ChangeDate = txtJuchuuDate;

            txtShouhinCD.ChangeDate = txtJuchuuDate;

            base_Entity = _GetBaseData();
            

            txtJuchuuNO.ChangeDate = txtJuchuuDate;
            txtCopy.ChangeDate = txtJuchuuDate;


            gv_JuchuuNyuuryoku.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv_JuchuuNyuuryoku.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            gv_JuchuuNyuuryoku.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gv_JuchuuNyuuryoku.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            gv_JuchuuNyuuryoku.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gv_JuchuuNyuuryoku.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
            gv_JuchuuNyuuryoku.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gv_JuchuuNyuuryoku.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;
            gv_JuchuuNyuuryoku.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gv_JuchuuNyuuryoku.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;
            gv_JuchuuNyuuryoku.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv_JuchuuNyuuryoku.Columns[16].SortMode = DataGridViewColumnSortMode.NotSortable;
            gv_JuchuuNyuuryoku.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv_JuchuuNyuuryoku.Columns[17].SortMode = DataGridViewColumnSortMode.NotSortable;

            gv_JuchuuNyuuryoku.SetGridDesign();
           // gv_1.SetReadOnlyColumn("ColHinbanCD,colShouhinName,colColorRyakuName,colColorNO,colSizeNO,colGenZaikoSuu,colUriageTanka,colTanka,colJANCD,colSiiresakiName,colSoukoName,colSiiresakiRyakuName,colSiiresakiYuubinNO1,colSiiresakiYuubinNO2,colSiiresakiJuusho1,colSiiresakiJuusho2,colSiiresakiTelNO11,colSiiresakiTelNO12,colSiiresakiTelNO13,colSiiresakiTelNO21,colSiiresakiTelNO22,colSiiresakiTelNO23,colHacchuuNO,colHacchuuGyouNO,colJuchuuNO,colJuchuuGyouNO");
            gv_JuchuuNyuuryoku.SetReadOnlyColumn("ColHinbanCD,colShouhinName,colColorRyakuName,colColorNO,colSizeNO,colGenZaikoSuu,colUriageTanka,colTanka,colJANCD,colSiiresakiName,colSoukoName");

            gv_JuchuuNyuuryoku.SetHiraganaColumn("colJuchuuMeisaiTekiyou");
            gv_JuchuuNyuuryoku.SetNumberColumn("colJuchuuSuu");
            // gv_JuchuuNyuuryoku.ClearSelection();

            txtKouritenCD.TxtBox = txtTokuisakiCD;//ses
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
                    // txtJuchuuNO.E115Check(false, "JuchuuNyuuryoku", txtJuchuuDate);
                    txtJuchuuNO.E265Check(false, "JuchuuNyuuryoku", txtJuchuuNO);

                    //txtCopy.E102Check(true);
                    txtCopy.E133Check(true, "JuchuuNyuuryoku", txtCopy, null, null);

                   
                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    kobj = new KouritenDetail();
                    sobj = new SiiresakiDetail();
                    tobj = new TokuisakiDetail();
                    break;

                case Mode.Update:
                    ErrorCheck();
                    txtJuchuuNO.E102Check(true);
                    txtCopy.E102Check(false);

                    txtJuchuuNO.E133Check(true, "JuchuuNyuuryoku", txtJuchuuNO, null, null);
                    txtJuchuuNO.E160Check(true, "JuchuuNyuuryoku", txtJuchuuNO, null);
                    // txtJuchuuNO.E115Check(true, "JuchuuNyuuryoku", txtJuchuuDate);     
                    txtJuchuuNO.E265Check(true, "JuchuuNyuuryoku", txtJuchuuNO);

                    Disable_UDI_Mode();
                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    kobj = new KouritenDetail();
                    sobj = new SiiresakiDetail();
                    tobj = new TokuisakiDetail();
                    break;
                case Mode.Delete:
                    ErrorCheck();
                    txtJuchuuNO.E102Check(true);
                    txtCopy.E102Check(false);

                    txtJuchuuNO.E133Check(true, "JuchuuNyuuryoku", txtJuchuuNO, null, null);
                    txtJuchuuNO.E160Check(true, "JuchuuNyuuryoku", txtJuchuuNO, null);
                    // txtJuchuuNO.E115Check(true, "JuchuuNyuuryoku", txtJuchuuDate);
                    txtJuchuuNO.E265Check(true, "JuchuuNyuuryoku", txtJuchuuNO);

                    Disable_UDI_Mode();
                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;
                    btn_Tokuisaki.Enabled = true;
                    btn_Kouriten.Enabled = true;
                    kobj = new KouritenDetail(false);
                    sobj = new SiiresakiDetail(false);
                    tobj = new TokuisakiDetail(false);
                    break;
                case Mode.Inquiry:
                    txtJuchuuNO.E102Check(true);
                    txtCopy.E102Check(false);

                    txtJuchuuNO.E133Check(true, "JuchuuNyuuryoku", txtJuchuuNO, null, null);
                    txtJuchuuNO.E160Check(true, "JuchuuNyuuryoku", txtJuchuuNO, null);
                    txtJuchuuNO.E265Check(false, "JuchuuNyuuryoku", txtJuchuuNO);

                    Disable_UDI_Mode();
                    Control btn12 = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btn12.Visible = false;
                    Control btn10 = this.TopLevelControl.Controls.Find("BtnF10", true)[0];
                    btn10.Visible = false;
                    Control btn11 = this.TopLevelControl.Controls.Find("BtnF11", true)[0];
                    btn11.Visible = false;
                    btn_Tokuisaki.Enabled = true;
                    btn_Kouriten.Enabled = true;
                    kobj = new KouritenDetail(false);
                    sobj = new SiiresakiDetail(false);
                    tobj = new TokuisakiDetail(false);

                    break;
            }
        }

        private void Mode_Setting()
        {
            cf.Clear(PanelTitle);
            cf.Clear(PanelDetail);

            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(PanelDetail);

            lblTokuisakiShort_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblKouriten_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblStaff_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblBrand_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;            
            lblYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            chk_SS.Checked = true; //HET
            chk_FW.Checked = true; //HET

            lblTokuisakiShort_Name.Text = string.Empty;
            lblKouriten_Name.Text = string.Empty;
            lblStaff_Name.Text = string.Empty;
            lblBrand_Name.Text = string.Empty;

            gvdt1 = new DataTable();
            F8_dt1 = new DataTable();
            txtJuchuuNO.Focus();
            txtJuchuuDate.Text = base_Entity.LoginDate;
            txtStaffCD.Text = base_Entity.OperatorCD;
            lblStaff_Name.Text = base_Entity.SPName;

            for (int i = 0; i < gv_JuchuuNyuuryoku.RowCount; i++)
            {
                gv_JuchuuNyuuryoku.Rows.Remove(gv_JuchuuNyuuryoku.Rows[0]);
            }

            SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", false);
            SetButton(ButtonType.BType.Display, F10, "表示(F10)", false);
            SetButton(ButtonType.BType.Memory, F11, "保存(F11)", false);
            // F10_Gridview_Bind();

            gv_JuchuuNyuuryoku.Memory_Row_Count = 0;

            BaseEntity be = new BaseEntity();
            be.ProgramID = ProgramID;
            be.OperatorCD = OperatorCD;
            be.PC = PCID;
            BaseBL bbl = new BaseBL();
            bbl.D_Exclusive_Number_Remove(be);

            if (cboMode.SelectedValue.ToString()=="1")
            {
                cboMode.NextControlName = txtCopy.Name;
                txtJuchuuNO.Enabled = false;
                txtCopy.Focus();
            }
            else
            {
                cboMode.NextControlName = txtJuchuuNO.Name;
                txtJuchuuNO.Focus();
            }
            //sobj = new SiiresakiDetail(false);
            kobj = new KouritenDetail();
            tobj = new TokuisakiDetail();
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
                F8_Gridview_Bind();
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
                Function_F11();
            }
            if (tagID == "12")
            {
                //if (ErrorCheck(PanelTitle) && ErrorCheck(PanelDetail))
                //{

                if (F8_dt1.Rows.Count > 0)
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
               // }
            }

            base.FunctionProcess(tagID);
        }

        private void btn_Tokuisaki_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtTokuisakiCD.Text) && !txtTokuisakiCD.IsErrorOccurs )
                tobj.ShowDialog();
            else
                txtTokuisakiCD.Focus();
        }

        private void btn_Kouriten_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtKouritenCD.Text) && !txtKouritenCD.IsErrorOccurs)
                kobj.ShowDialog();
            else
                txtKouritenCD.Focus();
        }

        //private void txtStaffCD_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        if (!txtStaffCD.IsErrorOccurs)
        //        {
        //            sobj.ShowDialog();
        //        }
        //    }
        //}

        private void txtCopy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cboMode.SelectedValue.ToString() == "1")
            {
                if (!txtCopy.IsErrorOccurs)
                {
                    if (ErrorCheck(PanelTitle))
                    {
                        EnablePanel();
                    DataTable dt = txtCopy.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                        From_DB_To_Form(dt);
                    }
                    else
                    {
                        cf.Clear(PanelDetail);
                    }
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
                        DataTable dt = tBL.M_Tokuisaki_Select(txtTokuisakiCD.Text, txtJuchuuDate.Text, "E101");
                        DataTable dt1 = tBL.M_Tokuisaki_Select(txtTokuisakiCD.Text, txtJuchuuDate.Text, "E267");
                        DataTable dt2 = tBL.M_Tokuisaki_Select(txtTokuisakiCD.Text, txtJuchuuDate.Text, "E227");
                       
                        if (dt.Rows.Count > 0 && dt.Rows[0]["MessageID"].ToString() =="E101")
                        {
                            base_bl.ShowMessage("E101");
                            return;
                        }
                        if (dt1.Rows.Count > 0 && dt.Rows[0]["MessageID"].ToString() == "E267")
                        {
                            base_bl.ShowMessage("E267", "取引開始日");
                            return;
                        }
                        if (dt2.Rows.Count > 0 && dt.Rows[0]["MessageID"].ToString() == "E227")
                        {
                            base_bl.ShowMessage("E227", "取引終了日");
                            return;
                        }
                        lblTokuisakiShort_Name.Text = dt.Rows[0]["TokuisakiRyakuName"].ToString();
                        tobj.Access_Tokuisaki_obj = From_DB_To_Tokuisaki(dt);
                    }
                    
                    if(!string.IsNullOrEmpty(txtKouritenCD.Text))
                    {
                        KouritenBL kBL = new KouritenBL();
                        DataTable dt = kBL.Kouriten_Select_Check(txtKouritenCD.Text, txtJuchuuDate.Text, "E101",string.Empty);
                        DataTable dt1 = kBL.Kouriten_Select_Check(txtKouritenCD.Text, txtJuchuuDate.Text, "E267", string.Empty);
                        DataTable dt2 = kBL.Kouriten_Select_Check(txtKouritenCD.Text, txtJuchuuDate.Text, "E227", string.Empty);
                        if (dt.Rows.Count > 0 && dt.Rows[0]["MessageID"].ToString() == "E101")
                        {
                            base_bl.ShowMessage("E101");
                            return;
                        }
                        if (dt1.Rows.Count > 0 && dt.Rows[0]["MessageID"].ToString() == "E267")
                        {
                            base_bl.ShowMessage("E267", "取引開始日");
                            return;
                        }
                        if (dt2.Rows.Count > 0 && dt.Rows[0]["MessageID"].ToString() == "E227")
                        {
                            base_bl.ShowMessage("E227", "取引終了日");
                            return;
                        }

                        lblKouriten_Name.Text = dt.Rows[0]["KouritenRyakuName"].ToString();
                        kobj.Access_Kouriten_obj = From_DB_To_Kouriten(dt);
                    }
                    if(!string.IsNullOrEmpty(txtStaffCD.Text))
                    {
                        StaffBL sBL = new StaffBL();
                        DataTable dt = sBL.Staff_Select_Check(txtStaffCD.Text, txtJuchuuDate.Text, "E101");
                        DataTable dt1 = sBL.Staff_Select_Check(txtStaffCD.Text, txtJuchuuDate.Text, "E135");
                        if (dt.Rows.Count > 0 && dt.Rows[0]["MessageID"].ToString() == "E101")
                        {
                            base_bl.ShowMessage("E101");
                            return;
                        }
                        if (dt.Rows.Count > 0 && dt.Rows[0]["MessageID"].ToString() == "E135")
                        {
                            base_bl.ShowMessage("E135");
                            return;
                        }
                        lblStaff_Name.Text = dt.Rows[0]["StaffName"].ToString();
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
                txtKibouNouki.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["KibouNouki"]);


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
               
                gv_JuchuuNyuuryoku.DataSource = dt;
              //  gv_JuchuuNyuuryoku.ClearSelection();

                DataTable dt_temp = dt.Copy();
                gvdt1 = dt_temp;

                if (F8_dt1.Rows.Count == 0)
                    F8_dt1 = gvdt1.Clone();

                if (cboMode.SelectedValue.ToString() == "3" || cboMode.SelectedValue.ToString()=="2")
                {
                    F8_dt1 = gvdt1.Copy();
                    gv_JuchuuNyuuryoku.Memory_Row_Count = F8_dt1.Rows.Count;
                }
                if (!string.IsNullOrEmpty(txtCopy.Text))
                {
                    F8_dt1 = gvdt1.Copy();
                    F8_dt1.Rows.OfType<DataRow>().ToList().ForEach(r =>
                    {
                        r["JuchuuGyouNO"] = DBNull.Value;
                        r["HacchuuGyouNO"] = DBNull.Value;
                    });
                    gv_JuchuuNyuuryoku.Memory_Row_Count = F8_dt1.Rows.Count;
                }
            }
        }

        private void txtJuchuuNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtJuchuuNO.IsErrorOccurs)
                {
                    StaffEntity obj_staff = new StaffEntity();
                    obj_staff.OperatorCD = OperatorCD;
                    obj_staff.PC = PCID;
                    obj_staff.StaffName = txtJuchuuNO.Text;
                    if (cboMode.SelectedValue.ToString() == "2")//update
                    {
                        obj_bl.JuchuuNyuuryoku_Exclusive_Insert(obj_staff);
                        EnablePanel();
                    }
                    else if (cboMode.SelectedValue.ToString() == "3" || cboMode.SelectedValue.ToString() == "4")
                    {
                        if (cboMode.SelectedValue.ToString() == "3")
                        {
                            obj_bl.JuchuuNyuuryoku_Exclusive_Insert(obj_staff);
                        }
                        cf.DisablePanel(PanelTitle);

                        btn_Tokuisaki.Enabled = true;
                        btn_Kouriten.Enabled = true;
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
            cf.EnablePanel(PanelDetail);
            SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", true);
            SetButton(ButtonType.BType.Display, F10, "表示(F10)", true);
            SetButton(ButtonType.BType.Memory, F11, "保存(F11)", true);
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
                obj.Juusho2 = dt.Rows[0]["Juusho2"].ToString();
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

            if (selectedRow.Cells["colSiiresakiCD"].Value.ToString().Equals(obj.SiiresakiCD))
            {
                obj.SiiresakiRyakuName= selectedRow.Cells["colSiiresakiRyakuName"].Value.ToString();
                obj.SiiresakiName= selectedRow.Cells["colSiiresakiName"].Value.ToString();
                obj.YuubinNO1=selectedRow.Cells["colSiiresakiYuubinNO1"].Value.ToString();
                obj.YuubinNO2=selectedRow.Cells["colSiiresakiYuubinNO2"].Value.ToString();
                obj.Juusho1=selectedRow.Cells["colSiiresakiJuusho1"].Value.ToString();
                obj.Juusho2=selectedRow.Cells["colSiiresakiJuusho2"].Value.ToString();
                obj.Tel11=selectedRow.Cells["colSiiresakiTelNO11"].Value.ToString();
                obj.Tel12=selectedRow.Cells["colSiiresakiTelNO12"].Value.ToString();
                obj.Tel13=selectedRow.Cells["colSiiresakiTelNO13"].Value.ToString();
                obj.Tel21=selectedRow.Cells["colSiiresakiTelNO21"].Value.ToString();
                obj.Tel22=selectedRow.Cells["colSiiresakiTelNO22"].Value.ToString();
                obj.Tel23=selectedRow.Cells["colSiiresakiTelNO23"].Value.ToString();
            }
            else
            {
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
            }

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
            lblBrand_Name.Text = string.Empty;
            if (dt.Rows.Count > 0)
                lblBrand_Name.Text = dt.Rows[0]["Char1"].ToString();
            else lblBrand_Name.Text = string.Empty;
        }

        private void gv_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.RowIndex >= 0)
            {
                var row = this.gv_JuchuuNyuuryoku.Rows[e.RowIndex];
                if (cboMode.SelectedValue.Equals("3") || cboMode.SelectedValue.Equals("4"))
                {
                    sobj = new SiiresakiDetail(false);
                }
                else
                    sobj = new SiiresakiDetail();
                if (gv_JuchuuNyuuryoku.Columns["colSiiresakiDetail"].Index == e.ColumnIndex)
                {
                    if(!ErrorCheck_CellEndEdit(e.RowIndex, e.ColumnIndex - 2) && !string.IsNullOrEmpty(gv_JuchuuNyuuryoku.Rows[e.RowIndex].Cells["colSiiresakiCD"].EditedFormattedValue.ToString().Trim()))
                    {
                        sobj.Access_Siiresaki_obj.SiiresakiCD = gv_JuchuuNyuuryoku.Rows[e.RowIndex].Cells["colSiiresakiCD"].Value.ToString();
                        sobj.Access_Siiresaki_obj.SiiresakiRyakuName = gv_JuchuuNyuuryoku.Rows[e.RowIndex].Cells["colSiiresakiRyakuName"].Value.ToString();
                        sobj.Access_Siiresaki_obj.SiiresakiName = gv_JuchuuNyuuryoku.Rows[e.RowIndex].Cells["colSiiresakiName"].Value.ToString();
                        sobj.Access_Siiresaki_obj.YuubinNO1 = gv_JuchuuNyuuryoku.Rows[e.RowIndex].Cells["colSiiresakiYuubinNO1"].Value.ToString();
                        sobj.Access_Siiresaki_obj.YuubinNO2 = gv_JuchuuNyuuryoku.Rows[e.RowIndex].Cells["colSiiresakiYuubinNO2"].Value.ToString();
                        sobj.Access_Siiresaki_obj.Juusho1 = gv_JuchuuNyuuryoku.Rows[e.RowIndex].Cells["colSiiresakiJuusho1"].Value.ToString();
                        sobj.Access_Siiresaki_obj.Juusho2 = gv_JuchuuNyuuryoku.Rows[e.RowIndex].Cells["colSiiresakiJuusho2"].Value.ToString();
                        sobj.Access_Siiresaki_obj.Tel11 = gv_JuchuuNyuuryoku.Rows[e.RowIndex].Cells["colSiiresakiTelNO11"].Value.ToString();
                        sobj.Access_Siiresaki_obj.Tel12 = gv_JuchuuNyuuryoku.Rows[e.RowIndex].Cells["colSiiresakiTelNO12"].Value.ToString();
                        sobj.Access_Siiresaki_obj.Tel13 = gv_JuchuuNyuuryoku.Rows[e.RowIndex].Cells["colSiiresakiTelNO13"].Value.ToString();
                        sobj.Access_Siiresaki_obj.Tel21 = gv_JuchuuNyuuryoku.Rows[e.RowIndex].Cells["colSiiresakiTelNO21"].Value.ToString();
                        sobj.Access_Siiresaki_obj.Tel22 = gv_JuchuuNyuuryoku.Rows[e.RowIndex].Cells["colSiiresakiTelNO22"].Value.ToString();
                        sobj.Access_Siiresaki_obj.Tel23 = gv_JuchuuNyuuryoku.Rows[e.RowIndex].Cells["colSiiresakiTelNO23"].Value.ToString();
                        sobj.ShowDialog();


                        SiiresakiEntity s_obj = sobj.Access_Siiresaki_obj;
                        gv_JuchuuNyuuryoku["colSiiresakiCD", e.RowIndex].Value = s_obj.SiiresakiCD;
                        gv_JuchuuNyuuryoku["colSiiresakiName", e.RowIndex].Value = s_obj.SiiresakiName;
                        gv_JuchuuNyuuryoku["colSiiresakiRyakuName", e.RowIndex].Value = s_obj.SiiresakiRyakuName;
                        gv_JuchuuNyuuryoku["colSiiresakiYuubinNO1", e.RowIndex].Value = s_obj.YuubinNO1;
                        gv_JuchuuNyuuryoku["colSiiresakiYuubinNO2", e.RowIndex].Value = s_obj.YuubinNO2;
                        gv_JuchuuNyuuryoku["colSiiresakiJuusho1", e.RowIndex].Value = s_obj.Juusho1;
                        gv_JuchuuNyuuryoku["colSiiresakiJuusho2", e.RowIndex].Value = s_obj.Juusho2;
                        gv_JuchuuNyuuryoku["colSiiresakiTelNO11", e.RowIndex].Value = s_obj.Tel11;
                        gv_JuchuuNyuuryoku["colSiiresakiTelNO12", e.RowIndex].Value = s_obj.Tel12;
                        gv_JuchuuNyuuryoku["colSiiresakiTelNO13", e.RowIndex].Value = s_obj.Tel13;
                        gv_JuchuuNyuuryoku["colSiiresakiTelNO21", e.RowIndex].Value = s_obj.Tel21;
                        gv_JuchuuNyuuryoku["colSiiresakiTelNO22", e.RowIndex].Value = s_obj.Tel22;
                        gv_JuchuuNyuuryoku["colSiiresakiTelNO23", e.RowIndex].Value = s_obj.Tel23;
                    }
                    else
                    {
                        gv_JuchuuNyuuryoku.CurrentCell = gv_JuchuuNyuuryoku.Rows[e.RowIndex].Cells["colSiiresakiCD"];
                    }
                }
                //}
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
        private void btnNameF10_Click(object sender, EventArgs e)
        {
            F10_Gridview_Bind();
        }   

        private void F10_Gridview_Bind()
        {
            gv_JuchuuNyuuryoku.ActionType = "F10";             //to skip gv error check at the ErrorCheck() of BaseForm.cs
            if (ErrorCheck(PanelDetail))
            {
                JuchuuNyuuryokuEntity obj = new JuchuuNyuuryokuEntity();
                obj.BrandCD = txtBrandCD.Text;
                obj.ShouhinCD = txtShouhinCD.Text;
                obj.JANCD = txtJANCD.Text;
                obj.ShouhinName = txtShouhinName.Text;
                obj.YearTerm = txtYearTerm.Text;
                obj.SeasonSS = chk_SS.Checked ? "1" : "0";
                obj.SeasonFW = chk_FW.Checked ? "1" : "0";
                obj.SizeNO = txtSizeNo.Text;
                obj.ColorNO = txtColorNo.Text;

                if (string.IsNullOrEmpty(obj.BrandCD) && string.IsNullOrEmpty(obj.ShouhinCD) && string.IsNullOrEmpty(obj.JANCD) && string.IsNullOrEmpty(obj.ShouhinName) && string.IsNullOrEmpty(obj.YearTerm) && obj.SeasonSS == "0" && obj.SeasonFW == "0" && string.IsNullOrEmpty(obj.SizeNO) && string.IsNullOrEmpty(obj.ColorNO))
                {
                    base_bl.ShowMessage("E111");
                    txtBrandCD.Focus();
                    return;
                }

                obj.ChangeDate = txtJuchuuDate.Text;
                DataTable dt = obj_bl.JuchuuNyuuryoku_Display(obj);
                gv_JuchuuNyuuryoku.DataSource = dt;                     //For task no. 120
                gv_JuchuuNyuuryoku.Focus();
                if (dt.Rows.Count > 0)
                {
                    DataTable dt_temp = dt.Copy();
                    gvdt1 = dt_temp;

                    if (F8_dt1.Rows.Count == 0)
                        F8_dt1 = gvdt1.Clone();
                }
            }
            gv_JuchuuNyuuryoku.ActionType = string.Empty;             //to check gv error at the ErrorCheck() of BaseForm.cs
        }

        private void btnNameF11_Click(object sender, EventArgs e)
        {
            //if (F11_Gridivew_ErrorCheck())
            //    return;
            //else
            //    F11_Gridview_Bind();

            Function_F11();
        }

        private void Function_F11()
        {
            if (F11_Gridivew_ErrorCheck())
                return;
            else
                F11_Gridview_Bind();
        }

        private void F11_Gridview_Bind()
        {

            for (int t = 0; t < gv_JuchuuNyuuryoku.RowCount; t++)
            {
                //if (gv_JuchuuNyuuryoku.Rows[t].Cells["colJuchuuSuu"].Value.ToString() == "0")
                //{
                //    continue;
                //}

                // bool bl = false;
                // grid 1 checking
                DataRow F8_drNew = F8_dt1.NewRow();// save updated data 
                DataGridViewRow row = gv_JuchuuNyuuryoku.Rows[t];// grid view data
                string shouhinCD = row.Cells["colShouhinCD"].Value.ToString();
                string chk_value = row.Cells["colFree"].EditedFormattedValue.ToString();
                string senpouHacchuuNO = row.Cells["colSenpouHacchuuNO"].EditedFormattedValue.ToString();
                string siiresakiCD = row.Cells["colSiiresakiCD"].EditedFormattedValue.ToString();
                string siiresakiName = row.Cells["colSiiresakiName"].EditedFormattedValue.ToString();
                string soukoCD = row.Cells["colSoukoCD"].EditedFormattedValue.ToString();

                string color = row.Cells["colColorNO"].Value.ToString();
                string size = row.Cells["colSizeNO"].Value.ToString();

                //商品・カラー・サイズ・Free・仕入先CD・仕入先名・倉庫CD・先方発注番号の明細行が存在する時→Update,存在しない時→Insert
                string chk = string.Empty;
                DataRow[] select_dr1 = gvdt1.Select("ShouhinCD ='" + shouhinCD + "' and ColorNO='" + color + "' and SizeNO='" + size + "'");// original data
                DataRow existDr1 = null;
                if (chk_value != "False")
                    chk = "1";
                if(!string.IsNullOrEmpty(chk))
                    existDr1 = F8_dt1.Select("ShouhinCD ='" + shouhinCD + "' and [Free]='"+chk+"' and SoukoCD='" + soukoCD + "' and ISNULL([SiiresakiCD],'')='" + siiresakiCD + "' and ISNULL([SiiresakiName],'')='" + siiresakiName + "' and ISNULL([DJMSenpouHacchuuNO],'')='" + senpouHacchuuNO + "'").SingleOrDefault();
                else
                    existDr1 = F8_dt1.Select("ShouhinCD ='" + shouhinCD + "' and  SoukoCD='" + soukoCD + "' and ISNULL([SiiresakiCD],'')='" + siiresakiCD + "' and ISNULL([SiiresakiName],'')='" + siiresakiName + "' and ISNULL([DJMSenpouHacchuuNO],'')='" + senpouHacchuuNO + "' and [Free] IS NULL").SingleOrDefault();
                if (existDr1 != null)
                {
                    //if (select_dr1[0][8].ToString() == "0")
                    if (row.Cells["colJuchuuSuu"].Value.ToString() == "0" && gvdt1.Rows.Count != gv_JuchuuNyuuryoku.Rows.Count)
                    {
                        F8_dt1.Rows.Remove(existDr1);
                        existDr1 = null;
                    }
                }
                F8_drNew[0] = shouhinCD;
                //if (row.Cells["colJuchuuSuu"].Value.ToString() != "0" && row.Cells[8].Value.ToString() != select_dr1[0][8].ToString().Replace(".000000", string.Empty))
                if (row.Cells["colJuchuuSuu"].Value.ToString() != "0")
                {
                    for (int c = 1; c < gv_JuchuuNyuuryoku.Columns.Count; c++)
                    {
                        if (gv_JuchuuNyuuryoku.Columns[c].Name == "colFree" || gv_JuchuuNyuuryoku.Columns[c].Name == "colJuchuuSuu" || gv_JuchuuNyuuryoku.Columns[c].Name == "colSenpouHacchuuNO" || gv_JuchuuNyuuryoku.Columns[c].Name == "colSiiresakiCD" || gv_JuchuuNyuuryoku.Columns[c].Name == "colSoukoCD")
                        {
                            if (existDr1 != null)
                            {
                                if (select_dr1.Length >0 &&  select_dr1[0][c].ToString() != row.Cells[c].Value.ToString())
                                {
                                  //  bl = true;
                                    F8_drNew[c] = row.Cells[c].Value;
                                }
                                else
                                {
                                    F8_drNew[c] = existDr1[c];
                                }
                            }
                            else
                            {
                                //if (select_dr1[0][c].ToString() != row.Cells[c].Value.ToString())
                                //    bl = true;

                                F8_drNew[c] = row.Cells[c].Value;
                            }
                        }
                        else
                        {
                            if (((c == 32 && string.IsNullOrEmpty(row.Cells["colHacchuuGyouNO"].Value.ToString())) || (c == 34 &&  string.IsNullOrEmpty(row.Cells["colJuchuuGyouNO"].Value.ToString()))))
                                F8_drNew[c] = DBNull.Value;
                            else
                                F8_drNew[c] = row.Cells[c].Value;
                        }
                    }
                    // grid 1 insert(if exist, remove exist and insert)
                    //if (bl == true)
                    //{
                        if (existDr1 != null)
                            F8_dt1.Rows.Remove(existDr1);
                        F8_dt1.Rows.Add(F8_drNew);
                   // }
                }
                
            }

            gv_JuchuuNyuuryoku.Memory_Row_Count = F8_dt1.Rows.Count;
            Focus_Clear();
        }

        //private void F11_Gridview_Bind()
        //{
        //    for (int t = 0; t < gv_JuchuuNyuuryoku.RowCount; t++)
        //    {

        //        bool bl = false;
        //        // grid 1 checking
        //        DataRow F8_drNew = F8_dt1.NewRow();// save updated data 
        //        DataGridViewRow row = gv_JuchuuNyuuryoku.Rows[t];// grid view data
        //        string shouhinCD = row.Cells["colShouhinCD"].Value.ToString();
        //        string chk_value = row.Cells["colFree"].EditedFormattedValue.ToString();
        //        string senpouHacchuuNO = row.Cells["colSenpouHacchuuNO"].EditedFormattedValue.ToString();
        //        string siiresakiCD = row.Cells["colSiiresakiCD"].EditedFormattedValue.ToString();
        //        string soukoCD = row.Cells["colSoukoCD"].EditedFormattedValue.ToString();

        //        string color = row.Cells["colColorNO"].Value.ToString();
        //        string size = row.Cells["colSizeNO"].Value.ToString();

        //        string chk = string.Empty;
        //        DataRow[] select_dr1 = gv1_to_dt1.Select("ShouhinCD ='" + shouhinCD + "' and ColorNO='" + color + "' and SizeNO='" + size + "'");// original data
        //        DataRow existDr1 = null;
        //        if (chk_value != "False")
        //            chk = "1";
        //        existDr1 = F8_dt1.Select("ShouhinCD ='" + shouhinCD + "'and ISNULL([Free],'')='" + chk + "' and SoukoCD='" + soukoCD + "' and ISNULL([SiiresakiCD],'')='" + siiresakiCD + "' and ISNULL([DJMSenpouHacchuuNO],'')='" + senpouHacchuuNO + "'").SingleOrDefault();

        //        F8_drNew[0] = shouhinCD;
        //        if (row.Cells[8].Value.ToString() != select_dr1[0][8].ToString().Replace(".000000", string.Empty))
        //        {
        //            for (int c = 1; c < gv_JuchuuNyuuryoku.Columns.Count; c++)
        //            {
        //                if (gv_JuchuuNyuuryoku.Columns[c].Name == "colFree" || gv_JuchuuNyuuryoku.Columns[c].Name == "colJuchuuSuu" || gv_JuchuuNyuuryoku.Columns[c].Name == "colSenpouHacchuuNO" || gv_JuchuuNyuuryoku.Columns[c].Name == "colSiiresakiCD" || gv_JuchuuNyuuryoku.Columns[c].Name == "colSoukoCD")
        //                {
        //                    if (existDr1 != null)
        //                    {
        //                        if (select_dr1[0][c].ToString() != row.Cells[c].Value.ToString())
        //                        {
        //                            bl = true;
        //                            F8_drNew[c] = row.Cells[c].Value;
        //                        }
        //                        else
        //                        {
        //                            F8_drNew[c] = existDr1[c];
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (select_dr1[0][c].ToString() != row.Cells[c].Value.ToString())
        //                            bl = true;

        //                        F8_drNew[c] = row.Cells[c].Value;
        //                    }
        //                }
        //                else
        //                {
        //                    F8_drNew[c] = row.Cells[c].Value;
        //                }
        //            }
        //            // grid 1 insert(if exist, remove exist and insert)
        //            if (bl == true)
        //            {
        //                if (row.Cells["colJuchuuSuu"].Value.ToString() != "0")
        //                {
        //                    string Juchuu_max = string.Empty;
        //                    string Hacchuu_max = string.Empty;
        //                    if (F8_dt1.Rows.Count > 0)
        //                    {
        //                        if (existDr1 == null)
        //                        {
        //                            Juchuu_max = F8_dt1.AsEnumerable()
        //                               .Where(d => d["JuchuuNO"].ToString() == F8_drNew["JuchuuNO"].ToString())
        //                               .Max(r => r["JuchuuGyouNO"].ToString())
        //                               .ToString();

        //                            Hacchuu_max = F8_dt1.AsEnumerable()
        //                               .Where(d => d["HacchuuNO"].ToString() == F8_drNew["HacchuuNO"].ToString())
        //                               .Max(r => r.IsNull("HacchuuGyouNO") ? "0" : r["HacchuuGyouNO"].ToString())
        //                               .ToString();

        //                            if (chk_value == "True" && !string.IsNullOrEmpty(Juchuu_max))
        //                            {
        //                                F8_drNew["JuchuuGyouNO"] = Convert.ToInt32(Juchuu_max) + 1;
        //                                //F8_drNew["HacchuuNO"] = DBNull.Value;
        //                                //F8_drNew["HacchuuGyouNO"] = DBNull.Value;
        //                            }
        //                            else if (chk_value == "False" && !string.IsNullOrEmpty(Hacchuu_max))
        //                            {
        //                                F8_drNew["JuchuuGyouNO"] = Convert.ToInt32(Juchuu_max) + 1;
        //                                if(!string.IsNullOrWhiteSpace(F8_drNew["HacchuuNO"].ToString()))
        //                                F8_drNew["HacchuuGyouNO"] = Convert.ToInt32(Hacchuu_max) + 1;
        //                            }
        //                        }
        //                    }
        //                    F8_dt1.Rows.Add(F8_drNew);
        //                }
        //                if (existDr1 != null)
        //                    F8_dt1.Rows.Remove(existDr1);
        //            }
        //        }
        //    }
        //    gv_JuchuuNyuuryoku.Memory_Row_Count = F8_dt1.Rows.Count;
        //    Focus_Clear();
        //}

        private void Focus_Clear()
        {
            txtBrandCD.Focus();
            lblBrand_Name.Text = string.Empty;
            txtBrandCD.Text = string.Empty;
            txtShouhinCD.Text = string.Empty;
            txtJANCD.Text = string.Empty;
            txtShouhinName.Text = string.Empty;
            txtYearTerm.Text = string.Empty;
            chk_SS.Checked = false;
            chk_FW.Checked = false;
            txtColorNo.Text = string.Empty; 
            txtSizeNo.Text = string.Empty;
            chk_SS.Checked = true;
            chk_FW.Checked = true;
        }

        private void btnNameF8_Click(object sender, EventArgs e)
        {
            F8_Gridview_Bind();
        }

        private void F8_Gridview_Bind()
        {
            if(F8_dt1.Rows.Count>0)
            {
                //DataView objDT = new DataView(F8_dt1);
                //objDT.Sort = "ShouhinCD, ExpectedDate,JuchuuSuu  ASC";
                //F8_dt1 = objDT.ToTable();
                //F8_dt1.DefaultView.Sort = "ShouhinCD, ExpectedDate, JuchuuSuu ASC";
                //gv_JuchuuNyuuryoku.DataSource = F8_dt1.DefaultView.ToTable();

                F8_dt1.DefaultView.Sort = "ShouhinCD";
                gv_JuchuuNyuuryoku.DataSource = F8_dt1.DefaultView.ToTable();
                gv_JuchuuNyuuryoku.Focus();
                gv_JuchuuNyuuryoku.Memory_Row_Count = F8_dt1.Rows.Count;
            }
            else
            {
                DataTable dtSource = (DataTable)gv_JuchuuNyuuryoku.DataSource;
                if (dtSource != null)
                    dtSource.Rows.Clear();
            }
        }

        private void DBProcess()
        {
            using (SqlConnection sqlConnection = new SqlConnection(obj_bl.GetCon()))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Transaction = sqlTransaction;
                sqlCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    string mode = string.Empty;
                    (string, string, string) obj = GetInsert(sqlCommand);
                    if ((!string.IsNullOrEmpty(obj.Item1)) && (!string.IsNullOrEmpty(obj.Item2)) && (!string.IsNullOrEmpty(obj.Item3)))
                    {
                        if (cboMode.SelectedValue.Equals("1"))
                        {
                            mode = "New";
                            DoInsert(mode, obj.Item1, obj.Item2, obj.Item3, sqlCommand);
                        }
                        else if (cboMode.SelectedValue.Equals("2"))
                        {
                            mode = "Update";
                            DoUpdate(mode, obj.Item1, obj.Item2, obj.Item3, sqlCommand);
                        }
                        else if (cboMode.SelectedValue.Equals("3"))
                        {
                            mode = "Delete";
                            DoDelete(mode, obj.Item1, obj.Item2, obj.Item3, sqlCommand);
                        }
                    }

                    sqlTransaction.Commit();
                }
                catch(Exception ex)
                {
                    sqlTransaction.Rollback();
                    base_bl.ShowMessage(ex.Message);
                }
                
            }            
        }

        private (string, string, string) GetInsert(SqlCommand sqlCommand)
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
            dr["KibouNouki"] = string.IsNullOrEmpty(txtKibouNouki.Text) ? null : txtKibouNouki.Text.ToString();
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

            
            DataTable dt_Main = new DataTable();
            if (cboMode.SelectedValue.ToString() == "1" && F8_dt1.Rows.Count > 0)
            {
                //Get JuchuuNo and JuchuuGyouNO
                DataTable Juchuu_dt = obj_bl.GetJuchuuNO("1", txtJuchuuDate.Text, "0",sqlCommand);
                for(int k=0;k<F8_dt1.Rows.Count;k++)
                {
                    F8_dt1.Rows[k]["JuchuuNO"] = Juchuu_dt.Rows[0]["Column1"];
                    F8_dt1.Rows[k]["JuchuuGyouNO"] = k + 1;
                    F8_dt1.Rows[k]["HacchuuNO"] = DBNull.Value;
                    F8_dt1.Rows[k]["HacchuuGyouNO"] = DBNull.Value;
                }
                //for HacchuuNo and HacchuuGyouNO
                dt_Main = F8_dt1.AsEnumerable()
                          .GroupBy(r => new { Col1 = r["SiiresakiCD"], Col2 = r["SiiresakiName"], Col3 = r["SoukoCD"] })
                          .Select(g => g.OrderBy(r => r["SiiresakiCD"]).First())
                          .CopyToDataTable();

                for (int i = 0; i < dt_Main.Rows.Count; i++)
                {
                    DataTable hacchuu_dt = new DataTable();
                    DataRow[] select_drF = null;
                    select_drF = F8_dt1.Select("SiiresakiCD = '" + dt_Main.Rows[i]["SiiresakiCD"].ToString() + "' and SiiresakiName='" + dt_Main.Rows[i]["SiiresakiName"].ToString() + "' and SoukoCD='" + dt_Main.Rows[i]["SoukoCD"].ToString() + "' and [Free] IS NULL");

                    //if (dt_Main.Rows[i]["Free"].ToString() != "1")
                    if (select_drF.Length > 0)
                    {
                        hacchuu_dt = obj_bl.GetJuchuuNO("2", txtJuchuuDate.Text, "0",sqlCommand);
                        dt_Main.Rows[i]["HacchuuNO"] = hacchuu_dt.Rows[0]["Column1"];
                    }

                    dt_Main.Rows[i]["JuchuuNO"] = Juchuu_dt.Rows[0]["Column1"];
                    string siiresakiCD = dt_Main.Rows[i]["SiiresakiCD"].ToString();
                    string name = dt_Main.Rows[i]["SiiresakiName"].ToString();
                    string soukoCD = dt_Main.Rows[i]["SoukoCD"].ToString();
                    DataRow[] select_dr = null;
                    string NULL_Check = string.Empty;
                    if (string.IsNullOrEmpty(siiresakiCD))
                        NULL_Check = " and [SiiresakiCD] IS NULL ";
                    if (string.IsNullOrEmpty(name))
                        NULL_Check += " and [SiiresakiName] IS NULL ";
                    if (!string.IsNullOrEmpty(NULL_Check))
                        select_dr = F8_dt1.Select("SoukoCD ='" + soukoCD + "'" + NULL_Check + "");
                    else
                        select_dr = F8_dt1.Select("SiiresakiCD = '" + siiresakiCD + "'and SiiresakiName='" + name + "' and SoukoCD='" + soukoCD + "'");
                    if (select_dr.Length > 0)
                    {
                        for (int j = 0; j < select_dr.Length; j++)
                        {
                            if (hacchuu_dt.Rows.Count > 0 && select_dr[j]["Free"].ToString() != "1")
                            {
                                select_dr[j]["HacchuuNO"] = hacchuu_dt.Rows[0]["Column1"];
                                select_dr[j]["HacchuuGyouNO"] = j + 1;
                            }
                        }
                    }
                }
            }

            if (cboMode.SelectedValue.ToString() == "2" && F8_dt1.Rows.Count > 0)
            {
                //remove add new row 
                //for (int k = F8_dt1.Rows.Count - 1; k >= 0; k--)
                //{
                //    DataRow dr_K = F8_dt1.Rows[k];
                //    if (string.IsNullOrEmpty(dr_K["JuchuuNO"].ToString()))
                //    {
                //        dr_K.Delete();
                //    }
                //}
                //F8_dt1.AcceptChanges();

                //take JuchuuNo and JuchuuGyouNO For added New row (update case add new row 2021-03-03)
                string J_NO = string.Empty;
                for (int k = 0; k < F8_dt1.Rows.Count; k++)
                {
                    DataRow dr_K = F8_dt1.Rows[k];

                    if (!string.IsNullOrEmpty(dr_K["JuchuuNO"].ToString()))
                        J_NO = dr_K["JuchuuNO"].ToString();
                    else
                    {
                        dr_K["JuchuuNO"] = J_NO;
                        int[] TableB = F8_dt1.AsEnumerable().Select(s => s.IsNull("JuchuuGyouNO") ? 0 : Convert.ToInt32(s["JuchuuGyouNO"])).ToArray<int>();
                        dr_K["JuchuuGyouNO"] = Convert.ToInt32(TableB.Max()) + 1;
                    }
                }

                //first filter for hacchuu NO group by
                dt_Main = F8_dt1.AsEnumerable()
                                    .GroupBy(r => new { Col1 = r["SiiresakiCD"], Col2 = r["SoukoCD"], Col3 = r["HacchuuNO"] })
                                    .Select(g => g.OrderBy(r => r["JuchuuNO"]).Last()).CopyToDataTable();

                for (int i = 0; i < dt_Main.Rows.Count; i++)
                {
                    JuchuuNyuuryokuBL objMethod = new JuchuuNyuuryokuBL();
                    DataTable hacchuu_dt = new DataTable();
                    DataTable Max_HacchuuNO = new DataTable();
                    DataRow[] select_dr = null;
                    if (!string.IsNullOrEmpty(dt_Main.Rows[i]["HacchuuNO"].ToString()))
                        select_dr = F8_dt1.Select("SiiresakiCD = '" + dt_Main.Rows[i]["SiiresakiCD"].ToString() + "' and SoukoCD='" + dt_Main.Rows[i]["SoukoCD"].ToString() + "' and HacchuuNO='" + dt_Main.Rows[i]["HacchuuNO"].ToString() + "' and [Free] IS NULL");
                    else
                        select_dr = F8_dt1.Select("SiiresakiCD = '" + dt_Main.Rows[i]["SiiresakiCD"].ToString() + "' and SoukoCD='" + dt_Main.Rows[i]["SoukoCD"].ToString() + "' and [Free] IS NULL");

                    //if (!string.IsNullOrEmpty(dt_Main.Rows[i]["HacchuuNO"].ToString()) && dt_Main.Rows[i]["Free"].ToString() != "1")
                    if (!string.IsNullOrEmpty(dt_Main.Rows[i]["HacchuuNO"].ToString()) && select_dr.Length > 0)
                        {
                        //existing record take HacchuuNO
                        Max_HacchuuNO = objMethod.Get_Max_HacchuuNO(dt_Main.Rows[i]["JuchuuNO"].ToString(), dt_Main.Rows[i]["SiiresakiCD"].ToString(), dt_Main.Rows[i]["SoukoCD"].ToString(), dt_Main.Rows[i]["HacchuuNO"].ToString());
                        if (Max_HacchuuNO.Rows.Count > 0)
                        {
                            dt_Main.Rows[i]["HacchuuNO"] = Max_HacchuuNO.Rows[0]["HacchuuNO"];

                            for (int j = 0; j < F8_dt1.Rows.Count; j++)
                            {
                                if (F8_dt1.Rows[j]["JuchuuNO"].ToString() == dt_Main.Rows[i]["JuchuuNO"].ToString() && string.IsNullOrEmpty(F8_dt1.Rows[j]["HacchuuNO"].ToString()) && string.IsNullOrEmpty(F8_dt1.Rows[j]["HacchuuGyouNO"].ToString()) && F8_dt1.Rows[j]["SiiresakiCD"].ToString() == dt_Main.Rows[i]["SiiresakiCD"].ToString() && F8_dt1.Rows[j]["SoukoCD"].ToString() == dt_Main.Rows[i]["SoukoCD"].ToString())
                                {
                                    F8_dt1.Rows[j]["HacchuuNO"] = Max_HacchuuNO.Rows[0]["HacchuuNO"].ToString();

                                    string max = F8_dt1.AsEnumerable()
                                                 .Where(d => d["JuchuuNO"].ToString() == dt_Main.Rows[i]["JuchuuNO"].ToString() && d["SiiresakiCD"].ToString() == dt_Main.Rows[i]["SiiresakiCD"].ToString() && d["SoukoCD"].ToString() == dt_Main.Rows[i]["SoukoCD"].ToString())
                                                 .Max(r => r.IsNull("HacchuuGyouNO") ? "0" : r["HacchuuGyouNO"].ToString())
                                                 .ToString();

                                    F8_dt1.Rows[j]["HacchuuGyouNO"] = Convert.ToInt32(max) + 1;
                                }
                            }
                        }
                    }
                    //else if (string.IsNullOrEmpty(dt_Main.Rows[i]["HacchuuNO"].ToString()) && dt_Main.Rows[i]["Free"].ToString() != "1")
                    else if (string.IsNullOrEmpty(dt_Main.Rows[i]["HacchuuNO"].ToString()) && select_dr.Length > 0)
                    {
                        for (int j = 0; j < F8_dt1.Rows.Count; j++)
                        {
                            if (F8_dt1.Rows[j]["JuchuuNO"].ToString() == dt_Main.Rows[i]["JuchuuNO"].ToString() && string.IsNullOrEmpty(F8_dt1.Rows[j]["HacchuuNO"].ToString()) && string.IsNullOrEmpty(F8_dt1.Rows[j]["HacchuuGyouNO"].ToString()) && F8_dt1.Rows[j]["SiiresakiCD"].ToString() == dt_Main.Rows[i]["SiiresakiCD"].ToString() && F8_dt1.Rows[j]["SoukoCD"].ToString() == dt_Main.Rows[i]["SoukoCD"].ToString())
                            {
                                if (string.IsNullOrEmpty(dt_Main.Rows[i]["HacchuuNO"].ToString()))
                                {
                                    hacchuu_dt = obj_bl.GetJuchuuNO("2", txtJuchuuDate.Text, "0");
                                    dt_Main.Rows[i]["HacchuuNO"] = hacchuu_dt.Rows[0]["Column1"];
                                }
                                F8_dt1.Rows[j]["HacchuuNO"] = dt_Main.Rows[i]["HacchuuNO"];

                                string max = F8_dt1.AsEnumerable()
                                            .Where(d => d["JuchuuNO"].ToString() == dt_Main.Rows[i]["JuchuuNO"].ToString() && d["SiiresakiCD"].ToString() == dt_Main.Rows[i]["SiiresakiCD"].ToString() && d["SoukoCD"].ToString() == dt_Main.Rows[i]["SoukoCD"].ToString())
                                            .Max(r => r.IsNull("HacchuuGyouNO") ? "0" : r["HacchuuGyouNO"].ToString())
                                            .ToString();

                                F8_dt1.Rows[j]["HacchuuGyouNO"] = Convert.ToInt32(max) + 1;
                            }
                        }
                    }
                }
            }

            if (F8_dt1.Rows.Count == 0)
                return (string.Empty, string.Empty, string.Empty);

            Column_Remove_Datatable(dt_Main);

            DataTable save_dt = F8_dt1.AsEnumerable()
                    .GroupBy(r => new { Col1 = r["JuchuuNO"], Col2 = r["JuchuuGyouNO"] })
                    .Select(g => g.OrderBy(r => r["JuchuuNO"]).Last()).CopyToDataTable();

            string main_XML = cf.DataTableToXml(dt_Main);
            string detail_XML = cf.DataTableToXml(save_dt);
            return (header_XML, main_XML, detail_XML);
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

        private void DoInsert(string mode,string str_header,string str_main,string str_detail,SqlCommand sqlCommand)
        {
            JuchuuNyuuryokuBL objMethod = new JuchuuNyuuryokuBL();
            string return_BL =  objMethod.JuchuuNyuuryoku_CUD(mode,str_header,str_main,str_detail,sqlCommand);
            if (return_BL == "true")
                base_bl.ShowMessage("I101");
        }

        private void DoUpdate(string mode, string str_header, string str_main, string str_detail, SqlCommand sqlCommand)
        {
            JuchuuNyuuryokuBL objMethod = new JuchuuNyuuryokuBL();
            string return_BL = objMethod.JuchuuNyuuryoku_CUD(mode, str_header, str_main, str_detail,sqlCommand);
            if (return_BL == "true")
                base_bl.ShowMessage("I101");
        }

        private void DoDelete(string mode, string str_header, string str_main, string str_detail, SqlCommand sqlCommand)
        {
            JuchuuNyuuryokuBL objMethod = new JuchuuNyuuryokuBL();
            string return_BL = objMethod.JuchuuNyuuryoku_CUD(mode, str_header, str_main, str_detail,sqlCommand);
            if (return_BL == "true")
                base_bl.ShowMessage("I102");
        }

       private void Column_Remove_Datatable(DataTable dt)
        {
            //ktp error no 152
            if(dt.Columns.Count>0)
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
        }

        private void gv_1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Gridview_F9ShowHide(e.ColumnIndex,"Show");
        }

        private void Gridview_F9ShowHide(int col,string type)
        {
            SCombo cbo = this.TopLevelControl.Controls.Find("cboMode", true)[0] as SCombo;
            Control[] ctrlArr = this.TopLevelControl.Controls.Find("BtnF9", true);
            if (gv_JuchuuNyuuryoku.Columns[col].Name == "colSiiresakiCD" || gv_JuchuuNyuuryoku.Columns[col].Name == "colSoukoCD")
            {
                Control btnF9 = ctrlArr[0];
                if (ctrlArr.Length > 0 && type=="Show")
                {
                    if (cbo.SelectedValue.Equals("3") || cbo.SelectedValue.Equals("4"))
                        btnF9.Visible = false;
                    else if (btnF9 != null)
                        btnF9.Visible = true;
                }
                else
                {
                    if (btnF9 != null)
                        btnF9.Visible = false;
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
       
        private void gv_1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(gv_JuchuuNyuuryoku.IsLastKeyEnter)
            {
                if (ErrorCheck_CellEndEdit(e.RowIndex, e.ColumnIndex))
                gv_JuchuuNyuuryoku.CurrentCell = gv_JuchuuNyuuryoku.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
            if (e.ColumnIndex == 8)
            {
                //0に変更された場合はワークテーブルから削除
                if (gv_JuchuuNyuuryoku.Rows[e.RowIndex].Cells["colJuchuuSuu"].EditedFormattedValue.ToString() == "0")
                {
                    DataGridViewRow row = gv_JuchuuNyuuryoku.Rows[e.RowIndex];// grid view data
                    string shouhinCD = row.Cells["colShouhinCD"].Value.ToString();
                    string chk_value = row.Cells["colFree"].EditedFormattedValue.ToString();
                    string senpouHacchuuNO = row.Cells["colSenpouHacchuuNO"].EditedFormattedValue.ToString();
                    string siiresakiCD = row.Cells["colSiiresakiCD"].EditedFormattedValue.ToString();
                    string siiresakiName = row.Cells["colSiiresakiName"].EditedFormattedValue.ToString();
                    string soukoCD = row.Cells["colSoukoCD"].EditedFormattedValue.ToString();

                    string color = row.Cells["colColorNO"].Value.ToString();
                    string size = row.Cells["colSizeNO"].Value.ToString();

                    //商品・カラー・サイズ・Free・仕入先CD・仕入先名・倉庫CD・先方発注番号の明細行が存在する時→Update,存在しない時→Insert
                    string chk = string.Empty;
                    DataRow existDr1 = null;
                    if (chk_value != "False")
                        chk = "1";
                    if (!string.IsNullOrEmpty(chk))
                        existDr1 = F8_dt1.Select("ShouhinCD ='" + shouhinCD + "' and [Free]='" + chk + "' and SoukoCD='" + soukoCD + "' and ISNULL([SiiresakiCD],'')='" + siiresakiCD + "' and ISNULL([SiiresakiName],'')='" + siiresakiName + "' and ISNULL([DJMSenpouHacchuuNO],'')='" + senpouHacchuuNO + "'").SingleOrDefault();
                    else
                        existDr1 = F8_dt1.Select("ShouhinCD ='" + shouhinCD + "' and  SoukoCD='" + soukoCD + "' and ISNULL([SiiresakiCD],'')='" + siiresakiCD + "' and ISNULL([SiiresakiName],'')='" + siiresakiName + "' and ISNULL([DJMSenpouHacchuuNO],'')='" + senpouHacchuuNO + "' and [Free] IS NULL").SingleOrDefault();
                    if (existDr1 != null)
                    {
                        F8_dt1.Rows.Remove(existDr1);
                        existDr1 = null;
                    }
                }
            }
        }

        private bool ErrorCheck_CellEndEdit(int row,int col)
        {
            string isSelected = string.Empty;
            string free = gv_JuchuuNyuuryoku.Rows[row].Cells["colFree"].Value.ToString();
            string JuchuuSuu = gv_JuchuuNyuuryoku.Rows[row].Cells["colJuchuuSuu"].Value.ToString();
            string siiresakiCD = gv_JuchuuNyuuryoku.Rows[row].Cells["colSiiresakiCD"].EditedFormattedValue.ToString().Trim();
            if (string.IsNullOrEmpty(free))
                isSelected = "OFF";
            else isSelected = "ON";
            bool bl_error = false;
            string col_Name = gv_JuchuuNyuuryoku.Columns[col].Name;

            if (col_Name == "colJuchuuSuu")
            {
                string split_val = gv_JuchuuNyuuryoku.Rows[row].Cells["colJuchuuSuu"].EditedFormattedValue.ToString().Replace(",", "");
                int JuchuuSuu_Number = string.IsNullOrEmpty(gv_JuchuuNyuuryoku.Rows[row].Cells["colJuchuuSuu"].EditedFormattedValue.ToString()) ? 0 : Convert.ToInt32(split_val);
                gv_JuchuuNyuuryoku.Rows[row].Cells["colJuchuuSuu"].Value = JuchuuSuu_Number.ToString();
            }
            if (col_Name == "colJuchuuMeisaiTekiyou")
            {
                int MaxLength = ((DataGridViewTextBoxColumn)gv_JuchuuNyuuryoku.Columns[col_Name]).MaxInputLength;

                string byte_text = gv_JuchuuNyuuryoku.Rows[row].Cells[col_Name].EditedFormattedValue.ToString();
                if (cf.IsByteLengthOver(MaxLength, byte_text))
                {
                    MessageBox.Show("入力された文字が長すぎます", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bl_error = true;
                    return bl_error;
                }
            }
            if (col_Name == "colSiiresakiCD")
            {
                DataGridViewRow selectedRow = null;
                DataTable siiresaki_dt = new DataTable();
                if (isSelected == "OFF" && JuchuuSuu != "0")
                {
                    if (string.IsNullOrEmpty(siiresakiCD))
                    {
                        base_bl.ShowMessage("E102");
                        bl_error = true;
                    }
                }
                if (bl_error == false && (!string.IsNullOrEmpty(siiresakiCD)))
                {
                    (bl_error, siiresaki_dt) = Gridview_Error_Check("E101", siiresakiCD, "Siiresaki");
                    if (bl_error == false)
                        (bl_error, siiresaki_dt) = Gridview_Error_Check("E227", siiresakiCD, "Siiresaki");
                    if (bl_error == false)
                        (bl_error, siiresaki_dt) = Gridview_Error_Check("E267", siiresakiCD, "Siiresaki");
                }
                if (bl_error == false && (!string.IsNullOrEmpty(siiresakiCD)))
                {
                    
                    if (gv_JuchuuNyuuryoku.SelectedCells.Count > 0)
                    {
                        //int selectedrowindex = row;
                        selectedRow = gv_JuchuuNyuuryoku.Rows[row];
                    }
                    sobj.Access_Siiresaki_obj = From_DB_To_Siiresaki(siiresaki_dt, selectedRow);
                }
                if(bl_error==false && string.IsNullOrEmpty(siiresakiCD))
                {
                    selectedRow = gv_JuchuuNyuuryoku.Rows[row];
                    ClearSiiresakiData(selectedRow);
                }
                if (bl_error)
                    return bl_error;
            }
            if (col_Name == "colexpectedDate")
            {
                DateTime JuchuuDate = string.IsNullOrEmpty(txtJuchuuDate.Text) ? Convert.ToDateTime(base_Entity.LoginDate) : Convert.ToDateTime(txtJuchuuDate.Text);

                string expectedDate = gv_JuchuuNyuuryoku.Rows[row].Cells["colexpectedDate"].EditedFormattedValue.ToString().Trim();
                if (isSelected == "OFF" && JuchuuSuu != "0")
                {
                    if (string.IsNullOrEmpty(expectedDate))
                    {
                        base_bl.ShowMessage("E102");
                        bl_error = true;
                    }
                }

                if (bl_error == false && (!string.IsNullOrEmpty(expectedDate)))
                {
                    TextBox txt = new TextBox();
                    txt.Text = expectedDate;
                    if (!cf.DateCheck(txt))
                    {
                        base_bl.ShowMessage("E103");
                        bl_error = true;
                    }
                    if (bl_error == false)
                    {
                        gv_JuchuuNyuuryoku.Rows[row].Cells["colexpectedDate"].Value = txt.Text;
                        expectedDate = string.IsNullOrEmpty(txt.Text) ? base_Entity.LoginDate : txt.Text;
                        if (Convert.ToDateTime(expectedDate) < JuchuuDate)
                        {
                            base_bl.ShowMessage("E267", "受注日");
                            bl_error = true;
                        }
                    }
                }
                if (bl_error)
                    return bl_error;

            }

            if (col_Name == "colSoukoCD")
            {
                DataTable souko_dt = new DataTable();
                string soukoCD = gv_JuchuuNyuuryoku.Rows[row].Cells["colSoukoCD"].EditedFormattedValue.ToString().Trim();
                if (JuchuuSuu != "0")
                {
                    if (string.IsNullOrEmpty(soukoCD))
                    {
                        base_bl.ShowMessage("E102");
                        bl_error = true;
                    }
                }
                if (bl_error == false && (!string.IsNullOrEmpty(soukoCD)))
                {
                    (bl_error, souko_dt) = Gridview_Error_Check("E101", soukoCD, "Souko");
                }
                if (bl_error == false && (!string.IsNullOrEmpty(soukoCD)))
                {
                    gv_JuchuuNyuuryoku.Rows[row].Cells["colSoukoCD"].Value = souko_dt.Rows[0]["SoukoCD"];
                    gv_JuchuuNyuuryoku.Rows[row].Cells["colSoukoName"].Value = souko_dt.Rows[0]["SoukoName"];
                }
                if (bl_error)
                    return bl_error;
            }


            return bl_error;
        }
       
        private bool  F11_Gridivew_ErrorCheck()
        {
            bool bl_error = false;
          
            foreach (DataGridViewRow gv in gv_JuchuuNyuuryoku.Rows)
            {
                if(gv.Cells["colJuchuuSuu"].Value.ToString() != "0")
                {
                    for (int i = 0; i < gv.Cells.Count; i++)
                    {
                        string colName = gv_JuchuuNyuuryoku.Columns[i].Name;
                        if (colName == "colSiiresakiCD" || colName == "colexpectedDate" || colName == "colSoukoCD" || colName == "colJuchuuMeisaiTekiyou" || colName== "colJuchuuSuu")
                        {
                            if (ErrorCheck_CellEndEdit(gv.Index, i))
                            {                                
                                gv_JuchuuNyuuryoku.Focus();//At first,set focus to gridview from F11 (ktp)
                                gv_JuchuuNyuuryoku.CurrentCell = gv_JuchuuNyuuryoku.Rows[gv.Index].Cells[i];
                                // gv_JuchuuNyuuryoku.BeginEdit(true);
                                bl_error = true;
                                break;
                            }
                        }
                    }
                }
               
                if (bl_error)
                    return true;
            }
            return bl_error;
        }

        private void gv_JuchuuNyuuryoku_KeyDown(object sender, KeyEventArgs e)
        {
            SCombo cbo = new SCombo();

            if (this.TopLevelControl.Controls.Find("cboMode", true).Count() > 0)
                cbo = this.TopLevelControl.Controls.Find("cboMode", true)[0] as SCombo;
            if (e.KeyCode == Keys.F9 && (cbo.SelectedValue.Equals("1") || cbo.SelectedValue.Equals("2")))
            {
                if (gv_JuchuuNyuuryoku.CurrentCell != null)
                {
                    if (gv_JuchuuNyuuryoku.CurrentCell.ColumnIndex == 14 || gv_JuchuuNyuuryoku.CurrentCell.ColumnIndex == 18)//ssa
                    {
                        gridKeyDown();
                    }
                }
            }

        }
        private void gridKeyDown()
        {
            gv_JuchuuNyuuryoku.CellEndEdit -= new DataGridViewCellEventHandler(gv_1_CellEndEdit);
            gv_JuchuuNyuuryoku.EndEdit();
            gv_JuchuuNyuuryoku.CellEndEdit += new DataGridViewCellEventHandler(gv_1_CellEndEdit);

            int row = gv_JuchuuNyuuryoku.CurrentCell.RowIndex;
            int column = gv_JuchuuNyuuryoku.CurrentCell.ColumnIndex;
            if (gv_JuchuuNyuuryoku.CurrentCell.OwningColumn.Name == "colSiiresakiCD")
            {
                SiiresakiSearch detail = new SiiresakiSearch();
                detail.Date_Access_Siiresaki = txtJuchuuDate.Text;
                detail.ShowDialog();

                if (!string.IsNullOrEmpty(detail.SiiresakiCD))
                {
                    gv_JuchuuNyuuryoku.CurrentCell = this.gv_JuchuuNyuuryoku[column + 3, row];
                    this.gv_JuchuuNyuuryoku.CurrentCell.Selected = true;

                    gv_JuchuuNyuuryoku[column, row].Value = detail.SiiresakiCD.ToString();
                    gv_JuchuuNyuuryoku[column + 1, row].Value = detail.SiiresakiName.ToString();
                }
                else
                {
                    gv_JuchuuNyuuryoku.CurrentCell = this.gv_JuchuuNyuuryoku[column, row];
                    this.gv_JuchuuNyuuryoku.CurrentCell.Selected = true;
                }


                DataTable dt = siiresaki_bl.Siiresaki_Select_Check(detail.SiiresakiCD.ToString(), txtJuchuuDate.Text, "E101");
                if (dt.Rows.Count > 0 && dt.Rows[0]["MessageID"].ToString() != "E101")
                {
                    DataGridViewRow selectedRow = null;
                    int selectedrowindex = gv_JuchuuNyuuryoku.SelectedCells[0].RowIndex;
                    selectedRow = gv_JuchuuNyuuryoku.Rows[selectedrowindex];

                    sobj = new SiiresakiDetail();
                    sobj.Access_Siiresaki_obj = From_DB_To_Siiresaki(dt, selectedRow);
                }
            }
            else if(gv_JuchuuNyuuryoku.CurrentCell.OwningColumn.Name == "colSoukoCD")
            {
                SoukoSearch souko = new SoukoSearch();
                souko.ShowDialog();

                if(!string.IsNullOrEmpty(souko.soukoCD))
                {
                    if (gv_JuchuuNyuuryoku.Rows.Count - 1 != row)
                        gv_JuchuuNyuuryoku.CurrentCell = this.gv_JuchuuNyuuryoku[6, row + 1];
                    else
                        gv_JuchuuNyuuryoku.CurrentCell = this.gv_JuchuuNyuuryoku[column, row];
                    this.gv_JuchuuNyuuryoku.CurrentCell.Selected = true;

                    gv_JuchuuNyuuryoku[column, row].Value = souko.soukoCD.ToString();
                    gv_JuchuuNyuuryoku[column + 1, row].Value = souko.soukoName.ToString();
                }
                else
                {
                    gv_JuchuuNyuuryoku.CurrentCell = this.gv_JuchuuNyuuryoku[column, row];
                    this.gv_JuchuuNyuuryoku.CurrentCell.Selected = true;
                }
            }
        }

        private void gv_JuchuuNyuuryoku_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                (e.Control as DataGridViewTextBoxEditingControl).KeyDown -= new KeyEventHandler(gv_JuchuuNyuuryoku_KeyDown);
                (e.Control as DataGridViewTextBoxEditingControl).KeyDown += new KeyEventHandler(gv_JuchuuNyuuryoku_KeyDown);

                Control[] ctrlArr = this.TopLevelControl.Controls.Find("BtnF9", true);
                Control btnF9 = ctrlArr[0];
                if (btnF9 != null)
                {
                    btnF9.Click -= BtnF9_Click;
                    btnF9.Click += BtnF9_Click;
                }
            }
        }

        private void BtnF9_Click(object sender, EventArgs e)
        {
            if (gv_JuchuuNyuuryoku.CurrentCell != null)
            {
                if (gv_JuchuuNyuuryoku.CurrentCell.ColumnIndex == 14 || gv_JuchuuNyuuryoku.CurrentCell.ColumnIndex == 18)//ssa
                {
                    gridKeyDown();
                }
            }
        }
        private void ClearSiiresakiData(DataGridViewRow selectedRow)
        {
            SiiresakiEntity obj = new SiiresakiEntity();
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
        }
    }
}
