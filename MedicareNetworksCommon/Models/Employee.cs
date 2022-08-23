using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicareNetworksCommon.Models
{
    public class Employee
    {
        public class RoleType
        {
            public int RoletypeID { get; set; }
            public string Role { get; set; }
        }

        public class Emp
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string FatherName { get; set; }
            public string Nationality { get; set; }
            public string Religion { get; set; }
            public string CNIC { get; set; }
            public string MobileNo { get; set; }
            public string Roletype { get; set; }
            public int RoleTypeID { get; set; }
            public string Address { get; set; }
            public string LoginName { get; set; }
            public string LoginPass { get; set; }
            public bool IsActive { get; set; }
            public DateTime DateofBirth { get; set; }
            public int CreationID { get; set; }
            public string CreationIP { get; set; }
            public string SelectedModules { get; set; }
        }

        public class Modules
        {
            public int ID { get; set; }
            public string Module { get; set; }
        }       
    }
}
