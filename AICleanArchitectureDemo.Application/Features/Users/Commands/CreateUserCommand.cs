using MediatR;

namespace AICleanArchitectureDemo.Application.Features.Users.Commands;

public record CreateUserCommand(string Name, string Email) : IRequest<int>;
