using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using AirlineProject.Models;

namespace AirlineProject.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class tblFlight_ScheduleController : ApiController
    {
        private dbAirlineProjectEntitiesOne db = new dbAirlineProjectEntitiesOne();

        public tblFlight_ScheduleController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }


        // GET: api/tblFlight_Schedule
        public IQueryable<tblFlight_Schedule> GettblFlight_Schedule()
        {
            return db.tblFlight_Schedule;
        }

        // GET: api/tblFlight_Schedule/5
        [ResponseType(typeof(tblFlight_Schedule))]
        public IHttpActionResult GettblFlight_Schedule(int id)
        {
            tblFlight_Schedule tblFlight_Schedule = db.tblFlight_Schedule.Find(id);
            if (tblFlight_Schedule == null)
            {
                return NotFound();
            }

            return Ok(tblFlight_Schedule);
        }

        // PUT: api/tblFlight_Schedule/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblFlight_Schedule(int id, tblFlight_Schedule tblFlight_Schedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblFlight_Schedule.Schedule_ID)
            {
                return BadRequest();
            }

            db.Entry(tblFlight_Schedule).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblFlight_ScheduleExists(id))
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

        // POST: api/tblFlight_Schedule
        [ResponseType(typeof(tblFlight_Schedule))]
        public IHttpActionResult PosttblFlight_Schedule(tblFlight_Schedule tblFlight_Schedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblFlight_Schedule.Add(tblFlight_Schedule);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblFlight_Schedule.Schedule_ID }, tblFlight_Schedule);
        }

        // DELETE: api/tblFlight_Schedule/5
        //[ResponseType(typeof(tblFlight_Schedule))]
        //public IHttpActionResult DeletetblFlight_Schedule(int id)
        //{
        //    tblFlight_Schedule tblFlight_Schedule = db.tblFlight_Schedule.Find(id);
        //    if (tblFlight_Schedule == null)
        //    {
        //        return NotFound();
        //    }

        //    db.tblFlight_Schedule.Remove(tblFlight_Schedule);
        //    db.SaveChanges();

        //    return Ok(tblFlight_Schedule);
        //}
        public HttpResponseMessage DeletetblFlight_Schedule(int id)
        {
            int result = db.delete_schedule(id);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Schedule status changed to deleted!");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblFlight_ScheduleExists(int id)
        {
            return db.tblFlight_Schedule.Count(e => e.Schedule_ID == id) > 0;
        }
    }
}