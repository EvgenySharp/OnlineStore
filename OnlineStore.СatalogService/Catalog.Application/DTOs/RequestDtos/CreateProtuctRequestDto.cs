namespace Catalog.Application.DTOs.RequestDtos
{
    public class CreateProtuctRequestDto
    {
        public string Title { get; set; }
        public Guid ManufacturerId { get; set; }
        public Guid CategoryId { get; set;}
    }
}