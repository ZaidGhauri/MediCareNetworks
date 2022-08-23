using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicareNetworksCommon.Models
{
    public class Reports
    {
        public class EmpAttendance
        {
            public int ID { get; set; }
            public int EmployeeID { get; set; }
            public string EmpName { get; set; }
            public string Present { get; set; }
            public DateTime CurrentDate { get; set; }
        }
    }
}
