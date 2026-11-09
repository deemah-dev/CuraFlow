using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.Identity.Commands.GenerateToken;

public sealed record GenerateTokenCommand(string Email, string Password) : IRequest<Result<TokenResponse>>;
