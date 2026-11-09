using CuraFlow.Application.Common.Interfaces;
using CuraFlow.Application.Features.Identity.Dtos;
using CuraFlow.Domain.Common.Results;

namespace CuraFlow.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    public Task<Result<UserDto>> AuthenticateAsync(string email, string password)
    {
        throw new NotImplementedException();
    }

    public Task<Result<UserDto>> GetUserByIdAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetUserNameAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<Result<UserDto>> RegisterUserAsync(string userName, string email, string phoneNumber, string password)
    {
        throw new NotImplementedException();
    }
}