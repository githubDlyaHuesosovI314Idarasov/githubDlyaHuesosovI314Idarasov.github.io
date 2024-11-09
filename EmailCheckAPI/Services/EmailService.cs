using EmailCheckAPI.Models;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;

namespace EmailCheckAPI.Services
{
    public class EmailService
    {
        private readonly SMTPSettings _smtpSettings;

        public EmailService(IOptions<SMTPSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SendEmailAsync(EmailRequest request)
        {
            using (var client = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port))
            {
                client.EnableSsl = _smtpSettings.EnableSSL;
                client.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpSettings.From),
                    Subject = request.Subject,
                    Body = request.Body,
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(request.ToEmail);

                await client.SendMailAsync(mailMessage);
            }
        }


    }
}
