using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Role_and_Permission_Management.Data;

namespace Role_and_Permission_Management.Middleware
{
    public class PermissionMiddleware 
    {
        private readonly RequestDelegate _next;

        public PermissionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ApplicationDbContext dbContext) {
        // Retrieve user and check permissions dynamically
        var user = context.User;
        if (user.Identity != null && user.Identity.IsAuthenticated) {
            var userId = int.Parse(user.FindFirst("UserId").Value);
            var requiredPermission = context.GetEndpoint()?.Metadata.GetMetadata<RequiredPermissionAttribute>()?.Permission;

            if (requiredPermission != null) {
                var hasPermission = await dbContext.UserRoles
                    .Where(ur => ur.UserId == userId)
                    .SelectMany(ur => ur.Role.RolePermissions)
                    .AnyAsync(rp => rp.Permission.Name == requiredPermission);

                if (!hasPermission) {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("Forbidden: You do not have the required permission.");
                    return;
                }
            }
        }
         await _next(context);
        }
       
    }
}