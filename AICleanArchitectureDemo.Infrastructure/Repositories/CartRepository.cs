using AICleanArchitectureDemo.Domain.Entities;
using AICleanArchitectureDemo.Domain.Interfaces;
using AICleanArchitectureDemo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AICleanArchitectureDemo.Infrastructure.Repositories;

public class CartRepository : ICartRepository
{
    private readonly AppDbContext _context;

    public CartRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CartItem?> GetByIdAsync(int id)
    {
        return await _context.CartItems.Include(c => c.Product).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<CartItem>> GetAllAsync()
    {
        return await _context.CartItems.Include(c => c.Product).ToListAsync();
    }

    public async Task AddAsync(CartItem entity)
    {
        await _context.CartItems.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CartItem entity)
    {
        _context.CartItems.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var item = await GetByIdAsync(id);
        if (item != null)
        {
            _context.CartItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<CartItem>> GetBySessionIdAsync(string sessionId)
    {
        return await _context.CartItems.Include(c => c.Product)
            .Where(c => c.SessionId == sessionId).ToListAsync();
    }

    public async Task<CartItem?> GetBySessionAndProductAsync(string sessionId, int productId)
    {
        return await _context.CartItems.Include(c => c.Product)
            .FirstOrDefaultAsync(c => c.SessionId == sessionId && c.ProductId == productId);
    }

    public async Task DeleteBySessionIdAsync(string sessionId)
    {
        var items = await GetBySessionIdAsync(sessionId);
        _context.CartItems.RemoveRange(items);
        await _context.SaveChangesAsync();
    }

    public async Task<int> GetCartCountAsync(string sessionId)
    {
        return await _context.CartItems.Where(c => c.SessionId == sessionId).SumAsync(c => c.Quantity);
    }

    public async Task<decimal> GetCartTotalAsync(string sessionId)
    {
        return await _context.CartItems.Include(c => c.Product)
            .Where(c => c.SessionId == sessionId)
            .SumAsync(c => c.Quantity * (c.Product != null ? c.Product.Price : 0));
    }
}
