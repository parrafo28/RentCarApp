using Microsoft.EntityFrameworkCore;

namespace RentCarApp.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<RentCarApp.Domain.Entities.Vehicle> Vehicles { get; set; }
        public DbSet<RentCarApp.Domain.Entities.Status> Status { get; set; }
        public DbSet<RentCarApp.Domain.Entities.Client> Clients { get; set; }
        public DbSet<RentCarApp.Domain.Entities.VehicleClient> VehicleClients { get; set; }
    }
}
