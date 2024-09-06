using Application;
using Application.UseCases.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail([FromBody] EmailDTO dto, [FromServices] IEmailService emailService)
        {
            try
            {
                await _emailService.SendEmailAsync(dto.ToEmail, dto.Subject, dto.Body);
                return Ok("Email sent successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }

}
