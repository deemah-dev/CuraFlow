using System.Text.Json.Serialization;

namespace CuraFlow.Application.Features.Identity;

public sealed record TokenResponse(
    [property: JsonPropertyName("AccessToken")] string AccessToken,
    [property: JsonPropertyName("RefreshToken")] string RefreshToken,
    [property: JsonPropertyName("ExpiresOnUtc")] DateTimeOffset ExpiresOnUtc);