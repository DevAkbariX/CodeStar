using CodeStar.Application.Common;
using CodeStar.Application.DTOs.Instructor;
using CodeStar.Domain.Entities;
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
        Task<Result<bool>> InsertInstructorAnyc(AddInstructorDTO dTO);
        public Task<Result<bool>> ConfirmEmailAsync(string email, string token);
        public Task<Result<bool>> SendEmailConfirmationAsync(string email);
    }
}
