using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MovieRentApp.Models.Entities.Base;
using Newtonsoft.Json;

namespace MovieRentApp.Models.Entities
{
    [Table("Rentals", Schema = "MovieRent")]
    public class Rental : EntityBase
    {
        [Required] 
        public int MovieId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(MovieId))]
        public Movie MovieNavigation { get; set; }
        
        [Required] 
        public int UserId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(UserId))]
        public User UserNavigation { get; set; }
        
        [DataType(DataType.DateTime)]
        [Display(Name = "Date Shipped")]
        public DateTime RentalDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date Shipped")]
        public DateTime ReturnDate { get; set; }
    }
}