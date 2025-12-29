using MediatR;

namespace AICleanArchitectureDemo.Application.Features.Cart.Commands;

public record AddToCartCommand(string SessionId, int ProductId, int Quantity) : IRequest<int>;
