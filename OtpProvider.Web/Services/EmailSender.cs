using System.Net.Mail;
using System.Net;
namespace OtpProvider.Web.Services
{
    public class EmailSender
    {
        public bool SendEmail(string toEmail)
        {
            var otpCode = new Random().Next(100000, 999999).ToString();
            var smtpServer = "smtp.gmail.com";
            var port = 587;
            var username = "rasel5jtempkibria@gmail.com";
            var password = Environment.GetEnvironmentVariable("app_pass", EnvironmentVariableTarget.User);
            var fromEmail = "rasel5jtempkibria@gmail.com";
          
            try
            {
                using (var client = new SmtpClient(smtpServer, port))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(username, password);

                    var mail = new MailMessage
                    {
                        From = new MailAddress(fromEmail),
                        Subject = "OTP",
                        Body = $"Your Opt: <b>{otpCode}</b>",
                        IsBodyHtml = true
                    };
                    mail.To.Add(toEmail);
                    client.Send(mail);
                }
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                return false;
            }
        }
    }
}
