using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Domain.Entities
{
    public class SkillSpark
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SkillProf { get; set; } //profile Url
        public string View { get; set; }
        public string TotalDuration { get; set; }
        public decimal Price { get; set; }
        public int LikesCount { get; set; }
        public DateTime CreateDate { get;set; }
        public bool isvalid { get; set; }


        #region Rel
        public long InstructorId { get; set; }               
        public Instructor Instructor { get; set; }
        public ICollection<SkillSparkTag> SkillSparkTags { get; set; }
        public ICollection<SkillEpisode> Episodes { get; set; }
        public ICollection<SkillQuestion> SkillQuestions { get; set; }
        #endregion
    }
}
