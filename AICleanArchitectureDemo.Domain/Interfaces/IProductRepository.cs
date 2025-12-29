using AICleanArchitectureDemo.Domain.Entities;

namespace AICleanArchitectureDemo.Domain.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);
    Task<IEnumerable<Product>> SearchAsync(string query);
}
