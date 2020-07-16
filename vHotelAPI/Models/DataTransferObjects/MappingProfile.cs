using AutoMapper;

namespace vHotelAPI.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();

            CreateMap<Product, ProductDto>();

            CreateMap<NewCategoryDto, Category>();

            CreateMap<UpdateCategoryDto, Category>();
        }
    }
}
