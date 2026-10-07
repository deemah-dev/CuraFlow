namespace CuraFlow.Application.Common.Interfaces;

public interface IIdentityService
{
    public Task<string> GetUserNameAsync(string userId);
}