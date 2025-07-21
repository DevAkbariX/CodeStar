using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Domain.Entities
{
    public class Master
    {
        public long Id { get; set; }
        public byte[]? IntroductionVideo { get; set; }


        public long Fk_UserId { get; set; }
        public User User { get; set; }
        public ICollection<MasterResume> Resumes { get; set; }
        public ICollection<MasterCertification> Certifications { get; set; }
    }
}
