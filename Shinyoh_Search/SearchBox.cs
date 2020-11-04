using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shinyoh_Controls;
using System.Windows.Forms;
using Entity;

namespace Shinyoh_Search
{
    public class SearchBox : STextBox
    {
        protected STextBox changeDate { get; set; }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            
            if(e.KeyCode == Keys.F9)
            {
                switch(this.SearchType)
                {
                    case Entity.SearchType.ScType.Souko:
                        SoukoSearch soukoSearch = new SoukoSearch();
                        soukoSearch.ShowDialog();
                        this.Text = soukoSearch.sokoCD;
                        break;
                    case Entity.SearchType.ScType.Staff:
                        StaffSearch staffSearch = new StaffSearch();
                        staffSearch.ShowDialog();
                        this.Text = staffSearch.staffCD;
                        changeDate.Text = staffSearch.changeDate;
                        break;
                }
                
            }
        }
    }
}
