using CuraFlow.Application.Features.MedicalDepartment.Dtos;
using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.MedicalDepartment.Commands.CreateMedicalDepartment;

public sealed record CreateMedicalDepartmentCommand(string Name, decimal BaseConsultationFee, int DefualtDurationMinutes, string Description) : IRequest<Result<MedicalDepartmentDto>>;