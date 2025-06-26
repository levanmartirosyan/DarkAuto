using DarkAuto.DTOs;
using DarkAuto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DarkAuto
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarCategory> CarCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<DeliveryCompany> DeliveryCompanies { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Seller> Sellers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<GetAllUsersDTO>().HasNoKey().ToFunction("GetAllUsers");
            modelBuilder.Entity<GetUserByCredentialsDTO>().HasNoKey().ToFunction("GetUserByCredentials");
            modelBuilder.Entity<GetAllCarsDTO>().HasNoKey().ToFunction("GetAllCars");
            modelBuilder.Entity<GetDeliveryCompaniesDTO>().HasNoKey().ToFunction("GetDeliveryCompanies");
            modelBuilder.Entity<GetLocationsDTO>().HasNoKey().ToFunction("GetLocations");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=LEVAN\\SQLEXPRESS;Database=DarkAutoEF;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
