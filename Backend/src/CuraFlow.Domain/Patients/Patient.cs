namespace CuraFlow.Domain.Patients;

public class Patient : AuditableEntity
{
    public string FirstName { get; private set; }
    public string SecondName { get; private set; }
    public string ThirdName { get; private set; }
    public string LastName { get; private set; }
    public string NationalNo { get; private set; }
    public string FirstPhoneNumber { get; private set; }
    public string SecondPhoneNumber { get; private set; }

    private Patient(Guid id,
                    string firstName,
                    string secondName,
                    string? thirdName,
                    string lastName,
                    string nationalNo,
                    string firstPhoneNumber,
                    string? secondPhoneNumber)
    : base(id)
    {
        FirstName = firstName;
        SecondName = secondName;
        ThirdName = thirdName ?? string.Empty;
        LastName = lastName;
        NationalNo = nationalNo;
        FirstPhoneNumber = firstPhoneNumber;
        SecondPhoneNumber = secondPhoneNumber ?? string.Empty;
    }

    private Patient() { }

    public static Result<Patient> Create(Guid id,
                    string firstName,
                    string secondName,
                    string thirdName,
                    string lastName,
                    string nationalNo,
                    string firstPhoneNumber,
                    string? secondPhoneNumber)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return PatientErrors.FirstNameRequired;
        }

        if (string.IsNullOrWhiteSpace(secondName))
        {
            return PatientErrors.FirstNameRequired;
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            return PatientErrors.FirstNameRequired;
        }

        if (string.IsNullOrWhiteSpace(firstPhoneNumber))
        {
            return PatientErrors.FirstNameRequired;
        }

        if (string.IsNullOrWhiteSpace(secondPhoneNumber))
        {
            return PatientErrors.FirstNameRequired;
        }

        return new Patient(id, firstName, secondName, thirdName, lastName, firstPhoneNumber, secondPhoneNumber);
    }
}