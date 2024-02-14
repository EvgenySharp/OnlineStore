namespace Catalog.Application.DTOs.RequestDtos.Products
{
    public class UptadeProductTitleRequestDto
    {
        public Guid Id { get; set; }
        public string NewTitle { get; set; }
    }
}