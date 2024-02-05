namespace Auth.BuisnessLayer.DTOs.RequestDTOs
{
    public class UpdateUserRequestDto
    {
        public string Name { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}