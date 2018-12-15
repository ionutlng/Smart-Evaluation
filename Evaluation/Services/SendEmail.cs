using System.Net;
using System.Net.Mail;

namespace Evaluation.Services
{
    public class SendEmail
    {
        public static void SendVerificationEmail(string email, string activationCode, string link)
        {
            var fromEmail = new MailAddress("smart.evaluation10@gmail.com", "smart evaluation");

            

            var toEmail = new MailAddress(email);
            var fromEmailPassword = "nota10licenta";
            var subject = "Your account is successfully created!";

            var body = "<br/><br/> Hello " + toEmail + ". Your account is successfully created! " +
                       "Please click on the below link to verify it <br/> <a href=\" " + link + activationCode + " \">LINK</a>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })

            {
                smtp.Send(message);
            }
        }
    }
}