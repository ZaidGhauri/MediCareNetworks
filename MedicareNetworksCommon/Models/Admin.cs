using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicareNetworksCommon.Models
{
    public class Admin
    {
        public class LoginUser 
        {
            public int UserID { get; set; }
            public string UserName { get; set; }
            public string UserRoleType { get; set; }
        }
    }
}
