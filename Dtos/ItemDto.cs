using System;

namespace Catalog.DTOs
{
        public record ItemDto
    {
        public Guid ID{get; init;}
        public string Name{get; init;}
        public decimal Price {get; init;}
        public DateTimeOffset CreatedDate {get; init;} 
    }
}