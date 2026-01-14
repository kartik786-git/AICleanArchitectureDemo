using AICleanArchitectureDemo.Application.DTOs;
using AICleanArchitectureDemo.Application.Features.Cart.Queries;

namespace AICleanArchitectureDemo.WebBlazor.Services;

public class CartStateService
{
    private readonly ILogger<CartStateService> _logger;

    public CartStateService(ILogger<CartStateService> logger)
    {
        _logger = logger;
    }

    public string? SessionId { get; private set; }
    public List<CartItemDto> CartItems { get; private set; } = new();

    public event Action? OnCartChanged;

    public void SetSessionId(string sessionId)
    {
        SessionId = sessionId;
    }

    public void UpdateCart(List<CartItemDto> items)
    {
        CartItems = items ?? new List<CartItemDto>();
        OnCartChanged?.Invoke();
    }

    public void ClearCart()
    {
        CartItems.Clear();
        OnCartChanged?.Invoke();
    }

    public decimal GetTotalPrice()
    {
        return CartItems.Sum(item => item.ProductPrice * item.Quantity);
    }

    public int GetTotalItems()
    {
        return CartItems.Sum(item => item.Quantity);
    }
}
