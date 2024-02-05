using Auth.BuisnessLayer.Abstractions.Interfaces;
using Auth.BuisnessLayer.DTOs.ResponseDTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth.BuisnessLayer.Services
{
    public class TokenService : ITokenService
    {
        public async Task SetJwtTokenAsync(LoginUserResponseDto loginUserRequestDto, CancellationToken cancellationToken)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, loginUserRequestDto.Name),
                new Claim("Role", loginUserRequestDto.Role.ToString()),
            };

            byte[] secretBytes = Encoding.UTF8.GetBytes("this_is_secret_key_for_jwt_token_generation");
            var key = new SymmetricSecurityKey(secretBytes);
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                "https://localhost:7019",
                "http://localhost:5232",
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials);

            loginUserRequestDto.Token = new JwtSecurityTokenHandler().WriteToken(token);
            return;
        }
    }
}