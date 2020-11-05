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
    }
}
