using Microsoft.AspNetCore.Mvc;
using OtpProvider.Web.Services;

namespace OtpProvider.Web.Controllers
{
    public class OtpController : Controller
    {
        [HttpGet]
        public IActionResult SendOtp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendOtp(string email)
        {
            EmailSender emailSender = new EmailSender();
            
            var success =  emailSender.SendEmail(email);
            if(success)
            {
                ViewBag.Message = "OTP sent successfully.";
            }
            else
            {
                ViewBag.Error = "Failed to send OTP.";
            }
            return View();
        }
    }
}
