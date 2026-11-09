using CuraFlow.Application.Features.Identity.Dtos;
using CuraFlow.Domain.Common.Results;

namespace CuraFlow.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<Result<UserDto>> AuthenticateAsync(string email, string password);
    Task<Result<UserDto>> GetUserByIdAsync(string userId);
    Task<string> GetUserNameAsync(string userId);
    Task<Result<UserDto>> RegisterUserAsync(string userName, string email, string phoneNumber, string password);
}