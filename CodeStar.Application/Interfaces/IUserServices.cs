using CodeStar.Application.Common;
using CodeStar.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Application.Interfaces
{
    public interface IUserServices
    {
        public Task<Result<bool>> UserInsert(UserInsertDTO dto);
    }
}
