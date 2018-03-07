using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibrarySystem.DAL;
using LibrarySystem.ViewModels;

namespace LibrarySystem.Controllers
{
    public class HomeController : Controller
    {
        private LibraryContext db = new LibraryContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<RegisterDateGroup> data = from consumer in db.Consumers
                                                   group consumer by consumer.RegisterDate into dateGroup
                                                   select new RegisterDateGroup()
                                                   {
                                                       RegisterDate = dateGroup.Key,
                                                       ConsumerCount = dateGroup.Count()
                                                   };
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Our contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}