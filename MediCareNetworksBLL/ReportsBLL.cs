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
    public class ReportsBLL
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        DataAccess DAL = new DataAccess();

        public List<Reports.EmpAttendance> GetEmpAttendance()
        {
            dt = DAL.GetDatatable("rpt_GetEmplAttendance");

            List<Reports.EmpAttendance> list = new List<Reports.EmpAttendance>();

            foreach (DataRow dr in dt.Rows)
            {
                Reports.EmpAttendance obj = new Reports.EmpAttendance();
                obj.ID = Convert.ToInt32(dr["ID"].ToString());
                obj.EmployeeID = Convert.ToInt32(dr["EMPLOYEEID"].ToString());
                obj.EmpName = dr["EMPLOYEENAME"].ToString();
                obj.CurrentDate = Convert.ToDateTime(dr["CURRENTDATE"].ToString());
                obj.Present = "Present";
                list.Add(obj);
            }
            return list;
        }
    }
}
