using Phone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phone.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Area()
        {
            return View();
        }


        public ActionResult Operator()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Msg(passContact log)
        {

            DBClass objConnection = new DBClass();
            String query = "insert into Contact(Name,Email,Msg) values('" + log.txtName + "','" + log.txtEmail + "','" + log.txtMsg + "')";
            objConnection.srchRecord(query);
            return View("Message");


        }

    }
}