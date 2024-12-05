using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Role_and_Permission_Management.Models
{
    public class AuditLog
    {
    public int Id { get; set; }
    public int LogId { get; set; }
    public int ChangedByUserId { get; set; }
    public int RoleId { get; set; }
    public string Action { get; set; } // e.g., "Add", "Remove", "Update"
    public string OldValue { get; set; }
    public string NewValue { get; set; }
    public DateTime Timestamp { get; set; }
    }
}