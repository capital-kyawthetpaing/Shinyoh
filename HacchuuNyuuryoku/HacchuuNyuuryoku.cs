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
            //sobj = new SiiresakiDetail();
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

            txtSiiresakiCD.lblName = lblSiiresakiShort_Name;
            txtStaffCD.lblName = lblStaff_Name;
            txtBrandCD.lblName = lblBrand_Name;

            txtSiiresakiCD.ChangeDate = txtHacchuuDate;
            txtStaffCD.ChangeDate = txtHacchuuDate;
            txtShouhinCD.ChangeDate = txtHacchuuDate;

            base_Entity = _GetBaseData();
            

            txtHacchuuNO.ChangeDate = txtHacchuuDate;
            txtCopy.ChangeDate = txtHacchuuDate;
           
            gv_HacchuuNyuuryoku.SetGridDesign();
            gv_HacchuuNyuuryoku.SetReadOnlyColumn("ColHinbanCD,colShouhinName,colColorRyakuName,colColorNO,colSizeNO,colHacchuuTanka,colJANCD,colSoukoName");
            gv_HacchuuNyuuryoku.SetHiraganaColumn("colHacchuuMeisaiTekiyou");
            gv_HacchuuNyuuryoku.SetNumberColumn("colHacchuuSuu");
            gv_HacchuuNyuuryoku.ClearSelection();
            ChangeMode(Mode.New);
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
                    sobj = new SiiresakiDetail();
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
                    sobj = new SiiresakiDetail();
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
                    sobj = new SiiresakiDetail(false);

                    break;
                case Mode.Inquiry:
                    txtHacchuuNO.E102Check(true);
                    txtCopy.E102Check(false);

                    txtHacchuuNO.E133Check(true, "HacchuuNyuuryoku", txtHacchuuNO, null, null);
                    txtHacchuuNO.E266Check(false, "HacchuuNyuuryoku", txtHacchuuNO);
                    txtHacchuuNO.E265Check(false, "HacchuuNyuuryoku", txtHacchuuNO);

                    Disable_UDI_Mode();
                    Control btn12 = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btn12.Visible = false;
                    Control btn10 = this.TopLevelControl.Controls.Find("BtnF10", true)[0];
                    btn10.Visible = false;
                    Control btn11 = this.TopLevelControl.Controls.Find("BtnF11", true)[0];
                    btn11.Visible = false;
                    sobj = new SiiresakiDetail(false);
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

            gv_HacchuuNyuuryoku.Memory_Row_Count = 0;

            if (cboMode.SelectedValue.ToString() == "1")
            {
                cboMode.NextControlName = txtCopy.Name;
                txtHacchuuNO.Enabled = false;
                txtCopy.Focus();
            }
            else
            {
                cboMode.NextControlName = txtHacchuuNO.Name;
                txtHacchuuNO.Focus();
            }
            sobj = new SiiresakiDetail();
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
                F8_Gridview_Bind();
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
                // gv_HacchuuNyuuryoku.ClearSelection();
                //gv_HacchuuNyuuryoku.Columns["colChakuniYoteiDate"].DefaultCellStyle.Format = "yyyy/MM/dd";

                DataTable dt_temp = dt.Copy();
                gv1_to_dt1 = dt_temp;

                if (F8_dt1.Rows.Count == 0)
                    F8_dt1 = gv1_to_dt1.Clone();

                if (cboMode.SelectedValue.ToString() == "3" || cboMode.SelectedValue.ToString() == "2")
                {
                    F8_dt1 = gv1_to_dt1.Copy();
                    gv_HacchuuNyuuryoku.Memory_Row_Count = F8_dt1.Rows.Count;
                }
                if (!string.IsNullOrEmpty(txtCopy.Text))
                {
                    F8_dt1 = gv1_to_dt1.Copy();
                    F8_dt1.Rows.OfType<DataRow>().ToList().ForEach(r =>
                    {
                        r["HacchuuGyouNO"] = DBNull.Value;
                    });
                    gv_HacchuuNyuuryoku.Memory_Row_Count = F8_dt1.Rows.Count;
                }
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
                        btn_Siiresaki.Enabled = true;
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
            gv_HacchuuNyuuryoku.ActionType = "F10";             //to skip gv error check at the ErrorCheck() of BaseForm.cs
            if (ErrorCheck(PanelDetail))
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

                if (string.IsNullOrEmpty(obj.BrandCD) && string.IsNullOrEmpty(obj.ShouhinCD) && string.IsNullOrEmpty(obj.JANCD) && string.IsNullOrEmpty(obj.ShouhinName) && string.IsNullOrEmpty(obj.YearTerm) && obj.SeasonSS == "0" && obj.SeasonFW == "0" && string.IsNullOrEmpty(obj.SizeNO) && string.IsNullOrEmpty(obj.ColorNO))
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
                    gv_HacchuuNyuuryoku.Focus();
                    DataTable dt_temp = dt.Copy();
                    gv1_to_dt1 = dt_temp;

                    if (F8_dt1.Rows.Count == 0)
                        F8_dt1 = gv1_to_dt1.Clone();
                    gv_HacchuuNyuuryoku.Select();

                    gv_HacchuuNyuuryoku.CurrentCell = gv_HacchuuNyuuryoku.Rows[0].Cells[5];//set focus to chakuniyotei date (ktp)
                }
                else
                {
                    F8_dt1.Rows.Clear();
                    gv_HacchuuNyuuryoku.DataSource = F8_dt1;
                    Focus_Clear();
                }
            }
            gv_HacchuuNyuuryoku.ActionType = string.Empty;             //to check gv error at the ErrorCheck() of BaseForm.cs
        }

        private void btnNameF11_Click(object sender, EventArgs e)
        {
            Function_F11();
        }

        private void Function_F11()
        {
            if (F11_Gridivew_ErrorCheck())
                return;
            else
                F11_Gridview_Bind();
        }

        private bool F11_Gridivew_ErrorCheck()
        {
            bool bl_error = false;

            foreach (DataGridViewRow gv in gv_HacchuuNyuuryoku.Rows)
            {
                if (gv.Cells["colHacchuuSuu"].Value.ToString() != "0")
                {
                    for (int i = 0; i < gv.Cells.Count; i++)
                    {
                        string colName = gv_HacchuuNyuuryoku.Columns[i].Name;
                        if (colName == "colChakuniYoteiDate" || colName == "colSoukoCD" || colName == "colHacchuuMeisaiTekiyou")
                        {
                            if (ErrorCheck_CellEndEdit(gv.Index, i))
                            {
                                gv_HacchuuNyuuryoku.Focus();
                                gv_HacchuuNyuuryoku.CurrentCell = gv_HacchuuNyuuryoku.Rows[gv.Index].Cells[i];
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

        private bool ErrorCheck_CellEndEdit(int row, int col)
        {
            string HacchuuSuu = gv_HacchuuNyuuryoku.Rows[row].Cells["colHacchuuSuu"].Value.ToString();            
            bool bl_error = false;
            string col_Name = gv_HacchuuNyuuryoku.Columns[col].Name;

            if (col_Name == "colHacchuuSuu")
            {
                string split_val = gv_HacchuuNyuuryoku.Rows[row].Cells["colHacchuuSuu"].EditedFormattedValue.ToString().Replace(",", "");
                int HacchuuSuu_Number = string.IsNullOrEmpty(gv_HacchuuNyuuryoku.Rows[row].Cells["colHacchuuSuu"].EditedFormattedValue.ToString()) ? 0 : Convert.ToInt32(split_val);
                gv_HacchuuNyuuryoku.Rows[row].Cells["colHacchuuSuu"].Value = HacchuuSuu_Number.ToString();
            }
            if (col_Name == "colHacchuuMeisaiTekiyou")
            {
                int MaxLength = ((DataGridViewTextBoxColumn)gv_HacchuuNyuuryoku.Columns[col_Name]).MaxInputLength;

                string byte_text = gv_HacchuuNyuuryoku.Rows[row].Cells[col_Name].EditedFormattedValue.ToString();
                if (cf.IsByteLengthOver(MaxLength, byte_text))
                {
                    MessageBox.Show("入力された文字が長すぎます", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bl_error = true;
                }
            }
            if (col_Name == "colChakuniYoteiDate")
            {
                DateTime JuchuuDate = string.IsNullOrEmpty(txtHacchuuDate.Text) ? Convert.ToDateTime(base_Entity.LoginDate) : Convert.ToDateTime(txtHacchuuDate.Text);

                string expectedDate = gv_HacchuuNyuuryoku.Rows[row].Cells["colChakuniYoteiDate"].EditedFormattedValue.ToString().Trim();
                if (HacchuuSuu != "0")
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
                        gv_HacchuuNyuuryoku.Rows[row].Cells["colChakuniYoteiDate"].Value = txt.Text;
                        expectedDate = string.IsNullOrEmpty(txt.Text) ? base_Entity.LoginDate : txt.Text;
                        if (Convert.ToDateTime(expectedDate) < JuchuuDate)
                        {
                            base_bl.ShowMessage("E267", "発注日");
                            bl_error = true;
                        }
                    }
                }
            }
            if (col_Name == "colSoukoCD")
            {
                DataTable souko_dt = new DataTable();
                string soukoCD = gv_HacchuuNyuuryoku.Rows[row].Cells["colSoukoCD"].EditedFormattedValue.ToString().Trim();
                if (HacchuuSuu != "0")
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
                    gv_HacchuuNyuuryoku.Rows[row].Cells["colSoukoCD"].Value = souko_dt.Rows[0]["SoukoCD"];
                    gv_HacchuuNyuuryoku.Rows[row].Cells["colSoukoName"].Value = souko_dt.Rows[0]["SoukoName"];
                }
            }
            return bl_error;
        }

        private (bool, DataTable) Gridview_Error_Check(string errorType, string CD, string type)
        {
            bool return_error = false;
            DataTable dt = new DataTable();
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

        private void gv_HacchuuNyuuryoku_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (gv_HacchuuNyuuryoku.IsLastKeyEnter)
            {
                if (ErrorCheck_CellEndEdit(e.RowIndex, e.ColumnIndex))
                    gv_HacchuuNyuuryoku.CurrentCell = gv_HacchuuNyuuryoku.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void F11_Gridview_Bind()
        {
            for (int t = 0; t < gv_HacchuuNyuuryoku.RowCount; t++)
            {
                //bool bl = false;
                // grid 1 checking
                DataRow F8_drNew = F8_dt1.NewRow();// save updated data 
                DataGridViewRow row = gv_HacchuuNyuuryoku.Rows[t];// grid view data
                
                string ChakuniYoteiDate = row.Cells["colChakuniYoteiDate"].EditedFormattedValue.ToString();
                string soukoCD = row.Cells["colSoukoCD"].EditedFormattedValue.ToString();

                string shouhinCD = row.Cells["ColShouhinCD"].Value.ToString();
                string color =row.Cells["colColorNO"].Value.ToString();
                string size =row.Cells["colSizeNO"].Value.ToString();

                DataRow[] select_dr1 = null;
                string NULL_Check = string.Empty;
                if (string.IsNullOrEmpty(color))
                    NULL_Check = "and [ColorNO] IS NULL ";
                if (string.IsNullOrEmpty(size))
                    NULL_Check += " and [SizeNO] IS NULL ";
                if (!string.IsNullOrEmpty(NULL_Check))
                    select_dr1 = gv1_to_dt1.Select("ShouhinCD ='" + shouhinCD + "'" + NULL_Check + "");// original data
                else
                    select_dr1 = gv1_to_dt1.Select("ShouhinCD ='" + shouhinCD + "' and ColorNO='" + color + "' and SizeNO='" + size + "'");// original data

                DataRow existDr1 = F8_dt1.Select("ShouhinCD ='" + shouhinCD + "' and  ChakuniYoteiDate='" + ChakuniYoteiDate + "' and SoukoCD='" + soukoCD + "'").SingleOrDefault();
                if (existDr1 != null)
                {
                    if (row.Cells["colHacchuuSuu"].Value.ToString() == "0")
                    {
                        F8_dt1.Rows.Remove(existDr1);
                        existDr1 = null;
                    }
                }
                F8_drNew[0] = row.Cells["colHinbanCD"].Value.ToString();
                //if (row.Cells["colHacchuuSuu"].Value.ToString() != "0" && row.Cells[7].Value.ToString() != select_dr1[0][7].ToString())
                if (row.Cells["colHacchuuSuu"].Value.ToString() != "0")
                {
                    for (int c = 1; c < gv_HacchuuNyuuryoku.Columns.Count; c++)
                    {
                        if (gv_HacchuuNyuuryoku.Columns[c].Name == "colHacchuuSuu" || gv_HacchuuNyuuryoku.Columns[c].Name == "colChakuniYoteiDate"  || gv_HacchuuNyuuryoku.Columns[c].Name == "colSoukoCD")
                        {
                            if (existDr1 != null)
                            {
                                if (select_dr1[0][c].ToString() != row.Cells[c].Value.ToString())
                                {
                                    //bl = true;
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
                            if (c == 14 && string.IsNullOrEmpty(row.Cells["colHacchuuGyouNO"].Value.ToString()))
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
                    //}
                }
            }
            gv_HacchuuNyuuryoku.Memory_Row_Count = F8_dt1.Rows.Count;
            Focus_Clear();
            #region
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
            #endregion
        }

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
            txtColorNo.Text = string.Empty; ;
            txtSizeNo.Text = string.Empty;
        }

        private void btnNameF8_Click(object sender, EventArgs e)
        {
            F8_Gridview_Bind();
        }

        private void F8_Gridview_Bind()
        {
            if (F8_dt1.Rows.Count > 0)
            {
                F8_dt1.DefaultView.Sort = "ShouhinCD";
                gv_HacchuuNyuuryoku.Focus();
                gv_HacchuuNyuuryoku.DataSource = F8_dt1.DefaultView.ToTable();
            }
            else
            {
                DataTable dtSource = (DataTable)gv_HacchuuNyuuryoku.DataSource;
                if (dtSource != null)
                    dtSource.Rows.Clear();
            }
        }

        private void DBProcess()
        {
            string mode = string.Empty;
            (string, string) obj = GetInsert();
            if ((!string.IsNullOrEmpty(obj.Item1)) && (!string.IsNullOrEmpty(obj.Item2)))
            {
                if (cboMode.SelectedValue.Equals("1"))
                {
                    mode = "New";
                    DoInsert(mode, obj.Item1, obj.Item2);
                }
                else if (cboMode.SelectedValue.Equals("2"))
                {
                    mode = "Update";
                    DoUpdate(mode, obj.Item1, obj.Item2);
                }
                else if (cboMode.SelectedValue.Equals("3"))
                {
                    mode = "Delete";
                    DoDelete(mode, obj.Item1, obj.Item2);
                }
            }
        }

        private (string, string) GetInsert()
        {
            SiiresakiEntity si_obj = sobj.Access_Siiresaki_obj;

            DataTable dt = new DataTable();
            Create_Datatable_Column(dt);
            DataRow dr = dt.NewRow();
            dr["HacchuuNO"] = txtHacchuuNO.Text;
            dr["HacchuuDate"] = txtHacchuuDate.Text;
            dr["StaffCD"] = txtStaffCD.Text;
            dr["HacchuuDenpyouTekiyou"] = txtHacchuuDenpyouTekiyou.Text;

            dr["SiiresakiCD"] = si_obj.SiiresakiCD;
            dr["SiiresakiName"] = si_obj.SiiresakiName;
            dr["SiiresakiRyakuName"] = si_obj.SiiresakiRyakuName;
            dr["SiiresakiYuubinNO1"] = si_obj.YuubinNO1;
            dr["SiiresakiYuubinNO2"] = si_obj.YuubinNO2;
            dr["SiiresakiJuusho1"] = si_obj.Juusho1;
            dr["SiiresakiJuusho2"] = si_obj.Juusho2;
            dr["SiiresakiTel11"] = si_obj.Tel11;
            dr["SiiresakiTel12"] = si_obj.Tel12;
            dr["SiiresakiTel13"] = si_obj.Tel13;
            dr["SiiresakiTel21"] = si_obj.Tel21;
            dr["SiiresakiTel22"] = si_obj.Tel22;
            dr["SiiresakiTel23"] = si_obj.Tel23;
            
            dr["InsertOperator"] = base_Entity.OperatorCD;
            dr["UpdateOperator"] = base_Entity.OperatorCD;
            dr["PC"] = base_Entity.PC;
            dr["ProgramID"] = base_Entity.ProgramID;
            dt.Rows.Add(dr);
            
            JuchuuNyuuryokuBL obj_bl = new JuchuuNyuuryokuBL();            
            if (cboMode.SelectedValue.ToString() == "1")
            {
                DataTable hacchuu_dt = obj_bl.GetJuchuuNO("2", txtHacchuuNO.Text, "0");
                dt.Rows[0]["HacchuuNO"] = hacchuu_dt.Rows[0]["Column1"];
                for (int i = 0; i < F8_dt1.Rows.Count; i++)
                {
                    F8_dt1.Rows[i]["HacchuuNO"] = dt.Rows[0]["HacchuuNO"];
                    F8_dt1.Rows[i]["HacchuuGyouNO"] = i + 1;
                }
            }
            DataTable save_dt = F8_dt1.AsEnumerable()
                    .GroupBy(r => new { Col1 = r["HacchuuNO"], Col2 = r["HacchuuGyouNO"] })
                    .Select(g => g.OrderBy(r => r["HacchuuNO"]).Last()).CopyToDataTable();

            string header_XML = cf.DataTableToXml(dt);
            string detail_XML = cf.DataTableToXml(save_dt);
            return (header_XML, detail_XML);
        }

        public void Create_Datatable_Column(DataTable create_dt)
        {
            create_dt.Columns.Add("HacchuuNO");
            create_dt.Columns.Add("HacchuuDate");
            create_dt.Columns.Add("StaffCD");
            create_dt.Columns.Add("HacchuuDenpyouTekiyou");

            create_dt.Columns.Add("SiiresakiCD");
            create_dt.Columns.Add("SiiresakiName");
            create_dt.Columns.Add("SiiresakiRyakuName");
            create_dt.Columns.Add("SiiresakiYuubinNO1");
            create_dt.Columns.Add("SiiresakiYuubinNO2");
            create_dt.Columns.Add("SiiresakiJuusho1");
            create_dt.Columns.Add("SiiresakiJuusho2");
            create_dt.Columns.Add("SiiresakiTel11");
            create_dt.Columns.Add("SiiresakiTel12");
            create_dt.Columns.Add("SiiresakiTel13");
            create_dt.Columns.Add("SiiresakiTel21");
            create_dt.Columns.Add("SiiresakiTel22");
            create_dt.Columns.Add("SiiresakiTel23");
            create_dt.Columns.Add("InsertOperator");
            create_dt.Columns.Add("UpdateOperator");
            create_dt.Columns.Add("PC");
            create_dt.Columns.Add("ProgramID");
        }

        private void DoInsert(string mode, string str_header, string str_detail)
        {
            HacchuuListBL objMethod = new HacchuuListBL();
            string return_BL = objMethod.HacchuuNyuuryoku_CUD(mode, str_header, str_detail);
            if (return_BL == "true")
                base_bl.ShowMessage("I101");
        }

        private void DoUpdate(string mode, string str_header, string str_detail)
        {
            HacchuuListBL objMethod = new HacchuuListBL();
            string return_BL = objMethod.HacchuuNyuuryoku_CUD(mode, str_header, str_detail);
            if (return_BL == "true")
                base_bl.ShowMessage("I101");
        }

        private void DoDelete(string mode, string str_header, string str_detail)
        {
            HacchuuListBL objMethod = new HacchuuListBL();
            string return_BL = objMethod.HacchuuNyuuryoku_CUD(mode, str_header, str_detail);
            if (return_BL == "true")
                base_bl.ShowMessage("I102");
        }

        private void txtBrandCD_KeyDown(object sender, KeyEventArgs e)
        {
            multipurposeBL bl = new multipurposeBL();
            DataTable dt = bl.M_Multiporpose_SelectData(txtBrandCD.Text, 1, string.Empty, string.Empty);
            if (dt.Rows.Count > 0)
                lblBrand_Name.Text = dt.Rows[0]["Char1"].ToString();
            else lblBrand_Name.Text = string.Empty;
        }

        private void gv_HacchuuNyuuryoku_KeyDown(object sender, KeyEventArgs e)
        {
            SCombo cbo = new SCombo();

            if (this.TopLevelControl.Controls.Find("cboMode", true).Count() > 0)
                cbo = this.TopLevelControl.Controls.Find("cboMode", true)[0] as SCombo;
            if (e.KeyCode == Keys.F9 && (cbo.SelectedValue.Equals("1") || cbo.SelectedValue.Equals("2")))
            {
                if (gv_HacchuuNyuuryoku.CurrentCell != null)
                {
                    if (gv_HacchuuNyuuryoku.CurrentCell.ColumnIndex == 11)//ssa
                    {
                        gridKeyDown();
                    }
                }
            }
        }
        private void gridKeyDown()
        {
            gv_HacchuuNyuuryoku.CellEndEdit -= new DataGridViewCellEventHandler(gv_HacchuuNyuuryoku_CellEndEdit);
            gv_HacchuuNyuuryoku.EndEdit();
            gv_HacchuuNyuuryoku.CellEndEdit += new DataGridViewCellEventHandler(gv_HacchuuNyuuryoku_CellEndEdit);

            int row = gv_HacchuuNyuuryoku.CurrentCell.RowIndex;
            int column = gv_HacchuuNyuuryoku.CurrentCell.ColumnIndex;
            if (gv_HacchuuNyuuryoku.CurrentCell.OwningColumn.Name == "colSoukoCD")
            {
                SoukoSearch souko = new SoukoSearch();
                souko.ShowDialog();

                if (!string.IsNullOrEmpty(souko.soukoCD))
                {
                    if (gv_HacchuuNyuuryoku.Rows.Count > 1)
                        gv_HacchuuNyuuryoku.CurrentCell = this.gv_HacchuuNyuuryoku[6, row + 1];
                    else
                        gv_HacchuuNyuuryoku.CurrentCell = this.gv_HacchuuNyuuryoku[column, row];
                    this.gv_HacchuuNyuuryoku.CurrentCell.Selected = true;

                    gv_HacchuuNyuuryoku[column, row].Value = souko.soukoCD.ToString();
                    gv_HacchuuNyuuryoku[column + 1, row].Value = souko.soukoName.ToString();
                }
                else
                {
                    gv_HacchuuNyuuryoku.CurrentCell = this.gv_HacchuuNyuuryoku[column, row];
                    this.gv_HacchuuNyuuryoku.CurrentCell.Selected = true;
                }
            }
        }

        private void gv_HacchuuNyuuryoku_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                (e.Control as DataGridViewTextBoxEditingControl).KeyDown -= new KeyEventHandler(gv_HacchuuNyuuryoku_KeyDown);
                (e.Control as DataGridViewTextBoxEditingControl).KeyDown += new KeyEventHandler(gv_HacchuuNyuuryoku_KeyDown);

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
            if (gv_HacchuuNyuuryoku.CurrentCell != null)
            {
                if (gv_HacchuuNyuuryoku.CurrentCell.ColumnIndex == 11)//ssa
                {
                    gridKeyDown();
                }
            }
        }
    }
}
