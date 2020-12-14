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
        TokuisakiDetail tokuisakiDetail = new TokuisakiDetail();
        KouritenDetail kouritenDetail = new KouritenDetail();
        string YuuBinNO1 = string.Empty;
        string YuuBinNO2 = string.Empty;
        string Address = string.Empty;
        public ShukkaNyuuryoku()
        {
            InitializeComponent();
            multi_Entity = new multipurposeEntity();
            cf = new CommonFunction();
            staffBL = new StaffBL();
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
            txtStaff.lblName = lblSatffName;


            txtTokuisaki.ChangeDate = txtShukkaDate;
            txtKouriten.ChangeDate = txtShukkaDate;
            txtStaff.ChangeDate = txtShukkaDate;

            ChangeMode(Mode.New);

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
            lblSatffName.Text = staffEntity.StaffName;
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
                //Mode_Setting();
                //if (cboMode.SelectedValue.Equals("2") || cboMode.SelectedValue.Equals("3") || cboMode.SelectedValue.Equals("4"))
                //{
                //    Disable_UDI_Mode();
                //}
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
            //Mode_Setting();
            switch (mode)
            {
                case Mode.New:
                    ErrorCheck();
                    New_Mode();
                    txtShukkaNo.E102Check(false);
                    txtShukkaNo.E133Check(false, "ShukkaNyuuryoku", txtShukkaNo, null, null);
                    txtShukkaNo.E160Check(false, "ShukkaNyuuryoku", txtShukkaNo, null);

                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
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
        private void Mode_Setting()
        {
            cf.Clear(PanelTitle);
            cf.Clear(panelDetail);

            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(panelDetail);

            //lblTokuisaki_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //lblKouriten_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //lblStaff_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //lblBrand_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //lblYear.BorderStyle = System.Windows.Forms.BorderStyle.None;


            //lblTokuisaki_Name.Text = string.Empty;
            //lblKouriten_Name.Text = string.Empty;
            //lblStaff_Name.Text = string.Empty;
            //lblBrand_Name.Text = string.Empty;
            //Main_dt = new DataTable();
            //gv1_to_dt1 = new DataTable();
            //gv2_to_dt2 = new DataTable();
            //internal_dt1 = new DataTable();
            //internal_dt2 = new DataTable();
            txtShukkaNo.Focus();
        }
        private void ErrorCheck()
        {
            txtShukkaDate.E102Check(true);
            txtShukkaDate.E103Check(true);
            txtShukkaDate.E115Check(true, "ShukkaNyuuryoku", txtShukkaDate);

            txtTokuisaki.E102Check(true);
            txtTokuisaki.E101Check(true, "M_Tokuisaki", txtTokuisaki, txtShukkaDate, null);
            txtTokuisaki.E267Check(true, "M_Tokuisaki", txtTokuisaki, txtShukkaDate);

            txtKouriten.E102Check(true);
            txtKouriten.E101Check(true, "M_Kouriten", txtKouriten, txtShukkaDate, null);

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
        private void sButton1_Click(object sender, EventArgs e)
        {
            ShukkaNoSearch a = new ShukkaNoSearch();
            a.Show();
            
        }

        private void btnDetail1_Click(object sender, EventArgs e)
        {
            tokuisakiDetail.ShowDialog();
        }

        private void btnDetail2_Click(object sender, EventArgs e)
        {
            kouritenDetail.ShowDialog();
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
                        txtAddress.Text = dt.Rows[0]["Juusho1"].ToString();
                    }
                    else
                    {
                        if (txtYubin1.Text != YuuBinNO1 || txtYubin2.Text != YuuBinNO2)
                        {
                            txtAddress.Text = string.Empty;
                        }
                        else
                        {
                            txtAddress.Text = Address;
                        }
                    }
                }

            }
        }
    }
}
