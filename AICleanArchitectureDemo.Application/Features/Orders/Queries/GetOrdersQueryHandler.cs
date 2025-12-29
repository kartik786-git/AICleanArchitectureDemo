using AICleanArchitectureDemo.Application.DTOs;
using AICleanArchitectureDemo.Domain.Entities;
using AICleanArchitectureDemo.Domain.Interfaces;
using MediatR;

namespace AICleanArchitectureDemo.Application.Features.Orders.Queries;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<OrderDto>>
{
    private readonly IRepository<Order> _orderRepository;

    public GetOrdersQueryHandler(IRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetAllAsync();

        return orders.Select(o => new OrderDto
        {
            Id = o.Id,
            CustomerEmail = o.CustomerEmail,
            OrderDate = o.OrderDate,
            Status = o.Status.ToString(),
            TotalAmount = o.TotalAmount,
            Items = o.Items.Select(i => new OrderItemDto
            {
                ProductId = i.ProductId,
                ProductName = i.Product?.Name ?? string.Empty,
                Quantity = i.Quantity,
                PriceAtTime = i.PriceAtTime
            }).ToList()
        }).ToList();
    }
}
