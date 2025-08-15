using CodeStar.Application.Common;
using CodeStar.Application.DTOs.Instructor;
using CodeStar.Application.Interfaces.Repository;
using CodeStar.Domain.Entities;
using CodeStar.Domain.Enums;
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
        public InstructorRepository(CodeStarDbContext context, IRepository<Instructor> repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<bool> ApproveInstructor(long id, long AdminId)
        {
            try
            {
                var user = await _repository.GetByIdAsync(id);
                if (user == null)
                    return false;
                user.ProcessedByAdminId = (int?)AdminId;
                user.ProcessedAt = DateTime.Now;
                user.Status = RequestStatusEnum.Approved;
                await _repository.UpdateAsync(user);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<Instructor> GetByEmail(string email)
        {
            try
            {
                var result = await _context.Instructors.Where(i=>i.Email==email).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<InstructorDetailDTO> GetInstructorDetail(long id)
        {
            var instructor = await _context.Instructors
                .Where(i => i.Id == id)
                .Select(i => new InstructorDetailDTO
                {
                    Id = i.Id,
                    ProcessedByAdminId = i.ProcessedByAdminId,
                    Email = i.Email,
                    Status = i.Status,
                    UserName = i.UserName,
                    YearsOfExperience = i.YearsOfExperience,
                    EmailConfirmationToken = i.EmailConfirmationToken,
                    EmailTokenExpiration = i.EmailTokenExpiration,
                    FullName = i.FullName,
                    HasPriorExperience = i.HasPriorExperience,
                    InstructorMedia = i.InstructorMedia,
                    InstructorProfileSummary = i.InstructorProfileSummary,
                    IsEmailConfirmed = i.IsEmailConfirmed,
                    Mobile = i.Mobile,
                    NationalCode = i.NationalCode,
                    ProcessedAt = i.ProcessedAt,
                    Profile = i.Profile,
                    RejectionReason = i.RejectionReason,
                    RequestedAt = i.RequestedAt,
                    PersionTitle = i.Role != null ? i.Role.PersionTitle : null,
                })
                .FirstOrDefaultAsync();

            return instructor;
        }

        public async Task<Result<bool>> InsertInstructor(Instructor instructor)
        {
            try
            {
                await _repository.AddAsync(instructor);
                return Result<bool>.SuccessResult(true, "Success Added");

            }
            catch (Exception ex)
            {

                return Result<bool>.FailureResult("Failed to add instructor", new List<string> { ex.Message });
            }
        }

        public async Task<bool> RejectInstructor(long id, string RejectionReason, long AdminId)
        {
            try
            {

                var user = await _repository.GetByIdAsync(id);
                if (user == null)
                {
                    return false;
                }
                user.RejectionReason = RejectionReason;
                user.Status = RequestStatusEnum.Rejected;
                user.ProcessedByAdminId = (int?)AdminId;
                user.ProcessedAt = DateTime.Now;

                await _repository.UpdateAsync(user);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Result<bool>> UpdateInstructor(Instructor instructor)
        {
            try
            {
                 await _repository.UpdateAsync(instructor);
                return Result<bool>.SuccessResult(true, "باموفقیت بروز رسانی شد");
            }
            catch (Exception ex)
            {

                return Result<bool>.FailureResult("Failed to Update user", new List<string> { ex.Message });
            }
        }
    }
}
