namespace CuraFlow.Application.Features.MedicalDepartment.Dtos;

public class MedicalDepartmentDto
{
    public Guid MedicalDepartmentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal BaseConsultationFee { get; set; }
    public int DefualtDurationMinutes { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}