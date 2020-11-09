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
    public class multipurposeBL : BaseBL
    {
        CKMDL ckmdl;

        public DataTable GetMenu()
        {
            ckmdl = new CKMDL();
            var parameters = new SqlParameter[] { };
            DataTable dt = ckmdl.SelectDatatable("M_Menu_Select", GetConnectionString(), parameters);
            return dt;
        }

        public DataTable GetAuthorization()
        {
            ckmdl = new CKMDL();
            var parameters = new SqlParameter[] { };
            DataTable dt = ckmdl.SelectDatatable("M_Authorization_Select", GetConnectionString(), parameters);
            return dt;
        }

        public DataTable GetPosition(multipurposeEntity multipurpose_entity)
        {
            ckmdl = new CKMDL();
            multipurpose_entity.Sqlprms = new SqlParameter[1];
            multipurpose_entity.Sqlprms[0] = new SqlParameter("@id", DbType.Int32) { Value = multipurpose_entity.id };
            DataTable dt = ckmdl.SelectDatatable("M_MultiPorpose_Select", GetConnectionString(), multipurpose_entity.Sqlprms );
            return dt;
        }
    }
}
