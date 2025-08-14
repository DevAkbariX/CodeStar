using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Domain.Entities
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; } // کلید دسترسی (مثلا "AddCourse")
        public string Description { get; set; } // توضیح دسترسی
        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
