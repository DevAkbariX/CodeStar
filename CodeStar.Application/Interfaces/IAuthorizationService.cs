using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Application.Interfaces
{
    public interface IAuthorizationService
    {
        Task<bool> UserHasPermissionAsync(int userId, string permissionKey);
        Task<bool> UserIsInRoleAsync(int userId, string roleName);
        Task<List<string>> GetUserPermissionsAsync(int userId);
    }
}
