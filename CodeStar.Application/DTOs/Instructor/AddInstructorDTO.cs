using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Application.DTOs.Instructor
{
    public class AddInstructorDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string NationalCode { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string InstructorProfileSummary { get; set; }
        public bool HasPriorExperience { get; set; }
        public int YearsOfExperience { get; set; }
    }
}
