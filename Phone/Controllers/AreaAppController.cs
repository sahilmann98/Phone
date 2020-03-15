using Phone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phone.Controllers
{
    public class AreaAppController : Controller
    {
        // GET: AreaApp
        PhoneBookEntities3 obj = new PhoneBookEntities3();
        public ActionResult AreaDetails()
        {
            return View(obj.tblAreas.ToList());
        }

        // GET: AreaApp/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AreaApp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AreaApp/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] tblArea data)
        {
            if (!ModelState.IsValid)
                return View();
            obj.tblAreas.Add(data);
            obj.SaveChanges();
            return RedirectToAction("AreaDetails");


        }

        // GET: AreaApp/Edit/5
        public ActionResult Edit(int id)
        {
            var detailsToEdit = (from m in obj.tblAreas where m.id == id select m).First();
            return View(detailsToEdit);
        }

        // POST: AreaApp/Edit/5
        [HttpPost]
        public ActionResult Edit(tblArea detailsToEdit)
        {
            var orignalRecord = (from m in obj.tblAreas where m.id == detailsToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            obj.Entry(orignalRecord).CurrentValues.SetValues(detailsToEdit);

            obj.SaveChanges();
            return RedirectToAction("AreaDetails");
        }

        // GET: AreaApp/Delete/5
        public ActionResult Delete(tblArea detailsToEdit)
        {
            var d = obj.tblAreas.Where(x => x.id == detailsToEdit.id).FirstOrDefault();
            obj.tblAreas.Remove(d);
            obj.SaveChanges();
            return RedirectToAction("AreaDetails");
        }

        // POST: AreaApp/Delete/5
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
