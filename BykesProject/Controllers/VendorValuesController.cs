using BykesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BykesProject.Controllers
{
    [RoutePrefix("api/vendor/bikes")]
    public class VendorValuesController : ApiController
    {
        private BykeRentalEntities db = new BykeRentalEntities();
        private BykeRentalEntities db2 = new BykeRentalEntities();
        // GET api/<controller>
        [Route("{venderRef}")]
        public IEnumerable<vwByke> Get(String venderRef)
        {
            var qry = db.Vendors.Where(v => v.VendorCode == venderRef);
            if(qry.Count()>0)
            {
                int vendorID = qry.FirstOrDefault().VendorID;
                
                    return db2.vwBykes.Where(b => b.VendorID == vendorID).ToList();
            }
            else
            return db.vwBykes.Take(0).ToList();
        }

        // GET api/<controller>/5
        

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