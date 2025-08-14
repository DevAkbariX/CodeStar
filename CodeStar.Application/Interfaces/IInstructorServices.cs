using CodeStar.Application.Common;
using CodeStar.Application.DTOs.Instructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Application.Interfaces
{
    public interface IInstructorServices
    {
        Task<InstructorDetailDTO> GetInstructorDetail(long id);
        Task<Result<bool>> RejectInstructor(long id , string RejectionReason);
    }
}
