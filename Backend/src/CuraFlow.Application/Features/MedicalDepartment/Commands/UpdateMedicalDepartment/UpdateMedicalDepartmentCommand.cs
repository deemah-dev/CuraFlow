using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.MedicalDepartment.Commands.UpdateMedicalDepartment;

public sealed record UpdateMedicalDepartmentCommand(Guid MedicalDeparmtnetId,
                                                    string Name,
                                                    decimal BaseConsultationFee,
                                                    int DefualtDurationMinutes,
                                                    string Description) : IRequest<Result<Updated>>;