
using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Entities;
using System.Collections.Generic;
using System;
using System.Linq;
using Catalog.DTOs;
using Catalog.DtOs;


namespace Catalog.Controllers
{
    //Get / items

    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;

        }
        //Get / items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(item => item.AsDto());
            return items;
        }
        // Get / items / {id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);
            if(item is null )
            {
                return NotFound();
            }
            return item.AsDto();;
        }
        // POST / items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new(){
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
            
            repository.CreateItem(item);
            return CreatedAtAction(nameof(GetItem), new {id = item.Id}, item.AsDto());
        }
        // PUT /items/
        [HttpPut("{id")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = repository.GetItem(id);
            if (existingItem is null)
                return NotFound();

            Item updatedItem = existingItem with {
                Name = itemDto.Name,
                Price = itemDto.Price
            };
            repository.UpdateItem(updatedItem);
            return NoContent();
        }
    }
}