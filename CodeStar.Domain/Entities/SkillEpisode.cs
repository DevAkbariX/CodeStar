using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Domain.Entities
{
    public class SkillEpisode
    {
        public long Id { get; set; }
        public long SkillSparkId { get; set; }     
        public string Title { get; set; }
        public string Description { get; set; }
        public int EpisodeNumber { get; set; }      
        public int DurationInMinutes { get; set; }  
        public string VideoUrl { get; set; }        
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        #region rel
            public SkillSpark SkillSpark { get; set; }
        #endregion
    }
}
