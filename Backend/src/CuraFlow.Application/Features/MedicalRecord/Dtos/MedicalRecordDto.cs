using CuraFlow.Domain.MedicalRecords.Enums;

namespace CuraFlow.Application.Features.MedicalRecord.Dtos;

public class MedicalRecordDto
{
    public Guid MediclaRecordId { get; set; }
    public Guid PatientId { get; set; }
    public BloodType BloodType { get; set; }
    public string Allergies { get; set; } = string.Empty;
    public string ChronicDiseases { get; set; } = string.Empty;
    public string SurgicalHistory { get; set; } = string.Empty;
    public string FamilyHistory { get; set; } = string.Empty;
}