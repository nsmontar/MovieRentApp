using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MovieRentApp.Models.Entities;

namespace MovieRentApp.Models.ViewModels
{
    [Table("RentedMoviesView", Schema = "MovieRent")]
    public class RentedMovies : Movie
    {
        [DataType(DataType.DateTime)]
        [Display(Name = "Date Shipped")]
        public DateTime RentalDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date Shipped")]
        public DateTime ReturnDate { get; set; }
    }
}