using CuraFlow.Application.Common.Interfaces;
using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.Identity.Commands.GenerateToken;

public class GenerateTokenCommandHandler(ITokenProvider tokenProvider, IIdentityService identityService)
: IRequestHandler<GenerateTokenCommand, Result<TokenResponse>>
{
    public async Task<Result<TokenResponse>> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
    {
        var authResult = await identityService.AuthenticateAsync(request.Email, request.Password);

        if (authResult.IsError)
        {
            return authResult.Errors;
        }

        var generateTokenResult = await tokenProvider.GenerateJwtTokenAsync(authResult.Value, cancellationToken);

        if (generateTokenResult.IsError)
        {
            return generateTokenResult.Errors;
        }

        return generateTokenResult.Value;
    }
}