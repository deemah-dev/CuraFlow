using CuraFlow.Application.Features.MedicalRecord.Dtos;
using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.MedicalRecord.Queries.GetMedicalRecord;

public sealed record GetMediclaRecordQuery(Guid MedicalRecordId) : IRequest<Result<MedicalRecordDto>>;