using CuraFlow.Domain.Appointments;

namespace CuraFlow.Application.Features.Appointments.Dtos;

public class AppointmentDto
{
    public Guid AppointmentId { get; set; }
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public Guid MedicalDepartmentId { get; set; }
    public DateTimeOffset AppoinmentDate { get; set; }
    public AppointmentStatus Status { get; set; }
}