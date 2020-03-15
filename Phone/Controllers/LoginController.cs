using Phone.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phone.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AdminDetails()
        {
            return View();
        }

        public ActionResult Login_Check(Login Admin)
        {

            DataTable tbl = new DataTable();
            DBClass obj_connection = new DBClass();

            tbl = obj_connection.srchRecord("Select * from AdminDetails where AdminID='" + Admin.AdminID + "' and AdminPassword='" + Admin.AdminPassword + "'");
            if (tbl.Rows.Count > 0)
            {
                return View("AdminDetails");
            }
            else
            {
                return View("AdminWrong");
            }


        }
    }
}