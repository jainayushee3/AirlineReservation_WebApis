using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AirlineProject.Controllers
{

    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class AdminLoginController : ApiController
    {
        [HttpGet]
        public bool Login(string username, string password)
        {
            if (username.Equals("admin", StringComparison.OrdinalIgnoreCase) && password.Equals("adminpass"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
