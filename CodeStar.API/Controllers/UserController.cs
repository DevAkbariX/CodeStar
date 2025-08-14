using CodeStar.API.Security;
using CodeStar.Application.Common;
using CodeStar.Application.DTOs.User;
using CodeStar.Application.Interfaces;
using CodeStar.Application.Interfaces.Repository;
using CodeStar.Application.Utilities;
using CodeStar.Domain.Entities;
using CodeStar.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CodeStar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserServices _user;
        IinstructorRequestService _Ireq;
        private readonly CodeStarDbContext _db;
        public UserController(IUserServices user, IinstructorRequestService Ireq,CodeStarDbContext db)
        {
            _user = user;
            _Ireq = Ireq;
            _db = db;
        }

        [AuthorizePermission("InsertUser")]
        [HttpPost]
        public async Task<IActionResult> InsertUser(UserInsertDTO dTO)
        {
            try
            {

                if (dTO == null)
                {
                    return BadRequest(Result<bool>.FailureResult("مشکل در ورودی ها !"));
                }

                var res = await _user.UserInsert(dTO);

                if (!res.Success)
                {
                    return BadRequest(Result<bool>.FailureResult(res.Message, res.Errors));
                }

                return Ok(Result<bool>.SuccessResult(true, "کاربر با موفقیت اضافه شد"));


            }
            catch (Exception ex)
            {
                return StatusCode(500, Result<bool>.FailureResult("خطای سرور", new List<string> { ex.Message }));
            }
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUser(long Id)
        {
            try
            {
                if (Id == null)
                {
                    return BadRequest(Result<bool>.FailureResult("کاربری برای حدف یافت نشد  !"));
                }
                var res =await _user.DeleteUser(Id);

                return Ok(Result<bool>.SuccessResult(true, "کاربر با موفقیت حذف شد"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, Result<bool>.FailureResult("خطای سرور", new List<string> { ex.Message }));
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateUser(int Id, [FromBody] UserUpdateDTO dto)
        {
            try
            {
                if (Id <= 0 || dto == null)
                {
                    return BadRequest(Result<bool>.FailureResult("کاربری برای ویرایش یافت نشد  !"));
                }
                var res = await _user.UpdateUser(Id,dto);

                if (!res.Success)
                {
                    return BadRequest(Result<bool>.FailureResult(res.Message, res.Errors));
                }

                return Ok(Result<bool>.SuccessResult(true, "کاربر با موفقیت به‌روزرسانی شد"));

            }
            catch (Exception ex)
            {
                return StatusCode(500, Result<bool>.FailureResult("خطای سرور", new List<string> { ex.Message }));
            }

         }



        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {

            var user = _db.Users.FirstOrDefault(u => u.UserName == dto.UserName);
            if (user == null) return Unauthorized("Invalid credentials");

            
            bool isPasswordValid = AuthHelper.VerifyPassword(dto.Password, user.Password);
            if (!isPasswordValid) return Unauthorized("Invalid credentials");

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKeyForJwtTesting1234"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

        
    }

    public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}



