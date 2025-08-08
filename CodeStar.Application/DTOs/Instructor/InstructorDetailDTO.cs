using CodeStar.Domain.Entities;
using CodeStar.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Application.DTOs.Instructor
{
    public class InstructorDetailDTO
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string NationalCode { get; set; }
        public string UserName { get; set; }
        public string? Profile { get; set; }
        public string InstructorProfileSummary { get; set; }
        public bool HasPriorExperience { get; set; }
        public int YearsOfExperience { get; set; }
        public DateTime RequestedAt { get; set; } = DateTime.Now;
        public RequestStatusEnum Status { get; set; } = RequestStatusEnum.Pending;
        public string? RejectionReason { get; set; }
        public int? ProcessedByAdminId { get; set; }
        public DateTime? ProcessedAt { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string? EmailConfirmationToken { get; set; }
        public DateTime? EmailTokenExpiration { get; set; }

        public InstructorMedia? InstructorMedia { get; set; }
        public string PersionTitle { get; set; }
    }
}
