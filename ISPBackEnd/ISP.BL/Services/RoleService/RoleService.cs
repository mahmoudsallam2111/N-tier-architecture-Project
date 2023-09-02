using AutoMapper;
using ISP.API.Constants;
using ISP.BL.Dtos.Permission;
using ISP.BL.Dtos.Role;
using ISP.DAL;
using ISP.DAL.Repository.RoleRepository;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ISP.BL.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;
        private readonly IMapper mapper;
        private readonly RoleManager<Role> roleManager;
   
      
        public RoleService(IRoleRepository roleRepository, IMapper mapper, 
            RoleManager<Role> roleManager)
        {
            this.roleRepository = roleRepository;
            this.mapper = mapper;            
            this.roleManager = roleManager;
            
        }

        public async Task<ReadRoleDto> Insert(string roleName)
        {
            var isExist = await roleManager.FindByNameAsync(roleName);
            if (isExist != null)
                return null;


            var role = new Role{Name = roleName};
           
            await roleManager.CreateAsync(role);       


            return mapper.Map<ReadRoleDto>(role);
        }
        
        public async Task<List<ReadRoleDto>> GetAll()
        {        

            var rolesList = await roleRepository.GetAll();
            return mapper.Map<List<ReadRoleDto>>(rolesList);           
        }
       
        public async Task<ReadRoleDto?> GetRoleById(string id)
        {
            var roleDB = await roleRepository.GetByID(id);
            return  mapper.Map<ReadRoleDto>(roleDB);
        }

        public async Task<string?> GetRoleNameByID(string name)
        {
            var roleName = await roleRepository.GetByName(name);
            return roleName;
        }        

        public async Task<ReadRoleDto> Delete(string id)
        {
            var getRole = await roleManager.FindByIdAsync(id);
            if (getRole == null)
            {
                return null;
            }
            getRole.Status = false;
            await roleManager.UpdateAsync(getRole);
            
            return mapper.Map<ReadRoleDto>(getRole);

        }

        public async Task<bool> CreateRoleClaims(WriteRoleDto writeRoleDto)
        {

            var role = await roleManager.FindByNameAsync(writeRoleDto.Name);
            if (role == null)
                return false;


            foreach (var claim in writeRoleDto.claims)
                await roleManager.AddClaimAsync(role, new Claim("Permission", claim));

            return true;
        }

        public async Task<List<ReadPermissions>> GetPermissionByRoleId(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            var claims = roleManager.GetClaimsAsync(role).Result.Select(c => c.Value).ToList();
            
            List<ReadPermissions> permissions = new List<ReadPermissions>();
            foreach (var claim in claims)
            {
                permissions.Add(new ReadPermissions
                {
                    type = claim,
                    value = true
                }); 
            }
            return permissions;
        }

        public async Task<bool> UpdatePermissionsOfRole(string id, List<string> permissionsList)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
                return false;
            
            var claims = roleManager.GetClaimsAsync(role).Result.ToList();


            foreach (var claim in claims)
                await roleManager.RemoveClaimAsync(role, claim);                      
            
            
            foreach (var claimValue in permissionsList)
                await roleManager.AddClaimAsync(role, new Claim("Permission", claimValue));

            return true;

        }

        public async Task<List<string>> GetAllPermissions()
        {
            return DAL.PermissionsData.Permissions.PermissionsList();
        }
    }
}
