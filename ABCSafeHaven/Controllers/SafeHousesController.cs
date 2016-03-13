using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ABCSafeHaven.Models;

namespace ABCSafeHaven.Controllers
{
    public class SafeHousesController : Controller
    {
        private SafeHouseDBContext db = new SafeHouseDBContext();

        // GET: SafeHouses
        public ActionResult Index()
        {
            return View(db.SafeHouses.ToList());
        }
        public ActionResult MySafeHouses()
        {
            return View(db.SafeHouses.ToList().Where(s=> s.owner == User.Identity.Name));
        }
        // GET: SafeHouses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SafeHouse safeHouse = db.SafeHouses.Find(id);
            if (safeHouse == null)
            {
                return HttpNotFound();
            }
            return View(safeHouse);
        }
        public ActionResult Map(string i)
        {
            ViewBag.nameFilter = i;
            if (String.IsNullOrEmpty(i))
            {
                return View(db.SafeHouses.ToList());
            }
            else
            {
                var events = from e in db.SafeHouses where e.address.Contains(i) select e;
                return View(events);
            }
        }
        // GET: SafeHouses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SafeHouses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,owner,isAvailable,capacity,address,specialRequests")] SafeHouse safeHouse)
        {
            if (ModelState.IsValid)
            {
                safeHouse.owner = User.Identity.Name;
                db.SafeHouses.Add(safeHouse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(safeHouse);
        }

        // GET: SafeHouses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SafeHouse safeHouse = db.SafeHouses.Find(id);
            if (safeHouse == null)
            {
                return HttpNotFound();
            }
            return View(safeHouse);
        }

        // POST: SafeHouses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,owner,isAvailable,capacity,address,specialRequests")] SafeHouse safeHouse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(safeHouse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(safeHouse);
        }

        // GET: SafeHouses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SafeHouse safeHouse = db.SafeHouses.Find(id);
            if (safeHouse == null)
            {
                return HttpNotFound();
            }
            return View(safeHouse);
        }

        // POST: SafeHouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SafeHouse safeHouse = db.SafeHouses.Find(id);
            db.SafeHouses.Remove(safeHouse);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
