using MediCareNetworksBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedicareNetworksCommon.Models;

namespace MediCareNetworks.Controllers
{
    public class EmployeeController : BaseController
    {
        EmployeeBLL employeeBLL = new EmployeeBLL();
        //
        // GET: /Employee/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add() 
        {
            ViewData["RoleTypes"] = employeeBLL.GetRoletypes();
            ViewData["AllModules"] = employeeBLL.GetAllModules();
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(FormCollection form)
        {
            Employee.Emp emp = new Employee.Emp();

            emp.ID = Convert.ToInt32(form["empID"].ToString());
            emp.Name = form["txtName"].ToString();
            emp.FatherName = form["txtFatherName"].ToString();
            emp.Nationality = form["txtNationality"].ToString();
            emp.Religion = form["txtReligion"].ToString();
            emp.DateofBirth = form["txtDateofBirth"].ToString() == "" ? Convert.ToDateTime("01-01-1990 00:00") : Convert.ToDateTime(form["txtDateofBirth"].ToString() + " 00:00");
            emp.CNIC = form["txtCNIC"].ToString();
            emp.MobileNo = form["txtMobileNumber"].ToString();
            emp.RoleTypeID = Convert.ToInt32(form["ddlRoleType"].ToString());
            emp.LoginName = form["txtUserName"].ToString();
            emp.LoginPass = form["txtPassword"].ToString();
            emp.Address = form["txtAddress"].ToString();
            emp.CreationID = Convert.ToInt32(Session["UserID"].ToString());
            emp.CreationIP = Request.UserHostAddress;
            emp.SelectedModules = form["Modulescheckbox"].ToString();

            int result = employeeBLL.AddEmployee(emp);
            if (result == 1)
                return RedirectToAction("EmployeeList");
            else
                return RedirectToAction("Add");
        }

        public ActionResult EmployeeList()
        {
            List<Employee.Emp> list = employeeBLL.GetAllEmployees();
            return View(list);
        }

        public ActionResult Edit(int id)
        {
            ViewData["RoleTypes"] = employeeBLL.GetRoletypes();
            ViewData["AllModules"] = employeeBLL.GetAllModules();
            Employee.Emp emp = employeeBLL.GetEmployeeDetail(id);
            List<Employee.Modules> modules = employeeBLL.GetEmployeeModule(id);
            Tuple<Employee.Emp, List<Employee.Modules>> tuple = new Tuple<Employee.Emp, List<Employee.Modules>>(emp, modules);
            return View(tuple);
        }

        public ActionResult UpdateEmployee(FormCollection form)
        {
            Employee.Emp emp = new Employee.Emp();

            emp.ID = Convert.ToInt32(form["empID"].ToString());
            emp.Name = form["txtName"].ToString();
            emp.FatherName = form["txtFatherName"].ToString();
            emp.Nationality = form["txtNationality"].ToString();
            emp.Religion = form["txtReligion"].ToString();
            emp.DateofBirth = form["txtDateofBirth"].ToString() == "" ? Convert.ToDateTime("01-01-1990 00:00") : Convert.ToDateTime(form["txtDateofBirth"].ToString() + " 00:00");
            emp.CNIC = form["txtCNIC"].ToString();
            emp.MobileNo = form["txtMobileNumber"].ToString();
            emp.RoleTypeID = Convert.ToInt32(form["ddlRoleType"].ToString());
            emp.LoginName = form["txtUserName"].ToString();
            emp.LoginPass = form["txtPassword"].ToString();
            emp.Address = form["txtAddress"].ToString();
            emp.SelectedModules = form["Modulescheckbox"].ToString();
            emp.CreationID = Convert.ToInt32(Session["UserID"].ToString());
            emp.CreationIP = Request.UserHostAddress;

            int result = employeeBLL.AddEmployee(emp);

            if (result != 0)
                return RedirectToAction("ViewEmployee/" + emp.ID);
            else
                return RedirectToAction("Edit/" + emp.ID);
        }

        public ActionResult ViewEmployee(int id)
        {
            ViewData["RoleTypes"] = employeeBLL.GetRoletypes();
            ViewData["AllModules"] = employeeBLL.GetAllModules();
            Employee.Emp emp = employeeBLL.GetEmployeeDetail(id);
            List<Employee.Modules> modules = employeeBLL.GetEmployeeModule(id);
            Tuple<Employee.Emp, List<Employee.Modules>> tuple = new Tuple<Employee.Emp, List<Employee.Modules>>(emp, modules);
            return View(tuple);
        }

        public ActionResult RemoveEmployee(int id)
        {
            int UpdatedbyID = Convert.ToInt32(Session["UserID"].ToString());
            employeeBLL.RemoveEmployee(id, UpdatedbyID, Request.UserHostAddress);
            return RedirectToAction("EmployeeList");
        }
    }
}
