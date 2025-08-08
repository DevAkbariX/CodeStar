using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Domain.Entities
{
    public class SkillSparkTag
    {
        public long SkillSparkId { get; set; }
        public SkillSpark SkillSpark { get; set; }

        public long TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
