using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediCareNetworksBLL;
using System.Data;
using MedicareNetworksCommon.Models;
using System.Web.Routing;

namespace MediCareNetworks.Controllers
{
    public class BaseController : Controller
    {        
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (requestContext.HttpContext.Session["UserID"] == null)
            {
               // RedirectToAction("Index", "Account");
                requestContext.HttpContext.Response.Clear();
                requestContext.HttpContext.Response.Redirect(Url.Action("Index", "Account"));
                requestContext.HttpContext.Response.End();
            }
            else
            {
                int UserID = Convert.ToInt32(requestContext.HttpContext.Session["UserID"].ToString());
                Tuple<List<Dashboard.Module>, List<Dashboard.SubModule>> tuple = _dashboardBLL.GetModules(UserID);
                ViewData["Module"] = tuple;
            }
        }

        //
        // GET: /Base/
        DashboardBLL _dashboardBLL = new DashboardBLL();        
        public BaseController()
        {            
            //int EmployeeID = Convert.ToInt32(Session["UserID"].ToString());
            //Tuple<List<Dashboard.Module>, List<Dashboard.SubModule>> tuple = _dashboardBLL.GetModules(UserID);
            //ViewData["Module"] = tuple;
        }        
    }
}
