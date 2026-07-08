using SecureAuthSystem.DTOs;

namespace SecureAuthSystem.Services.Interface
{
    public interface IRoleService
    {

        // Get all roles
        Task<List<RoleDto>> GetRoles();
        // Get role by id
        Task<RoleDto> GetRoleById(int id);
        // Create new role
        Task<string> AddRole(RoleDto roleDto);
        // Update role
        Task<string> UpdateRole(int id, RoleDto roleDto);
        // Delete role
        Task<string> DeleteRole(int id);

    }
}