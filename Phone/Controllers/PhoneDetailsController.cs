using Phone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phone.Controllers
{
    public class PhoneDetailsController : Controller
    {
        // GET: PhoneDetails
        PhoneBookEntities2 obj = new PhoneBookEntities2();

        public ActionResult PhoneList()
        {
            return View(obj.PhoneDatas.ToList());
        }

        // GET: PhoneDetails/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PhoneDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhoneDetails/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] PhoneData data)
        {
            if (!ModelState.IsValid)
                return View();
            obj.PhoneDatas.Add(data);
            obj.SaveChanges();
            return RedirectToAction("PhoneList");
        }

        // GET: PhoneDetails/Edit/5
        public ActionResult Edit(int id)
        {
            var detailsToEdit = (from m in obj.PhoneDatas where m.id == id select m).First();
            return View(detailsToEdit);
        }

        // POST: PhoneDetails/Edit/5
        [HttpPost]
        public ActionResult Edit(PhoneData detailsToEdit)
        {
            var orignalRecord = (from m in obj.PhoneDatas where m.id == detailsToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            obj.Entry(orignalRecord).CurrentValues.SetValues(detailsToEdit);

            obj.SaveChanges();
            return RedirectToAction("PhoneList");
        }

        // GET: PhoneDetails/Delete/5
        public ActionResult Delete(PhoneData detailsToEdit)
        {


            var d = obj.PhoneDatas.Where(x => x.id == detailsToEdit.id).FirstOrDefault();
            obj.PhoneDatas.Remove(d);
            obj.SaveChanges();
            return RedirectToAction("PhoneList");
        }

        // POST: PhoneDetails/Delete/5
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
