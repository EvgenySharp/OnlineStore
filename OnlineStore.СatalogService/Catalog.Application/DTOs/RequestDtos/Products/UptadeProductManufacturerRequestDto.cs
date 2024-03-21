namespace Catalog.Application.DTOs.RequestDtos.Products
{
    public class UptadeProductManufacturerRequestDto
    {
        public Guid Id { get; set; }
        public Guid NewManufacturerId { get; set; }
    }
}