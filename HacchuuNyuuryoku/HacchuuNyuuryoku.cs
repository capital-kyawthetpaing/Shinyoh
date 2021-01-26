using BL;
using CKM_CommonFunction;
using Entity;
using Shinyoh;
using Shinyoh_Details;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HacchuuNyuuryoku
{
    public partial class HacchuuNyuuryoku : BaseForm
    {
        CommonFunction cf;
        multipurposeEntity multi_Entity;
        BaseEntity base_Entity;
        BaseBL base_bl;
        SiiresakiDetail sobj;
        HacchuuNyuuryokuBL obj_bl;

        DataTable gv1_to_dt1;
        DataTable F8_dt1;
        public HacchuuNyuuryoku()
        {
            InitializeComponent();
            cf = new CommonFunction();
            base_bl = new BaseBL();
            sobj = new SiiresakiDetail();
            obj_bl = new HacchuuNyuuryokuBL();

            gv1_to_dt1 = new DataTable();
            F8_dt1 = new DataTable();
        }

        private void HacchuuNyuuryoku_Load(object sender, EventArgs e)
        {
            ProgramID = "HacchuuNyuuryoku";
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
            SetButton(ButtonType.BType.Display, F10, "表示(F10)", false);
            SetButton(ButtonType.BType.Memory, F11, "保存(F11)", false);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);

            txtSiiresakiCD.lblName = lblSiiresakiShort_Name;
            txtStaffCD.lblName = lblStaff_Name;
            txtBrandCD.lblName = lblBrand_Name;

            txtSiiresakiCD.ChangeDate = txtHacchuuDate;
            txtStaffCD.ChangeDate = txtHacchuuDate;
            txtShouhinCD.ChangeDate = txtHacchuuDate;

            base_Entity = _GetBaseData();
            ChangeMode(Mode.New);

            txtHacchuuNO.ChangeDate = txtHacchuuDate;
            txtCopy.ChangeDate = txtHacchuuDate;
           
            gv_HacchuuNyuuryoku.SetGridDesign();
            gv_HacchuuNyuuryoku.SetReadOnlyColumn("ColHinbanCD,colShouhinName,colColorRyakuName,colColorNO,colSizeNO,colHacchuuTanka,colJANCD,colSoukoName");
            gv_HacchuuNyuuryoku.SetHiraganaColumn("colHacchuuMeisaiTekiyou");
            gv_HacchuuNyuuryoku.SetNumberColumn("colHacchuuSuu,colChakuniYoteiDate");
            gv_HacchuuNyuuryoku.ClearSelection();
        }

        private void ChangeMode(Mode mode)
        {
            Mode_Setting();
            switch (mode)
            {
                case Mode.New:
                    ErrorCheck();
                    txtHacchuuNO.E102Check(false);

                    txtHacchuuNO.E133Check(false, "HacchuuNyuuryoku", txtHacchuuNO, null, null);
                    txtHacchuuNO.E266Check(false, "HacchuuNyuuryoku", txtHacchuuNO);
                    txtHacchuuNO.E265Check(false, "HacchuuNyuuryoku", txtHacchuuNO);
                    
                    txtCopy.E133Check(true, "HacchuuNyuuryoku", txtCopy, null, null);

                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    break;

                case Mode.Update:
                    ErrorCheck();
                    txtHacchuuNO.E102Check(true);
                    txtCopy.E102Check(false);

                    txtHacchuuNO.E133Check(true, "HacchuuNyuuryoku", txtHacchuuNO, null, null);
                    txtHacchuuNO.E266Check(true, "HacchuuNyuuryoku", txtHacchuuNO);
                    txtHacchuuNO.E265Check(true, "HacchuuNyuuryoku", txtHacchuuNO);


                    Disable_UDI_Mode();
                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    ErrorCheck();
                    txtHacchuuNO.E102Check(true);
                    txtCopy.E102Check(false);

                    txtHacchuuNO.E133Check(true, "HacchuuNyuuryoku", txtHacchuuNO, null, null);
                    txtHacchuuNO.E266Check(true, "HacchuuNyuuryoku", txtHacchuuNO);
                    txtHacchuuNO.E265Check(true, "HacchuuNyuuryoku", txtHacchuuNO);

                    Disable_UDI_Mode();
                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;

                    break;
                case Mode.Inquiry:
                    txtHacchuuNO.E102Check(true);
                    txtCopy.E102Check(false);

                    txtHacchuuNO.E133Check(true, "HacchuuNyuuryoku", txtHacchuuNO, null, null);

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
            cf.Clear(PanelDetail);

            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(PanelDetail);

            lblSiiresakiShort_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblStaff_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblBrand_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblYear.BorderStyle = System.Windows.Forms.BorderStyle.None;


            lblSiiresakiShort_Name.Text = string.Empty;
            lblStaff_Name.Text = string.Empty;
            lblBrand_Name.Text = string.Empty;

            gv1_to_dt1 = new DataTable();
            F8_dt1 = new DataTable();

            txtHacchuuNO.Focus();
            txtHacchuuDate.Text = base_Entity.LoginDate;
            txtStaffCD.Text = base_Entity.OperatorCD;
            lblStaff_Name.Text = base_Entity.SPName;

            for (int i = 0; i < gv_HacchuuNyuuryoku.RowCount; i++)
            {
                gv_HacchuuNyuuryoku.Rows.Remove(gv_HacchuuNyuuryoku.Rows[0]);
            }

            SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", false);
            SetButton(ButtonType.BType.Display, F10, "表示(F10)", false);
            SetButton(ButtonType.BType.Memory, F11, "保存(F11)", false);
           
        }

        public void Disable_UDI_Mode()
        {
            txtCopy.Enabled = false;
        }

        public void ErrorCheck()
        {
            txtHacchuuDate.E102Check(true);
            txtHacchuuDate.E103Check(true);
            
            txtHacchuuDate.E115Check(true, "HacchuuNyuuryoku", txtHacchuuDate);

            txtSiiresakiCD.E102Check(true);
            txtSiiresakiCD.E101Check(true, "M_Siiresaki", txtSiiresakiCD, txtHacchuuDate, null);
            txtSiiresakiCD.E267Check(true, "M_Siiresaki", txtSiiresakiCD, txtHacchuuDate);
            txtSiiresakiCD.E227Check(true, "M_Siiresaki", txtSiiresakiCD, txtHacchuuDate);
            
            txtStaffCD.E102Check(true);
            txtStaffCD.E101Check(true, "M_Staff", txtStaffCD, txtHacchuuDate, null);
            txtStaffCD.E135Check(true, "M_Staff", txtStaffCD, txtHacchuuDate);
        }

        private void EnablePanel()
        {
            cf.EnablePanel(PanelDetail);
            SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", true);
            SetButton(ButtonType.BType.Display, F10, "表示(F10)", true);
            SetButton(ButtonType.BType.Memory, F11, "保存(F11)", true);
            txtHacchuuDate.Focus();
            cf.DisablePanel(PanelTitle);
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
                //F8_Gridview_Bind();
            }
            if (tagID == "10")
            {
                F10_Gridview_Bind();
            }
            if (tagID == "11")
            {
               // F11_Gridview_Bind();
            }
            if (tagID == "12")
            {
                if (F8_dt1.Rows.Count > 0)
                {
                   // DBProcess();

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

        private void From_DB_To_Form(DataTable dt)
        {
            if (dt.Rows[0]["MessageID"].ToString() == "E132")
            {
                txtHacchuuDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["HacchuuDate"]);
                txtSiiresakiCD.Text = dt.Rows[0]["SiiresakiCD"].ToString();
                lblSiiresakiShort_Name.Text = dt.Rows[0]["SiiresakiRyakuName"].ToString();
                txtStaffCD.Text = dt.Rows[0]["StaffCD"].ToString();
                lblStaff_Name.Text = dt.Rows[0]["StaffName"].ToString();
                txtHacchuuDenpyouTekiyou.Text = dt.Rows[0]["HacchuuDenpyouTekiyou"].ToString();

                //show page load data in siiresaki detail
                sobj.Access_Siiresaki_obj = From_DB_To_Siiresaki(dt);

                dt.Columns.Remove("HacchuuDate");
                dt.Columns.Remove("SiiresakiCD");
                dt.Columns.Remove("SiiresakiRyakuName");
                dt.Columns.Remove("SiiresakiName");
                dt.Columns.Remove("SiiresakiYuubinNO1");
                dt.Columns.Remove("SiiresakiYuubinNO2");
                dt.Columns.Remove("SiiresakiJuusho1");
                dt.Columns.Remove("SiiresakiJuusho2");
                dt.Columns.Remove("SiiresakiTelNO1-1");
                dt.Columns.Remove("SiiresakiTelNO1-2");
                dt.Columns.Remove("SiiresakiTelNO1-3");
                dt.Columns.Remove("SiiresakiTelNO2-1");
                dt.Columns.Remove("SiiresakiTelNO2-2");
                dt.Columns.Remove("SiiresakiTelNO2-3");
                dt.Columns.Remove("StaffCD");
                dt.Columns.Remove("StaffName");
                dt.Columns.Remove("HacchuuDenpyouTekiyou");
                dt.Columns.Remove("MessageID");

                gv_HacchuuNyuuryoku.DataSource = dt;
                gv_HacchuuNyuuryoku.ClearSelection();

                DataTable dt_temp = dt.Copy();
                gv1_to_dt1 = dt_temp;

                if (cboMode.SelectedValue.ToString() == "1")
                    F8_dt1 = gv1_to_dt1.Clone();
                else
                    F8_dt1 = gv1_to_dt1.Copy();
            }
        }

        private SiiresakiEntity From_DB_To_Siiresaki(DataTable dt)
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
            if (dt.Columns.Contains("SiiresakiTelNO1-1"))
                obj.Tel11 = dt.Rows[0]["SiiresakiTelNO1-1"].ToString();
            else obj.Tel11 = dt.Rows[0]["Tel11"].ToString();
            if (dt.Columns.Contains("SiiresakiTelNO1-2"))
                obj.Tel12 = dt.Rows[0]["SiiresakiTelNO1-2"].ToString();
            else
                obj.Tel12 = dt.Rows[0]["Tel12"].ToString();
            if (dt.Columns.Contains("SiiresakiTelNO1-3"))
                obj.Tel13 = dt.Rows[0]["SiiresakiTelNO1-3"].ToString();
            else
                obj.Tel13 = dt.Rows[0]["Tel13"].ToString();
            if (dt.Columns.Contains("SiiresakiTelNO2-1"))
                obj.Tel21 = dt.Rows[0]["SiiresakiTelNO2-1"].ToString();
            else
                obj.Tel21 = dt.Rows[0]["Tel21"].ToString();
            if (dt.Columns.Contains("SiiresakiTelNO2-2"))
                obj.Tel22 = dt.Rows[0]["SiiresakiTelNO2-2"].ToString();
            else
                obj.Tel22 = dt.Rows[0]["Tel22"].ToString();
            if (dt.Columns.Contains("SiiresakiTelNO2-3"))
                obj.Tel23 = dt.Rows[0]["SiiresakiTelNO2-3"].ToString();
            else
                obj.Tel23 = dt.Rows[0]["Tel23"].ToString();
            return obj;
        }

        private void btn_Siiresaki_Click(object sender, EventArgs e)
        {
            sobj.ShowDialog();
        }

        private void txtSiiresakiCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtSiiresakiCD.IsErrorOccurs)
                {
                    DataTable dt = txtSiiresakiCD.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                    {
                        sobj.Access_Siiresaki_obj = From_DB_To_Siiresaki(dt);
                    }
                }
            }
        }

        private void txtHacchuuNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtHacchuuNO.IsErrorOccurs)
                {
                    StaffEntity obj_staff = new StaffEntity();
                    obj_staff.OperatorCD = OperatorCD;
                    obj_staff.PC = PCID;
                    obj_staff.StaffName = txtHacchuuNO.Text;
                    if (cboMode.SelectedValue.ToString() == "2")//update
                    {
                        obj_bl.HacchuuNyuuryoku_Exclusive_Insert(obj_staff);
                        EnablePanel();
                    }
                    else if (cboMode.SelectedValue.ToString() == "3" || cboMode.SelectedValue.ToString() == "4")
                    {
                        if (cboMode.SelectedValue.ToString() == "3")
                        {
                            obj_bl.HacchuuNyuuryoku_Exclusive_Insert(obj_staff);
                        }
                        cf.DisablePanel(PanelTitle);
                    }
                }
                DataTable dt = txtHacchuuNO.IsDatatableOccurs;
                if (dt.Rows.Count > 0 && cboMode.SelectedValue.ToString() != "1")
                {
                    From_DB_To_Form(dt);
                }
            }
        }

        private void txtHacchuuDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtHacchuuDate.IsErrorOccurs)
                {
                    if (!string.IsNullOrWhiteSpace(txtSiiresakiCD.Text))
                    {
                        SiiresakiBL sbl = new SiiresakiBL();
                        DataTable dt = sbl.Siiresaki_Select_Check(txtSiiresakiCD.Text, txtHacchuuDate.Text, "E101");
                        DataTable dt1 = sbl.Siiresaki_Select_Check(txtSiiresakiCD.Text, txtHacchuuDate.Text, "E227");
                        DataTable dt2 = sbl.Siiresaki_Select_Check(txtSiiresakiCD.Text, txtHacchuuDate.Text, "E267");
                        if (dt.Rows[0]["MessageID"].ToString() == "E101" && dt.Rows.Count > 0)
                        {
                            base_bl.ShowMessage("E101");
                            return;
                        }
                        if (dt1.Rows[0]["MessageID"].ToString() == "E227" && dt1.Rows.Count > 0)
                        {
                            base_bl.ShowMessage("E227");
                            return;
                        }
                        if (dt2.Rows[0]["MessageID"].ToString() == "E267" && dt2.Rows.Count > 0)
                        {
                            base_bl.ShowMessage("E267");
                            return;
                        }
                        lblSiiresakiShort_Name.Text = dt.Rows[0]["SiiresakiRyakuName"].ToString();
                        sobj.Access_Siiresaki_obj = From_DB_To_Siiresaki(dt);
                    }
                    if (!string.IsNullOrEmpty(txtStaffCD.Text))
                    {
                        StaffBL sBL = new StaffBL();
                        DataTable dt = sBL.Staff_Select_Check(txtStaffCD.Text, txtHacchuuDate.Text, "E101");
                        DataTable dt1= sBL.Staff_Select_Check(txtStaffCD.Text, txtHacchuuDate.Text, "E135");
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

        private void btnNameF10_Click(object sender, EventArgs e)
        {
            F10_Gridview_Bind();
        }
        private void F10_Gridview_Bind()
        {
            
            HacchuuNyuuryokuEntity obj = new HacchuuNyuuryokuEntity();
            obj.BrandCD = txtBrandCD.Text;
            obj.ShouhinCD = txtShouhinCD.Text;
            obj.JANCD = txtJANCD.Text;
            obj.ShouhinName = txtShouhinName.Text;
            obj.YearTerm = txtYearTerm.Text;
            obj.SeasonSS = chk_SS.Checked ? "1" : "0";
            obj.SeasonFW = chk_FW.Checked ? "1" : "0";
            obj.SizeNO = txtSizeNo.Text;
            obj.ColorNO = txtColorNo.Text;

            if(string.IsNullOrEmpty(obj.BrandCD) && string.IsNullOrEmpty(obj.ShouhinCD) && string.IsNullOrEmpty(obj.JANCD) && string.IsNullOrEmpty(obj.ShouhinName) && string.IsNullOrEmpty(obj.YearTerm) && obj.SeasonSS=="0" && obj.SeasonFW=="0" && string.IsNullOrEmpty(obj.SizeNO) && string.IsNullOrEmpty(obj.ColorNO))
            {
                base_bl.ShowMessage("E111");
                txtBrandCD.Focus();
                return;
            }

            obj.ChangeDate = txtHacchuuDate.Text;
            DataTable dt = obj_bl.HacchuuNyuuryoku_Display(obj);
            if (dt.Rows.Count > 0)
            {
                gv_HacchuuNyuuryoku.DataSource = dt;
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
            //txtBrandCD.Focus();


            //for (int t = 0; t < gv_HacchuuNyuuryoku.RowCount; t++)
            //{
            //    bool bl = false;
            //    // grid 1 checking
            //    DataRow F8_drNew = F8_dt1.NewRow();// save updated data 
            //    DataGridViewRow row = gv_HacchuuNyuuryoku.Rows[t];// grid view data
            //    string shouhinCD = row.Cells["colShouhinCD"].Value.ToString();
            //    string chk_value = row.Cells["colFree"].Value.ToString();
            //    string senpouHacchuuNO = row.Cells["colSenpouHacchuuNO"].Value.ToString();
            //    string siiresakiCD = row.Cells["colSiiresakiCD"].Value.ToString();
            //    string soukoCD = row.Cells["colSoukoCD"].Value.ToString();

            //    DataRow[] select_dr1 = gv1_to_dt1.Select("ShouhinCD ='" + shouhinCD + "'");// original data
            //    DataRow existDr1 = F8_dt1.Select("ShouhinCD ='" + shouhinCD + "' and  DJMSenpouHacchuuNO='" + senpouHacchuuNO + "' and SiiresakiCD='" + siiresakiCD + "' and SoukoCD='" + soukoCD + "'").SingleOrDefault();

            //    F8_drNew[0] = shouhinCD;
            //    if (row.Cells["colJuchuuSuu"].Value.ToString() != "0")
            //    {
            //        for (int c = 1; c < gv_JuchuuNyuuryoku.Columns.Count; c++)
            //        {
            //            if (gv_JuchuuNyuuryoku.Columns[c].Name == "colFree" || gv_JuchuuNyuuryoku.Columns[c].Name == "colJuchuuSuu" || gv_JuchuuNyuuryoku.Columns[c].Name == "colSenpouHacchuuNO" || gv_JuchuuNyuuryoku.Columns[c].Name == "colSiiresakiCD" || gv_JuchuuNyuuryoku.Columns[c].Name == "colSoukoCD")
            //            {
            //                if (existDr1 != null)
            //                {
            //                    if (select_dr1[0][c].ToString() != row.Cells[c].Value.ToString())
            //                    {
            //                        bl = true;
            //                        F8_drNew[c] = row.Cells[c].Value;
            //                    }
            //                    else
            //                    {
            //                        F8_drNew[c] = existDr1[c];
            //                    }
            //                }
            //                else
            //                {
            //                    if (select_dr1[0][c].ToString() != row.Cells[c].Value.ToString())
            //                        bl = true;

            //                    F8_drNew[c] = row.Cells[c].Value;
            //                }
            //            }
            //            else
            //            {
            //                F8_drNew[c] = row.Cells[c].Value;
            //            }
            //        }
            //        // grid 1 insert(if exist, remove exist and insert)
            //        if (bl == true)
            //        {
            //            if (existDr1 != null)
            //                F8_dt1.Rows.Remove(existDr1);
            //            F8_dt1.Rows.Add(F8_drNew);
            //        }
            //    }
            //}


            //comment nwe mar win logic difference

            //for (int t = 0; t < gv_1.RowCount; t++)
            //{
            //    bool bl = false;
            //    // grid 1 checking
            //    DataRow F8_drNew = F8_dt1.NewRow();// save updated data 
            //    DataGridViewRow row = gv_1.Rows[t];// grid view data
            //    string id = row.Cells["colShouhinCD"].Value.ToString();

            //    DataRow[] select_dr1 = gv1_to_dt1.Select("ShouhinCD ='" + id+"'");// original data
            //    DataRow existDr1 = F8_dt1.Select("ShouhinCD ='" + id+"'").SingleOrDefault();

            //    F8_drNew[0] = id;
            //    for (int c = 1; c < gv_1.Columns.Count; c++)
            //    {
            //       if(gv_1.Columns[c].Name == "colFree" || gv_1.Columns[c].Name == "colJuchuuSuu" || gv_1.Columns[c].Name == "colSenpouHacchuuNO" || gv_1.Columns[c].Name == "colSiiresakiCD" || gv_1.Columns[c].Name == "colSoukoCD")
            //        {
            //            if (existDr1 != null)
            //            {
            //                if (select_dr1[0][c].ToString() != row.Cells[c].Value.ToString())
            //                {
            //                    bl = true;
            //                    F8_drNew[c] = row.Cells[c].Value;
            //                }
            //                else
            //                {
            //                    F8_drNew[c] = existDr1[c];
            //                }
            //            }
            //            else
            //            {
            //                if (select_dr1[0][c].ToString() != row.Cells[c].Value.ToString())
            //                    bl = true;

            //                F8_drNew[c] = row.Cells[c].Value;
            //            }
            //        }
            //       else
            //        {
            //            F8_drNew[c] = row.Cells[c].Value;
            //        } 
            //    }
            //    // grid 1 insert(if exist, remove exist and insert)
            //    if (bl == true)
            //    {
            //        if (existDr1 != null)
            //            F8_dt1.Rows.Remove(existDr1);
            //        F8_dt1.Rows.Add(F8_drNew);
            //    }
            //}
        }
    }
}
