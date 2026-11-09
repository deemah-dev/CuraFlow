using FluentValidation;

namespace CuraFlow.Application.Features.Identity.Commands.RefreshToken;

public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidator()
    {
        RuleFor(c => c.ExpiredAccessToken).NotEmpty().WithMessage("Expired Access Token Required");
        RuleFor(c => c.RefreshToken).NotEmpty().WithMessage("Refresh Token Required");
    }
}