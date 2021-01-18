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

namespace IdouNyuuryoku
{
    public partial class IdouNyuuryoku : BaseForm
    {
        CommonFunction cf;
        multipurposeEntity multi_Entity;
        BaseEntity base_Entity;
        BaseBL base_bl;
        IdouNyuuryokuBL Idou_BL;

        DataTable gv1_to_dt1;
        DataTable F8_dt1;

        bool bl_rowEnter = true;
        public IdouNyuuryoku()
        {
            InitializeComponent();
            cf = new CommonFunction();
            multi_Entity = new multipurposeEntity();
            base_Entity = new BaseEntity();
            base_bl = new BaseBL();
            Idou_BL = new IdouNyuuryokuBL();
            gv1_to_dt1 = new DataTable();
            F8_dt1 = new DataTable();
        }

        private void IdouNyuuryoku_Load(object sender, EventArgs e)
        {
            ProgramID = "IdouNyuuryoku";
            StartProgram();
            cboMode.Bind(false, multi_Entity);

            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "新規(F2)", true);
            SetButton(ButtonType.BType.Update, F3, "変更(F3)", true);
            SetButton(ButtonType.BType.Delete, F4, "削除(F4)", true);
            SetButton(ButtonType.BType.Inquiry, F5, "照会(F5)", true);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            SetButton(ButtonType.BType.Confirm, F8, "確認(F8)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", true);
            SetButton(ButtonType.BType.Display, F10, "表示(F10)", true);
            SetButton(ButtonType.BType.Memory, F11, "保存(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);

            base_Entity = _GetBaseData();
            ChangeMode(Mode.New);

            txtIdoukubun.lblName = lbl_IdouKubun;
            txtStaffCD.lblName = lblStaff_Name;
            txtShukkosouko.lblName = lbl_Shukko;
            txtNyukosouko.lblName = lbl_Nyuko;

            txtIdouNO.ChangeDate = txtIdouDate;
            txtCopy.ChangeDate = txtIdouDate;
            txtStaffCD.ChangeDate = txtIdouDate;

            gv_1.SetGridDesign();
            gv_1.SetReadOnlyColumn("colShouhinCD,colShouhinName,colColorRyakuName,colColorNO,colSizeNO");

            gv_1.SetHiraganaColumn("colIdouMeisaiTekiyou");
            gv_1.SetNumberColumn("colIdouSuu,colGenkaTanka,colGenkaKingaku");
        }
        private void ChangeMode(Mode mode)
        {
            Mode_Setting();
            switch (mode)
            {
                case Mode.New:
                    ErrorCheck();
                    txtIdouNO.E102Check(false);
                    txtIdouNO.E133Check(false, "IdouNyuuryoku", txtIdouNO, null, null);
                    

                    txtCopy.E102Check(true);
                    txtCopy.E133Check(true, "IdouNyuuryoku", txtCopy, null, null);

                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    break;

                case Mode.Update:
                    ErrorCheck();
                    txtIdouNO.E102Check(true);
                    txtCopy.E102Check(false);

                    txtIdouNO.E133Check(true, "IdouNyuuryoku", txtIdouNO, null, null);
                    

                    Disable_UDI_Mode();
                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    ErrorCheck();
                    txtIdouNO.E102Check(true);
                    txtCopy.E102Check(false);

                    txtIdouNO.E133Check(true, "IdouNyuuryoku", txtIdouNO, null, null);

                    Disable_UDI_Mode();
                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;

                    break;
                case Mode.Inquiry:
                    txtIdouNO.E102Check(false);
                    txtCopy.E102Check(false);
                    txtIdouNO.E133Check(true, "IdouNyuuryoku", txtIdouNO, null, null);

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

            lbl_IdouKubun.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblStaff_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lbl_Nyuko.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lbl_Shukko.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblBrand_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;


            lbl_IdouKubun.Text = string.Empty;
            lblStaff_Name.Text = string.Empty;
            lbl_Nyuko.Text = string.Empty;
            lbl_Shukko.Text = string.Empty;
            lblBrand_Name.Text = string.Empty;

            gv1_to_dt1 = new DataTable();
            F8_dt1 = new DataTable();

            txtIdouNO.Focus();
            txtIdouDate.Text = base_Entity.LoginDate;
            txtStaffCD.Text = base_Entity.OperatorCD;
            lblStaff_Name.Text = base_Entity.SPName;

            Load_Setting();
            
        }
        private void Load_Setting()
        {
            DataTable dt_Multi = Idou_BL.IdouNyuuryoku_Select_Check(string.Empty, string.Empty, "Load_Multi");
            if (dt_Multi.Rows.Count > 0)
            {
                txtIdoukubun.Text = dt_Multi.Rows[0]["Key"].ToString();
                lbl_IdouKubun.Text = dt_Multi.Rows[0]["Char1"].ToString();
            }
            DataTable dt_Souko = Idou_BL.IdouNyuuryoku_Select_Check(string.Empty, string.Empty, "Load_Souko");
            if (dt_Souko.Rows.Count > 0)
            {
                txtNyukosouko.Text = dt_Souko.Rows[0]["SoukoCD"].ToString();
                lbl_Nyuko.Text = dt_Souko.Rows[0]["SoukoName"].ToString();
            }
        }
        private void Disable_UDI_Mode()
        {
            txtCopy.Enabled = false;
        }
        private void ErrorCheck()
        {

            txtIdouDate.E102Check(true);
            txtIdouDate.E103Check(true);

            txtIdouDate.E115Check(true, "IdouNyuuryoku", txtIdouDate);
            txtIdoukubun.E102Check(true);
            txtIdoukubun.E101Check(true, "M_MultiPorpose", txtIdoukubun, null, null);

            txtStaffCD.E102Check(true);
            txtStaffCD.E101Check(true, "M_Staff", txtStaffCD, txtIdouDate, null);
            txtStaffCD.E135Check(true, "M_Staff", txtStaffCD, txtIdouDate);


            txtShukkosouko.E102Check(true);
            txtShukkosouko.E101Check(true, "souko", txtShukkosouko, null, null);

            txtNyukosouko.E102Check(true);
            txtNyukosouko.E101Check(true, "souko", txtNyukosouko, null, null);
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
                F11_Gridview_Bind();
            }
            if (tagID == "12")
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
            base.FunctionProcess(tagID);
        }

