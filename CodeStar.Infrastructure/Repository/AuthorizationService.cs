using CodeStar.Application.Interfaces;
using CodeStar.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Infrastructure.Repository
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly CodeStarDbContext _context;
        public AuthorizationService(CodeStarDbContext context) { _context = context; }

        public async Task<bool> UserHasPermissionAsync(int userId, string permissionKey)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .ThenInclude(r => r.RolePermissions)
                .ThenInclude(rp => rp.Permission)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null) return false;
            return user.Role.RolePermissions.Any(rp => rp.Permission.Name == permissionKey);
        }

        public async Task<bool> UserIsInRoleAsync(int userId, string roleName)
        {
            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == userId);
            return user != null && string.Equals(user.Role.Title, roleName, StringComparison.OrdinalIgnoreCase);
        }

        public async Task<List<string>> GetUserPermissionsAsync(int userId)
        {
            return await _context.RolePermissions
                .Where(rp => rp.Role.Users.Any(u => u.Id == userId))
                .Select(rp => rp.Permission.Name)
                .Distinct()
                .ToListAsync();
        }
    }
}
