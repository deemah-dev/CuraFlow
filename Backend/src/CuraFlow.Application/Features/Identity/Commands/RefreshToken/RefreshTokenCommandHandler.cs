using System.Security.Claims;

using CuraFlow.Application.Common.Interfaces;
using CuraFlow.Application.Features.Identity;
using CuraFlow.Application.Features.Identity.Commands.RefreshToken;
using CuraFlow.Domain.Common.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Application.Features.Identity.Command.RefreshToken;

public class RefreshTokenCommandHandler(IIdentityService identityService, ITokenProvider tokenProvider, IAppDbContext context) : IRequestHandler<RefreshTokenCommand, Result<TokenResponse>>
{
    public async Task<Result<TokenResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var principals = tokenProvider.GetClaimPrincipals(request.ExpiredAccessToken);

        if (principals is null)
        {
            return Error.Conflict(
                code: "Auth.ExpiredAccessToken.Invalid",
                description: "Expired access token is not valid.");
        }

        var userId = principals.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userId is null)
        {
            return Error.Conflict(
                code: "Auth.UserIdClaim.Invalid",
                description: "Invalid userId claim.");
        }

        var userResult = await identityService.GetUserByIdAsync(userId);

        var refreshToken = await context.RefreshTokens.FirstOrDefaultAsync(
            rt => rt.Token == request.RefreshToken
            && rt.UserId == userId, cancellationToken);

        if (refreshToken is null || refreshToken.ExpiresOnUtc <= DateTimeOffset.UtcNow)
        {
            return Error.Conflict(
                code: "Auth.RefreshToken.Expired",
                description: "Refresh token is invalid or has expired.");
        }

        var generateTokenResult = await tokenProvider.GenerateJwtTokenAsync(userResult.Value, cancellationToken);

        if (generateTokenResult.IsError)
        {
            return generateTokenResult.Errors;
        }

        return generateTokenResult.Value;
    }
}