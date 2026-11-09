using System.Data;

using FluentValidation;

namespace CuraFlow.Application.Features.Identity.Commands.GenerateToken;

public class GenerateTokenCommandValidator : AbstractValidator<GenerateTokenCommand>
{
    public GenerateTokenCommandValidator()
    {
        RuleFor(t => t.Email).NotEmpty().EmailAddress();

        RuleFor(t => t.Password).NotEmpty();
    }
}