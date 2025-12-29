using AICleanArchitectureDemo.Application.DTOs;
using MediatR;

namespace AICleanArchitectureDemo.Application.Features.Products.Queries;

public record GetProductsQuery : IRequest<List<ProductDto>>;
