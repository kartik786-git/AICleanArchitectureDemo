using AICleanArchitectureDemo.Domain.Entities;

namespace AICleanArchitectureDemo.Domain.Interfaces;

public interface ICartRepository : IRepository<CartItem>
{
    Task<IEnumerable<CartItem>> GetBySessionIdAsync(string sessionId);
    Task<CartItem?> GetBySessionAndProductAsync(string sessionId, int productId);
    Task DeleteBySessionIdAsync(string sessionId);
    Task<int> GetCartCountAsync(string sessionId);
    Task<decimal> GetCartTotalAsync(string sessionId);
}
