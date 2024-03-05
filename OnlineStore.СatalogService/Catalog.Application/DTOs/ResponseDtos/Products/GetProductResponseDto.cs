namespace Catalog.Application.DTOs.ResponseDtos.Products
{
    public class GetProductResponseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ManufacturerId { get; set; }
        public bool IsDiscount { get; set; }
        public int Price { get; set; }
        public DateTime AddingDate { get; set; }
    }
}