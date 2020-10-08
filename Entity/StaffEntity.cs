using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class StaffEntity : BaseEntity
    {
        public string StaffCD { get; set; }
        public string StaffName { get; set; }
        public string ProgramID { get; set; }
    }
}
