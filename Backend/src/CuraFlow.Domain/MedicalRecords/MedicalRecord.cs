using CuraFlow.Domain.Common;
using CuraFlow.Domain.Common.Results;
using CuraFlow.Domain.MedicalRecords.Enums;
using CuraFlow.Domain.Patients;

namespace CuraFlow.Domain.MedicalRecords;

public class MedicalRecord : AuditableEntity
{
    private MedicalRecord(Guid id, Guid patientId, BloodType bloodType, string allergies, string chronicDiseases, string surgicalHistory, string familyHistory)
    : base(id)
    {
        PatientId = patientId;
        BloodType = bloodType;
        Allergies = allergies;
        ChronicDiseases = chronicDiseases;
        SurgicalHistory = surgicalHistory;
        FamilyHistory = familyHistory;
    }

    private MedicalRecord() { }

    public Guid PatientId { get; private set; }
    public BloodType BloodType { get; private set; }
    public string Allergies { get; private set; } = string.Empty;
    public string ChronicDiseases { get; private set; } = string.Empty;
    public string SurgicalHistory { get; private set; } = string.Empty;
    public string FamilyHistory { get; private set; } = string.Empty;

    public Patient? Patient { get; set; }

    public static Result<MedicalRecord> Create(Guid id, Guid patientId, BloodType bloodType, string allergies, string chronicDiseases, string surgicalHistory, string familyHistory)
    {
        return new MedicalRecord(id, patientId, bloodType, allergies, chronicDiseases, surgicalHistory, familyHistory);
    }
}