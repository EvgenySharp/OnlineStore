namespace Auth.BuisnessLayer.DTOs.RequestDTOs
{
    public class RegisterUserRequestDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}