using ManufacturingOffice.Domain.Common;
using ManufacturingOffice.Domain.Enums;

namespace ManufacturingOffice.Domain.Entities;

public class WorkOrder : BaseEntity
{
    public string OrderNumber { get; set; } = string.Empty;
    public string PartNumber { get; set; } = string.Empty;
    public string PartDescription { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public int CompletedQuantity { get; set; }
    public WorkOrderStatus Status { get; set; }
    public Priority Priority { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public string? WorkCenter { get; set; }
    public string? AssignedTo { get; set; }
    public bool MaterialReady { get; set; }
    public string? Notes { get; set; }
}
