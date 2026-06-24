using ManufacturingOffice.Domain.Common;

namespace ManufacturingOffice.Domain.Entities;

public class InventoryItem : BaseEntity
{
    public string SKU { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int OnHand { get; set; }
    public int Reserved { get; set; }
    public int InTransit { get; set; }
    public int Available => OnHand - Reserved;
    public int ReorderPoint { get; set; }
    public string? Location { get; set; }
    public string? Bin { get; set; }
    public string? UnitOfMeasure { get; set; }
    public decimal UnitCost { get; set; }
}
