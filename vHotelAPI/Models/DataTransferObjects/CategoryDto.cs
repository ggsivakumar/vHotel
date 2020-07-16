using System;
using System.Collections.Generic;

namespace vHotelAPI.Models
{
    public class CategoryDto
    {       
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }
    }
}
