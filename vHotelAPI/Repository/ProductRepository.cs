using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using vHotelAPI.Contracts;
using vHotelAPI.Models;

namespace vHotelAPI.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return FindAll().OrderBy(product => product.Name).ToList();
        }

        public Product GetProductById(int productId)
        {
            return FindByCondition(product => product.Id.Equals(productId))
              .FirstOrDefault();
        }

        public Product GetProductWithDetails(int productId)
        {
            return FindByCondition(product => product.Id.Equals(productId))
                //.Include(c => c.pr)
                .FirstOrDefault();
        }
        public void CreateProduct(Product product)
        {
            Create(product);
        }

        public void UpdateProduct(Product product)
        {
            Update(product);
        }

        public void DeleteProduct(Product product)
        {
            Delete(product);
        }

        public IEnumerable<Product> ProductsByCategory(int categoryId)
        {
            return FindByCondition(a => a.CategoryFk.Equals(categoryId)).ToList();
        }
    }
}
