using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using vHotelAPI.Contracts;
using vHotelAPI.Models;

namespace vHotelAPI.Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return FindAll().OrderBy(category => category.Name).ToList();
        }

        public Category GetCategoryWithDetails(int categoryId)
        {
            return FindByCondition(category => category.Id.Equals(categoryId))
                 .Include(p => p.Product)
                 .FirstOrDefault();
        }

        public Category GetCateogryById(int categoryId)
        {
            return FindByCondition(category => category.Id.Equals(categoryId))
               .FirstOrDefault();
        }

        public void CreateCategory(Category category)
        {
            Create(category);
        }

        public void UpdateCategory(Category category)
        {
            Update(category);
        }

        public void DeleteCategory(Category category)
        {
            Delete(category);
        }       

        
    }
}
