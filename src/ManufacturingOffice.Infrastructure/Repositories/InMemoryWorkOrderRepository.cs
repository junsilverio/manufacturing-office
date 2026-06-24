using ManufacturingOffice.Application.Interfaces;
using ManufacturingOffice.Domain.Entities;
using ManufacturingOffice.Domain.Enums;

namespace ManufacturingOffice.Infrastructure.Repositories;

public class InMemoryWorkOrderRepository : IWorkOrderRepository
{
    private readonly List<WorkOrder> _workOrders = new();
    private int _nextId = 1;

    public InMemoryWorkOrderRepository()
    {
        SeedData();
    }

    private void SeedData()
    {
        var demoOrders = new[]
        {
            new WorkOrder
            {
                Id = _nextId++,
                OrderNumber = "WO-2026-001",
                PartNumber = "PART-100",
                PartDescription = "Control Panel Assembly",
                Quantity = 50,
                CompletedQuantity = 35,
                Status = WorkOrderStatus.InProgress,
                Priority = Priority.High,
                DueDate = DateTime.Now.AddDays(3),
                StartDate = DateTime.Now.AddDays(-2),
                WorkCenter = "Assembly Line 1",
                AssignedTo = "John Smith",
                MaterialReady = true,
                CreatedAt = DateTime.Now.AddDays(-5)
            },
            new WorkOrder
            {
                Id = _nextId++,
                OrderNumber = "WO-2026-002",
                PartNumber = "PART-200",
                PartDescription = "Motor Housing",
                Quantity = 100,
                CompletedQuantity = 0,
                Status = WorkOrderStatus.Scheduled,
                Priority = Priority.Normal,
                DueDate = DateTime.Now.AddDays(7),
                WorkCenter = "Machining Center 2",
                MaterialReady = true,
                CreatedAt = DateTime.Now.AddDays(-3)
            },
            new WorkOrder
            {
                Id = _nextId++,
                OrderNumber = "WO-2026-003",
                PartNumber = "PART-300",
                PartDescription = "Wiring Harness",
                Quantity = 75,
                CompletedQuantity = 75,
                Status = WorkOrderStatus.Completed,
                Priority = Priority.Normal,
                DueDate = DateTime.Now.AddDays(-1),
                StartDate = DateTime.Now.AddDays(-5),
                CompletedDate = DateTime.Now.AddDays(-1),
                WorkCenter = "Assembly Line 2",
                AssignedTo = "Jane Doe",
                MaterialReady = true,
                CreatedAt = DateTime.Now.AddDays(-10)
            },
            new WorkOrder
            {
                Id = _nextId++,
                OrderNumber = "WO-2026-004",
                PartNumber = "PART-400",
                PartDescription = "Gearbox Assembly",
                Quantity = 30,
                CompletedQuantity = 0,
                Status = WorkOrderStatus.Released,
                Priority = Priority.Critical,
                DueDate = DateTime.Now.AddDays(1),
                WorkCenter = "Assembly Line 1",
                MaterialReady = false,
                Notes = "Waiting for bearings",
                CreatedAt = DateTime.Now.AddDays(-2)
            }
        };

        _workOrders.AddRange(demoOrders);
    }

    public Task<IEnumerable<WorkOrder>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<WorkOrder>>(_workOrders.ToList());
    }

    public Task<WorkOrder?> GetByIdAsync(int id)
    {
        return Task.FromResult(_workOrders.FirstOrDefault(w => w.Id == id));
    }

    public Task<WorkOrder> AddAsync(WorkOrder workOrder)
    {
        workOrder.Id = _nextId++;
        workOrder.CreatedAt = DateTime.Now;
        _workOrders.Add(workOrder);
        return Task.FromResult(workOrder);
    }

    public Task UpdateAsync(WorkOrder workOrder)
    {
        var existing = _workOrders.FirstOrDefault(w => w.Id == workOrder.Id);
        if (existing != null)
        {
            var index = _workOrders.IndexOf(existing);
            workOrder.ModifiedAt = DateTime.Now;
            _workOrders[index] = workOrder;
        }
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var workOrder = _workOrders.FirstOrDefault(w => w.Id == id);
        if (workOrder != null)
        {
            _workOrders.Remove(workOrder);
        }
        return Task.CompletedTask;
    }

    public Task<IEnumerable<WorkOrder>> GetByStatusAsync(WorkOrderStatus status)
    {
        var filtered = _workOrders.Where(w => w.Status == status).ToList();
        return Task.FromResult<IEnumerable<WorkOrder>>(filtered);
    }
}
