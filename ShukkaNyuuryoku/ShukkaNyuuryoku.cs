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

namespace ShukkaNyuuryoku {
    public partial class ShukkaNyuuryoku : BaseForm {
        multipurposeEntity multi_Entity;
        CommonFunction cf;
        StaffBL staffBL;
        BaseBL bbl;
        TokuisakiDetail tokuisakiDetail = new TokuisakiDetail();
        KouritenDetail kouritenDetail = new KouritenDetail();
        string YuuBinNO1 = string.Empty;
        string YuuBinNO2 = string.Empty;
        string Address = string.Empty;
        DataTable Main_dt, Temptb1, Temptb2, gvdt1, gvdt2, F8_dt1;
        public ShukkaNyuuryoku()
        {
            InitializeComponent();
            multi_Entity = new multipurposeEntity();
            cf = new CommonFunction();
            bbl = new BaseBL();
            staffBL = new StaffBL();
            Main_dt = new DataTable();
            Temptb1 = new DataTable();
            Temptb2 = new DataTable();
            gvdt1 = new DataTable();
            gvdt2 = new DataTable();
            F8_dt1 = new DataTable();
        }

        private void ShukkaNyuuryoku_Load(object sender, EventArgs e)
        {
            ProgramID = "ShukkaNyuuryoku";
            StartProgram();
            cboMode.Bind(false, multi_Entity);

            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "新規(F2)", true);
            SetButton(ButtonType.BType.Update, F3, "修正(F3)", true);
            SetButton(ButtonType.BType.Delete, F4, "削除(F4)", true);
            SetButton(ButtonType.BType.Inquiry, F5, "照会(F5)", true);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", true);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            SetButton(ButtonType.BType.Empty, F8, "確認(F8)", true);
            SetButton(ButtonType.BType.Empty, F10, "表示(F10)", true);
            SetButton(ButtonType.BType.Empty, F11, "保存(F11)", true);

            txtTokuisaki.lblName = lblTokuisakiName;
            txtKouriten.lblName = lblKouritenName;
            txtStaff.lblName = lblStatffName;


            txtTokuisaki.ChangeDate = txtShukkaDate;
            txtKouriten.ChangeDate = txtShukkaDate;
            txtStaff.ChangeDate = txtShukkaDate;

            ChangeMode(Mode.New);

            txtShukkaNo.ChangeDate = txtShukkaNo;

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
            if (tagID == "9")
            {
                //SiiresakiSearch detail = new SiiresakiSearch();
                //detail.ShowDialog();
            }
            if (tagID == "10")
            {

            }
            if (tagID == "12")
            {
                //if (ErrorCheck(PanelTitle) && ErrorCheck(Panel_Detail))
                //{
                //    DBProcess();
                //    switch (cboMode.SelectedValue)
                //    {
                //        case "1":
                //            ChangeMode(Mode.New);
                //            break;
                //        case "2":
                //            ChangeMode(Mode.Update);
                //            break;
                //        case "3":
                //            ChangeMode(Mode.Delete);
                //            break;
                //        case "4":
                //            ChangeMode(Mode.Inquiry);
                //            break;
                //    }
                //}
            }

            base.FunctionProcess(tagID);
        }

