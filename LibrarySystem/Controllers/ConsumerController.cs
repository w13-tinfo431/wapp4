using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibrarySystem.DAL;
using LibrarySystem.Models;
using PagedList;
using System.Data.Entity.Infrastructure;

namespace LibrarySystem.Controllers
{
    [Authorize]
    public class ConsumerController : Controller
    {
        private LibraryContext db = new LibraryContext();
        [AllowAnonymous]
        // GET: Consumer
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var consumers = from s in db.Consumers
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                consumers = consumers.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    consumers = consumers.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    consumers = consumers.OrderBy(s => s.RegisterDate);
                    break;
                case "date_desc":
                    consumers = consumers.OrderByDescending(s => s.RegisterDate);
                    break;
                default:
                    consumers = consumers.OrderBy(s => s.LastName);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(consumers.ToPagedList(pageNumber, pageSize));
        }
        [Authorize(Users = "w13@uw.edu,harkg@uw.edu")]
        // GET: Consumer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumer consumer = db.Consumers.Find(id);
            if (consumer == null)
            {
                return HttpNotFound();
            }
            return View(consumer);
        }

        // GET: Consumer/Create
        [Authorize(Users = "w13@uw.edu,harkg@uw.edu")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Consumer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "w13@uw.edu,harkg@uw.edu")]
        public ActionResult Create([Bind(Include = "ConsumerID,FirstName,LastName,RegisterDate")] Consumer consumer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                db.Consumers.Add(consumer);
                db.SaveChanges();
                return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(consumer);
        }

        // GET: Consumer/Edit/5
        [Authorize(Users = "w13@uw.edu,harkg@uw.edu")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumer consumer = db.Consumers.Find(id);
            if (consumer == null)
            {
                return HttpNotFound();
            }
            return View(consumer);
        }

        // POST: Consumer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "w13@uw.edu,harkg@uw.edu")]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var consumerToUpdate = db.Consumers.Find(id);
            if (TryUpdateModel(consumerToUpdate, "",
               new string[] { "LastName", "FirstName", "RegisterDate" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(consumerToUpdate);
        }

        // GET: Consumer/Delete/5
        [Authorize(Users = "w13@uw.edu,harkg@uw.edu")]
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Consumer consumer = db.Consumers.Find(id);
            if (consumer == null)
            {
                return HttpNotFound();
            }
            return View(consumer);
        }

        // POST: Consumer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "w13@uw.edu,harkg@uw.edu")]
        public ActionResult DeleteConfirmed(int id)
        {
            Consumer consumer = db.Consumers.Find(id);
            db.Consumers.Remove(consumer);
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
