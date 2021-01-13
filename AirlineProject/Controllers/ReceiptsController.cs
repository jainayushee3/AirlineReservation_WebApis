//using AirlineProject.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Http.Cors;

//namespace AirlineProject.Controllers
//{
//    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
//    public class ReceiptsController : ApiController
//    {
//        private dbAirlineProjectEntitiesOne db = new dbAirlineProjectEntitiesOne();

//        [HttpPut]
//        public IHttpActionResult CancelTickets(int id)
//        {
//            int result = db.cancel_tickets(id);
//            db.SaveChanges();
//            return StatusCode(HttpStatusCode.OK);
//        }

//        [HttpGet]
//        public HttpResponseMessage GetReceipts()
//        {
//            //Receipt contains all ticket details & list of seat numbers
//            List<Receipt> all_receipts = new List<Receipt>();
//            Receipt receipt = null;

//            //Ticket Details has only receipt id and schedule details
//            List<ticket_details_Result> all_tickets = db.ticket_details().ToList();

//            foreach (var item in all_tickets)
//            {
//                receipt = new Receipt();
//                receipt.Receipt_ID = item.Receipt_ID;
//                receipt.Schedule_ID = (int)item.Schedule_ID;
//                receipt.No_Of_Tickets = (int)item.Number_Of_Tickets;
//                receipt.Source_Loc = item.Source_Loc;
//                receipt.Destination = item.Destination;
//                receipt.Tickets_Status = item.Tickets_Status;
//                receipt.Dep_Date = item.Dep_Date.ToString();
//                receipt.Dep_Time = item.Dep_Time.ToString();
//                receipt.seat_number_list = db.seat_numbers(item.Receipt_ID).ToList();
//                all_receipts.Add(receipt);
//            }

//            return Request.CreateResponse(HttpStatusCode.OK, all_receipts);
//        }
//    }
//}
