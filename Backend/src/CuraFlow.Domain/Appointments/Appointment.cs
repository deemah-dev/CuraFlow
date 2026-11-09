using CuraFlow.Domain.Common;
using CuraFlow.Domain.Common.Results;
using CuraFlow.Domain.Employees;
using CuraFlow.Domain.MedicalDepartments;
using CuraFlow.Domain.Patients;

namespace CuraFlow.Domain.Appointments;

public class Appointment : AuditableEntity
{
    private Appointment(Guid id, Guid patientId, Guid doctorId, Guid medicalDepartmentId, DateTimeOffset appoinmentDate)
    : base(id)
    {
        PatientId = patientId;
        DoctorId = doctorId;
        MedicalDepartmentId = medicalDepartmentId;
        AppoinmentDate = appoinmentDate;
        Status = AppointmentStatus.Pending;
    }

    private Appointment() { }

    public Guid PatientId { get; private set; }
    public Guid DoctorId { get; private set; }
    public Guid MedicalDepartmentId { get; private set; }
    public DateTimeOffset AppoinmentDate { get; private set; }
    public AppointmentStatus Status { get; private set; }
    public Patient? Patient { get; set; }
    public Employee? Doctor { get; set; }
    public MedicalDepartment? Department { get; set; }

    public static Result<Appointment> Create(Guid id, Guid patientId, Guid doctorId, Guid medicalDepartmentId, DateTimeOffset appoinmentDate)
    {
        if (patientId == Guid.Empty)
        {
            return AppoinmentErrors.PatientIdRequired;
        }

        if (doctorId == Guid.Empty)
        {
            return AppoinmentErrors.DoctorIdRequired;
        }

        if (medicalDepartmentId == Guid.Empty)
        {
            return AppoinmentErrors.MedicalDepartmentIdRequired;
        }

        if (appoinmentDate < DateTimeOffset.UtcNow)
        {
            return AppoinmentErrors.InvalidAppointmentDate;
        }

        return new Appointment(id, patientId, doctorId, medicalDepartmentId, appoinmentDate);
    }
}