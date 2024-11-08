using EmailCheckAPI.Models;
using EmailCheckAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmailCheckAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest emailRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid email request");
            }

            await _emailService.SendEmailAsync(emailRequest);
            return Ok("Email sent successfully");
        }


    }
}
