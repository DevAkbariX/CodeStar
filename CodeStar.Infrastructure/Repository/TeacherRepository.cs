using CodeStar.Application.DTOs.Teacher;
using CodeStar.Application.Interfaces.Teacher;
using CodeStar.Application.Interfaces;
using CodeStar.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodeStar.Application.Common;
using CodeStar.Domain.Entities;

namespace CodeStar.Infrastructure.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly IRepository<Domain.Entities.Teacher> _repository;
        private readonly CodeStarDbContext _context;
        public TeacherRepository(IRepository<Domain.Entities.Teacher> repository, CodeStarDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<string> GetBuyUserNameTeacher(string email)
        {
            try
            {
                var result = await _context.Teachers.FirstOrDefaultAsync(c => c.Email == email);

                return result?.FullName;
            }
            catch (Exception ex)
            {
                var exs = ex.Message;
                return null;
            }
        }

        public async Task<Result<bool>> InsertTeacher(InsertTeacherDTO teacher)
        {
            if (await GetBuyUserNameTeacher(teacher.Email) != null)
            {
                return Result<bool>.FailureResult(
                "ایمیل تکراری است.",
                new List<string> { "یک مدرس با این ایمیل قبلاً ثبت شده است." });
            }
            var entity = new Teacher
            {
                FullName = teacher.FullName,
                Email = teacher.Email,
                Git = teacher.Git,
                Instagram = teacher.Instagram,
                Linkdin = teacher.Linkdin,
            };

            await _repository.AddAsync(entity);

            return Result<bool>.SuccessResult(true, "مدرس با موفقیت افزوده شد.");
        }
    }
}