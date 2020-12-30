using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKM_DataLayer;
using DL;
using System.Data;
using Entity;
using System.Data.SqlClient;
namespace BL
{
    public class Login_BL : BaseBL
    {
        //private const string IniFileName = "CKM.ini";
        ////  public static bool Islocalized =false;
        //M_Staff_DL msdl;
        //M_Store_DL mstoredl;
        //Menu_DL mdl;
        //public const bool isd = false;
        //public static bool Islocalized = false;
        //public static string Ver = "";
        //public static string SyncPath = "";
        //public static string FtpPath = "";
        //public static string ID = "";
        //public static string IP = "";
        //public static string Password = "";
        public Login_BL()
        {
            //msdl = new M_Staff_DL();
            //mstoredl = new M_Store_DL();
            //mdl = new Menu_DL();
        }
        public DataTable MH_Staff_LoginSelect(MasterTourokuStaff mts)
        {
            CKMDL ckmdl = new CKMDL();
            mts.Sqlprms = new SqlParameter[2];
            mts.Sqlprms[0] = new SqlParameter("@StaffCD", SqlDbType.VarChar) { Value = mts.StaffCD };
            mts.Sqlprms[1] = new SqlParameter("@Password", SqlDbType.VarChar) { Value = mts.Passward };
            return ckmdl.SelectDatatable("M_StaffAccess", GetConnectionString(), mts.Sqlprms);
        }
        public DataTable D_MenuMessageSelect(string SCD)
        {
            MasterTourokuStaff mts = new MasterTourokuStaff() {StaffCD =SCD };
            // return mdl.D_MenuMessageSelect(SCD);

            CKMDL ckmdl = new CKMDL();
            mts.Sqlprms = new SqlParameter[1];
            mts.Sqlprms[0] = new SqlParameter("@StaffCD", SqlDbType.VarChar) { Value = mts.StaffCD };
            return ckmdl.SelectDatatable("SMENU", GetConnectionString(), mts.Sqlprms);
        }
    }
}
