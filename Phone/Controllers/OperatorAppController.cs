using Phone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phone.Controllers
{
    public class OperatorAppController : Controller
    {
        // GET: OperatorApp
        PhoneBookEntities3 obj = new PhoneBookEntities3();

        public ActionResult OperatorDetails()
        {
            return View(obj.tblOperators.ToList());
        }

        // GET: OperatorApp/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OperatorApp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OperatorApp/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] tblOperator data)
        {
            if (!ModelState.IsValid)
                return View();
            obj.tblOperators.Add(data);
            obj.SaveChanges();
            return RedirectToAction("OperatorDetails");


        }

        // GET: OperatorApp/Edit/5
        public ActionResult Edit(int id)
        {
            var detailsToEdit = (from m in obj.tblOperators where m.id == id select m).First();
            return View(detailsToEdit);
        }

        // POST: OperatorApp/Edit/5
        [HttpPost]
        public ActionResult Edit(tblOperator detailsToEdit)
        {
            var orignalRecord = (from m in obj.tblOperators where m.id == detailsToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            obj.Entry(orignalRecord).CurrentValues.SetValues(detailsToEdit);

            obj.SaveChanges();
            return RedirectToAction("OperatorDetails");
        }


        // GET: AreaApp/Delete/5
        // GET: AreaApp/Delete/5
        public ActionResult Delete(tblOperator detailsToEdit)
        {
            var d = obj.tblOperators.Where(x => x.id == detailsToEdit.id).FirstOrDefault();
            obj.tblOperators.Remove(d);
            obj.SaveChanges();
            return RedirectToAction("OperatorDetails");
        }


        // POST: OperatorApp/Delete/5
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
