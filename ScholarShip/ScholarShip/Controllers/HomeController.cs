using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScholarShip.Classes;
using ScholarShip.Models;

namespace ScholarShip.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            int userId = 0;
            if(StaticFunctions.GetSessionUserID(Session[ConstantVariables.UserSessionKey]) != null)
            {
                userId = Convert.ToInt32(Session[ConstantVariables.UserSessionKey]);
            }
            var view = (
                        from app in db.Application
                        join schol in db.ScholarShips on app.ScholarShip_Id equals schol.Id
                        join app_stud in db.Student_Application.Where(m => m.Student_Id == userId) 
                        on app.Id equals app_stud.Application_Id into app_stud_app
                        from app_stud in app_stud_app.DefaultIfEmpty()
                        where DateTime.Now.CompareTo(app.StartDate) > -1 && DateTime.Now.CompareTo(app.EndDate) < 1
                        select new HomeViewModel() { 
                            Id = app.Id,StartDate = app.StartDate,EndDate = app.EndDate,Schol_Name = schol.Schol_Name,
                            Field = schol.Field, University = schol.University, Scholarship_StartDate = schol.StartDate,
                            Scholarship_EndDate = schol.EndDate , Student_Application_Id = app_stud.Id
                        }).ToList();
            return View(view);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize(Roles = ConstantVariables.adminsRole)]
        public ActionResult IndexOfStudents()
        {
            var view = (
                        from app in db.Application
                        join schol in db.ScholarShips on app.ScholarShip_Id equals schol.Id
                        join app_stud in db.Student_Application.Where(m => m.IsFinalPost == false)
                                                    on app.Id equals app_stud.Application_Id 
                        join stud in db.Student on app_stud.Student_Id equals stud.Id
                        where DateTime.Now.CompareTo(app.StartDate) > -1 && DateTime.Now.CompareTo(app.EndDate) < 1
                        select new IndexOfStudentViewModel ()
                        {
                            Student_Application_Id = app_stud.Id, IsAccepted = app_stud.IsAccepted , 
                            IsFinalPost = app_stud.IsFinalPost, Schol_Name = schol.Schol_Name,
                            Field = schol.Field, Scholarship_University = schol.University,
                            FullName = string.Format("{0} {1}", stud.Fname ,stud.Lname),
                            NationalID = stud.NationalID, University = stud.University,
                            Major = stud.Major,GPA = stud.GPA
                        }).ToList();

            return View();
        }
        public ActionResult UploadResume(int? id)
        {
            Student student = db.Student.Find(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult UploadResume(HttpPostedFileBase file)
        {
            Student student = db.Student.Find(Convert.ToInt32(Request.Form["Id"]));
            if (student == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    ModelState.AddModelError("Id", "Some Problems occures !");
                    return View(student);
                }

                if (file.FileName != null)
                {

                    string ext = System.IO.Path.GetExtension(file.FileName);
                    if (ext != null)
                    {
                        switch (ext.ToLower())
                        {
                            case ".txt":
                                break;

                            case ".GIF":
                                break;

                            case ".pdf":
                                break;

                            case ".doc":
                                break;
                            default:
                                ModelState.AddModelError("Id", "This Extension Not Allowed");
                                return View(student);
                        }
                        file.SaveAs(Server.MapPath("~/Content/Images/") + student.Id + ext);
                        student.Resume = "~/Content/Images/" + student.Id + ext;
                        db.Entry(student).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(student);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}