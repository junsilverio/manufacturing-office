using ManufacturingOffice.Domain.Common;
using ManufacturingOffice.Domain.Enums;

namespace ManufacturingOffice.Domain.Entities;

public class WorkCenter : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public WorkCenterStatus Status { get; set; }
    public string? CurrentWorkOrder { get; set; }
    public string? Operator { get; set; }
    public int Capacity { get; set; }
    public DateTime? LastStatusChange { get; set; }
}
