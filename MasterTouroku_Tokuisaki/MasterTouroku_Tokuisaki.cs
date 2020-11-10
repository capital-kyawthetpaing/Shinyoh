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

namespace MasterTouroku_Tokuisaki {
    public partial class MasterTouroku_Tokuisaki : BaseForm {
        StaffEntity staff_Entity;
        CommonFunction cf;

        public MasterTouroku_Tokuisaki()
        {
            InitializeComponent();
        }

        private void MasterTouroku_Tokuisaki_Load(object sender, EventArgs e)
        {
            multipurposeEntity multipurposeEntity = new multipurposeEntity();
            ProgramID = "MasterTourokuTokuisaki";
            StartProgram();
            cboMode.Bind(false,multipurposeEntity);
            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "新規(F2)", true);
            SetButton(ButtonType.BType.Update, F3, "修正(F3)", true);
            SetButton(ButtonType.BType.Delete, F4, "削除(F4)", true);
            SetButton(ButtonType.BType.Inquiry, F5, "照会(F5)", true);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", true);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            SetButton(ButtonType.BType.Empty, F8, "", false);
            SetButton(ButtonType.BType.Empty, F10, "CSV取込(F10)", true);
            SetButton(ButtonType.BType.Empty, F11, "", false);
            txt_Tokuisaki.Focus();
            ChangeMode(Mode.New);
            sRadRegister.Checked = true;
            staff_Entity = GetBaseData();
        }

