using System;
using System.Collections.Generic;

namespace vHotelAPI.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryFk { get; set; }
        public bool Active { get; set; }

        public virtual Category CategoryFkNavigation { get; set; }
    }
}
