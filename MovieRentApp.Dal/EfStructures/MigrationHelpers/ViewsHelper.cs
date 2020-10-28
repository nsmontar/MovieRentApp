using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieRentApp.Dal.EfStructures.MigrationHelpers
{
    // Helper class for using in manual TSQL migration
    public static class ViewsHelper
    {
        // SQL Server View for displaying rented movies
        // (movies which don't have a Return Date)
        // Use in 20201028212146_TSQL.cs Up method
        public static void CreateRentedMoviesView(
        MigrationBuilder builder) 
        {
            builder.Sql(@"
                CREATE VIEW [MovieRent].[RentedMoviesView] AS
                SELECT m.Id, m.Title, m.Duration, m.Author, 
                r.RentalDate, r.ReturnDate
                FROM  MovieRent.Movies m INNER JOIN MovieRent.Rentals r 
                ON m.Id = r.MovieId
                WHERE r.ReturnDate IS NULL");
        }
        // Use in 20201028212146_TSQL.cs Down method
        public static void DropRentedMoviesView(
        MigrationBuilder builder) 
        {
            builder.Sql("DROP VIEW [MovieRent].[RentedMoviesView]");
        }
    
    }
}