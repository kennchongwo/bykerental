using BykesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BykesProject.Controllers
{
    [RoutePrefix("api/bookings")]
    public class BookingValuesController : ApiController
    {
        private BykeRentalEntities db = new BykeRentalEntities();
        // GET api/<controller>
        [Route("{mode}")]
        public IEnumerable<vwBooking> Get(String mode)
        {
            return db.vwBookings.ToList() ;
        }


        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}