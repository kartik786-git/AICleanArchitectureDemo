using AICleanArchitectureDemo.Application.DTOs;
using MediatR;

namespace AICleanArchitectureDemo.Application.Features.Users.Queries;

public record GetUsersQuery : IRequest<List<UserDto>>;
