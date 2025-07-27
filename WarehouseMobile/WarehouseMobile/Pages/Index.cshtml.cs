using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MobileView.Datas;
using MobileView.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WarehouseMobile.Pages
{
     public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        public List<BookWarehouseCreatedEvent> Warehouses { get; private set; } = [];

        [BindProperty(SupportsGet = true)]
        public string? SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? FromDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? ToDate { get; set; }

        public void OnGet()
        {

            Warehouses = _db.Warehouse 
                .Where(x =>
                    (string.IsNullOrWhiteSpace(SearchTerm) ||
                        x.Title.Contains(SearchTerm) ||
                        x.Author.Contains(SearchTerm)) &&
                    (!FromDate.HasValue || x.CreationDate >= FromDate.Value) &&
                    (!ToDate.HasValue || x.CreationDate <= ToDate.Value)
                )
                .OrderByDescending(x => x.CreationDate)
                .ToList();
        }
    }
}
