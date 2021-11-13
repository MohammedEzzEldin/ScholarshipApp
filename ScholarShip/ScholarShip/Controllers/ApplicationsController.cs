using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScholarShip.Classes;
using ScholarShip.Models;

namespace ScholarShip.Controllers
{
    public class ApplicationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Applications
        public ActionResult Index()
        {
            return View(db.Application.ToList());
        }

        // GET: Applications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Application.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // GET: Applications/Create
        public ActionResult Create()
        {
            ScholarShipsList();
            return View();
        }

        [NonAction]
        private void ScholarShipsList(object selectedValue = null)
        {
            //var Dictionary =
            //    db.ScholarShips.Where(
            //               model => DateTime.Now.CompareTo(model.StartDate) > -1 &&
            //              (model.EndDate == null || DateTime.Now.CompareTo(model.EndDate) < 1)
            //    )
            //    //.Select(model => new { Key = model.Id, Value = model.Schol_Name })
            //     .ToDictionary(k => k.Id , v => v.Schol_Name);
            //ViewBag.ScholarShipsList = StaticFunctions.ToSelectList(Dictionary);

            ViewBag.ScholarShipsList = new SelectList(db.ScholarShips, "Id", "Schol_Name", selectedValue);
        }

        // POST: Applications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ScholarShip_Id,StartDate,EndDate")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Application.Add(application);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ScholarShipsList();
            return View(application);
        }
        //[HttpPost, ActionName("Create")]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateAction()
        //{
        //    Application application = new Application();
        //    if (!string.IsNullOrEmpty(Request.Form["StartDate"]))
        //    {
        //        application.StartDate = Convert.ToDateTime(Request.Form["StartDate"]);
        //    }

        //    if (!string.IsNullOrEmpty(Request.Form["EndDate"]))
        //    {
        //        application.EndDate = Convert.ToDateTime(Request.Form["EndDate"]);
        //    }
        //    ScholarShipTbl scholarShip = db.ScholarShips.Find(Convert.ToInt32(Request.Form["ScholarShip_Id"]));
        //    application.ScholarShip = scholarShip;

        //    if (ModelState.IsValid)
        //    {
        //        db.Application.Add(application);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ScholarShipsList();
        //    return View(application);
        //}
        [Authorize(Roles = ConstantVariables.studentsRole)]
        public ActionResult Apply(int? id)
        {
            if (id != null)
            {
                // cehck if he already apply on it 
                if (db.Student_Application.Where(m => m.Application_Id == (int)id).SingleOrDefault() == null)
                {
                    var studID = Session[ConstantVariables.UserSessionKey];
                    Application app = db.Application.Find(id);
                    Student stud = db.Student.Find(studID);
                    Student_Application student_Application = new Student_Application()
                    {
                        Application = app,
                        Student = stud,
                        Application_Id = (int)id,
                        Student_Id = Convert.ToInt32(studID),
                        RegDate = DateTime.Now
                    };
                    db.Student_Application.Add(student_Application);
                    db.SaveChanges();
                    string msg = string.Empty;
                    bool isSend = StaticFunctions.SendEmail(
                        Convert.ToString(Session[ConstantVariables.UserEmailSessionKey]),
                        "apply Application",
                        "Your application applied successfuly",
                        ref msg
                    );
                    if (isSend)
                    {
                        msg = "We send the status on your email";
                    }
                    TempData["Message"] = msg;
                }
                else
                {
                    TempData["Message"] = "Your application is already applied.";
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = ConstantVariables.studentsRole)]
        public ActionResult CancelApplication(int? application_id)
        {
            if (application_id != null)
            {
                // cehck if he already apply on it 
                Student_Application student_Application = db.Student_Application.Find(application_id);
                db.Student_Application.Remove(student_Application);
                db.SaveChanges();

                string msg = "We send the status on your email";
                bool isSend = StaticFunctions.SendEmail(
                    Convert.ToString(Session[ConstantVariables.UserEmailSessionKey]),
                    "cancel Application",
                    "Your application cancelled successfuly",
                    ref msg
                );

                if (isSend)
                {
                    msg = "We send the status on your email";
                }
                TempData["Message"] = msg;

            }
            else
            {
                TempData["Message"] = "Your application is already cancelled.";
            }
            return RedirectToAction("Index", "Home");
        }
        // GET: Applications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Application.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartDate,EndDate")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Entry(application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(application);
        }

        // GET: Applications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Application.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Application application = db.Application.Find(id);
            db.Application.Remove(application);
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
