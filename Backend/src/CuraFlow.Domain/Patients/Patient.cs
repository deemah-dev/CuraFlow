using System.Net.Mail;

using CuraFlow.Domain.Common;
using CuraFlow.Domain.Common.Results;

namespace CuraFlow.Domain.Patients;

public class Patient : AuditableEntity
{
    private Patient(Guid id, string firstName, string lastName, string phone, string? email)
    : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Email = email;
    }

    private Patient() { }

    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;
    public string? Email { get; private set; }

    public static Result<Patient> Create(Guid id, string firstName, string lastName, string phone, string? email)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return PatientErrors.FirstNameRequired;
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            return PatientErrors.LastNameRequired;
        }

        if (string.IsNullOrWhiteSpace(phone))
        {
            return PatientErrors.PhoneRequired;
        }

        return new Patient(id, firstName, lastName, phone, email);
    }

    public Result<Updated> Update(Guid id, string firstName, string lastName, string phone, string? email)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return PatientErrors.FirstNameRequired;
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            return PatientErrors.LastNameRequired;
        }

        if (string.IsNullOrWhiteSpace(phone))
        {
            return PatientErrors.PhoneRequired;
        }

        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Email = email;

        return Result.Updated;
    }
}