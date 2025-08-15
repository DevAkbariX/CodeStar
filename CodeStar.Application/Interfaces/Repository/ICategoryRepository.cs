using CodeStar.Application.Common;
using CodeStar.Application.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Application.Interfaces.Repository
{
    public interface ICategoryRepository
    {
        Task<Result<bool>> InsertCategory(InsertCategoryDTO dTO);
    }
}
