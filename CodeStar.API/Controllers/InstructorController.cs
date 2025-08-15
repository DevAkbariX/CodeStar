using CodeStar.API.Security;
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
    public class InstructorController : ControllerBase
    {
        IInstructorServices _instructor;
        public InstructorController(IInstructorServices instructor)
        {
            _instructor = instructor;
        }
        [HttpPost]
        public async Task<IActionResult> AddInstructor(AddInstructorDTO dTO)
        {
            try
            {
                if (dTO == null)
                    return BadRequest(Result<bool>.FailureResult("مشکل در ورودی ها !"));
                var result = await _instructor.InsertInstructorAnyc(dTO);
                if (!result.Success)
                    return BadRequest(Result<bool>.FailureResult(result.Message, result.Errors));
                await _instructor.SendEmailConfirmationAsync(dTO.Email);
                return Ok(Result<bool>.SuccessResult(true, "با موفقیت ثبت شد"));
            }
            catch (Exception ex)
            {

                return StatusCode(500, Result<bool>.FailureResult("خطای سرور", new List<string> { ex.Message }));
            }
        }
        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            var result = await _instructor.ConfirmEmailAsync(email, token);
            return result.Success ? Ok("ایمیل با موفقیت تأیید شد") : BadRequest(result.Message);
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

        [AuthorizePermission("RejectInstructor")]
        [HttpPost("{Reject}")]
        public async Task<IActionResult> RejectInstructor(long id, string RejectionReason)
        {
            try
            {
                var result = await _instructor.RejectInstructor(id, RejectionReason);
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
    }
}
