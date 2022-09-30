using BykesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BykesProject.Controllers
{
    [RoutePrefix("api/bookings/bookingStatus")]
    public class BookedBykesValuesController : ApiController
    {
        private BykeRentalEntities db = new BykeRentalEntities();
        // GET api/<controller>
        [Route("{mode}")]
        public IEnumerable<vwByke> Get(String mode)
        {
            return db.vwBykes.Where(c => c.Status==mode).ToList();
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