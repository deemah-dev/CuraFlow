using CuraFlow.Application.Features.Tenants.Dtos;
using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.Tenants.Queries.GetTenantById;

public sealed record GetTenantByIdQuery(Guid TenantId) : IRequest<Result<TenantDto>>;