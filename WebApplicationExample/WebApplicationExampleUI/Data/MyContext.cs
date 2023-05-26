using Microsoft.EntityFrameworkCore;
using WebApplicationExampleUI.Models;
using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
namespace WebApplicationExampleUI.Data
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext>options) : base(options)
        {
        }
        public DbSet<Aircrafts>? Aircrafts { get; set; }
        public DbSet<Airports>? Airports { get; set; }
        public DbSet<Flights>? Flights { get; set; }
        public DbSet<Passengers>? Passengers { get; set; }
        public DbSet<Tickets>? Tickets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airports>().HasKey(p => p.AirportID);
            modelBuilder.Entity<Airports>().ToTable("Airports");
            modelBuilder.Entity<Passengers>().HasKey(p => p.Userlogin);
            modelBuilder.Entity<Passengers>().ToTable("Passengers");
            modelBuilder.Entity<Aircrafts>().ToTable("Aircrafts");
            modelBuilder.Entity<Aircrafts>().HasKey(p => p.AircraftID);
            modelBuilder.Entity<Flights>().ToTable("Flights");
            modelBuilder.Entity<Flights>().HasKey(p => p.FlightID);
            modelBuilder.Entity<Tickets>().ToTable("Tickets");
            modelBuilder.Entity<Tickets>().HasKey(p => p.TicketID); 
        }
    }
}
