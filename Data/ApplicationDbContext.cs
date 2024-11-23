﻿using HotelReservation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUsers>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Company>  Companies { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelAmenities> HotelAmenities { get; set; }
        public DbSet<ImageList> ImageLists { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportDetails> ReportDetails { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationRoom>  ReservationRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder);
                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
                var connection = builder.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelAmenities>()
                .HasKey(e=> new { e.HotelId,e.AmenityId});

            modelBuilder.Entity<ReservationRoom>()
                .HasKey(e => new { e.ReservationID, e.RoomId });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(login => new { login.LoginProvider, login.ProviderKey });
            });

            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.HasKey(role => new { role.UserId, role.RoleId });
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.HasKey(token => new { token.UserId, token.LoginProvider, token.Name });
            });

             
            modelBuilder.Entity<Hotel>()
            .HasOne(h => h. company)
            .WithMany(c => c.Hotels)
            .HasForeignKey(h => h.CompanyId);
            
            modelBuilder.Entity<ImageList>()
            .HasOne(il => il.Hotel)
            .WithMany(h => h.ImageLists)
            .HasForeignKey(il => il.HotelId);
            
            modelBuilder.Entity<Hotel>()
            .HasOne(h => h.Report)
            .WithOne(r => r.Hotel)
            .HasForeignKey<Report>(r => r.HotelId);

        }
    }
}
