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
    public class AssetsController : Controller
    {
        int book = 1, magazine = 2, movie = 3, document = 4, game = 5, music = 6 ;

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Assets
        public ActionResult Index()
        {
            var assets = db.Assets.Include(a => a.Type);
            return View(assets.ToList());
        }

        // GET: Assets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asset asset = db.Assets.Find(id);
            
            if (asset == null)
            {
                return HttpNotFound();
            }
            return View(asset);
        }

        // GET: Assets/Create
        public ActionResult Create()
        {
            ViewBag.AssetTypeId = new SelectList(db.AssetTypes, "Id", "Name");
            return View();
        }

        // POST: Assets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,AssetTypeId,ReleasedYear,ImageUrl")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                db.Assets.Add(asset);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssetTypeId = new SelectList(db.AssetTypes, "Id", "Name", asset.AssetTypeId);
            return View(asset);
        }

        // GET: Assets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asset asset = db.Assets.Find(id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssetTypeId = new SelectList(db.AssetTypes, "Id", "Name", asset.AssetTypeId);
            return View(asset);
        }

        // POST: Assets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,AssetTypeId,ReleasedYear,ImageUrl")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asset).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssetTypeId = new SelectList(db.AssetTypes, "Id", "Name", asset.AssetTypeId);
            return View(asset);
        }

        // GET: Assets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asset asset = db.Assets.Find(id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            return View(asset);
        }

        // POST: Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asset asset = db.Assets.Find(id);
            db.Assets.Remove(asset);
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

        public ActionResult Book()
        {
            var books = db.Assets.Where(a => a.AssetTypeId == book);
            return View(books.ToList());
        }

        public ActionResult Magazine()
        {
            var magazines = db.Assets.Where(a => a.AssetTypeId == magazine);
            return View(magazines.ToList());
        }

        public ActionResult Movie()
        {
            var movies = db.Assets.Where(a => a.AssetTypeId == movie);
            return View(movies.ToList());
        }

        public ActionResult Documentation()
        {
            var documents = db.Assets.Where(a => a.AssetTypeId == document);
            return View(documents.ToList());
        }

        public ActionResult Game()
        {
            var games = db.Assets.Where(a => a.AssetTypeId == game);
            return View(games.ToList());
        }

        public ActionResult Music()
        {
            var musics = db.Assets.Where(a => a.AssetTypeId == music);
            return View(musics.ToList());
        }

        
    }
}
