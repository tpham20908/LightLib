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
            return View();
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
            var selectedAssets = db.Assets.Where(a => IdList.Contains(a.Id));
            return View(selectedAssets.ToList());
        }
    }
}