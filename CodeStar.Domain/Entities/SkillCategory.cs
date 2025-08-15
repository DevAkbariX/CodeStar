using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Domain.Entities
{
    public class SkillCategory
    {
        public long ID { get; set; }
        public int Fk_Category { get;set; }
        public long Fk_SkillSpark { get; set; }


        #region Rell
        public Category Category { get; set; }
        public SkillSpark SkillSpark { get; set; }
        #endregion
    }
}
