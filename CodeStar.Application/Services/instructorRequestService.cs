using CodeStar.Application.Common;
using CodeStar.Application.DTOs.User;
using CodeStar.Application.Interfaces;
using CodeStar.Application.Interfaces.Repository;
using CodeStar.Application.Utilities;
using CodeStar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Application.Services
{
    public class instructorRequestService : IinstructorRequestService
    {
        private readonly IinstructorRequestRepository _repository;

        public instructorRequestService(IinstructorRequestRepository repository)
        {
          _repository = repository;
        }
        public async Task<Result<bool>> SubmitRequestAsync(UserInsertDTO dto)
        {
            try
            {
                if (dto == null)
                {
                    return Result<bool>.FailureResult("ورودی خالی یا اشتباه است");
                }

                var password = AuthHelper.HashPassword(dto.Password);

                var user = new Instructor()
                {
                    Email = dto.Email,
                    FullName = dto.FullName,
                    Mobile = dto.Mobile,
                    NationalCode = dto.NationalCode,
                    Password = password,
                    UserName = dto.UserName,
                };
                await _repository.InsertAsync(user);
                return Result<bool>.SuccessResult(true, "درخواست ثبت شد");
        


            }
            catch (Exception ex)
            {
                return Result<bool>.FailureResult("خطایی رخ داد: " + ex.Message);
            }
        }
    }
}
