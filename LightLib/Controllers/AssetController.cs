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
    public class AssetController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Asset
        public ActionResult Index()
        {
            var assets = db.Assets.Include(a => a.Type).OrderBy(a=>a.Type.Id);
            return View(assets.ToList());
        }
        // GET: Asset
        public ActionResult IndexList()
        {
            var assets = db.Assets.Include(a => a.Type);
            return View(assets.ToList());
        }

        // GET: Asset/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asset asset = db.Assets.Include(a=>a.Type).SingleOrDefault(a=>a.Id==id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            return View(asset);
        }

        // GET: Asset/Create
        public ActionResult Create()
        {
            ViewBag.AssetTypeId = new SelectList(db.AssetTypes, "Id", "Name");
            return View();
        }

        // POST: Asset/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,AssetTypeId,Author,ReleasedYear,ImageUrl")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                db.Assets.Add(asset);
                db.SaveChanges();
                return RedirectToAction("IndexList");
            }

            ViewBag.AssetTypeId = new SelectList(db.AssetTypes, "Id", "Name", asset.AssetTypeId);
            return View(asset);
        }

        // GET: Asset/Edit/5
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

        // POST: Asset/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,AssetTypeId,Author,ReleasedYear,ImageUrl")] Asset asset)
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

        // GET: Asset/Delete/5
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

        // POST: Asset/Delete/5
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
    }
}
