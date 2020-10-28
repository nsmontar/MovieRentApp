/*
This is a blank migration for manual creation of RentedMoviesView
Raw SQL code for view creation is in MigrationHelpers folder
*/

using Microsoft.EntityFrameworkCore.Migrations;
using MovieRentApp.Dal.EfStructures.MigrationHelpers;


namespace MovieRentApp.Dal.EfStructures.Migrations
{
    public partial class TSQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            ViewsHelper.CreateRentedMoviesView(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            ViewsHelper.DropRentedMoviesView(migrationBuilder);
        }
    }
}
