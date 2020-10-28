using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using MovieRentApp.Models.Entities.Base;

namespace MovieRentApp.Models.Entities
{
    [Table("Movies", Schema = "MovieRent")]
    public class Movie : EntityBase
    {
        [Required]
        [DataType(DataType.Text), MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        [DataType(DataType.Text), MaxLength(50)]
        public string Author { get; set; }

        [DataType(DataType.Text), MaxLength(8000)]
        public string Description { get; set; }
        [InverseProperty(nameof(Rental.MovieNavigation))]
        public List<Rental> Rentals { get; set; } = new List<Rental>();
    }
}