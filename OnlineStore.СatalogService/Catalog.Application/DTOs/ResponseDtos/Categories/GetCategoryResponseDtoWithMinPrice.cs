namespace Catalog.Application.DTOs.ResponseDtos.Categories
{
    public class GetCategoryResponseDtoWithMinPrice
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int MinPrice { get; set; }
    }
}