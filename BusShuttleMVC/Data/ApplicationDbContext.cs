using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DomainModel;

namespace BusShuttleMVC.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public virtual DbSet<Bus> Buses { get; set; }
    public DbSet<BusStop> BusStops { get; set; }
    public DbSet<BusLoop> BusLoops { get; set; }
    public DbSet<BusRoute> BusRoutes { get; set; }
    public DbSet<Entry> Entries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // Call base implementation
        
        modelBuilder.Entity<RouteStop>()
            .HasKey(rs => rs.Id);

        modelBuilder.Entity<RouteStop>()
            .HasOne(rs => rs.BusRoute)
            .WithMany(br => br.RouteStops)
            .HasForeignKey(rs => rs.BusRouteId);

        modelBuilder.Entity<RouteStop>()
            .HasOne(rs => rs.BusStop)
            .WithMany(bs => bs.RouteStops)
            .HasForeignKey(rs => rs.BusStopId);
    }

    // Parameterless constructor for MSTest
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
