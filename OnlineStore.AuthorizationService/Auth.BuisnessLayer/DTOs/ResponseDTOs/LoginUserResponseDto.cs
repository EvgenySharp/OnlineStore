using Auth.DataAccessLayer.Enums;

namespace Auth.BuisnessLayer.DTOs.ResponseDTOs
{
    public class LoginUserResponseDto
    {
        public string Name { get; set; }
        public string Token { get; set; }
        public Roles Role { get; set; }
    }
}