        private void ChangeMode(Mode mode)
        {
            Mode_Setting();
            switch (mode)
            {
                case Mode.New:
                    ErrorCheck();
                    txtShukkaNo.E102Check(false);
                    txtShukkaNo.E133Check(false, "ShukkaNyuuryoku", txtShukkaNo, null, null);
                    txtShukkaNo.E160Check(false, "ShukkaNyuuryoku", txtShukkaNo, null);

                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    //txtShukkaNo.Enabled = false;
                    break;

                case Mode.Update:
                    ErrorCheck();
                    txtShukkaNo.E102Check(true);
                    txtShukkaNo.E133Check(true, "ShukkaNyuuryoku", txtShukkaNo, null, null);
                    txtShukkaNo.E160Check(true, "ShukkaNyuuryoku", txtShukkaNo, null);

                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                    ErrorCheck();
                    txtShukkaNo.E102Check(true);
                    txtShukkaNo.E133Check(true, "ShukkaNyuuryoku", txtShukkaNo, null, null);
                    txtShukkaNo.E160Check(true, "ShukkaNyuuryoku", txtShukkaNo, null);

                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;

                    break;
                case Mode.Inquiry:
                    txtShukkaNo.E102Check(true);
                    txtShukkaNo.E133Check(true, "ShukkaNyuuryoku", txtShukkaNo, null, null);
                    txtShukkaNo.E160Check(true, "ShukkaNyuuryoku", txtShukkaNo, null);

                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;
                    break;
            }
        }
        private void New_Mode()
        {
            BaseEntity baseEntity = _GetBaseData();
            txtShukkaDate.Text = baseEntity.LoginDate;

            StaffEntity staffEntity = new StaffEntity
            {
                StaffCD = OperatorCD
            };
            staffEntity = staffBL.GetStaffEntity(staffEntity);
            txtStaff.Text = OperatorCD;
            lblStatffName.Text = staffEntity.StaffName;
        }
        private void Mode_Setting()
        {
            cf.Clear(PanelTitle);
            cf.Clear(panelDetail);

            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(panelDetail);

            lblTokuisakiName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblKouritenName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblStatffName.BorderStyle = System.Windows.Forms.BorderStyle.None;

            lblTokuisakiName.Text = string.Empty;
            lblKouritenName.Text = string.Empty;
            lblStatffName.Text = string.Empty;
            txtShukkaNo.Focus();
            New_Mode();
        }
        private void ErrorCheck()
        {
            txtShukkaDate.E102Check(true);
            txtShukkaDate.E103Check(true);
            txtShukkaDate.E115Check(true, "ShukkaNyuuryoku", txtShukkaDate);

            txtTokuisaki.E102Check(true);
            txtTokuisaki.E101Check(true, "M_Tokuisaki", txtTokuisaki, txtShukkaDate, null);
            txtTokuisaki.E267Check(true, "M_Tokuisaki", txtTokuisaki, txtShukkaDate);
            txtTokuisaki.E227Check(true, "M_Tokuisaki", txtTokuisaki, txtShukkaDate);

            txtKouriten.E102Check(true);
            txtKouriten.E101Check(true, "M_Kouriten", txtKouriten, txtShukkaDate, null);
            txtKouriten.E267Check(true, "M_Kouriten", txtKouriten, txtShukkaDate);
            txtKouriten.E227Check(true, "M_Kouriten", txtKouriten, txtShukkaDate);

            txtStaff.E102Check(true);
            txtStaff.E101Check(true, "M_Staff", txtStaff, txtShukkaDate, null);
            txtStaff.E135Check(true, "M_Staff", txtStaff, txtShukkaDate);

            //txtShukkaSijiNo.E133Check(false, "ShukkaNyuuryoku", txtShukkaSijiNo, null, null);

            txtShukkaYoteiDate1.E103Check(true);
            txtShukkaYoteiDate2.E103Check(true);
            txtShukkaYoteiDate2.E104Check(true, txtShukkaYoteiDate1, txtShukkaYoteiDate2);

            txtDenpyouDate1.E103Check(true);
            txtDenpyouDate2.E103Check(true);
            txtDenpyouDate2.E104Check(true, txtDenpyouDate1, txtDenpyouDate2);

            txtYubin2.E102MultiCheck(true, txtYubin1, txtYubin2);
            txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, null, null);
        }
        private void btnDetail1_Click(object sender, EventArgs e)
        {
                if (tokuisakiDetail.Access_Tokuisaki_obj.TokuisakiCD.ToString().Equals(txtTokuisaki.Text))
                {
                    tokuisakiDetail.ShowDialog();
                }
                else
                {
                    bbl.ShowMessage("E269", "出荷指示時", "得意先");
                    txtTokuisaki.Focus();
                }                  
        }

        private void btnDetail2_Click(object sender, EventArgs e)
        {
            if (kouritenDetail.Access_Kouriten_obj.KouritenCD.ToString().Equals(txtKouriten.Text))
            {
                tokuisakiDetail.ShowDialog();
            }
            else
            {
                bbl.ShowMessage("E269", "出荷指示時", "得意先");
                txtKouriten.Focus();
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
                        txtJuusho.Text = dt.Rows[0]["Juusho1"].ToString();
                    }
                    else
                    {
                        if (txtYubin1.Text != YuuBinNO1 || txtYubin2.Text != YuuBinNO2)
                        {
                            txtJuusho.Text = string.Empty;
                        }
                        else
                        {
                            txtJuusho.Text = Address;
                        }
                    }
                }

            }
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
        private void EnablePanel()
        {
            cf.EnablePanel(panelDetail);
            txtShukkaNo.Focus();
            cf.DisablePanel(PanelTitle);
        }
        private void txtTokuisaki_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtTokuisaki.IsErrorOccurs)
                {
                    DataTable dt = txtTokuisaki.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                    {
                        tokuisakiDetail.Access_Tokuisaki_obj = From_DB_To_Tokuisaki(dt);
                    }
                }
            }
        }

        private void txtKouriten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtTokuisaki.IsErrorOccurs)
                {
                    DataTable dt = txtKouriten.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                    {
                        kouritenDetail.Access_Kouriten_obj = From_DB_To_Kouriten(dt);
                    }
                }
            }
        }

        private void gvShukka1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (gvShukka1.Columns[e.ColumnIndex].Name == "colKonkai")
            {
                string value = gvShukka1.Rows[e.RowIndex].Cells["colKonkai"].EditedFormattedValue.ToString();
                string a = gvShukka1.Rows[e.RowIndex].Cells["colShukkazansuu"].EditedFormattedValue.ToString();
                string b = gvShukka1.Rows[e.RowIndex].Cells["colMiryoku"].EditedFormattedValue.ToString();
                decimal c = Convert.ToDecimal(a) - Convert.ToDecimal(b);

                if (Convert.ToDecimal(value) < 0)
                {
                    bbl.ShowMessage("E109");
                    e.Cancel = true;
                }
                else if (Convert.ToDecimal(value) > c)
                {
                    bbl.ShowMessage("E143",c.ToString(),value);
                    e.Cancel = true;
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            F8_dt1.DefaultView.Sort = "JANCD";

            gvShukka1.DataSource = F8_dt1.DefaultView.ToTable();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtShukkaSijiNo.Focus();

            for (int t = 0; t < gvShukka1.RowCount; t++)
            {
                bool bl = false;
                // grid 1 checking
                DataRow F8_drNew = F8_dt1.NewRow();// save updated data 
                DataGridViewRow row = gvShukka1.Rows[t];// grid view data
                string id = row.Cells[0].Value.ToString();

                DataRow[] select_dr1 = gvdt1.Select("JANCD ='" + id + "'");// original data
                DataRow existDr1 = F8_dt1.Select("JANCD ='" + id + "'").SingleOrDefault();

                F8_drNew[0] = id;
                for (int c = 1; c < gvShukka1.Columns.Count; c++)
                {
                    if (existDr1 != null)
                    {
                        if (select_dr1[0][c].ToString() != row.Cells[c].Value.ToString() && (c == 8 || c == 9 || c == 10))
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
                        if (select_dr1[0][c].ToString() != row.Cells[c].Value.ToString() && (c == 8 || c == 9 || c == 10))
                            bl = true;

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

        private void txtShukkaNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtShukkaNo.IsErrorOccurs)
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
                Main_dt = txtShukkaNo.IsDatatableOccurs;
                if (Main_dt.Rows.Count > 0 && cboMode.SelectedValue.ToString() != "1")
                {
                    From_DB_To_Form(Main_dt);
                }
            }
        }
        private void From_DB_To_Form(DataTable dt)
        {
            if (dt.Rows[0]["MessageID"].ToString() == "E132")
            {
                txtShukkaDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["ShukkaDate"]);
                txtTokuisaki.Text = dt.Rows[0]["TokuisakiCD"].ToString();
                lblTokuisakiName.Text = dt.Rows[0]["TokuisakiRyakuName"].ToString();
                txtKouriten.Text = dt.Rows[0]["KouritenCD"].ToString();
                lblKouritenName.Text = dt.Rows[0]["KouritenRyakuName"].ToString();
                txtStaff.Text = dt.Rows[0]["StaffCD"].ToString();
                lblStatffName.Text = dt.Rows[0]["StaffName"].ToString();
                txtDenpyou.Text = dt.Rows[0]["ShukkaDenpyouTekiyou"].ToString();

                //show page load data in tokuisaki detail
                tokuisakiDetail.Access_Tokuisaki_obj = From_DB_To_Tokuisaki(dt);


                //show page load data in kouriten detail
                kouritenDetail.Access_Kouriten_obj = From_DB_To_Kouriten(dt);

                //
                dt.Columns.Remove("ShukkaDate");
                dt.Columns.Remove("StaffCD");
                dt.Columns.Remove("StaffName");
                dt.Columns.Remove("ShukkaDenpyouTekiyou");

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
                dt.Columns.Remove("DenpyouDate");
                dt.Columns.Remove("JuchuuNOGyouNO");
                dt.Columns.Remove("MessageID");

                DataTable dt1 = dt.Copy();      
                dt1.Columns.Remove("ShukkaSiziNOGyouNO");
                gvdt1 = dt1;
                gvShukka1.DataSource = dt1;

                //DataTable dt2 = dt.Copy();
                //dt2.Columns.Remove("JANCD");
                //dt2.Columns.Remove("ShouhinCD");
                //dt2.Columns.Remove("ShouhinName");
                //dt2.Columns.Remove("ColorRyakuName");
                //dt2.Columns.Remove("ColorNO");
                //dt2.Columns.Remove("SizeNO");
                //dt2.Columns.Remove("ShukkaSiziZumiSuu");
                //dt2.Columns.Remove("MiNyuukaSuu");
                //dt2.Columns.Remove("ShukkaSuu");
                //dt2.Columns.Remove("Kanryou");
                //gvdt2 = dt2;
                //gvShukka2.DataSource = dt2;

                Temptb1 = gvdt1.Copy();
                gvdt1 = Temptb1;
                F8_dt1 = gvdt1.Clone();
                // Temptb1.Clear();
                //Temptb2 = gvdt2.Copy();
                //Temptb2.Clear();
            }
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

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            ShukkaNyuuryokuEntity obj = new ShukkaNyuuryokuEntity();
            ShukkaNyuuryokuBL sBL = new ShukkaNyuuryokuBL();
            BaseEntity baseEntity = _GetBaseData();
            obj.TokuisakiCD = txtTokuisaki.Text;
            obj.ShukkaSiziNO1 = txtShukkaSijiNo.Text;
            obj.ShukkaDate1 = txtShukkaYoteiDate1.Text;
            obj.ShukkaDate2 = txtShukkaYoteiDate2.Text;
            obj.DenpyouDate1 = txtDenpyouDate1.Text;
            obj.DenpyouDate2 = txtDenpyouDate2.Text;           
            obj.Yuubin1 = txtYubin1.Text;
            obj.Yuubin2 = txtYubin2.Text;
            obj.TelNO1 = txtTelNo1.Text;
            obj.TelNO2 = txtTelNo2.Text;
            obj.TelNO3 = txtTelNo3.Text;
            obj.Name = txtName.Text;
            obj.Juusho = txtJuusho.Text;
            obj.ChangeDate = baseEntity.LoginDate;

            DataTable dt = sBL.ShukkaNyuuryoku_Display(obj);

            if (dt.Rows.Count > 0)
            {
                dt.Columns.Remove("ShukkaSiziNOGyouNO");
                dt.Columns.Remove("TokuisakiCD");
                dt.Columns.Remove("KouritenCD");
                dt.Columns.Remove("DenpyouDate");
                dt.Columns.Remove("JuchuuNOGyouNO");
                if(obj.Condition == "1")
                {
                    gvShukka1.DataSource = dt;
                    DataTable dt_temp = dt.Copy();
                    gvdt1 = dt_temp;
                }
                else
                {
                    gvShukka1.DataSource = dt;
                    DataTable dt_temp = dt.Copy();
                    gvdt1 = dt_temp;
                }
               
            }
        }
    }
}
