using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieRentApp.Dal.EfStructures.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_Customers",
                schema: "MovieRent",
                table: "Users",
                newName: "IX_Users");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "MovieRent",
                table: "Movies",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RentalDate",
                schema: "MovieRent",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                schema: "MovieRent",
                table: "Movies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "MovieRent",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "RentalDate",
                schema: "MovieRent",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                schema: "MovieRent",
                table: "Movies");

            migrationBuilder.RenameIndex(
                name: "IX_Users",
                schema: "MovieRent",
                table: "Users",
                newName: "IX_Customers");
        }
    }
}
