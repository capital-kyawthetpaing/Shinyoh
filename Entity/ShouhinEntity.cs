using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ShouhinEntity : BaseEntity
    {
        public string Product { get; set; }
        public string Product1 { get; set; }
        public string RevisionDate { get; set; }
        public string CopyProduct { get; set; }
        public string CopyRevisionDate { get; set; }
        public int ShokutiFLG { get; set; }
        public string ProductName { get; set;  }
        public string ShouhinRyakuName { get; set; }
        public string KatakanaName { get; set; }
        public string JANCD { get; set; }
        public string JANCD1 { get; set; }
        public string Exhibition { get; set; }
        public string Exhibition1 { get; set; }
        public string SS { get; set; }
        public string FW { get; set; }
        public string TaniCD { get; set; }
        public string BrandCD { get; set; }
        public string BrandCD1 { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string JoudaiTanka { get; set; }
        public string GedaiTanka { get; set; }
        public string HyoujunGenkaTanka { get; set; }
        public int ZeirituKBN { get; set; }
        public int ZaikoHyoukaKBN { get; set; }
        public int ZaikoKanriKBN { get; set; }
        public string MainSiiresakiCD { get; set; }
        public string ToriatukaiShuuryouDate { get; set; }
        public string HanbaiTeisiDate { get; set; }
        public string Model_No { get; set; }
        public string Model_Name { get; set; }
        public string FOB { get; set; }
        public string Shipping_Place { get; set; }
        public decimal HacchuuLot { get; set; }
        public string ImageFilePathName { get; set; }
        public string Image { get; set; }
        public string Remarks { get; set; }
        public int KensakuHyouziJun { get; set; }
        public int UsedFlag { get; set; }
        public int DisplayTarget { get; set; }
    }
}
