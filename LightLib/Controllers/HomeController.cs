using LightLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LightLib.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            if (User.IsInRole("admin"))
            {
                return View("IndexAdmin");
            }
            var assets = db.Assets.OrderByDescending(a => a.Type.Id).Take(6);
            return View(assets.ToList());
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

        // Show all checkouts picked by user to confirm
        public ActionResult Checkouts(int? removeId)
        {
            List<int> IdList = (List<int>)Session["Checkouts"];
            if (removeId != null) // remove item from checked
            {
                IdList.Remove((int)removeId);
                Session["Checkouts"] = IdList;
                
            }
            //find items already rented
            string userName = System.Web.HttpContext.Current.User.Identity.Name;
            int rentedNumber = db.Assets.Where(a => a.User == userName).Count();
            ViewBag.RentedNumber = rentedNumber;
            
            var selectedAssets = db.Assets.Where(a => IdList.Contains(a.Id));
            return View(selectedAssets.ToList());
        }

        //Saving action into DB
        //Post action
        [Authorize]
        [HttpPost]//only from form !
        [ValidateAntiForgeryToken]
        public ActionResult Checkouts(List<Asset> la)
        {
            List<int> IdList = (List<int>)Session["Checkouts"];
            if (IdList.Count == 0)
            {
                return HttpNotFound();
            }
            //get current user name
            string userName = System.Web.HttpContext.Current.User.Identity.Name;
            var assetsToRent = db.Assets.Where(a => IdList.Contains(a.Id)).ToList();
            assetsToRent.ForEach(a => a.User = userName);
            assetsToRent.ForEach(a => a.RentDate = DateTime.Now.Date);
            db.SaveChanges();
            IdList.Clear();
            Session["Checkouts"] = IdList;
            return RedirectToAction("Index", "Asset");
        }

        //Show my File // Return asset
        [Authorize]
        public ActionResult MyFile(int? returnId)
        {
            if (returnId != null) // return one item 
            {
                var assetToReturn = db.Assets.Find(returnId);
                assetToReturn.User = null;
                db.SaveChanges();
            }

            //get current user name
            string userName = System.Web.HttpContext.Current.User.Identity.Name;
            var rentedByUser = db.Assets.Where(a => a.User==userName).ToList();
            return View(rentedByUser);
        }

        //Retrurn ALL
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MyFile(List<Asset> la)
        {
            //get current user name
            string userName = System.Web.HttpContext.Current.User.Identity.Name;
            var assetsToReturn = db.Assets.Where(a => a.User==userName).ToList();
            assetsToReturn.ForEach(a => a.User = null);
            string minSQLDate = "01/01/1990";
            assetsToReturn.ForEach(a => a.RentDate = DateTime.ParseExact(minSQLDate,"d",System.Globalization.CultureInfo.InvariantCulture));
            db.SaveChanges();
            var rentedByUser = db.Assets.Where(a => a.User==userName).ToList();
            return View(rentedByUser);
        }
    }
}