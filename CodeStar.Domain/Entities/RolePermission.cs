using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Domain.Entities
{
    public class RolePermission
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public int Fk_PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
