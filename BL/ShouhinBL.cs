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
    public class ShouhinBL : BaseBL
    {
        public string Shouhin_IUD(ShouhinEntity shouhin_entity)
        {
            CKMDL ckmdl = new CKMDL();
            shouhin_entity.Sqlprms = new SqlParameter[1];
            return ckmdl.InsertUpdateDeleteData("sp_Shouhin_IUD", GetConnectionString(), shouhin_entity.Sqlprms);
        }
    }
}
