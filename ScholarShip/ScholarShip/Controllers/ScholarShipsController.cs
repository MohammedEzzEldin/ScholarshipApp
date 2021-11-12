using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScholarShip.Models;

namespace ScholarShip.Controllers
{
    public class ScholarShipsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ScholarShips
        public ActionResult Index()
        {
            return View(db.ScholarShips.ToList());
        }

        // GET: ScholarShips/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScholarShipTbl scholarShip = db.ScholarShips.Find(id);
            if (scholarShip == null)
            {
                return HttpNotFound();
            }
            return View(scholarShip);
        }

        // GET: ScholarShips/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScholarShips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Schol_Name,Description,Requirements,StartDate,EndDate,Field,University,Country,City,IsFinalPost")] ScholarShipTbl scholarShip)
        {
            if (ModelState.IsValid)
            {
                db.ScholarShips.Add(scholarShip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scholarShip);
        }

        // GET: ScholarShips/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScholarShipTbl scholarShip = db.ScholarShips.Find(id);
            if (scholarShip == null)
            {
                return HttpNotFound();
            }
            return View(scholarShip);
        }

        // POST: ScholarShips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Schol_Name,Description,Requirements,StartDate,EndDate,Field,University,Country,City,IsFinalPost")] ScholarShipTbl scholarShip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scholarShip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scholarShip);
        }

        // GET: ScholarShips/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScholarShipTbl scholarShip = db.ScholarShips.Find(id);
            if (scholarShip == null)
            {
                return HttpNotFound();
            }
            return View(scholarShip);
        }

        // POST: ScholarShips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScholarShipTbl scholarShip = db.ScholarShips.Find(id);
            db.ScholarShips.Remove(scholarShip);
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
