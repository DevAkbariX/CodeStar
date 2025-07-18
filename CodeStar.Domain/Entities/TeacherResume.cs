using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Domain.Entities
{
    public class TeacherResume
    {
        public long Id { get; set; }
        public int FK_TeacherID { get; set; }
        public string Title { get; set; }         
        public string Description { get; set; }    
        public string StartDate { get; set; }    
        public string EndDate { get; set; }

        public Teacher Teacher { get; set; }
    }
}
