using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStar.Application.Common;
using CodeStar.Application.DTOs.Instructor;
using CodeStar.Domain.Entities;

namespace CodeStar.Application.Interfaces.Repository
{
    public interface IInstructorRepository
    {
        public Task<InstructorDetailDTO> GetInstructorDetail(long id);
        public Task<bool> RejectInstructor(long id , string RejectionReason , long AdminId);
        Task<Result<bool>> InsertInstructor(Instructor instructor);
        Task<Instructor> GetByEmail(string email);
        Task<Result<bool>> UpdateInstructor(Instructor instructor);
    }
}
