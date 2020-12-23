using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shinyoh_Controls
{
    public class SGridView : DataGridView
    {
        bool UseRow = true;

        public void UseRowNo(bool val)
        {
            UseRow = RowHeadersVisible = val;
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
                            "No",
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

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            int icolumn = this.CurrentCell.ColumnIndex;
            int irow = this.CurrentCell.RowIndex;
            bool found = false;
            bool canrowIncrease = true;

            if (keyData == Keys.Enter)
            {
                while (!found)
                {
                    if(irow == this.Rows.Count - 1)
                    {
                        canrowIncrease = false;
                    }
                    if(icolumn == this.Columns.Count - 1)
                    {
                        if (canrowIncrease)
                            irow++;
                        else
                            irow = 0;
                        icolumn = 0;
                    }
                    else
                        icolumn++;
                    

                    if(this[icolumn, irow].Visible == true && this[icolumn, irow].ReadOnly == false)
                    {
                        found = true;
                    }
                }
                this.CurrentCell = this[icolumn, irow];              
                return true;
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
