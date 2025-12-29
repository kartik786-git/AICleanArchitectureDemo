using AICleanArchitectureDemo.Domain.Entities;
using AICleanArchitectureDemo.Domain.Interfaces;
using MediatR;

namespace AICleanArchitectureDemo.Application.Features.Cart.Commands;

public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, int>
{
    private readonly ICartRepository _cartRepository;
    private readonly IRepository<Product> _productRepository;

    public AddToCartCommandHandler(ICartRepository cartRepository, IRepository<Product> productRepository)
    {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
    }

    public async Task<int> Handle(AddToCartCommand request, CancellationToken cancellationToken)
    {
        // Check if product exists and is in stock
        var product = await _productRepository.GetByIdAsync(request.ProductId);
        if (product == null)
            throw new KeyNotFoundException("Product not found");
        if (!product.IsInStock() || product.StockQuantity < request.Quantity)
            throw new InvalidOperationException("Product is out of stock or insufficient quantity");

        // Check if item already exists in cart
        var existingItem = await _cartRepository.GetBySessionAndProductAsync(request.SessionId, request.ProductId);
        if (existingItem != null)
        {
            // Update quantity
            existingItem.UpdateQuantity(existingItem.Quantity + request.Quantity);
            await _cartRepository.UpdateAsync(existingItem);
            return existingItem.Id;
        }
        else
        {
            // Add new item
            var cartItem = new CartItem
            {
                SessionId = request.SessionId,
                ProductId = request.ProductId,
                Quantity = request.Quantity
            };
            await _cartRepository.AddAsync(cartItem);
            return cartItem.Id;
        }
    }
}
