namespace Catalog.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}