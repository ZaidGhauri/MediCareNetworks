using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicareNetworksCommon.Models
{
    public class Dashboard
    {
        public class Module
        {
            public int ModueID { get; set; }
            public string ModuleName { get; set; }
            public string ModulePath { get; set; }
            public bool IsDisplay { get; set; }
        }

        public class SubModule
        {
            public int SubModuleID { get; set; }
            public string SubModules { get; set; }
            public string SubModulePath { get; set; }
            public int ModuleID { get; set; }
            public bool IsDisplay { get; set; }
        }
    }
}
