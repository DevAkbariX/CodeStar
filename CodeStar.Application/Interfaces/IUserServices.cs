using CodeStar.Application.Common;
using CodeStar.Application.DTOs.User;
using CodeStar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Application.Interfaces
{
    public interface IUserServices
    {
        public Task<Result<bool>> UserInsert(UserInsertDTO dto);
        public Task<Result<bool>> DeleteUser(long Id);
        public Task<Result<UserUpdateDTO>> UpdateUser(int Id,UserUpdateDTO Dto);
        //public Task<Result<GetUserDetailDTO>> GetUserDetail(int Id );
        public Task<Result<bool>> ConfirmEmailAsync(string email, string token);
        public Task<Result<bool>> SendEmailConfirmationAsync(string email);
    }
}
