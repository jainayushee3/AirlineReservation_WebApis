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

    public class BookingController : ApiController
    {

        dbAirlineProjectEntitiesOne entitiesOne = new dbAirlineProjectEntitiesOne();

        [HttpPost]
        [Route("api/BookSeats")]
        public HttpResponseMessage BookSeats(BookSeats seats)
        {
            int result = entitiesOne.proc_BookSeats(seats.sid, seats.seatno, seats.seatclass, seats.seatstatus, seats.receiptid);
            entitiesOne.SaveChanges();
            List<int?> getSeatID = entitiesOne.proc_GetRecentlyBookedSeats(seats.receiptid).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, getSeatID);
        }

        [HttpPost]
        [Route("api/BookPassengers")]
        public HttpResponseMessage BookPassengers(BookPassenger bp)
        {
            int result = entitiesOne.proc_EnterPassengers(bp.userid, bp.name, bp.age, bp.seatid);
            entitiesOne.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/BookTickets")]
        public HttpResponseMessage BookTickets(Ticket ticket)
        {
            int result = entitiesOne.proc_BookTicket(ticket.sid, ticket.userid, ticket.triptype, ticket.otherri, ticket.not, ticket.ticstatus, ticket.total);
            entitiesOne.SaveChanges();
            List<int?> receipt_id = entitiesOne.proc_ReturnReceiptID(ticket.sid, ticket.userid, ticket.triptype, ticket.otherri, ticket.not, ticket.ticstatus, ticket.total).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, receipt_id);
        }

    }


    }
