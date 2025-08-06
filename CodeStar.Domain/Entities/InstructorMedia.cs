using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Domain.Entities
{
    public class InstructorMedia
    {
        public long Id { get; set; }
        public byte[]? IntroductionVideo { get; set; }


        public long Fk_InstructorID { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<InstructorResume> Resumes { get; set; }
        public ICollection<InstructorCertification> Certifications { get; set; }
    }
}
