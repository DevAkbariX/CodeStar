using CodeStar.Application.Common;
using CodeStar.Application.Interfaces;
using CodeStar.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodeStar.API.Controllers
{
    public class InstructorController : Controller
    {
        IInstructorServices _instructor;
        public InstructorController(IInstructorServices instructor)
        {
            _instructor = instructor;
        }
        public IActionResult Index()
        {
            return View();

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

        [HttpPost("{Reject}")]
        public async Task<IActionResult> RejectInstructor(long id , string RejectionReason)
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
