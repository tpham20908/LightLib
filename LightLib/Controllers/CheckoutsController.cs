using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LightLib.Models;

namespace LightLib.Controllers
{
    public class CheckoutsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Checkouts
        public ActionResult Index()
        {
            return View(db.Checkouts.ToList());
        }

        // Show all checkouts picked by user to confirm
        public ActionResult Checkouts()
        {
            List<int> IdList = (List<int>)Session["Checkouts"];
            Checkout ch = new Checkout();
            var selectedAssets = db.Assets.Where(a => IdList.Contains(a.Id));
            return View(selectedAssets.ToList());
        }


        // GET: Checkouts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Checkout checkout = db.Checkouts.Find(id);
            if (checkout == null)
            {
                return HttpNotFound();
            }
            return View(checkout);
        }

        // GET: Checkouts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Checkouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateCheckedOut")] Checkout checkout)
        {
            if (ModelState.IsValid)
            {
                db.Checkouts.Add(checkout);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(checkout);
        }

        // GET: Checkouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Checkout checkout = db.Checkouts.Find(id);
            if (checkout == null)
            {
                return HttpNotFound();
            }
            return View(checkout);
        }

        // POST: Checkouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateCheckedOut")] Checkout checkout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(checkout);
        }

        // GET: Checkouts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Checkout checkout = db.Checkouts.Find(id);
            if (checkout == null)
            {
                return HttpNotFound();
            }
            return View(checkout);
        }

        // POST: Checkouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Checkout checkout = db.Checkouts.Find(id);
            db.Checkouts.Remove(checkout);
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
