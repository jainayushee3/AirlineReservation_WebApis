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
    public class LoginController : ApiController
    {

        dbAirlineProjectEntitiesOne db = new dbAirlineProjectEntitiesOne();

        [HttpGet]
        [Route("api/Login/login")]
        public HttpResponseMessage UserLogin( string Email, string Password)
        {
            try
            {
                proc_LoginCheck_Result result = null;
                result = db.proc_LoginCheck(Email, Password).FirstOrDefault();
                if (result == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Username or Password");
                else
                    return Request.CreateResponse<proc_LoginCheck_Result>(result);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Login Failed");
            }
        }

        [HttpPost]
        [Route("api/Login/register")]
        public HttpResponseMessage RegisterUser(tblUser model)
        {
            try
            {
                tblUser user = db.tblUsers.Where(c => c.Email == model.Email).FirstOrDefault();
                if (user != null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Account already exists");
                }
                else
                {
                    db.tblUsers.Add(model);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Registerd Successfully");
                }
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Registration Failed");
            }
        }
    }
}
