using MediCareNetworksBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using MedicareNetworksCommon.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace MediCareNetworks.Controllers
{
    public class ReportsController : BaseController
    {
        ReportsBLL _reportBLL = new ReportsBLL();
        //
        // GET: /Reports/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EmployeeAttendance()
        {
            return View();
        }

        public ActionResult GetEmployeeAttendance([DataSourceRequest]DataSourceRequest request)
        {
            return Json(_reportBLL.GetEmpAttendance().ToDataSourceResult(request));
        }
    }
}
