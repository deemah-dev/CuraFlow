using System.ComponentModel;

using CuraFlow.Application.Common.Interfaces;
using CuraFlow.Application.Features.Appointments.Dtos;
using CuraFlow.Application.Features.Appointments.Meppers;
using CuraFlow.Domain.Appointments;
using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.Appointments.Commands.CreateAppointmet;

public class CreateAppointmentCommandHandler(IAppDbContext context) : IRequestHandler<CreateAppointmentCommand, Result<AppointmentDto>>
{
    public async Task<Result<AppointmentDto>> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var createAppointmentResult = Appointment.Create(Guid.Empty, request.PatientId, request.DoctorId, request.MedicalDepartmentId, request.AppointmentDate);
        if (createAppointmentResult.IsError)
        {
            return createAppointmentResult.Errors;
        }

        var appointment = createAppointmentResult.Value;

        await context.Appointments.AddAsync(appointment, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return appointment.ToDto();
    }
}