        private void txtIdoukubun_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtIdoukubun.IsErrorOccurs)
                {
                    DataTable dt = txtIdoukubun.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                    {
                        lbl_IdouKubun.Text = dt.Rows[0]["Char1"].ToString();
                        Souko_Disable_Enable(txtIdoukubun.Text);
                    }
                }
                else
                {
                    lbl_IdouKubun.Text = string.Empty;
                }
            }
        }

        private void Souko_Disable_Enable(string txt_val)
        {
            if (txt_val == "1")
            {
                txtShukkosouko.Enabled = false;
                txtNyukosouko.Enabled = true;
                txtStaffCD.NextControlName = txtNyukosouko.Name;
            }
            else if (txt_val == "2")
            {
                txtShukkosouko.Enabled = true;
                txtNyukosouko.Enabled = false;
                txtStaffCD.NextControlName = txtShukkosouko.Name;
                txtShukkosouko.NextControlName = txtDenpyouTekiyou.Name;
            }
            else if (txt_val == "3")
            {
                txtShukkosouko.Enabled = true;
                txtNyukosouko.Enabled = true;
                txtStaffCD.NextControlName = txtShukkosouko.Name;
                txtShukkosouko.NextControlName = txtNyukosouko.Name;
            }
        }

        private void txtBrandCD_KeyDown(object sender, KeyEventArgs e)
        {
            multipurposeBL bl = new multipurposeBL();
            DataTable dt = bl.M_Multiporpose_SelectData(txtBrandCD.Text, 1, string.Empty, string.Empty);
            if (dt.Rows.Count > 0)
                lblBrand_Name.Text = dt.Rows[0]["Char1"].ToString();
        }

        private void txtIdouNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtIdouNO.IsErrorOccurs)
                {
                    StaffEntity obj_staff = new StaffEntity();
                    obj_staff.OperatorCD = OperatorCD;
                    obj_staff.PC = PCID;
                    obj_staff.StaffName = txtIdouNO.Text;
                    if (cboMode.SelectedValue.ToString() == "2")//update
                    {
                        Idou_BL.IdouNyuuryoku_Exclusive_Insert(obj_staff);
                        EnablePanel();
                    }
                    else if (cboMode.SelectedValue.ToString() == "3" || cboMode.SelectedValue.ToString() == "4")
                    {
                        if (cboMode.SelectedValue.ToString() == "3")
                            Idou_BL.IdouNyuuryoku_Exclusive_Insert(obj_staff);
                        cf.DisablePanel(PanelTitle);
                    }
                }
                DataTable dt = txtIdouNO.IsDatatableOccurs;
                if (dt.Rows.Count > 0 && cboMode.SelectedValue.ToString() != "1")
                {
                    From_DB_To_Form(dt);
                }
            }
        }

        private void EnablePanel()
        {
            cf.EnablePanel(PanelDetail);
            txtIdouDate.Focus();
            cf.DisablePanel(PanelTitle);
        }

        private void From_DB_To_Form(DataTable dt)
        {
            if (dt.Rows[0]["MessageID"].ToString() == "E132")
            {
                txtIdouDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["IdouDate"]);
                txtIdoukubun.Text = dt.Rows[0]["IdouKBN"].ToString();
                lbl_IdouKubun.Text = dt.Rows[0]["Char1"].ToString();
                txtStaffCD.Text = dt.Rows[0]["StaffCD"].ToString();
                lblStaff_Name.Text = dt.Rows[0]["StaffName"].ToString();
                txtShukkosouko.Text = dt.Rows[0]["ShukkoSoukoCD"].ToString();
                lbl_Shukko.Text = dt.Rows[0]["ShukkoSoukoName"].ToString();
                txtNyukosouko.Text = dt.Rows[0]["NyuukoSoukoCD"].ToString();
                lbl_Nyuko.Text = dt.Rows[0]["NyuukoSoukoName"].ToString();
                txtDenpyouTekiyou.Text = dt.Rows[0]["IdouDenpyouTekiyou"].ToString();

                dt.Columns.Remove("IdouDate");
                dt.Columns.Remove("IdouKBN");
                dt.Columns.Remove("Char1");
                dt.Columns.Remove("StaffCD");
                dt.Columns.Remove("StaffName");
                dt.Columns.Remove("ShukkoSoukoCD");
                dt.Columns.Remove("ShukkoSoukoName");
                dt.Columns.Remove("NyuukoSoukoCD");
                dt.Columns.Remove("NyuukoSoukoName");
                dt.Columns.Remove("IdouDenpyouTekiyou");
                dt.Columns.Remove("MessageID");

                gv_1.DataSource = dt;
                gv_1.ClearSelection();

                DataTable dt_temp = dt.Copy();
                gv1_to_dt1 = dt_temp;

                if (cboMode.SelectedValue.ToString() == "1")
                {
                    F8_dt1 = gv1_to_dt1.Clone();
                    Souko_Disable_Enable(txtIdoukubun.Text);
                }
                else if(cboMode.SelectedValue.ToString() == "2")
                {
                    F8_dt1 = gv1_to_dt1.Copy();
                    Souko_Disable_Enable(txtIdoukubun.Text);
                }
                else
                    F8_dt1 = gv1_to_dt1.Copy();
            }
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

        private void txtIdouDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtIdouDate.IsErrorOccurs)
                {
                    if (!string.IsNullOrEmpty(txtStaffCD.Text))
                    {
                        StaffBL sBL = new StaffBL();
                        DataTable sf_DT = sBL.Staff_Select_Check(txtStaffCD.Text, txtIdouDate.Text, "E101");
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

        private void gv_1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string KanriNO = gv_1.Rows[e.RowIndex].Cells["colKanriNO"].Value.ToString();
            string soukoCD = txtShukkosouko.Text;
            string ShouhinCD = gv_1.Rows[e.RowIndex].Cells["colShouhinCD"].Value.ToString();
            
            if (gv_1.Columns[e.ColumnIndex].Name == "colKanriNO")
            {
                if (string.IsNullOrEmpty(KanriNO))
                {
                    base_bl.ShowMessage("E102");
                    gv_1.CurrentCell = gv_1.Rows[e.RowIndex].Cells["colKanriNO"];
                }
                else
                {
                    gv_1.MoveNextCell();
                }
            }
            if (gv_1.Columns[e.ColumnIndex].Name == "colIdouSuu")
            {
                bool bl_check = false;
                string split_val = gv_1.Rows[e.RowIndex].Cells["colIdouSuu"].EditedFormattedValue.ToString().Replace(",", "");
                int IdouSuu = string.IsNullOrEmpty(gv_1.Rows[e.RowIndex].Cells["colIdouSuu"].EditedFormattedValue.ToString())? 0 : Convert.ToInt32(split_val);
                if (IdouSuu == 0)
                {
                    gv_1.Rows[e.RowIndex].Cells["colIdouSuu"].Value = "0";
                }
                else if(IdouSuu < 0)
                {
                    base_bl.ShowMessage("E109");
                    bl_check = true;
                }
                if(!bl_check)
                {
                    DataTable dt = Idou_BL.IdouNyuuryoku_Select_Check(ShouhinCD, soukoCD, "Sum_Com", KanriNO);
                    if (dt.Rows.Count > 0)
                    {
                        if (IdouSuu > Convert.ToInt32(dt.Rows[0]["GenZaikoSuu"]))
                        {
                            base_bl.ShowMessage("Q325", IdouSuu.ToString(), dt.Rows[0]["GenZaikoSuu"].ToString());
                            bl_check = true;
                        }
                    }
                    gv_1.Rows[e.RowIndex].Cells["colGenkaKingaku"].Value = Convert.ToInt32(gv_1.Rows[e.RowIndex].Cells["colGenkaTanka"].Value) * Convert.ToInt32(gv_1.Rows[e.RowIndex].Cells["colIdouSuu"].Value);
                }
                if(!bl_check)
                {
                    gv_1.MoveNextCell();
                }
                else
                {
                    gv_1.CurrentCell = gv_1.Rows[e.RowIndex].Cells["colIdouSuu"];
                }  
            }
            if (gv_1.Columns[e.ColumnIndex].Name == "colGenkaTanka")
            {
                string split_val = gv_1.Rows[e.RowIndex].Cells["colGenkaTanka"].EditedFormattedValue.ToString().Replace(",", "");
                int Tanka_Number = string.IsNullOrEmpty(gv_1.Rows[e.RowIndex].Cells["colGenkaTanka"].EditedFormattedValue.ToString()) ? 0 : Convert.ToInt32(split_val);
                gv_1.Rows[e.RowIndex].Cells["colGenkaTanka"].Value = Tanka_Number.ToString();
                gv_1.Rows[e.RowIndex].Cells["colGenkaKingaku"].Value = Convert.ToInt32(gv_1.Rows[e.RowIndex].Cells["colGenkaTanka"].Value) * Convert.ToInt32(gv_1.Rows[e.RowIndex].Cells["colIdouSuu"].Value);
                gv_1.MoveNextCell();
            }
            if (gv_1.Columns[e.ColumnIndex].Name == "colGenkaKingaku")
            {
                string split_val = gv_1.Rows[e.RowIndex].Cells["colGenkaKingaku"].EditedFormattedValue.ToString().Replace(",", "");
                int Genka_Number = string.IsNullOrEmpty(gv_1.Rows[e.RowIndex].Cells["colGenkaKingaku"].EditedFormattedValue.ToString()) ? 0 : Convert.ToInt32(split_val);
                gv_1.Rows[e.RowIndex].Cells["colGenkaKingaku"].Value = Genka_Number.ToString();
                gv_1.MoveNextCell();
            }
            if (gv_1.Columns[e.ColumnIndex].Name == "colIdouMeisaiTekiyou")
                gv_1.MoveNextCell();
        }

        private void gv_1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (!bl_rowEnter)
            //{
            //    string soukoCD = string.Empty;
            //    if (txtIdoukubun.Text == "1")
            //        soukoCD = txtNyukosouko.Text;
            //    else soukoCD = txtShukkosouko.Text;
            //    string ShouhinCD = gv_1.Rows[e.RowIndex].Cells["colShouhinCD"].Value.ToString();
            //    DataTable dt = Idou_BL.IdouNyuuryoku_Select_Check(ShouhinCD, soukoCD, "Kanri");
            //    if (dt.Rows.Count > 0)
            //    {
            //        gv_1.Rows[e.RowIndex].Cells["colKanriNO"].Value = dt.Rows[0]["KanriNO"].ToString();
            //    }

            //}
            //bl_rowEnter = false;
        }

        private void btnNameF10_Click(object sender, EventArgs e)
        {
            F10_Gridview_Bind();
        }

        private void F10_Gridview_Bind()
        {
            IdouNyuuryokuEntity obj = new IdouNyuuryokuEntity();
            obj.BrandCD = txtBrandCD.Text;
            obj.ShouhinCD = txtShouhinCD.Text;
            obj.JANCD = txtJANCD.Text;
            obj.ShouhinName = txtShouhinName.Text;
            obj.YearTerm = txtYearTerm.Text;
            obj.SeasonSS = chk_SS.Checked ? "1" : "0";
            obj.SeasonFW = chk_FW.Checked ? "1" : "0";
            obj.ColorNO = txtColorNo.Text;
            obj.SizeNO = txtSizeNo.Text;
            obj.ChangeDate = txtIdouDate.Text;
            if (txtIdoukubun.Text == "1")
                obj.SoukoCD = txtNyukosouko.Text;
            else obj.SoukoCD = txtShukkosouko.Text;
            DataTable dt = Idou_BL.IdouNyuuryoku_Display(obj);
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
                string shouhinCD = row.Cells["colShouhinCD"].Value.ToString();
                string kanriNO = row.Cells["colKanriNO"].Value.ToString();

                DataRow[] select_dr1 = gv1_to_dt1.Select("ShouhinCD ='" + shouhinCD + "'");// original data
                DataRow existDr1 = F8_dt1.Select("ShouhinCD ='" + shouhinCD + "' and  KanriNO='" + kanriNO + "'").SingleOrDefault();

                F8_drNew[0] = shouhinCD;

                if (row.Cells["colIdouSuu"].Value.ToString() != "0" && (select_dr1[0][6].ToString() != row.Cells["colIdouSuu"].Value.ToString()))
                {
                    for (int c = 1; c < gv_1.Columns.Count; c++)
                    {
                        if (gv_1.Columns[c].Name == "colIdouSuu" || gv_1.Columns[c].Name == "colKanriNO")
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
        }

        private void btnNameF8_Click(object sender, EventArgs e)
        {
            F8_Gridview_Bind();
        }

        private void F8_Gridview_Bind()
        {
            F8_dt1.DefaultView.Sort = "ShouhinCD";
            gv_1.DataSource = F8_dt1.DefaultView.ToTable();
            gv_1.ClearSelection();
        }

        private void DBProcess()
        {
            string mode = string.Empty;
            (string, string) obj = GetInsert();

            if (cboMode.SelectedValue.Equals("1"))
            {
                mode = "New";
                DoInsert(mode, obj.Item1, obj.Item2);
            }
            else if (cboMode.SelectedValue.Equals("2"))
            {
                //mode = "Update";
                //DoUpdate(mode, obj.Item1, obj.Item2, obj.Item3);
            }
            else if (cboMode.SelectedValue.Equals("3"))
            {
                //mode = "Delete";
                //DoUpdate(mode, obj.Item1, obj.Item2, obj.Item3);
            }
        }
        private (string, string) GetInsert()
        {
            DataTable dt = new DataTable();
            Create_Datatable_Column(dt);
            DataRow dr = dt.NewRow();
            dr["IdouNO"] = txtIdouNO.Text;
            dr["IdouDate"] = txtIdouDate.Text;
            dr["IdouKBN"] = txtIdoukubun.Text;
            dr["StaffCD"] = txtStaffCD.Text;
            dr["ShukkoSoukoCD"] = txtShukkosouko.Text;
            dr["NyuukoSoukoCD"] = txtNyukosouko.Text;
            dr["IdouDenpyouTekiyou"] = txtDenpyouTekiyou.Text;
            dr["InsertOperator"] = base_Entity.OperatorCD;
            dr["UpdateOperator"] = base_Entity.OperatorCD;
            dr["PC"] = base_Entity.PC;
            dr["ProgramID"] = base_Entity.ProgramID;

            dt.Rows.Add(dr);
            string header_XML = cf.DataTableToXml(dt);

            if (cboMode.SelectedValue.ToString() == "1")
            {
                for (int i = 0; i < F8_dt1.Rows.Count; i++)
                {
                    DataTable Idou_dt = Idou_BL.GetIdouNO("15", txtIdouDate.Text, "0");
                    F8_dt1.Rows[i]["IdouNO"] = Idou_dt.Rows[0]["Column1"];
                    F8_dt1.Rows[i]["IdouGyouNO"] = i + 1;
                }
            }
            string detail_XML = cf.DataTableToXml(F8_dt1);
            return (header_XML, detail_XML);
        }
        public void Create_Datatable_Column(DataTable create_dt)
        {
            create_dt.Columns.Add("IdouNO");
            create_dt.Columns.Add("IdouDate");
            create_dt.Columns.Add("IdouKBN");
            create_dt.Columns.Add("StaffCD");
            create_dt.Columns.Add("ShukkoSoukoCD");
            create_dt.Columns.Add("NyuukoSoukoCD");
            create_dt.Columns.Add("IdouDenpyouTekiyou");
            create_dt.Columns.Add("InsertOperator");
            create_dt.Columns.Add("UpdateOperator");
            create_dt.Columns.Add("PC");
            create_dt.Columns.Add("ProgramID");
        }

        private void DoInsert(string mode, string str_header, string str_detail)
        {
            IdouNyuuryokuBL objMethod = new IdouNyuuryokuBL();
            objMethod.IdouNyuuryoku_CUD(mode, str_header, str_detail);
        }
    }
}
