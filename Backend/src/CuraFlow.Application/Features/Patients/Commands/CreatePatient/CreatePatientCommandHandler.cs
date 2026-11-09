using CuraFlow.Application.Common.Interfaces;
using CuraFlow.Application.Features.Patients.Dtos;
using CuraFlow.Application.Features.Patients.Meppers;
using CuraFlow.Domain.Common.Results;
using CuraFlow.Domain.Patients;

using MediatR;

namespace CuraFlow.Application.Features.Patients.Commands.CreatePatient;

public class CreatePatientCommandHandler(IAppDbContext context) : IRequestHandler<CreatePatientCommand, Result<PatientDto>>
{
    public async Task<Result<PatientDto>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var createPatientResult = Patient.Create(Guid.Empty, request.FirstName, request.Lastname, request.Phone, request.Email);

        if (createPatientResult.IsError)
        {
            return createPatientResult.Errors;
        }

        var patient = createPatientResult.Value;

        await context.Patients.AddAsync(patient, cancellationToken);

        await context.SaveChangesAsync(cancellationToken);

        return patient.ToDto();
    }
}