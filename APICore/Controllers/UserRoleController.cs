using APICore.Repos.Models;
using APICore.Service;

using Microsoft.AspNetCore.Mvc;

namespace APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleServices userRole;
        public UserRoleController(IUserRoleServices roleServicecs) {
            this.userRole = roleServicecs;
        }

        [HttpPost("assignrolepermission")]
        public async Task<IActionResult> assignrolepermission(List<TblRolepermission> rolepermissions)
        {
            var data = await this.userRole.AssignRolePermission(rolepermissions);
            return Ok(data);
        }

        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var data = await this.userRole.GetAllRoles();
            if(data==null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("GetAllMenus")]
        public async Task<IActionResult> GetAllMenus()
        {
            var data = await this.userRole.GetAllMenus();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("GetAllMenusbyrole")]
        public async Task<IActionResult> GetAllMenusbyrole(string userrole)
        {
            var data = await this.userRole.GetAllMenubyrole(userrole);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("GetMenupermissionbyrole")]
        public async Task<IActionResult> GetMenupermissionbyrole(string userrole,string menucode)
        {
            var data = await this.userRole.GetMenupermissionbyrole(userrole, menucode);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }


    }
}
