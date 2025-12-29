using AICleanArchitectureDemo.Application.DTOs;
using MediatR;

namespace AICleanArchitectureDemo.Application.Features.Orders.Queries;

public record GetOrderByIdQuery(int Id) : IRequest<OrderDto?>;
