namespace MobileView.Services;
using MobileView.Models;

public class InBookWarehouse
{

    private readonly List<BookWarehouseCreatedEvent> _Warehouse = new();

    public void Add(BookWarehouseCreatedEvent Warehouse)
    {
        _Warehouse.Insert(0, Warehouse);
        if (_Warehouse.Count > 100) _Warehouse.RemoveAt(_Warehouse.Count - 1);
    }

    public List<BookWarehouseCreatedEvent> GetAll() => _Warehouse;



}

