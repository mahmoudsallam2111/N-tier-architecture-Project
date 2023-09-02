using ISP.API.Constants;
using ISP.BL.Dtos.Permission;
using ISP.BL.Dtos.Role;
using ISP.BL.Services.RoleService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Permissions.Role.View)]
    
    public class RoleController : ControllerBase
    {        

        private readonly IRoleService roleService;       

        public RoleController(IRoleService roleService ) 
        {
            this.roleService = roleService;
            
        }

        [HttpPost]
        [Authorize(Permissions.Role.Create)]
        [AllowAnonymous]
        public async Task<IActionResult> Add(WriteRoleDto writeRoleDto)
        {
            if (!ModelState.IsValid)            
                return BadRequest(ModelState);
            

            var isAddedRole = await roleService.Insert(writeRoleDto.Name);            

            if (isAddedRole == null)

                return Problem(detail: "Errror in Create Role", statusCode: 404,
                   title: "error", type: "null reference");



            var isAddedClaims = await roleService.CreateRoleClaims(writeRoleDto);

            if (!isAddedClaims)
                return Problem(detail: "Errror in Adding Claims to Role", statusCode: 404,
                  title: "error", type: "null reference");


            return Ok();
        }



        [HttpGet]
        [Authorize(Permissions.Role.View)]
        public async Task<ActionResult<List<ReadRoleDto>>> GetAll()
        {
            return await roleService.GetAll();
        }

                 

        
        [HttpDelete("{id}")]
        [Authorize(Permissions.Role.Delete)]
        public async Task<ActionResult<ReadRoleDto>> Delete( string id)
        {
            var getRole = await roleService.Delete(id);
            if (getRole == null)
            {
                return Problem(detail: "the object does not exsits", statusCode: 404,
                    title: "error", type: "null reference");
            }            
            return getRole;
        }



        [HttpGet("{id}")]
        
        [Authorize(Permissions.Role.View)]
        public async Task<ActionResult<ReadRolePermissions>> GetById(string id)
        {
            var roleName = await roleService.GetRoleNameByID(id);
            if (roleName == null)           
                return NotFound();
            
            var permissions = await roleService.GetPermissionByRoleId(id);


            return new ReadRolePermissions
            {
                claims = permissions,
                name = roleName,
                id = id,
            };
        }


        [HttpPut("{id}")]        
        [Authorize(Permissions.Role.Edit)]
        public async Task<ActionResult> Edit(string id, updateRoleDto updateRole)
        {
           var isUbdated =  await roleService.UpdatePermissionsOfRole( id, updateRole.claims);
            if (!isUbdated)
                return BadRequest();

            return Ok();
        }


        
    }
}
