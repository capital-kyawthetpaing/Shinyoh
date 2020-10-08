using System.Data.SqlClient;

namespace Entity
{
    public class BaseEntity
    {
        public string SPName { get; set; }
        public SqlParameter[] Sqlprms { get; set; }
        public string LoginDate { get; set; }
        public string PC { get; set; }
    }
}
