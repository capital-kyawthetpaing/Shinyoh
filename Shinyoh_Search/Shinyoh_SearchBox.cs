using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shinyoh_Controls;

namespace Shinyoh_Search
{
    public class Shinyoh_SearchBox : TextBox
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                ////if(this.SearchType == Entity.SearchType.ScType.Souko)
                ////{
                ////    SoukoSearch soukoSearch = new SoukoSearch();
                ////    soukoSearch.ShowDialog();
                ////}
            }
        }
         
    }
}
