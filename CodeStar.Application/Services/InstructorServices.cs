using CodeStar.Application.Common;
using CodeStar.Application.DTOs.Instructor;
using CodeStar.Application.DTOs.User;
using CodeStar.Application.Interfaces;
using CodeStar.Application.Interfaces.Repository;
using CodeStar.Domain.Entities;
using CodeStar.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Application.Services
{
    public class InstructorServices : IInstructorServices
    {
        IInstructorRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailSender _email;
        public InstructorServices(IHttpContextAccessor httpContextAccessor,IInstructorRepository repository, IEmailSender email)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
            _email = email;
        }
        public async Task<InstructorDetailDTO> GetInstructorDetail(long id)
        {
            var result = await _repository.GetInstructorDetail(id);
            if (result == null)
                return null;
            return result;
        }

        public async Task<Result<bool>> RejectInstructor(long id, string RejectionReason)
        {
            try
            {
                var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim == null)
                    return Result<bool>.FailureResult("خطای سرور: " + "شما در سایت لاگین نیستید");

                var adminId = long.Parse(userIdClaim.Value);


                var result = await _repository.RejectInstructor(id, RejectionReason, adminId);
                if (!result)
                    return Result<bool>.FailureResult("خطای سرور: " + "مشکل در تغییر درخواست");

                var instructor = await _repository.GetInstructorDetail(id);
                var template = File.ReadAllText("Templates/RejectInstructorTemplate.html");
                var body = template.Replace("{{RejectionReason}}", RejectionReason);
                await _email.SendEmailAsync(instructor.Email, "رد درخواست مدرس", body);


                await _email.SendEmailAsync(instructor.Email, "رد درخواست مدرسی در CodeStar", body);

                return Result<bool>.SuccessResult(true, "دلیل رد درخواست شما به کاربر ارسال شد");
            }
            catch (Exception ex)
            {
                return Result<bool>.FailureResult("خطای سرور: " + ex.Message);
            }
        }
    }
}
