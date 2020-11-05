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
        public static STextBox ChangeDate { get; set; }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            
            if(e.KeyCode == Keys.F9)
            {
                switch(this.SearchType)
                {
                    case Entity.SearchType.ScType.Souko:
                        Control cbo = this.TopLevelControl.Controls.Find("cboMode", true)[0];
                        if (cbo.Text != "新規")
                        {
                            SoukoSearch soukoSearch = new SoukoSearch();
                            soukoSearch.ShowDialog();
                            this.Text = soukoSearch.sokoCD;
                        }
                        break;
                    case Entity.SearchType.ScType.Staff:
                        Control cbo_staff = this.TopLevelControl.Controls.Find("cboMode", true)[0];
                        if (cbo_staff.Text != "新規")
                        {
                            StaffSearch staffSearch = new StaffSearch();
                            staffSearch.ShowDialog();
                            this.Text = staffSearch.staffCD;
                            ChangeDate.Text = staffSearch.changeDate;
                        }
                        break;
                }
                
            }
            if (e.KeyCode == Keys.Enter)
            {
                base.OnKeyDown(e);
            }
        }
    }
}
