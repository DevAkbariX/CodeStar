using CodeStar.Application.Common;
using CodeStar.Application.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<Result<bool>> InsertCategory(InsertCategoryDTO dTO);
    }
}
