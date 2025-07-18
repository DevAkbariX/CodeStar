using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Domain.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Linkdin { get; set; }
        public string Git { get; set; }
        public string Instagram { get; set; }
        public ICollection<TeacherResume> Resumes { get; set; }
        public ICollection<TeacherCertification> Certifications { get; set; }
    }
}
