using AutoMapper;
using CodeStar.Application.Common;
using CodeStar.Application.DTOs.Category;
using CodeStar.Application.Interfaces.Repository;
using CodeStar.Domain.Entities;
using CodeStar.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Infrastructure.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly CodeStarDbContext _context;
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;
        public CategoryRepository(CodeStarDbContext context, IRepository<Category> repository,IMapper mapper)
        {
            _context = context;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<bool>> InsertCategory(InsertCategoryDTO dTO)
        {
            try
            {
                var check = _context.Category.Where(c=>c.Title == dTO.Title).FirstOrDefault();
                if (check != null)
                    return Result<bool>.FailureResult($"{check.Title} is Already !");

                var category = _mapper.Map<Category>(dTO);
                category.IsActive = true;

                await _repository.AddAsync(category);
                return Result<bool>.SuccessResult(true, "Success Added");
            }
            catch(Exception ex)
            {
                return Result<bool>.FailureResult("Failed to Update user", new List<string> { ex.Message });
            }
        }
    }
}
