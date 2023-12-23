using APIDevelopmentUsingDapper.Model;

namespace APIDevelopmentUsingDapper.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<int> CreateProductAsync(Product Product);
        Task<bool> UpdateProductAsync(Product Product);
        Task<bool> DeleteProductAsync(int id);
    }
}
