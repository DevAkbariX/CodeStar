using CodeStar.Application.Common;
using CodeStar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Application.Interfaces.Repository
{
    public interface IinstructorRequestRepository
    {
        public Task<Result<bool>> InsertAsync(Instructor user);
    }
}
