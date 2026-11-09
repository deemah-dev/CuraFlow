using CuraFlow.Application.Features.Tenants.Dtos;
using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.Tenants.Commands.DeleteTenant;

public sealed record DeleteTenantCommand(Guid TenantId) : IRequest<Result<Deleted>>;