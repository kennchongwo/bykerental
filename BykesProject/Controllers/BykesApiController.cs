using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BykesProject.Models;

namespace BykesProject.Controllers
{
    public class BykesApiController : ApiController
    {
        private BykeRentalEntities db = new BykeRentalEntities();

        // GET: api/BykesApi
        public IQueryable<Byke> GetBykes()
        {
            return db.Bykes;
        }

        // GET: api/BykesApi/5
        [ResponseType(typeof(Byke))]
        public IHttpActionResult GetByke(int id)
        {
            Byke byke = db.Bykes.Find(id);
            if (byke == null)
            {
                return NotFound();
            }

            return Ok(byke);
        }

        // PUT: api/BykesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutByke(int id, Byke byke)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != byke.BykeId)
            {
                return BadRequest();
            }

            db.Entry(byke).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BykeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BykesApi
        [ResponseType(typeof(Byke))]
        public IHttpActionResult PostByke(Byke byke)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bykes.Add(byke);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = byke.BykeId }, byke);
        }

        // DELETE: api/BykesApi/5
        [ResponseType(typeof(Byke))]
        public IHttpActionResult DeleteByke(int id)
        {
            Byke byke = db.Bykes.Find(id);
            if (byke == null)
            {
                return NotFound();
            }

            db.Bykes.Remove(byke);
            db.SaveChanges();

            return Ok(byke);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BykeExists(int id)
        {
            return db.Bykes.Count(e => e.BykeId == id) > 0;
        }
    }
}