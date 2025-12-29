using AICleanArchitectureDemo.Domain.Entities;
using AICleanArchitectureDemo.Domain.Interfaces;
using MediatR;

namespace AICleanArchitectureDemo.Application.Features.Orders.Commands;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
{
    private readonly ICartRepository _cartRepository;
    private readonly IRepository<Order> _orderRepository;
    private readonly IRepository<Product> _productRepository;

    public CreateOrderCommandHandler(
        ICartRepository cartRepository,
        IRepository<Order> orderRepository,
        IRepository<Product> productRepository)
    {
        _cartRepository = cartRepository;
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        // Get cart items
        var cartItems = await _cartRepository.GetBySessionIdAsync(request.SessionId);
        if (!cartItems.Any())
            throw new InvalidOperationException("Cart is empty");

        // Create order
        var order = new Order
        {
            CustomerEmail = request.CustomerEmail,
            Status = OrderStatus.Pending,
            Items = new List<OrderItem>()
        };

        decimal totalAmount = 0;

        // Convert cart items to order items
        foreach (var cartItem in cartItems)
        {
            var product = await _productRepository.GetByIdAsync(cartItem.ProductId);
            if (product == null)
                throw new InvalidOperationException($"Product {cartItem.ProductId} not found");

            if (product.StockQuantity < cartItem.Quantity)
                throw new InvalidOperationException($"Insufficient stock for product {product.Name}");

            var orderItem = new OrderItem
            {
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity,
                PriceAtTime = product.Price
            };

            order.Items.Add(orderItem);
            totalAmount += orderItem.GetTotalPrice();

            // Reduce stock
            product.UpdateStock(-cartItem.Quantity);
            await _productRepository.UpdateAsync(product);
        }

        order.TotalAmount = totalAmount;

        // Save order
        await _orderRepository.AddAsync(order);

        // Clear cart
        await _cartRepository.DeleteBySessionIdAsync(request.SessionId);

        return order.Id;
    }
}
