using System.Collections.Generic;
using vHotelAPI.Models;

namespace vHotelAPI.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int productId);
        Product GetProductWithDetails(int productId);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        IEnumerable<Product> ProductsByCategory(int categoryId);
    }
}
