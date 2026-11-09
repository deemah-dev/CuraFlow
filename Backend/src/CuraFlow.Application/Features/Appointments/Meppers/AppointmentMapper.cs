using CuraFlow.Application.Features.Appointments.Dtos;
using CuraFlow.Domain.Appointments;

namespace CuraFlow.Application.Features.Appointments.Meppers;

public static class AppointmentMapper
{
    public static AppointmentDto ToDto(this Appointment appointment) => new()
    {
        AppointmentId = appointment.Id,
        AppoinmentDate = appointment.AppoinmentDate,
        DoctorId = appointment.DoctorId,
        MedicalDepartmentId = appointment.MedicalDepartmentId,
        PatientId = appointment.PatientId,
        Status = appointment.Status
    };
}