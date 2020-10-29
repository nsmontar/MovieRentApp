using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieRentApp.Dal.EfStructures;

namespace MovieRentApp.Dal.Initialization
{
    public static class SampleDataInitializer
    {
        public static void DropAndCreateDatabase(RentAppContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();
        }

        internal static void ResetIdentity(RentAppContext context)
        {
            var tables = new[] { "Movies", "Users", "Rentals" };
            foreach (var itm in tables)
            {
                var rawSqlString = $"DBCC CHECKIDENT (\"MovieRent.{itm}\", RESEED, 0);";
                context.Database.ExecuteSqlCommand(rawSqlString);
            }
        }
        public static void ClearData(RentAppContext context)
        {
            context.Database.ExecuteSqlCommand("Delete from MovieRent.Movies");
            context.Database.ExecuteSqlCommand("Delete from MovieRent.Users");
            ResetIdentity(context);
        }


        internal static void SeedData(RentAppContext context)
        {
            if (!context.Movies.Any())
            {
                context.Movies.AddRange(SampleData.GetAllMovieRecords());
                context.SaveChanges();
            }
            if (!context.Users.Any())
            {
                context.Users.AddRange(SampleData.GetAllUserRecords());
                context.SaveChanges();
            }
        }
        public static void InitializeData(RentAppContext context)
        {
            //Ensure the database exists and is up to date
            context.Database.Migrate();
            ClearData(context);
            SeedData(context);
        }

    }
}