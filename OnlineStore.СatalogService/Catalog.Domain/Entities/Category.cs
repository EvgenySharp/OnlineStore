using System.ComponentModel.DataAnnotations;

namespace Catalog.Domain.Entities
{
    public class Category
    {
        public  Guid Id { get; set; } = Guid.NewGuid(); 

        [MaxLength(100)]
        public string Title { get; set; }
        public IEnumerable<Product>? Products { get; set; }
    }
}