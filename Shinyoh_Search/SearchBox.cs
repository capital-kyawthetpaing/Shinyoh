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
            //if (!this.IsErrorOccurs && ChangeDate == null)
            if (!this.IsErrorOccurs)
            {
                switch (this.SearchType)
                {
                    case Entity.SearchType.ScType.Staff:
                        colName = "StaffName";
                        break;
                    case Entity.SearchType.ScType.Tokuisaki:
                        colName = "TokuisakiRyakuName";
                        break;
                    case Entity.SearchType.ScType.Kouriten:
                        colName = "KouritenRyakuName";
                        break;
                }

                DataTable dt = this.IsDatatableOccurs;
                if (dt.Rows.Count > 0)
                {
                    if(lblName!=null)
                    {
                        if(dt.Columns.Contains(colName))
                        lblName.Text = dt.Rows[0][colName].ToString();
                    }
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
                        staffSearch.changeDate_Access = ChangeDate.Text;
                        staffSearch.ShowDialog();
                        CD = staffSearch.staffCD;
                        CDate = staffSearch.changeDate;
                        name = staffSearch.staffName;
                        break;
                    case Entity.SearchType.ScType.Denpyou:
                        DenpyouNoSearch denpyouSearch = new DenpyouNoSearch();
                        denpyouSearch.ShowDialog();
                        Combo.SelectedIndex = Convert.ToInt32(denpyouSearch.renban);
                        CDate = denpyouSearch.seqno;
                        CD = denpyouSearch.prefix;
                        break;
                    case Entity.SearchType.ScType.Siiresaki:
                        SiiresakiSearch siiresakiSearch = new SiiresakiSearch();
                        siiresakiSearch.Date_Access_Siiresaki = ChangeDate.Text;
                        siiresakiSearch.ShowDialog();
                        CD = siiresakiSearch.SiiresakiCD;
                        CDate = siiresakiSearch.changeDate;
                        break;
                    case Entity.SearchType.ScType.Tokuisaki:
                        TokuisakiSearch tokuisakiSearch = new TokuisakiSearch();
                        tokuisakiSearch.Date_Access_Tokuisaki = ChangeDate.Text;
                        tokuisakiSearch.ShowDialog();
                        CD = tokuisakiSearch.Tokuisaki;
                        CDate = tokuisakiSearch.ChangeDate;
                        name = tokuisakiSearch.TokuisakiRyakuName;
                        break;
                    case Entity.SearchType.ScType.multiporpose:
                        MultiPorposeSearch msearch = new MultiPorposeSearch();
                        msearch.ShowDialog();
                        if(this.Name== "txtID")
                            CD = msearch.Id;
                        else
                            CD = msearch.Key;
                        break;
                    case Entity.SearchType.ScType.Kouriten:
                        KouritenSearch kSearch = new KouritenSearch();
                        kSearch.Date_Access_Kouriten = ChangeDate.Text;
                        kSearch.ShowDialog();
                        CD = kSearch.KouritenCD;
                        CDate = kSearch.changeDate;
                        name = kSearch.KouritenRyakuName;
                        break;
                    case Entity.SearchType.ScType.ShippingNO:
                        ShippingNoSearch snSearch = new ShippingNoSearch();
                        //snSearch.changeDate_Access = ChangeDate.Text;
                        snSearch.ShowDialog();
                        CD = snSearch.ShippingNo;
                        CDate = snSearch.changeDate;
                        break;
                }

                this.Text = CD;
                //for combo box
                if (Combo != null)
                {
                    ChangeDate.Text = CDate;
                    SendKeys.Send("{ENTER}");
                }
                //for textbox 
                if (lblName != null)
                {
                    lblName.Text = name;
                    SendKeys.Send("{ENTER}");
                }
                else if (ChangeDate != null)
                {
                    if (ChangeDate.Name == this.NextControlName)
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
                    if(this.Text=="")
                    {
                        this.Focus();
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
}
