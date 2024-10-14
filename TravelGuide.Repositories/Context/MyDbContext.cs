using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TravelGuide.Entiteis.Models;

namespace TravelGuide.Context
{
    public class MyDbContext : IdentityDbContext<AppUser>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) 
        {
            
        }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			//Seeding a  'Administrator' role to AspNetRoles table
			builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "540fa4db-060f-4f1b-b60a-dd199bfe4f0b", Name = "Admin", NormalizedName = "ADMIN" }, new IdentityRole { Id = "540fa4db-060f-4f1b-b60a-dd199bfe4111", Name = "User", NormalizedName = "USER" });


			//a hasher to hash the password before seeding the user to the db
			var hasher = new PasswordHasher<AppUser>();


			//Seeding the User to AspNetUsers table
			builder.Entity<AppUser>().HasData(
				new AppUser
				{
					Id = "62fe5285-fd68-4711-ae93-673787f4ac66", // primary key
					UserName = "Admin",
					NormalizedUserName = "ADMIN",
					Email = "admin@admin.com",
					NormalizedEmail = "admin@admin.com".ToUpper(),
					PasswordHash = hasher.HashPassword(null, "123"),
					EmailConfirmed = true
				},
				new AppUser
				{ // primary key
					Id = "62fe5285-fd68-4711-ae93-673787f4a111",
					UserName = "user",
					NormalizedUserName = "USER",
					Email = "user@user.com",
					NormalizedEmail = "user@user.com".ToUpper(),
					PasswordHash = hasher.HashPassword(null, "123"),
					EmailConfirmed = true
				}
			);


			//Seeding the relation between our user and role to AspNetUserRoles table
			builder.Entity<IdentityUserRole<string>>().HasData(
				new IdentityUserRole<string>
				{
					RoleId = "540fa4db-060f-4f1b-b60a-dd199bfe4f0b",
					UserId = "62fe5285-fd68-4711-ae93-673787f4ac66"
				}, new IdentityUserRole<string>
				{
					RoleId = "540fa4db-060f-4f1b-b60a-dd199bfe4111",
					UserId = "62fe5285-fd68-4711-ae93-673787f4a111"
				}, new IdentityUserRole<string>
				{
					RoleId = "540fa4db-060f-4f1b-b60a-dd199bfe4111",
					UserId = "62fe5285-fd68-4711-ae93-673787f4ac66"
                }
			);
            builder.Entity<Payment>()
			.HasOne(p => p.FlightBooking)
			.WithMany()
			.HasForeignKey(p => p.FlightBookingId)
			.OnDelete(DeleteBehavior.Cascade);

			//builder.Entity<Payment>()
			//	.HasOne(p => p.RoomBooking)
			//	.WithMany()
			//	.HasForeignKey(p => p.RoomBookingId)
			//	.OnDelete(DeleteBehavior.Cascade);

			//builder.Entity<Payment>()
			//    .HasOne(p => p.PackageBooking)
			//    .WithMany()
			//    .HasForeignKey(p => p.PackageBookingId)
			//    .OnDelete(DeleteBehavior.Cascade);

		}
        public DbSet<WatchlistItem> WatchlistItems { get; set; }
        public DbSet<Hotel> Hotels {  get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<TravelPackage> TravelPackages { get; set; }
        public DbSet<RoomBooking> RoomBookings { get; set; }
        public DbSet<FlightBooking> FlightBookings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PackageBooking> PackageBookings { get; set; }
    }
}
