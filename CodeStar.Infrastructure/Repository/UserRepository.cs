using CodeStar.Application.Common;
using CodeStar.Application.DTOs.User;
using CodeStar.Application.Interfaces.Repository;
using CodeStar.Domain.Entities;
using CodeStar.Infrastructure.Data;
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
        private readonly CodeStarDbContext _context;
        private readonly IRepository<User> _repository;
        

        public UserRepository(CodeStarDbContext context , IRepository<User> repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            try
            {
                var result = _context.Users.Where(c => c.Email == email).FirstOrDefault();
                return  result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            try
            {
                var result = _context.Users.Where(c => c.Id == id).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
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

        public async Task<Result<bool>> UpdateAsync(User user)
        {
            try
            {
                await _repository.UpdateAsync(user);
                return Result<bool>.SuccessResult(true, "User updated successfully");
            }
            catch(Exception ex )
            {
                return  Result<bool>.FailureResult("Failed to Update user", new List<string> { ex.Message });
            }
        }

         async Task<Result<bool>> IUserRepository.DeleteAsync(int id)
        {
            try
            {
                var result = _context.Users.Where(c => c.Id == id).FirstOrDefault();
                await _repository.DeleteAsync(id);
                return Result<bool>.SuccessResult(true, "User deleted successfully");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
