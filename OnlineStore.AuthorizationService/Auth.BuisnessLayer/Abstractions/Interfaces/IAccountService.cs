using Auth.BuisnessLayer.DTOs.RequestDTOs;
using Auth.BuisnessLayer.DTOs.ResponseDTOs;

namespace Auth.BuisnessLayer.Abstractions.Interfaces
{
    public interface IAccountService
    {
        Task<RegisterUserResponseDto> RegisterUserAsync(RegisterUserRequestDto registerUserRequestDto, CancellationToken cancellationToken);
        Task<UsersPageResponseDto> GetAllUserAsync(GetUserRequestDto getUserRequestDto, CancellationToken cancellationToken);
        Task<GetUserResponseDto> GetUserByIdAsync(Guid id, CancellationToken cancellationToken);
        Task DeleteUserByIdAsync(Guid id, CancellationToken cancellationToken);
        Task СhangePasswordAsync(СhangePasswordRequestDto changePasswordRequestDto, CancellationToken cancellationToken);
        Task<LoginUserResponseDto> LoginUserAsync(LoginUserRequestDto loginUserRequestDto, CancellationToken cancellationToken);
    }
}