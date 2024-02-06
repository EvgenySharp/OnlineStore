namespace Auth.BuisnessLayer.DTOs.RequestDTOs
{
    public class СhangePasswordRequestDto
    {
        public string Name { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}