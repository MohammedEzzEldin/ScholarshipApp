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
            var view = db.Application.Where(
                app => DateTime.Now.Year < app.EndDate.Year && 
                       DateTime.Now.Month < app.EndDate.Month && 
                       DateTime.Now.Day < app.EndDate.Day
                ).ToList();

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