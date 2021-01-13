using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Web.Http.Cors;
using AirlineProject.Models;

namespace AirlineProject.Controllers
{
   
   
    public class Email{
        public string mailto { get; set; }
        public int otp { get; set; }
    }
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class SendMailController : ApiController
    {
            [HttpPost]

            public HttpResponseMessage SendEmail(Email user)
            {
                try
                {
                    string subject = "LTI Airlines";
                    string body = user.otp+" is your OTP ";
                    string FromMail = "ayushee.tbmun@gmail.com";
                    string emailTo = user.mailto;
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com",587);
                    mail.From = new MailAddress(FromMail);
                    mail.To.Add(emailTo);
                    mail.Subject = subject;
                    mail.Body = body;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("ayushee.tbmun@gmail.com", "Ayushee$4j");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                  return Request.CreateResponse(HttpStatusCode.OK, "Mail sent Successfully");  
            }
                catch (Exception)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest,"Sorry! We couldn't send email");
                }
            }
    }
}
