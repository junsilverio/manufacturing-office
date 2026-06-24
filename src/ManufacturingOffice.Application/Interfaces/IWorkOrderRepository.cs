using ManufacturingOffice.Domain.Entities;

namespace ManufacturingOffice.Application.Interfaces;

public interface IWorkOrderRepository
{
    Task<IEnumerable<WorkOrder>> GetAllAsync();
    Task<WorkOrder?> GetByIdAsync(int id);
    Task<WorkOrder> AddAsync(WorkOrder workOrder);
    Task UpdateAsync(WorkOrder workOrder);
    Task DeleteAsync(int id);
    Task<IEnumerable<WorkOrder>> GetByStatusAsync(Domain.Enums.WorkOrderStatus status);
}
