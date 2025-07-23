namespace MobileView.Services;
using MobileView.Models;

public class InWarehouseMobile
{

    private readonly List<WarehouseMobileCreatedEvent> _Warehouse = new();

    public void Add(WarehouseMobileCreatedEvent Warehouse)
    {
        _Warehouse.Insert(0, Warehouse);
        if (_Warehouse.Count > 100) _Warehouse.RemoveAt(_Warehouse.Count - 1);
    }

    public List<WarehouseMobileCreatedEvent> GetAll() => _Warehouse;



}

