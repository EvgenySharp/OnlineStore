using Auth.BuisnessLayer.Abstractions.Interfaces;
using Auth.BuisnessLayer.DTOs.ResponseDTOs;
using Auth.BuisnessLayer.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth.BuisnessLayer.Services
{
    public class TokenService : ITokenService
    {
        private readonly IOptions<JwtSettings> _jwtSettings;

        public TokenService(IOptions<JwtSettings> jwtOption) 
        {
            _jwtSettings = jwtOption;
        }

        public void SetJwtToken(LoginUserResponseDto loginUserResponseDto, CancellationToken cancellationToken)
        {
            var claims = new List<Claim>
            {
                new Claim(_jwtSettings.Value.NameClaim, loginUserResponseDto.Name),
                new Claim(_jwtSettings.Value.RoleClaim, loginUserResponseDto.Role.ToString()),
            };

            byte[] secretBytes = Encoding.UTF8.GetBytes("this_is_secret_key_for_jwt_token_generation");
            var key = new SymmetricSecurityKey(secretBytes);
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _jwtSettings.Value.Issuer,
                _jwtSettings.Value.Audience,
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials);

            loginUserResponseDto.Token = new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}