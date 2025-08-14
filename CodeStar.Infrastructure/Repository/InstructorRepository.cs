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
        public InstructorRepository(CodeStarDbContext context)
        {
            _context = context;
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
    }
}
