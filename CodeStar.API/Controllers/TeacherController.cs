using CodeStar.Application.DTOs.Teacher;
using CodeStar.Application.Interfaces.Teacher;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeStar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }


        [HttpPost]
        public async Task<IActionResult> RegisterTeacher([FromBody]InsertTeacherDTO teacher)
        {
            if (!ModelState.IsValid)
                return BadRequest("داده‌های ورودی نامعتبر هستند.");

            var result = await _teacherRepository.InsertTeacher(teacher);

            if (!result.Success)
                return BadRequest(new { result.Message, result.Errors });

            return Ok(new
            {
                result.Message,
                result.Data 
            });
        }
    }
}
