using Microsoft.EntityFrameworkCore;
using TravelGuide.Entiteis.Models;

namespace PointOfSales.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) 
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<WatchlistItem> WatchlistItems { get; set; }
        public DbSet<Hotel> Hotels {  get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<TravelPackage> TravelPackages { get; set; }
        public DbSet<RoomBooking> RoomBookings { get; set; }
        public DbSet<FlightBooking> FlightBookings { get; set; }

        public DbSet<PackageBooking> PackageBookings { get; set; }


    }
}
