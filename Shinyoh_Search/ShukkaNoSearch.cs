﻿using BL;
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

namespace Shinyoh_Search {
    public partial class ShukkaNoSearch : SearchBase {
        public string TokuisakiName = string.Empty;
        public string StaffName = string.Empty;
        public string ShukkaNo = string.Empty;
        public ShukkaNoSearch()
        {
            InitializeComponent();
        }
        private void ShukkaNoSearch_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);
            lblTokuisaki_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblStaffName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtShukkaDate1.Focus();
            gvShukkaNo.UseRowNo(true);
            DataGridviewBind();
            ErrorCheck();
        }
        private void ErrorCheck()
        {
            //出荷日
            txtShukkaDate1.E103Check(true);
            txtShukkaDate2.E103Check(true);
            txtShukkaDate2.E104Check(true, txtShukkaDate1, txtShukkaDate2);
            //得意先
            txtTokuisaki.E101Check(true, "M_Tokuisaki", txtTokuisaki, txtShukkaDate1, null);
            //担当スタッフCD
            txtStaffCD.E101Check(true, "M_Staff", txtStaffCD, txtShukkaDate1, null);
            //出荷番号			
            txtShukkaNo2.E106Check(true, txtShukkaNo1, txtShukkaNo2);
            //	出荷指示番号				
            txtShukkaSijiNo2.E106Check(true, txtShukkaSijiNo1, txtShukkaSijiNo2);
            //	商品CD		
            txtShouhin2.E106Check(true, txtShouhin1, txtShouhin2);
        }
        public override void FunctionProcess(string tagID)
        {

            if (tagID == "2")
            {
                DataGridviewBind();
            }
            if (tagID == "3")
            {
                DataGridViewRow row = gvShukkaNo.CurrentRow;
                GetGridviewData(row);
            }
            base.FunctionProcess(tagID);
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
                        TokuisakiName = dt.Rows[0]["TokuisakiRyakuName"].ToString();
                        lblTokuisaki_Name.Text = TokuisakiName;
                    }
                    else
                    {
                        lblTokuisaki_Name.Text = string.Empty;
                    }
                }
            }
        }

        private void txtStaffCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtStaffCD.IsErrorOccurs)
                {
                    DataTable dt = txtStaffCD.IsDatatableOccurs;
                    if (dt.Rows.Count > 0)
                    {
                        StaffName = dt.Rows[0]["StaffName"].ToString();
                        lblStaffName.Text = StaffName;
                    }
                    else
                    {
                        lblStaffName.Text = string.Empty;
                    }
                }
            }
        }
        private void DataGridviewBind()
        {
            ShukkaNyuuryokuEntity obj = new ShukkaNyuuryokuEntity();
            obj.ShukkaDate1 = txtShukkaDate1.Text;
            obj.ShukkaDate2 = txtShukkaDate2.Text;
            obj.TokuisakiCD = txtTokuisaki.Text;
            obj.StaffCD = txtStaffCD.Text;
            obj.ShouhinName = txtShouhinName.Text;
            obj.ShukkaNO1 = txtShukkaNo1.Text;
            obj.ShukkaNO2 = txtShukkaNo2.Text;
            obj.ShukkaSiziNO1 = txtShukkaSijiNo1.Text;
            obj.ShukkaSiziNO2 = txtShukkaSijiNo2.Text;
            obj.ShouhinCD1 = txtShouhin1.Text;
            obj.ShouhinCD2 = txtShouhin2.Text;

            ShukkaNyuuryokuBL sBL = new ShukkaNyuuryokuBL();
            DataTable dt = sBL.ShukkaNo_Search(obj);
            if (dt.Columns.Contains("CurrentDay"))
            {
                if (dt.Rows.Count > 0)
                {
                    lbl_Date.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["CurrentDay"]);
                }
            }
            dt.Columns.Remove("CurrentDay");
            gvShukkaNo.DataSource = dt;
        }
        private void GetGridviewData(DataGridViewRow gvrow)
        {
            if (gvrow.DataBoundItem != null)
            {
                DataGridViewRow row = gvrow;
                ShukkaNo = row.Cells["colShukkaNo"].Value.ToString();
                this.Close();
            }
        }

        private void gvShukkaNo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetGridviewData(gvShukkaNo.Rows[e.RowIndex]);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DataGridviewBind();
        }
    }
}