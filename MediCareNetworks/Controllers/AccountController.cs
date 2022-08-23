using MediCareNetworksBLL;
using MedicareNetworksCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCareNetworks.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        AdminBLL adminBLL = new AdminBLL();        

        public ActionResult Index()
        {
            if (TempData["loginError"] != null)
                ViewData["loginError"] = TempData["loginError"].ToString();
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form) 
        {
            string username = form["txtusername"].ToString();
            string password = form["txtpassword"].ToString();

            if (username == "" || password == "")
            {
                TempData["loginError"] = "Enter UserName and Password";
                return RedirectToAction("Index");
            }
            else
            {
                Admin.LoginUser obj = adminBLL.GetLoginDetail(username, password);
                if (obj.UserName != null)
                {
                    Session["UserID"] = obj.UserID.ToString();
                    Session["UserName"] = obj.UserName.ToString();
                    Session["UserRoleType"] = obj.UserRoleType.ToString();
                    return RedirectToAction("Dashboard", "Admin");
                }
                else
                {
                    TempData["loginError"] = "Incorrect UserName or Password";
                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult LogOut() 
        {
            Session["UserID"] = null;
            Session["UserName"] = null;
            Session["UserRoleType"] = null;
            return RedirectToAction("Index");
        }
    }
}
