using MediCareNetworksBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedicareNetworksCommon.Models;

namespace MediCareNetworks.Controllers
{
    public class ClientController : BaseController
    {
        //
        // GET: /Client/
        ClientBLL _clientBLL = new ClientBLL();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddClient() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateClient(FormCollection form)
        {
            Client.Clients obj = new Client.Clients();

            obj.ID = Convert.ToInt32(form["ClientID"].ToString());
            obj.Name = form["txtName"].ToString();
            obj.PersonName = form["txtperson"].ToString();
            obj.MobileNo = form["txtMobileNumber"].ToString();
            obj.ContactNo = form["txtOfficeNo"].ToString();
            obj.Address = form["txtAddress"].ToString();            
            obj.RatingID = Convert.ToInt32(form["optionsRadios"].ToString());
            int RadioValue = Convert.ToInt32(form["optionsRadios"].ToString());
            if (RadioValue == 1)
                obj.Rating = "Bad";
            else if (RadioValue == 2)
                obj.Rating = "Fair";
            else if (RadioValue == 3)
                obj.Rating = "Good";
            else if (RadioValue == 4)
                obj.Rating = "Best";
            else if (RadioValue == 5)
                obj.Rating = "Excellent";
            obj.Comments = form["txtComment"].ToString();
            obj.CreationID = Convert.ToInt32(Session["UserID"].ToString());
            obj.CreationIP = Request.UserHostAddress;

            int result = _clientBLL.AddClient(obj);
            if (result == 1)
                return RedirectToAction("ClientList");
            else
                return RedirectToAction("AddClient");
        }

        public ActionResult ClientList() 
        {
            List<Client.Clients> list =  _clientBLL.GetAllClients();
            return View(list);
        }

        public ActionResult Edit(int id)
        {
            Client.Clients obj = _clientBLL.GetSingleClients(id);
            return View(obj);
        }

        public ActionResult UpdateClient(FormCollection form)
        {
            Client.Clients obj = new Client.Clients();

            obj.ID = Convert.ToInt32(form["ClientID"].ToString());
            obj.Name = form["txtName"].ToString();
            obj.PersonName = form["txtperson"].ToString();
            obj.MobileNo = form["txtMobileNumber"].ToString();
            obj.ContactNo = form["txtOfficeNo"].ToString();
            obj.Address = form["txtAddress"].ToString();
            obj.RatingID = Convert.ToInt32(form["optionsRadios"].ToString());
            int RadioValue = Convert.ToInt32(form["optionsRadios"].ToString());
            if (RadioValue == 1)
                obj.Rating = "Bad";
            else if (RadioValue == 2)
                obj.Rating = "Fair";
            else if (RadioValue == 3)
                obj.Rating = "Good";
            else if (RadioValue == 4)
                obj.Rating = "Best";
            else if (RadioValue == 5)
                obj.Rating = "Excellent";
            obj.Comments = form["txtComment"].ToString();
            obj.CreationID = Convert.ToInt32(Session["UserID"].ToString());
            obj.CreationIP = Request.UserHostAddress;

            int result = _clientBLL.AddClient(obj);
            if (result == 1)
                return RedirectToAction("ClientList");
            else
                return RedirectToAction("Edit/" + obj.ID);
        }

        public ActionResult Remove(int id)
        {
            int UpdatedbyID = Convert.ToInt32(Session["UserID"].ToString());
            _clientBLL.RemoveClient(id, UpdatedbyID, Request.UserHostAddress);
            return RedirectToAction("ClientList");
        }
    }
}
