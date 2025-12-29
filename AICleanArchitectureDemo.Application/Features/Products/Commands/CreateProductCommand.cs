using MediatR;

namespace AICleanArchitectureDemo.Application.Features.Products.Commands;

public record CreateProductCommand(
    string Name,
    string Description,
    decimal Price,
    int CategoryId,
    int StockQuantity,
    string? ImageUrl) : IRequest<int>;
