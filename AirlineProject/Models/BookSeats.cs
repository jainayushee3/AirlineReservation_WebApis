using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineProject.Models
{
    public class BookSeats
    {
        public int sid { get; set; }
        public string seatno { get; set; }
        public string seatclass { get; set; }
        public string seatstatus { get; set; }
        public int receiptid { get; set; }
    }
}