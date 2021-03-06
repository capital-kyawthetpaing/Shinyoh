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
    public partial class StaffSearch : SearchBase
    {
        public string changeDate_Access;
        public string staffCD = string.Empty;
        public string changeDate = string.Empty;
        public string staffName = string.Empty;

        public StaffSearch()
        {
            InitializeComponent();          
        }

        private void StaffSearch_Load(object sender, EventArgs e)
        {
            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Normal, F9, "", false);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);

            gvStaff.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gvStaff.UseRowNo(true);
            DataGridviewBind();

            
            rdo_Date.Focus();
            txtStaff2.E106Check(true, txtStaff1, txtStaff2);

            gvStaff.SetGridDesign();
            gvStaff.SetReadOnlyColumn("**");//readonly for search form 
            gvStaff.Select();
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "3")
            {
                DataGridviewBind();
                gvStaff.Select();
            }
            if (tagID == "4")
            {
                DataGridViewRow row = gvStaff.CurrentRow;
                GetGridviewData(row);
            }
            base.FunctionProcess(tagID);
        }
        private void btnStaff_F11_Click(object sender, EventArgs e)
        {
            DataGridviewBind();
            gvStaff.Select();
        }
        private void DataGridviewBind()
        {
            MasterTourokuStaff obj = new MasterTourokuStaff();
            obj.ChangeDate = changeDate_Access;
            obj.StaffCD = txtStaff1.Text;
            obj.Passward = txtStaff2.Text;//using tempory for assign data
            obj.StaffName = txtStaffName.Text;
            obj.KanaName = txtKanaName.Text;
            obj.Remarks = string.Empty;
            if (rdo_Date.Checked)
                obj.Remarks = "RevisionDate";
            if(rdo_All.Checked)
                obj.Remarks = "All";
            StaffBL objMethod = new StaffBL();
            DataTable dt = objMethod.Staff_Search(obj);
            if(dt.Columns.Contains("CurrentDay"))
            {
                if (dt.Rows.Count > 0)
                {
                    lbl_Date.Text = String.Format("{0:yyyy/MM/dd}", dt.Rows[0]["CurrentDay"]);
                    //dt.Columns.Remove("CurrentDay");
                }
                else
                {
                    ClearSession();     //HET
                }
            }
            else
            {
                if (dt.Rows.Count == 0)     //HET
                    ClearSession();
            }
           // dt.Columns.Remove("CurrentDay");
            gvStaff.DataSource = dt;
        }
        //HET
        private void ClearSession()
        {
            txtStaff1.Clear();
            txtStaff2.Clear();
            txtStaffName.Clear();
            txtKanaName.Clear();
            rdo_Date.Checked = true;
        }
        private void GetGridviewData(DataGridViewRow gvrow)
        {
            if (gvrow != null)
            {
                DataGridViewRow row = gvrow;
                staffCD = row.Cells["colStaffCD"].Value.ToString();
                changeDate = Convert.ToDateTime(row.Cells["colChangeDate"].Value.ToString()).ToString("yyyy/MM/dd");
                staffName = row.Cells["colStaffName"].Value.ToString();
            }
            this.Close();
        }

        private void gvStaff_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetGridviewData(gvStaff.Rows[e.RowIndex]);
        }

        private void gvStaff_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //if(gvStaff.Rows.Count >0 )
                if (gvStaff.CurrentCell != null)
                    GetGridviewData(gvStaff.Rows[gvStaff.CurrentCell.RowIndex]);
            }
        }
    }
}
