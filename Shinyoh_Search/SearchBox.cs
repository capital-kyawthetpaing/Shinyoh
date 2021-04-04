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
        public SLabel lblName1 { get; set; }
        public SCombo Combo { get; set; }
        public STextBox TxtBox { get; set; }
        public STextBox TxtBox1 { get; set; }
        private string CD = string.Empty;
        private string CDate = string.Empty;
        private string colorNO = string.Empty;
        private string sizeNO = string.Empty;
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
                //to show search screen when user press enter in searchbox
                if (this.TopLevelControl != null && string.IsNullOrEmpty(CD) && string.IsNullOrEmpty(this.Text))
                {
                    Control[] ctrlArr = this.TopLevelControl.Controls.Find("BtnF9", true);
                    if (ctrlArr.Length > 0)
                    {
                        Control btnF9 = ctrlArr[0];
                        if (btnF9.Visible == true && this.E102 == true)
                            Search();
                        else
                            base.OnKeyDown(e);
                    }
                    else
                        base.OnKeyDown(e);
                }
                else
                    base.OnKeyDown(e);

                //base.OnKeyDown(e);
                if (string.IsNullOrWhiteSpace(this.Text))
                {
                    if(lblName != null)
                        lblName.Text = string.Empty;
                }
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
                    case Entity.SearchType.ScType.multiporpose:
                        colName = "Char1";
                        break;
                    case Entity.SearchType.ScType.Souko:
                        colName = "SoukoName";
                        break;
                    case Entity.SearchType.ScType.Siiresaki:
                        colName = "SiiresakiRyakuName";
                        break;
                }
                DataTable dt = this.IsDatatableOccurs;
                if(dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (lblName != null)
                        {
                            if (dt.Columns.Contains(colName))
                                lblName.Text = dt.Rows[0][colName].ToString();
                        }
                    }
                }                   
            }
        }

        public void Search()
        {
            string mode = string.Empty;
            Control[] ctlmode = this.TopLevelControl.Controls.Find("cboMode", true);
            if (ctlmode.Length > 0)
            {
                Control cbo = this.TopLevelControl.Controls.Find("cboMode", true)[0];
                mode = cbo.Text;
            }
            Control[] ctrlArr = this.TopLevelControl.Controls.Find("BtnF9", true);
            if (DepandOnMode == false || (DepandOnMode == true && mode != "新規"))
            {
                switch (this.SearchType)
                {
                    case Entity.SearchType.ScType.Souko:
                        
                        SoukoSearch soukoSearch = new SoukoSearch();
                        soukoSearch.ShowDialog();
                        CD = soukoSearch.soukoCD;
                        //CDate = soukoSearch.soukoName;
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
                        //Combo.SelectedIndex = Convert.ToInt32(denpyouSearch.renban);
                        if(!string.IsNullOrWhiteSpace(denpyouSearch.renban)) // ktp no 181 
                        {
                            Combo.SelectedValue = denpyouSearch.renban;
                            if (this.Name == "txtSEQNO")
                            {
                                TxtBox.Text = denpyouSearch.prefix;
                                TxtBox.Focus();
                                CD = denpyouSearch.seqno;
                            }
                            else
                            {
                                TxtBox.Text = denpyouSearch.seqno;
                                CD = denpyouSearch.prefix;
                            }
                        }                       
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
                        MultiPorposeSearch msearch = new MultiPorposeSearch(this.Text);                       
                        if (this.Name.Contains("Partition"))
                            msearch.Access_Type = "101";
                        else if (this.Name.Contains("Tani"))
                            msearch.Access_Type = "102";
                        else if (this.Name.Contains("Brand"))
                            msearch.Access_Type = "103";
                        else if (this.Name.Contains("Color"))
                            msearch.Access_Type = "104";
                        else if (this.Name.Contains("Size"))
                            msearch.Access_Type = "105";
                        else if (this.Name.Contains("TaxRate"))
                            msearch.Access_Type = "221";
                        else if (this.Name.Contains("Evaluation"))
                            msearch.Access_Type = "106";
                        else if (this.Name.Contains("Management"))
                            msearch.Access_Type = "107";
                        else if (this.Name.Contains("kubun"))
                            msearch.Access_Type = "109";
                        msearch.ShowDialog();
                        //CD = msearch.Id;
                        //CDate = msearch.Key;
                        if (this.Name == "txtID" || this.Name == "txtCopyID")
                            CD = msearch.Id;
                        else
                            CD = msearch.Key;
                        if (CDate != null)
                            CDate = msearch.Key;
                        if (lblName != null)
                            name = msearch.Char1;
                        break;
                    case Entity.SearchType.ScType.Kouriten:
                        KouritenSearch kSearch = new KouritenSearch();
                        kSearch.Date_Access_Kouriten = ChangeDate.Text;
                        if(this.TxtBox!=null)
                        {
                            kSearch.tokuisakiCD = TxtBox.Text;
                        }
                        kSearch.ShowDialog();
                        CD = kSearch.KouritenCD;
                        CDate = kSearch.changeDate;
                        name = kSearch.KouritenRyakuName;
                        break;
                    case Entity.SearchType.ScType.ShippingNO:
                        ShippingNoSearch snSearch = new ShippingNoSearch();
                        snSearch.ShowDialog();
                        CD = snSearch.ShippingNo;
                        break;
                    case Entity.SearchType.ScType.Shouhin:
                        Shouhin_Search shsearch = new Shouhin_Search();
                        shsearch.parent_changeDate = ChangeDate.Text;
                        shsearch.ShowDialog();
                        //if(this.Name == "txtCopyProduct")
                        //{
                        //    //CD = shsearch.shouhinCD;
                        //    CD = shsearch.hinbanCD;
                        //    TxtBox.Text = shsearch.colorNO;
                        //    TxtBox.Focus();
                        //}
                        //else
                        //{
                                //CD = shsearch.shouhinCD;ses
                                CD = shsearch.hinbanCD;
                                colorNO = shsearch.colorNO;
                                name = shsearch.colorName;
                                sizeNO = shsearch.sizeNO;
                                colName = shsearch.sizeName;
                                CDate = shsearch.changeDate;
                        //}
                        break;
                    case Entity.SearchType.ScType.ArrivalNo:
                        ArrivalNOSearch search = new ArrivalNOSearch();
                        search.ShowDialog();
                        CD = search.ChakuniNO;
                        break;
                    case Entity.SearchType.ScType.ChakuniYoteiNyuuryoku:
                        ChakuniYoteiNyuuryokuSearch cysearch = new ChakuniYoteiNyuuryokuSearch();
                        cysearch.ShowDialog();
                        CD = cysearch.ChakuniYoteiNO;
                        break;
                    case Entity.SearchType.ScType.JuchuuNo:
                        JuchuuNyuuryokuSearch obj_search = new JuchuuNyuuryokuSearch();
                        obj_search.ShowDialog();
                        CD = obj_search.JuchuuNo;
                        break;
                    case Entity.SearchType.ScType.ShukkaNo:
                        ShukkaNoSearch  shukkaNoSearch = new ShukkaNoSearch();
                        shukkaNoSearch.ShowDialog();
                        CD = shukkaNoSearch.ShukkaNo;
                        break;
                    case Entity.SearchType.ScType.IdouNyuuryoku:
                        IdouNyuuryokuSearch idou_search = new IdouNyuuryokuSearch();
                        idou_search.ShowDialog();
                        CD = idou_search.IdouNo;
                        break;
                    case Entity.SearchType.ScType.HacchuuNyuuryoku:
                        HacchuuNyuuryokuSearch hacc_search = new HacchuuNyuuryokuSearch();
                        hacc_search.ShowDialog();
                        CD = hacc_search.HacchuuNo;
                        break;
                }

                if(!string.IsNullOrWhiteSpace(CD))
                {
                    this.Text = CD;

                    if (lblName != null)
                    {
                        lblName.Text = name;
                    }

                    if (this.Parent.Name.Equals("PanelTitle"))
                    {
                        if (TxtBox != null && TxtBox1 != null)
                        {
                            TxtBox.Text = colorNO;
                            lblName.Text = name;
                            TxtBox1.Text = sizeNO;
                            lblName1.Text = colName;
                        }
                        if (ChangeDate != null)
                        {
                            ChangeDate.Text = CDate;
                            ChangeDate.Focus();
                        }
                        SendKeys.Send("{ENTER}");
                    }
                    else
                    {
                        SendKeys.Send("{ENTER}");
                    }
                }

                CD = string.Empty;            // For enter case to show search screen
                

                ////for combo box
                //if (Combo != null)
                //{
                //    ChangeDate.Text = CDate;
                //    //SendKeys.Send("{ENTER}");
                //}
                ////for textbox 
                //if (lblName != null)
                //{
                //    lblName.Text = name;
                //    //SendKeys.Send("{ENTER}");
                //}
                //else if (ChangeDate != null)
                //{
                //    if (ChangeDate.Name == this.NextControlName)
                //        ChangeDate.Text = CDate;
                //    if (string.IsNullOrEmpty(this.Text))
                //    {
                //        this.Focus();
                //    }
                //    else
                //    {
                //        //comment 2020-12-28
                //        //ChangeDate.Focus();
                //        //SendKeys.Send("{ENTER}");
                //        //add 2020-12-28
                //        //CD and change date is not located(top,down) in form design
                //        if (this.NextControlName != ChangeDate.Name)
                //        {
                //            this.Focus();
                //        }
                //        else
                //        {
                //            ChangeDate.Focus();
                //        }
                //        SendKeys.Send("{ENTER}");
                //    }
                //}
                //else
                //{
                //    if(this.Text=="")
                //    {
                //        this.Focus();
                //    }
                //    else
                //    {
                //        Control control = this.TopLevelControl.Controls.Find(this.NextControlName, true)[0];
                //        control.Focus();
                //    }
                //}
            }            
        }

        protected override void OnLeave(EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Text))
            {
                if(lblName != null)
                    lblName.Text = string.Empty;
            }
            base.OnLeave(e);
        }
    }
}
