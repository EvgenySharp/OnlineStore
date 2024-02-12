namespace Catalog.Application.DTOs.RequestDtos.Products
{
    public class UptadeProductCategoryRequestDto
    {
        public Guid Id { get; set; }
        public Guid NewCategoryId { get; set; }
    }
}