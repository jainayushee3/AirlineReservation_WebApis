using System;
using System.Collections;
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
    public class SearchFlightController : ApiController
    {
        dbAirlineProjectEntitiesOne entities = new dbAirlineProjectEntitiesOne();

        [HttpGet]
        [Route("api/FlightSearch/Schedule")]

        public IEnumerable<proc_getSchedule_Result> getSchedule(DateTime date, string source, string destination)
        {
            List<proc_getSchedule_Result> result = entities.proc_getSchedule(date, source, destination).ToList();
            return result;
        }

        //[HttpGet]
        //[Route("api/FlightSearch/Schedule")]

        //public IEnumerable<ScheduleResult> getSchedule(DateTime date, string source, string destination)
        //{

        //    List<ScheduleResult> result = new List<ScheduleResult>();
        //    ScheduleResult sched_res = new ScheduleResult();
        //    List<proc_getSchedule_Result> sched_result = entities.proc_getSchedule(date, source, destination).ToList();

        //    foreach (var item in sched_result)
        //    {
        //        sched_res.Schedule_ID = item.Schedule_ID;
        //        sched_res.Flight_ID = (int)item.Flight_ID;
        //        sched_res.Destination = item.Destination;
        //        sched_res.Source = item.Source_Loc;
        //        sched_res.Dep_Date = (DateTime)item.Dep_Date;
        //        sched_res.Arr_Time = (DateTime)item.Arr_Time;
        //        sched_res.Dep_Time = (DateTime)item.Dep_Time;
        //        sched_res.Duration = (DateTime)item.Duration;
        //        //List<proc_getPrice_Result> prices = entities.proc_getPrice(item.Schedule_ID).ToList();
        //        //sched_res.Prices = prices;
        //        result.Add(sched_res);

        //    }

        //    return result;
        //}

        //[HttpGet]
        //[Route("api/FlightSearch/ReturnPrice")]

        //public IEnumerable<proc_ReturnPrice_Result> getPrice(int Schedule_ID)
        //{
        //    List<proc_ReturnPrice_Result> result = entities.pr(Schedule_ID).ToList();
        //    return result;
        //}







    }
}
