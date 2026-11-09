using CuraFlow.Application.Features.Tenants.Dtos;
using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.Tenants.Commands.UpdateTenant;

public sealed record UpdatedTenantCommand(Guid TenantId, string Name, string Identitfier) : IRequest<Result<Updated>>;