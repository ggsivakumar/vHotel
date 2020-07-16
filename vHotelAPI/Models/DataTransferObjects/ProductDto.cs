namespace vHotelAPI.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryFk { get; set; }
        public bool Active { get; set; }       
    }
}
