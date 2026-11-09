using CuraFlow.Application.Features.MedicalRecord.Dtos;
using CuraFlow.Domain.Common.Results;
using CuraFlow.Domain.MedicalRecords.Enums;

using MediatR;

namespace CuraFlow.Application.Features.MedicalRecord.Commands.CreateMedicalRecord;

public sealed record CreateMedicalRecordCommand(Guid PatientId,
                                                BloodType? BloodType,
                                                string? Allergies,
                                                string? ChronicDiseases,
                                                string? SurgicalHistory,
                                                string? FamilyHistory) : IRequest<Result<MedicalRecordDto>>;