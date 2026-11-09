using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.Patients.Commands.UpdatePatinet;

public sealed record UpdatePatientCommand(Guid PatinetId,
                                            string FirstName,
                                            string LastName,
                                            string Phone,
                                            string? Email) : IRequest<Result<Updated>>;