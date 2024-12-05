using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Role_and_Permission_Management.Data;
using Role_and_Permission_Management.Models;

namespace Role_and_Permission_Management.Services
{
    public class RoleService
    {
        private readonly ApplicationDbContext _context;

        public RoleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync() => await _context.Roles.ToListAsync();

        public async Task AssignPermissionToRoleAsync(int roleId, int permissionId, int changedByUserId)
        {
            var rolePermission = new RolePermission {
            RoleId = roleId,
            PermissionId = permissionId,
            AssignedAt = DateTime.UtcNow
        };
        _context.RolePermissions.Add(rolePermission);
        await _context.SaveChangesAsync();

        // Log the change
        var log = new AuditLog {
            ChangedByUserId = changedByUserId,
            RoleId = roleId,
            Action = "Assign Permission",
            OldValue = null,
            NewValue = $"PermissionId: {permissionId}",
            Timestamp = DateTime.UtcNow
        };

        _context.AuditLogs.Add(log);
        await _context.SaveChangesAsync();
        }
    }
}