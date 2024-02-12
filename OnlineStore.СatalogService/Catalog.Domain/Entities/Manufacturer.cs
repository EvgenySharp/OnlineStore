using System.ComponentModel.DataAnnotations;

namespace Catalog.Domain.Entities
{
    public class Manufacturer
    {
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }
        public IEnumerable<Product>? Products { get; set;}
    }
}