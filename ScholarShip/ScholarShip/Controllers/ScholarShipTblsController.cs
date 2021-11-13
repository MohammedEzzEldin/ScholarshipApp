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
    public class ScholarShipTblsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ScholarShipTbls
        public ActionResult Index()
        {
            return View(db.ScholarShips.ToList());
        }

        // GET: ScholarShipTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScholarShipTbl scholarShipTbl = db.ScholarShips.Find(id);
            if (scholarShipTbl == null)
            {
                return HttpNotFound();
            }
            return View(scholarShipTbl);
        }

        // GET: ScholarShipTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScholarShipTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Schol_Name,Description,Requirements,StartDate,EndDate,Field,University,Country,City")] ScholarShipTbl scholarShipTbl)
        {
            if (ModelState.IsValid)
            {
                db.ScholarShips.Add(scholarShipTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scholarShipTbl);
        }

        // GET: ScholarShipTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScholarShipTbl scholarShipTbl = db.ScholarShips.Find(id);
            if (scholarShipTbl == null)
            {
                return HttpNotFound();
            }
            return View(scholarShipTbl);
        }

        // POST: ScholarShipTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Schol_Name,Description,Requirements,StartDate,EndDate,Field,University,Country,City")] ScholarShipTbl scholarShipTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scholarShipTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scholarShipTbl);
        }

        // GET: ScholarShipTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScholarShipTbl scholarShipTbl = db.ScholarShips.Find(id);
            if (scholarShipTbl == null)
            {
                return HttpNotFound();
            }
            return View(scholarShipTbl);
        }

        // POST: ScholarShipTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScholarShipTbl scholarShipTbl = db.ScholarShips.Find(id);
            db.ScholarShips.Remove(scholarShipTbl);
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
