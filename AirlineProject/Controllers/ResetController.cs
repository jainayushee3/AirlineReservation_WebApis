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
    public class ResetController : ApiController
    {
        public class MailPwd
        {
            public string email { get; set; }
            public string pwd { get; set; }
        }
        private  dbAirlineProjectEntitiesOne db = new dbAirlineProjectEntitiesOne();
        [HttpPut]
        public HttpResponseMessage ResetPassword(MailPwd m)
        {
            try
            {
                tblUser user = db.tblUsers.Where(c => c.Email ==m.email).FirstOrDefault();
                if (user == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User doesn't exists");
                }
                else
                {
                    user.Password = m.pwd;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK,user);
                }
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong,reset password failed");
            }
        }
    }
}
