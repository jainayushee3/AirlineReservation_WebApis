using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineProject.Models
{
    public class Ticket
    {
        public int sid { get; set; }
        public int userid { get; set; }

        public string triptype { get; set; }

        public int? otherri { get; set; }
        public int not { get; set; }

        public string ticstatus { get; set; }

        public float total { get; set; }

    }
}