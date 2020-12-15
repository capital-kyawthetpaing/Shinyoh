using CKM_DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class ShukkasiziNyuuryokuBL : BaseBL
    {
        CKMDL ckmdl;
        public ShukkasiziNyuuryokuBL()
        {
            ckmdl = new CKMDL();
        }
        public DataTable ShukkasiziNyuuryoku_ErrorCheck(string ShippingNO, string error_Type)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@ShippingNo", SqlDbType.VarChar) { Value = ShippingNO };
            //parameters[1] = new SqlParameter("@ShippingDate", SqlDbType.Date) { Value = Shippingdate };
            parameters[1] = new SqlParameter("@Errortype", SqlDbType.VarChar) { Value = error_Type };
            DataTable dt = ckmdl.SelectDatatable("ShukkasiziNyuuryoku_ErrorCheck_Select", GetConnectionString(), parameters);
            return dt;
        }
        public DataTable ShukkasiziNyuuryoku_Data_Select(string ShippingNO, string ShippingDate, int type)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@ShippingNo", SqlDbType.VarChar) { Value = ShippingNO };
            parameters[1] = new SqlParameter("@ShippingDate", SqlDbType.Date) { Value = ShippingDate };
            parameters[2] = new SqlParameter("@Type", SqlDbType.TinyInt) { Value = type };
            DataTable dt = ckmdl.SelectDatatable("ShukkasiziNyuuryoku_Data_Select", GetConnectionString(), parameters);
            return dt;
        }
        public DataTable ShukkasiziNyuuryoku_Display(ShukkaSiziNyuuryokuEntity se, int type)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@TokuisakiCD", SqlDbType.VarChar) { Value = se.TokuisakiCD };
            parameters[1] = new SqlParameter("@JuchuuNO", SqlDbType.VarChar) { Value = se.JuchuuNO };
            parameters[2] = new SqlParameter("@SenpouHacchuuNO", SqlDbType.VarChar) { Value = se.SenpyouhachuuNo };
            parameters[3] = new SqlParameter("@Type", SqlDbType.TinyInt) { Value = type };
            parameters[4] = new SqlParameter("@ShippingDate", SqlDbType.Date) { Value = se.ShippingDate};
            DataTable dt = ckmdl.SelectDatatable("ShukkasiziNyuuryoku_Display", GetConnectionString(), parameters);
            return dt;
        }
        public DataTable ShippingNO_Search(ShukkaSiziNyuuryokuEntity sksze)
        {
            CKMDL ckmdl = new CKMDL();
            sksze.Sqlprms = new SqlParameter[11];

            sksze.Sqlprms[0] = new SqlParameter("@ShukkaYoteiDate_From", SqlDbType.Date) { Value = sksze.ShukkaYoteiDate_From };
            sksze.Sqlprms[1] = new SqlParameter("@ShukkaYoteiDate_To", SqlDbType.Date) { Value = sksze.ShukkaYoteiDate_To };
            sksze.Sqlprms[2] = new SqlParameter("@TokuisakiCD", SqlDbType.VarChar) { Value = sksze.TokuisakiCD };
            sksze.Sqlprms[3] = new SqlParameter("@StaffCD", SqlDbType.VarChar) { Value = sksze.StaffCD };
            sksze.Sqlprms[4] = new SqlParameter("@ShouhinName", SqlDbType.VarChar) { Value = sksze.ShouhinName };
            sksze.Sqlprms[5] = new SqlParameter("@DenpyouDate_From", SqlDbType.Date) { Value = sksze.DenpyouDate_From };
            sksze.Sqlprms[6] = new SqlParameter("@DenpyouDate_To", SqlDbType.Date) { Value = sksze.DenpyouDate_To };
            sksze.Sqlprms[7] = new SqlParameter("@ShukkaSiziNO_From", SqlDbType.VarChar) { Value = sksze.ShukkaSiziNO_From };
            sksze.Sqlprms[8] = new SqlParameter("@ShukkaSiziNO_To", SqlDbType.VarChar) { Value = sksze.ShukkaSiziNO_To};
            sksze.Sqlprms[9] = new SqlParameter("@ShouhinCD_From", SqlDbType.VarChar) { Value = sksze.ShouhinCD_From };
            sksze.Sqlprms[10] = new SqlParameter("@ShouhinCD_To", SqlDbType.VarChar) { Value = sksze.ShouhinCD_To };

            DataTable dt = ckmdl.SelectDatatable("ShippingNO_Search", GetConnectionString(), sksze.Sqlprms);
            return dt;
        }

    }
}
