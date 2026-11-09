using CuraFlow.Application.Common.Models;
using CuraFlow.Application.Features.Identity.Dtos;
using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.Identity.Queries.GetUsers;

public sealed record GetUsersQuery() : IRequest<Result<PagenatedList<UserDto>>>;