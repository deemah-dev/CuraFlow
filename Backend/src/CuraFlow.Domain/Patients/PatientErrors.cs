using CuraFlow.Domain.Common.Results;

namespace CuraFlow.Domain.Patients;

public class PatientErrors
{
    internal static readonly Error FirstNameRequired = Error.Validation("Patient.FirstName");
    internal static readonly Error LastNameRequired = Error.Validation("Patient.LastName");
    internal static readonly Error PhoneRequired = Error.Validation("Patient.Phone");
}