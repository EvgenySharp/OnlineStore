using Auth.BuisnessLayer.DTOs.ResponseDTOs;

namespace Auth.BuisnessLayer.Abstractions.Interfaces
{
    public interface ITokenService
    {
        Task SetJwtTokenAsync(LoginUserResponseDto loginUserRequestDTOs, CancellationToken cancellationToken);        
    }
}