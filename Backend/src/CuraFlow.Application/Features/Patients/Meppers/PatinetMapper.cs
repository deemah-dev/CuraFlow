using CuraFlow.Application.Features.Patients.Dtos;
using CuraFlow.Domain.Patients;

namespace CuraFlow.Application.Features.Patients.Meppers;

public static class PatientMapper
{
    public static PatientDto ToDto(this Patient patient) => new()
    {
        PatientId = patient.Id,
        FirstName = patient.FirstName,
        LastName = patient.LastName,
        Phone = patient.Phone,
        Email = patient.Email
    };
}