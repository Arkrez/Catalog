using Catalog.DTOs;
using Catalog.Entities;
namespace Catalog
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item) => new ItemDto
        {
            ID = item.Id,
            Name = item.Name,
            Price = item.Price,
            CreatedDate = item.CreatedDate
        };
    }
}