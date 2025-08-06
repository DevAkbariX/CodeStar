using CodeStar.Application.Common;
using CodeStar.Application.Interfaces.Repository;
using CodeStar.Domain.Entities;
using CodeStar.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Infrastructure.Repository
{
    public class InstructorRequestRepository : IinstructorRequestRepository
    {
        private readonly CodeStarDbContext _context;
        private readonly IRepository<Instructor> _repository;


        public InstructorRequestRepository(CodeStarDbContext context, IRepository<Instructor> repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<Result<bool>> InsertAsync(Instructor user)
        {
            try
            {
                await _repository.AddAsync(user);
                return Result<bool>.SuccessResult(true, "Success Added");
            }
            catch (Exception ex)
            {
                return Result<bool>.FailureResult("Failed to add user", new List<string> { ex.Message });
            }
        }

    }
}
