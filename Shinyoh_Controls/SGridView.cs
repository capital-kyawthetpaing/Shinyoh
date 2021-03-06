﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CKM_CommonFunction;

namespace Shinyoh_Controls
{
    public class SGridView : DataGridView
    {
        CommonFunction cf = new CommonFunction();
        bool UseRow = true;
        bool EditCol = false;

        bool AllReadonly = false;
        bool ForSearchForm = false;

        string HiraganaCol = string.Empty;
        string NumberCol = string.Empty;

        public int Memory_Row_Count = 0;
        public string ActionType = string.Empty;    //"F10" for btnF10 click (if your form includes to check error at the time of F10 click, you need to set "F10" value to this "ActionType" variable and then clear assigned value before F12 button click.

        public bool IsLastKeyEnter = false;

        public void SetGridDesign()
        {
            this.EnableHeadersVisualStyles = false;
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(191, 191, 191);
            this.ColumnHeadersDefaultCellStyle.Font = new Font("MS Gothic", 9, FontStyle.Bold);
            //this.BackgroundColor = Color.FromArgb(242, 242, 242);
            //this.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(221, 235, 247);
        }
        public void UseRowNo(bool val)
        {
            UseRow = RowHeadersVisible = val;
        }
        public void SetReadOnlyColumn(string colArr)
        {
            foreach (DataGridViewColumn col in Columns)
            {
                if (colArr.Equals("*"))
                {
                    SetReadOnly(col);
                    AllReadonly = true;
                }
                else if (colArr.Equals("**"))
                {
                    SetReadOnly(col);
                    ForSearchForm = true;
                }
                else
                {
                    string[] arr = colArr.Split(',');
                    ArrayList arrlst = new ArrayList();
                    arrlst.AddRange(arr);

                    if (arrlst.Contains(col.Name))
                    {
                        SetReadOnly(col);
                    }                      
                }
            }
        }
        private void SetReadOnly(DataGridViewColumn col)
        {
            col.ReadOnly = true;
            col.DefaultCellStyle.BackColor = Color.FromArgb(217, 217, 217);           
        }
        public void SetHiraganaColumn(string colArr)
        {
            HiraganaCol = colArr;
        }
        public void SetNumberColumn(string colArr)
        {
            NumberCol = colArr;
        }

        //kpt commented
        //protected override void OnEnter(EventArgs e)
        //{
        //    if (this.TopLevelControl != null )
        //    {
        //        try
        //        {
        //            (((Shinyoh.BaseForm)(((System.Windows.Forms.Form.ControlCollection)this.TopLevelControl.Controls).Owner as Form)).Controls.Find("BtnF9", true)[0] as Control).Visible = false;
        //        }
        //        catch (Exception ex) //can get catch for in some Codition
        //        {
        //            var msg = ex.Message;
        //        }
        //        this.TopLevelControl.Refresh();
        //    }
        //    base.OnEnter(e);
        //}
        protected override void OnCellEnter(DataGridViewCellEventArgs e)
        {
            if (HiraganaCol.Equals("*"))
            {
                this.ImeMode = ImeMode.Hiragana;
            }
            else
            {
                string[] arr = HiraganaCol.Split(',');
                ArrayList arrlst = new ArrayList();
                arrlst.AddRange(arr);

                DataGridViewColumn col = this.Columns[this.CurrentCell.ColumnIndex];

                if (arrlst.Contains(col.Name))
                {
                    this.ImeMode = ImeMode.Hiragana;
                }
                else
                    this.ImeMode = ImeMode.NoControl;
            }

            base.OnCellEnter(e);
        }
        protected override void OnCellBeginEdit(DataGridViewCellCancelEventArgs e)
        {
            EditCol = true;
            base.OnCellBeginEdit(e);
        }
        protected override void OnCellEndEdit(DataGridViewCellEventArgs e)
        {
            EditCol = false;
            base.OnCellEndEdit(e);
        }
        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (UseRow)
                {
                    if (e.ColumnIndex == -1 && e.RowIndex == -1)
                    {
                        //セルを描画する
                        e.Paint(e.ClipBounds, DataGridViewPaintParts.All);

                        //行番号を描画する範囲を決定する
                        //e.AdvancedBorderStyleやe.CellStyle.Paddingは無視しています
                        Rectangle indexRect = e.CellBounds;
                        indexRect.Inflate(-2, -2);
                        //行番号を描画する
                        TextRenderer.DrawText(e.Graphics,
                            "No.",
                            e.CellStyle.Font,
                            indexRect,
                            e.CellStyle.ForeColor,
                            TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
                            
                        //描画が完了したことを知らせる
                        e.Handled = true;
                    }
                    //列ヘッダーかどうか調べる
                    if (e.ColumnIndex < 0 && e.RowIndex >= 0)
                    {
                        //セルを描画する
                        e.Paint(e.ClipBounds, DataGridViewPaintParts.All);

                        //行番号を描画する範囲を決定する
                        //e.AdvancedBorderStyleやe.CellStyle.Paddingは無視しています
                        Rectangle indexRect = e.CellBounds;
                        indexRect.Inflate(-2, -2);
                        //行番号を描画する
                        TextRenderer.DrawText(e.Graphics,
                            (e.RowIndex + 1).ToString(),
                            e.CellStyle.Font,
                            indexRect,
                            e.CellStyle.ForeColor,
                            TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
                        //描画が完了したことを知らせる
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {            
            base.OnKeyPress(e);
        }

        protected override void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= Col_Keypress;
            DataGridViewColumn col = this.Columns[this.CurrentCell.ColumnIndex];
            if (NumberCol.Contains(col.Name))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Col_Keypress);
                }
            }

            base.OnEditingControlShowing(e);
        }

