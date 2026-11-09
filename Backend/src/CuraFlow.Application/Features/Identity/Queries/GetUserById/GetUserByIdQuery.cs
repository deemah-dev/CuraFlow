using CuraFlow.Application.Features.Identity.Dtos;
using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.Identity.Queries.GetUserById;

public sealed record GetUserByIdQuery(string UserId) : IRequest<Result<UserDto>>;