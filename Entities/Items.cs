using System;

namespace Product.Entities
{
    public record Item{
        public Guid Id { get; init;}
        public string Name { get; init;}
        public decimal Price { get; init;}
        public decimal Category { get; init;}
        public decimal Quantity { get; init;}
        public decimal TotalInventory { get; init;}
        public DateTimeOffset CreatedDate { get; init;}
    }
}