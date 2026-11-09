using CuraFlow.Application.Common.Interfaces;
using CuraFlow.Application.Common.Models;
using CuraFlow.Application.Features.MedicalRecord.Dtos;
using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.MedicalRecord.Queries.GetMedicalRecords;

public sealed record GetMedicalRecordsQuery() : ICachedQuery<Result<PagenatedList<MedicalRecordDto>>>
{
    public string CacheKey => throw new NotImplementedException();

    public string[] Tags => throw new NotImplementedException();

    public TimeSpan Expiration => throw new NotImplementedException();
}