using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScholarShip.Models;

namespace ScholarShip.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            //var view = db.Application.Where(
            //    app => DateTime.Now.Year < app.EndDate.Year ||
            //           (DateTime.Now.Year == app.EndDate.Year && DateTime.Now.Month < app.EndDate.Month) ||
            //           (
            //              DateTime.Now.Year == app.EndDate.Year && 
            //              DateTime.Now.Month == app.EndDate.Month && 
            //              DateTime.Now.Day <= app.EndDate.Day
            //           )
            //    ).ToList();
            //var view = db.Application.Where(
            //    app =>  DateTime.Now.CompareTo(app.StartDate) > -1 && DateTime.Now.CompareTo(app.EndDate) < 1
            //    ).ToList();
            var view = (
                        from app in db.Application
                        join schol in db.ScholarShips on app.ScholarShip_Id equals schol.Id
                        where DateTime.Now.CompareTo(app.StartDate) > -1 && DateTime.Now.CompareTo(app.EndDate) < 1
                        select new HomeViewModel() { 
                            Id = app.Id,StartDate = app.StartDate,EndDate = app.EndDate,Schol_Name = schol.Schol_Name,
                            Field = schol.Field, University = schol.University, Scholarship_StartDate = schol.StartDate,
                            Scholarship_EndDate = schol.EndDate 
                        }).ToList();
            return View(view);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}