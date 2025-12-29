using AICleanArchitectureDemo.Application.DTOs;
using MediatR;

namespace AICleanArchitectureDemo.Application.Features.Cart.Queries;

public record GetCartQuery(string SessionId) : IRequest<List<CartItemDto>>;
