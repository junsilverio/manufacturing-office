using ManufacturingOffice.Domain.Entities;

namespace ManufacturingOffice.Application.Interfaces;

public interface IInventoryRepository
{
    Task<IEnumerable<InventoryItem>> GetAllAsync();
    Task<InventoryItem?> GetByIdAsync(int id);
    Task<InventoryItem?> GetBySKUAsync(string sku);
    Task<InventoryItem> AddAsync(InventoryItem item);
    Task UpdateAsync(InventoryItem item);
    Task DeleteAsync(int id);
    Task<IEnumerable<InventoryItem>> GetLowStockItemsAsync();
}
