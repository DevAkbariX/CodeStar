using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStar.Application.DTOs.Instructor;

namespace CodeStar.Application.Interfaces.Repository
{
    public interface IInstructorRepository
    {
        public Task<InstructorDetailDTO> GetInstructorDetail(long id);
        public Task<bool> RejectInstructor(long id , string RejectionReason , long AdminId);
    }
}
