using CodeStar.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Domain.Entities
{
    public class InstructorRequest
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string NationalCode { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public DateTime RequestedAt { get; set; } = DateTime.Now;
        public RequestStatusEnum Status { get; set; } = RequestStatusEnum.Pending;
        public int? ProcessedByAdminId { get; set; }
        public DateTime? ProcessedAt { get; set; }
    }
}
