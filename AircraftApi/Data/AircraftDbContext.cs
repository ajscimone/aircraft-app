using AircraftApi.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AircraftApi.Data
{
    public class AircraftDbContext : DbContext
    {
        public AircraftDbContext(DbContextOptions<AircraftDbContext> dbContextOptions): base(dbContextOptions)
        {
            
        }
        public DbSet<Aircraft> Aircrafts { get; set; }

        public DbSet<AircraftManufacturer> AircraftManufacturers { get; set; }

        public DbSet<AircraftModel> AircraftModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AircraftManufacturer>()
                .HasIndex(e => e.Name)
                .IsUnique();

            modelBuilder.Entity<AircraftModel>()
                .HasIndex(e => e.Name)
                .IsUnique();
        }
    }
}
