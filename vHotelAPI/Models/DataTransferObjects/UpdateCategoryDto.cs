namespace vHotelAPI.Models
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
