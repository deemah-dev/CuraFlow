using System.Security.Claims;

using CuraFlow.Application.Common.Interfaces;
using CuraFlow.Application.Features.Identity;
using CuraFlow.Application.Features.Identity.Dtos;
using CuraFlow.Domain.Common.Results;

namespace CuraFlow.Infrastructure.Identity;

public class TokenProvider : ITokenProvider
{
    public Task<Result<TokenResponse>> GenerateJwtTokenAsync(UserDto user, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ClaimsPrincipal? GetClaimPrincipals(string expiredAccessToken)
    {
        throw new NotImplementedException();
    }
}