using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PersionTitle { get; set; }
        public bool IsActived { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Instructor> Instructor { get; set; }
    }
}
