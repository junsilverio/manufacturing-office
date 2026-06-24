using ManufacturingOffice.Domain.Common;
using ManufacturingOffice.Domain.Enums;

namespace ManufacturingOffice.Domain.Entities;

public class QualityEvent : BaseEntity
{
    public string EventNumber { get; set; } = string.Empty;
    public string WorkOrderNumber { get; set; } = string.Empty;
    public string PartNumber { get; set; } = string.Empty;
    public QualityStatus Status { get; set; }
    public string DefectCategory { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int QuantityAffected { get; set; }
    public DateTime EventDate { get; set; }
    public string? Inspector { get; set; }
    public string? CorrectionAction { get; set; }
    public DateTime? ResolvedDate { get; set; }
}
