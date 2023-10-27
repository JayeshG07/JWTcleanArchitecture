using Domain.Dto;

namespace Infrastructure.Interface
{
    public interface IRoleRepository
    {
        Task<IEnumerable<RoleDto>> GetRolesAsync();
        Task<bool> CreateRoleAsync(RoleDto role);
        Task<bool> DeleteRoleAsync(int id);
    }

}
