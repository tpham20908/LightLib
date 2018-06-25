using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LightLib.Models;
using LightLib.ViewModels;

namespace LightLib.Controllers
{
    public class LibraryUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LibraryUsers
        public ActionResult Index()
        {
            return View(db.LibraryUsers.ToList());
        }

        // GET: LibraryUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibraryUser libraryUser = db.LibraryUsers.Find(id);
            if (libraryUser == null)
            {
                return HttpNotFound();
            }
            return View(libraryUser);
        }

        // GET: LibraryUsers/Rent/2
        public ActionResult Rent(int id, string Search)
        {
            var assets = db.Assets
                .Where(a => a.Title.Contains(Search));

            var user = db.LibraryUsers
                .FirstOrDefault(u => u.Id == id);

            var model = new UserCheckoutsAssets()
            {
                User = user,
                Assets = assets
            };

            return View(model);
        }

        // GET: LibraryUsers/RentProcess?userId=2&assetId=2
        public ActionResult RentProcess(int userId, int assetId)
        {
            var user = db.LibraryUsers.Include(u => u.Checkouts)
                .FirstOrDefault(u => u.Id == userId);
            var asset = db.Assets.FirstOrDefault(a => a.Id == assetId);

            List<Asset> assets = new List<Asset>();
            assets.Add(asset);

            if (!user.Checkouts.Any())
                user.Checkouts = new List<Checkout>();

            user.Checkouts.ToList()
                .Add(new Checkout { Assets = assets });

            return View("Details");

        }

        // GET: LibraryUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LibraryUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address")] LibraryUser libraryUser)
        {
            if (ModelState.IsValid)
            {
                db.LibraryUsers.Add(libraryUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(libraryUser);
        }

        // GET: LibraryUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibraryUser libraryUser = db.LibraryUsers.Find(id);
            if (libraryUser == null)
            {
                return HttpNotFound();
            }
            return View(libraryUser);
        }

        // POST: LibraryUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address")] LibraryUser libraryUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libraryUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(libraryUser);
        }

        // GET: LibraryUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibraryUser libraryUser = db.LibraryUsers.Find(id);
            if (libraryUser == null)
            {
                return HttpNotFound();
            }
            return View(libraryUser);
        }

        // POST: LibraryUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LibraryUser libraryUser = db.LibraryUsers.Find(id);
            db.LibraryUsers.Remove(libraryUser);
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
