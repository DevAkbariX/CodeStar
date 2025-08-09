using CodeStar.Application.Common;
using CodeStar.Application.DTOs.Instructor;
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
    public class InstructorRepository : IInstructorRepository
    {
        private readonly CodeStarDbContext _context;
        private readonly IRepository<Instructor> _repository;
        public InstructorRepository(CodeStarDbContext context,IRepository<Instructor> repository)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<Instructor?> GetByEmailAsync(string email)
        {
            try
            {
                var result =await _context.Instructors.Where(i=>i.Email==email).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<InstructorDetailDTO> GetInstructorDetail(long id)
        {
            return await _context.Instructors.Include(i=>i.Role).Where(n => n.Id == id).Select(s => new InstructorDetailDTO
            {
                Id = s.Id,
                ProcessedByAdminId = s.ProcessedByAdminId,
                Email = s.Email,
                Status = s.Status,
                UserName = s.UserName,
                YearsOfExperience = s.YearsOfExperience,
                EmailConfirmationToken = s.EmailConfirmationToken,
                EmailTokenExpiration = s.EmailTokenExpiration,
                FullName = s.FullName,
                HasPriorExperience = s.HasPriorExperience,
                InstructorMedia = s.InstructorMedia,
                InstructorProfileSummary = s.InstructorProfileSummary,
                IsEmailConfirmed = s.IsEmailConfirmed,
                Mobile = s.Mobile,
                NationalCode = s.NationalCode,
                ProcessedAt = s.ProcessedAt,
                Profile = s.Profile,
                RejectionReason = s.RejectionReason,
                RequestedAt = s.RequestedAt,
                PersionTitle = s.Role.PersionTitle,
            }).SingleOrDefaultAsync(); 
        }

        public async Task<Result<bool>> InsertInstructor(Instructor instructor)
        {
            try
            {
                await _repository.AddAsync(instructor);
                return Result<bool>.SuccessResult(true,"Success To Add");
            }
            catch (Exception ex)
            {

                return Result<bool>.FailureResult("Faild To Add Instructor", new List<string> { ex.Message });
            }
        }

        public async Task<Result<bool>> UpdateInstructor(Instructor instructor)
        {
            try
            {
                await _repository.UpdateAsync(instructor);
                return Result<bool>.SuccessResult(true, "User updated successfully");
            }
            catch (Exception ex)
            {

                return Result<bool>.FailureResult("Failed to Update user", new List<string> { ex.Message });
            }
        }
    }
}
