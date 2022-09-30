using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BykesProject.Models;

namespace BykesProject.Controllers
{
    [Authorize]
    public class BykesController : Controller
    {
        private BykeRentalEntities db = new BykeRentalEntities();

        // GET: Bykes
        public ActionResult Index()
        {
            //is it a vendor who has logged in
            ViewBag.VendorID = "0";
            string uname = User.Identity.Name;
            var qry = db.AspNetUsers.Where(c => c.Email == uname);
            if(qry.Count()>0)
            {
                string uid = qry.FirstOrDefault().Id;

                var qry2 = from d in db.Vendors.Where(v => v.Id == uid) select d;
                if (qry2.Count() > 0)
                {
                    ViewBag.VendorID = qry2.FirstOrDefault().VendorID.ToString();
                }
                else {
                    var qry3 = from d in db.UserTyppes.Where(v => v.Id == uid) select d;
                    if (qry3.Count() > 0 && qry3.FirstOrDefault().UserType=="Client")
                    {
                        ViewBag.VendorID = "z";
                    }
                }

            }


            var bykes = db.Bykes.Include(b => b.Vendor);
            return View(bykes.ToList());
        }

        // GET: Bykes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Byke byke = db.Bykes.Find(id);
            if (byke == null)
            {
                return HttpNotFound();
            }
            return View(byke);
        }

        // GET: Bykes/Create
        public ActionResult Create(int id)//id = VendorID
        {
            //ViewBag.VendorID = new SelectList(db.Vendors, "VendorID", "VendorName");
            ViewBag.VendorID = id;


            List<SelectListItem> items = new List<SelectListItem>();
            items.Insert(0, (new SelectListItem { Text = "Booked", Value = "Booked" }));
            items.Insert(0, (new SelectListItem { Text = "NotBooked", Value = "NotBooked" }));
            ViewBag.booking = items;

            return View();
        }

        // POST: Bykes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BykeDescription,VendorID,BykeType,Status")] Byke byke, int id)
        {
            byke.BykeId = 0;
            byke.VendorID = id;
            if (ModelState.IsValid)
            {
                db.Bykes.Add(byke);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.VendorID = new SelectList(db.Vendors, "VendorID", "VendorName", byke.VendorID);
            ViewBag.VendorID = id;

            List<SelectListItem> items = new List<SelectListItem>();
            items.Insert(0, (new SelectListItem { Text = "Booked", Value = "Booked" }));
            items.Insert(0, (new SelectListItem { Text = "NotBooked", Value = "NotBooked" }));
            ViewBag.booking = items;

            return View(byke);
        }

        public ActionResult Book(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Byke byke = db.Bykes.Find(id);
            if (byke == null)
            {
                return HttpNotFound();
            }
            //ViewBag.VendorID = new SelectList(db.Vendors, "VendorID", "VendorName", byke.VendorID);
            return View(byke);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Book([Bind(Include = "BykeId,BykeDescription,VendorID,BykeType,Status")] Byke byke)
        {
            string uname = User.Identity.Name;
            string Idd = db.AspNetUsers.Where(u => u.UserName == uname).FirstOrDefault().Id;

            if (ModelState.IsValid)
            {
                byke.Status = "Booked";
                db.Entry(byke).State = EntityState.Modified;

                Booking b = new Booking { BykeId = byke.BykeId, Id = Idd };
                db.Bookings.Add(b);
                db.SaveChanges();

               

                return RedirectToAction("Index");
            }
            ViewBag.VendorID = new SelectList(db.Vendors, "VendorID", "VendorName", byke.VendorID);
            return View(byke);
        }

        // GET: Bykes/Edit/5


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Byke byke = db.Bykes.Find(id);
            if (byke == null)
            {
                return HttpNotFound();
            }
            ViewBag.VendorID = new SelectList(db.Vendors, "VendorID", "VendorName", byke.VendorID);
            return View(byke);
        }

        // POST: Bykes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BykeId,BykeDescription,VendorID,BykeType,Status")] Byke byke)
        {
            if (ModelState.IsValid)
            {
                db.Entry(byke).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VendorID = new SelectList(db.Vendors, "VendorID", "VendorName", byke.VendorID);
            return View(byke);
        }

        // GET: Bykes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Byke byke = db.Bykes.Find(id);
            if (byke == null)
            {
                return HttpNotFound();
            }
            return View(byke);
        }

        // POST: Bykes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Byke byke = db.Bykes.Find(id);
            db.Bykes.Remove(byke);
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
