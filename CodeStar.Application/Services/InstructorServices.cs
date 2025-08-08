using CodeStar.Application.Common;
using CodeStar.Application.DTOs.Instructor;
using CodeStar.Application.Interfaces;
using CodeStar.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Application.Services
{
    public class InstructorServices : IInstructorServices
    {
        IInstructorRepository _repository;
        public InstructorServices(IInstructorRepository repository)
        {
            _repository = repository;
        }
        public async Task<InstructorDetailDTO> GetInstructorDetail(long id)
        {
            var result = await _repository.GetInstructorDetail(id);
            if (result == null)
                return null;
            return result;
        }
    }
}
