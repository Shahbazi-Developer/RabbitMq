using Microsoft.AspNetCore.Mvc.RazorPages;
using MobileView.Datas;
using MobileView.Models;

namespace WarehouseMobile.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly AppDbContext _db;

    public IndexModel(ILogger<IndexModel> logger, AppDbContext db)
    {
        _logger = logger;
        _db = db;
    }


    public List<BookWarehouseCreatedEvent> Warehouses { get; set; } = new();

    public void OnGet()
    {
        Warehouses = _db.Warehouse.OrderByDescending(a => a.CreationDate).ToList();

    }
}
