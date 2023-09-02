using ISP.BL.Dtos.Permission;
using ISP.BL.Dtos.Role;

namespace ISP.BL.Services.RoleService
{
    public interface IRoleService 
    {
        Task<ReadRoleDto?> GetRoleById(string id);
        Task<string?> GetRoleNameByID(string id);
        Task<ReadRoleDto> Insert(string roleName);
        Task<List<ReadRoleDto>> GetAll();      
        Task<ReadRoleDto> Delete( string id);

        Task<bool> CreateRoleClaims(WriteRoleDto writeRoleDto);
        Task<List<ReadPermissions>> GetPermissionByRoleId(string id);
        Task<bool> UpdatePermissionsOfRole(string id ,List<string> permissionsList);

        
        Task<List<string>> GetAllPermissions();

    }
}
