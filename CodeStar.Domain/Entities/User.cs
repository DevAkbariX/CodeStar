using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Domain.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string NationalCode { get; set; }
        public string? Profile { get;set; }

        public int Fk_RoleId { get; set; }
        public Role Role { get; set; }

        public Master? Master { get; set; }
    }
}
