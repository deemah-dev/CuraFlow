using System.Security.Claims;

using CuraFlow.Application.Features.Identity;
using CuraFlow.Application.Features.Identity.Dtos;
using CuraFlow.Domain.Common.Results;

namespace CuraFlow.Application.Common.Interfaces;

public interface ITokenProvider
{
    Task<Result<TokenResponse>> GenerateJwtTokenAsync(UserDto user, CancellationToken cancellationToken = default);
    ClaimsPrincipal? GetClaimPrincipals(string expiredAccessToken);
}