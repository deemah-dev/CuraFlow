using CuraFlow.Application.Common.Interfaces;
using CuraFlow.Application.Features.Tenants.Dtos;
using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.Tenants.Commands.CreateTenant;

public sealed record CreateTenantCommand(string Name, string Identifier) : IRequest<Result<TenantDto>>, ISkipTenantValidation;