using MediCareNetworksBLL;
using MedicareNetworksCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCareNetworks.Controllers
{
    public class AdminController : BaseController
    {
        EmployeeBLL _empBLL = new EmployeeBLL();
        AdminBLL _adminBLL = new AdminBLL();
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EmpAttendance() 
        {
            List<Employee.Emp> list = _empBLL.GetAllEmployees();
            return View(list);
        }

        public ActionResult MarkAttendance(FormCollection form)
        {
            int EmployeeID = Convert.ToInt32(form["ddlEmployees"].ToString());
            int CreationID = Convert.ToInt32(Session["UserID"].ToString());
            string CreationIP = Request.UserHostAddress;
            int result = _adminBLL.MarkAttendance(EmployeeID, CreationID, CreationIP);
            return RedirectToAction("EmpAttendance");
        }

        public ActionResult Dashboard()
        {
            //ViewData["RoleTypes"] = _adminBLL.GetModules();
            return View();
        }
    }
}
