using CodeStar.Application.Common;
using CodeStar.Application.DTOs.Instructor;
using CodeStar.Application.DTOs.User;
using CodeStar.Application.Interfaces;
using CodeStar.Application.Interfaces.Repository;
using CodeStar.Application.Utilities;
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
        public InstructorServices(IHttpContextAccessor httpContextAccessor, IInstructorRepository repository, IEmailSender email)
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

        public async Task<Result<bool>> InsertInstructorAnyc(AddInstructorDTO dTO)
        {
            try
            {
                if (dTO == null)
                    return Result<bool>.FailureResult("ورودی خالی یا اشتباه است");

                var password = AuthHelper.HashPassword(dTO.Password);
                var token = Guid.NewGuid().ToString();

                var instructor = new Instructor()
                {
                    FullName=dTO.FullName,
                    Email = dTO.Email.Trim().ToLower(),
                    Mobile = dTO.Mobile,
                    NationalCode = dTO.NationalCode,
                    Password = password,
                    UserName = dTO.UserName,
                    InstructorProfileSummary = dTO.InstructorProfileSummary,
                    HasPriorExperience = dTO.HasPriorExperience,
                    YearsOfExperience = dTO.YearsOfExperience,
                    EmailConfirmationToken = token,
                    IsEmailConfirmed = false,
                    Fk_RoleId=4,
                    
                };
                return await _repository.InsertInstructor(instructor);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Result<bool>> ConfirmEmailAsync(string email, string token)
        {
            var instructor = await _repository.GetByEmail(email);

            if (instructor == null || instructor.EmailConfirmationToken != token)
                return Result<bool>.FailureResult("توکن یا ایمیل نامعتبر است");

            if (instructor.EmailTokenExpiration < DateTime.UtcNow)
                return Result<bool>.FailureResult("توکن منقضی شده است");

            instructor.IsEmailConfirmed = true;
            instructor.EmailConfirmationToken = null;
            instructor.EmailTokenExpiration = null;

            await _repository.UpdateInstructor(instructor);

            return Result<bool>.SuccessResult(true, "ایمیل تأیید شد");
        }

        public async Task<Result<bool>> SendEmailConfirmationAsync(string email)
        {
            var instructorResult = await _repository.GetByEmail(email);
            if (instructorResult == null)
                return Result<bool>.FailureResult("کاربری با این ایمیل یافت نشد");

            var instructor = instructorResult;

            if (instructor.IsEmailConfirmed)
                return Result<bool>.FailureResult("ایمیل قبلاً تأیید شده است");

            var template = File.ReadAllText("Templates/ConfirmEmailTemplateResume.html");
            var verifyLink = $"https://localhost:7013/api/Instructor/confirm-email?token={instructor.EmailConfirmationToken}&email={instructor.Email}";
            var body = template.Replace("{{ConfirmLink}}", verifyLink);


            await _email.SendEmailAsync(instructor.Email, "تأیید ایمیل", body);

            return Result<bool>.SuccessResult(true, "لینک تأیید به ایمیل شما ارسال شد.");
        }
    }
}
