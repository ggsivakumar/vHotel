using System.Collections.Generic;
using vHotelAPI.Models;

namespace vHotelAPI.Contracts
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCateogryById(int categoryId);
        Category GetCategoryWithDetails(int categoryId);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);      

    }
}
