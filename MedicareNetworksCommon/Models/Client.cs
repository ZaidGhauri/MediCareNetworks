using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicareNetworksCommon.Models
{
    public class Client
    {
        public class Clients 
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string PersonName { get; set; }
            public string MobileNo { get; set; }
            public string ContactNo { get; set; }
            public string Address { get; set; }
            public string Rating { get; set; }
            public int RatingID { get; set; }
            public string Comments { get; set; }
            public int CreationID { get; set; }
            public string CreationIP { get; set; }
        }
    }
}
