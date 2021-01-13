using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using AirlineProject.Models;

namespace AirlineProject.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class tblFlight_DetailsController : ApiController
    {
        private dbAirlineProjectEntitiesOne db = new dbAirlineProjectEntitiesOne();

        public tblFlight_DetailsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }


        // GET: api/tblFlight_Details
        //[BasicAuthentication]
        public HttpResponseMessage GettblFlight_Details()
        {
            return Request.CreateResponse(HttpStatusCode.OK, db.tblFlight_Details.ToList());
            //string username = Thread.CurrentPrincipal.Identity.Name;
            //if (username.Equals("admin"))
            //{
            //    return Request.CreateResponse(HttpStatusCode.OK, db.tblFlight_Details.ToList());
            //}
            //else
            //{
            //    return Request.CreateResponse(HttpStatusCode.BadRequest);
            //}

        }

        // GET: api/tblFlight_Details/5
        [ResponseType(typeof(tblFlight_Details))]
        public IHttpActionResult GettblFlight_Details(int id)
        {
            tblFlight_Details tblFlight_Details = db.tblFlight_Details.Find(id);
            if (tblFlight_Details == null)
            {
                return NotFound();
            }

            return Ok(tblFlight_Details);
        }

        // PUT: api/tblFlight_Details/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblFlight_Details(int id, tblFlight_Details tblFlight_Details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblFlight_Details.Flight_ID)
            {
                return BadRequest();
            }

            db.Entry(tblFlight_Details).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblFlight_DetailsExists(id))
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

        // POST: api/tblFlight_Details
        [ResponseType(typeof(tblFlight_Details))]
        public IHttpActionResult PosttblFlight_Details(tblFlight_Details tblFlight_Details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblFlight_Details.Add(tblFlight_Details);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblFlight_Details.Flight_ID }, tblFlight_Details);
        }

        // DELETE: api/tblFlight_Details/5
        //[ResponseType(typeof(tblFlight_Details))]
        //public IHttpActionResult DeletetblFlight_Details(int id)
        //{
        //    tblFlight_Details tblFlight_Details = db.tblFlight_Details.Find(id);
        //    if (tblFlight_Details == null)
        //    {
        //        return NotFound();
        //    }

        //    db.tblFlight_Details.Remove(tblFlight_Details);
        //    db.SaveChanges();

        //    return Ok(tblFlight_Details);
        //}
        public HttpResponseMessage DeletetblFlight_Details(int id)
        {
            //Calling a procedure to update status instead of performing delete operation
            int result=db.delete_flight(id);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK,"Flight & Schedule status changed to deleted");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblFlight_DetailsExists(int id)
        {
            return db.tblFlight_Details.Count(e => e.Flight_ID == id) > 0;
        }
    }
}