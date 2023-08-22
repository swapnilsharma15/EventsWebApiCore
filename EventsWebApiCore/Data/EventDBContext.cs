using EventsWebApiCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EventsWebApiCore.Data
{
    public class EventDBContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        protected readonly IConfiguration Configuration;

        public EventDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>()
                .ToTable("EventTable");

            modelBuilder.Entity<Event>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
