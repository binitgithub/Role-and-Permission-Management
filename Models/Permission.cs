using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Role_and_Permission_Management.Models
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}