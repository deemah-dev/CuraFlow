using CuraFlow.Domain.Common.Results;

namespace CuraFlow.Domain.Appointments;

public class AppoinmentErrors
{
    internal static readonly Error PatientIdRequired = Error.Validation("Appointment.PatientId");
    internal static readonly Error DoctorIdRequired = Error.Validation("Appointment.DoctorId");
    internal static readonly Error MedicalDepartmentIdRequired = Error.Validation("Appointment.MedicalDepartmentId");
    internal static readonly Error InvalidAppointmentDate = Error.Validation("Appointment.AppointmentDate");
}