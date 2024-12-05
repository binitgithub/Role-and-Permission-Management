using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Role_and_Permission_Management.Models;

namespace Role_and_Permission_Management.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
        // Configure many-to-many for RolePermission
        modelBuilder.Entity<RolePermission>()
            .HasKey(rp => new { rp.RoleId, rp.PermissionId });

        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Role)
            .WithMany(r => r.RolePermissions)
            .HasForeignKey(rp => rp.RoleId);

        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Permission)
            .WithMany()
            .HasForeignKey(rp => rp.PermissionId);

        // Configure many-to-many for UserRole
        modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);
    }
    }
}