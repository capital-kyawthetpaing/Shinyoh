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
    public partial class TokuisakiSearch : SearchBase {
        public string Tokuisaki = string.Empty;
        public string ChangeDate = string.Empty;
        public string TokuisakiRyakuName = string.Empty;
        public string Date_Access_Tokuisaki = string.Empty;

        public TokuisakiSearch()
        {
            InitializeComponent();
        }

        private void TokuisakiSearch_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Normal, F9, "", false);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);

            gvTokuisaki.UseRowNo(true);
            gvTokuisaki.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            rdo_Date.Focus();
            DataGridviewBind();

            txtTokuisaki2.E106Check(true, txtTokuisaki1, txtTokuisaki2);
            gvTokuisaki.SetGridDesign();
            gvTokuisaki.SetReadOnlyColumn("**");//readonly for search form 
            gvTokuisaki.Select();
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "3")
            {
                DataGridviewBind();
                gvTokuisaki.Select();
            }
            if (tagID == "4")
            {
                DataGridViewRow row = gvTokuisaki.CurrentRow;
                GetGridviewData(row);
            }
            base.FunctionProcess(tagID);
        }
        private void DataGridviewBind()
        {
            TokuisakiEntity obj = new TokuisakiEntity();
            obj.TokuisakiCD = txtTokuisaki1.Text;
            obj.ChangeDate = Date_Access_Tokuisaki;
            obj.TokuisakiRyakuName = txtTokuisaki2.Text;//using tempory for assign data
            obj.TokuisakiName = txtTokuisakiName.Text;
            obj.KanaName = txtKanaName.Text;
            obj.Remarks = string.Empty;
            if (rdo_Date.Checked)
                obj.Remarks = "RevisionDate";
            if (rdo_All.Checked)
                obj.Remarks = "All";
            TokuisakiBL tBL = new TokuisakiBL();
            DataTable dt = tBL.Tokuisaki_Search(obj);
            if (dt.Columns.Contains("CurrentDay"))
            {
                if (dt.Rows.Count > 0)
                {
                    lbl_Date.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["CurrentDay"]);
                }
                else
                {
                    ClearSession();         //HET
                }
                dt.Columns.Remove("CurrentDay");
            }
            else
            {
                if(dt.Rows.Count == 0)      //HET
                    ClearSession();                
            }
            gvTokuisaki.DataSource = dt;
        }
        //HET
        private void ClearSession()
        {          
            txtTokuisaki1.Clear();
            txtTokuisaki2.Clear();
            txtTokuisakiName.Clear();
            txtKanaName.Clear();
            rdo_Date.Checked = true;
        }
        private void gvTokuisaki_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                GetGridviewData(gvTokuisaki.Rows[e.RowIndex]);
            }
        }
        private void GetGridviewData(DataGridViewRow gvrow)
        {
            if (gvrow != null)
            {
                DataGridViewRow row = gvrow;
                Tokuisaki = row.Cells["colTokuisakiCD"].Value.ToString();
                ChangeDate = Convert.ToDateTime(row.Cells["colChangeDate"].Value.ToString()).ToString("yyyy/MM/dd");
                TokuisakiRyakuName = row.Cells["colTokuisakiRyakuName"].Value.ToString();              
            }
            this.Close();
        }  
        private void btnTokuisaki_F11_Click(object sender, EventArgs e)
        {
            DataGridviewBind();
            gvTokuisaki.Select();
        }

        private void gvTokuisaki_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (gvTokuisaki.CurrentCell != null)
                    GetGridviewData(gvTokuisaki.Rows[gvTokuisaki.CurrentCell.RowIndex]);
            }
        }
    }
}
