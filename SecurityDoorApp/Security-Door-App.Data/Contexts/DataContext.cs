using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Security_Door_App.Data.Models;

namespace Security_Door_App.Data.Contexts
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Card>()
                .HasIndex(c => c.UniqueNumber)
                .IsUnique();

            modelBuilder.Entity<DoorReader>()
               .HasIndex(c => c.SerialNumber)
               .IsUnique();
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Door> Doors { get; set; }
        public DbSet<DoorAction> DoorActions { get; set; }
        public DbSet<DoorReader> doorReaders { get; set; }
    }
}
