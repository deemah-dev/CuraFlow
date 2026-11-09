using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.Identity.Commands.RefreshToken;

public sealed record RefreshTokenCommand(string ExpiredAccessToken, string RefreshToken) : IRequest<Result<TokenResponse>>;
