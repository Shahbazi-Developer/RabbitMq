using Microsoft.EntityFrameworkCore;
using MobileView.Models;

namespace MobileView.Datas
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<WarehouseMobileCreatedEvent> Warehouse { get; set; }
    }
    
}
