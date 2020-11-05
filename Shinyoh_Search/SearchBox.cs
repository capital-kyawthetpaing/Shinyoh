﻿using System;
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
        protected STextBox txtStaff_CDate { get; set; }
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
                        MessageBox.Show(this.NextControl.Text);
                       // this.NextControl.Text = staffSearch.changeDate;
                       // txtStaff_CDate.Text = staffSearch.changeDate;
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
