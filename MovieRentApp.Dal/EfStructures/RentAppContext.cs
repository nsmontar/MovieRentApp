using System;
using Microsoft.EntityFrameworkCore;
using MovieRentApp.Models.Entities;
using MovieRentApp.Models.Entities.Base;
//using MovieRentApp.Models.ViewModels;

namespace MovieRentApp.Dal.EfStructures
{
    public class RentAppContext : DbContext
    {
        public RentAppContext(DbContextOptions<RentAppContext> options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Query<CartRecordWithProductInfo>().ToView("CartRecordWithProductInfo", "Store");
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.EmailAddress).HasName("IX_Customers").IsUnique();
            });
            modelBuilder.Entity<Rental>(entity =>
            {
                entity.Property(e => e.RentalDate).HasColumnType("datetime").HasDefaultValueSql("getdate()");
            });
        }
    }
}