using Microsoft.EntityFrameworkCore;

namespace RentCarApp.Frontend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options )
            : base(options)
        {
        }

        public DbSet<RentCarApp.Frontend.Models.Vehicle> Vehicles { get; set; } = default!;
    }
}
