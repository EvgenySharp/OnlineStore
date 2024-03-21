using Auth.DataAccessLayer.Enums;

namespace Auth.BuisnessLayer.DTOs.ResponseDTOs
{
    public class RegisterUserResponseDto
    {
        public string Name { get; set; }
        public Roles Role { get; set; }
    }
}