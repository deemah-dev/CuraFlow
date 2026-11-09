using CuraFlow.Domain.Common.Results;

public static class RefreshTokenErrors
{
    internal static readonly Error TokenIsRequired
        = Error.Validation("RefreshToken.Token.Required", "Refresh token is required");

    internal static readonly Error UserIdIsRequired
        = Error.Validation("RefreshToken.UserId.Required", "Refresh token user ID is required");

    internal static readonly Error ExpiryInvalid
        = Error.Validation("RefreshToken.Expiry.Invalid", "Refresh token expiry must be in the future");
}