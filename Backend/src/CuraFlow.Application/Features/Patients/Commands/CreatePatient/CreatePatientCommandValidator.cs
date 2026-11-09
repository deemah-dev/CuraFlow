using FluentValidation;

namespace CuraFlow.Application.Features.Patients.Commands.CreatePatient;

public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
{
    public CreatePatientCommandValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty().WithMessage("First Name Required");
        RuleFor(c => c.Lastname).NotEmpty().WithMessage("Last Name Required");
        RuleFor(c => c.Phone).NotEmpty().WithMessage("Phone Required");
        RuleFor(c => c.Email).EmailAddress().WithMessage("First Name Required");
    }
}