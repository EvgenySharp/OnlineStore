﻿namespace Catalog.Domain.Entities
{
    public class Manufacturer
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<Product>? Products { get; set;}
    }
}