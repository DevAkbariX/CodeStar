using CodeStar.Application.Common;
using CodeStar.Application.DTOs.Instructor;
using CodeStar.Application.Interfaces;
using CodeStar.Application.Services;
using CodeStar.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodeStar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : Controller
    {
        IInstructorServices _instructor;
        public InstructorController(IInstructorServices instructor)
        {
            _instructor = instructor;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstructorDetail(long id)
        {
            try
            {
                var result = await _instructor.GetInstructorDetail(id);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return StatusCode(500, Result<bool>.FailureResult("خطای سرور", new List<string> { ex.Message }));
            }
        }
        [HttpPost]
        public async Task<IActionResult> InstructorInsert(InstructorInsertDTO dTO)
        {
            try
            {
                if (dTO == null)
                    return BadRequest(Result<bool>.FailureResult("مشکل در ورودی ها !"));

                var result = await _instructor.InstructorInserts(dTO);
                if (!result.Success)
                    return BadRequest(Result<bool>.FailureResult(result.Message, result.Errors));

                await SendVerificationEmail(dTO.Email);
                return Ok(Result<bool>.SuccessResult(true, " موفقیت اضافه شد"));
            }
            catch (Exception ex)
            {

                return StatusCode(500, Result<bool>.FailureResult("خطای سرور", new List<string> { ex.Message }));
            }
        }
        [HttpPost("send-verification-email")]
        public async Task<IActionResult> SendVerificationEmail(string email)
        {
            var result = await _instructor.SendEmailConfirmationAsync(email);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }
        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            var result = await _instructor.ConfirmEmailAsync(email, token);
            return result.Success ? Ok("ایمیل با موفقیت تأیید شد") : BadRequest(result.Message);
        }
    }
}
