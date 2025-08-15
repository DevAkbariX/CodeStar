using CodeStar.Application.Common;
using CodeStar.Application.DTOs.Category;
using CodeStar.Application.Interfaces;
using CodeStar.Application.Interfaces.Repository;
using CodeStar.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<bool>> InsertCategory(InsertCategoryDTO dTO)
        {
            try
            {
                return await _repository.InsertCategory(dTO);
            }
            catch(Exception ex)
            {
                return Result<bool>.FailureResult("خطایی رخ داد: " + ex.Message);
            }
        }
    }
}
