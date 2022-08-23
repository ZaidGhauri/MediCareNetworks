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
    public class EmployeeBLL
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        DataAccess DAL = new DataAccess();

        public List<Employee.RoleType> GetRoletypes()
        {
            ds = DAL.GetDataset("GetRoleTypes");

            List<Employee.RoleType> list = new List<Employee.RoleType>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Employee.RoleType obj = new Employee.RoleType();
                obj.RoletypeID = Convert.ToInt32(dr["ID"].ToString());
                obj.Role = dr["ROLETYPE"].ToString();
                list.Add(obj);
            }            
            return list;
        }

        public List<Dashboard.Module> GetAllModules()
        {
            dt = DAL.GetDatatable("GetAllModules");

            List<Dashboard.Module> list = new List<Dashboard.Module>();

            foreach (DataRow dr in dt.Rows)
            {
                Dashboard.Module obj = new Dashboard.Module();
                obj.ModueID = Convert.ToInt32(dr["ID"].ToString());
                obj.ModuleName = dr["MODULE"].ToString();
                list.Add(obj);
            }
            return list;
        }

        public List<Employee.Emp> GetAllEmployees()
        {
            ds = DAL.GetDataset("GetAllEmployees");

            List<Employee.Emp> list = new List<Employee.Emp>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Employee.Emp obj = new Employee.Emp();
                obj.ID = Convert.ToInt32(dr["ID"].ToString());
                obj.Name = dr["NAME"].ToString();
                obj.FatherName = dr["FATHERNAME"].ToString();
                obj.MobileNo = dr["MOBILENO"].ToString();
                obj.LoginName = dr["LOGINNAME"].ToString();
                obj.LoginPass = dr["LOGINPASSWORD"].ToString();
                obj.Roletype = dr["RoleType"].ToString();
                list.Add(obj);
            }
            return list;            
        }

        public int AddEmployee(Employee.Emp emp)
        {
            string[] parameters = {"@ID", "@Name", "@FatherName", "@Nationality", "@Religion",
                                   "@CNIC", "@MobileNo", "@RoleTypeID", "@Address", "@UserName",
                                   "@Password", "@DateofBirth", "@SelectedModules", "@CreationbyID", "@CreationbyIP"};

            object[] parameterValues = {emp.ID, emp.Name, emp.FatherName, emp.Nationality, emp.Religion,
                                        emp.CNIC, emp.MobileNo, emp.RoleTypeID, emp.Address, emp.LoginName,
                                        emp.LoginPass, emp.DateofBirth, emp.SelectedModules, emp.CreationID, emp.CreationIP};

            int result = DAL.ExecuteNonQuery("AddEmployee", parameters, parameterValues);
            return result;
        }

        public void RemoveEmployee(int EmployeeID, int UpdatedID, string UpdatedIP)
        {
            string[] parameters = {"@EmployeeID", "@UpdatedID", "@UpdatedIP"};
            object[] parameterValues = {EmployeeID, UpdatedID, UpdatedIP};
            DAL.ExecuteNonQuery("RemoveEmployee", parameters, parameterValues);
        }

        public Employee.Emp GetEmployeeDetail(int EmployeeID)
        {
            string[] parameters = { "@EmployeeID" };
            object[] paramValues = { EmployeeID };
            dt = DAL.GetDatatable("GetEmployeeDetail", parameters, paramValues);

            Employee.Emp obj = new Employee.Emp();

            if (dt.Rows.Count > 0)
            {
                obj.ID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                obj.Name = dt.Rows[0]["NAME"].ToString();
                obj.FatherName = dt.Rows[0]["FATHERNAME"].ToString();
                obj.Nationality = dt.Rows[0]["NATIONALITY"].ToString();
                obj.Religion = dt.Rows[0]["RELIGION"].ToString();
                obj.DateofBirth = Convert.ToDateTime(dt.Rows[0]["DATEOFBIRTH"].ToString());
                obj.CNIC = dt.Rows[0]["CNIC"].ToString();
                obj.Address = dt.Rows[0]["ADDRESS"].ToString();
                obj.Roletype = dt.Rows[0]["ROLETYPE"].ToString();
                obj.RoleTypeID = Convert.ToInt32(dt.Rows[0]["ROLETYPEID"].ToString());
                obj.MobileNo = dt.Rows[0]["MOBILENO"].ToString();
                obj.LoginName = dt.Rows[0]["LOGINNAME"].ToString();
                obj.LoginPass = dt.Rows[0]["LOGINPASSWORD"].ToString();               
            }

            return obj;
        }

        public List<Employee.Modules> GetEmployeeModule(int EmployeeID)
        {
            string[] parameters = { "@EmployeeID" };
            object[] paramValues = { EmployeeID };
            dt = DAL.GetDatatable("GetEmployeeModule", parameters, paramValues);

            List<Employee.Modules> list = new List<Employee.Modules>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Employee.Modules obj = new Employee.Modules();
                    obj.ID = Convert.ToInt32(dr["ID"].ToString());
                    obj.Module = dr["MODULE"].ToString();
                    list.Add(obj);
                }
            }

            return list;
        }
    }
}
