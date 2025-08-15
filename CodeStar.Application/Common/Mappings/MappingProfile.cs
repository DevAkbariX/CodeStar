using AutoMapper;
using CodeStar.Application.DTOs.Category;
using CodeStar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Example 
            // CreateMap<SkillSpark, SkillSparkDto>();
            CreateMap<Category, InsertCategoryDTO>();
            CreateMap<InsertCategoryDTO, Category>();
        }
    }
}
