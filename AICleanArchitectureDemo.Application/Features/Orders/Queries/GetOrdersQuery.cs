using AICleanArchitectureDemo.Application.DTOs;
using MediatR;

namespace AICleanArchitectureDemo.Application.Features.Orders.Queries;

public record GetOrdersQuery : IRequest<List<OrderDto>>;
