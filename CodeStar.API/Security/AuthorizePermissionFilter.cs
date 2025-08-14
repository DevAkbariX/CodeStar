using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;
using CodeStar.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeStar.API.Security
{
    public class AuthorizePermissionAttribute : Attribute, IAsyncAuthorizationFilter
    {
        private readonly string _permissionName;

        public AuthorizePermissionAttribute(string permissionName)
        {
            _permissionName = permissionName;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                context.Result = new ForbidResult();
                return;
            }
            var userId = long.Parse(userIdClaim.Value);

            var dbContext = context.HttpContext.RequestServices.GetRequiredService<CodeStarDbContext>();

            var hasPermission = await (
                from u in dbContext.Users
                join r in dbContext.Roles on u.Fk_RoleId equals r.Id
                join rp in dbContext.RolePermissions on r.Id equals rp.RoleId
                join p in dbContext.Permissions on rp.Fk_PermissionId equals p.Id
                where u.Id == userId && p.Name == _permissionName
                select p
            ).AnyAsync();

            if (!hasPermission)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
