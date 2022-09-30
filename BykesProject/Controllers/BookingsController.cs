using BykesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BykesProject.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        private BykeRentalEntities db = new BykeRentalEntities();
        // GET: Bookings
        public ActionResult Index()
        {
            return View(db.vwBookings.ToList());
        }
    }
}