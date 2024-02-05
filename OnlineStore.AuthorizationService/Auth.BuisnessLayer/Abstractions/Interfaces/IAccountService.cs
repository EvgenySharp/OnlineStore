using Auth.BuisnessLayer.DTOs.RequestDTOs;
using Auth.BuisnessLayer.DTOs.ResponseDTOs;

namespace Auth.BuisnessLayer.Abstractions.Interfaces
{
    public interface IAccountService
    {
        Task<RegisterUserResponseDto> RegisterUserAsync(RegisterUserRequestDto registerUserRequestDto, CancellationToken cancellationToken);
        Task<IEnumerable<GetUserResponseDto>> GetAllUserAsync( CancellationToken cancellationToken);
        Task<GetUserResponseDto> GetUserByIdAsync(Guid id, CancellationToken cancellationToken);
        Task DeleteUserByIdAsync(Guid id, CancellationToken cancellationToken);
        Task UpdatePasswordAsync(UpdateUserRequestDto updateUserRequestDto, CancellationToken cancellationToken);
        Task<LoginUserResponseDto> LoginUserAsync(LoginUserRequestDto loginUserRequestDto, CancellationToken cancellationToken);
        Task<RoleResponseDto> СreateRoleAsync(RoleRequestDto roleRequestDto, CancellationToken cancellationToken);
        Task DeleteRoleByNameAsync(RoleRequestDto roleRequestDto, CancellationToken cancellationToken);
        Task<RoleResponseDto> GetRoleByNameAsync(RoleRequestDto roleRequestDto, CancellationToken cancellationToken);
        Task<IEnumerable<RoleResponseDto>> GetAllRoleAsync(CancellationToken cancellationToken);
    }
}