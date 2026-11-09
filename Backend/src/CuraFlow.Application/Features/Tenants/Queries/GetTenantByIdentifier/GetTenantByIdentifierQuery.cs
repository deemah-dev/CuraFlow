using System.IO.Pipelines;

using CuraFlow.Application.Common.Interfaces;
using CuraFlow.Application.Features.Tenants.Dtos;
using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.Tenants.Queries.GetTenantByIdentifier;

public sealed record GetTenantByIdentifierQuery(string Identifier) : IRequest<Result<TenantDto>>, ISkipTenantValidation;