        private void ChangeMode(Mode mode)
        {
            cf.Clear(PanelTitle);
            cf.Clear(PanelDetail);
            cf.EnablePanel(PanelTitle);
            cf.DisablePanel(PanelDetail);
            txt_Tokuisaki.Focus();
            switch (mode)
            {
                case Mode.New:
                    txt_Tokuisaki.E102Check(true);
                    txtChange_Date.E102Check(true);
                    txtChange_Date.E103Check(true);
                    txtChange_Date.E132Check(true, "M_Tokuisaki", txt_Tokuisaki, txtChange_Date, null);
                 //   txtChange_Date.E133Check(true, "M_Siiresaki", txt_Tokuisaki, txtChange_Date, null);

                    txtTokuisaki_CopyDate.E103Check(true);
                    txtTokuisaki_CopyDate.E102MultiCheck(true, txtTokuisaki_Copy, txtTokuisaki_CopyDate);
                 //   txtTokuisaki_CopyDate.E133Check(true, "M_Siiresaki", txt_Tokuisaki, txtChange_Date, null);

                    txtTokuisakiName.E102Check(true);
                    txtShortName.E102Check(true);
                    txtBillAddress.E102Check(true);
                    txtYubin2.E102MultiCheck(true, txtYubin1, txtYubin2);
                    txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, string.Empty, string.Empty);

                    txtStaffCharge.E102Check(true);
               //     txtStaffCharge.E101Check(true, "M_Tokuisaki", txtStaffCharge, txtChange_Date, null);

                    txtStartDate.E103Check(true);
                    txtEndDate.E103Check(true);
                    txtEndDate.E106Check(true, txtStartDate, txtEndDate);

                    cf.Clear(PanelTitle);
                    cf.Clear(PanelDetail);
                    cf.DisablePanel(PanelDetail);

                    Control btnNew = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnNew.Visible = true;
                    break;

                case Mode.Update:
                  //  txtChange_Date.E132Check(false,null,null,null,null);

                    Control btnUpdate = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnUpdate.Visible = true;
                    break;
                case Mode.Delete:
                //    txtChange_Date.E132Check(false, null, null, null, null);

                    Control btnDelete = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnDelete.Visible = true;

                    break;
                case Mode.Inquiry:
                  //  txtChange_Date.E132Check(false, null, null, null, null);

                    Control btnInquiry = this.TopLevelControl.Controls.Find("BtnF12", true)[0];
                    btnInquiry.Visible = false;
                    break;
            }
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
            if (tagID == "12")
            {
                if (sRadRegister.Checked == true)
                {
                    DBProcess();
                }
                
                //if (ErrorCheck(PanelTitle) && ErrorCheck(PanelDetail))
                //{
                //    if(sRadRegister.Checked == true)
                //    {
                //        DBProcess();
                //    }
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

        private void DBProcess()
        {
            TokuisakiEntity tokuisaki = GetInsert();

            if (cboMode.SelectedValue.Equals("1"))
            {
                tokuisaki.Mode = "New";
                DoInsert(tokuisaki);
            }
            else if (cboMode.SelectedValue.Equals("2"))
            {
                tokuisaki.Mode = "Update";
                DoUpdate(tokuisaki);
            }
            else if (cboMode.SelectedValue.Equals("3"))
            {
                tokuisaki.Mode = "Delete";
                DoDelete(tokuisaki);
            }
        }

        private TokuisakiEntity GetInsert()
        {
            TokuisakiEntity obj = new TokuisakiEntity();
            obj.TokuisakiCD = txt_Tokuisaki.Text;
            obj.ChangeDate = txtChange_Date.Text;
            obj.ShokutiFLG = chk.Checked ? 1 : 0;
            if (RadSaMa.Checked == true || RadOnchuu.Checked == true)
            {
                obj.AliasKBN = 1;
            }else
                obj.AliasKBN = 0;
            obj.ShukkaSizishoHuyouKBN = 0;
            obj.TokuisakiName = txtTokuisakiName.Text;
            obj.TokuisakiRyakuName = txtShortName.Text;
            obj.KanaName = txtKanaName.Text;
            obj.SeikyuusakiCD = txtBillAddress.Text;
            obj.YuubinNO1 = txtYubin1.Text;
            obj.YuubinNO2 = txtYubin2.Text;
            obj.Juusho1 = txtAddress1.Text;
            obj.Juusho2 = txtAddress2.Text;
            obj.Tel11 = txtPhNo1.Text;
            obj.Tel12 = txtPhNo2.Text;
            obj.Tel13 = txtPhNo3.Text;
            obj.Tel21 = txtPhNo4.Text;
            obj.Tel22 = txtPhNo5.Text;
            obj.Tel23 = txtPhNo6.Text;
            obj.TantouBusho = txtDepCharge.Text;
            obj.TantouYakushoku = txtJobTitle.Text;
            obj.TantoushaName = txtPersonCharge.Text;
            obj.MailAddress = txtMailAddress.Text;
            obj.StaffCD = txtStaffCharge.Text;
            obj.TorihikiKaisiDate = txtStartDate.Text;
            obj.TorihikiShuuryouDate = txtEndDate.Text;
            obj.Remarks = txtRemark.Text;
            obj.KensakuHyouziJun = txtSearch.Text;
            obj.UsedFlg = 0;
            obj.InsertOperator = staff_Entity.StaffCD;
            obj.UpdateOperator = staff_Entity.StaffCD;

            //for log table
            obj.PC = staff_Entity.PC;
            obj.KeyItem = txt_Tokuisaki.Text + " " + txtChange_Date.Text;
            return obj;
        }

        private void DoInsert(TokuisakiEntity tokuisakiEntity)
        {
            TokuisakiBL bl = new TokuisakiBL();
            bl.M_Tokuisaki_CUD(tokuisakiEntity);
        }
        private void DoUpdate(TokuisakiEntity tokuisakiEntity)
        {
            TokuisakiBL bl = new TokuisakiBL();
            bl.M_Tokuisaki_CUD(tokuisakiEntity);
        }
        private void DoDelete(TokuisakiEntity tokuisakiEntity)
        {
            TokuisakiBL bl = new TokuisakiBL();
            bl.M_Tokuisaki_CUD(tokuisakiEntity);
        }
        private void From_DB_To_TokuForm(DataTable dt)
        {
           if(dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["MessageID"].ToString() == "E132")
                {
                    //if (dt.Rows[0]["ShokutiFLG"].ToString().Equals("1"))
                    //{
                    //    chk.Checked = true;
                    //}
                    //else
                    //    chk.Checked = false;
                    txtTokuisakiName.Text = dt.Rows[0]["TokuisakiName"].ToString();
                    txtShortName.Text = dt.Rows[0]["TokuisakiRyakuName"].ToString();
                    txtKanaName.Text = dt.Rows[0]["KanaName"].ToString();
                    txtBillAddress.Text = dt.Rows[0]["SeikyuusakiCD"].ToString();

                    //if (dt.Rows[0]["AliasKBN"].ToString().Equals("1"))
                    //{
                    //    RadSaMa.Checked = true;
                    //}
                    //else
                    //    RadSaMa.Checked = false;

                    txtYubin1.Text = dt.Rows[0]["YuubinNO1"].ToString();
                    txtYubin2.Text = dt.Rows[0]["YuubinNO2"].ToString();
                    txtAddress1.Text = dt.Rows[0]["Juusho1"].ToString();
                    txtAddress2.Text = dt.Rows[0]["Juusho2"].ToString();
                    txtPhNo1.Text = dt.Rows[0]["Tel11"].ToString();
                    txtPhNo2.Text = dt.Rows[0]["Tel12"].ToString();
                    txtPhNo3.Text = dt.Rows[0]["Tel13"].ToString();
                    txtPhNo4.Text = dt.Rows[0]["Tel21"].ToString();
                    txtPhNo5.Text = dt.Rows[0]["Tel22"].ToString();
                    txtPhNo6.Text = dt.Rows[0]["Tel23"].ToString();
                    txtDepCharge.Text = dt.Rows[0]["TantouBusho"].ToString();
                    txtJobTitle.Text = dt.Rows[0]["TantouYakushoku"].ToString();
                    txtPersonCharge.Text = dt.Rows[0]["TantoushaName"].ToString();
                    txtMailAddress.Text = dt.Rows[0]["MailAddress"].ToString();
                    txtStaffCharge.Text = dt.Rows[0]["StaffCD"].ToString();
                    txtStartDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["TorihikiKaisiDate"]);
                    txtEndDate.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["TorihikiShuuryouDate"]);
                    txtRemark.Text = dt.Rows[0]["Remarks"].ToString();
                    txtSearch.Text = dt.Rows[0]["KensakuHyouziJun"].ToString();
                }
            }
        }

        private void txtTokuisaki_CopyDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cboMode.SelectedValue.ToString() == "1")
            {
                //txtTokuisakiName.Focus();
                //DataTable dt = txtTokuisaki_CopyDate.IsDatatableOccurs;
                //if (dt.Rows.Count > 0)
                //    From_DB_To_TokuForm(dt);
                if (!txtTokuisaki_CopyDate.IsErrorOccurs)
                {
                    EnablePanel();
                    DataTable dt = txtTokuisaki_CopyDate.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                        From_DB_To_TokuForm(dt);
                }
            }
        }

        private void txtYubin2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtYubin2.IsErrorOccurs && txtYubin2.IsDatatableOccurs.Rows.Count > 0)
                {
                    DataTable dt = txtYubin2.IsDatatableOccurs;
                    txtAddress1.Text = dt.Rows[0]["Juusho1"].ToString();
                    txtAddress2.Text = dt.Rows[0]["Juusho2"].ToString();
                }
            }
        }
        private void txtChange_Date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtChange_Date.IsErrorOccurs)
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
                DataTable dt = txtChange_Date.IsDatatableOccurs;
                if (dt.Rows.Count > 0 && cboMode.SelectedValue.ToString() != "1")
                {
                    From_DB_To_TokuForm(dt);
                }
            }
        }
        private void EnablePanel()
        {
            cf.EnablePanel(PanelDetail);
            txt_Tokuisaki.Focus();
            cf.DisablePanel(PanelTitle);
        }
    }
}

