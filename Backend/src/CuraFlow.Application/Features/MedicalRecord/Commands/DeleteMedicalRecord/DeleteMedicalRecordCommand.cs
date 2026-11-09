using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.MedicalRecord.Commands.DeleteMedicalRecord;

public sealed record DeleteMedicalRecordCommand(Guid MedicalRecordId) : IRequest<Result<Deleted>>;