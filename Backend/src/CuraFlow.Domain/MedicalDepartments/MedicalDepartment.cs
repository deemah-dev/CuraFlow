using CuraFlow.Domain.Common;
using CuraFlow.Domain.Common.Results;

namespace CuraFlow.Domain.MedicalDepartments;

public class MedicalDepartment : AuditableEntity
{
    private MedicalDepartment(Guid id, string name, decimal baseConsultationFee, int defaultDurationMinutes, string description, bool isActive)
    : base(id)
    {
        Name = name;
        BaseConsultationFee = baseConsultationFee;
        DefaultDurationMinutes = defaultDurationMinutes;
        Description = description;
        IsActive = isActive;
    }

    private MedicalDepartment() { }

    public string Name { get; private set; } = string.Empty;
    public decimal BaseConsultationFee { get; private set; }
    public int DefaultDurationMinutes { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }

    public static Result<MedicalDepartment> Create(Guid id, string name, decimal baseConsultationFee, int defaultDurationMinutes, string description, bool isActive)
    {
        return new MedicalDepartment(id, name, baseConsultationFee, defaultDurationMinutes, description, isActive);
    }
}