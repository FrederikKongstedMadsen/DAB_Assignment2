using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAB_Assignment2.Models;
using Microsoft.EntityFrameworkCore;

namespace DAB_Assignment2.Data
{
    public class DabDbContext : DbContext
    {
        public DbSet<Canteen> Canteens { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<CanteenCustomer> CanteenCustomer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CanteenCustomer>()
                .HasKey(cc => new { cc.CanteenId, cc.CustomerId });

            modelBuilder.Entity<CanteenCustomer>()
                .HasOne(cc => cc.Customer)
                .WithMany(c => c.CanteenCustomers)
                .HasForeignKey(cc => cc.CustomerId);

            modelBuilder.Entity<CanteenCustomer>()
                .HasOne(cc => cc.Canteen)
                .WithMany(c => c.CanteenCustomers)
                .HasForeignKey(cc => cc.CanteenId);

            //modelBuilder.Entity<Customer>()
            //    .HasOne(c => c.Meal)
            //    .WithOne(m => m.Customer)
            //    .HasForeignKey<Meal>(m => m.Id);

            //modelBuilder.Entity<Dish>()
            //    .HasOne(d => d.Meal)
            //    .WithMany(m => m.Dishes)
            //    .HasForeignKey(d => d.Id);

            //modelBuilder.Entity<Canteen>()
            //    .HasMany(c => c.Dishes)
            //    .WithMany(d => d.Canteens);

            //modelBuilder.Entity<Dish>()
            //    .HasMany(d => d.Canteens)
            //    .WithMany(c => c.Dishes);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DAB_SecondAssignment;Trusted_Connection=True;MultipleActiveResultSets=true");
        
    }
}
