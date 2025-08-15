using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Application.DTOs.Category
{
    public class InsertCategoryDTO
    {
        public string Title { get; set; }
        public int ParentId { get; set; }
        public string IconUrl { get; set; }
    }
}
