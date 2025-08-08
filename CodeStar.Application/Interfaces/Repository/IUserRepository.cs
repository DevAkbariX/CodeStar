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
        public Task<Result<bool>> UpdateAsync(User user);
        public Task<User?> GetByIdAsync(int id);
        public Task<Result<bool>> DeleteAsync(int id);

        Task<User?> GetByEmailAsync(string email);
    }
}
