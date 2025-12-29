using MediatR;

namespace AICleanArchitectureDemo.Application.Features.Orders.Commands;

public record CreateOrderCommand(string SessionId, string CustomerEmail) : IRequest<int>;
