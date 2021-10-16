using Microsoft.AspNetCore.Mvc;
using Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Product.Dtos;
using Product.Entities;

namespace Product.Controllers
{
    //Get /items
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IITemsRepository repository;

        public ItemsController(IITemsRepository repository)
        {
            this.repository = repository;
        }
        //Get /items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select( item => item.AsDto());
            return items;
        }
        //Get /items/{id}
        [HttpGet("{Id}")]
        public ActionResult<ItemDto> GetItem(Guid Id)
        {
            var item = repository.GetItem(Id);
            if (item is null){
                return NotFound();
            }
            return item.AsDto();
        }
        //Post /items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                Category = itemDto.Category,
                Quantity = itemDto.Quantity,
                CreatedDate = DateTimeOffset.UtcNow
            };
            repository.CreateItem(item);
            return CreatedAtAction(nameof(GetItem), new {id = item.Id}, item.AsDto());
        }
        // PUT /items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = repository.GetItem(id);
            if(existingItem is null){
                return NotFound();
            }

            Item updatedItem = existingItem with {
                Name = itemDto.Name,
                Price = itemDto.Price,
                Quantity = itemDto.Quantity,
                Category = itemDto.Category,
            };

            repository.UpdateItem(updatedItem);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id){
            var existingItem = repository.GetItem(id);
            if(existingItem is null){
                return NotFound();
            }
            repository.DeleteItem(id);

            return NoContent();
        }
    }
}