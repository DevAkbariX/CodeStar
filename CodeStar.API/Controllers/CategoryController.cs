using CodeStar.Application.Common;
using CodeStar.Application.DTOs.Category;
using CodeStar.Application.Interfaces;
using CodeStar.Domain.Entities;
using CodeStar.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeStar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        ICategoryService _cat;
        public CategoryController(ICategoryService cat)
        {
           _cat = cat;
        }


        [HttpPost("InsertCategory")]
        public async Task<IActionResult> InsertCategory(InsertCategoryDTO dTO)
        {
            try
            {

                if (dTO == null)
                {
                    return BadRequest(Result<bool>.FailureResult("مشکل در ورودی ها !"));
                }

                var res = await _cat.InsertCategory(dTO);

                if (!res.Success)
                {
                    return BadRequest(Result<bool>.FailureResult(res.Message, res.Errors));
                }

                return Ok(Result<bool>.SuccessResult(true, "گروه با موفقیت افزوده شد"));


            }
            catch (Exception ex)
            {
                return StatusCode(500, Result<bool>.FailureResult("خطای سرور", new List<string> { ex.Message }));
            }
        }


    }
}
