using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using AirlineProject.Models;

namespace AirlineProject.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class FlightController : ApiController
    {
        dbAirlineProjectEntitiesOne entities = new dbAirlineProjectEntitiesOne();
        [HttpGet]
        [Route("api/Flight/Source")]
        public HttpResponseMessage GetSource()
        {
            var source = entities.proc_GetSourceLocations();
            return Request.CreateResponse(source);
        }

        [HttpGet]
        [Route("api/Flight/Destination")]
        public HttpResponseMessage GetDestination()
        {
            var source = entities.proc_GetDestinationLocations();
            return Request.CreateResponse(source);
        }

        [HttpGet]
        [Route("api/Flight/getseats")]
        public HttpResponseMessage GetSeats(int id)
        {
            var seats = entities.proc_getBookedSeats(id);
            return Request.CreateResponse(seats);
        }

    }
}
