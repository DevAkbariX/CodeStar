using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Domain.Entities
{
    public class Category
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public string IconUrl { get; set; }
        public bool IsActive { get; set; }
        public ICollection<SkillCategory> SkillCategorys { get; set;}
    }
}
