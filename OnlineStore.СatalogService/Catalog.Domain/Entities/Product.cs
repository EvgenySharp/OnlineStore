namespace Catalog.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }
        public Guid? ManufacturerId { get; set; }
        public Manufacturer? Manufacturer { get; set; }
    }
}