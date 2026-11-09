using CuraFlow.Domain.Common.Results;
using CuraFlow.Domain.MedicalRecords.Enums;

using MediatR;

namespace CuraFlow.Application.Features.MedicalRecord.Commands.UpdateMedicalRecord;

public sealed record UpdateMedicalRecordCommand(Guid MedicalRecordId,
                                                BloodType? BloodType,
                                                string? Allergies,
                                                string? ChronicDiseases,
                                                string? SurgicalHistory,
                                                string? FamilyHistory) : IRequest<Result<Updated>>;