using CuraFlow.Application.Features.Patients.Dtos;
using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.Patients.Commands.CreatePatient;

public sealed record CreatePatientCommand(string FirstName, string Lastname, string Phone, string? Email) : IRequest<Result<PatientDto>>;