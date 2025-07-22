using CodeStar.Application.Common;
using CodeStar.Application.DTOs.User;
using CodeStar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        public Task<Result<bool>> InsertAsync(User user);
        Task<Result<bool>> UpdateAsync(User user);
        Task<User?> GetByEmailAsync(string email);
    }
}
