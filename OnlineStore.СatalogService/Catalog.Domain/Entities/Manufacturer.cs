namespace Catalog.Domain.Entities
{
    public class Manufacturer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
    }
}