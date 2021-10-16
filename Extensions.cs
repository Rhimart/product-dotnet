using Product.Dtos;
using Product.Entities;

namespace Product{
    public static class Extentions{
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto{
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity,
                Category = item.Category,
                CreatedDate = item.CreatedDate
            };
        }
    }
}