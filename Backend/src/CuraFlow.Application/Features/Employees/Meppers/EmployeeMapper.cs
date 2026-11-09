using CuraFlow.Application.Features.Employees.Dtos;
using CuraFlow.Application.Features.Identity.Dtos;
using CuraFlow.Domain.Employees;

namespace CuraFlow.Application.Features.Employees.Meppers;

public static class EmployeeMapper
{
    public static EmployeeDto ToDto(this Employee employee, UserDto user) => new()
    {
        EmployeeId = employee.Id,
        Address = employee.Address,
        Email = employee.Email,
        FirstName = employee.FirstName,
        Lastname = employee.LastName,
        PhonNumber = employee.PhonNumber,
        Role = employee.Role,
        UserId = user.UserId,
        UserName = user.UserName
    };
}