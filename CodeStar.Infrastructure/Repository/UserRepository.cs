using CodeStar.Application.Common;
using CodeStar.Application.DTOs.User;
using CodeStar.Application.Interfaces.Repository;
using CodeStar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context;
        private readonly IRepository<User> _repository;
        

        public UserRepository(DbContext context , IRepository<User> repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<Result<bool>> InsertAsync(User user)
        {
            try
            {
               await _repository.AddAsync(user);
                return Result<bool>.SuccessResult(true, "Success Added");
            }
            catch(Exception ex)
            {
                return Result<bool>.FailureResult("Failed to add user", new List<string> { ex.Message });
            }
        }
    }
}
