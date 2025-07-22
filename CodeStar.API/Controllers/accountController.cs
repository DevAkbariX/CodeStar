using CodeStar.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeStar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class accountController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public accountController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("send-verification-email")]
        public async Task<IActionResult> SendVerificationEmail([FromBody] string email)
        {
            var result = await _userServices.SendEmailConfirmationAsync(email);
            return result.Success  ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            var result = await _userServices.ConfirmEmailAsync(email, token);
            return result.Success ? Ok("ایمیل با موفقیت تأیید شد") : BadRequest(result.Message);
        }
    }
}
