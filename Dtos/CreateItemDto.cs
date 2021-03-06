

using System.ComponentModel.DataAnnotations;

namespace Product.Dtos
{
     public record CreateItemDto
     {
        [Required]
        public string Name { get; init;}
        [Required]
        [Range(1, 1000)]
        public decimal Price { get; init;}
        [Required]
        [Range(1, 5)]
        public decimal Category { get; init;}
        [Required]
        public decimal Quantity { get; init;}
     }
}