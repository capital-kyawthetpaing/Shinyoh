using System.Data.SqlClient;
using System;

namespace Entity
{
    public class BaseEntity
    {
        public string SPName { get; set; }
        public SqlParameter[] Sqlprms { get; set; }
        public string LoginDate { get; set; }
        public string PC { get; set; }
        public string Mode { get; set; }
        public string MessageID { get; set; }
        public string OperatorCD { get; set; }
        public string ProgramID { get; set; }
        public string InsertOperator { get; set; }
        public DateTime InsertDateTime { get; set; }
        public string UpdateOperator { get; set; }
        public DateTime UpdateDateTime { get; set; }
        //for Log Table
        public string KeyItem { get; set; }
    }
}
