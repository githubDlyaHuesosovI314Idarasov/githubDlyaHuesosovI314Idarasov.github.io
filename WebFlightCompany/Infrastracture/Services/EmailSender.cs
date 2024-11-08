using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace WebFlightCompany.Infrastracture.Services
{
    public class EmailSender : IEmailSender
    {
        private IConfiguration _config;
        public EmailSender(IConfiguration config) {
        
            _config = config;
        }
        public async Task SendEmailAsync(string email, string subject, string? htmlMessage)
        {
            var smtpSettings = _config.GetSection("SmtpSettings");

            SmtpClient smtp = new SmtpClient() {

                Host = smtpSettings["Host"],
                Port = Int32.Parse(smtpSettings["Port"]),
                EnableSsl = Boolean.Parse(smtpSettings["EnableSsl"]),
                Credentials = new NetworkCredential(
                    smtpSettings["Username"],
                    smtpSettings["Password"]
                )

            };

            MailMessage mailMessage = new MailMessage() {

                From = new MailAddress(smtpSettings["From"]),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true,
               
            };
            mailMessage.To.Add(email);

            await smtp.SendMailAsync(mailMessage);

            
        }
    }
}
