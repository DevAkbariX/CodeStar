using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Domain.Entities
{
    public class Tag
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsValid { get;set; }
        public ICollection<SkillSparkTag> SkillSparkTags { get; set; }
    }
}
