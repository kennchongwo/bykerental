using BykesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BykesProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private BykeRentalEntities db = new BykeRentalEntities();
        public ActionResult Index()
        {
            ViewBag.VendorID = "0";
            string uname = User.Identity.Name;
            var qry = db.AspNetUsers.Where(c => c.Email == uname);
            if (qry.Count() > 0)
            {
                string uid = qry.FirstOrDefault().Id;

                var qry2 = from d in db.Vendors.Where(v => v.Id == uid) select d;
                if (qry2.Count() > 0)
                {
                    ViewBag.VendorID = qry2.FirstOrDefault().VendorID.ToString();
                }
                else
                {
                    var qry3 = from d in db.UserTyppes.Where(v => v.Id == uid) select d;
                    if (qry3.Count() > 0 && qry3.FirstOrDefault().UserType == "Client")
                    {
                        ViewBag.VendorID = "z";
                    }
                }

            }

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
    }
}