using CodeStar.Application.Common;
using CodeStar.Application.DTOs.User;
using CodeStar.Application.Interfaces;
using CodeStar.Application.Interfaces.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CodeStar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserServices _user;
        IinstructorRequestService _Ireq;
        public UserController(IUserServices user , IinstructorRequestService Ireq)
        {
            _user = user;
            _Ireq = Ireq;
        }
        [HttpPost]
        public async Task<IActionResult> InsertUser(UserInsertDTO dTO)
        {
            try
            {
                
                if (dTO == null) 
                {
                    return BadRequest(Result<bool>.FailureResult("مشکل در ورودی ها !"));
                }
                if(dTO.Role == 2)
                {
                    var res = await _user.UserInsert(dTO);

                    if (!res.Success)
                    {
                        return BadRequest(Result<bool>.FailureResult(res.Message, res.Errors));
                    }

                    return Ok(Result<bool>.SuccessResult(true, "کاربر با موفقیت اضافه شد"));
                }
                var result = await _Ireq.SubmitRequestAsync(dTO);
                if (!result.Success)
                {
                    return BadRequest(Result<bool>.FailureResult(result.Message, result.Errors));
                }
                return Ok(Result<bool>.SuccessResult("درخواست جهت بررسی به ادمین ارجاع داده شد"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, Result<bool>.FailureResult("خطای سرور", new List<string> { ex.Message }));
            }
        }


    }
}
