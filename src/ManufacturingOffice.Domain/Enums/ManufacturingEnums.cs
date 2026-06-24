namespace ManufacturingOffice.Domain.Enums;

public enum WorkOrderStatus
{
    Draft,
    Scheduled,
    Released,
    InProgress,
    Paused,
    Completed,
    Cancelled
}

public enum Priority
{
    Low,
    Normal,
    High,
    Critical
}

public enum WorkCenterStatus
{
    Idle,
    Running,
    Blocked,
    Maintenance
}

public enum QualityStatus
{
    Pass,
    Fail,
    Pending,
    OnHold
}
