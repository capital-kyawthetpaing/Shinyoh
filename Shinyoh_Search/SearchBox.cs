using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shinyoh_Controls;
using System.Windows.Forms;

namespace Shinyoh_Search
{
    public class SearchBox : STextBox
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F9)
            {
                if(this.SearchType == Entity.SearchType.ScType.Souko)
                {
                    SoukoSearch soukoSearch = new SoukoSearch();
                    soukoSearch.ShowDialog();
                }
            }
        }
    }
}
