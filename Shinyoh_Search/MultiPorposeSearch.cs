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
    public partial class MultiPorposeSearch : SearchBase
    {
        public string Id = string.Empty;
        public string Key = string.Empty;
        public string Char1 = string.Empty;
        public string Char2 = string.Empty;

        public string Access_Type;
        public string Access_Key;
        public MultiPorposeSearch()
        {
            InitializeComponent();
           // gvMultiporpose.ScrollBars = ScrollBars.Vertical;
            gvMultiporpose.ScrollBars = ScrollBars.Both;
        }

        private void MultiPorposeSearch_Load(object sender, EventArgs e)
        {
            txtID1.Text = Access_Type;
            txtID2.Text = Access_Type;
            txtKey1.Text = Access_Key;
            txtKey2.Text = Access_Key;

            SetButton(ButtonType.BType.Close, F1, "戻る(F1)", true);
            SetButton(ButtonType.BType.Normal, F9, "", false);
            SetButton(ButtonType.BType.Search, F11, "表示(F11)", true);
            SetButton(ButtonType.BType.Save, F12, "確定(F12)", true);
            gvMultiporpose.UseRowNo(true);
            Access_Type = string.Empty;
            GridViewBind();
            txtID2.E106Check(true, txtID1, txtID2);
            txtKey2.E106Check(true, txtKey1, txtKey2);
            gvMultiporpose.Select();
            gvMultiporpose.SetGridDesign();
            gvMultiporpose.SetReadOnlyColumn("**");//readonly for search form 
            txtID1.Focus();
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "3")
            {
                GridViewBind();
            }
            if (tagID == "4")
            {
                DataGridViewRow row = gvMultiporpose.CurrentRow;
                GetGridviewData(row);
            }
            base.FunctionProcess(tagID);
        }
        private void GridViewBind()
        {
            multipurposeBL bl = new multipurposeBL();
            multipurposeEntity mentity = new multipurposeEntity();
            mentity.ID1 = txtID1.Text;
            mentity.ID2 = txtID2.Text;
            mentity.Key1 = txtKey1.Text;
            mentity.Key2 = txtKey2.Text;
            mentity.IdName = txtIDName.Text;
            mentity.Type = Access_Type;
            DataTable dt = bl.M_Multiporpose_Search(mentity);
            gvMultiporpose.DataSource = dt;
            if(dt.Rows.Count == 0)    //HET
            {
                ClearSession();
            }
        }
        //HET
        private void ClearSession()
        {
            txtID1.Clear();
            txtID2.Clear();
            txtKey1.Clear();
            txtKey2.Clear();
            txtIDName.Clear();
            txtID1.Focus();
        }
        private void GetGridviewData(DataGridViewRow gvrow)
        {
            if (gvrow != null)
            {
                DataGridViewRow row = gvrow;
                Id = gvMultiporpose.CurrentRow.Cells["colID"].Value.ToString();
                Key = gvMultiporpose.CurrentRow.Cells["colKey"].Value.ToString();
                Char1 = gvMultiporpose.CurrentRow.Cells["colChar1"].Value.ToString();
                Char2 = gvMultiporpose.CurrentRow.Cells["colChar2"].Value.ToString();
            }
            this.Close();
        }
        private void gvMultiporpose_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                GetGridviewData(gvMultiporpose.Rows[e.RowIndex]);
            }
        }
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            Access_Type = string.Empty;
            GridViewBind();
            //gvMultiporpose.Focus();       //comment close HET
        }

        private void gvMultiporpose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(gvMultiporpose.CurrentCell!=null)
                GetGridviewData(gvMultiporpose.Rows[gvMultiporpose.CurrentCell.RowIndex]);
            }
        }
    }
}
