using ManufacturingOffice.Application.Interfaces;
using ManufacturingOffice.Domain.Entities;

namespace ManufacturingOffice.Infrastructure.Repositories;

public class InMemoryInventoryRepository : IInventoryRepository
{
    private readonly List<InventoryItem> _items = new();
    private int _nextId = 1;

    public InMemoryInventoryRepository()
    {
        SeedData();
    }

    private void SeedData()
    {
        var demoItems = new[]
        {
            new InventoryItem
            {
                Id = _nextId++,
                SKU = "MAT-001",
                Description = "Steel Plate 10mm",
                OnHand = 150,
                Reserved = 50,
                InTransit = 100,
                ReorderPoint = 50,
                Location = "Warehouse A",
                Bin = "A-01-01",
                UnitOfMeasure = "Sheet",
                UnitCost = 45.99m,
                CreatedAt = DateTime.Now.AddMonths(-1)
            },
            new InventoryItem
            {
                Id = _nextId++,
                SKU = "MAT-002",
                Description = "M8 Bolts",
                OnHand = 5000,
                Reserved = 1200,
                InTransit = 0,
                ReorderPoint = 1000,
                Location = "Warehouse B",
                Bin = "B-05-03",
                UnitOfMeasure = "Each",
                UnitCost = 0.25m,
                CreatedAt = DateTime.Now.AddMonths(-2)
            },
            new InventoryItem
            {
                Id = _nextId++,
                SKU = "MAT-003",
                Description = "Ball Bearings 25mm",
                OnHand = 30,
                Reserved = 20,
                InTransit = 50,
                ReorderPoint = 40,
                Location = "Warehouse A",
                Bin = "A-03-05",
                UnitOfMeasure = "Each",
                UnitCost = 12.50m,
                CreatedAt = DateTime.Now.AddMonths(-1)
            },
            new InventoryItem
            {
                Id = _nextId++,
                SKU = "MAT-004",
                Description = "Copper Wire 16AWG",
                OnHand = 800,
                Reserved = 300,
                InTransit = 0,
                ReorderPoint = 200,
                Location = "Warehouse B",
                Bin = "B-02-01",
                UnitOfMeasure = "Meter",
                UnitCost = 1.75m,
                CreatedAt = DateTime.Now.AddMonths(-3)
            }
        };

        _items.AddRange(demoItems);
    }

    public Task<IEnumerable<InventoryItem>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<InventoryItem>>(_items.ToList());
    }

    public Task<InventoryItem?> GetByIdAsync(int id)
    {
        return Task.FromResult(_items.FirstOrDefault(i => i.Id == id));
    }

    public Task<InventoryItem?> GetBySKUAsync(string sku)
    {
        return Task.FromResult(_items.FirstOrDefault(i => i.SKU == sku));
    }

    public Task<InventoryItem> AddAsync(InventoryItem item)
    {
        item.Id = _nextId++;
        item.CreatedAt = DateTime.Now;
        _items.Add(item);
        return Task.FromResult(item);
    }

    public Task UpdateAsync(InventoryItem item)
    {
        var existing = _items.FirstOrDefault(i => i.Id == item.Id);
        if (existing != null)
        {
            var index = _items.IndexOf(existing);
            item.ModifiedAt = DateTime.Now;
            _items[index] = item;
        }
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var item = _items.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {
            _items.Remove(item);
        }
        return Task.CompletedTask;
    }

    public Task<IEnumerable<InventoryItem>> GetLowStockItemsAsync()
    {
        var lowStock = _items.Where(i => i.Available <= i.ReorderPoint).ToList();
        return Task.FromResult<IEnumerable<InventoryItem>>(lowStock);
    }
}
