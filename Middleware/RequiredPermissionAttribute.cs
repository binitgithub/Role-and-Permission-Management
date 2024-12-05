using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Role_and_Permission_Management.Middleware
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RequiredPermissionAttribute : Attribute
    {
        public string Permission { get; }
        public RequiredPermissionAttribute(string permission) {
        Permission = permission;
    }
    }
}