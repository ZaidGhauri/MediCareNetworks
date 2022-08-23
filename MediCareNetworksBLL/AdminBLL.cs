using MediCareNetworksDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicareNetworksCommon.Models;

namespace MediCareNetworksBLL
{
    public class AdminBLL
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        DataAccess DAL = new DataAccess();

        public Admin.LoginUser GetLoginDetail(string UserName, string Password)
        {
            string[] parameters = {"@UserName","@Password"};
            object[] paramvalues = {UserName, Password};
            dt = DAL.GetDatatable("GetLoginDetails", parameters, paramvalues);

            Admin.LoginUser obj = new Admin.LoginUser();
            if (dt.Rows.Count > 0)
            {
                obj.UserID = Convert.ToInt32(dt.Rows[0]["UserID"].ToString());
                obj.UserName = dt.Rows[0]["UserName"].ToString();
                obj.UserRoleType = dt.Rows[0]["UserRoleType"].ToString();
            }
            return obj;
        }

        public int MarkAttendance(int EmployeeID, int CreatedByID, string CreatedByIP)
        {
            string[] parameters = { "@EmployeeID", "@CreatedByID", "@CreatedByIP" };
            object[] parameterValues = { EmployeeID, CreatedByID, CreatedByIP };
            return DAL.ExecuteNonQuery("MarkAttendance", parameters, parameterValues);           
        }
    }
}
