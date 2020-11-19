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

namespace Shinyoh_Search
{
    public partial class KouritenSearch : SearchBase
    {
        public string KouritenCD = string.Empty;
        public string changeDate = string.Empty;
        public KouritenSearch()
        {
            InitializeComponent();
        }

        private void KouritenSearch_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);

            rdo_Date.Focus();
            gv_Kouriten.UseRowNo(true);
            gv_Kouriten.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridviewBind();

        }

        private void txtCD2_TextChanged(object sender, EventArgs e)
        {
            txtCD2.E106Check(true, txtCD1, txtCD2);
        }

        private void txtTokuisakiCD2_TextChanged(object sender, EventArgs e)
        {
            txtTokuisakiCD2.E106Check(true, txtTokuisakiCD1, txtTokuisakiCD2);
        }

        private void btnKouriten_F11_Click(object sender, EventArgs e)
        {
            DataGridviewBind();
        }
        private void DataGridviewBind()
        {
            KouritenEntity obj = new KouritenEntity();
            obj.KouritenCD = txtCD1.Text;
            obj.KouritenRyakuName = txtCD2.Text;//using tempory for assign data
            obj.KouritenName = txtName.Text;
            obj.KanaName = txtKanaName.Text;

            obj.TokuisakiCD = txtTokuisakiCD1.Text;
            obj.MailAddress = txtTokuisakiCD2.Text;
            obj.Juusho1 = txtTokuisakiName.Text;
            obj.Juusho2 = txtTokuisaki_Kana.Text;

            obj.Remarks = string.Empty;
            if (rdo_Date.Checked)
                obj.Remarks = "RevisionDate";
            if (rdo_All.Checked)
                obj.Remarks = "All";
            KouritenBL objMethod = new KouritenBL();
            DataTable dt = objMethod.Kouriten_Search(obj);
            if (dt.Columns.Contains("CurrentDay"))
            {
                lbl_Date.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["CurrentDay"]);
                dt.Columns.Remove("CurrentDay");
            }
            gv_Kouriten.DataSource = dt;
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "2")
            {
                DataGridviewBind();
            }
            if (tagID == "3")
            {
                DataGridViewRow row = gv_Kouriten.CurrentRow;
                GetGridviewData(row);
            }
            base.FunctionProcess(tagID);
        }

        private void GetGridviewData(DataGridViewRow gvrow)
        {
            if (gvrow.DataBoundItem != null)
            {
                DataGridViewRow row = gvrow;
                KouritenCD = row.Cells["colKouritenCD"].Value.ToString();
                changeDate = Convert.ToDateTime(row.Cells["colChangeDate"].Value.ToString()).ToString("yyyy/MM/dd");
                this.Close();
            }
        }

        private void gv_Kouriten_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetGridviewData(gv_Kouriten.Rows[e.RowIndex]);
        }
    }
}