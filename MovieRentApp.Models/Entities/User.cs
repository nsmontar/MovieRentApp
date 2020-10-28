using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MovieRentApp.Models.Entities.Base;

namespace MovieRentApp.Models.Entities
{
    [Table("Users", Schema = "MovieRent")]
    public class User : EntityBase
    {
        [Required]
        [DataType(DataType.Text), MaxLength(50), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text), MaxLength(50), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress), MaxLength(50), Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password), MaxLength(50)]
        public string Password { get; set; }
        [InverseProperty(nameof(Rental.UserNavigation))]
        public List<Rental> Rentals { get; set; } = new List<Rental>();
    }
}