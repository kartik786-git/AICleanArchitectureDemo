using AICleanArchitectureDemo.Domain.Entities;

namespace AICleanArchitectureDemo.Domain.Interfaces;

public interface IOrderRepository : IRepository<Order>
{
    Task<IEnumerable<Order>> GetByCustomerEmailAsync(string email);
}
