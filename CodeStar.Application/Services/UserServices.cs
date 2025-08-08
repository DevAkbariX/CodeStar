using CodeStar.Application.Common;
using CodeStar.Application.DTOs.User;
using CodeStar.Application.Interfaces;
using CodeStar.Application.Interfaces.Repository;
using CodeStar.Application.Utilities;
using CodeStar.Domain.Entities;
using CodeStar.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _repository;
        private readonly IEmailSender _email;
        public UserServices(IUserRepository repository,IEmailSender email)
        {
            _repository = repository;
            _email = email;
        }

        public async Task<Result<bool>> ConfirmEmailAsync(string email, string token)
        {
            var user = await _repository.GetByEmailAsync(email);

            if (user == null || user.EmailConfirmationToken != token)
                return Result<bool>.FailureResult("توکن یا ایمیل نامعتبر است");

            if (user.EmailTokenExpiration < DateTime.UtcNow)
                return Result<bool>.FailureResult("توکن منقضی شده است");

            user.IsEmailConfirmed = true;
            user.EmailConfirmationToken = null;
            user.EmailTokenExpiration = null;

            await _repository.UpdateAsync(user);

            return Result<bool>.SuccessResult(true, "ایمیل تأیید شد");
        }
        public async Task<Result<bool>> SendEmailConfirmationAsync(string email)
        {
            var userResult = await _repository.GetByEmailAsync(email);
            if (userResult == null)
                return Result<bool>.FailureResult("کاربری با این ایمیل یافت نشد");

            var user = userResult;

            if (user.IsEmailConfirmed)
                return Result<bool>.FailureResult("ایمیل قبلاً تأیید شده است");

            var token = Guid.NewGuid().ToString();

            user.EmailConfirmationToken = token;
            await _repository.UpdateAsync(user);

            var template = File.ReadAllText("Templates/ConfirmEmailTemplate.html");
            var verifyLink = $"https://localhost:7013/api/account/confirm-email?token={token}&email={user.Email}";
            var body = template.Replace("{{ConfirmLink}}", verifyLink);


            await _email.SendEmailAsync(user.Email, "تأیید ایمیل", body);

            return Result<bool>.SuccessResult(true, "لینک تأیید به ایمیل شما ارسال شد.");
        }
        public async Task<Result<bool>> UserInsert(UserInsertDTO dto)
        {
            try
            {
                if (dto == null)
                {
                    return Result<bool>.FailureResult("ورودی خالی یا اشتباه است");
                }

                var password = AuthHelper.HashPassword(dto.Password);
                var token = Guid.NewGuid().ToString();


                var user = new User()
                {
                    Email = dto.Email,
                    FullName = dto.FullName,
                    Mobile = dto.Mobile,
                    NationalCode = dto.NationalCode,
                    Password = password,
                    UserName = dto.UserName,
                    Fk_RoleId = 1,
                    EmailConfirmationToken = token,
                    EmailTokenExpiration = DateTime.UtcNow.AddHours(24)
                };
                return await _repository.InsertAsync(user);


            }
            catch (Exception ex)
            {
                return Result<bool>.FailureResult("خطایی رخ داد: " + ex.Message);
            }
        }
    }

      
}

