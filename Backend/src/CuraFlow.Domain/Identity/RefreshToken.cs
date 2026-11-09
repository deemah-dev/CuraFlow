using CuraFlow.Domain.Common;
using CuraFlow.Domain.Common.Results;

public class RefreshToken : Entity
{
    private RefreshToken(Guid id, string userId, string token, DateTimeOffset expiresOnUtc)
    : base(id)
    {
        UserId = userId;
        Token = token;
        ExpiresOnUtc = expiresOnUtc;
    }

    public string UserId { get; private set; } = null!;
    public string Token { get; private set; } = null!;
    public DateTimeOffset ExpiresOnUtc { get; private set; }

    public static Result<RefreshToken> Create(Guid id, string token, string userId, DateTimeOffset expiresOnUtc)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            return RefreshTokenErrors.TokenIsRequired;
        }

        if (string.IsNullOrWhiteSpace(userId))
        {
            return RefreshTokenErrors.UserIdIsRequired;
        }

        if (expiresOnUtc <= DateTimeOffset.UtcNow)
        {
            return RefreshTokenErrors.ExpiryInvalid;
        }

        return new RefreshToken(id, userId, token, expiresOnUtc);
    }
}
