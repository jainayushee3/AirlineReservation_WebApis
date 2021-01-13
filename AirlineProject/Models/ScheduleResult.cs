using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineProject.Models
{
    public class ScheduleResult
    {
        public int Flight_ID { get; set; }
        public int Schedule_ID { get; set; }
        public DateTime Dep_Date { get; set; }
        public DateTime Dep_Time { get; set; }
        public DateTime Arr_Time { get; set; }
        public string Destination { get; set; }
        public string Source { get; set; }
        public DateTime Duration { get; set; }
       

    }
}