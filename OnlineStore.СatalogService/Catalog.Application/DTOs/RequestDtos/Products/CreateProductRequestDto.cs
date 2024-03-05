namespace Catalog.Application.DTOs.RequestDtos.Products
{
    public class CreateProductRequestDto
    {
        public string Title { get; set; }
        public Guid ManufacturerId { get; set; }
        public Guid CategoryId { get; set; }
        public bool IsDiscount { get; set; }
        public decimal Price { get; set; }
    }
}