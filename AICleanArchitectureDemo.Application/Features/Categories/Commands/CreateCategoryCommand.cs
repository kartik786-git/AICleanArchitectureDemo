using MediatR;

namespace AICleanArchitectureDemo.Application.Features.Categories.Commands;

public record CreateCategoryCommand(string Name, string Description) : IRequest<int>;
