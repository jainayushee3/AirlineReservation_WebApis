using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineProject.Models
{
    public class Receipt
    {
        public int Receipt_ID { get; set; }
        public int Schedule_ID { get; set; }
        public int No_Of_Tickets { get; set; }
        public string Tickets_Status { get; set; }
        public string Source_Loc { get; set; }
        public string Destination { get; set; }
        public string Dep_Date { get; set; }
        public string Dep_Time { get; set; }
        public List<string> seat_number_list { get; set; }
    }
}