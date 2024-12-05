using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Role_and_Permission_Management.Models
{
    public class RolePermission
    {
    public int RoleId { get; set; }
    public Role Role { get; set; }
    public int PermissionId { get; set; }
    public Permission Permission { get; set; }
    public DateTime AssignedAt { get; set; }
    }
}