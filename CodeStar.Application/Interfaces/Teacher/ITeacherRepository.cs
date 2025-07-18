using CodeStar.Application.Common;
using CodeStar.Application.DTOs.Teacher;
using CodeStar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Application.Interfaces.Teacher
{
    public interface ITeacherRepository
    {
        Task<string> GetBuyUserNameTeacher(string Email);
        Task<Result<bool>> InsertTeacher(InsertTeacherDTO teacher);
    }
}
