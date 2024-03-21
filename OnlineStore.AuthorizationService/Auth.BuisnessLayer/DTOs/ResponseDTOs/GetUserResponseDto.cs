using Auth.DataAccessLayer.Enums;

namespace Auth.BuisnessLayer.DTOs.ResponseDTOs
{
    public class GetUserResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Roles Role { get; set; }
    }
}