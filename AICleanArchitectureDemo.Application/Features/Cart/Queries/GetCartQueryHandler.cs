using AICleanArchitectureDemo.Application.DTOs;
using AICleanArchitectureDemo.Domain.Interfaces;
using MediatR;

namespace AICleanArchitectureDemo.Application.Features.Cart.Queries;

public class GetCartQueryHandler : IRequestHandler<GetCartQuery, List<CartItemDto>>
{
    private readonly ICartRepository _cartRepository;

    public GetCartQueryHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<List<CartItemDto>> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        var cartItems = await _cartRepository.GetBySessionIdAsync(request.SessionId);

        return cartItems.Select(item => new CartItemDto
        {
            Id = item.Id,
            ProductId = item.ProductId,
            ProductName = item.Product?.Name ?? string.Empty,
            ProductPrice = item.Product?.Price ?? 0,
            Quantity = item.Quantity
        }).ToList();
    }
}
