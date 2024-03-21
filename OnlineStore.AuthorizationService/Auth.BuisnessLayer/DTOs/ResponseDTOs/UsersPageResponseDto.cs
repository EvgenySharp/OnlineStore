namespace Auth.BuisnessLayer.DTOs.ResponseDTOs
{
    public class UsersPageResponseDto
    {
        public IEnumerable<GetUserResponseDto> Users { get; set; }
        public int TotalUsersCount { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
    }
}