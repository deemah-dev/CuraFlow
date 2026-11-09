using CuraFlow.Domain.Common;
using CuraFlow.Domain.Common.Enums;
using CuraFlow.Domain.Common.Results;

namespace CuraFlow.Domain.Employees;

public class Employee : AuditableEntity
{
    private Employee(Guid id, string firstName, string lastName, string address, string phonNumber, string email, Role role)
    : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        PhonNumber = phonNumber;
        Email = email;
        Role = role;
    }

    private Employee() { }

    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Address { get; private set; } = string.Empty;
    public string PhonNumber { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public Role Role { get; private set; }

    public static Result<Employee> Create(Guid id, string firstName, string lastName, string address, string phonNumber, string email, Role role)
    {
        return new Employee(id, firstName, lastName, address, phonNumber, email, role);
    }
}