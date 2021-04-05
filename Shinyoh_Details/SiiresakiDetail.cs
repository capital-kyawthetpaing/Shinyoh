﻿using Entity;
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
using CKM_CommonFunction;
using BL;

namespace Shinyoh_Details
{
    public partial class SiiresakiDetail : SearchBase
    {
        public SiiresakiEntity Access_Siiresaki_obj = new SiiresakiEntity();
        string YuuBinNO1 = string.Empty;
        string YuuBinNO2 = string.Empty;
        string Address1 = string.Empty;
        string Address2 = string.Empty;
        string SiiresakiCD = string.Empty;
        bool isEnable;
        CommonFunction cf = new CommonFunction();
        JuchuuNyuuryokuBL bl = new JuchuuNyuuryokuBL();
        public SiiresakiDetail()
        {
            InitializeComponent();
            isEnable = true;
        }

        public SiiresakiDetail(bool val)
        {
            InitializeComponent();
            isEnable = val; 
        }

        private void SiiresakiDetail_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Search, F11, "", false);
            
            lbl_Name.BorderStyle= System.Windows.Forms.BorderStyle.None;

            txtCD.Enabled = false; ;

            txtShort_Name.Focus();

            txtShort_Name.E102Check(true);
            txtLong_Name.E102Check(true);
            txtYubin2.E102MultiCheck(true, txtYubin1, txtYubin2);
            txtYubin2.Yuubin_Juusho(true, txtYubin1, txtYubin2, string.Empty, string.Empty);

            //Get Data from JuchuuNyuuroku form
            Access_DB_Object(Access_Siiresaki_obj);

            SiiresakiCD = Access_Siiresaki_obj.SiiresakiCD;
            DataTable dt = bl.ShokutiFLG_Select(string.Empty, string.Empty, SiiresakiCD, "Siiresaki");

            if (!isEnable)
            {
                cf.DisablePanel(Panel_Detail);
                SetButton(ButtonType.BType.Save, F12, "確定(F12)", false);
            }
            else
            {
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["ShokutiFLG"].ToString() == "1")
                    {
                        cf.EnablePanel(Panel_Detail);
                        SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);
                    }
                    else
                    {
                        cf.DisablePanel(Panel_Detail);
                        SetButton(ButtonType.BType.Save, F12, "確定(F12)", false);
                    }
                }
            }
        }
        private void Access_DB_Object(SiiresakiEntity obj)
        {
            txtCD.Text = obj.SiiresakiCD;
            txtLong_Name.Text = obj.SiiresakiName;
            txtShort_Name.Text = obj.SiiresakiRyakuName;
            lbl_Name.Text = obj.SiiresakiRyakuName;
            txtYubin1.Text = obj.YuubinNO1;
            txtYubin2.Text = obj.YuubinNO2;
            txtAddress1.Text = obj.Juusho1;
            txtAddress2.Text = obj.Juusho2;
            txtPhone1_1.Text = obj.Tel11;
            txtPhone1_2.Text = obj.Tel12;
            txtPhone1_3.Text = obj.Tel13;
            txtPhone2_1.Text = obj.Tel21;
            txtPhone2_2.Text = obj.Tel22;
            txtPhone2_3.Text = obj.Tel23;
            YuuBinNO1 = txtYubin1.Text;
            YuuBinNO2 = txtYubin2.Text;
            Address1 = txtAddress1.Text;
            Address2 = txtAddress2.Text;
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "4")
            {
                if(ErrorCheck(Panel_Detail))
                {
                    Access_Siiresaki_obj.SiiresakiCD = txtCD.Text;
                    Access_Siiresaki_obj.SiiresakiName = txtLong_Name.Text;
                    Access_Siiresaki_obj.SiiresakiRyakuName = txtShort_Name.Text;
                    Access_Siiresaki_obj.YuubinNO1 = txtYubin1.Text;
                    Access_Siiresaki_obj.YuubinNO2 = txtYubin2.Text;
                    Access_Siiresaki_obj.Juusho1 = txtAddress1.Text;
                    Access_Siiresaki_obj.Juusho2 = txtAddress2.Text;
                    Access_Siiresaki_obj.Tel11 = txtPhone1_1.Text;
                    Access_Siiresaki_obj.Tel12 = txtPhone1_2.Text;
                    Access_Siiresaki_obj.Tel13 = txtPhone1_3.Text;
                    Access_Siiresaki_obj.Tel21 = txtPhone2_1.Text;
                    Access_Siiresaki_obj.Tel22 = txtPhone2_2.Text;
                    Access_Siiresaki_obj.Tel23 = txtPhone2_3.Text;

                    this.Close();
                }
            }
            base.FunctionProcess(tagID);
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
                        txtAddress1.Text = dt.Rows[0]["Juusho1"].ToString();
                        txtAddress2.Text = dt.Rows[0]["Juusho2"].ToString();
                    }
                    else
                    {
                        if (txtYubin1.Text != YuuBinNO1 || txtYubin2.Text != YuuBinNO2)
                        {
                            txtAddress1.Text = string.Empty;
                            txtAddress2.Text = string.Empty;
                        }
                        else
                        {
                            txtAddress1.Text = Address1;
                            txtAddress2.Text = Address2;
                        }
                    }
                }
            }
        }
    }
}
