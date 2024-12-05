using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Role_and_Permission_Management.Services;

namespace Role_and_Permission_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("roles")]
    public async Task<IActionResult> GetRoles() => Ok(await _roleService.GetAllRolesAsync());

    [HttpPost("roles/{roleId}/permissions/{permissionId}")]
    public async Task<IActionResult> AssignPermissionToRole(int roleId, int permissionId, [FromHeader] int changedByUserId) {
        await _roleService.AssignPermissionToRoleAsync(roleId, permissionId, changedByUserId);
        return Ok("Permission assigned successfully.");
    }
    }
}