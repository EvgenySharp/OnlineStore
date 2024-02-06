using Auth.BuisnessLayer.DTOs.ResponseDTOs;

namespace Auth.BuisnessLayer.Abstractions.Interfaces
{
    public interface ITokenService
    {
        void SetJwtToken(LoginUserResponseDto loginUserResponseDtos, CancellationToken cancellationToken);        
    }
}