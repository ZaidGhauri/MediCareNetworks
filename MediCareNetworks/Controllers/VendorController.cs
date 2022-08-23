using MediCareNetworksBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedicareNetworksCommon.Models;

namespace MediCareNetworks.Controllers
{
    public class VendorController : BaseController
    {
        //
        // GET: /Vendor/
        VendorBLL _vendorBLL = new VendorBLL();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

    }
}
