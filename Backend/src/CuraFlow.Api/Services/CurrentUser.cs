using System.Security.Claims;

using CuraFlow.Application.Common.Interfaces;

namespace CuraFlow.Api.Services;

public class CurrentUser(IHttpContextAccessor httpContextAccessor) : ICurrentUser
{
    public string Id => httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "-";
}