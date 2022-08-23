using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCareNetworksDAL;
using MedicareNetworksCommon.Models;

namespace MediCareNetworksBLL
{
    public class DashboardBLL
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        DataAccess DAL = new DataAccess();

        public Tuple<List<Dashboard.Module>, List<Dashboard.SubModule>> GetModules(int EmployeeID)
        {
            string[] parameters = { "@EmployeeID" };
            object[] paramValues = { EmployeeID };
            ds = DAL.GetDataset("GetModules", parameters, paramValues);

            Tuple<List<Dashboard.Module>, List<Dashboard.SubModule>> tuple = null;

            List<Dashboard.Module> list = new List<Dashboard.Module>();
            List<Dashboard.SubModule> list2 = new List<Dashboard.SubModule>();


            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Dashboard.Module obj = new Dashboard.Module();
                obj.ModueID = Convert.ToInt32(dr["ID"].ToString());
                obj.ModuleName = dr["MODULE"].ToString();
                obj.ModulePath = dr["MODULEPATH"].ToString();
                obj.IsDisplay = Convert.ToBoolean(dr["ISDISPLAY"].ToString());
                list.Add(obj);
            }

            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                Dashboard.SubModule obj = new Dashboard.SubModule();
                obj.SubModuleID = Convert.ToInt32(dr["ID"].ToString());
                obj.SubModules = dr["SUBMODULES"].ToString();
                obj.SubModulePath = dr["SUBMODULEPATH"].ToString();
                obj.ModuleID = Convert.ToInt32(dr["MODULEID"].ToString());
                obj.IsDisplay = Convert.ToBoolean(dr["ISDISPLAY"].ToString());
                list2.Add(obj);
            }

            tuple = new Tuple<List<Dashboard.Module>, List<Dashboard.SubModule>>(list, list2);
            return tuple;
        }
    }
}
