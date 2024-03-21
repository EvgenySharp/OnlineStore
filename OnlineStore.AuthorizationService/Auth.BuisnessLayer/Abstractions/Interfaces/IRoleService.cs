using Auth.BuisnessLayer.DTOs.RequestDTOs;
using Auth.BuisnessLayer.DTOs.ResponseDTOs;

namespace Auth.BuisnessLayer.Abstractions.Interfaces
{
    public interface IRoleService
    {
        Task DeleteRoleByNameAsync(string roleName, CancellationToken cancellationToken);
        Task<IEnumerable<RoleResponseDto>> GetAllRoleAsync(CancellationToken cancellationToken);
        Task<RoleResponseDto> GetRoleByNameAsync(string roleName, CancellationToken cancellationToken);
        Task<RoleResponseDto> СreateRoleAsync(RoleRequestDto roleRequestDto, CancellationToken cancellationToken);
    }
}