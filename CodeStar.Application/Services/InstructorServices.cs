using CodeStar.Application.Common;
using CodeStar.Application.DTOs.Instructor;
using CodeStar.Application.Interfaces;
using CodeStar.Application.Interfaces.Repository;
using CodeStar.Application.Utilities;
using CodeStar.Domain.Entities;
using CodeStar.Domain.Enums;
using CodeStar.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Application.Services
{
    public class InstructorServices : IInstructorServices
    {
        IInstructorRepository _repository;
        private readonly IEmailSender _email;
        public InstructorServices(IInstructorRepository repository,IEmailSender email)
        {
            _email = email;
            _repository = repository;
        }

        public async Task<Result<bool>> ConfirmEmailAsync(string email, string token)
        {
            var instructor = await _repository.GetByEmailAsync(email);
            if(email==null||instructor.EmailConfirmationToken!=token)
                return Result<bool>.FailureResult("توکن یا ایمیل نامعتبر است");

            if (instructor.EmailTokenExpiration < DateTime.UtcNow)
                return Result<bool>.FailureResult("توکن منقضی شده است");
            instructor.IsEmailConfirmed = true;
            instructor.EmailConfirmationToken = null;
            instructor.EmailTokenExpiration = null;

            await _repository.UpdateInstructor(instructor);
            return Result<bool>.SuccessResult(true, "ایمیل تأیید شد");
        }

        public async Task<InstructorDetailDTO> GetInstructorDetail(long id)
        {
            var result = await _repository.GetInstructorDetail(id);
            if (result == null)
                return null;
            return result;
        }

        public async Task<Result<bool>> InstructorInserts(InstructorInsertDTO dTO)
        {
            try
            {
                if (dTO == null)
                    return Result<bool>.FailureResult("ورودی خالی یا اشتباه است");
                var password = AuthHelper.HashPassword(dTO.Password);
                var token = Guid.NewGuid().ToString();
                var instructor = new Instructor()
                {
                    Email = dTO.Email,
                    EmailConfirmationToken = token,
                    EmailTokenExpiration = DateTime.UtcNow.AddHours(24),
                    Fk_RoleId = 4,
                    FullName = dTO.FullName,
                    HasPriorExperience = dTO.HasPriorExperience,
                    Mobile = dTO.Mobile,
                    NationalCode = dTO.NationalCode,
                    Password = password,
                    UserName = dTO.UserName,
                    InstructorProfileSummary = dTO.InstructorProfileSummary,
                    YearsOfExperience = dTO.YearsOfExperience,
                    IsEmailConfirmed = false,
                    Status = RequestStatusEnum.Pending
                };
                return await _repository.InsertInstructor(instructor);
            }
            catch (Exception ex)
            {

                return Result<bool>.FailureResult("خطایی رخ داده : " + ex.Message);
            }
        }

        public async Task<Result<bool>> SendEmailConfirmationAsync(string email)
        {
            var instructorResult = await _repository.GetByEmailAsync(email);
            if (instructorResult == null)
                return Result<bool>.FailureResult("ایمیلی یافت نشد");
            var instructor = instructorResult;
            if (instructor.IsEmailConfirmed)
                return Result<bool>.FailureResult("این ایمیل قبلا تایید شده است");

            var template = File.ReadAllText("Templates/ConfirmEmailTemplateResume.html");
            var verifyLink = $"https://localhost:7013/api/Instructor/confirm-email?token={instructor.EmailConfirmationToken}&email={instructor.Email}";
            var body = template.Replace("{{ConfirmLink}}", verifyLink);

            await _email.SendEmailAsync(instructor.Email, "تأیید ایمیل", body);
            return Result<bool>.SuccessResult(true, "لینک تأیید به ایمیل شما ارسال شد.");
        }
    }
}
