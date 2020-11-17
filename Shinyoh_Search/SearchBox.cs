using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shinyoh_Controls;
using System.Windows.Forms;
using Entity;
using System.Data;

namespace Shinyoh_Search
{
    public class SearchBox : STextBox
    {
        public STextBox ChangeDate { get; set; }
        public SLabel lblName { get; set; }
        public SCombo Combo { get; set; }
        private string CD = string.Empty;
        private string CDate = string.Empty;
        private string name = string.Empty;
        private string colName = string.Empty;
        protected override void OnKeyDown(KeyEventArgs e)
        {         
            if(e.KeyCode == Keys.F9)
            {
                Search();               
            }
            if (e.KeyCode == Keys.Enter)
            {              
                base.OnKeyDown(e);
                DataSelect();
            }
        }        

        public void DataSelect()
        {
            if (!this.IsErrorOccurs && ChangeDate == null)
            {
                switch (this.SearchType)
                {
                    case Entity.SearchType.ScType.Staff:
                        colName = "StaffName";
                        break;
                }

                DataTable dt = this.IsDatatableOccurs;
                if (dt.Rows.Count > 0)
                {
                    if(lblName!=null)
                        lblName.Text = dt.Rows[0][colName].ToString();
                }                   
            }
        }

        public void Search()
        {
            Control cbo = this.TopLevelControl.Controls.Find("cboMode", true)[0];
            if(DepandOnMode == false || (DepandOnMode == true && cbo.Text != "新規"))
            {
                switch (this.SearchType)
                {
                    case Entity.SearchType.ScType.Souko:
                        SoukoSearch soukoSearch = new SoukoSearch();
                        soukoSearch.ShowDialog();
                        CD = soukoSearch.soukoCD;
                        //this.CD = soukoSearch.soukoCD;
                        break;
                    case Entity.SearchType.ScType.Staff:
                        StaffSearch staffSearch = new StaffSearch();
                        staffSearch.ShowDialog();
                        CD = staffSearch.staffCD;
                        CDate = staffSearch.changeDate;
                        name = staffSearch.staffName;
                        break;
                    case Entity.SearchType.ScType.Denpyou:
                        DenpyouNoSearch denpyouSearch = new DenpyouNoSearch();
                        denpyouSearch.ShowDialog();
                        Combo.SelectedIndex = Convert.ToInt32(denpyouSearch.renban);
                        CD = denpyouSearch.seqno;
                        CDate = denpyouSearch.prefix;
                        break;
                    case Entity.SearchType.ScType.Siiresaki:
                        SiiresakiSearch siiresakiSearch = new SiiresakiSearch();
                        siiresakiSearch.ShowDialog();
                        CD = siiresakiSearch.SiiresakiCD;
                        CDate = siiresakiSearch.changeDate;
                        break;
                    case Entity.SearchType.ScType.Tokuisaki:
                        TokuisakiSearch tokuisakiSearch = new TokuisakiSearch();
                        tokuisakiSearch.ShowDialog();
                        CD = tokuisakiSearch.Tokuisaki;
                        CDate = tokuisakiSearch.ChangeDate;
                        break;
                    case Entity.SearchType.ScType.multiporpose:
                        MultiPorposeSearch msearch = new MultiPorposeSearch();
                        msearch.ShowDialog();
                        if(this.Name== "txtID")
                            CD = msearch.Id;
                        else
                            CD = msearch.Key;
                        break;
                }

                this.Text = CD;
                if (lblName != null)
                {
                    lblName.Text = name;
                }
                if (Combo != null)
                {
                    ChangeDate.Text = CDate;
                    this.ctrlE133_1 = ChangeDate;
                    this.ctrlE102_c = Combo;
                    SendKeys.Send("{ENTER}");
                }
                else if (ChangeDate != null)
                {
                    ChangeDate.Text = CDate;
                    if (string.IsNullOrEmpty(this.Text))
                    {
                        this.Focus();
                    }
                    else
                    {
                        ChangeDate.Focus();
                        SendKeys.Send("{ENTER}");
                    }
                }
                else
                {
                    Control control = this.TopLevelControl.Controls.Find(this.NextControlName, true)[0];
                    control.Focus();
                }
            }            
        }
    }
}
