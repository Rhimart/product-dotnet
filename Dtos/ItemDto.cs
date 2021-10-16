using System;

namespace Product.Dtos
{
     public record ItemDto{
        public Guid Id { get; init;}
        public string Name { get; init;}
        public decimal Price { get; init;}
        public decimal Category { get; init;}
        public DateTimeOffset CreatedDate { get; init;}
    }
}