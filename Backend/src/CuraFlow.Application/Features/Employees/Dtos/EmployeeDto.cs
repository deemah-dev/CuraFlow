using CuraFlow.Domain.Common.Enums;

namespace CuraFlow.Application.Features.Employees.Dtos;

public class EmployeeDto
{
    public Guid EmployeeId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhonNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Role Role { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
}