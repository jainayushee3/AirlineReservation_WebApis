using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AirlineProject.Models;
using System.Web.Http.Cors;

namespace AirlineProject.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ReceiptDetailsController : ApiController
    {
        private dbAirlineProjectEntitiesOne db = new dbAirlineProjectEntitiesOne();


        [HttpGet]
        [Route("api/UserTrips")]
        public HttpResponseMessage GetReceipts(int id)
        {
            //Receipt contains all ticket details & list of seat numbers
            List<ReceiptDetails> all_receipts = new List<ReceiptDetails>();
            ReceiptDetails receipt = null;

            //Ticket Details has only receipt id and schedule details
            List<proc_getTickets_Result> all_tickets = db.proc_getTickets(id).ToList();
            foreach(var item in all_tickets)
            {
                receipt = new ReceiptDetails();
                receipt.Receipt_ID = item.Receipt_id;
                receipt.Schedule_ID = (int)item.Schedule_id;
                receipt.No_Of_Tickets = (int)item.number_of_tickets;
                receipt.Source_Loc = item.Source_Loc;
                receipt.Destination = item.Destination;
                receipt.Tickets_Status = item.Tickets_Status;
                receipt.Dep_Date = item.Dep_Date.ToString();
                receipt.Dep_Time = item.Dep_Time.ToString();
                receipt.seat_number_list = db.sp_ticket_seat_details(item.Receipt_id).ToList();
                db.SaveChanges();
                all_receipts.Add(receipt);
                
            }
            return Request.CreateResponse(HttpStatusCode.OK, all_receipts);

        }

        [HttpPut]
        [Route("api/Cancel")]
        public IHttpActionResult CancelTickets(int id, tblUser user)
        {
            int result = db.sp_Cancel_tickets(id);
            db.SaveChanges();
            return StatusCode(HttpStatusCode.OK);
        }

    }
}
