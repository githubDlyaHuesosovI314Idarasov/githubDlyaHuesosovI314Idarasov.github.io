using EmailCheckAPI.Models;
using System.Net.Mail;
using System.Net;

namespace EmailCheckAPI.Services
{
    public class EmailService
    {
        private readonly SMTPSettings _smtpSettings;

        public EmailService(SMTPSettings smtpSettings)
        {
            _smtpSettings = smtpSettings;
        }

        public async Task SendEmailAsync(EmailRequest request)
        {
            using var client = new SmtpClient(_smtpSettings.Host, Int32.Parse(_smtpSettings.Port))
            {
                Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpSettings.From, _smtpSettings.Username),
                Subject = request.Subject,
                Body = request.Body,
                IsBodyHtml = true
            };
            mailMessage.To.Add(request.ToEmail);

            await client.SendMailAsync(mailMessage);


        }


    }
}
