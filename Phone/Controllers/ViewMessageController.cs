using Phone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phone.Controllers
{
    public class ViewMessageController : Controller
    {
        // GET: ViewMessage

        PhoneBookEntities4 instance = new PhoneBookEntities4();

        public ActionResult displayMessage()
        {
            return View(instance.tblContacts.ToList());
        }

        // GET: ViewMessage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ViewMessage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ViewMessage/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ViewMessage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ViewMessage/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ViewMessage/Delete/5
        public ActionResult Delete(tblContact detailsToEdit)
        {
            var d = instance.tblContacts.Where(x => x.id == detailsToEdit.id).FirstOrDefault();
            instance.tblContacts.Remove(d);
            instance.SaveChanges();
            return RedirectToAction("displayMessage");
        }

        // POST: ViewMessage/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