        private void Col_Keypress(object sender,KeyPressEventArgs e)
        {
            e.Handled = !cf.IsNumberKey(e.KeyChar, true);
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            IsLastKeyEnter = false;
            if (keyData == Keys.Enter)
            {
                if(EditCol == false)
                {
                    if(ForSearchForm)
                        return base.ProcessCmdKey(ref msg, keyData);
                    else if (!AllReadonly)
                        MoveNextCell();
                }
                else
                {
                    IsLastKeyEnter = true;
                    this.EndEdit();
                }
                
                return true;
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }
        public void MoveNextCell()
        {
            //ktp added -- to prevent infinite loop when all columns are readonly
            Control[] ctlmode = this.TopLevelControl.Controls.Find("cboMode", true);
            if (ctlmode.Length > 0)
            {
                SCombo cbo = this.TopLevelControl.Controls.Find("cboMode", true)[0] as SCombo;
                if (cbo.SelectedValue.Equals("3") || cbo.SelectedValue.Equals("4"))//all col readonly
                    return;
            }

            if(this.CurrentCell != null)
            {
                int icolumn = this.CurrentCell.ColumnIndex;
                int irow = this.CurrentCell.RowIndex;
                bool found = false;
                bool canrowIncrease = true;
                while (!found)
                {
                    if (irow == this.Rows.Count - 1)
                    {
                        canrowIncrease = false;
                    }
                    if (icolumn == this.Columns.Count - 1)
                    {
                        if (canrowIncrease)
                            irow++;
                        else
                            irow = 0;
                        icolumn = 0;
                    }
                    else
                        icolumn++;


                    if (this[icolumn, irow].Visible == true && this[icolumn, irow].ReadOnly == false)
                    {
                        found = true;
                    }
                }
                this.CurrentCell = this[icolumn, irow];
            }
            
        }

        protected override void OnCellMouseDoubleClick(DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex >= 0)
                base.OnCellMouseDoubleClick(e);
        }
        public bool IsErrorOccurs { get; set; }
        public string ISRowColumn { get; set; }

        public bool ErrorCheck([Optional] string ChangeDate)
        {
            SGridView svg = this;
            //Creating DataTable.
            DataTable dt = svg.DataSource as DataTable;
            (IsErrorOccurs, ISRowColumn) = DataTable_ErrorCheck(svg.Memory_Row_Count,dt,svg.Name,ChangeDate);
            if (IsErrorOccurs)
            {
                if (!string.IsNullOrEmpty(ISRowColumn))
                {
                    svg.CurrentCell = svg.Rows[Convert.ToInt32(ISRowColumn.Split('_')[0])].Cells[Convert.ToInt32(ISRowColumn.Split('_')[1])];
                    svg.BeginEdit(true);
                }
            }
            return IsErrorOccurs;
        }

       public (bool,string) DataTable_ErrorCheck(int memory_row,DataTable dt,string grid_name, [Optional] string ChangeDate)
        {
            bool error_Occur = false;
            string row_col = string.Empty;
            GridView_ErrorCheck gv_error = new GridView_ErrorCheck();
            if (grid_name.Contains("JuchuuNyuuryoku"))
            {
              (error_Occur, row_col) = gv_error.JuchuuNyuuryoku(memory_row,dt, ChangeDate);
            }
            return (error_Occur,row_col);
        }

    }
}
